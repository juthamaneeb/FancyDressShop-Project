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
    public partial class CustomerCart : UserControl
    {
        private RentalRepository rentalRepo = new RentalRepository();
        private Customer currentCustomer;
        public CustomerCart(Customer customer)
        {
            InitializeComponent();
            this.currentCustomer = customer;
            LoadRentalCards();
        }

        public void LoadRentalCards(bool isHistory = false)
        {
            List<Rental> allRentals = rentalRepo.GetRentalsByCustomerId(this.currentCustomer.CustomerId);

            var completedAndCancelled = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "completed",
                "cancelled",
                "closed"
            };

            List<Rental> currentRentals;

            if (isHistory)
            {
                currentRentals = allRentals
                    .Where(r => completedAndCancelled.Contains(r.Status.ToLower()))
                    .ToList();
            }
            else
            {
                currentRentals = allRentals
                    .Where(r => !completedAndCancelled.Contains(r.Status.ToLower()))
                    .ToList();
            }
            flowLayoutPanelRentals.Controls.Clear();
            flowLayoutPanelRentals.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelRentals.WrapContents = true;
            flowLayoutPanelRentals.Visible = true;

            int panelWidth = flowLayoutPanelRentals.ClientSize.Width;
            int columns = 5;
            int margin = 20;
            int finalCardWidth = (panelWidth - (columns + 1) * margin) / columns;
            int cardHeight = 387;

            if (currentRentals.Count == 0)
            {
                Label lblNoRentals = new Label();
                string message = isHistory
                    ? "ยังไม่มีรายการเช่าที่ถูกยกเลิกหรือเสร็จสิ้น (Completed/Cancelled)"
                    : "ไม่มีรายการเช่าที่ต้องดำเนินการอยู่ในขณะนี้";

                lblNoRentals.Text = message;
                lblNoRentals.AutoSize = true;
                lblNoRentals.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
                flowLayoutPanelRentals.Controls.Add(lblNoRentals);
                return;
            }

            foreach (var rental in currentRentals)
            {
                RentalCard card = new RentalCard(rental);

                card.Width = finalCardWidth;
                card.Height = cardHeight;
                card.Margin = new Padding(10);

                card.RentalCardSelected += Card_RentalCardSelected;

                flowLayoutPanelRentals.Controls.Add(card);
            }
        }

        private void Card_RentalCardSelected(object sender, Rental rentalData)
        {
            CustomerRentals detailView = new CustomerRentals(rentalData, this);
            detailView.Dock = DockStyle.Fill;

            flowLayoutPanelRentals.Visible = false;

            pnlBody.Controls.Add(detailView);

            detailView.BringToFront();
        }

        private void HighlightButton(object btnSender)
        {
            var clickedButton = btnSender as RoundedButton;

            if (clickedButton == null) return;

            Color activeColor = Color.FromArgb(247, 211, 110);
            Color defaultColor = Color.FromArgb(168, 218, 220);

            btnCurrentBills.IsSelected = false;
            btnCurrentBills.BackColor = defaultColor;

            btnHistory.IsSelected = false;
            btnHistory.BackColor = defaultColor;

            clickedButton.IsSelected = true; 
            clickedButton.BackColor = activeColor;
        }

        private void BtnCurrentBills_Click(object sender, EventArgs e)
        {
            CloseDetailView();

            HighlightButton(sender);

            LoadRentalCards(false);
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            CloseDetailView();

            HighlightButton(sender);

            LoadRentalCards(true);
        }

        private void CloseDetailView()
        {
            foreach (Control c in pnlBody.Controls)
            {
                if (c is CustomerRentals)
                {
                    pnlBody.Controls.Remove(c);
                    c.Dispose();
                }
            }
            flowLayoutPanelRentals.Visible = true;
        }
    }
}
