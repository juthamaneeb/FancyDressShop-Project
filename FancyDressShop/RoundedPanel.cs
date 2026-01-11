using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    private int cornerRadius = 20;
    public int CornerRadius
    {
        get { return cornerRadius; }
        set
        {
            cornerRadius = value;
            this.Invalidate();
        }
    }

    // *** 2. Property สำหรับเปิด/ปิด Hover (ที่คุณสร้างเอง) ***
    private bool enableHover = true;
    public bool EnableHover
    {
        get { return enableHover; }
        set { enableHover = value; }
    }

    // *** 3. Property สำหรับเส้นขอบ (ที่ขาดหายไป) ***
    private Color borderColor = Color.LightGray; // สีเส้นขอบเริ่มต้น (ตั้งค่าเริ่มต้นให้ไม่ติดแดง)
    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; this.Invalidate(); }
    }

    // *** 4. ความหนาของเส้นขอบ (ที่ขาดหายไป) ***
    private int borderThickness = 1; // ค่าเริ่มต้น 1 pixel
    public int BorderThickness
    {
        get { return borderThickness; }
        set { borderThickness = value; this.Invalidate(); }
    }

    // *** 5. Logic สำหรับ Hover Effect (ที่คุณวางมา) ***
    public Color HoverBorderColor { get; set; } = Color.Red; // สีแดงตาม Palette
    private bool isHovering = false; // สถานะ

    public RoundedPanel()
    {
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.MouseEnter += RoundedPanel_MouseEnter;
        this.MouseLeave += RoundedPanel_MouseLeave;
    }

    private void RoundedPanel_MouseEnter(object sender, EventArgs e)
    {
        if (this.EnableHover)
        {
            isHovering = true;
            this.Invalidate();
        }
    }

    private void RoundedPanel_MouseLeave(object sender, EventArgs e)
    {
        if (this.EnableHover)
        {
            isHovering = false;
            this.Invalidate();
        }
    }


    private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(bounds.Location, size);
        GraphicsPath path = new GraphicsPath();

        // Top Left
        path.AddArc(arc, 180, 90);

        // Top Right
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);

        // Bottom Right
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // Bottom Left
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }


    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // ประกาศ Graphics object
        Graphics g = e.Graphics;

        Rectangle bounds = new Rectangle(0, 0, this.Width - borderThickness, this.Height - borderThickness);
        using (GraphicsPath path = GetRoundedRect(bounds, cornerRadius))
        {
            // กำหนด Region เพื่อตัดมุม
            this.Region = new Region(path);
            Color currentBorderColor = borderColor;
            if (isHovering && enableHover)
            {
                currentBorderColor = HoverBorderColor;
            }
            else
            {
                currentBorderColor = borderColor;
            }

            if (borderThickness > 0)
            {
                // วาดเส้นขอบ
                using (Pen pen = new Pen(currentBorderColor, borderThickness))
                {
                    // ตั้งค่า SmoothingMode เพื่อให้ขอบดูเนียน
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawPath(pen, path);
                }
            }
        }
    }
}