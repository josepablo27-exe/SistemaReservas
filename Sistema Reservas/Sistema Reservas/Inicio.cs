using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sistema_Reservas.Botones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Reservas
{
    public partial class Inicio : Form
    {
        private readonly IConfiguration _configuration;

        public Inicio(IConfiguration configuration)
        {
            InitializeComponent();
            _configuration = configuration;
        }

        //Color para los bordes de los paneles
        Color color = ColorTranslator.FromHtml("#ED4F49");

        // Instancia del caudro de alerta
        void CuadroAlerta(Color backColor, Color color, string title, string text, Image icon)
        {
            Alerta alerta = new Alerta();
            alerta.BackColor = backColor;
            alerta.ColorAlertBox = color;
            alerta.TitleAlertBox = title;
            alerta.TextAlertBox = text;
            alerta.IconAlertBox = icon;
            alerta.ShowDialog();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            int ancho_pantalla = Screen.PrimaryScreen.WorkingArea.Width;
            int alto_pantalla = Screen.PrimaryScreen.WorkingArea.Height;

            /* Inicio Panel 1 */

            int ancho_panel1 = (int)Math.Round(ancho_pantalla * 0.98);
            int alto_panel1 = (int)Math.Round(alto_pantalla * 0.95);
            panel1.Size = new Size(ancho_panel1, alto_panel1);
            int x_panel1 = (ancho_pantalla - ancho_panel1) / 2;
            int y_panel1 = (alto_pantalla - alto_panel1) / 2;
            panel1.Location = new Point(x_panel1, y_panel1);

            /* Fin Panel 1 */

            /* Inicio Label 1 */

            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font(label1.Font.FontFamily, 34, FontStyle.Regular);
            int x_label1 = (ancho_panel1 - label1.Size.Width) / 2;
            label1.Location = new Point(x_label1, 20);

            /* Fin Label 1 */

            /* Inicio logoCasa242 */

            int ancho_logoCasa242 = 350;
            int alto_logoCasa242 = 70;
            logoCasa242.Size = new Size(ancho_logoCasa242, alto_logoCasa242);
            int x_logoCasa242 = ancho_panel1 - ancho_logoCasa242;
            int y_logoCasa242 = 0;
            logoCasa242.Location = new Point(x_logoCasa242, y_logoCasa242);

            /* Fin logoCasa242 */

            /* Inicio pnlSalon */

            int ancho_pnlSalon = (int)Math.Round(ancho_panel1 * 0.40);
            int alto_pnlSalon = (int)Math.Round(alto_panel1 * 0.70);
            pnlSalon.Size = new Size(ancho_pnlSalon, alto_pnlSalon);
            int x_pnlSalon = (int)Math.Round(ancho_panel1 * 0.07);
            int y_pnlSalon = (int)Math.Round(alto_panel1 * 0.20);
            pnlSalon.Location = new Point(x_pnlSalon, y_pnlSalon);
            pnlSalon.BorderColor = color;

            /* Fin pnlSalon */

            /* Inicio pnlTransmision */

            int ancho_pnlTransmision = (int)Math.Round(ancho_panel1 * 0.40);
            int alto_pnlTransmision = (int)Math.Round(alto_panel1 * 0.70);
            pnlTransmision.Size = new Size(ancho_pnlTransmision, alto_pnlTransmision);
            int x_pnlTransmision = (int)Math.Round(ancho_panel1 * 0.53);
            int y_pnlTransmision = (int)Math.Round(alto_panel1 * 0.20);
            pnlTransmision.Location = new Point(x_pnlTransmision, y_pnlTransmision);
            pnlTransmision.BorderColor = color;

            /* Fin pnlTransmision */

            /* Inicio iconoSalon */

            int ancho_iconoSalon = 172;
            int alto_iconoSalon = 192;
            iconoSalon.Size = new Size(ancho_iconoSalon, alto_iconoSalon);
            int x_iconoSalon = (ancho_pnlSalon - ancho_iconoSalon) / 2;
            iconoSalon.Location = new Point(x_iconoSalon, 50);

            /* Fin iconoSalon */

            /* Inicio iconoTransmision */

            int ancho_iconoTransmision = 192;
            int alto_iconoTransmision = 192;
            iconoTransmision.Size = new Size(ancho_iconoTransmision, alto_iconoTransmision);
            int x_iconoTransmision = (ancho_pnlTransmision - ancho_iconoTransmision) / 2;
            iconoTransmision.Location = new Point(x_iconoTransmision, 50);

            /* Fin iconoTransmision */

            /* Inicio lblSalon */

            lblSalon.TextAlign = ContentAlignment.MiddleCenter;
            lblSalon.Font = new Font(lblSalon.Font.FontFamily, 30, FontStyle.Regular);
            int x_lblSalon = (ancho_pnlSalon - lblSalon.Size.Width) / 2;
            int y_lblSalon = (int)Math.Round(alto_pnlSalon * 0.60);
            lblSalon.Location = new Point(x_lblSalon, y_lblSalon);

            /* Fin lblSalon */

            /* Inicio lblTransmision */

            lblTransmision.TextAlign = ContentAlignment.MiddleCenter;
            lblTransmision.Font = new Font(lblTransmision.Font.FontFamily, 30, FontStyle.Regular);
            int x_lblTransmision = (ancho_pnlTransmision - lblTransmision.Size.Width) / 2;
            int y_lblTransmision = (int)Math.Round(alto_pnlTransmision * 0.60);
            lblTransmision.Location = new Point(x_lblTransmision, y_lblTransmision);

            /* Fin lblTransmision */

            /* Inicio lblEspaciosSalon */

            lblEspaciosSalon.TextAlign = ContentAlignment.MiddleCenter;
            lblEspaciosSalon.Font = new Font(lblEspaciosSalon.Font.FontFamily, 26);
            int x_lblEspacios = (int)Math.Round(ancho_pnlSalon * 0.08);
            int y_lblEspacios = (int)Math.Round(alto_pnlSalon * 0.82);
            lblEspaciosSalon.Location = new Point(x_lblEspacios, y_lblEspacios);

            /* Fin lblEspaciosSalon */

            /* Inicio espaciosSalon */

            espaciosSalon.TextAlign = ContentAlignment.MiddleCenter;
            espaciosSalon.Font = new Font(espaciosSalon.Font.FontFamily, 26);
            int x_espaciosSalon = (int)Math.Round(ancho_pnlSalon * 0.72);
            int y_espaciosSalon = (int)Math.Round(alto_pnlSalon * 0.82);
            espaciosSalon.Location = new Point(x_espaciosSalon, y_espaciosSalon);

            //Contar los espacios disponibles en el salón principal
            EspaciosDisponiblesSalon();

            /* Fin espaciosSalon */

            /* Inicio lblEspaciosTransmision */

            lblEspaciosTransmision.TextAlign = ContentAlignment.MiddleCenter;
            lblEspaciosTransmision.Font = new Font(lblEspaciosTransmision.Font.FontFamily, 26);
            int x_lblEspaciosTransmision = (int)Math.Round(ancho_pnlTransmision * 0.08);
            int y_lblEspaciosTransmision = (int)Math.Round(alto_pnlTransmision * 0.82);
            lblEspaciosTransmision.Location = new Point(x_lblEspaciosTransmision, y_lblEspaciosTransmision);

            /* Fin lblEspaciosTransmision */

            /* Inicio espaciosTransmision */

            espaciosTransmision.TextAlign = ContentAlignment.MiddleCenter;
            espaciosTransmision.Font = new Font(espaciosTransmision.Font.FontFamily, 26);
            int x_espaciosTransmision = (int)Math.Round(ancho_pnlTransmision * 0.73);
            int y_espaciosTransmision = (int)Math.Round(alto_pnlTransmision * 0.82);
            espaciosTransmision.Location = new Point(x_espaciosTransmision, y_espaciosTransmision);

            //Contar los espacios disponibles en transmisión en vivo
            EspaciosDisponiblesTransmision();

            /* Fin espaciosTransmision */
        }

        // Contar los espacios disponibles en el salón principal
        private void EspaciosDisponiblesSalon()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT COUNT(*) AS total_disponibles FROM ASIENTOS_SALON WHERE CATEGORIA IN ('Disponible', 'Coches', 'A/C') AND RESERVADO = 0";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int resultado = reader.GetInt32(0);
                            espaciosSalon.Text = resultado.ToString();
                        }
                    }
                }
                catch (MySqlException)
                {
                    CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Error con la conexión a la base de datos", Properties.Resources.Error);
                    espaciosSalon.Text = "Error";
                }
                
            }
        }

        // Contar los espacios disponibles en transmisión en vivo
        private void EspaciosDisponiblesTransmision()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT COUNT(*) AS total_disponibles FROM ASIENTOS_TRANSMISION WHERE CATEGORIA = 'Disponible' AND RESERVADO = 0";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                try
                {
                    conexion.Open();

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int resultado = reader.GetInt32(0);
                            espaciosTransmision.Text = resultado.ToString();
                        }
                    }
                }
                catch (MySqlException)
                {
                    CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Error con la conexión a la base de datos", Properties.Resources.Error);
                    espaciosTransmision.Text = "Error";
                }
            }
        }

        // Seleccionar la opción de salón principal
        private void pnlSalon_Click(object sender, EventArgs e)
        {
            CantidadAsientosSalon cantidadAsientosSalon = new CantidadAsientosSalon(_configuration);
            cantidadAsientosSalon.Show();
            this.Hide();
        }

        // Seleccionar la opción de transmisión en vivo
        private void pnlTransmision_Click(object sender, EventArgs e)
        {
            CantidadAsientosTransmision cantidadAsientosTransmision = new CantidadAsientosTransmision(_configuration);
            cantidadAsientosTransmision.Show();
            this.Hide();
        }

    }
}
