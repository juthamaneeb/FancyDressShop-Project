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
    public partial class PaymentConfirmation : UserControl
    {
        private MainForm parentForm;
        private int currentRentalId;
        private Rental currentRental;
        private RentalRepository rentalRepository;
        private string selectedSlipPath = string.Empty;

        public PaymentConfirmation(MainForm mainForm, int rentalId)
        {
            InitializeComponent();
            this.parentForm = mainForm;
            this.currentRentalId = rentalId;
            this.rentalRepository = new RentalRepository();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            SetupPaymentDetails();
        }

        private void SetupPaymentDetails()
        {
            currentRental = rentalRepository.GetRentalById(currentRentalId);
            if (currentRental == null)
            {
                MessageBox.Show("ไม่พบรายการบิลที่ต้องการชำระเงิน กรุณาตรวจสอบอีกครั้ง", "ข้อผิดพลาด");
                parentForm.LoadUserControl(new CustomerCatalog(parentForm));
                return;
            }
            lblRentalId.Text = currentRentalId.ToString();
            decimal grandTotal = currentRental.TotalPrice + currentRental.DepositAmount;
            lblGrandTotal.Text = grandTotal.ToString("N2") + " บาท";
            DateTime? creationTime = currentRental.CreationTime;
            if (!creationTime.HasValue)
            {
                MessageBox.Show("ไม่พบเวลาสร้างบิลที่ถูกต้อง", "ข้อผิดพลาด");
                parentForm.LoadUserControl(new CustomerCatalog(parentForm));
                return;
            }
            DateTime dueDate = creationTime.Value.AddHours(24);
            lblDueDateTime.Text = dueDate.ToString("dd/MM/yyyy HH:mm:ss");
            btnSubmitPayment.Enabled = false;
        }

        private void btnBrowseSlip_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                openFileDialog.Title = "เลือกไฟล์สลิปการชำระเงิน";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.selectedSlipPath = openFileDialog.FileName;

                        if (picSlipPath != null)
                        {
                            byte[] imageBytes = File.ReadAllBytes(this.selectedSlipPath);

                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                Image tempImage = Image.FromStream(ms);

                                picSlipPath.Image = new Bitmap(tempImage);

                                tempImage.Dispose();
                            }

                            picSlipPath.SizeMode = PictureBoxSizeMode.Zoom;
                        }

                        btnSubmitPayment.Enabled = true;
                        MessageBox.Show("เลือกไฟล์สลิปเรียบร้อย", "สำเร็จ");
                    }
                    catch (Exception ex)
                    {
                        this.selectedSlipPath = string.Empty;
                        MessageBox.Show("เกิดข้อผิดพลาดในการโหลดไฟล์รูปภาพ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnSubmitPayment.Enabled = false;
                    }
                }
            }
        }

        private void btnSubmitPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.selectedSlipPath) || !File.Exists(this.selectedSlipPath))
            {
                MessageBox.Show("กรุณาเลือกไฟล์สลิปก่อนดำเนินการต่อ", "แจ้งเตือน");
                return;
            }

            currentRental = rentalRepository.GetRentalById(currentRentalId);
            if (currentRental == null || currentRental.Status != "Pending Payment")
            {
                MessageBox.Show($"บิลที่ {currentRentalId} ไม่อยู่ในสถานะที่สามารถชำระเงินได้", "แจ้งเตือน");
                parentForm.LoadUserControl(new CustomerCatalog(parentForm));
                return;
            }

            string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PaymentSlips");
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string fileName = $"RENTAL_{currentRentalId}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(selectedSlipPath)}";
            string targetPath = Path.Combine(targetDirectory, fileName);
            string relativePath = Path.Combine("PaymentSlips", fileName);

            try
            {
                File.Copy(this.selectedSlipPath, targetPath, true);

                if (rentalRepository.SubmitPaymentSlip(currentRentalId, relativePath))
                {
                    MessageBox.Show($"ส่งหลักฐานการชำระเงินสำเร็จ!", "สำเร็จ");

                    try
                    {
                        Rental updatedRental = rentalRepository.GetRentalById(currentRentalId);
                        if (updatedRental != null)
                        {
                            ReceiptGenerator generator = new ReceiptGenerator();
                            System.Drawing.Image receiptImage = generator.GenerateReceiptImage(updatedRental);

                            if (receiptImage != null)
                            {
                                using (ReceiptPreviewForm previewForm = new ReceiptPreviewForm(receiptImage, updatedRental))
                                {
                                    previewForm.ShowDialog(this);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"เกิดข้อผิดพลาดในการสร้างตัวอย่างใบเสร็จ: {ex.Message}", "ข้อผิดพลาด");
                    }

                    parentForm.LoadUserControl(new CustomerCatalog(parentForm));
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูลการชำระเงิน กรุณาลองใหม่", "ผิดพลาด");
                    try { File.Delete(targetPath); } catch { /* ignore */ }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถบันทึกไฟล์สลิปได้: {ex.Message}", "System Error");
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "คุณต้องการยกเลิกกระบวนการส่งสลิปและกลับไปยังหน้าหลักหรือไม่? บิลของคุณจะยังคงอยู่และรอการชำระเงิน",
                "ยืนยันการกลับหน้าหลัก",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                parentForm.LoadUserControl(new CustomerCatalog(parentForm));
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentRental != null)
            {
                DateTime creationTime = currentRental.CreationTime;
                DateTime dueDate = creationTime.AddHours(24);

                TimeSpan remainingTime = dueDate - DateTime.Now;

                if (remainingTime.TotalSeconds > 0)
                {
                    lblDueDateTime.Text = $"เหลือเวลาชำระเงิน: {remainingTime.Hours:D2} ชม. {remainingTime.Minutes:D2} น. {remainingTime.Seconds:D2} วิ.";
                }
                else
                {
                    ((Timer)sender).Stop();
                    lblDueDateTime.Text = "🚨 บิลนี้หมดอายุแล้ว";
                    btnSubmitPayment.Enabled = false;
                }
            }
        }

    }
}
