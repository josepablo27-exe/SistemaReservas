namespace Sistema_Reservas
{
    partial class PantallaCarga
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
            this.imgCarga = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCarga
            // 
            this.imgCarga.Location = new System.Drawing.Point(252, 120);
            this.imgCarga.Name = "imgCarga";
            this.imgCarga.Size = new System.Drawing.Size(259, 210);
            this.imgCarga.TabIndex = 0;
            this.imgCarga.TabStop = false;
            // 
            // PantallaCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.imgCarga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PantallaCarga";
            this.Opacity = 0.7D;
            this.Text = "PantallaCarga";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PantallaCarga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCarga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCarga;
    }
}