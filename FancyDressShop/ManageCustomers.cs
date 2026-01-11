using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class ManageCustomers : Form
    {
        private int currentCustomerId = 0;
        private CustomerRepository customerRepository;

        public ManageCustomers()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();

            SetupStatusComboBox();      
            SetupFilterStatusComboBox(); 

            LoadCustomersAndApplyFilters(); 
            SetupFilterStatusComboBox();
            LoadBankOptions();

            txtStatusCus.SelectedIndexChanged += TxtStatusCus_SelectedIndexChanged;
            cmbFilterStatusCus.SelectedIndexChanged += FilterChanged_Handler;
            LoadCustomersAndApplyFilters(); 
        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomersAndApplyFilters();
        }
        public class StatusItem
        {
            public string EnglishValue { get; set; }
            public string ThaiDisplay { get; set; }
        }

        private void SetupStatusComboBox()
        {
            List<StatusItem> customerStatusList = new List<StatusItem>
            {
                 new StatusItem { EnglishValue = "Active", ThaiDisplay = "ใช้งานปกติ" },
                new StatusItem { EnglishValue = "Suspended", ThaiDisplay = "ระงับการใช้งานชั่วคราว" },
                new StatusItem { EnglishValue = "Banned", ThaiDisplay = "ถูกระงับ (แบน)" }
            };

            txtStatusCus.DataSource = customerStatusList;
            txtStatusCus.DisplayMember = "ThaiDisplay";
            txtStatusCus.ValueMember = "EnglishValue";  

            txtStatusCus.SelectedValue = "Active";
        }

        private void SetupFilterStatusComboBox()
        {
            List<StatusItem> filterStatusList = new List<StatusItem>
    {
                new StatusItem { EnglishValue = "All", ThaiDisplay = "--สถานะ--" }, 
        
                new StatusItem { EnglishValue = "Active", ThaiDisplay = "ใช้งานปกติ" },
                new StatusItem { EnglishValue = "Suspended", ThaiDisplay = "ระงับการใช้งานชั่วคราว" },
                new StatusItem { EnglishValue = "Banned", ThaiDisplay = "ถูกระงับ (แบน)" }
            };

            cmbFilterStatusCus.DataSource = filterStatusList;
            cmbFilterStatusCus.DisplayMember = "ThaiDisplay";
            cmbFilterStatusCus.ValueMember = "EnglishValue"; 

            cmbFilterStatusCus.SelectedValue = "All";
        }

        private string GetThaiStatus(string englishStatus)
        {
            List<StatusItem> statusList = (List<StatusItem>)txtStatusCus.DataSource;

            StatusItem match = statusList.FirstOrDefault(s =>
                s.EnglishValue.Equals(englishStatus, StringComparison.OrdinalIgnoreCase));

            return match != null ? match.ThaiDisplay : englishStatus;
        }

        private void ClearForm()
        {
            txtCustomerId.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;

            dtpBirthDate.Value = DateTime.Now;

            txtStatusCus.SelectedValue = "Active";

            TxtStatusCus_SelectedIndexChanged(txtStatusCus, EventArgs.Empty);
            txtBanReason.Text = string.Empty;
            dtpBanUntil.Value = DateTime.Now;

            picProfile.Image = null;
            txtProfileImagePath.Text = string.Empty;

            if (cmbBankName.Items.Count > 0) cmbBankName.SelectedIndex = 0;
            txtAccountNumber.Text = string.Empty;
            txtAccountName.Text = string.Empty;

            currentCustomerId = 0;

            btnAddCus.Enabled = true;
            btnEditCus.Enabled = false;
            btnDeleteCus.Enabled = false;
        }

        private void LoadCustomersAndApplyFilters(string statusFilter = "All", string searchTerm = "")
        {
            List<Customer> customers = customerRepository.GetAllCustomers();

            if (statusFilter != "All")
            {
                customers = customers.Where(c =>
                    c.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                customers = customerRepository.SearchCustomers(searchTerm);

                string lowerSearchTerm = searchTerm.ToLower();
                customers = customers.Where(c =>
                    (c.FullName != null && c.FullName.ToLower().Contains(lowerSearchTerm)) ||
                    (c.Email != null && c.Email.ToLower().Contains(lowerSearchTerm)) ||
                    (c.PhoneNumber != null && c.PhoneNumber.ToLower().Contains(lowerSearchTerm)) ||
                    (c.Username != null && c.Username.ToLower().Contains(lowerSearchTerm)) ||
                    c.CustomerId.ToString().Contains(lowerSearchTerm)
                ).ToList();

            }

            foreach (var customer in customers)
            {
                customer.ThaiStatus = GetThaiStatus(customer.Status);
            }

            dgvCustomers.DataSource = customers;

            if (dgvCustomers.Columns.Count > 0)
            {
                dgvCustomers.Columns["CustomerId"].HeaderText = "ID ลูกค้า";
                dgvCustomers.Columns["Username"].HeaderText = "ชื่อผู้ใช้";
                dgvCustomers.Columns["FullName"].HeaderText = "ชื่อ-นามสกุล";
                dgvCustomers.Columns["PhoneNumber"].HeaderText = "เบอร์โทร";
                dgvCustomers.Columns["Email"].HeaderText = "อีเมล";
                dgvCustomers.Columns["ThaiStatus"].HeaderText = "สถานะบัญชี";
                dgvCustomers.Columns["BanReason"].HeaderText = "เหตุผลระงับ";
                dgvCustomers.Columns["BanUntil"].HeaderText = "ปลดแบนเมื่อ";

                dgvCustomers.Columns["Status"].Visible = false;    
                dgvCustomers.Columns["Password"].Visible = false;
                dgvCustomers.Columns["ProfileImage"].Visible = false;
                dgvCustomers.Columns["CreatedAt"].Visible = false;
                dgvCustomers.Columns["Address"].Visible = false;     
                dgvCustomers.Columns["BirthDate"].Visible = false;
                dgvCustomers.Columns["Role"].Visible = false;     
                dgvCustomers.Columns["BankName"].Visible = false; 
                dgvCustomers.Columns["AccountNumber"].Visible = false;
                dgvCustomers.Columns["AccountName"].Visible = false;

                dgvCustomers.Columns["CustomerId"].DisplayIndex = 0;
                dgvCustomers.Columns["Username"].DisplayIndex = 1;
                dgvCustomers.Columns["FullName"].DisplayIndex = 2;

                dgvCustomers.Columns["Email"].DisplayIndex = 3;
                dgvCustomers.Columns["PhoneNumber"].DisplayIndex = 4;

                dgvCustomers.Columns["ThaiStatus"].DisplayIndex = 5;
                dgvCustomers.Columns["BanReason"].DisplayIndex = 6;
                dgvCustomers.Columns["BanUntil"].DisplayIndex = 7;

                dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCustomers.CurrentRow == null) return;
            DataGridViewRow row = dgvCustomers.CurrentRow;

            txtCustomerId.Text = GetStringValue(row.Cells["CustomerId"].Value);
            txtUsername.Text = GetStringValue(row.Cells["Username"].Value);
            txtFullName.Text = GetStringValue(row.Cells["FullName"].Value);
            txtPhoneNumber.Text = GetStringValue(row.Cells["PhoneNumber"].Value);
            txtEmail.Text = GetStringValue(row.Cells["Email"].Value);
            txtAddress.Text = GetStringValue(row.Cells["Address"].Value);

            cmbBankName.Text = GetStringValue(row.Cells["BankName"].Value);
            txtAccountNumber.Text = GetStringValue(row.Cells["AccountNumber"].Value);
            txtAccountName.Text = GetStringValue(row.Cells["AccountName"].Value);

            string englishStatus = GetStringValue(row.Cells["Status"].Value);
            txtStatusCus.SelectedValue = englishStatus;

            TxtStatusCus_SelectedIndexChanged(txtStatusCus, EventArgs.Empty);

            object birthDateValue = row.Cells["BirthDate"].Value;
            if (birthDateValue != null && birthDateValue != DBNull.Value)
            {
                dtpBirthDate.Value = (DateTime)birthDateValue;
            }
            else
            {
                dtpBirthDate.Value = DateTime.Now;
            }

            string imagePathInDB = GetStringValue(row.Cells["ProfileImage"].Value);
            txtProfileImagePath.Text = imagePathInDB;

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathInDB);

            if (!string.IsNullOrEmpty(imagePathInDB) && File.Exists(fullPath))
            {
                try
                {
                    using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        if (picProfile.Image != null) picProfile.Image.Dispose();
                        picProfile.Image = Image.FromStream(stream);
                    }
                }
                catch (Exception)
                {
                    picProfile.Image = null;
                }
            }
            else
            {
                picProfile.Image = null;
            }

            txtBanReason.Text = GetStringValue(row.Cells["BanReason"].Value);

            object banUntilValue = row.Cells["BanUntil"].Value;
            if (banUntilValue != null && banUntilValue != DBNull.Value)
            {
                dtpBanUntil.Value = (DateTime)banUntilValue;
                dtpBanUntil.Checked = true;
            }
            else
            {
                dtpBanUntil.Checked = false; 
                dtpBanUntil.Value = DateTime.Now;

                txtPassword.Text = string.Empty;
            }

            btnEditCus.Enabled = true; 
            btnDeleteCus.Enabled = true;
            btnAddCus.Enabled = false;
        }

        private string GetStringValue(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return string.Empty;
            }
            return value.ToString();
                }

        private void btnClearCus_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("กรุณากรอก ชื่อผู้ใช้ รหัสผ่าน และชื่อ-นามสกุล ให้ครบถ้วน", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string statusToSave = txtStatusCus.SelectedValue.ToString();

            Customer newCustomer = new Customer
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FullName = txtFullName.Text,
                Status = statusToSave,

                Email = GetStringValue(txtEmail.Text),
                PhoneNumber = GetStringValue(txtPhoneNumber.Text),
                Address = GetStringValue(txtAddress.Text),
                ProfileImage = GetStringValue(txtProfileImagePath.Text),

                BankName = cmbBankName.Text,
                AccountNumber = txtAccountNumber.Text.Trim(),
                AccountName = txtAccountName.Text.Trim(),

                BirthDate = dtpBirthDate.Value,

                BanReason = GetStringValue(txtBanReason.Text),
                BanUntil = dtpBanUntil.Checked
                    ? dtpBanUntil.Value
                    : (DateTime?)null,
                
            };

            if (customerRepository.AddCustomer(newCustomer))
            {
                MessageBox.Show("เพิ่มลูกค้าใหม่สำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomersAndApplyFilters();
                ClearForm(); 
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = openFileDialog.FileName;

                string relativeFolderName = "ProfileImages"; 
                string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFolderName);

                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                string fileName = Path.GetFileName(sourceFilePath);
                string destinationFilePath = Path.Combine(imagesFolder, fileName);

                string relativePathToSave = Path.Combine(relativeFolderName, fileName);

                try
                {
                    byte[] imageBytes = File.ReadAllBytes(sourceFilePath);
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                    {
                        if (picProfile.Image != null) picProfile.Image.Dispose();
                        picProfile.Image = Image.FromStream(ms);
                    }

                    File.Copy(sourceFilePath, destinationFilePath, true);

                    txtProfileImagePath.Text = relativePathToSave;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ข้อผิดพลาดในการโหลดหรือคัดลอกรูปภาพ: " + ex.Message, "ข้อผิดพลาด");
                }
            }
        }

        private void btnDeleteCus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลลูกค้าที่ต้องการลบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"คุณแน่ใจหรือไม่ว่าต้องการลบข้อมูลลูกค้า ID: {txtCustomerId.Text}?",
                "ยืนยันการลบ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                int customerId = Convert.ToInt32(txtCustomerId.Text);

                if (customerRepository.DeleteCustomer(customerId))
                {
                    MessageBox.Show("ลบข้อมูลลูกค้าสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomersAndApplyFilters();
                    ClearForm();   
                }
                else
                {
                }
            }
        }

        private void btnEditCus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลลูกค้าที่ต้องการแก้ไข", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้และชื่อ-นามสกุล", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer customerToUpdate = new Customer
            {
                CustomerId = Convert.ToInt32(txtCustomerId.Text),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),

                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                BanUntil = dtpBanUntil.Checked
                    ? dtpBanUntil.Value
                    : (DateTime?)null,
                ProfileImage = txtProfileImagePath.Text.Trim(),
                Status = txtStatusCus.SelectedValue.ToString(),
                BanReason = txtBanReason.Text.Trim(),

                BankName = cmbBankName.Text,
                AccountNumber = txtAccountNumber.Text.Trim(),
                AccountName = txtAccountName.Text.Trim(),
            };

            if (customerRepository.UpdateCustomer(customerToUpdate))
            {
                MessageBox.Show("แก้ไขข้อมูลลูกค้าสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomersAndApplyFilters();
            }
        }

        private void FilterChanged_Handler(object sender, EventArgs e)
        {
            string selectedStatus = "All";
            if (cmbFilterStatusCus.SelectedValue != null && cmbFilterStatusCus.SelectedValue.ToString() != "--สถานะ--")
            {
                selectedStatus = cmbFilterStatusCus.SelectedValue.ToString();
            }

            LoadCustomersAndApplyFilters(selectedStatus, txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedStatus = "All";
            if (cmbFilterStatusCus.SelectedValue != null && cmbFilterStatusCus.SelectedValue.ToString() != "--สถานะ--")
            {
                selectedStatus = cmbFilterStatusCus.SelectedValue.ToString();
            }

            LoadCustomersAndApplyFilters(selectedStatus, txtSearch.Text.Trim());
        }

        private void TxtStatusCus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtStatusCus.SelectedValue == null) return;

            string selectedStatus = txtStatusCus.SelectedValue.ToString();

            bool isStatusBannedOrSuspended = (selectedStatus == "Banned" || selectedStatus == "Suspended");

            txtBanReason.Enabled = isStatusBannedOrSuspended;
            dtpBanUntil.Enabled = isStatusBannedOrSuspended;

            if (!isStatusBannedOrSuspended)
            {
                txtBanReason.Text = string.Empty;
                dtpBanUntil.Checked = false;
                dtpBanUntil.Value = DateTime.Now; 
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
                "ธนาคารออมสิน (GSB)",
                "อื่นๆ"
                    };

            cmbBankName.Items.AddRange(bankNames);

            if (cmbBankName.Items.Count > 0)
            {
                cmbBankName.SelectedIndex = 0;
            }
        }
    }
}
