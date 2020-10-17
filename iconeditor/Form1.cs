using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iconeditor
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        Brush brush = (Brush)Brushes.Black;
        int zoom = 1;
        bool initialized = false;
        public Form1()
        {
            InitializeComponent();

            graphics = canvas.CreateGraphics();
            pen = new Pen(Color.Black, 1);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            graphics.ScaleTransform(zoom, zoom);
            if(!initialized)
            {
                graphics.FillRectangle(brush, 1, 1, 1, 1);
                graphics.FillRectangle(brush, 1, 3, 1, 1);
                graphics.FillRectangle(brush, 1, 5, 1, 1);
                graphics.FillRectangle(brush, 1, 7, 1, 1);
                graphics.FillRectangle(brush, 1, 9, 1, 1);
                graphics.FillRectangle(brush, 1, 11, 1, 1);

                graphics.FillRectangle(brush, 2, 2, 1, 1);
                graphics.FillRectangle(brush, 2, 4, 1, 1);
                graphics.FillRectangle(brush, 2, 6, 1, 1);
                graphics.FillRectangle(brush, 2, 8, 1, 1);
                graphics.FillRectangle(brush, 2, 10, 1, 1);
                graphics.FillRectangle(brush, 2, 12, 1, 1);

                graphics.FillRectangle(brush, 3, 1, 1, 1);
                graphics.FillRectangle(brush, 3, 3, 1, 1);
                graphics.FillRectangle(brush, 3, 5, 1, 1);
                graphics.FillRectangle(brush, 3, 7, 1, 1);
                graphics.FillRectangle(brush, 3, 9, 1, 1);
                graphics.FillRectangle(brush, 3, 11, 1, 1);

                graphics.FillRectangle(brush, 4, 2, 1, 1);
                graphics.FillRectangle(brush, 4, 4, 1, 1);
                graphics.FillRectangle(brush, 4, 6, 1, 1);
                graphics.FillRectangle(brush, 4, 8, 1, 1);
                graphics.FillRectangle(brush, 4, 10, 1, 1);
                graphics.FillRectangle(brush, 4, 12, 1, 1);

                graphics.FillRectangle(brush, 5, 1, 1, 1);
                graphics.FillRectangle(brush, 5, 3, 1, 1);
                graphics.FillRectangle(brush, 5, 5, 1, 1);
                graphics.FillRectangle(brush, 5, 7, 1, 1);
                graphics.FillRectangle(brush, 5, 9, 1, 1);
                graphics.FillRectangle(brush, 5, 11, 1, 1);

                graphics.FillRectangle(brush, 6, 2, 1, 1);
                graphics.FillRectangle(brush, 6, 4, 1, 1);
                graphics.FillRectangle(brush, 6, 6, 1, 1);
                graphics.FillRectangle(brush, 6, 8, 1, 1);
                graphics.FillRectangle(brush, 6, 10, 1, 1);
                graphics.FillRectangle(brush, 6, 12, 1, 1);

                initialized = true;
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x != -1 && y != -1)
            {
                graphics.DrawLine(pen, new Point(x, y), e.Location);

                x = e.X;
                y = e.Y;
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            //zoom = trackBar1.Value / 100f;
            canvas.Invalidate();
            Console.WriteLine(zoom.ToString());
        }
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            zoom = zoom - 10;
            canvas.Invalidate();
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            zoom = zoom + 10;
            canvas.Invalidate();
            brush = (Brush)Brushes.Beige;

        }

    }
}
