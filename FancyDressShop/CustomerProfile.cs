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
    public partial class CustomerProfile : UserControl
    {
        private MainForm parentForm;
        private CustomerRepository customerRepository;
        private Customer currentCustomer;
        private string newProfileImagePath = string.Empty;

        public CustomerProfile(MainForm mainForm)
        {
            InitializeComponent();
            this.parentForm = mainForm;
            this.customerRepository = new CustomerRepository();
            this.currentCustomer = parentForm.loggedInCustomer;
            LoadBankOptions();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            if (parentForm.loggedInCustomer == null)
            {
                MessageBox.Show("ไม่พบข้อมูลผู้ใช้งาน กรุณาลองเข้าสู่ระบบใหม่", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.currentCustomer != null)
            {
                txtUsername.Text = currentCustomer.Username;
                txtCreatedAt.Text = currentCustomer.CreatedAt.ToShortDateString();
                txtFullname.Text = currentCustomer.FullName;
                txtEmail.Text = currentCustomer.Email;
                txtPhoneNumber.Text = currentCustomer.PhoneNumber;
                txtAddress.Text = currentCustomer.Address;

                cmbBankName.Text = currentCustomer.BankName;
                txtAccountNumber.Text = currentCustomer.AccountNumber;
                txtAccountName.Text = currentCustomer.AccountName;

                if (!string.IsNullOrEmpty(currentCustomer.ProfileImage))
                {
                    string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentCustomer.ProfileImage);
                    if (System.IO.File.Exists(imagePath))
                    {
                        using (var stream = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            picProfileImage.Image = Image.FromStream(stream);
                        }
                        picProfileImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        picProfileImage.Image = null;
                        picProfileImage.Text = "ไม่พบรูปภาพ";
                    }
                }
                else
                {
                    picProfileImage.Image = null;
                    picProfileImage.Text = "ไม่มีรูปโปรไฟล์";
                }

                if (currentCustomer.BirthDate.HasValue)
                {
                    dtpBirthDate.Value = currentCustomer.BirthDate.Value;
                    dtpBirthDate.Checked = true;
                }
                else
                {
                    
                    dtpBirthDate.Value = DateTime.Now.Date;
                    dtpBirthDate.Checked = false;
                }
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                openFileDialog.Title = "เลือกรูปภาพโปรไฟล์ใหม่";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFilePath = openFileDialog.FileName;

                        byte[] imageBytes = System.IO.File.ReadAllBytes(selectedFilePath);

                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                        {
                            Image tempImage = Image.FromStream(ms);

                            picProfileImage.Image = new Bitmap(tempImage);
                            tempImage.Dispose();
                        }

                        picProfileImage.SizeMode = PictureBoxSizeMode.Zoom;

                        this.newProfileImagePath = selectedFilePath;

                        MessageBox.Show("เลือกรูปภาพใหม่เรียบร้อยแล้ว กรุณากด 'บันทึกข้อมูล' เพื่อยืนยันการเปลี่ยนแปลง", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        this.newProfileImagePath = string.Empty;
                        MessageBox.Show("เกิดข้อผิดพลาดในการโหลดไฟล์รูปภาพ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string fullName = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();
            string accountNumber = txtAccountNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("กรุณากรอกชื่อ-นามสกุล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword))
            {
                if (newPassword != confirmPassword || newPassword.Length < 6)
                {
                    MessageBox.Show("รหัสผ่านใหม่ต้องตรงกันและยาวอย่างน้อย 6 ตัวอักษร", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                    return;
                }
                currentCustomer.Password = newPassword;
            }
            else
            {
                currentCustomer.Password = string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(email) && (!email.Contains("@") || !email.Contains(".")))
            {
                MessageBox.Show("รูปแบบอีเมลไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(phone) && (phone.Length != 10 || !phone.All(char.IsDigit)))
            {
                MessageBox.Show("เบอร์โทรศัพท์ต้องเป็นตัวเลข 10 หลักเท่านั้น", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(accountNumber) && !accountNumber.All(char.IsDigit))
            {
                MessageBox.Show("เลขที่บัญชีต้องเป็นตัวเลขเท่านั้น", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                if (!string.IsNullOrEmpty(newProfileImagePath))
                {
                    string relativeFolder = "ProfileImages";
                    string targetFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFolder);

                    if (!Directory.Exists(targetFolder))
                    {
                        Directory.CreateDirectory(targetFolder);
                    }

                    string fileExtension = Path.GetExtension(newProfileImagePath);
                    string newFileName = $"{currentCustomer.CustomerId}_{DateTime.Now.Ticks}{fileExtension}";

                    string targetPath = Path.Combine(targetFolder, newFileName);

                    if (!string.IsNullOrEmpty(currentCustomer.ProfileImage))
                    {
                        string oldFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentCustomer.ProfileImage);
                        if (File.Exists(oldFullPath))
                        {
                            try
                            {
                                
                                if (picProfileImage.Image != null) picProfileImage.Image.Dispose();
                                File.Delete(oldFullPath);
                            }
                            catch {}
                        }
                    }

                    File.Copy(newProfileImagePath, targetPath, true);

                    currentCustomer.ProfileImage = Path.Combine(relativeFolder, newFileName);

                    newProfileImagePath = string.Empty;
                }

                currentCustomer.FullName = fullName;
                currentCustomer.Email = email;
                currentCustomer.PhoneNumber = phone;
                currentCustomer.Address = txtAddress.Text.Trim();
                currentCustomer.BirthDate = dtpBirthDate.Checked ? dtpBirthDate.Value : (DateTime?)null;

                currentCustomer.BankName = cmbBankName.Text;
                currentCustomer.AccountNumber = accountNumber;
                currentCustomer.AccountName = txtAccountName.Text.Trim();

                bool success = customerRepository.UpdateCustomer(currentCustomer);

                if (success)
                {
                    parentForm.UpdateLoggedInCustomer(currentCustomer);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBankOptions()
        {
            cmbBankName.Items.Clear();

            string[] bankNames = new string[]
            {
                "ธนาคารกรุงเทพ (BBL)",
                "ธนาคารกสิกรไทย (KBANK)",
                "ธนาคารกรุงไทย (KTB)",
                "ธนาคารไทยพาณิชย์ (SCB)",
                "ธนาคารกรุงศรีอยุธยา (BAY)",
                "ธนาคารออมสิน (GSB)"
            };

            cmbBankName.Items.AddRange(bankNames);

            if (cmbBankName.Items.Count > 0)
            {
                cmbBankName.SelectedIndex = 0;
            }
        }
    }
}
