using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPictureBox : PictureBox
{
    private int cornerRadius = 15; // รัศมีที่แนะนำ (ควรเท่ากับปุ่มอื่นๆ)

    public int CornerRadius
    {
        get { return cornerRadius; }
        set
        {
            cornerRadius = value;
            this.Invalidate(); // บังคับให้วาดใหม่
        }
    }

    private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);

        Rectangle arc = new Rectangle(bounds.Location, size);
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

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
        using (GraphicsPath path = GetRoundedRect(bounds, cornerRadius))
        {
            this.Region = new Region(path);
        }
    }

}
