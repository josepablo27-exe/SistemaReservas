﻿namespace Sistema_Reservas
{
    partial class Alerta
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
            this.components = new System.ComponentModel.Container();
            this.PicAlertBox = new System.Windows.Forms.PictureBox();
            this.LblTitleAlertBox = new System.Windows.Forms.Label();
            this.LblTextAlertBox = new System.Windows.Forms.Label();
            this.LinAlertBox = new System.Windows.Forms.Panel();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PicAlertBox
            // 
            this.PicAlertBox.Location = new System.Drawing.Point(26, 15);
            this.PicAlertBox.Name = "PicAlertBox";
            this.PicAlertBox.Size = new System.Drawing.Size(50, 50);
            this.PicAlertBox.TabIndex = 0;
            this.PicAlertBox.TabStop = false;
            // 
            // LblTitleAlertBox
            // 
            this.LblTitleAlertBox.AutoSize = true;
            this.LblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.LblTitleAlertBox.Location = new System.Drawing.Point(89, 14);
            this.LblTitleAlertBox.Name = "LblTitleAlertBox";
            this.LblTitleAlertBox.Size = new System.Drawing.Size(170, 32);
            this.LblTitleAlertBox.TabIndex = 1;
            this.LblTitleAlertBox.Text = "TitleAlertBox";
            // 
            // LblTextAlertBox
            // 
            this.LblTextAlertBox.AutoSize = true;
            this.LblTextAlertBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTextAlertBox.Location = new System.Drawing.Point(94, 42);
            this.LblTextAlertBox.Name = "LblTextAlertBox";
            this.LblTextAlertBox.Size = new System.Drawing.Size(128, 23);
            this.LblTextAlertBox.TabIndex = 2;
            this.LblTextAlertBox.Text = "TextAlertBox";
            // 
            // LinAlertBox
            // 
            this.LinAlertBox.BackColor = System.Drawing.Color.Black;
            this.LinAlertBox.Location = new System.Drawing.Point(0, 74);
            this.LinAlertBox.Name = "LinAlertBox";
            this.LinAlertBox.Size = new System.Drawing.Size(5, 6);
            this.LinAlertBox.TabIndex = 3;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 10;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // Alerta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 80);
            this.Controls.Add(this.LinAlertBox);
            this.Controls.Add(this.LblTextAlertBox);
            this.Controls.Add(this.LblTitleAlertBox);
            this.Controls.Add(this.PicAlertBox);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Alerta";
            this.Text = "AlertaCantidadEspacios";
            this.Load += new System.EventHandler(this.Alerta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicAlertBox;
        private System.Windows.Forms.Label LblTitleAlertBox;
        private System.Windows.Forms.Label LblTextAlertBox;
        private System.Windows.Forms.Panel LinAlertBox;
        private System.Windows.Forms.Timer timerAnimation;
    }
}