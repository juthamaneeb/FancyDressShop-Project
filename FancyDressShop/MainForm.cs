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
    public partial class MainForm : Form
    {
        private Form activeForm = null;
        public Customer loggedInCustomer { get; private set; }
        public string CurrentView { get; set; }
        private bool isLoggingOut = false;
        public MainForm(Customer user)
        {
            InitializeComponent();
            loggedInCustomer = user;
            SetupMenu(user.Role);
            CartManager.Instance.CartUpdated += UpdateCartBadge;
            UpdateCartBadge(null, EventArgs.Empty);
        }

        public void SetupMenu(string userRole)
        {
            bool isAdmin = userRole.ToLower() == "admin";

            if (isAdmin)
            {
                panelAdminMenu.BringToFront();
                panelCustomerMenu.SendToBack();
            }
            else
            {
                panelCustomerMenu.BringToFront();
                panelAdminMenu.SendToBack();

                ActivateButton(btnCatalog);
                LoadUserControl(new CustomerCatalog(this));
            }

            panelAdminMenu.Visible = isAdmin;
            panelCustomerMenu.Visible = !isAdmin;
        }

        private void LoadFormToPanel(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            childForm.TopLevel = false;   
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; 

            panelmain.Controls.Add(childForm);
            panelmain.Tag = childForm; 
            childForm.BringToFront();
            childForm.Show();
        }

        public void LoadUserControl(UserControl uc)
        {
            panelmain.Controls.Clear(); 
            uc.Dock = DockStyle.Fill;
            panelmain.Controls.Add(uc); 
        }

        private void btnManageDresses_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new ManageDresses());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLoggingOut)
            {
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "คุณต้องการปิดโปรแกรมและออกจากระบบหรือไม่?",
                    "ยืนยันการปิด",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                Application.Exit();
            }
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadFormToPanel(new ManageCustomers());
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new CustomerCatalog(this));
        }

        private void btnRentReturn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new AdminRentalManager(this));
        }

        public void UpdateLoggedInCustomer(Customer updatedCustomer)
        {
            if (updatedCustomer != null)
            {
                this.loggedInCustomer = updatedCustomer;
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new CustomerProfile(this));
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (loggedInCustomer == null)
            {
                MessageBox.Show("ข้อผิดพลาด: ไม่พบข้อมูลลูกค้าที่ล็อกอินอยู่", "Error");
                return;
            }

            CustomerCart customerCartControl = new CustomerCart(this.loggedInCustomer);

            LoadUserControl(customerCartControl);
        }

        private void btnCartMenu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (loggedInCustomer == null)
            {
                MessageBox.Show("ข้อผิดพลาด: ไม่พบข้อมูลลูกค้าที่ล็อกอินอยู่", "Error");
                return;
            }

            CartDisplay customerCartControl = new CartDisplay(this, this.loggedInCustomer);

            LoadUserControl(customerCartControl);
        }

        private void UpdateCartBadge(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(UpdateCartBadge), new object[] { sender, e });
                return;
            }
        }

        public void ShowCartDisplay()
        {
            if (loggedInCustomer == null)
            {
                MessageBox.Show("ข้อผิดพลาด: ไม่พบข้อมูลลูกค้าที่ล็อกอินอยู่", "Error");
                return;
            }

            CartDisplay cartScreen = new CartDisplay(this, this.loggedInCustomer);

            LoadUserControl(cartScreen);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            CartManager.Instance.CartUpdated -= UpdateCartBadge;
            base.OnFormClosed(e);
        }

        private void btnExitCus_Click(object sender, EventArgs e)
        {
            Logout();
        }

        public void Logout()
        {
            DialogResult confirmResult = MessageBox.Show(
                "คุณต้องการออกจากระบบและกลับไปยังหน้าล็อกอินใช่หรือไม่?",
                "ยืนยันการออกจากระบบ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                CartManager.Instance.ClearCart();
                loggedInCustomer = null;
                isLoggingOut = true;

                LoginForm loginForm = new LoginForm();

                this.Hide();
                this.Close();

                loginForm.Show();
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new AdminDashboard());
        }

        private void btnAboutus_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new AboutUs());
        }

        private RoundedButton currentButton;

        private Color colorDefault = Color.FromArgb(168, 218, 220);
        private Color colorActive = Color.FromArgb(247, 211, 110);

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                RoundedButton clickedButton = btnSender as RoundedButton;

                if (clickedButton == null || currentButton == clickedButton)
                {
                    return;
                }

                DisableButton();
                currentButton = clickedButton;
                currentButton.IsSelected = true;
                currentButton.BackColor = colorActive;
            }
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.IsSelected = false;
                currentButton.BackColor = colorDefault;
                currentButton = null;
            }
        }

        private void btnUs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            LoadUserControl(new AboutUs());
        }
    }
}
