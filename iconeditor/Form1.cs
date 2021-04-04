using System;
using System.Collections;
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
        byte x_size = 16;
        byte y_size = 16;
        byte max_x_size = 64;
        byte max_y_size = 64;
        int canvas_width = 0;
        int canvas_height = 0;
        int canvas_pixelsize;

        bool moving = false;
        bool x_valid = true;
        bool y_valid = true;

        Pen pen;
        Brush brush = (Brush)Brushes.Black;
        Bitmap bmp;

        Pen dashedPen = new Pen(Color.Silver, 1);

        Color[,] icon = new Color[64, 64];

        public IconEditor()
        {
            InitializeComponent();

            tbX.Text = x_size.ToString();
            tbY.Text = y_size.ToString();

            graphics = canvas.CreateGraphics();

            // Pen to draw pixels onto the canvas
            pen = new Pen(Color.Black, 1);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
            bmp = new Bitmap(canvas.ClientSize.Width, canvas.ClientSize.Height);

            btnPen.BackColor = ColorTranslator.FromHtml("#2D9EEF");

            // Pen to draw the dashed grid lines onto the canvas
            dashedPen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            dashedPen.DashOffset = 50;
            dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            ClearCanvas();
            CalculatePixels();
            drawGrid();
        }

        private Color[,] ClearCanvas(Color[,] canvas = null)
        {
            for (int i = 0; i < max_x_size; i++)
            {
                for (int k = 0; k < max_y_size; k++)
                {
                    if(canvas != null)
                    {
                        canvas[i, k] = Color.White;
                    }
                    else
                    {
                        icon[i, k] = Color.White;
                    }
                }
            }

            return canvas;
        }

        private void CalculatePixels()
        {
            /* 
             * Get the canvas dimensions and calculate the size for the pixels, so every pixel is square
             * Pixel width = (canvas width / amount of x-pixels) - size of grid lines
             * the size of the grid lines is substracted, to keep a space between the pixels for the grid
             */

            canvas_width = Size.Width - 40;
            canvas_height = Size.Height - 85;
            int canvas_pixelsize_width = (canvas_width / x_size) - 1;
            int canvas_pixelsize_height = (canvas_height / y_size) - 1;
            
            // take the smaller pixel size, so that the pixels are not too big
            canvas_pixelsize = canvas_pixelsize_width.CompareTo(canvas_pixelsize_height) == 1 ? canvas_pixelsize_height : canvas_pixelsize_width;

            canvas_width = (canvas_pixelsize * x_size) + (x_size - 1);
            canvas_height = (canvas_pixelsize * y_size) + (y_size - 1);

            Size panelSize = new Size(canvas_width, canvas_height);
            canvas.Size = panelSize;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
            redrawPixels();
        }

        private void drawGrid()
        {
            // draw the vertical grid lines
            for (int i = 1; i < x_size; i++)
            {
                graphics.DrawLine(dashedPen, canvas_pixelsize * i + i - 1, 1, canvas_pixelsize * i + i - 1, canvas_height);
            }

            // draw the horizontal grid lines
            for (int i = 1; i < y_size; i++)
            {
                graphics.DrawLine(dashedPen, 1, canvas_pixelsize * i + i - 1, canvas_width, canvas_pixelsize * i + i - 1);
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            DrawPixel(e);
        }

        private void DrawPixel(MouseEventArgs e)
        {
            /*
             * fills the pixel at the position of the mouse cursor
             * draws a rectangle with the calculated pixel size on the canvas
             * additionally, the drawn pixel gets stored in an array to make saving/exporting and redrawing the canvas (after resizing) easier
             */

            x = e.X;
            y = e.Y;

            if(x >= 0 && y >= 0 && x <= canvas_width && y <= canvas_height)
            {
                int selector_X = e.X / (canvas_pixelsize + 1);
                int rectangle_X = selector_X * (canvas_pixelsize + 1);

                int selector_Y = e.Y / (canvas_pixelsize + 1);
                int rectangle_Y = selector_Y * (canvas_pixelsize + 1);

                Color c = new Pen(brush).Color;

                icon[selector_Y, selector_X] = c;

                graphics.FillRectangle(brush, rectangle_X, rectangle_Y, canvas_pixelsize, canvas_pixelsize);
            }
        }

        private void redrawPixels(Color[,] previousIcon = null)
        {
            /*
             * redraws all drawn pixels when the program is resized
             * when the program size changes, the pixel size changes too. So the pixels (displayed by rectangles) have to be drawn again
             */

            Brush redrawBrush;
            Color[,] tmpIcon;
            Color[,] newIcon = new Color[64, 64];
            tmpIcon = icon;

            newIcon = ClearCanvas(newIcon);

            for (int y = 0; y < y_size; y++)
            {
                for (int x = 0; x < x_size; x++)
                {
                    Color c = tmpIcon[y, x];
                    if(c != Color.White)
                    {
                        newIcon[y, x] = c;
                        redrawBrush = new SolidBrush(c);
                        int rectangle_X = x * (canvas_pixelsize + 1);
                        int rectangle_Y = y * (canvas_pixelsize + 1);

                        graphics.FillRectangle(redrawBrush, rectangle_X, rectangle_Y, canvas_pixelsize, canvas_pixelsize);
                    }
                }
            }

            icon = newIcon;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x != -1 && y != -1)
            {
                DrawPixel(e);
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }

        private void btnEraser_click(object sender, EventArgs e)
        {
            brush = (Brush)Brushes.White;
            btnEraser.BackColor = ColorTranslator.FromHtml("#2D9EEF");
            btnPen.BackColor = Color.Transparent;
        }


        private void btnPen_Click(object sender, EventArgs e)
        {
            brush = (Brush)Brushes.Black;
            btnPen.BackColor = ColorTranslator.FromHtml("#2D9EEF");
            btnEraser.BackColor = Color.Transparent;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
             * Converts the current drawing from the drawing-array into a bitmap
             * The bitmap then gets saved as a PNG-image
             */

            Bitmap bm = new Bitmap(x_size, y_size);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                Color c;
                for(int y = 0; y < y_size; y++)
                {
                    for(int x = 0; x < x_size; x++)
                    {
                        c = icon[y, x];
                        using (Pen p = new Pen(c, 1))
                        {
                            gr.DrawRectangle(p, x, y, 1, 1);
                        }
                    }
                }

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = "icon";
                dialog.DefaultExt = ".png";
                dialog.Filter = "Image Files|*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    bm.Save(dialog.FileName, ImageFormat.Png);
                }
            }
        }

        private void btnRefreshSize_Click(object sender, EventArgs e)
        {
            x_size = Convert.ToByte(tbX.Text);
            y_size = Convert.ToByte(tbY.Text);
            CalculatePixels();
            canvas.Invalidate();
        }

        private void IconEditor_Resize(object sender, EventArgs e)
        {
            /*
             * Recalculates the pixel size when the program gets resized
             * Then the canvas gets invalidated (cleared), so the pixels can be redrawn
             */

            int tmp_width = canvas_width;
            int tmp_height = canvas_height;
            CalculatePixels();

            if (tmp_width != canvas_width || tmp_height != canvas_height)
            {
                canvas.Invalidate();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string message = "Do you want to clear the canvas?";
            string caption = "Clear canvas";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, messageBoxIcon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                ClearCanvas();
                canvas.Invalidate();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string caption = "Icon Editor v0.2";
            string message = "The Icon Editor was developed by Daniel Depta for Fachhochschule Erfurt\n\nhttps://github.com/ddepta/iconeditor";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Information;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, messageBoxIcon);
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {
            int input = 0;

            if (int.TryParse(tbX.Text, out input))
            {
                if (input > 0 && input <= max_x_size)
                {
                    if(y_valid)
                    {
                        btnRefreshSize.Enabled = true;
                        lbValidation.Hide();
                    }
                    x_valid = true;
                }
                else
                {
                    btnRefreshSize.Enabled = false;
                    lbValidation.Show();
                    x_valid = false;
                }
            }
            else
            {
                btnRefreshSize.Enabled = false;
                lbValidation.Show();
                x_valid = false;
            }
        }

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            int input = 0;

            if (int.TryParse(tbY.Text, out input))
            {
                if (input > 0 && input <= max_x_size)
                {
                    if (x_valid)
                    {
                        btnRefreshSize.Enabled = true;
                        lbValidation.Hide();
                    }
                    y_valid = true;
                }
                else
                {
                    btnRefreshSize.Enabled = false;
                    lbValidation.Show();
                    y_valid = false;
                }
            }
            else
            {
                btnRefreshSize.Enabled = false;
                lbValidation.Show();
                y_valid = false;
            }
        }
    }
}
