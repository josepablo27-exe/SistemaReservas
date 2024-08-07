using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_Reservas
{
    public partial class CantidadAsientosSalon : Form
    {
        private readonly IConfiguration _configuration;

        public CantidadAsientosSalon(IConfiguration configuration)
        {
            InitializeComponent();
            _configuration = configuration;
        }

        // Espacios disponibles en el salón principal
        int espacios_disponibles_salon = 0;

        // Espacios disponibles en transmisión en vivo
        int espacios_disponibles_transmision = 0;

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

        private void CantidadAsientosSalon_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            /* Inicio Panel 1 */

            int ancho_panel1 = 1000;
            int alto_panel1 = 400;
            panel1.Size = new Size(ancho_panel1, alto_panel1);
            int x_panel1 = (Screen.PrimaryScreen.WorkingArea.Width - ancho_panel1) / 2;
            int y_panel1 = (Screen.PrimaryScreen.WorkingArea.Height - alto_panel1) / 2;
            panel1.Location = new Point(x_panel1, y_panel1);

            /* Fin Panel 1 */

            /* Inicio Label 1 */

            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font(label1.Font.FontFamily, 34, FontStyle.Regular);
            int x_label1 = (ancho_panel1 - label1.Size.Width) / 2;
            label1.Location = new Point(x_label1, 50);

            /* Fin Label 1 */

            /* Inicio textBox 1 */

            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Font = new Font(label1.Font.FontFamily, 24, FontStyle.Regular);
            textBox1.Size = new Size(400, 200);
            textBox1.Location = new Point(300, 175);

            /* Fin textBox 1 */

            /* Inicio btnContinuar */

            Color color = ColorTranslator.FromHtml("#ED4F49");
            btnContinuar.BackColor = color;
            btnContinuar.Size = new Size(300, 50);
            btnContinuar.Location = new Point(350, 300);
            btnContinuar.Font = new Font(btnContinuar.Font.FontFamily, 26, FontStyle.Regular);

            /* Fin btnContinuar */
        }

        // Función para verificar la cantidad de asientos ingresados
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            int cantidad_asientos;
            try
            {
                // Verificar que se haya ingresado una cantidad válida
                cantidad_asientos = int.Parse(textBox1.Text);
                int prueba  = 2 / cantidad_asientos;
                if (cantidad_asientos < 0)
                {
                    CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Ingrese una cantidad válida", Properties.Resources.Error);
                }
                else 
                {
                    //Contar los espacios disponibles en el salón
                    EspaciosDisponiblesSalon();

                    //Contar los espacios disponibles en transmisión en vivo
                    EspaciosDisponiblesTransmision();

                    //Verificar que la cantidad de asientos ingresados sea menor o igual a los disponibles en el salón
                    if (cantidad_asientos <= espacios_disponibles_salon)
                    {
                        SalonPrincipal salonprincipal = new SalonPrincipal(cantidad_asientos, _configuration);
                        salonprincipal.Show();
                        this.Close();
                    }
                    //Verificar si la cantidad de asientos ingresados es mayor a los disponibles en el salón y transmisión
                    else if (cantidad_asientos > espacios_disponibles_transmision && cantidad_asientos > espacios_disponibles_salon)
                    {
                        CuadroAlerta(Color.LightGoldenrodYellow, Color.Goldenrod, "Advertencia", "No hay suficientes espacios en el Salón Principal", Properties.Resources.Warning);
                    }
                    //Verificar si la cantidad de asientos es mayor a los disponibles en salón, pero menor de los disponibles en transmisión
                    else
                    {
                        Transmision transmision = new Transmision(cantidad_asientos, _configuration);
                        transmision.Show();
                        this.Close();
                        CuadroAlerta(Color.LightGoldenrodYellow, Color.Goldenrod, "Advertencia", "No hay suficientes espacios en el Salón Principal", Properties.Resources.Warning);
                    }
                }
                
            }
            catch
            {
                CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Ingrese una cantidad válida", Properties.Resources.Error);
            }
        }

        // Volver a la página anterior
        private void btnAtras_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(_configuration);
            inicio.Show();
            this.Close();
        }

        //Contar los espacios disponibles en el salón
        private void EspaciosDisponiblesSalon()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT COUNT(*) AS total_disponibles FROM ASIENTOS_SALON WHERE CATEGORIA IN ('Disponible', 'Coches', 'AC') AND RESERVADO = 0";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        espacios_disponibles_salon = reader.GetInt32(0);
                    }
                }
            }
        }

        //Contar los espacios disponibles en transmisión en vivo
        private void EspaciosDisponiblesTransmision()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT COUNT(*) AS total_disponibles FROM ASIENTOS_TRANSMISION WHERE CATEGORIA = 'Disponible' AND RESERVADO = 0";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        espacios_disponibles_transmision = reader.GetInt32(0);
                    }
                }
            }
        }
    }
}
