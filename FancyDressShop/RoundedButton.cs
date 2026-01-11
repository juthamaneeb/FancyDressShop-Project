using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    // เพิ่มตัวแปรเช็คสถานะว่าถูกเลือกอยู่ไหม
    private bool isSelected = false;
    public bool IsSelected
    {
        get { return isSelected; }
        set
        {
            isSelected = value;
            // ถ้าถูกเลือก ให้หยุดการคำนวณสีพื้นหลังอัตโนมัติชั่วคราว
            // เพื่อให้ MainForm เป็นคนกำหนดสีเอง
        }
    }

    private int cornerRadius = 15;
    public int CornerRadius
    {
        get { return cornerRadius; }
        set { cornerRadius = value; this.Invalidate(); }
    }

    private Color borderColor = Color.Black;
    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; this.Invalidate(); }
    }

    private int borderThickness = 1;
    public int BorderThickness
    {
        get { return borderThickness; }
        set { borderThickness = value; this.Invalidate(); }
    }

    private Color hoverBackColor = Color.FromArgb(220, 220, 220); // สีเทาอ่อนๆ ตอนชี้
    public Color HoverBackColor
    {
        get { return hoverBackColor; }
        set { hoverBackColor = value; }
    }

    private Color defaultBackColor;

    public RoundedButton()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.StandardClick, true);

        // เก็บสีเริ่มต้นไว้
        defaultBackColor = this.BackColor;

        this.MouseEnter += RoundedButton_MouseEnter;
        this.MouseLeave += RoundedButton_MouseLeave;
    }

    protected override void OnBackColorChanged(EventArgs e)
    {
        // ⭐️ สำคัญ: อย่าจำค่าสีใหม่ ถ้ามันคือสีตอน Hover หรือ สีตอนถูกเลือก (สีทอง)
        // ให้จำเฉพาะตอนที่เป็นสีปกติ
        if (!this.DesignMode && this.BackColor != HoverBackColor && !IsSelected)
        {
            defaultBackColor = this.BackColor;
        }
        base.OnBackColorChanged(e);
        this.Invalidate();
    }

    private void RoundedButton_MouseEnter(object sender, EventArgs e)
    {
        // ⭐️ ถ้าถูกเลือกอยู่ (สีทอง) ไม่ต้องเปลี่ยนสีตอนเอาเมาส์ชี้
        if (!IsSelected)
        {
            this.BackColor = HoverBackColor;
            this.Invalidate();
        }
    }

    private void RoundedButton_MouseLeave(object sender, EventArgs e)
    {
        // ⭐️ ถ้าถูกเลือกอยู่ (สีทอง) ไม่ต้องคืนค่าสีเดิมตอนเอาเมาส์ออก
        if (!IsSelected)
        {
            this.BackColor = defaultBackColor;
            this.Invalidate();
        }
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        this.Focus();
        base.OnMouseUp(mevent);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        Graphics g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

        using (GraphicsPath path = GetRoundedRect(bounds, cornerRadius))
        {
            this.Region = new Region(path);

            // ⭐️⭐️⭐️ แก้ไข: เช็ค Enabled เพื่อเปลี่ยนสีพื้นหลัง ⭐️⭐️⭐️
            Color buttonColor;
            if (this.Enabled)
            {
                // ถ้าใช้งานได้: ใช้สีปกติ หรือสีทอง(ถ้าถูกเลือก)
                buttonColor = IsSelected ? Color.FromArgb(247, 211, 110) : this.BackColor;
            }
            else
            {
                // ถ้าถูกปิด (Disable): ใช้สีเทา
                buttonColor = Color.LightGray;
            }

            using (SolidBrush brush = new SolidBrush(buttonColor))
            {
                g.FillPath(brush, path);
            }

            // ⭐️⭐️⭐️ แก้ไข: เช็ค Enabled เพื่อเปลี่ยนสีตัวหนังสือ ⭐️⭐️⭐️
            Color textColor = this.Enabled ? this.ForeColor : Color.DarkGray;

            TextRenderer.DrawText(g, this.Text, this.Font, bounds, textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // วาดขอบ (ถ้า Disable อาจจะไม่วาดขอบ หรือวาดสีเทา)
            if (borderThickness > 0 && this.Enabled)
            {
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    g.DrawPath(pen, path);
                }
            }
        }
    }


    private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int diameter = radius * 2;
        if (diameter > bounds.Width) diameter = bounds.Width;
        if (diameter > bounds.Height) diameter = bounds.Height;

        Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();
        return path;
    }
}