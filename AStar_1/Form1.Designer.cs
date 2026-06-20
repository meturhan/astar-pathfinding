namespace AStar_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tual = new System.Windows.Forms.Panel();
            this.Btn_AStar = new System.Windows.Forms.Button();
            this.Nud_Size = new System.Windows.Forms.NumericUpDown();
            this.Btn_Yenile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Size)).BeginInit();
            this.SuspendLayout();

            // Tual

            this.Tual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tual.Location = new System.Drawing.Point(12, 12);
            this.Tual.Name = "Tual";
            this.Tual.Size = new System.Drawing.Size(500, 500);
            this.Tual.TabIndex = 0;
            this.Tual.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tual_MouseDown);
            this.Tual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tual_MouseDown);

            // Btn_AStar

            this.Btn_AStar.Location = new System.Drawing.Point(518, 12);
            this.Btn_AStar.Name = "Btn_AStar";
            this.Btn_AStar.Size = new System.Drawing.Size(45, 23);
            this.Btn_AStar.TabIndex = 1;
            this.Btn_AStar.Text = "Bul";
            this.Btn_AStar.UseVisualStyleBackColor = true;
            this.Btn_AStar.Click += new System.EventHandler(this.Btn_AStar_Click);

            // Nud_Size

            this.Nud_Size.Location = new System.Drawing.Point(518, 41);
            this.Nud_Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_Size.Name = "Nud_Size";
            this.Nud_Size.Size = new System.Drawing.Size(45, 20);
            this.Nud_Size.TabIndex = 2;
            this.Nud_Size.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Nud_Size.ValueChanged += new System.EventHandler(this.Nud_Size_ValueChanged);

            // Btn_Yenile

            this.Btn_Yenile.Location = new System.Drawing.Point(518, 489);
            this.Btn_Yenile.Name = "Btn_Yenile";
            this.Btn_Yenile.Size = new System.Drawing.Size(45, 23);
            this.Btn_Yenile.TabIndex = 3;
            this.Btn_Yenile.Text = "Yenile";
            this.Btn_Yenile.UseVisualStyleBackColor = true;
            this.Btn_Yenile.Click += new System.EventHandler(this.Btn_Yenile_Click);

            // Form1

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 525);
            this.Controls.Add(this.Btn_Yenile);
            this.Controls.Add(this.Nud_Size);
            this.Controls.Add(this.Btn_AStar);
            this.Controls.Add(this.Tual);
            this.Name = "Form1";
            // ...;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Size)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Tual;
        private System.Windows.Forms.Button Btn_AStar;
        private System.Windows.Forms.NumericUpDown Nud_Size;
        private System.Windows.Forms.Button Btn_Yenile;
    }
}

