﻿using System;
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
        Pen pen;
        Brush brush = (Brush)Brushes.Black;
        int zoom = 1;
        bool initialized = false;
        Bitmap bmp;

        Color[,] icon = new Color[64, 64];
        Color[,] redoState = new Color[64, 64];
        string[,] fuckoff = new string[64, 64];

        List<Color[,]> history = new List<Color[,]>();
        int historyPosition = 0;

        List<string[,]> fuckoff_history = new List<string[,]>();

        public IconEditor()
        {
            InitializeComponent();

            tbX.Text = x_size.ToString();
            tbY.Text = y_size.ToString();

            graphics = canvas.CreateGraphics();
            pen = new Pen(Color.Black, 1);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
            bmp = new Bitmap(canvas.ClientSize.Width, canvas.ClientSize.Height);

            ClearCanvas();
            Color[,] _icon = (Color[,])icon.Clone();
            history.Add(_icon);
            CalculatePixels();
            drawGrid();
        }

        private void ClearCanvas()
        {
            for (int i = 0; i < max_x_size; i++)
            {
                for (int k = 0; k < max_y_size; k++)
                {
                    icon[i, k] = Color.White;
                    redoState[i, k] = Color.White;
                    //icon[i, k] = Color.White.R
                }
            }
        }

        private void CalculatePixels()
        {
            canvas_width = Size.Width - 40;
            canvas_height = Size.Height - 107;
            int canvas_pixelsize_width = (canvas_width / x_size) - 1;
            int canvas_pixelsize_height = (canvas_height / y_size) - 1;
            
            canvas_pixelsize = canvas_pixelsize_width.CompareTo(canvas_pixelsize_height) == 1 ? canvas_pixelsize_height : canvas_pixelsize_width;

            canvas_width = (canvas_pixelsize * x_size) + (x_size - 1);
            canvas_height = (canvas_pixelsize * y_size) + (y_size - 1);

            Size panelSize = new Size(canvas_width, canvas_height);
            canvas.Size = panelSize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
            redrawPixels();
            //e.Graphics.DrawImage(bmp, Point.Empty);
        }

        private void drawGrid()
        {
            Pen dashedPen = new Pen(Color.Pink, 1);
            dashedPen.DashCap = System.Drawing.Drawing2D.DashCap.Flat;
            dashedPen.DashOffset = 50;
            dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            for (int i = 1; i < x_size; i++)
            {
                graphics.DrawLine(dashedPen, canvas_pixelsize * i + i - 1, 1, canvas_pixelsize * i + i - 1, canvas_height);
            }

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
            x = e.X;
            y = e.Y;
            //TODO: negative selectoren abfangen
            //also zu kleine und zu große (über 800px)

            int selector_X = e.X / (canvas_pixelsize + 1);
            int rectangle_X = selector_X * (canvas_pixelsize + 1);

            int selector_Y = e.Y / (canvas_pixelsize + 1);
            int rectangle_Y = selector_Y * (canvas_pixelsize + 1);

            Color c = new Pen(brush).Color;

            icon[selector_Y, selector_X] = c;
            Array.Clear(redoState, 0, redoState.Length);
            redoState[selector_Y, selector_X] = c;
            
            graphics.FillRectangle(brush, rectangle_X, rectangle_Y, canvas_pixelsize, canvas_pixelsize);
        }

        private void redrawPixels(Color[,] previousIcon = null)
        {
            Brush redrawBrush;
            Color[,] tmpIcon;

                tmpIcon = icon;

            for (int y = 0; y < y_size; y++)
            {
                for (int x = 0; x < x_size; x++)
                {
                    Color c = tmpIcon[y, x];
                    if(c != Color.White)
                    {
                        redrawBrush = new SolidBrush(c);
                        int rectangle_X = x * (canvas_pixelsize + 1);
                        int rectangle_Y = y * (canvas_pixelsize + 1);

                        graphics.FillRectangle(redrawBrush, rectangle_X, rectangle_Y, canvas_pixelsize, canvas_pixelsize);
                    }
                }
            }
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
            //drawGrid();
            Color[,] _icon = new Color[64,64];
            for(int y = 0; y < max_y_size; y++)
            {
                for (int x = 0; x < max_x_size; x++)
                {
                    string redHex = ColorTranslator.ToHtml(icon[y, x]);
                    _icon[y, x] = ColorTranslator.FromHtml(redHex);
                }
            }


            var tmphistory = history;

            if (historyPosition + 1 < history.Count)
            {
                history.RemoveRange(historyPosition, history.Count - (historyPosition));
                Color[,] newIcon = new Color[64,64];
                for(int y = 0; y < max_y_size; y++)
                {
                    for (int x = 0; x < max_x_size; x++)
                    {
                        if(icon[y, x] == redoState[y, x])
                        {
                            newIcon[y, x] = history[historyPosition - 1][y, x];
                        }
                        else
                        {
                            newIcon[y, x] = icon[y, x];
                        }
                    }
                }
                history.Add(newIcon);
                history.Add(icon);
                historyPosition =history.Count() - 1;

            }
            else
            {
                history.Add(_icon);
                historyPosition++;
            }

            ToggleUndoRedoButtons();
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
            Bitmap bm = new Bitmap(10, 10);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                Color c;
                for(int y = 0; y < 10; y++)
                {
                    for(int x = 0; x < 10; x++)
                    {
                        c = icon[y, x];
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

        private void BildToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CanvasSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnRefreshSize_Click(object sender, EventArgs e)
        {
            string message = "You'll lose the undo-history, do you want to continue?";
            string caption = "Resize canvas";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, messageBoxIcon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                x_size = Convert.ToByte(tbX.Text);
                y_size = Convert.ToByte(tbY.Text);
                CalculatePixels();
                canvas.Invalidate();
            }
        }

        private void IconEditor_ResizeEnd(object sender, EventArgs e)
        {
            /*
            int tmp_width = canvas_width;
            int tmp_height = canvas_height;
            CalculatePixels();

            if(tmp_width != canvas_width || tmp_height != canvas_height)
            {
                canvas.Invalidate();
            }
            */
        }

        private void IconEditor_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void IconEditor_Resize(object sender, EventArgs e)
        {
            int tmp_width = canvas_width;
            int tmp_height = canvas_height;
            CalculatePixels();

            if (tmp_width != canvas_width || tmp_height != canvas_height)
            {
                canvas.Invalidate();
            }

        }

        private void ToggleUndoRedoButtons()
        {
            btnUndo.Enabled = historyPosition != 0;
            btnRedo.Enabled = historyPosition + 1 < history.Count;
        }

        private void BtnClear_Click(object sender, EventArgs e)
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

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if(historyPosition > 0)
            {
                historyPosition--;
                icon = history[historyPosition];
                canvas.Invalidate();
                redrawPixels();
            }

            bool activateRedoButton = true;
            ToggleUndoRedoButtons();
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            if(historyPosition < history.Count)
            {
                historyPosition++;
                icon = history[historyPosition];
                canvas.Invalidate();
                redrawPixels();
            }
            ToggleUndoRedoButtons();

        }
    }
}
