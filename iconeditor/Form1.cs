using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iconeditor
{
    public partial class IconEditor : Form
    {
        Graphics graphics;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        Brush brush = (Brush)Brushes.Black;
        int zoom = 1;
        bool initialized = false;
        Bitmap bmp;

        String[,] icon = new String[10, 10];
        Color[,] image = new Color[10, 10];

        public IconEditor()
        {
            InitializeComponent();

            graphics = canvas.CreateGraphics();
            pen = new Pen(Color.Black, 1);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
            bmp = new Bitmap(canvas.ClientSize.Width, canvas.ClientSize.Height);

            for(int i = 0; i < 10; i++)
            {
                for(int k = 0; k < 10; k++)
                {
                    icon[i, k] = "#FFFFFF";
                    image[i, k] = Color.White;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
            //e.Graphics.DrawImage(bmp, Point.Empty);
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

            int selector_X = e.X / 100;
            int rectangle_X = selector_X * 100;

            int selector_Y = e.Y / 100;
            int rectangle_Y = selector_Y * 100;

            /*
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.FillRectangle(brush, rectangle_X, rectangle_Y, 100, 100);
            }
            canvas.Invalidate();
            */
            Color c = new Pen(brush).Color;
            string hexcolor = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            icon[selector_Y, selector_X] = hexcolor;
            image[selector_Y, selector_X] = c;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" " + icon[i,j]);
                }
                Console.WriteLine();
            }
            graphics.FillRectangle(brush, rectangle_X, rectangle_Y, 100, 100);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x != -1 && y != -1)
            {
                int selector_X = e.X / 100;
                int rectangle_X = selector_X * 100;

                int selector_Y = e.Y / 100;
                int rectangle_Y = selector_Y * 100;

                x = e.X;
                y = e.Y;

                /*
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(brush, rectangle_X, rectangle_Y, 100, 100);
                }
                */

                //canvas.Invalidate();

                Color c = new Pen(brush).Color;
                string hexcolor = "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
                icon[selector_Y, selector_X] = hexcolor;
                image[selector_Y, selector_X] = c;

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(" " + icon[i, j]);
                    }
                    Console.WriteLine();
                }

                graphics.FillRectangle(brush, rectangle_X, rectangle_Y, 100, 100);
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

        private void DateiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Guid guid = new Guid();
            //bmp.Save(guid.ToString() + ".png", ImageFormat.Png);
            /*
            Graphics gtmp = Graphics.FromImage(bmp);

            bmp = new Bitmap(canvas.ClientSize.Width, canvas.ClientSize.Height);
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(canvas.Width);
                int height = Convert.ToInt32(canvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                //graphics.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
            }
            */


            Bitmap bm = new Bitmap(10, 10);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                Color c;
                for(int y = 0; y < 10; y++)
                {
                    for(int x = 0; x < 10; x++)
                    {
                        c = image[y, x];
                        using (Pen p = new Pen(c, 1))
                        {
                            gr.DrawRectangle(p, x, y, 1, 1);
                        }
                    }
                }

                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    bm.Save(dialog.FileName, ImageFormat.Png);
                }
            }
        }

        private void BtnRed_Click(object sender, EventArgs e)
        {
            brush = (Brush)Brushes.Red;

        }
    }
}
