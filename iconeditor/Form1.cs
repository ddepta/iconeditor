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
            drawGrid();
        }

        private void drawGrid()
        {
            Pen dashedPen = new Pen(Color.Pink, 2);
            dashedPen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            dashedPen.DashOffset = 10;
            dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            graphics.DrawLine(dashedPen, 1, 100, 500, 100);
            graphics.DrawLine(dashedPen, 1, 200, 500, 200);
            graphics.DrawLine(dashedPen, 1, 300, 500, 300);
            graphics.DrawLine(dashedPen, 1, 400, 500, 400);

            graphics.DrawLine(dashedPen, 100, 1, 100, 500);
            graphics.DrawLine(dashedPen, 200, 1, 200, 500);
            graphics.DrawLine(dashedPen, 300, 1, 300, 500);
            graphics.DrawLine(dashedPen, 400, 1, 400, 500);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;

            int rectangle_X = e.X / 100;
            rectangle_X = rectangle_X * 100;

            int rectangle_Y = e.Y / 100;
            rectangle_Y = rectangle_Y * 100;
            graphics.FillRectangle(brush, rectangle_X, rectangle_Y, 100, 100);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x != -1 && y != -1)
            {
                int rectangle_X = e.X / 100;
                rectangle_X = rectangle_X * 100;

                int rectangle_Y = e.Y / 100;
                rectangle_Y = rectangle_Y * 100;
                graphics.FillRectangle(brush, rectangle_X, rectangle_Y, 100, 100);

                x = e.X;
                y = e.Y;
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            drawGrid();
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

        private void Eraser_Click(object sender, EventArgs e)
        {
            brush = (Brush)Brushes.White;
        }

        private void Black_Click(object sender, EventArgs e)
        {
            brush = (Brush)Brushes.Black;

        }
    }
}
