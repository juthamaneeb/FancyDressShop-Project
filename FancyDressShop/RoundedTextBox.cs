using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedTextBox : TextBox
{
    private int cornerRadius = 10; // รัศมีที่แนะนำคือ 5-10
    private int borderThickness = 1;
    private Color borderColor = Color.LightGray;

    public int CornerRadius
    {
        get { return cornerRadius; }
        set { cornerRadius = value; this.Invalidate(); }
    }

    // ต้องตั้งค่า BorderStyle ให้เป็น None เพื่อให้เราวาดเอง
    public RoundedTextBox()
    {
        this.BorderStyle = BorderStyle.None;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

        using (GraphicsPath path = new GraphicsPath())
        {
            // วาดรูปสี่เหลี่ยมผืนผ้าที่มีมุมมน
            path.AddArc(bounds.X, bounds.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddArc(bounds.Right - cornerRadius * 2, bounds.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddArc(bounds.Right - cornerRadius * 2, bounds.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.CloseAllFigures();

            // 1. วาดเส้นขอบ
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                g.DrawPath(pen, path);
            }

            // 2. กำหนด Region ให้ TextBox (ต้องทำใน OnResize)
            // this.Region = new Region(path); // *หากทำใน OnPaint จะทำให้ Textbox มีปัญหาเรื่อง Cursor*
        }
    }

    // *** การวาด TextBox ที่ซับซ้อนกว่านี้มักต้องใช้ WndProc เพื่อดักข้อความของ Windows ***
    // แต่สำหรับการวาดเส้นขอบภายนอกเบื้องต้น วิธีนี้จะเพียงพอ

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        // ต้องบังคับให้วาดใหม่เมื่อขนาดเปลี่ยน
        this.Invalidate();
    }
}