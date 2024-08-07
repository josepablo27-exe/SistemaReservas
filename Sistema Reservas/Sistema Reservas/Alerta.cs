using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Reservas
{
    public partial class Alerta : Form
    {
        public Alerta()
        {
            InitializeComponent();
        }

        public Color BackColorAlertBox
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public Color ColorAlertBox
        {
            get {  return LinAlertBox.BackColor; }
            set {  LinAlertBox.BackColor = LblTitleAlertBox.ForeColor = LblTextAlertBox.ForeColor = value; }
        }

        public Image IconAlertBox
        {
            get { return PicAlertBox.Image; }
            set { PicAlertBox.Image = value; }
        }

        public string TitleAlertBox
        {
            get { return LblTitleAlertBox.Text; }
            set { LblTitleAlertBox.Text = value; }
        }

        public string TextAlertBox
        {
            get { return LblTextAlertBox.Text; }
            set { LblTextAlertBox.Text = value; }
        }

        private void PositionAlertBox()
        {
            int xPos = 0; int yPos = 0;
            xPos = Screen.GetWorkingArea(this).Width;
            yPos = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(xPos - this.Width, yPos - this.Height);
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            LinAlertBox.Width += 2;
            if(LinAlertBox.Width == 499)
                this.Close();

        }

        private void Alerta_Load(object sender, EventArgs e)
        {
            PositionAlertBox();
            for (int i = 0; i < 500; i++)
                timerAnimation.Start();
        }
    }
}
