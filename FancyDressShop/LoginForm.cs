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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้และรหัสผ่าน", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CustomerRepository repository = new CustomerRepository();
            Customer customer = repository.LoginCustomer(username, password);

            if (customer != null)
            {
                // 1. (Optional) โค้ดกำหนด userRole เดิม (ถ้ายังจำเป็น)
                string userRole = customer.Role;
                if (string.IsNullOrEmpty(userRole))
                {
                    if (username.ToLower() == "admin")
                    {
                        userRole = "Admin";
                    }
                    else
                    {
                        userRole = "Customer";
                    }
                }

                // 2. ตรวจสอบสถานะ BANNED (ห้ามเข้าเด็ดขาด)
                if (customer.Status.Equals("Banned", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"บัญชีของคุณถูกแบนถาวร\nเหตุผล: {customer.BanReason}\nโปรดติดต่อผู้ดูแลระบบ",
                            "บัญชีถูกระงับ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                    return;
                }

                // 3. ตรวจสอบสถานะ SUSPENDED (เตือน แต่ยังอนุญาตให้เข้า)
                if (customer.Status.Equals("Suspended", StringComparison.OrdinalIgnoreCase))
                {
                    string banUntilMsg = customer.BanUntil.HasValue
                                 ? $"จนถึงวันที่ {customer.BanUntil.Value.ToShortDateString()}"
                                 : "โดยไม่มีกำหนด";

                    MessageBox.Show($"บัญชีของคุณถูกระงับชั่วคราว {banUntilMsg}\nเหตุผล: {customer.BanReason}\nคุณยังเข้าสู่ระบบได้แต่ไม่สามารถทำรายการเช่าได้",
                                    "บัญชีถูกระงับ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }

                MessageBox.Show($"ยินดีต้อนรับคุณ {customer.FullName}!", "ล็อกอินสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                MainForm mainForm = new MainForm(customer);
                mainForm.Show();
            }
            else // 5. กรณีล็อกอินล้มเหลว
            {
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "ล็อกอินล้มเหลว", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. สร้างหน้าสมัครสมาชิกขึ้นมา
            Register registerForm = new Register();

            // 2. แสดงหน้าสมัครสมาชิก
            registerForm.Show();

            // 3. ซ่อนหน้า Login ปัจจุบัน
            this.Hide();
        }

        private void LinkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

