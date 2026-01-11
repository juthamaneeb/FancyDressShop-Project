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
    public partial class SlipViewerForm : Form
    {
        public SlipViewerForm(Image slipImage)
        {
            InitializeComponent();

            this.Text = "หลักฐานการชำระเงิน";

            picSlip.Image = slipImage;
            picSlip.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
