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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IconEditor));
            this.canvas = new System.Windows.Forms.Panel();
            this.btnPen = new System.Windows.Forms.Button();
            this.btnEraser = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbX = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.lbPixel1 = new System.Windows.Forms.Label();
            this.lbPx2 = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.lbY = new System.Windows.Forms.Label();
            this.btnRefreshSize = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbDivider = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lbValidation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canvas.Location = new System.Drawing.Point(12, 34);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(4000, 4000);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // btnPen
            // 
            this.btnPen.BackColor = System.Drawing.Color.Transparent;
            this.btnPen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPen.BackgroundImage")));
            this.btnPen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPen.FlatAppearance.BorderSize = 0;
            this.btnPen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(195)))), ((int)(((byte)(242)))));
            this.btnPen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.btnPen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPen.Location = new System.Drawing.Point(64, 5);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(23, 23);
            this.btnPen.TabIndex = 4;
            this.btnPen.UseVisualStyleBackColor = false;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnEraser
            // 
            this.btnEraser.BackColor = System.Drawing.Color.Transparent;
            this.btnEraser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEraser.BackgroundImage")));
            this.btnEraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEraser.FlatAppearance.BorderSize = 0;
            this.btnEraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(195)))), ((int)(((byte)(242)))));
            this.btnEraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.btnEraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEraser.Location = new System.Drawing.Point(90, 5);
            this.btnEraser.Name = "btnEraser";
            this.btnEraser.Size = new System.Drawing.Size(23, 23);
            this.btnEraser.TabIndex = 3;
            this.btnEraser.UseVisualStyleBackColor = false;
            this.btnEraser.Click += new System.EventHandler(this.btnEraser_click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(195)))), ((int)(((byte)(242)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(12, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(137, 10);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(17, 13);
            this.lbX.TabIndex = 9;
            this.lbX.Text = "X:";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(156, 6);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(20, 20);
            this.tbX.TabIndex = 5;
            this.tbX.TextChanged += new System.EventHandler(this.tbX_TextChanged);
            // 
            // lbPixel1
            // 
            this.lbPixel1.AutoSize = true;
            this.lbPixel1.Location = new System.Drawing.Point(178, 10);
            this.lbPixel1.Name = "lbPixel1";
            this.lbPixel1.Size = new System.Drawing.Size(18, 13);
            this.lbPixel1.TabIndex = 11;
            this.lbPixel1.Text = "px";
            // 
            // lbPx2
            // 
            this.lbPx2.AutoSize = true;
            this.lbPx2.Location = new System.Drawing.Point(248, 10);
            this.lbPx2.Name = "lbPx2";
            this.lbPx2.Size = new System.Drawing.Size(18, 13);
            this.lbPx2.TabIndex = 14;
            this.lbPx2.Text = "px";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(226, 6);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(20, 20);
            this.tbY.TabIndex = 6;
            this.tbY.TextChanged += new System.EventHandler(this.tbY_TextChanged);
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(207, 10);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(17, 13);
            this.lbY.TabIndex = 12;
            this.lbY.Text = "Y:";
            // 
            // btnRefreshSize
            // 
            this.btnRefreshSize.Location = new System.Drawing.Point(275, 5);
            this.btnRefreshSize.Name = "btnRefreshSize";
            this.btnRefreshSize.Size = new System.Drawing.Size(56, 23);
            this.btnRefreshSize.TabIndex = 7;
            this.btnRefreshSize.Text = "Resize";
            this.btnRefreshSize.UseVisualStyleBackColor = true;
            this.btnRefreshSize.Click += new System.EventHandler(this.btnRefreshSize_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(195)))), ((int)(((byte)(242)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(38, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(23, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbDivider
            // 
            this.lbDivider.AutoSize = true;
            this.lbDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbDivider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbDivider.Location = new System.Drawing.Point(124, 9);
            this.lbDivider.Name = "lbDivider";
            this.lbDivider.Size = new System.Drawing.Size(2, 15);
            this.lbDivider.TabIndex = 17;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.BackgroundImage")));
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(195)))), ((int)(((byte)(242)))));
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(789, 5);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 23);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lbValidation
            // 
            this.lbValidation.AutoSize = true;
            this.lbValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValidation.ForeColor = System.Drawing.Color.Red;
            this.lbValidation.Location = new System.Drawing.Point(337, 10);
            this.lbValidation.Name = "lbValidation";
            this.lbValidation.Size = new System.Drawing.Size(198, 13);
            this.lbValidation.TabIndex = 18;
            this.lbValidation.Text = "Please enter numbers between 1 and 64";
            // 
            // IconEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 849);
            this.Controls.Add(this.btnEraser);
            this.Controls.Add(this.lbValidation);
            this.Controls.Add(this.lbDivider);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRefreshSize);
            this.Controls.Add(this.lbPx2);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.lbY);
            this.Controls.Add(this.lbPixel1);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.lbX);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPen);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.btnHelp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "IconEditor";
            this.Text = "Icon Editor";
            this.Resize += new System.EventHandler(this.IconEditor_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Button btnEraser;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label lbPixel1;
        private System.Windows.Forms.Label lbPx2;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.Button btnRefreshSize;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbDivider;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lbValidation;
    }
}

