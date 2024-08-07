namespace Sistema_Reservas
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoCasa242 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTransmision = new Sistema_Reservas.Botones.PanelInicio();
            this.espaciosTransmision = new System.Windows.Forms.Label();
            this.lblEspaciosTransmision = new System.Windows.Forms.Label();
            this.iconoTransmision = new System.Windows.Forms.PictureBox();
            this.lblTransmision = new System.Windows.Forms.Label();
            this.pnlSalon = new Sistema_Reservas.Botones.PanelInicio();
            this.espaciosSalon = new System.Windows.Forms.Label();
            this.lblEspaciosSalon = new System.Windows.Forms.Label();
            this.lblSalon = new System.Windows.Forms.Label();
            this.iconoSalon = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoCasa242)).BeginInit();
            this.pnlTransmision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoTransmision)).BeginInit();
            this.pnlSalon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoSalon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logoCasa242);
            this.panel1.Controls.Add(this.pnlTransmision);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pnlSalon);
            this.panel1.Location = new System.Drawing.Point(106, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 345);
            this.panel1.TabIndex = 1;
            // 
            // logoCasa242
            // 
            this.logoCasa242.Image = ((System.Drawing.Image)(resources.GetObject("logoCasa242.Image")));
            this.logoCasa242.Location = new System.Drawing.Point(357, 10);
            this.logoCasa242.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoCasa242.Name = "logoCasa242";
            this.logoCasa242.Size = new System.Drawing.Size(89, 40);
            this.logoCasa242.TabIndex = 4;
            this.logoCasa242.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "¡Bienvenidos a Casa 2:42!";
            // 
            // pnlTransmision
            // 
            this.pnlTransmision.BackColor = System.Drawing.Color.White;
            this.pnlTransmision.BackgroundColor = System.Drawing.Color.White;
            this.pnlTransmision.BorderColor = System.Drawing.Color.Red;
            this.pnlTransmision.BorderRadius = 40;
            this.pnlTransmision.BorderSize = 2;
            this.pnlTransmision.Controls.Add(this.espaciosTransmision);
            this.pnlTransmision.Controls.Add(this.lblEspaciosTransmision);
            this.pnlTransmision.Controls.Add(this.iconoTransmision);
            this.pnlTransmision.Controls.Add(this.lblTransmision);
            this.pnlTransmision.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlTransmision.ForeColor = System.Drawing.Color.White;
            this.pnlTransmision.Location = new System.Drawing.Point(281, 78);
            this.pnlTransmision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTransmision.Name = "pnlTransmision";
            this.pnlTransmision.Size = new System.Drawing.Size(156, 218);
            this.pnlTransmision.TabIndex = 3;
            this.pnlTransmision.TextColor = System.Drawing.Color.White;
            this.pnlTransmision.Click += new System.EventHandler(this.pnlTransmision_Click);
            // 
            // espaciosTransmision
            // 
            this.espaciosTransmision.AutoSize = true;
            this.espaciosTransmision.Font = new System.Drawing.Font("Segoe UI Black", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.espaciosTransmision.ForeColor = System.Drawing.Color.Black;
            this.espaciosTransmision.Location = new System.Drawing.Point(103, 169);
            this.espaciosTransmision.Name = "espaciosTransmision";
            this.espaciosTransmision.Size = new System.Drawing.Size(25, 19);
            this.espaciosTransmision.TabIndex = 3;
            this.espaciosTransmision.Text = "30";
            // 
            // lblEspaciosTransmision
            // 
            this.lblEspaciosTransmision.AutoSize = true;
            this.lblEspaciosTransmision.Font = new System.Drawing.Font("Segoe UI Semilight", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspaciosTransmision.ForeColor = System.Drawing.Color.Black;
            this.lblEspaciosTransmision.Location = new System.Drawing.Point(3, 153);
            this.lblEspaciosTransmision.Name = "lblEspaciosTransmision";
            this.lblEspaciosTransmision.Size = new System.Drawing.Size(137, 19);
            this.lblEspaciosTransmision.TabIndex = 2;
            this.lblEspaciosTransmision.Text = "Espacios Disponibles:";
            // 
            // iconoTransmision
            // 
            this.iconoTransmision.Image = global::Sistema_Reservas.Properties.Resources.Transmision;
            this.iconoTransmision.Location = new System.Drawing.Point(25, 25);
            this.iconoTransmision.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconoTransmision.Name = "iconoTransmision";
            this.iconoTransmision.Size = new System.Drawing.Size(89, 40);
            this.iconoTransmision.TabIndex = 1;
            this.iconoTransmision.TabStop = false;
            // 
            // lblTransmision
            // 
            this.lblTransmision.AutoSize = true;
            this.lblTransmision.ForeColor = System.Drawing.Color.Black;
            this.lblTransmision.Location = new System.Drawing.Point(9, 94);
            this.lblTransmision.Name = "lblTransmision";
            this.lblTransmision.Size = new System.Drawing.Size(127, 16);
            this.lblTransmision.TabIndex = 0;
            this.lblTransmision.Text = "Transmisión en vivo";
            // 
            // pnlSalon
            // 
            this.pnlSalon.BackColor = System.Drawing.Color.White;
            this.pnlSalon.BackgroundColor = System.Drawing.Color.White;
            this.pnlSalon.BorderColor = System.Drawing.Color.Red;
            this.pnlSalon.BorderRadius = 40;
            this.pnlSalon.BorderSize = 2;
            this.pnlSalon.Controls.Add(this.espaciosSalon);
            this.pnlSalon.Controls.Add(this.lblEspaciosSalon);
            this.pnlSalon.Controls.Add(this.lblSalon);
            this.pnlSalon.Controls.Add(this.iconoSalon);
            this.pnlSalon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSalon.ForeColor = System.Drawing.Color.White;
            this.pnlSalon.Location = new System.Drawing.Point(28, 78);
            this.pnlSalon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSalon.Name = "pnlSalon";
            this.pnlSalon.Size = new System.Drawing.Size(156, 226);
            this.pnlSalon.TabIndex = 2;
            this.pnlSalon.TextColor = System.Drawing.Color.White;
            this.pnlSalon.Click += new System.EventHandler(this.pnlSalon_Click);
            // 
            // espaciosSalon
            // 
            this.espaciosSalon.AutoSize = true;
            this.espaciosSalon.Font = new System.Drawing.Font("Segoe UI Black", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.espaciosSalon.ForeColor = System.Drawing.Color.Black;
            this.espaciosSalon.Location = new System.Drawing.Point(108, 162);
            this.espaciosSalon.Name = "espaciosSalon";
            this.espaciosSalon.Size = new System.Drawing.Size(33, 19);
            this.espaciosSalon.TabIndex = 4;
            this.espaciosSalon.Text = "250";
            // 
            // lblEspaciosSalon
            // 
            this.lblEspaciosSalon.AutoSize = true;
            this.lblEspaciosSalon.Font = new System.Drawing.Font("Segoe UI Semilight", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspaciosSalon.ForeColor = System.Drawing.Color.Black;
            this.lblEspaciosSalon.Location = new System.Drawing.Point(11, 145);
            this.lblEspaciosSalon.Name = "lblEspaciosSalon";
            this.lblEspaciosSalon.Size = new System.Drawing.Size(137, 19);
            this.lblEspaciosSalon.TabIndex = 1;
            this.lblEspaciosSalon.Text = "Espacios Disponibles:";
            // 
            // lblSalon
            // 
            this.lblSalon.AutoSize = true;
            this.lblSalon.ForeColor = System.Drawing.Color.Black;
            this.lblSalon.Location = new System.Drawing.Point(28, 94);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new System.Drawing.Size(97, 16);
            this.lblSalon.TabIndex = 0;
            this.lblSalon.Text = "Salón Principal";
            // 
            // iconoSalon
            // 
            this.iconoSalon.Image = ((System.Drawing.Image)(resources.GetObject("iconoSalon.Image")));
            this.iconoSalon.Location = new System.Drawing.Point(32, 25);
            this.iconoSalon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconoSalon.Name = "iconoSalon";
            this.iconoSalon.Size = new System.Drawing.Size(89, 40);
            this.iconoSalon.TabIndex = 2;
            this.iconoSalon.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.Text = "¡Bienvenidos a Casa 2:42!";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoCasa242)).EndInit();
            this.pnlTransmision.ResumeLayout(false);
            this.pnlTransmision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoTransmision)).EndInit();
            this.pnlSalon.ResumeLayout(false);
            this.pnlSalon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoSalon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTransmision;
        private System.Windows.Forms.Label lblEspaciosSalon;
        private System.Windows.Forms.Label lblSalon;
        private Botones.PanelInicio pnlSalon;
        private System.Windows.Forms.PictureBox iconoSalon;
        private Botones.PanelInicio pnlTransmision;
        private System.Windows.Forms.PictureBox iconoTransmision;
        private System.Windows.Forms.Label espaciosSalon;
        private System.Windows.Forms.Label espaciosTransmision;
        private System.Windows.Forms.Label lblEspaciosTransmision;
        private System.Windows.Forms.PictureBox logoCasa242;
    }
}

