using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FancyDressShop
{
    public partial class CustomerRentals : UserControl
    {
        private Rental currentRental;
        private readonly RentalRepository rentalRepo = new RentalRepository();
        private string selectedFilePath;
        private CustomerCart parentCart;
        private Timer countdownTimer;
        public CustomerRentals(Rental rental, CustomerCart parentCart)
        {
            InitializeComponent();
            this.currentRental = rental;
            this.parentCart = parentCart;

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;
            LoadRentalData();
        }


        private void LoadRentalData()
        {
            lblRentalId.Text = $"บิล ID: {currentRental.RentalId}";
            lblStatus.Text = $"สถานะ: {RentalRepository.ConvertStatusToThai(currentRental.Status)}";
            lblRentalDate.Text = $"เช่า: {currentRental.RentalDate.ToShortDateString()}";
            lblDueDate.Text = $"กำหนดคืน: {currentRental.DueDate.ToShortDateString()}";
            lblCreationTime.Text = $"สร้างเมื่อ: {currentRental.CreationTime.ToShortDateString()}";
            lblReturnDateActual.Text = currentRental.ReturnDate.HasValue
                                       ? $"วันที่คืนจริง: {currentRental.ReturnDate.Value.ToShortDateString()}"
                                       : "ยังไม่คืนชุด";
            lblHandoverDate.Text = currentRental.HandoverDate.HasValue
                                   ? $"วันที่รับชุด: {currentRental.HandoverDate.Value.ToShortDateString()}"
                                   : "ยังไม่ได้รับชุด";

            decimal totalRentalFee = currentRental.TotalPrice - currentRental.DepositAmount;
            lblTotalPrice.Text = $"ยอดรวมค่าเช่า: {totalRentalFee:N2} บ.";
            lblDepositAmount.Text = $"ยอดมัดจำ: {currentRental.DepositAmount:N2} บ.";

            lblGrandTotal.Text = $"ยอดรวมที่ต้องชำระ: {currentRental.TotalPrice:N2} บ.";
            lblGrandTotal.Font = new Font(lblGrandTotal.Font, FontStyle.Bold);

            decimal outstanding = currentRental.OutstandingBalance.GetValueOrDefault(0);
            lblOutstandingFine.Text = $"ค่าปรับค้างชำระ: {outstanding:N2} บ.";
            lblOutstandingFine.ForeColor = outstanding > 0 ? Color.Red : Color.Green;

            lblFineIncurred.Visible = false;
            lblAmountToRefund.Visible = false;

            if (currentRental.Status == "Returned" || currentRental.Status == "Completed" || currentRental.Status == "Closed")
            {
                decimal fineIncurred = 0;
                if (!string.IsNullOrEmpty(currentRental.Notes))
                {
                    var noteLines = currentRental.Notes.Split('\n');
                    var returnNote = noteLines.FirstOrDefault(line => line.Contains("[System] Returned."));
                    if (returnNote != null)
                    {
                        var parts = returnNote.Split('.');
                        var finePart = parts.FirstOrDefault(p => p.Trim().StartsWith("Fine:"));
                        if (finePart != null)
                        {
                            decimal.TryParse(finePart.Replace("Fine:", "").Trim(), out fineIncurred);
                        }
                    }
                }

                if (fineIncurred > 0)
                {
                    lblFineIncurred.Text = $"ค่าปรับที่เกิดขึ้น: {fineIncurred:N2} บ.";
                    lblFineIncurred.Visible = true;
                }

                decimal amountToRefund = currentRental.DepositAmount - fineIncurred;
                if (amountToRefund < 0) amountToRefund = 0;

                lblAmountToRefund.Text = $"ยอดคืนมัดจำสุทธิ: {amountToRefund:N2} บ.";
                lblAmountToRefund.Visible = true;
            }

            if (currentRental.Details == null || currentRental.Details.Count == 0)
            {
                currentRental = rentalRepo.GetRentalById(currentRental.RentalId);
            }
            dgvRentalDetails.DataSource = currentRental.Details;
            ConfigureDetailsDataGridView();

            linkSlipPayment.Visible = false;
            linkSlipFine.Visible = false;
            linkSlipRefund.Visible = false;
            picSlipPreview.Visible = false;
            lblSlipType.Visible = false;
            btnViewSlip.Visible = false;
            lblNoSlipMessage.Visible = false;

            if (picSlipPreview.Image != null)
            {
                picSlipPreview.Image.Dispose();
                picSlipPreview.Image = null;
            }

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            bool hasPaymentSlip = !string.IsNullOrEmpty(currentRental.PaymentSlipPath) && File.Exists(Path.Combine(baseDir, currentRental.PaymentSlipPath));
            bool hasFineSlip = !string.IsNullOrEmpty(currentRental.FineSlipPath) && File.Exists(Path.Combine(baseDir, currentRental.FineSlipPath));
            bool hasRefundSlip = !string.IsNullOrEmpty(currentRental.RefundSlipPath) && File.Exists(Path.Combine(baseDir, currentRental.RefundSlipPath));

            if (hasPaymentSlip) linkSlipPayment.Visible = true;
            if (hasFineSlip) linkSlipFine.Visible = true;
            if (hasRefundSlip) linkSlipRefund.Visible = true;

            bool anySlip = false;
            if (hasRefundSlip)
            {
                LoadSlipToPreview(currentRental.RefundSlipPath, "สลิปคืนเงินมัดจำ");
                anySlip = true;
            }
            else if (hasFineSlip)
            {
                LoadSlipToPreview(currentRental.FineSlipPath, "สลิปชำระค่าปรับ");
                anySlip = true;
            }
            else if (hasPaymentSlip)
            {
                LoadSlipToPreview(currentRental.PaymentSlipPath, "สลิปชำระค่าเช่า");
                anySlip = true;
            }

            if (!anySlip)
            {
                lblNoSlipMessage.Visible = true;
            }

            if (currentRental.Status == "Pending Payment")
            {
                lblCountdown.Visible = true;
                countdownTimer.Start();
            }
            else
            {
                lblCountdown.Visible = false;
                countdownTimer.Stop();
            }
            UpdateActionPanel();
        }

        private void LoadSlipToPreview(string slipPathInDB, string slipType)
        {
            if (picSlipPreview.Image != null) picSlipPreview.Image.Dispose();
            picSlipPreview.Image = null;

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, slipPathInDB);

            if (string.IsNullOrEmpty(slipPathInDB) || !File.Exists(fullPath))
            {
                picSlipPreview.Visible = false;
                lblSlipType.Visible = false;
                btnViewSlip.Visible = false;
                return;
            }

            try
            {
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                using (var ms = new System.IO.MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    picSlipPreview.Image = Image.FromStream(ms);
                }
                picSlipPreview.SizeMode = PictureBoxSizeMode.Zoom;
                picSlipPreview.Visible = true;

                lblSlipType.Text = slipType;
                lblSlipType.Visible = true;
                btnViewSlip.Visible = true;
            }
            catch (Exception)
            {
                lblSlipType.Text = $"{slipType} (โหลดรูปไม่ได้)";
                lblSlipType.Visible = true;
            }
        }

        private void linkSlipPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentRental != null)
            {
                LoadSlipToPreview(currentRental.PaymentSlipPath, "สลิปชำระค่าเช่า");
            }
        }

        private void linkSlipFine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentRental != null)
            {
                LoadSlipToPreview(currentRental.FineSlipPath, "สลิปชำระค่าปรับ");
            }
        }

        private void linkSlipRefund_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentRental != null)
            {
                LoadSlipToPreview(currentRental.RefundSlipPath, "สลิปคืนเงินมัดจำ");
            }
        }

        private void ConfigureDetailsDataGridView()
        {
            dgvRentalDetails.AutoGenerateColumns = false;
            dgvRentalDetails.RowHeadersWidth = 35;

            dgvRentalDetails.Columns["DressName"].HeaderText = "ชื่อชุด";
            dgvRentalDetails.Columns["DressSize"].HeaderText = "ไซส์";
            dgvRentalDetails.Columns["RentalQuantity"].HeaderText = "จำนวน";
            dgvRentalDetails.Columns["PriceAtRental"].HeaderText = "ราคาเช่า/วัน";

            dgvRentalDetails.Columns["RentalDetailId"].Visible = false;
            dgvRentalDetails.Columns["RentalId"].Visible = false;
            dgvRentalDetails.Columns["DressInventoryId"].Visible = false;
            dgvRentalDetails.Columns["DailyRentalPrice"].Visible = false;

            dgvRentalDetails.Columns["DressName"].DisplayIndex = 0;
            dgvRentalDetails.Columns["DressSize"].DisplayIndex = 1;
            dgvRentalDetails.Columns["RentalQuantity"].DisplayIndex = 2;

            dgvRentalDetails.Columns["PriceAtRental"].DisplayIndex = 3;

            dgvRentalDetails.Columns["PriceAtRental"].DefaultCellStyle.Format = "N2";

            dgvRentalDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void UpdateActionPanel()
        {
            pnlAction.Visible = true;
            btnSelectSlip.Visible = false;
            btnSubmitSlip.Visible = false;
            btnCancelRental.Visible = false;
            btnPrintReceipt.Visible = false;
            btnShowStoreQR.Visible = false;

            switch (currentRental.Status)
            {
                case "Pending Payment":
                    btnSelectSlip.Visible = true;
                    btnSubmitSlip.Visible = true;
                    btnCancelRental.Visible = true;
                    btnSubmitSlip.Text = "ยืนยันการชำระเงิน";
                    btnShowStoreQR.Visible = true;
                    break;

                case "Returned":
                    btnPrintReceipt.Visible = true;
                    if (currentRental.OutstandingBalance.GetValueOrDefault() > 0)
                    {
                        btnSelectSlip.Visible = true;
                        btnSubmitSlip.Visible = true;
                        btnSubmitSlip.Text = "ยืนยันการชำระค่าปรับ";
                        btnShowStoreQR.Visible = true;
                    }
                    else
                    {
                    }
                    break;

                case "Pending Confirmation":
                case "Confirmed":
                case "Active":
                case "Overdue":
                case "Completed":
                case "Closed": 
                    btnPrintReceipt.Visible = true;
                    pnlAction.Visible = false;
                    break;

                case "Cancelled":
                    btnPrintReceipt.Visible = false;
                    pnlAction.Visible = false;
                    break;
            }
        }

        private void btnSelectSlip_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    btnSubmitSlip.Enabled = true;

                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(selectedFilePath);

                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                        {
                            if (picSlipPreview.Image != null)
                            {
                                picSlipPreview.Image.Dispose();
                            }

                            picSlipPreview.Image = Image.FromStream(ms);
                        }

                        picSlipPreview.SizeMode = PictureBoxSizeMode.Zoom;
                        picSlipPreview.Visible = true;

                        lblSlipType.Text = "ดูตัวอย่างสลิปที่เลือก";
                        lblSlipType.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"ไม่สามารถแสดงตัวอย่างรูปภาพได้: {ex.Message}", "Error Loading Preview");
                        picSlipPreview.Image = null;
                        lblSlipType.Text = "ไม่สามารถแสดงตัวอย่างไฟล์";
                    }
                }
            }
        }

        private void btnSubmitSlip_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
            {
                MessageBox.Show("กรุณาเลือกไฟล์สลิปก่อนดำเนินการ", "แจ้งเตือน");
                return;
            }

            string targetFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Slips");
            if (!Directory.Exists(targetFolder)) Directory.CreateDirectory(targetFolder);

            string fileExtension = Path.GetExtension(selectedFilePath);
            string slipTypeTag = btnSubmitSlip.Text.Contains("ค่าปรับ") ? "FINE" : "PAYMENT";
            string newFileName = $"{currentRental.RentalId}_{DateTime.Now.ToString("yyyyMMddHHmmss")}_{slipTypeTag}{fileExtension}";
            string targetPath = Path.Combine(targetFolder, newFileName);

            try
            {
                File.Copy(selectedFilePath, targetPath, true);

                bool success = false;
                if (currentRental.Status == "Pending Payment")
                {
                    success = rentalRepo.SubmitPaymentSlip(currentRental.RentalId, targetPath);
                    MessageBox.Show("ส่งสลิปชำระเงินเรียบร้อยแล้ว รอผู้ดูแลระบบอนุมัติ", "สำเร็จ");
                }
                else if (currentRental.Status == "Returned" && currentRental.OutstandingBalance.GetValueOrDefault() > 0)
                {
                    success = rentalRepo.SubmitFineSlip(currentRental.RentalId, targetPath);
                    MessageBox.Show("ส่งสลิปค่าปรับเรียบร้อยแล้ว รอผู้ดูแลระบบตรวจสอบ", "สำเร็จ");
                }

                if (success)
                {
                    MessageBox.Show("ส่งสลิปเรียบร้อยแล้ว", "สำเร็จ");

                    var parentControl = this.Parent as Control;
                    if (parentControl != null)
                    {
                        var cartControl = parentControl.Controls.OfType<CustomerCart>().FirstOrDefault();
                        if (cartControl != null)
                        {
                            cartControl.LoadRentalCards();
                            cartControl.Visible = true;
                        }
                    }

                    currentRental = rentalRepo.GetRentalById(currentRental.RentalId);
                    LoadRentalData();

                    parentCart.LoadRentalCards();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการส่งสลิป: " + ex.Message, "Error");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var parentControl = this.Parent as Control;
            if (parentControl != null)
            {
                if (parentCart != null)
                {
                    parentCart.LoadRentalCards();
                    parentCart.Visible = true;
                }

                parentControl.Controls.Remove(this);
            }
        }

        private void btnCancelRental_Click(object sender, EventArgs e)
        {
            if (currentRental.Status != "Pending Payment")
            {
                MessageBox.Show("บิลนี้สามารถยกเลิกได้เฉพาะในสถานะ 'Pending Payment' เท่านั้น", "แจ้งเตือน");
                return;
            }

            var confirmResult = MessageBox.Show(
                "คุณต้องการยกเลิกบิลนี้ใช่หรือไม่? สต็อกชุดจะถูกคืนทันที",
                "ยืนยันการยกเลิก",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                bool success = rentalRepo.CancelRental(currentRental.RentalId);

                if (success)
                {
                    MessageBox.Show("ยกเลิกบิลเรียบร้อยแล้ว สต็อกถูกคืนแล้ว", "สำเร็จ");

                    if (parentCart != null)
                    {
                        parentCart.LoadRentalCards();
                        parentCart.Visible = true;
                    }
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                }
            }
        }
        private void btnViewSlip_Click(object sender, EventArgs e)
        {
            if (picSlipPreview.Image == null)
            {
                MessageBox.Show("ไม่มีรูปภาพสลิปที่จะแสดง", "แจ้งเตือน");
                return;
            }

            try
            {
                Image imageToShow = new Bitmap(picSlipPreview.Image);

                SlipViewerForm viewer = new SlipViewerForm(imageToShow);
                viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการเปิดรูปภาพ: {ex.Message}", "ข้อผิดพลาด");
            }
        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (currentRental != null)
            {
                DateTime creationTime = currentRental.CreationTime;
                DateTime dueDate = creationTime.AddHours(24);
                TimeSpan remainingTime = dueDate - DateTime.Now;

                if (remainingTime.TotalSeconds > 0)
                {
                    lblCountdown.Text = $"เหลือเวลาชำระเงิน: {remainingTime.Hours:D2}:{remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
                }
                else
                {
                    countdownTimer.Stop();
                    lblCountdown.Text = "หมดเวลาชำระเงิน";
                    UpdateActionPanel();
                }
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (currentRental == null)
            {
                MessageBox.Show("ไม่สามารถพิมพ์ใบเสร็จได้ เนื่องจากไม่มีข้อมูลบิล", "ข้อผิดพลาด");
                return;
            }

            try
            {
                ReceiptGenerator generator = new ReceiptGenerator();

                System.Drawing.Image receiptImage = generator.GenerateReceiptImage(currentRental);

                if (receiptImage != null)
                {
                    using (ReceiptPreviewForm previewForm = new ReceiptPreviewForm(receiptImage, currentRental))
                    {
                        previewForm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการสร้างตัวอย่างใบเสร็จ: {ex.Message}", "ข้อผิดพลาด");
            }
        }

        private void btnShowStoreQR_Click(object sender, EventArgs e)
        {
            string qrPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "qrfancydress.jpg");

            if (!File.Exists(qrPath))
            {
                MessageBox.Show("ไม่พบรูปภาพ QR Code ของร้านค้า", "ข้อผิดพลาด");
                return;
            }

            try
            {
                using (var fs = new FileStream(qrPath, FileMode.Open, FileAccess.Read))
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    Image qrImage = Image.FromStream(ms);

                    SlipViewerForm popup = new SlipViewerForm(qrImage);
                    popup.Text = "QR Code สำหรับชำระเงิน";
                    popup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดรูปภาพ: " + ex.Message);
            }
        }
    }
}