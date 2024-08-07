using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vonage;
using Vonage.Request;

namespace Sistema_Reservas
{
    public partial class NumeroTelefonicoTransmision : Form
    {
        private readonly IConfiguration _configuration;

        public NumeroTelefonicoTransmision(int cantidad_asientos, List<int> asientosSeleccionados, IConfiguration configuration)
        {
            InitializeComponent();
            panel1.Paint += Panel1_Paint;
            this.cantidad_asientos = cantidad_asientos;
            this.asientosSeleccionados = asientosSeleccionados;
            _configuration = configuration;
        }

        // Cantidad de asientos seleccionados
        int cantidad_asientos;

        // Lista de los ID de los asientos seleccionados
        List<int> asientosSeleccionados;

        // Instancia del cuadro de alerta
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

        private void NumeroTelefonicoTransmision_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            /* Inicio Panel 1 */

            int ancho_panel1 = 1000;
            int alto_panel1 = 500;
            panel1.Size = new Size(ancho_panel1, alto_panel1);
            int x_panel1 = (Screen.PrimaryScreen.WorkingArea.Width - ancho_panel1) / 2;
            int y_panel1 = (Screen.PrimaryScreen.WorkingArea.Height - alto_panel1) / 2;
            panel1.Location = new Point(x_panel1, y_panel1);

            /* Fin Panel 1 */

            /* Inicio Label 1 */

            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Size = new Size(680, 150);
            label1.Font = new Font(label1.Font.FontFamily, 34, FontStyle.Regular);
            int x_label1 = (ancho_panel1 - label1.Size.Width) / 2;
            label1.Location = new Point(x_label1, 20);

            /* Fin Label 1 */

            /* Inicio lblCantidad */

            lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
            lblCantidad.Font = new Font(lblCantidad.Font.FontFamily, 24, FontStyle.Regular);
            lblCantidad.Location = new Point(100, 200);

            /* Fin lblCantidad */

            /* Inicio cantidad */

            cantidad.Font = new Font(cantidad.Font.FontFamily, 24);
            cantidad.Location = new Point(425, 195);
            cantidad.Text = cantidad_asientos.ToString();

            /* Fin cantidad */

            /* Inicio lblAsientos */

            lblAsientos.TextAlign = ContentAlignment.MiddleCenter;
            lblAsientos.Font = new Font(lblAsientos.Font.FontFamily, 24, FontStyle.Regular);
            lblAsientos.Location = new Point(550, 200);

            /* Fin lblAsientos */

            /* Inicio asientos */

            asientos.AutoSize = false;
            asientos.Size = new Size(230, 50);
            asientos.Font = new Font(asientos.Font.FontFamily, 24);
            asientos.Location = new Point(700, 195);
            asientos.Text = ObtenerAsientos();
            asientos.AutoEllipsis = true; // Si el texto es muy grande, se ponen puntos suspensivos

            /* Fin asientos */

            /* Inicio textBox 1 */

            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Font = new Font(label1.Font.FontFamily, 30, FontStyle.Regular);
            textBox1.Size = new Size(800, 65);
            textBox1.Location = new Point(100, 285);

            /* Fin textBox 1 */

            /* Inicio btnCancelar */

            Color color = ColorTranslator.FromHtml("#ED4F49");
            btnCancelar.BorderColor = color;
            btnCancelar.TextColor = color;
            btnCancelar.Size = new Size(250, 50);
            btnCancelar.Location = new Point(200, 400);
            btnCancelar.Font = new Font(btnCancelar.Font.FontFamily, 26, FontStyle.Regular);

            /* Fin btnCancelar */

            /* Inicio btnFinalizar */

            btnFinalizar.BackColor = color;
            btnFinalizar.Size = new Size(250, 50);
            btnFinalizar.Location = new Point(550, 400);
            btnFinalizar.Font = new Font(btnFinalizar.Font.FontFamily, 26, FontStyle.Regular);

            /* Fin btnFinalizar */
        }

        // Establecer los bordes al panel 1
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Obtener el control Label
            Panel panel = sender as Panel;

