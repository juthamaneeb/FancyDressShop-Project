using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FancyDressShop
{
    public partial class AdminRentalManager : UserControl
    {
        private MainForm parentForm;
        private readonly RentalRepository rentalRepo;
        private Rental currentRental;
        private string refundSelectedFilePath;
        private readonly CustomerRepository customerRepo = new CustomerRepository();
        public AdminRentalManager(MainForm mainForm)
        {
            InitializeComponent();
            this.parentForm = mainForm;

            this.rentalRepo = new RentalRepository();
            this.customerRepo = new CustomerRepository();

            Dictionary<string, string> rentalStatusMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "All", "--สถานะการเช่า--" },
                { "Pending Payment", "รอชำระเงิน" },
                { "Pending Confirmation", "รอการอนุมัติ" },
                { "Active", "กำลังใช้งาน" },
                { "Confirmed", "ยืนยันการจอง" },
                { "Overdue", "เกินกำหนดคืน" },
                { "Returned", "คืนชุดแล้ว" },
                { "Completed", "เสร็จสมบูรณ์" },
                { "Cancelled", "ยกเลิก" },
                { "Closed", "ปิดบัญชีแล้ว" }
            };

            cmbRentalStatusFilter.DataSource = new BindingSource(rentalStatusMap, null);
            cmbRentalStatusFilter.DisplayMember = "Value";
            cmbRentalStatusFilter.ValueMember = "Key";
            cmbRentalStatusFilter.SelectedValue = "All";

            SetupPaymentStatusFilterComboBox();

            cmbRentalStatusFilter.SelectedIndexChanged += FilterChanged_Handler;
            cmbPaymentStatusFilter.SelectedIndexChanged += FilterChanged_Handler;

            dgvRentals.SelectionChanged += dgvRentals_SelectionChanged;
            dgvRentals.CellFormatting += dgvRentals_CellFormatting;

            LoadRentals();

            if (dgvRentals.Columns.Count > 0)
            {
                ConfigureDataGridView();
            }
        }


        private void ConfigureDataGridView()
        {
            dgvRentals.AutoGenerateColumns = false;
            dgvRentals.RowHeadersWidth = 35;

            dgvRentals.Columns["RentalId"].HeaderText = "ID บิล";
            dgvRentals.Columns["CustomerName"].HeaderText = "ลูกค้า";
            dgvRentals.Columns["CreationTime"].HeaderText = "สร้างเมื่อ";
            dgvRentals.Columns["DueDate"].HeaderText = "กำหนดคืน";
            dgvRentals.Columns["Status"].HeaderText = "สถานะการเช่า";
            dgvRentals.Columns["PaymentStatus"].HeaderText = "สถานะชำระ";
            dgvRentals.Columns["TotalPrice"].HeaderText = "ยอดรวม";
            dgvRentals.Columns["OutstandingBalance"].HeaderText = "ค่าปรับค้าง";

            string[] columnsToHide = {
                "CustomerId", "RentalDate", "ReturnDate", "DepositAmount",
                "PaymentSlipPath", "FineSlipPath", "Notes", "HandoverDate",
                "PaymentConfirmedDate", "FinalizeDate", "RefundSlipPath",
                "Details", "Customer" 
            };

            foreach (string colName in columnsToHide)
            {
                if (dgvRentals.Columns.Contains(colName))
                {
                    dgvRentals.Columns[colName].Visible = false;
                }
            }

            dgvRentals.Columns["RentalId"].DisplayIndex = 0;
            dgvRentals.Columns["CustomerName"].DisplayIndex = 1;
            dgvRentals.Columns["CreationTime"].DisplayIndex = 2;
            dgvRentals.Columns["DueDate"].DisplayIndex = 3;
            dgvRentals.Columns["Status"].DisplayIndex = 4;
            dgvRentals.Columns["PaymentStatus"].DisplayIndex = 5;
            dgvRentals.Columns["TotalPrice"].DisplayIndex = 6;
            dgvRentals.Columns["OutstandingBalance"].DisplayIndex = 7;

            dgvRentals.Columns["TotalPrice"].DefaultCellStyle.Format = "N2";
            dgvRentals.Columns["OutstandingBalance"].DefaultCellStyle.Format = "N2";

            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigureDetailsDataGridView()
        {
            dgvRentalDetails.AutoGenerateColumns = false;
            dgvRentalDetails.RowHeadersWidth = 35;

            dgvRentalDetails.Columns["DressName"].HeaderText = "ชื่อชุด";
            dgvRentalDetails.Columns["DressSize"].HeaderText = "ไซส์";
            dgvRentalDetails.Columns["RentalQuantity"].HeaderText = "จำนวน";
            dgvRentalDetails.Columns["PriceAtRental"].HeaderText = "ราคาเช่า/วัน";

            if (!dgvRentalDetails.Columns.Contains("DepositPrice"))
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "DepositPrice";
                col.DataPropertyName = "DepositPrice";
                dgvRentalDetails.Columns.Add(col);
            }

            dgvRentalDetails.Columns["DepositPrice"].HeaderText = "มัดจำ/ชุด";
            
            dgvRentalDetails.Columns["RentalDetailId"].Visible = false;
            dgvRentalDetails.Columns["RentalId"].Visible = false;
            dgvRentalDetails.Columns["DressInventoryId"].Visible = false;
            dgvRentalDetails.Columns["DailyRentalPrice"].Visible = false;

            dgvRentalDetails.Columns["DressName"].DisplayIndex = 0;
            dgvRentalDetails.Columns["DressSize"].DisplayIndex = 1;
            dgvRentalDetails.Columns["RentalQuantity"].DisplayIndex = 2;

            dgvRentalDetails.Columns["PriceAtRental"].DisplayIndex = 3;
            dgvRentalDetails.Columns["DepositPrice"].DisplayIndex = 4;

            dgvRentalDetails.Columns["PriceAtRental"].DefaultCellStyle.Format = "N2";
            dgvRentalDetails.Columns["DepositPrice"].DefaultCellStyle.Format = "N2";

            dgvRentalDetails.Columns["DressName"].FillWeight = 50;
            dgvRentalDetails.Columns["PriceAtRental"].FillWeight = 20;
            dgvRentalDetails.Columns["DepositPrice"].FillWeight = 20;
            dgvRentalDetails.Columns["DressSize"].FillWeight = 15; 
            dgvRentalDetails.Columns["RentalQuantity"].FillWeight = 15;
            dgvRentalDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FilterChanged_Handler(object sender, EventArgs e)
        {
            string rentalStatusFilter = cmbRentalStatusFilter.SelectedValue?.ToString() ?? "All";
            string paymentStatusFilter = cmbPaymentStatusFilter.SelectedValue?.ToString() ?? "All";
            string searchTerm = txtSearch.Text.Trim();
            LoadRentals(rentalStatusFilter, paymentStatusFilter, searchTerm);
        }


        private void DisplayRentalDetails()
        {
            if (currentRental == null)
            {
                lblCustomerName.Text = "ลูกค้า: -";
                lblCustomerPhone.Text = "โทร: -";
                lblCustomerEmail.Text = "อีเมล: -";
                lblCustomerAddress.Text = "ที่อยู่: -";

                lblBankName.Text = "ธนาคาร: -";
                lblAccountNumber.Text = "เลขที่บัญชี: -";
                lblAccountName.Text = "ชื่อบัญชี: -";

                lblCreationDate.Text = "สร้างเมื่อ: -";
                lblRentalStartDate.Text = "เริ่มเช่า: -";
                lblDueDate.Text = "กำหนดคืน: -";
                lblReturnDate.Text = "คืนจริง: -";
                lblPaymentConfirmedDate.Text = "อนุมัติชำระเงิน: -";
                lblHandoverDate.Text = "มอบชุดเมื่อ: -";
                lblFinalizeDate.Text = "ปิดบิลเมื่อ: -";
                lblRentalDays.Text = "จำนวนวัน: -";

                lblTotalPrice.Text = "ยอดรวมทั้งหมด: -";
                lblDepositAmount.Text = "ค่ามัดจำ: -";
                lblOutstandingFine.Text = "ค่าปรับค้าง: -";
                lblAmountToRefund.Text = "ยอดคืนลูกค้า: -";

                dgvRentalDetails.DataSource = null;
                if (picRefundSlipPreview.Image != null) picRefundSlipPreview.Image.Dispose();
                picRefundSlipPreview.Image = null;

                if (currentRental.Status == "Completed" || currentRental.Status == "Closed")
                {
                    decimal netRefund = GetNetRefundAmount(currentRental);

                    if (netRefund > 0)
                    {
                        lblAmountToRefund.Text = $"ยอดคืนลูกค้า (สุทธิ): {netRefund:N2} บ.";
                        lblAmountToRefund.ForeColor = Color.Black;
                    }
                    else
                    {
                        lblAmountToRefund.Text = "ยอดคืนลูกค้า: 0.00 บ. (หักค่าปรับหมดแล้ว)";
                        lblAmountToRefund.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblAmountToRefund.Text = "ยอดคืนลูกค้า: -";
                    lblAmountToRefund.ForeColor = Color.Black;
                }

                return;
            }

            Customer customerDetails = customerRepo.GetCustomerById(currentRental.CustomerId);
            if (customerDetails != null)
            {
                lblCustomerName.Text = $"ลูกค้า: {customerDetails.FullName}";
                lblCustomerPhone.Text = $"โทร: {customerDetails.PhoneNumber ?? "-"}";
                lblCustomerEmail.Text = $"อีเมล: {customerDetails.Email ?? "-"}";
                lblCustomerAddress.Text = $"ที่อยู่: {customerDetails.Address ?? "-"}";

                lblBankName.Text = $"ธนาคาร: {customerDetails.BankName ?? "-"}";
                lblAccountNumber.Text = $"เลขที่บัญชี: {customerDetails.AccountNumber ?? "-"}";
                lblAccountName.Text = $"ชื่อบัญชี: {customerDetails.AccountName ?? "-"}";
            }

            lblCreationDate.Text = $"สร้างเมื่อ: {currentRental.CreationTime.ToShortDateString()}";
            lblRentalStartDate.Text = $"เริ่มเช่า: {currentRental.RentalDate.ToShortDateString()}";
            lblDueDate.Text = $"กำหนดคืน: {currentRental.DueDate.ToShortDateString()}";
            lblReturnDate.Text = currentRental.ReturnDate.HasValue ? $"คืนจริง: {currentRental.ReturnDate.Value.ToShortDateString()}" : "คืนจริง: ยังไม่คืนชุด";
            lblPaymentConfirmedDate.Text = currentRental.PaymentConfirmedDate.HasValue ? $"อนุมัติชำระเงิน: {currentRental.PaymentConfirmedDate.Value.ToShortDateString()}" : "อนุมัติชำระเงิน: รออนุมัติ";
            lblHandoverDate.Text = currentRental.HandoverDate.HasValue ? $"มอบชุดเมื่อ: {currentRental.HandoverDate.Value.ToShortDateString()}" : "มอบชุดเมื่อ: ยังไม่มอบชุด";
            lblFinalizeDate.Text = currentRental.FinalizeDate.HasValue ? $"ปิดบิลเมื่อ: {currentRental.FinalizeDate.Value.ToShortDateString()}" : "ปิดบิลเมื่อ: ยังไม่ปิดบิล";

            int days = (int)Math.Ceiling((currentRental.DueDate.Date - currentRental.RentalDate.Date).TotalDays);
            if (days == 0) days = 1;

            lblRentalDays.Text = $"จำนวนวันเช่า: {days} วัน";

            lblTotalPrice.Text = $"ยอดรวมทั้งหมด: {currentRental.TotalPrice:N2} บ.";
            lblDepositAmount.Text = $"ค่ามัดจำ: {currentRental.DepositAmount:N2} บ.";
            decimal outstanding = currentRental.OutstandingBalance.GetValueOrDefault(0);
            lblOutstandingFine.Text = $"ค่าปรับค้างชำระ: {outstanding:N2} บ.";
            lblOutstandingFine.ForeColor = outstanding > 0 ? Color.Red : Color.Green;

            if (currentRental.Status == "Completed" || currentRental.Status == "Closed")
            {
                lblAmountToRefund.Text = $"ยอดคืนลูกค้า (มัดจำ): {currentRental.DepositAmount:N2} บ.";
            }
            else
            {
                lblAmountToRefund.Text = "ยอดคืนลูกค้า: -";
            }

            if (currentRental.Details != null)
            {
                dgvRentalDetails.DataSource = currentRental.Details;
                ConfigureDetailsDataGridView();
            }
            else
            {
                dgvRentalDetails.DataSource = null;
            }

            if (picRefundSlipPreview.Image != null) picRefundSlipPreview.Image.Dispose();
            picRefundSlipPreview.Image = null;

            if (currentRental.Status == "Closed" && !string.IsNullOrEmpty(currentRental.RefundSlipPath) && File.Exists(currentRental.RefundSlipPath))
            {
                try
                {
                    using (var stream = new FileStream(currentRental.RefundSlipPath, FileMode.Open, FileAccess.Read))
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        picRefundSlipPreview.Image = Image.FromStream(ms);
                    }
                    picRefundSlipPreview.SizeMode = PictureBoxSizeMode.Zoom;
                    picRefundSlipPreview.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ไม่สามารถโหลดรูปสลิปคืนเงินได้: {ex.Message}", "Error");
                }
            }
        }

        private void LoadRentals(string rentalStatusFilter = "All", string paymentStatusFilter = "All", string searchTerm = "")
        {
            try
            {
                List<Rental> rentals = rentalRepo.GetAllRentals();

                if (rentalStatusFilter != "All")
                {
                    rentals = rentals.Where(r => r.Status.Equals(rentalStatusFilter, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (paymentStatusFilter != "All")
                {
                    rentals = rentals.Where(r => r.PaymentStatus.Equals(paymentStatusFilter, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    string lowerSearchTerm = searchTerm.ToLower();
                    rentals = rentals.Where(r =>
                        r.RentalId.ToString().Contains(lowerSearchTerm) ||
                        (r.CustomerName != null && r.CustomerName.ToLower().Contains(lowerSearchTerm))
                    ).ToList();
                }

                rentals = rentals.OrderByDescending(r => r.CreationTime).ToList();
                dgvRentals.DataSource = rentals;
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลบิล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnApprovePayment_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0) return;

            DialogResult result = MessageBox.Show($"ต้องการอนุมัติการชำระเงินสำหรับบิลที่ {currentRental.RentalId} หรือไม่?\n(สถานะจะเปลี่ยนเป็น 'Confirmed')",
                                          "ยืนยันการอนุมัติ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (rentalRepo.ApprovePayment(currentRental.RentalId))
                {
                    MessageBox.Show("อนุมัติการชำระเงินเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRentals();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถอนุมัติได้ กรุณาตรวจสอบสถานะบิลหรือฐานข้อมูล", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnRecordReturn_Click(object sender, EventArgs e)
        {
            if (currentRental == null)
            {
                MessageBox.Show("กรุณาเลือกบิลที่ต้องการบันทึกการคืนชุด", "แจ้งเตือน");
                return;
            }

            DataGridViewRow selectedRow = dgvRentals.SelectedRows[0];
            int rentalId = Convert.ToInt32(selectedRow.Cells["RentalId"].Value);

            if (currentRental.Status != "Active" && currentRental.Status != "Overdue")
            {
                MessageBox.Show("บิลนี้ต้องอยู่ในสถานะ 'Active' หรือ 'Overdue' เท่านั้นจึงจะบันทึกการคืนชุดได้", "ข้อผิดพลาด");
                return;
            }

            DateTime actualReturnDate = dtpActionDate.Value.Date;

            DateTime dueDate = Convert.ToDateTime(selectedRow.Cells["DueDate"].Value).Date;

            string confirmMsg = $"บิลที่ {rentalId} กำหนดคืน: {dueDate.ToShortDateString()}\n" +
                                $"วันที่คืนจริง (จากปฏิทิน): {actualReturnDate.ToShortDateString()}\n\n" +
                                $"ต้องการบันทึกการคืนชุดและคำนวณค่าปรับหรือไม่?";

            DialogResult result = MessageBox.Show(confirmMsg, "ยืนยันการคืนชุด", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (rentalRepo.RecordReturnAndCalculateFine(rentalId, actualReturnDate))
                {
                    Rental returnedRental = rentalRepo.GetRentalById(rentalId);

                    string fineMessage = returnedRental.OutstandingBalance > 0
                                         ? $"สำเร็จ! บันทึกการคืนชุดเรียบร้อย และมีค่าปรับค้างชำระ: {returnedRental.OutstandingBalance:N2} บาท"
                                         : "สำเร็จ! บันทึกการคืนชุดเรียบร้อย ไม่มีค่าปรับ";

                    MessageBox.Show(fineMessage, "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRentals();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถบันทึกการคืนชุดได้ กรุณาตรวจสอบสถานะบิลหรือฐานข้อมูล", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetupPaymentStatusFilterComboBox()
        {
            var statusMap = new Dictionary<string, string>
                {
                    { "All", "--สถานะชำระ--" },
                    { "Unpaid", "ยังไม่ชำระ" },
                    { "Pending", "รอตรวจสอบ" },
                    { "Paid", "ชำระแล้ว" },
                    { "Cancelled", "ยกเลิก" },
                    { "Rejected", "ถูกปฏิเสธ" }
                };

            cmbPaymentStatusFilter.DataSource = new BindingSource(statusMap, null);
            cmbPaymentStatusFilter.DisplayMember = "Value";
            cmbPaymentStatusFilter.ValueMember = "Key";
            cmbPaymentStatusFilter.SelectedValue = "All";
        }

        private void dgvRentals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRentals.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                e.Value = RentalRepository.ConvertStatusToThai(e.Value.ToString());
                e.FormattingApplied = true;
            }

            if (dgvRentals.Columns[e.ColumnIndex].Name == "PaymentStatus" && e.Value != null)
            {
                e.Value = RentalRepository.ConvertStatusToThai(e.Value.ToString());
                e.FormattingApplied = true;
            }
        }

        private void dgvRentals_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0 || dgvRentals.CurrentRow == null)
            {
                currentRental = null;
                lblSelectedRentalId.Text = "N/A";
                if (picSlipPreview.Image != null)
                {
                    picSlipPreview.Image.Dispose();
                    picSlipPreview.Image = null;
                }
                UpdateActionButtonsState();
                return;
            }

            DataGridViewRow selectedRow = dgvRentals.SelectedRows[0];
            Rental selectedRental = selectedRow.DataBoundItem as Rental;

            if (selectedRental == null)
            {
                currentRental = null;
                UpdateActionButtonsState();
                return;
            }

            currentRental = rentalRepo.GetRentalById(selectedRental.RentalId);

            if (currentRental == null)
            {
                lblSelectedRentalId.Text = "Error";
                if (picSlipPreview.Image != null) picSlipPreview.Image.Dispose();
                picSlipPreview.Image = null;
                UpdateActionButtonsState();
                return;
            }

            linkSlipPayment.Visible = false;
            linkSlipFine.Visible = false;
            if (picSlipPreview.Image != null) picSlipPreview.Image.Dispose();
            picSlipPreview.Image = null;

            bool hasPaymentSlip = !string.IsNullOrEmpty(currentRental.PaymentSlipPath) && File.Exists(currentRental.PaymentSlipPath);
            bool hasFineSlip = !string.IsNullOrEmpty(currentRental.FineSlipPath) && File.Exists(currentRental.FineSlipPath);

            if (hasPaymentSlip) linkSlipPayment.Visible = true;
            if (hasFineSlip) linkSlipFine.Visible = true;

            if (hasPaymentSlip)
            {
                LoadSlipToPreview(currentRental.PaymentSlipPath);
            }
            else if (hasFineSlip)
            {
                LoadSlipToPreview(currentRental.FineSlipPath);
            }

            if (picRefundSlipPreview.Image != null)
            {
                picRefundSlipPreview.Image.Dispose();
                picRefundSlipPreview.Image = null;
            }
            refundSelectedFilePath = string.Empty;

            lblSelectedRentalId.Text = currentRental.RentalId.ToString();
            UpdateActionButtonsState();
            DisplayRentalDetails();

        }

        private void linkSlipPayment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentRental != null)
            {
                LoadSlipToPreview(currentRental.PaymentSlipPath);
            }
        }

        private void linkSlipFine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentRental != null)
            {
                LoadSlipToPreview(currentRental.FineSlipPath);
            }
        }

        private void LoadSlipToPreview(string slipPathInDB)
        {
            if (picSlipPreview.Image != null) picSlipPreview.Image.Dispose();
            picSlipPreview.Image = null;

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, slipPathInDB);

            if (string.IsNullOrEmpty(slipPathInDB) || !File.Exists(fullPath)) return;

            try
            {
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    picSlipPreview.Image = Image.FromStream(ms);
                }
                picSlipPreview.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถโหลดรูปสลิปได้: {ex.Message}", "Error");
            }
        }

        private void btnRejectPayment_Click(object sender, EventArgs e)
        {
            if (currentRental == null) return;

            int rentalId = Convert.ToInt32(dgvRentals.SelectedRows[0].Cells["RentalId"].Value);
            string paymentStatus = dgvRentals.SelectedRows[0].Cells["PaymentStatus"].Value?.ToString();

            if (currentRental.Status != "Pending Confirmation")
            {
                MessageBox.Show("บิลนี้ไม่อยู่ในสถานะ 'Pending Confirmation' จึงไม่สามารถปฏิเสธได้", "ข้อผิดพลาด");
                return;
            }

            DialogResult result = MessageBox.Show($"ต้องการ 'ปฏิเสธ' การชำระเงินสำหรับบิลที่ {rentalId} หรือไม่? (สถานะบิลจะกลับไปเป็น 'Pending Payment' และ 'Unpaid')",
                                                 "ยืนยันการปฏิเสธ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (rentalRepo.RejectPayment(rentalId))
                {
                    MessageBox.Show("ปฏิเสธการชำระเงินเรียบร้อยแล้ว", "สำเร็จ");
                    if (picSlipPreview.Image != null)
                    {
                        picSlipPreview.Image.Dispose();
                        picSlipPreview.Image = null;
                    }

                    LoadRentals();
                }
            }


        }

        private void UpdateActionButtonsState()
        {
            bool enableButtons = (currentRental != null);

            btnApprovePayment.Enabled = false;
            btnRejectPayment.Enabled = false;
            btnHandOver.Enabled = false;
            btnRecordReturn.Enabled = false;
            btnConfirmFinePayment.Enabled = false;
            btnViewSlip.Enabled = false;
            btnFinalizeRefund.Enabled = false;
            picRefundSlipPreview.Visible = false;
            btnSelectRefundSlip.Visible = false;
            btnRejectFine.Enabled = false;

            decimal netRefund = GetNetRefundAmount(currentRental);

            if (!enableButtons) return;

            string status = currentRental.Status;
            decimal outstanding = currentRental.OutstandingBalance ?? 0;
            string slipPath = currentRental.PaymentSlipPath;
            string refundPath = currentRental.RefundSlipPath;
            btnViewSlip.Enabled = !string.IsNullOrEmpty(slipPath) && System.IO.File.Exists(slipPath);


            switch (status)
            {
                case "Pending Confirmation":
                    btnApprovePayment.Enabled = true;
                    btnRejectPayment.Enabled = true;
                    break;

                case "Confirmed":
                    btnHandOver.Enabled = true;
                    break;

                case "Active":
                case "Overdue":
                    btnRecordReturn.Enabled = true;
                    break;

                case "Returned":
                    if (outstanding > 0)
                    {
                        btnConfirmFinePayment.Enabled = true;
                        if(!string.IsNullOrEmpty(currentRental.FineSlipPath))
                        {
                            btnRejectFine.Enabled = true;
                        }
                    }
                    else
                    {
                        btnFinalizeRefund.Enabled = true;
                    }
                    break;

                case "Completed":
                    if (netRefund > 0)
                    {
                        btnFinalizeRefund.Enabled = true;
                        btnFinalizeRefund.Text = "คืนเงินมัดจำและปิดบิล";
                    }
                    else
                    {
                        btnFinalizeRefund.Enabled = true;
                        btnFinalizeRefund.Text = "ปิดบิล (ไม่ต้องคืนเงิน)";
                    }
                    break;

                case "Pending Payment":
                case "Cancelled":
                case "Closed":
                    break;
            }

            if (btnFinalizeRefund.Enabled && btnFinalizeRefund.Text != "ปิดบิล (ไม่ต้องคืนเงิน)")
            {
                btnSelectRefundSlip.Visible = true;
                picRefundSlipPreview.Visible = true;
            }
            else
            {
                btnSelectRefundSlip.Visible = false;
                picRefundSlipPreview.Visible = false;
            }
        }

        private void btnConfirmFinePayment_Click(object sender, EventArgs e)
        {
            if (currentRental == null || currentRental.OutstandingBalance.GetValueOrDefault() <= 0) return;

            DateTime selectedDate = dtpActionDate.Value.Date;

            DialogResult result = MessageBox.Show(
                $"ต้องการอนุมัติการชำระค่าปรับสำหรับบิลที่ {currentRental.RentalId} ในวันที่ {selectedDate.ToShortDateString()} หรือไม่?",
                "ยืนยันการอนุมัติค่าปรับ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (rentalRepo.ApproveFinePayment(currentRental.RentalId, selectedDate))
                {
                    MessageBox.Show("อนุมัติการชำระค่าปรับเรียบร้อยแล้ว", "สำเร็จ");
                    LoadRentals();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถอนุมัติได้ กรุณาตรวจสอบสถานะบิล", "ข้อผิดพลาด");
                }
            }
        }

        private void btnHandOver_Click(object sender, EventArgs e)
        {
            if (currentRental == null)
            {
                MessageBox.Show("กรุณาเลือกบิลที่ต้องการมอบชุด", "แจ้งเตือน");
                return;
            }

            DateTime selectedDate = dtpActionDate.Value.Date;

            DialogResult result = MessageBox.Show(
                $"ยืนยันการมอบชุดสำหรับบิลที่ {currentRental.RentalId} ในวันที่ {selectedDate.ToShortDateString()} หรือไม่?",
                "ยืนยันการมอบชุด", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (rentalRepo.HandOverDress(currentRental.RentalId, selectedDate))
                {
                    MessageBox.Show("บันทึกการมอบชุดเรียบร้อยแล้ว", "สำเร็จ");
                    LoadRentals();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถบันทึกการมอบชุดได้ กรุณาตรวจสอบสถานะบิล", "ข้อผิดพลาด");
                }
            }
        }

        private void btnViewSlip_Click(object sender, EventArgs e)
        {
            if (picSlipPreview.Image == null)
            {
                MessageBox.Show("ไม่มีสลิปให้ดูในขณะนี้", "แจ้งเตือน");
                return;
            }

            try
            {
                Image slipImageToShow = new Bitmap(picSlipPreview.Image);
                SlipViewerForm viewer = new SlipViewerForm(slipImageToShow);
                viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการเปิดดูรูปภาพ: {ex.Message}", "ข้อผิดพลาด");
            }
        }

        private void btnCheckAutoCancel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "ยืนยันการตรวจสอบและยกเลิกบิลที่ยังไม่ชำระเงินเกิน 24 ชั่วโมงหรือไม่?\n(ระบบจะคืนสต็อกชุดโดยอัตโนมัติ)",
                "ยืนยันการยกเลิกอัตโนมัติ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int cancelledCount = rentalRepo.AutoCancelPendingRentals();

                if (cancelledCount > 0)
                {
                    MessageBox.Show($"สำเร็จ! ยกเลิกบิลที่ค้างชำระและคืนสต็อกเรียบร้อยแล้วจำนวน {cancelledCount} รายการ",
                                    "ยกเลิกอัตโนมัติสำเร็จ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ไม่มีบิลที่ต้องยกเลิกอัตโนมัติในขณะนี้",
                                    "แจ้งเตือน",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                LoadRentals();
            }


        }

        private void btnFinalizeRefund_Click(object sender, EventArgs e)
        {
            if (currentRental == null || !btnFinalizeRefund.Enabled) return;

            decimal netRefund = GetNetRefundAmount(currentRental);
            string targetPath = "";

            if (netRefund > 0)
            {
                if (string.IsNullOrEmpty(refundSelectedFilePath) || !System.IO.File.Exists(refundSelectedFilePath))
                {
                    MessageBox.Show("กรุณาเลือกไฟล์สลิปยืนยันการคืนเงินมัดจำ ก่อนดำเนินการ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string targetFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RefundSlips");
                    if (!Directory.Exists(targetFolder)) Directory.CreateDirectory(targetFolder);

                    string fileExtension = Path.GetExtension(refundSelectedFilePath);
                    string newFileName = $"{currentRental.RentalId}_REFUND_{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
                    targetPath = Path.Combine(targetFolder, newFileName);

                    if (picRefundSlipPreview.Image != null)
                    {
                        picRefundSlipPreview.Image.Dispose();
                        picRefundSlipPreview.Image = null;
                    }

                    File.Copy(refundSelectedFilePath, targetPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"เกิดข้อผิดพลาดในการบันทึกสลิป: {ex.Message}", "ข้อผิดพลาด");
                    return; 
                }
            }
            string confirmMsg = (netRefund > 0)
                ? $"ยืนยันการคืนเงินมัดจำจำนวน {netRefund:N2} บ. และปิดบิลหรือไม่?"
                : "ยืนยันการปิดบิล (เงินมัดจำถูกหักค่าปรับหมดแล้ว) หรือไม่?";

            if (MessageBox.Show(confirmMsg, "ยืนยันการปิดบิล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (rentalRepo.FinalizeRentalAndRefund(currentRental.RentalId, netRefund, targetPath))
                {
                    MessageBox.Show("ปิดบิลเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    refundSelectedFilePath = string.Empty;
                    LoadRentals();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถปิดบิลได้ กรุณาตรวจสอบฐานข้อมูล", "ข้อผิดพลาด");
                }
            }
        }

        private void btnSelectRefundSlip_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    refundSelectedFilePath = ofd.FileName;

                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(refundSelectedFilePath);

                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                        {
                            if (picRefundSlipPreview.Image != null) picRefundSlipPreview.Image.Dispose();

                            picRefundSlipPreview.Image = Image.FromStream(ms);
                            picRefundSlipPreview.SizeMode = PictureBoxSizeMode.Zoom;
                        }

                        btnFinalizeRefund.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"ไม่สามารถแสดงตัวอย่างรูปภาพสลิปคืนเงินได้: {ex.Message}", "Error");
                        picRefundSlipPreview.Image = null;
                        refundSelectedFilePath = string.Empty;
                        btnFinalizeRefund.Enabled = false;
                    }
                }
            }
        }

        private decimal GetNetRefundAmount(Rental rental)
        {
            if (rental == null) return 0;
            if (rental.OutstandingBalance.GetValueOrDefault() > 0) return 0;

            decimal fineIncurred = 0;
            if (!string.IsNullOrEmpty(rental.Notes))
            {
                var noteLines = rental.Notes.Split('\n');
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

            decimal netRefund = rental.DepositAmount - fineIncurred;

            return (netRefund > 0) ? netRefund : 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnRejectFine_Click(object sender, EventArgs e)
        {
            if (currentRental == null) return;

            int rentalId = currentRental.RentalId;

            DialogResult result = MessageBox.Show(
                $"ยืนยันการปฏิเสธสลิปค่าปรับสำหรับบิลที่ {rentalId} หรือไม่?\n(ลูกค้าจะต้องส่งสลิปใหม่)",
                "ปฏิเสธค่าปรับ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (rentalRepo.RejectFinePayment(rentalId))
                {
                    MessageBox.Show("ปฏิเสธสลิปค่าปรับเรียบร้อยแล้ว", "สำเร็จ");

                    if (picSlipPreview.Image != null)
                    {
                        picSlipPreview.Image.Dispose();
                        picSlipPreview.Image = null;
                    }

                    LoadRentals();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถปฏิเสธได้", "ข้อผิดพลาด");
                }
            }
        }
    }
}