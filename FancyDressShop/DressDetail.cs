using FancyDressShop.Models;
using FancyDressShop.Repositories;
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
    public partial class DressDetail : UserControl
    {
        private MainForm parentForm;
        private int currentDressId;
        private FancyDressRepository dressRepository;
        private DressInventoryRepository inventoryRepository;
        private List<DressInventory> availableInventory;
        private FancyDress currentDress;
        public DressDetail(MainForm mainForm, int dressId)
        {
            InitializeComponent();
            this.parentForm = mainForm;
            this.currentDressId = dressId;
            dressRepository = new FancyDressRepository();
            inventoryRepository = new DressInventoryRepository();

            LoadDressDetails(dressId);
            btnBack.Click += (sender, e) => parentForm.LoadUserControl(new CustomerCatalog(parentForm));
        }

        private void LoadDressDetails(int dressId)
        {
            this.currentDressId = dressId;
            currentDress = dressRepository.GetDressById(dressId);

            if (currentDress != null)
            {
                lblDetailName.Text = currentDress.Name;
                txtDescription.Text = currentDress.Description;
                lblDetailPrice.Text = $"ราคาเช่า : {currentDress.RentalPricePerDay:N2} บ./วัน";
                lblDetailDeposit.Text = $"ค่ามัดจำ : {currentDress.DepositPrice:N2} บ.";

                string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, currentDress.ImagePath);

                if (!string.IsNullOrEmpty(currentDress.ImagePath) && System.IO.File.Exists(fullPath))
                {
                    try
                    {
                        using (var stream = new System.IO.FileStream(fullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            picFullDress.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ไม่สามารถโหลดภาพได้: " + ex.Message, "ข้อผิดพลาดภาพ");
                        picFullDress.Image = null;
                    }
                }
                else
                {
                    picFullDress.Image = null;
                }

                LoadSizesIntoComboBox();
                LoadRelatedDresses(dressId, currentDress.Category);
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลชุดนี้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSizesIntoComboBox()
        {
            availableInventory = inventoryRepository.GetInventoryByDressId(this.currentDressId);
            cmbSize.DataSource = availableInventory;
            cmbSize.DisplayMember = "Size";
            cmbSize.ValueMember = "InventoryId";

            cmbSize.SelectedIndexChanged -= CmbSize_SelectedIndexChanged;
            cmbSize.SelectedIndexChanged += CmbSize_SelectedIndexChanged;

            if (cmbSize.Items.Count > 0)
            {
                cmbSize.SelectedIndex = 0;
                CmbSize_SelectedIndexChanged(cmbSize, EventArgs.Empty);
            }
            else
            {
                lblAvailableStock.Text = "สินค้าหมดทุกไซส์";
                btnAddToCart.Enabled = false;
            }
        }

        private void CmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSize.SelectedItem != null)
            {
                DressInventory selectedSize = cmbSize.SelectedItem as DressInventory;

                if (selectedSize != null)
                {
                    lblAvailableStock.Text = $"คงเหลือ: {selectedSize.AvailableQuantity} ชุด";

                    btnAddToCart.Enabled = (selectedSize.AvailableQuantity > 0);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.LoadUserControl(new CustomerCatalog(parentForm));
        }

        private void LoadRelatedDresses(int currentDressId, string category)
        {
            flowLayoutPanelRelated.Controls.Clear();
            List<FancyDress> relatedDresses =
                dressRepository.GetRelatedDresses(currentDressId, category);

            foreach (var dress in relatedDresses.Take(4))
            {
                MiniCard miniCard = new MiniCard();
                miniCard.SetDressData(dress);

                miniCard.OnViewDetailsClicked += MiniCard_OnViewDetailsClicked;

                flowLayoutPanelRelated.Controls.Add(miniCard);
            }
        }

        private void MiniCard_OnViewDetailsClicked(object sender, int dressId)
        {
            LoadDressDetails(dressId);
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbSize_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbSize.SelectedItem != null)
            {
                DressInventory selectedSize = cmbSize.SelectedItem as DressInventory;

                if (selectedSize != null)
                {
                    lblAvailableStock.Text = $"คงเหลือ: {selectedSize.AvailableQuantity} ชุด";

                    nudQuantity.Maximum = selectedSize.AvailableQuantity;
                    nudQuantity.Minimum = 1;

                    nudQuantity.Value = (selectedSize.AvailableQuantity > 0) ? 1 : 0;

                    btnAddToCart.Enabled = (selectedSize.AvailableQuantity > 0);
                }
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (parentForm.loggedInCustomer != null && parentForm.loggedInCustomer.Status.Equals("Suspended", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("บัญชีของคุณถูกระงับชั่วคราว ไม่สามารถเพิ่มชุดเข้าตะกร้าเพื่อทำการจองได้", "ถูกระงับชั่วคราว", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedInventoryId = GetSelectedInventoryId();
            int quantity = (int)nudQuantity.Value;

            if (selectedInventoryId <= 0 || quantity <= 0)
            {
                MessageBox.Show("กรุณาเลือกขนาดและระบุจำนวนให้ถูกต้อง");
                return;
            }

            var repo = new FancyDressRepository();
            CartItem newItem = repo.GetCartItemDetailByInventoryId(selectedInventoryId, quantity);

            if (newItem != null)
            {
                CartManager.Instance.AddItem(newItem);
                MessageBox.Show($"{newItem.DressName} (ไซส์ {newItem.DressSize}) จำนวน {quantity} ถูกเพิ่มเข้าตะกร้าแล้ว", "สำเร็จ");
            }
            else
            {
                MessageBox.Show("ไม่พบรายละเอียดสินค้าในคลัง หรือสินค้าไม่พร้อมใช้งาน", "ข้อผิดพลาด");
            }
        }
        private int GetSelectedInventoryId()
        {
            if (cmbSize.SelectedItem is DressInventory selectedSize)
            {
                return selectedSize.InventoryId;
            }

            return 0;
        }
    }
}
