namespace Sistema_Reservas
{
    partial class NumeroTelefonicoSalon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumeroTelefonicoSalon));
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinalizar = new Sistema_Reservas.Botones.BotonPrimario();
            this.btnCancelar = new Sistema_Reservas.Botones.BotonPrimario();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.asientos = new System.Windows.Forms.Label();
            this.lblAsientos = new System.Windows.Forms.Label();
            this.cantidad = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese su número telefónico para enviarle una confirmación";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(49, 124);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(137, 16);
            this.lblCantidad.TabIndex = 1;
            this.lblCantidad.Text = "Cantidad de asientos:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFinalizar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.asientos);
            this.panel1.Controls.Add(this.lblAsientos);
            this.panel1.Controls.Add(this.cantidad);
            this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(231, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 331);
            this.panel1.TabIndex = 0;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnFinalizar.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnFinalizar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFinalizar.BorderRadius = 40;
            this.btnFinalizar.BorderSize = 0;
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.FlatAppearance.BorderSize = 0;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(298, 251);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(150, 40);
            this.btnFinalizar.TabIndex = 9;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.TextColor = System.Drawing.Color.White;
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.White;
            this.btnCancelar.BorderColor = System.Drawing.Color.Red;
            this.btnCancelar.BorderRadius = 40;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(68, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 40);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.Red;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(195, 200);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // asientos
            // 
            this.asientos.AutoSize = true;
            this.asientos.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asientos.Location = new System.Drawing.Point(379, 125);
            this.asientos.Name = "asientos";
            this.asientos.Size = new System.Drawing.Size(78, 17);
            this.asientos.TabIndex = 4;
            this.asientos.Text = "A1 A2 A3 A4";
            // 
            // lblAsientos
            // 
            this.lblAsientos.AutoSize = true;
            this.lblAsientos.Location = new System.Drawing.Point(295, 125);
            this.lblAsientos.Name = "lblAsientos";
            this.lblAsientos.Size = new System.Drawing.Size(62, 16);
            this.lblAsientos.TabIndex = 3;
            this.lblAsientos.Text = "Asientos:";
            // 
            // cantidad
            // 
            this.cantidad.AutoSize = true;
            this.cantidad.Font = new System.Drawing.Font("Segoe UI Semilight", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidad.Location = new System.Drawing.Point(192, 124);
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(42, 17);
            this.cantidad.TabIndex = 2;
            this.cantidad.Text = "label3";
            // 
            // NumeroTelefonicoSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 555);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NumeroTelefonicoSalon";
            this.Text = "Ingrese su número telefónico";
            this.Load += new System.EventHandler(this.NumeroTelefonicoSalon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label cantidad;
        private System.Windows.Forms.Label lblAsientos;
        private System.Windows.Forms.Label asientos;
        private System.Windows.Forms.TextBox textBox1;
        private Botones.BotonPrimario btnFinalizar;
        private Botones.BotonPrimario btnCancelar;
    }
}