            // Dibujar un borde adicional alrededor del control Label
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                                         Color.Black, 2, ButtonBorderStyle.Solid,
                                         Color.Black, 2, ButtonBorderStyle.Solid,
                                         Color.Black, 2, ButtonBorderStyle.Solid,
                                         Color.Black, 2, ButtonBorderStyle.Solid);
        }

        // Reservar los asientos seleccionados
        private void Reservar()
        {
            // Verificar que el número telefónico sea válido
            string numero_telefonico = textBox1.Text;
            if (numero_telefonico.Length > 8)
            {
                CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "El formato debe ser: 88888888", Properties.Resources.Error);
            }
            else if (numero_telefonico.Length < 8)
            {
                CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Número telefónico inválido", Properties.Resources.Error);
            }
            else
            {
                try
                {
                    string connectionString = _configuration.GetConnectionString("DefaultConnection");
                    string consulta = "UPDATE asientos_transmision SET RESERVADO = true WHERE ID_ASIENTO = @idAsiento";

                    using (MySqlConnection conexion = new MySqlConnection(connectionString))
                    {
                        conexion.Open();

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            // Agrega el parámetro fuera del bucle
                            comando.Parameters.Add("@idAsiento", MySqlDbType.Int32);

                            for (int i = 0; i < asientosSeleccionados.Count; i++)
                            {
                                int id = asientosSeleccionados[i];
                                // Asigna el valor del ID de asiento al parámetro
                                comando.Parameters["@idAsiento"].Value = id;
                                comando.ExecuteNonQuery();
                            }
                        }
                    }
                    try
                    {
                        //Función para enviar el mensaje telefónico
                        EnviarMensaje(numero_telefonico);
                        GuardarReserva(numero_telefonico, ObtenerAsientos(), DateTime.Now);
                        Inicio inicio = new Inicio(_configuration);
                        inicio.Show();
                        this.Close();
                        CuadroAlerta(Color.LightGreen, Color.SeaGreen, "Éxito", "Se ha enviado el mensaje de texto", Properties.Resources.Success);
                    }
                    catch
                    {
                        CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Número telefónico inválido", Properties.Resources.Error);

                    }

                }
                catch
                {
                    CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Hubo un error en la reservación", Properties.Resources.Error);
                }
            }
        }

        // Obtener el número de los asientos seleccionados
        private string ObtenerAsientos()
        {
            string asiento = "";
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT ASIENTO FROM asientos_transmision WHERE ID_ASIENTO = @idAsiento";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        // Agrega el parámetro fuera del bucle
                        comando.Parameters.Add("@idAsiento", MySqlDbType.Int32);

                        //Buscar el numero de los asientos según su ID.
                        for (int i = 0; i < asientosSeleccionados.Count; i++)
                        {
                            int id = asientosSeleccionados[i];
                            comando.Parameters["@idAsiento"].Value = id;
                            object resultado = comando.ExecuteScalar();
                            if (resultado != null)
                            {
                                asiento = asiento + resultado.ToString() + " ";
                            }
                        }
                    }
                }
                catch (MySqlException)
                {
                    CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Error con la conexión a la base de datos", Properties.Resources.Error);
                }
            }
            return asiento;
        }

        //Función para enviar los asientos por un mensaje de texto al número telefónico
        public async Task EnviarMensaje(string numero_telefonico)
        {
            string apiKey = _configuration["Vonage:ApiKey"];
            string apiSecret = _configuration["Vonage:ApiSecret"];

            var credentials = Credentials.FromApiKeyAndSecret(
                apiKey,
                apiSecret
            );

            var VonageClient = new VonageClient(credentials);

            var response = await VonageClient.SmsClient.SendAnSmsAsync(new Vonage.Messaging.SendSmsRequest()
            {
                To = "506" + numero_telefonico,
                From = "Vonage APIs",
                Text = "Sus asientos son: " + ObtenerAsientos()
            });
        }

        //Función para guardar la reserva en el historial
        private void GuardarReserva(string telefono, string asiento, DateTime fechaHora)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            // Consulta SQL para insertar los datos en la tabla RESERVAS
            string consulta = "INSERT INTO HISTORIAL (TELEFONO, ASIENTO, FECHA, SALON) VALUES (@telefono, @asiento, @fecha, @salon)";

            string salon = "Transimisón en vivo";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    // Agrega los parámetros a la consulta
                    comando.Parameters.AddWithValue("@telefono", telefono);
                    comando.Parameters.AddWithValue("@asiento", asiento);
                    comando.Parameters.AddWithValue("@fecha", fechaHora);
                    comando.Parameters.AddWithValue("@salon", salon);

                    try
                    {
                        // Abre la conexión y ejecuta la consulta
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        Console.WriteLine("Reserva realizada con éxito.");
                    }
                    catch (MySqlException)
                    {
                        CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Error con la conexión a la base de datos", Properties.Resources.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(_configuration);
            inicio.Show();
            this.Close();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Reservar();
        }
    }
}
