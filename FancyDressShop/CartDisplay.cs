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
    public partial class CartDisplay : UserControl
    {
        private MainForm parentForm;
        private int numberOfDays = 0;
        private RentalRepository _rentalRepo = new RentalRepository();
        private Customer loggedInCustomer;

        public CartDisplay(MainForm mainForm, Customer customer)
        {
            InitializeComponent();
            this.parentForm = mainForm;
            this.loggedInCustomer = customer;

            dtpRentalDate.Value = DateTime.Now.Date;
            dtpDueDate.Value = DateTime.Now.Date.AddDays(1);

            Date_ValueChanged(null, EventArgs.Empty);
            dtpRentalDate.ValueChanged += Date_ValueChanged;

            dtpDueDate.ValueChanged += Date_ValueChanged;
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            flowLayoutPanelItems.Controls.Clear();

            if (CartManager.Instance.Items.Count == 0)
            {
                lblEmptyCart.Visible = true;
                pnlSummary.Enabled = false;
                btnClearCart.Visible = false; 
                RecalculateTotal();
                return;
            }

            lblEmptyCart.Visible = false;
            pnlSummary.Enabled = true;
            btnClearCart.Visible = true;

            foreach (var item in CartManager.Instance.Items)
            {
                CartItemCard card = new CartItemCard(item, numberOfDays);

                card.ItemChanged += (sender, e) =>
                {
                    RecalculateTotal();
                };

                card.ItemRemoved += (sender, e) =>
                {
                    RecalculateTotal();
                    LoadCartItems(); 
                };

                flowLayoutPanelItems.Controls.Add(card);
            }
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            DateTime rentalDate = dtpRentalDate.Value.Date;
            DateTime dueDate = dtpDueDate.Value.Date;

            if (dtpDueDate.Value.Date <= dtpRentalDate.Value.Date)
            {
                dtpDueDate.Value = dtpRentalDate.Value.Date.AddDays(1);
                MessageBox.Show("กำหนดคืนต้องหลังวันที่เช่าอย่างน้อย 1 วัน", "แจ้งเตือน");
                return;
            }

            numberOfDays = CalculateRentalDays();

            lblNumDays.Text = $"จำนวนวันเช่า: {numberOfDays} วัน";

            CartManager.Instance.RentalDate = rentalDate;
            CartManager.Instance.DueDate = dueDate;

            foreach (CartItemCard card in flowLayoutPanelItems.Controls.OfType<CartItemCard>())
            {
                card.UpdatePrice(numberOfDays);
            }

            RecalculateTotal();
        }
        private void RecalculateTotal()
        {
            int days = CalculateRentalDays();
            if (days <= 0)
            {
                lblTotalRentalPrice.Text = "ยอดรวมค่าเช่า: 0.00 บ.";
                lblTotalDeposit.Text = "ยอดรวมค่ามัดจำ: 0.00 บ.";
                btnProceed.Enabled = false;
                return;
            }

            if (CartManager.Instance.Items.Count == 0)
            {
                lblTotalRentalPrice.Text = "ยอดรวมค่าเช่า: 0.00 บ.";
                btnProceed.Enabled = false;
                return;
            }

            decimal totalRentalPrice = 0;
            decimal totalDeposit = 0;

            foreach (var item in CartManager.Instance.Items)
            {
                totalRentalPrice += item.RentalPricePerDay * item.Quantity * numberOfDays;

                totalDeposit += item.DepositPrice * item.Quantity;
            }

            decimal grandTotal = totalRentalPrice + totalDeposit;

            lblTotalRentalPrice.Text = $"ยอดรวมค่าเช่า: {totalRentalPrice:N2} บ."; 
            lblTotalDeposit.Text = $"ยอดรวมค่ามัดจำ: {totalDeposit:N2} บ.";
            pnlSummary.Text = $"รวมทั้งหมดที่ต้องชำระ: {grandTotal:N2} บ.";

            btnProceed.Enabled = true;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            var cartItems = CartManager.Instance.Items;
            if (cartItems.Count == 0)
            {
                MessageBox.Show("ตะกร้าว่างเปล่า กรุณาเพิ่มชุดก่อนดำเนินการต่อ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime rentalDate = dtpRentalDate.Value.Date;
            DateTime dueDate = dtpDueDate.Value.Date;

            if (dueDate <= rentalDate)
            {
                MessageBox.Show("วันที่คืนต้องเป็นวันหลังวันที่รับชุด", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loggedInCustomer == null)
            {
                MessageBox.Show("ข้อผิดพลาด: ไม่พบข้อมูลลูกค้า กรุณาลองเข้าสู่ระบบใหม่", "Error");
                return;
            }

            if (loggedInCustomer.Status.Equals("Suspended", StringComparison.OrdinalIgnoreCase))
            {
                string banUntilMsg = loggedInCustomer.BanUntil.HasValue
                                         ? $"จนถึงวันที่ {loggedInCustomer.BanUntil.Value.ToShortDateString()}"
                                         : "โดยไม่มีกำหนด";

                MessageBox.Show($"บัญชีของคุณถูกระงับชั่วคราว {banUntilMsg} ไม่สามารถทำรายการเช่าได้",
                                "ถูกระงับชั่วคราว",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                "คุณต้องการยืนยันการเช่าชุดนี้ใช่หรือไม่? บิลจะถูกสร้างและรอการชำระเงิน",
                "ยืนยันการเช่า",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int days = CalculateRentalDays();
                    decimal totalRentalPrice = cartItems.Sum(item => item.RentalPricePerDay * item.Quantity * days);
                    decimal totalDeposit = cartItems.Sum(item => item.DepositPrice * item.Quantity);
                    decimal grandTotal = totalRentalPrice + totalDeposit;

                    int newRentalId = _rentalRepo.CreateRental(
                        loggedInCustomer.CustomerId,
                        rentalDate,
                        dueDate,
                        grandTotal,   
                        totalDeposit,
                        cartItems
                    );

                    if (newRentalId > 0)
                    {
                        MessageBox.Show("สร้างบิลสำเร็จแล้ว! กรุณาดำเนินการชำระเงิน", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CartManager.Instance.ClearCart();

                        parentForm.LoadUserControl(new PaymentConfirmation(this.parentForm, newRentalId));
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถสร้างบิลได้ กรุณาลองใหม่อีกครั้ง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการสร้างบิล: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการล้างตะกร้าสินค้าทั้งหมดใช่หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CartManager.Instance.ClearCart();
                LoadCartItems();
                RecalculateTotal();
            }
        }

        private int CalculateRentalDays()
        {
            DateTime rentalDate = dtpRentalDate.Value.Date;
            DateTime dueDate = dtpDueDate.Value.Date;

            if (dueDate <= rentalDate)
            {
                dtpDueDate.Value = rentalDate.AddDays(1);
                dueDate = dtpDueDate.Value.Date;
            }

            TimeSpan diff = dueDate - rentalDate;

            int rentalDays = (int)Math.Ceiling(diff.TotalDays);

            return rentalDays;
        }


    }
}
