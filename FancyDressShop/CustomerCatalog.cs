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
    public partial class CustomerCatalog : UserControl
    {
        private FancyDressRepository dressRepository;
        private List<string> allCategories;
        private MainForm parentForm;

        public CustomerCatalog(MainForm mainForm)
        {
            InitializeComponent();
            this.parentForm = mainForm;
            dressRepository = new FancyDressRepository();

            InitializeCategoryFilter();

            flowLayoutPanelCatalog.AutoScroll = true;

            ApplyFiltersAndLoad();

            cmbCategoryFilter.SelectedIndexChanged += FilterChanged_Handler;
        }

        private void InitializeCategoryFilter()
        {
            allCategories = dressRepository.GetAllCategoriesFromDresses();
            cmbCategoryFilter.Items.Clear();

            cmbCategoryFilter.Items.Add("--หมวดหมู่--");
            cmbCategoryFilter.Items.Add("All");

            if (allCategories.Count > 0)
            {
                cmbCategoryFilter.Items.AddRange(allCategories.ToArray());
            }
            cmbCategoryFilter.SelectedIndex = 0; 
        }

        private void ApplyFiltersAndLoad()
        {
            flowLayoutPanelCatalog.Controls.Clear();

            string searchTerm = txtSearch.Text.Trim();
            string selectedCategory = cmbCategoryFilter.SelectedItem?.ToString() ?? "--หมวดหมู่--";

            string repoCategoryFilter = (selectedCategory == "--หมวดหมู่--") ? "All" : selectedCategory;

            List<FancyDress> dresses;

            dresses = dressRepository.SearchDresses(searchTerm, repoCategoryFilter);

            if (dresses.Count == 0)
            {
                Label lblNoDresses = new Label();
                lblNoDresses.Text = "ไม่พบชุดแฟนซีที่ตรงกับเงื่อนไขการค้นหา/กรอง และสถานะว่างให้เช่า";
                lblNoDresses.AutoSize = true;
                flowLayoutPanelCatalog.Controls.Add(lblNoDresses);
                return;
            }

            foreach (var dress in dresses)
            {
                DressItemControl item = new DressItemControl();
                item.SetDressData(dress);
                item.OnViewDetailsClicked += (sender, id) => OpenDressDetail(id);
                flowLayoutPanelCatalog.Controls.Add(item);
            }
        }

        private void FilterChanged_Handler(object sender, EventArgs e)
        {
            ApplyFiltersAndLoad();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            ApplyFiltersAndLoad();
        }
        private void OpenDressDetail(int dressId)
        {
            DressDetail detail = new DressDetail(parentForm, dressId);

            parentForm.LoadUserControl(detail); 
        }

    }
}
