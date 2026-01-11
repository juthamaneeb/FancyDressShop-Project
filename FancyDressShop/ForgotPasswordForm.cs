using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FancyDressShop
{
    public partial class ForgotPasswordForm : Form
    {
        private CustomerRepository customerRepository = new CustomerRepository();
        public ForgotPasswordForm()
        {
            InitializeComponent();
            pnlReset.Visible = false;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string contact = txtEmailOrPhone.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(contact))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้และอีเมล/เบอร์โทรศัพท์", "ข้อมูลไม่ครบถ้วน");
                return;
            }

            int customerId = customerRepository.VerifyCustomerForReset(username, contact);

            if (customerId > 0)
            {
                txtUsername.Enabled = false; 
                txtEmailOrPhone.Enabled = false;
                btnVerify.Enabled = false;
                pnlReset.Visible = true;
                this.Tag = customerId;
                MessageBox.Show("ยืนยันตัวตนสำเร็จ! กรุณาตั้งรหัสผ่านใหม่", "สำเร็จ");
            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้หรือข้อมูลยืนยันไม่ถูกต้อง", "ข้อผิดพลาด");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword.Length < 6)
            {
                MessageBox.Show("รหัสผ่านต้องมีความยาวอย่างน้อย 6 ตัวอักษร", "ข้อผิดพลาด");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("รหัสผ่านใหม่และการยืนยันไม่ตรงกัน", "ข้อผิดพลาด");
                return;
            }

            if (this.Tag == null) return; 

            int customerId = (int)this.Tag;

            if (customerRepository.UpdatePassword(customerId, newPassword))
            {
                MessageBox.Show("รีเซ็ตรหัสผ่านสำเร็จ! กรุณาใช้รหัสผ่านใหม่ในการล็อกอิน", "สำเร็จ");
                this.Close();
            }
            else
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกรหัสผ่าน", "ข้อผิดพลาด");
            }
        }

        private void btnBacktologin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
