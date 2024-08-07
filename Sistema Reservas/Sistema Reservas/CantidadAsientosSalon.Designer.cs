namespace Sistema_Reservas
{
    partial class CantidadAsientosSalon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CantidadAsientosSalon));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContinuar = new Sistema_Reservas.Botones.BotonPrimario();
            this.btnAtras = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese la cantidad de asientos";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(125, 178);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 43);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = " ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnContinuar);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(200, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 326);
            this.panel1.TabIndex = 3;
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.Red;
            this.btnContinuar.BackgroundColor = System.Drawing.Color.Red;
            this.btnContinuar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnContinuar.BorderRadius = 40;
            this.btnContinuar.BorderSize = 0;
            this.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinuar.FlatAppearance.BorderSize = 0;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.ForeColor = System.Drawing.Color.White;
            this.btnContinuar.Location = new System.Drawing.Point(199, 258);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(150, 40);
            this.btnContinuar.TabIndex = 4;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextColor = System.Drawing.Color.White;
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.Image = global::Sistema_Reservas.Properties.Resources.Atras;
            this.btnAtras.Location = new System.Drawing.Point(12, 3);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(96, 92);
            this.btnAtras.TabIndex = 4;
            this.btnAtras.TabStop = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // CantidadAsientosSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 625);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CantidadAsientosSalon";
            this.Text = "Ingrese la cantidad de asientos";
            this.Load += new System.EventHandler(this.CantidadAsientosSalon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private Botones.BotonPrimario btnContinuar;
        private System.Windows.Forms.PictureBox btnAtras;
    }
}