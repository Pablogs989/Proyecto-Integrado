namespace TOP_Manage
{
    partial class FrmAcabarPedido
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
            this.dtgResumen = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCoupon = new System.Windows.Forms.Button();
            this.txtCoupon = new System.Windows.Forms.TextBox();
            this.lblNomCamarero = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumen)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgResumen
            // 
            this.dtgResumen.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dtgResumen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResumen.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(144)))), ((int)(((byte)(169)))));
            this.dtgResumen.Location = new System.Drawing.Point(12, 12);
            this.dtgResumen.Name = "dtgResumen";
            this.dtgResumen.RowHeadersWidth = 51;
            this.dtgResumen.RowTemplate.Height = 24;
            this.dtgResumen.Size = new System.Drawing.Size(1878, 764);
            this.dtgResumen.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic Medium", 19.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(951, 960);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 43);
            this.label2.TabIndex = 9;
            this.label2.Text = "-----------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic Light", 19.2F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(624, 960);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 43);
            this.label1.TabIndex = 8;
            this.label1.Text = "ORDER SUMMARY:";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.BackgroundImage = global::TOP_Manage.Properties.Resources.proximo;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Yu Gothic Light", 22F);
            this.btnVolver.ForeColor = System.Drawing.Color.Red;
            this.btnVolver.Location = new System.Drawing.Point(22, 915);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(89, 88);
            this.btnVolver.TabIndex = 34;
            this.btnVolver.UseCompatibleTextRendering = true;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(164)))), ((int)(((byte)(189)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Yu Gothic Light", 18F);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(1567, 915);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(262, 58);
            this.btnAceptar.TabIndex = 35;
            this.btnAceptar.Text = "ACCEPT";
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // btnCoupon
            // 
            this.btnCoupon.BackColor = System.Drawing.Color.White;
            this.btnCoupon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCoupon.FlatAppearance.BorderSize = 0;
            this.btnCoupon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.btnCoupon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.btnCoupon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoupon.Font = new System.Drawing.Font("Yu Gothic Light", 18F);
            this.btnCoupon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(164)))), ((int)(((byte)(189)))));
            this.btnCoupon.Location = new System.Drawing.Point(950, 846);
            this.btnCoupon.Name = "btnCoupon";
            this.btnCoupon.Size = new System.Drawing.Size(153, 58);
            this.btnCoupon.TabIndex = 36;
            this.btnCoupon.Text = "COUPON";
            this.btnCoupon.UseVisualStyleBackColor = false;
            // 
            // txtCoupon
            // 
            this.txtCoupon.Font = new System.Drawing.Font("Yu Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoupon.Location = new System.Drawing.Point(586, 846);
            this.txtCoupon.Name = "txtCoupon";
            this.txtCoupon.Size = new System.Drawing.Size(344, 56);
            this.txtCoupon.TabIndex = 37;
            this.txtCoupon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNomCamarero
            // 
            this.lblNomCamarero.AutoSize = true;
            this.lblNomCamarero.Font = new System.Drawing.Font("Yu Gothic Light", 15F);
            this.lblNomCamarero.Location = new System.Drawing.Point(1749, 846);
            this.lblNomCamarero.Name = "lblNomCamarero";
            this.lblNomCamarero.Size = new System.Drawing.Size(80, 32);
            this.lblNomCamarero.TabIndex = 38;
            this.lblNomCamarero.Text = "label1";
            this.lblNomCamarero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmAcabarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.lblNomCamarero);
            this.Controls.Add(this.txtCoupon);
            this.Controls.Add(this.btnCoupon);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgResumen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAcabarPedido";
            this.Text = "Form14";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAcabarPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgResumen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCoupon;
        private System.Windows.Forms.TextBox txtCoupon;
        private System.Windows.Forms.Label lblNomCamarero;
    }
}