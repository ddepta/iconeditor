namespace iconeditor
{
    partial class IconEditor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.Panel();
            this.black = new System.Windows.Forms.Button();
            this.eraser = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.lbX = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.lbPixel1 = new System.Windows.Forms.Label();
            this.lbPx2 = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.lbY = new System.Windows.Forms.Label();
            this.btnRefreshSize = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(12, 56);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(800, 800);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // black
            // 
            this.black.BackColor = System.Drawing.Color.Black;
            this.black.Location = new System.Drawing.Point(158, 27);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(23, 23);
            this.black.TabIndex = 4;
            this.black.UseVisualStyleBackColor = false;
            this.black.Click += new System.EventHandler(this.Black_Click);
            // 
            // eraser
            // 
            this.eraser.Location = new System.Drawing.Point(96, 27);
            this.eraser.Name = "eraser";
            this.eraser.Size = new System.Drawing.Size(56, 23);
            this.eraser.TabIndex = 3;
            this.eraser.Text = "Eraser";
            this.eraser.UseVisualStyleBackColor = true;
            this.eraser.Click += new System.EventHandler(this.Eraser_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(747, 27);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(23, 23);
            this.btnPlus.TabIndex = 2;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.BtnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(717, 27);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(23, 23);
            this.btnMinus.TabIndex = 1;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.BtnMinus_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem1,
            this.bildToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(824, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // dateiToolStripMenuItem1
            // 
            this.dateiToolStripMenuItem1.Name = "dateiToolStripMenuItem1";
            this.dateiToolStripMenuItem1.Size = new System.Drawing.Size(42, 20);
            this.dateiToolStripMenuItem1.Text = "Files";
            // 
            // bildToolStripMenuItem
            // 
            this.bildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripTextBox2});
            this.bildToolStripMenuItem.Name = "bildToolStripMenuItem";
            this.bildToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bildToolStripMenuItem.Text = "Image Size";
            this.bildToolStripMenuItem.Click += new System.EventHandler(this.BildToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(187, 27);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(23, 23);
            this.btnRed.TabIndex = 6;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.BtnRed_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(595, 27);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(41, 23);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.Text = "undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(642, 27);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(48, 23);
            this.btnRedo.TabIndex = 8;
            this.btnRedo.Text = "redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(248, 32);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(17, 13);
            this.lbX.TabIndex = 9;
            this.lbX.Text = "X:";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(271, 29);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(20, 20);
            this.tbX.TabIndex = 10;
            // 
            // lbPixel1
            // 
            this.lbPixel1.AutoSize = true;
            this.lbPixel1.Location = new System.Drawing.Point(297, 33);
            this.lbPixel1.Name = "lbPixel1";
            this.lbPixel1.Size = new System.Drawing.Size(18, 13);
            this.lbPixel1.TabIndex = 11;
            this.lbPixel1.Text = "px";
            // 
            // lbPx2
            // 
            this.lbPx2.AutoSize = true;
            this.lbPx2.Location = new System.Drawing.Point(386, 33);
            this.lbPx2.Name = "lbPx2";
            this.lbPx2.Size = new System.Drawing.Size(18, 13);
            this.lbPx2.TabIndex = 14;
            this.lbPx2.Text = "px";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(360, 30);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(20, 20);
            this.tbY.TabIndex = 13;
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(337, 32);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(17, 13);
            this.lbY.TabIndex = 12;
            this.lbY.Text = "Y:";
            // 
            // btnRefreshSize
            // 
            this.btnRefreshSize.Location = new System.Drawing.Point(423, 28);
            this.btnRefreshSize.Name = "btnRefreshSize";
            this.btnRefreshSize.Size = new System.Drawing.Size(56, 23);
            this.btnRefreshSize.TabIndex = 15;
            this.btnRefreshSize.Text = "Refresh";
            this.btnRefreshSize.UseVisualStyleBackColor = true;
            this.btnRefreshSize.Click += new System.EventHandler(this.BtnRefreshSize_Click);
            // 
            // IconEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 868);
            this.Controls.Add(this.btnRefreshSize);
            this.Controls.Add(this.lbPx2);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.lbY);
            this.Controls.Add(this.lbPixel1);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.lbX);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.black);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.eraser);
            this.Controls.Add(this.menuStrip2);
            this.Name = "IconEditor";
            this.Text = "Icon-Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button eraser;
        private System.Windows.Forms.Button black;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.ToolStripMenuItem bildToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label lbPixel1;
        private System.Windows.Forms.Label lbPx2;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.Button btnRefreshSize;
    }
}

