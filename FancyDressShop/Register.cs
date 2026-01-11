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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            LoadBankOptions();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ProfilePicture.ImageLocation = openFileDialog1.FileName;

                ProfilePicture.Tag = openFileDialog1.FileName;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้, รหัสผ่าน และชื่อ-นามสกุล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string accountNumber = txtAccountNumber.Text.Trim();

            if (username.Length < 5 || username.Length > 20) { MessageBox.Show("ชื่อผู้ใช้ต้องมีความยาวระหว่าง 5 ถึง 20 ตัวอักษร", "ข้อผิดพลาด"); return; }
            if (password.Length < 6) { MessageBox.Show("รหัสผ่านต้องมีความยาวอย่างน้อย 6 ตัวอักษร", "ข้อผิดพลาด"); return; }
            if (!string.IsNullOrWhiteSpace(email) && (!email.Contains("@") || !email.Contains("."))) { MessageBox.Show("รูปแบบอีเมลไม่ถูกต้อง", "ข้อผิดพลาด"); return; }
            if (!string.IsNullOrWhiteSpace(phone) && (phone.Length != 10 || !phone.All(char.IsDigit))) { MessageBox.Show("เบอร์โทรศัพท์ต้องเป็นตัวเลข 10 หลักเท่านั้น", "ข้อผิดพลาด"); return; }
            if (!string.IsNullOrWhiteSpace(accountNumber) && !accountNumber.All(char.IsDigit)) { MessageBox.Show("เลขที่บัญชีต้องเป็นตัวเลขเท่านั้น", "ข้อผิดพลาด"); return; }


            Customer tempCustomerToCheck = new Customer { Username = username, Email = email, PhoneNumber = phone, AccountNumber = accountNumber };
            CustomerRepository repository = new CustomerRepository();

            if (repository.IsUsernameExists(username))
            {
                MessageBox.Show("ชื่อผู้ใช้ (Username) นี้ถูกใช้ไปแล้ว", "ข้อมูลซ้ำซ้อน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string duplicateField = repository.IsDuplicate(tempCustomerToCheck, isNewRegistration: true);
            if (!string.IsNullOrEmpty(duplicateField) && duplicateField != "Error")
            {
                MessageBox.Show($"ไม่สามารถลงทะเบียนได้: {duplicateField} ถูกใช้ไปแล้ว", "ข้อมูลซ้ำซ้อน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string finalProfileImagePath = null; 
            if (ProfilePicture.Tag != null && File.Exists(ProfilePicture.Tag.ToString()))
            {
                try
                {
                    string sourcePath = ProfilePicture.Tag.ToString();

                    string relativeFolder = "ProfileImages";
                    string targetFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFolder);

                    if (!Directory.Exists(targetFolder)) Directory.CreateDirectory(targetFolder);

                    string extension = Path.GetExtension(sourcePath);
                    string newFileName = $"{username}_{DateTime.Now.Ticks}{extension}";
                    string targetPath = Path.Combine(targetFolder, newFileName);

                    File.Copy(sourcePath, targetPath, true);

                    finalProfileImagePath = Path.Combine(relativeFolder, newFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดปัญหาในการบันทึกรูปโปรไฟล์: " + ex.Message);
                }
            }


            Customer newCustomer = new Customer
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Address = txtAddress.Text.Trim(),
                PhoneNumber = phone,
                Email = email,

                ProfileImage = finalProfileImagePath,

                BirthDate = dtpBirthDate.Value,
                Status = "Active",
                BanReason = null,
                BanUntil = null,
                BankName = cmbBankName.Text,
                AccountNumber = accountNumber,
                AccountName = txtAccountName.Text.Trim()
            };

            if (repository.RegisterCustomer(newCustomer))
            {
                MessageBox.Show("สมัครสมาชิกสำเร็จแล้ว!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("ไม่สามารถสมัครสมาชิกได้ โปรดลองอีกครั้ง", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void LoadBankOptions()
        {
            cmbBankName.Items.Clear();
            string[] bankNames = new string[] { "ธนาคารกรุงเทพ (BBL)", "ธนาคารกสิกรไทย (KBANK)", "ธนาคารกรุงไทย (KTB)", "ธนาคารไทยพาณิชย์ (SCB)", "ธนาคารกรุงศรีอยุธยา (BAY)", "ธนาคารออมสิน (GSB)" };
            cmbBankName.Items.AddRange(bankNames);
            if (cmbBankName.Items.Count > 0) cmbBankName.SelectedIndex = 0;
        }
    }
}