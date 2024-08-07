using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Reservas
{
    public partial class PantallaCarga : Form
    {
        public PantallaCarga()
        {
            InitializeComponent();
        }

        private void PantallaCarga_Load(object sender, EventArgs e)
        {
            imgCarga.Load("Carga.gif");
            imgCarga.Location = new Point(this.Width / 2 - imgCarga.Width / 2, this.Height / 2 - imgCarga.Height / 2);
;        }
    }
}
