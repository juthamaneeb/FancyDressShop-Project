using FancyDressShop;
using FancyDressShop.Models;
using FancyDressShop.Repositories;
using MySql.Data.MySqlClient; 
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FancyDressShop
{
    public partial class ManageDresses : UserControl
    {
        private int currentDressId = 0;
        private int currentInventoryId = 0;
        private string currentSelectedSize = null;
        private FancyDressRepository dressRepository;
        private DressInventoryRepository inventoryRepository;
        public ManageDresses(int dressId = 0)
        {
            InitializeComponent();
            currentDressId = dressId;
            UpdateButtonStates();
            dressRepository = new FancyDressRepository();
            inventoryRepository = new DressInventoryRepository();
            InitializeComboBoxes();
            SetupStatusComboBox();
            SetupFilterStatusComboBox();

            cmbFilterStatus.SelectedIndexChanged += FilterChanged_Handler;
            cmbFilterCategory.SelectedIndexChanged += FilterChanged_Handler;

            ApplyFiltersAndLoad();
        }
        private void UpdateButtonStates()
        {
            btnEdit.Enabled = currentDressId > 0;
            btnDelete.Enabled = currentDressId > 0;
            btnAdd.Enabled = currentDressId == 0;
        }

        private void InitializeComboBoxes()
        {
            List<string> dbCategories = dressRepository.GetAllCategoriesFromDresses();

            txtCategory.Items.Clear();

            if (dbCategories.Count > 0)
            {
                txtCategory.Items.AddRange(dbCategories.ToArray());
            }

            if (!txtCategory.Items.Contains("อื่นๆ"))
            {
                txtCategory.Items.Add("อื่นๆ");
            }
            txtCategory.SelectedIndex = (txtCategory.Items.Count > 0) ? 0 : -1;

            cmbFilterCategory.Items.Clear();

            cmbFilterCategory.Items.Add("--ประเภท--");

            if (dbCategories.Count > 0)
            {
                cmbFilterCategory.Items.AddRange(dbCategories.ToArray());
            }
            cmbFilterCategory.SelectedIndex = 0;
            txtInventorySize.Items.Clear();

            txtInventorySize.Items.Clear();
            txtInventorySize.Items.Add("XS");
            txtInventorySize.Items.Add("S");
            txtInventorySize.Items.Add("M");
            txtInventorySize.Items.Add("L");
            txtInventorySize.Items.Add("XL");
            txtInventorySize.Items.Add("XXL");
            txtInventorySize.Items.Add("FreeSize");
            txtInventorySize.SelectedIndex = 0;

        }

        private void ApplyFiltersAndLoad(string categoryFilter = "--ประเภท--", string statusFilter = "All", string searchTerm = "")
        {
            try
            {
                List<FancyDress> dresses = dressRepository.GetAllDressesForAdmin();

                if (categoryFilter != "--ประเภท--")
                {
                    dresses = dresses.Where(d =>
                        d.Category.Equals(categoryFilter, StringComparison.OrdinalIgnoreCase)
                    ).ToList();
                }

                if (statusFilter != "All")
                {
                    dresses = dresses.Where(d =>
                        d.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase)
                    ).ToList();
                }

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    string lowerSearchTerm = searchTerm.ToLower();
                    dresses = dresses.Where(d =>
                        d.Name.ToLower().Contains(lowerSearchTerm) ||
                        d.DressId.ToString().Contains(lowerSearchTerm)
                    ).ToList();
                }

                dresses = dresses.OrderBy(d => d.DressId).ToList();

                foreach (var dress in dresses)
                {
                    dress.ThaiStatus = ConvertStatusToThai(dress.Status);
                }

                dgvDresses.DataSource = dresses;

                dgvDresses.DataSource = dresses;
                if (dgvDresses.Columns.Contains("DressId"))
                {
                    dgvDresses.Columns["DressId"].Visible = true; 
                    dgvDresses.Columns["DressId"].HeaderText = "ID";
                    dgvDresses.Columns["DressId"].DisplayIndex = 0; 
                    dgvDresses.Columns["DressId"].Width = 50; 
                }

                dgvDresses.Columns["Name"].HeaderText = "ชื่อชุด";
                dgvDresses.Columns["Description"].HeaderText = "รายละเอียด";
                dgvDresses.Columns["Category"].HeaderText = "ประเภท";
                dgvDresses.Columns["RentalPricePerDay"].HeaderText = "ราคาเช่า/วัน";
                dgvDresses.Columns["RentalPricePerDay"].DefaultCellStyle.Format = "N2";
                dgvDresses.Columns["DepositPrice"].HeaderText = "ค่ามัดจำ";
                dgvDresses.Columns["DepositPrice"].DefaultCellStyle.Format = "N2";
                dgvDresses.Columns["ImagePath"].Visible = false;
                dgvDresses.Columns["Description"].Width = 150;
                dgvDresses.Columns["ThaiStatus"].HeaderText = "สถานะชุด";
                if (dgvDresses.Columns.Contains("Status"))
                {
                    dgvDresses.Columns["Status"].Visible = false;
                }
                dgvDresses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูลชุดแฟนซี: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class StatusItem
        {
            public string EnglishValue { get; set; }
            public string ThaiDisplay { get; set; }
        }

        private void SetupStatusComboBox()
        {
            List<StatusItem> statusList = new List<StatusItem>
            {
                new StatusItem { EnglishValue = "Available", ThaiDisplay = "ว่างให้เช่า" },
                new StatusItem { EnglishValue = "Rented", ThaiDisplay = "ถูกเช่า (ไม่ว่าง)" },
                new StatusItem { EnglishValue = "Repair", ThaiDisplay = "ส่งซ่อม" },
                new StatusItem { EnglishValue = "Unavailable", ThaiDisplay = "ยกเลิกใช้งาน" }
            };

            txtStatus.DataSource = null; 
            txtStatus.Items.Clear();    

            txtStatus.DataSource = statusList;
            txtStatus.DisplayMember = "ThaiDisplay";
            txtStatus.ValueMember = "EnglishValue"; 

            txtStatus.SelectedValue = "Available";

            if (txtStatus.Items.Count > 0)
            {
                txtStatus.SelectedIndex = 0;
            }
        }

        private void SetupFilterStatusComboBox()
        {
            List<StatusItem> statusList = new List<StatusItem>
            {
                new StatusItem { EnglishValue = "All", ThaiDisplay = "--สถานะ--" }, 
                new StatusItem { EnglishValue = "Available", ThaiDisplay = "ว่างให้เช่า" },
                new StatusItem { EnglishValue = "Rented", ThaiDisplay = "ถูกเช่า (ไม่ว่าง)" },
                new StatusItem { EnglishValue = "Repair", ThaiDisplay = "ส่งซ่อม" },
                new StatusItem { EnglishValue = "Unavailable", ThaiDisplay = "ยกเลิกใช้งาน" }
            };
            cmbFilterStatus.DataSource = null;
            cmbFilterStatus.Items.Clear();  

            cmbFilterStatus.DataSource = statusList;
            cmbFilterStatus.DisplayMember = "ThaiDisplay";
            cmbFilterStatus.ValueMember = "EnglishValue";
            cmbFilterStatus.SelectedValue = "All";
        }

        private void ClearForm()
        {
            txtDressId.Clear();
            txtNameDress.Clear();
            txtDescription.Clear();
            txtImagePath.Clear();

            txtRentalPrice.Value = 0;
            txtDepositPrice.Value = 0;

            if (DressImage.Image != null)
            {
                DressImage.Image.Dispose();
                DressImage.Image = null;
            }

            if (txtStatus.DataSource != null)
            {
                txtStatus.SelectedValue = "Available";
            }

            if (txtCategory.Items.Count > 0)
            {
                txtCategory.SelectedIndex = 0;
            }

            if (dgvInventory.DataSource != null)
            {
                dgvInventory.DataSource = null; 
                ClearSize();
            }
            dgvInventory.Rows.Clear();

            currentDressId = 0;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            ClearSize();
            UpdateButtonStates();
            txtNameDress.Focus();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameDress.Text) || txtRentalPrice.Value <= 0)
            {
                MessageBox.Show("กรุณากรอกชื่อชุด และราคาเช่าให้ถูกต้อง", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string statusToSave = txtStatus.SelectedValue.ToString();
            FancyDress newDress = new FancyDress
            {
                Name = txtNameDress.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                RentalPricePerDay = txtRentalPrice.Value,
                DepositPrice = txtDepositPrice.Value,
                ImagePath = txtImagePath.Text.Trim(),
                Status = statusToSave,
            };

            try
            {
                int newDressId = dressRepository.AddDress(newDress);

                MessageBox.Show("เพิ่มชุดแฟนซีสำเร็จ!", "สำเร็จ");

                cmbFilterCategory.SelectedIndexChanged -= FilterChanged_Handler;
                cmbFilterStatus.SelectedIndexChanged -= FilterChanged_Handler;

                InitializeComboBoxes();

                cmbFilterCategory.SelectedIndex = 0;
                cmbFilterStatus.SelectedValue = "All";
                txtSearch.Clear();

                cmbFilterCategory.SelectedIndexChanged += FilterChanged_Handler;
                cmbFilterStatus.SelectedIndexChanged += FilterChanged_Handler;

                ApplyFiltersAndLoad();

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มชุดแฟนซี: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = openFileDialog.FileName;
                string relativeFolderName = "DressImages";
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
                        Image tempImage = Image.FromStream(ms);
                        DressImage.Image = new Bitmap(tempImage);
                        tempImage.Dispose();

                        File.Copy(sourceFilePath, destinationFilePath, true);
                        txtImagePath.Text = relativePathToSave;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ข้อผิดพลาดในการโหลดหรือคัดลอกรูปภาพ: " + ex.Message, "ข้อผิดพลาด");
                }
            }
        }

        private void dgvDresses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDresses.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvDresses.Rows[e.RowIndex];

                txtDressId.Text = selectedRow.Cells["DressId"].Value.ToString();
                txtNameDress.Text = selectedRow.Cells["Name"].Value.ToString();
                txtDescription.Text = selectedRow.Cells["Description"].Value.ToString();
                txtCategory.SelectedItem = selectedRow.Cells["Category"].Value.ToString();
                txtRentalPrice.Value = Convert.ToDecimal(selectedRow.Cells["RentalPricePerDay"].Value);
                txtDepositPrice.Value = Convert.ToDecimal(selectedRow.Cells["DepositPrice"].Value);
                txtImagePath.Text = selectedRow.Cells["ImagePath"].Value.ToString();
                object statusValue = selectedRow.Cells["Status"].Value;
                string dressStatusEnglish = statusValue != null && statusValue != DBNull.Value
                                                ? statusValue.ToString()
                                                : "Available"; 
                if (txtStatus.DataSource != null)
                {
                    try
                    {
                        txtStatus.SelectedValue = dressStatusEnglish;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error setting SelectedValue: {ex.Message}");
                        txtStatus.SelectedIndex = -1;

                        foreach (var item in txtStatus.Items)
                        {
                            if (((StatusItem)item).EnglishValue == dressStatusEnglish)
                            {
                                txtStatus.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ComboBox DataSource ไม่ถูกผูกข้อมูล!", "Developer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int selectedDressId = Convert.ToInt32(selectedRow.Cells["DressId"].Value);
                currentDressId = selectedDressId;
                UpdateButtonStates();
                LoadDressInventory(selectedDressId);

                string imagePathInDB = txtImagePath.Text;

                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePathInDB);

                if (!string.IsNullOrEmpty(imagePathInDB) && System.IO.File.Exists(fullPath))
                {
                    try
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            if (DressImage.Image != null) DressImage.Image.Dispose();
                            DressImage.Image = Image.FromStream(stream);
                        }
                        DressImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception)
                    {
                        DressImage.Image = null;
                    }
                }
                else
                {
                    DressImage.Image = null;
                }
                this.Invalidate(true);
            }
        }

        private void LoadDressInventory(int dressId)
        {
            try
            {
                List<DressInventory> inventories = inventoryRepository.GetInventoryByDressId(dressId);
                dgvInventory.DataSource = inventories;

                if (dgvInventory.Columns.Contains("InventoryId")) dgvInventory.Columns["InventoryId"].Visible = false;
                if (dgvInventory.Columns.Contains("DressId")) dgvInventory.Columns["DressId"].Visible = false;
                if (dgvInventory.Columns.Contains("Size")) dgvInventory.Columns["Size"].HeaderText = "ไซส์";
                if (dgvInventory.Columns.Contains("TotalQuantity")) dgvInventory.Columns["TotalQuantity"].HeaderText = "จำนวนรวม";
                if (dgvInventory.Columns.Contains("AvailableQuantity")) dgvInventory.Columns["AvailableQuantity"].HeaderText = "จำนวนว่าง";

                dgvInventory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดสต็อก: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            if (currentDressId <= 0) return;

            string newSize = txtInventorySize.SelectedItem?.ToString();
            if (newSize == null || txtInventoryTotalQuantity.Value <= 0)
            {
                MessageBox.Show("กรุณาเลือกไซส์และระบุจำนวน", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.Cells["Size"].Value.ToString() == newSize)
                {
                    MessageBox.Show($"ไซส์ '{newSize}' มีอยู่ในรายการแล้ว กรุณาใช้การแก้ไขแทน", "ข้อมูลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DressInventory newInventory = new DressInventory
            {
                DressId = currentDressId,
                Size = newSize,
                TotalQuantity = (int)txtInventoryTotalQuantity.Value,
                AvailableQuantity = (int)txtInventoryTotalQuantity.Value
            };

            if (inventoryRepository.AddDressInventory(newInventory))
            {
                MessageBox.Show("เพิ่มสต็อกสำเร็จ", "สำเร็จ");
                LoadDressInventory(currentDressId);
                ClearSize();
            }
        }

        private void btnDeleteInventory_Click(object sender, EventArgs e)
        {
            if (currentInventoryId == 0)
            {
                MessageBox.Show("กรุณาเลือกไซส์ที่ต้องการลบก่อน", "แจ้งเตือน");
                return;
            }

            DialogResult result = MessageBox.Show($"คุณต้องการลบไซส์ '{currentSelectedSize}' นี้ใช่หรือไม่?",
                                                  "ยืนยันการลบไซส์",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (inventoryRepository.DeleteInventory(currentInventoryId))
                    {
                        MessageBox.Show("ลบไซส์สำเร็จ", "สำเร็จ");
                        LoadDressInventory(currentDressId); 
                        ClearSize();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ลบไม่สำเร็จ: " + ex.Message);
                }
            }
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvInventory.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvInventory.Rows[e.RowIndex];
                currentInventoryId = Convert.ToInt32(selectedRow.Cells["InventoryId"].Value);
                currentSelectedSize = selectedRow.Cells["Size"].Value.ToString();
                txtInventorySize.Text = currentSelectedSize;
                txtInventoryTotalQuantity.Value = Convert.ToDecimal(selectedRow.Cells["TotalQuantity"].Value);
                txtInventoryAvailableQuantity.Value = Convert.ToDecimal(selectedRow.Cells["AvailableQuantity"].Value);

                this.Invalidate(true);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentDressId <= 0)
            {
                MessageBox.Show("กรุณาเลือกชุดที่ต้องการลบก่อน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("คุณแน่ใจหรือไม่ที่จะลบชุดนี้? การกระทำนี้ไม่สามารถยกเลิกได้", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (dressRepository.DeleteDress(currentDressId))
                    {
                        MessageBox.Show("ลบข้อมูลชุดสำเร็จแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbFilterCategory.SelectedIndex = 0;
                        cmbFilterStatus.SelectedValue = "All";
                        txtSearch.Clear();

                        ApplyFiltersAndLoad();
                        ClearForm();
                    }
                    
                    else
                    {
                        MessageBox.Show("ไม่สามารถลบข้อมูลได้", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public string ConvertStatusToThai(string englishStatus)
        {
            switch (englishStatus)
            {
                case "Available":
                    return "ว่างให้เช่า";
                case "Rented":
                    return "ถูกเช่า (ไม่ว่าง)";
                case "Repair":
                    return "ส่งซ่อม";
                case "Unavailable":
                    return "ยกเลิกใช้งาน";
                default:
                    return englishStatus;
            }
        }

        private void dgvDresses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDresses.Columns[e.ColumnIndex].Name == "status" && e.Value != null)
            {
                string englishStatus = e.Value.ToString();
                e.Value = ConvertStatusToThai(englishStatus);
                e.FormattingApplied = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (currentDressId <= 0)
            {
                MessageBox.Show("ไม่สามารถแก้ไขได้ กรุณาเปิดฟอร์มในโหมดแก้ไข", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNameDress.Text) || txtRentalPrice.Value <= 0)
            {
                MessageBox.Show("กรุณากรอกชื่อชุด และราคาเช่าให้ถูกต้อง", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusToSave = txtStatus.SelectedValue.ToString();

            FancyDress updatedDress = new FancyDress
            {
                DressId = currentDressId,
                Name = txtNameDress.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                RentalPricePerDay = txtRentalPrice.Value,
                DepositPrice = txtDepositPrice.Value,
                ImagePath = txtImagePath.Text.Trim(),
                Status = statusToSave

            };

            try
            {
                dressRepository.UpdateDress(updatedDress);
                MessageBox.Show("แก้ไขชุดแฟนซีสำเร็จ!", "สำเร็จ");

                cmbFilterCategory.SelectedIndexChanged -= FilterChanged_Handler;
                cmbFilterStatus.SelectedIndexChanged -= FilterChanged_Handler;

                InitializeComboBoxes();

                cmbFilterCategory.SelectedIndex = 0;
                cmbFilterStatus.SelectedValue = "All";
                txtSearch.Clear();

                cmbFilterCategory.SelectedIndexChanged += FilterChanged_Handler;
                cmbFilterStatus.SelectedIndexChanged += FilterChanged_Handler;

                ApplyFiltersAndLoad();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการแก้ไขชุดแฟนซี: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearSize()
        {

            txtInventorySize.Text = string.Empty;
            txtInventoryTotalQuantity.Value = 0;
            txtInventoryAvailableQuantity.Value = 0;

            currentSelectedSize = null;
            currentInventoryId = 0;

            btnAddInventory.Enabled = true;     
            btnEditInventory.Enabled = false;   
            btnDeleteInventory.Enabled = false;
        }

        private void btnEditInventory_Click(object sender, EventArgs e)
        {
            if (currentInventoryId <= 0)
            {
                MessageBox.Show("กรุณาเลือกรายการที่จะแก้ไข", "แจ้งเตือน");
                return;
            }

            int newTotalQuantity = (int)txtInventoryTotalQuantity.Value;
            if (newTotalQuantity <= 0) return;

            DataGridViewRow currentRow = dgvInventory.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => Convert.ToInt32(r.Cells["InventoryId"].Value) == currentInventoryId);

            if (currentRow == null) return;

            int oldTotal = Convert.ToInt32(currentRow.Cells["TotalQuantity"].Value);
            int oldAvailable = Convert.ToInt32(currentRow.Cells["AvailableQuantity"].Value);

            int rentedCount = oldTotal - oldAvailable;

            if (newTotalQuantity < rentedCount)
            {
                MessageBox.Show($"ไม่สามารถลดจำนวนลงเหลือ {newTotalQuantity} ได้ เนื่องจากมีลูกค้าเช่าอยู่ {rentedCount} ชุด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int newAvailableQuantity = newTotalQuantity - rentedCount;

            DressInventory updatedInventory = new DressInventory
            {
                InventoryId = currentInventoryId,
                DressId = currentDressId,
                TotalQuantity = newTotalQuantity,
                AvailableQuantity = newAvailableQuantity
            };

            if (inventoryRepository.UpdateDressInventory(updatedInventory))
            {
                MessageBox.Show($"แก้ไขสต็อกไซส์ '{currentSelectedSize}' สำเร็จ!", "สำเร็จ");
                LoadDressInventory(currentDressId);
                ClearSize();
            }
            else
            {
                MessageBox.Show("ไม่สามารถแก้ไขไซส์ได้", "ผิดพลาด");
            }
        }

        private void txtStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClearIn_Click(object sender, EventArgs e)
        {
            ClearSize();
        }

        private void FilterChanged_Handler(object sender, EventArgs e)
        {
            string selectedStatus = "All";
            if (cmbFilterStatus.SelectedValue != null)
            {
                selectedStatus = cmbFilterStatus.SelectedValue.ToString();
            }

            string selectedCategory = cmbFilterCategory.SelectedItem?.ToString();
            if (selectedCategory == null || selectedCategory == "--ประเภท--")
            {
                selectedCategory = "--ประเภท--";
            }


            ApplyFiltersAndLoad(selectedCategory, selectedStatus, txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedStatus = "All";
            if (cmbFilterStatus.SelectedValue != null)
            {
                selectedStatus = cmbFilterStatus.SelectedValue.ToString();
            }

            string selectedCategory = cmbFilterCategory.SelectedItem?.ToString();
            if (selectedCategory == null || selectedCategory == "--ประเภท--")
            {
                selectedCategory = "--ประเภท--";
            }

            ApplyFiltersAndLoad(selectedCategory, selectedStatus, txtSearch.Text.Trim());
        }
    }
}
