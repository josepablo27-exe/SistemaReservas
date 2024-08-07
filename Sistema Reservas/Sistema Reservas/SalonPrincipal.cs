using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sistema_Reservas.Botones;

namespace Sistema_Reservas
{
    public partial class SalonPrincipal : Form
    {
        private readonly IConfiguration _configuration;

        public SalonPrincipal(int cantidad_asientos, IConfiguration configuration)
        {
            InitializeComponent();
            _configuration = configuration;
            Escenario.Paint += Escenario_Paint;
            this.cantidad_asientos = cantidad_asientos;
            foreach (var panel in GetAllPanels(this).Where(p => p.Name != "panel1" && p.Name != "panel2"))
            {
                panel.Click += Panel_Click;
            }
        }

        // Función para obtener todos los paneles
        private IEnumerable<Panel> GetAllPanels(Control control)
        {
            var panels = control.Controls.OfType<Panel>();
            return panels.SelectMany(GetAllPanels).Concat(panels);
        }

        // Cantidad de asientos ingresados
        int cantidad_asientos;

        // Lista de los asientos seleccionados
        List<int> asientosSeleccionados = new List<int>();

        //  Colores para las distintas categorías
        Color colorCoches = ColorTranslator.FromHtml("#CD0000");
        Color colorAC = ColorTranslator.FromHtml("#003CFF");
        Color colorSeleccionado = ColorTranslator.FromHtml("#00FF43");

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

        PantallaCarga pantallaCarga;

        private async void SalonPrincipal_Load(object sender, EventArgs e)
        {
            // Muestra la pantalla de carga
            pantallaCarga = new PantallaCarga();
            pantallaCarga.Show();

            // Cargar y configurar el formulario principal en un hilo separado
            await Task.Run(() => CargarFormulario());

            // Oculta la pantalla de carga
            pantallaCarga.Close();
        }

        private void CargarFormulario()
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.WindowState = FormWindowState.Maximized;

                int ancho_pantalla = Screen.PrimaryScreen.WorkingArea.Width;
                int alto_pantalla = Screen.PrimaryScreen.WorkingArea.Height;

                /* Inicio Panel 2 */

                int ancho_panel2 = (int)Math.Round(ancho_pantalla * 0.12);
                int alto_panel2 = (int)Math.Round(alto_pantalla * 0.83);
                panel2.Size = new Size(ancho_panel2, alto_panel2);
                int x_panel2 = 20;
                int y_panel2 = (int)Math.Round(alto_pantalla * 0.12);
                panel2.Location = new Point(x_panel2, y_panel2);

                /* Fin Panel 2 */

                /* Inicio Panel 1 */

                int px_panel1 = ancho_panel2 + x_panel2;
                int ancho_panel1 = (int)Math.Round(ancho_pantalla * 0.85);
                int alto_panel1 = (int)Math.Round(alto_pantalla * 0.83);
                panel1.Size = new Size(ancho_panel1, alto_panel1);
                int x_panel1 = ((ancho_pantalla - px_panel1) - ancho_panel1) / 2 + px_panel1;
                int y_panel1 = y_panel2;
                panel1.Location = new Point(x_panel1, y_panel1);

                /* Fin Panel 1 */

                /* Inicio Label 1 */

                label1.TextAlign = ContentAlignment.MiddleCenter;
                label1.Font = new Font(label1.Font.FontFamily, 34, FontStyle.Regular);
                int x_label1 = (ancho_pantalla - label1.Size.Width) / 2;
                label1.Location = new Point(x_label1, 20);

                /* Fin Label 1 */

                /* Inicio pnlDisponible */

                pnlDisponible.Location = new Point(20, 50);
                pnlDisponible.BorderRadius = 7;

                /* Fin pnlDisponible */

                /* Inicio lblDisponible */

                lblDisponible.Font = new Font(lblDisponible.Font.FontFamily, 14, FontStyle.Regular);
                lblDisponible.Location = new Point(60, 55);

                /* Fin lblDisponible */

                /* Inicio pnlReservado */

                pnlReservado.Location = new Point(20, 150);
                pnlReservado.BorderRadius = 7;

                /* Fin pnlReservado */

                /* Inicio lblReservado */

                lblReservado.Font = new Font(lblReservado.Font.FontFamily, 14, FontStyle.Regular);
                lblReservado.Location = new Point(60, 155);

                /* Fin lblReservado */

                /* Inicio pnlSeleccionado */

                pnlSeleccionado.Location = new Point(20, 250);
                pnlSeleccionado.BorderRadius = 7;

                /* Fin pnlSeleccionado */

                /* Inicio lblSeleccionado */

                lblSeleccionado.Font = new Font(lblSeleccionado.Font.FontFamily, 14, FontStyle.Regular);
                lblSeleccionado.Location = new Point(60, 255);

                /* Fin lblSeleccionado */

                /* Inicio pnlA/C */

                pnlAC.Location = new Point(20, 350);
                pnlAC.BorderRadius = 7;

                /* Fin pnlAC */

                /* Inicio lblAC */

                lblAC.Font = new Font(lblAC.Font.FontFamily, 14, FontStyle.Regular);
                lblAC.Location = new Point(60, 355);

                /* Fin lblAC */

                /* Inicio pnlCoches */

                pnlCoches.Location = new Point(20, 450);
                pnlCoches.BorderRadius = 7;

                /* Fin pnlCoches */

                /* Inicio lblCoches */

                lblCoches.Font = new Font(lblCoches.Font.FontFamily, 14, FontStyle.Regular);
                lblCoches.Location = new Point(60, 455);

                /* Fin lblCoches */

                /* Inicio btnReservar */

                int ancho_botonPrimario1 = 250;
                int x_botonPrimario1 = ancho_pantalla - (ancho_botonPrimario1 + 50);
                Color color = ColorTranslator.FromHtml("#ED4F49");
                btnReservar.BackColor = color;
                btnReservar.TextAlign = ContentAlignment.MiddleCenter;
                btnReservar.Size = new Size(ancho_botonPrimario1, 50);
                btnReservar.Location = new Point(x_botonPrimario1, 20);
                btnReservar.Font = new Font(btnReservar.Font.FontFamily, 22, FontStyle.Regular);

                /* Fin btnReservar */

                /* Inicio Escenario */

                Escenario.AutoSize = false;
                Escenario.TextAlign = ContentAlignment.MiddleCenter;
                Escenario.Size = new Size(600, 150);
                Escenario.Font = new Font(label1.Font.FontFamily, 30, FontStyle.Bold);
                Escenario.Location = new Point(330, 5);

                /* Fin Escenario */

                Asignacion();
                Recomendacion();
            });
        }

        // Establecer los bordes para el Escenario
        private void Escenario_Paint(object sender, PaintEventArgs e)
        {
            // Obtener el control Label
            Label label = sender as Label;

            // Dibujar un borde adicional alrededor del control Label
            ControlPaint.DrawBorder(e.Graphics, label.ClientRectangle,
                                    Color.Black, 4, ButtonBorderStyle.Solid,
                                    Color.Black, 4, ButtonBorderStyle.Solid,
                                    Color.Black, 4, ButtonBorderStyle.Solid,
                                    Color.Black, 4, ButtonBorderStyle.Solid);
        }
        
        // Abrir el formulario para ingresar el nùmero telefònico
        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (asientosSeleccionados.Count() > 0)
            {
                NumeroTelefonicoSalon numerotelefonicosalon = new NumeroTelefonicoSalon(cantidad_asientos, asientosSeleccionados, _configuration);
                numerotelefonicosalon.Show();
                this.Close();
            }
            else
            {
                CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "No hay asientos seleccionados", Properties.Resources.Error);
            }
        }

        // Asignar la categoría del asiento a los paneles
        private void Asignacion()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT ID_ASIENTO, CATEGORIA, RESERVADO FROM asientos_salon";

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
                            int idAsiento = reader.GetInt32(0);
                            string categoria = reader.GetString(1);
                            bool reservado = reader.GetBoolean(2);

                            // Busca el panel correspondiente según el ID de asiento y asigna los datos
                            PanelInicio panelAsiento = FindPanelInicioById(idAsiento, this.Controls);
                            if (panelAsiento != null)
                            {
                                if (categoria.Equals("Inhabilitado"))
                                {
                                    panelAsiento.Visible = false;
                                }
                                else if (categoria.Equals("Disponible") && reservado == false)
                                {
                                    panelAsiento.BorderColor = Color.Black;
                                    panelAsiento.BorderRadius = 7;
                                    panelAsiento.Cursor = Cursors.Hand;
                                    panelAsiento.BackColor = Color.White;
                                }
                                else if (categoria.Equals("Coches") && reservado == false)
                                {
                                    panelAsiento.BorderColor = colorCoches;
                                    panelAsiento.BorderRadius = 7;
                                    panelAsiento.Cursor = Cursors.Hand;
                                    panelAsiento.BackColor = Color.White;
                                }
                                else if (categoria.Equals("A/C") && reservado == false)
                                {
                                    panelAsiento.BorderColor = colorAC;
                                    panelAsiento.BorderRadius = 7;
                                    panelAsiento.Cursor = Cursors.Hand;
                                    panelAsiento.BackColor = Color.White;
                                }
                                else if (reservado == true)
                                {
                                    panelAsiento.BackColor = Color.Gray;
                                    panelAsiento.BorderRadius = 7;
                                    panelAsiento.BorderColor = Color.Black;
                                }
                            }
                        }
                    }
                }
                catch (MySqlException)
                {
                    CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Error con la conexión a la base de datos", Properties.Resources.Error);
                }
            }
        }

        // Buscar el panel por su tag
        private PanelInicio FindPanelInicioById(int idAsiento, Control.ControlCollection controls)
        {
            // Recorrer todos los controles en la colección
            foreach (Control control in controls)
            {
                // Verificar si el control es un PanelInicio y si su Tag es igual al ID de asiento
                if (control is PanelInicio panelInicio && panelInicio.Tag != null && int.Parse((string)panelInicio.Tag) == idAsiento)
                {
                    // Si se encuentra un panelInicio con el ID de asiento especificado, devolverlo
                    return panelInicio;
                }

                // Si el control tiene controles secundarios, realizar una búsqueda recursiva en ellos
                if (control.HasChildren)
                {
                    PanelInicio panelEncontrado = FindPanelInicioById(idAsiento, control.Controls);
                    if (panelEncontrado != null)
                    {
                        return panelEncontrado;
                    }
                }
            }
            // Si no se encuentra ningún panelInicio con el ID de asiento especificado, devolver null
            return null;
        }

        // Se recomienda un asiento de la base de datos que no este inhabilitado ni reservado
        private void Recomendacion()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT ID_ASIENTO, CATEGORIA, RESERVADO FROM asientos_salon";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                
                try
                {
                    conexion.Open();

                    // Acumulador para contar cuantos asientos fueron ingresados
                    int acu = cantidad_asientos;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read() && acu > 0)
                        {
                            int idAsiento = reader.GetInt32(0);
                            string categoria = reader.GetString(1);
                            bool reservado = reader.GetBoolean(2);

                            // Busca el panel correspondiente según el ID de asiento y asigna los datos
                            PanelInicio panelAsiento = FindPanelInicioById(idAsiento, this.Controls);
                            if (panelAsiento != null)
                            {
                                // Verificar si el asiento no esta inhabilitado ni reservado
                                if (!categoria.Equals("Inhabilitado") && reservado == false)
                                {
                                    // Definir un color verde para señalar los asientos seleccionados
                                    panelAsiento.BackColor = colorSeleccionado;
                                    acu -= 1;

                                    //Añadir el id del asiento a la lista de asientos
                                    asientosSeleccionados.Add(idAsiento);
                                }
                            }
                        }
                    }
                }
                catch (MySqlException)
                {
                    CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Error con la conexión a la base de datos", Properties.Resources.Error);
                }
            }
        }

        // Seleccionar un asiento en específico
        public void Seleccionar(int idAsiento)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT ID_ASIENTO, CATEGORIA, RESERVADO FROM asientos_salon WHERE ID_ASIENTO = @idAsiento";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idAsiento", idAsiento); // Asignar el valor de la variable id al parámetro @idAsiento
                try
                {
                    conexion.Open();
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Acceder a los datos del resultado de la consulta
                            bool reservado = reader.GetBoolean(2);

                            if (!reservado)
                            {
                                PanelInicio panelAsientoSeleccionado = FindPanelInicioById(idAsiento, this.Controls);
                                if (panelAsientoSeleccionado != null)
                                {
                                    int id = asientosSeleccionados[0]; // ID del primer asiento dentro de la lista de los asientos recomendados o seleccionads
                                    PanelInicio panelAsientoRecomendado = FindPanelInicioById(id, this.Controls);
                                    panelAsientoRecomendado.BackColor = Color.White; // Vuelve al color predeterminado del sistema
                                    asientosSeleccionados.Remove(id); // Elimina el asiento de la lista de seleccionados
                                    panelAsientoSeleccionado.BackColor = colorSeleccionado;
                                    asientosSeleccionados.Add(idAsiento);
                                }
                            }

                        }
                    }
                }
                catch (MySqlException)
                {
                    CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "Error con la conexión a la base de datos", Properties.Resources.Error);
                }
            }
        }

        // Volver a la página para ingresar la cantidad de asientos
        private void btnAtras_Click(object sender, EventArgs e)
        {
            CantidadAsientosSalon cantidadAsientosSalon = new CantidadAsientosSalon(_configuration);
            cantidadAsientosSalon.Show();
            this.Close();
        }

        // Controlar que por cada panel que se haga click, se ejecute la función de seleccionar
        private void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            if(panel.Tag != null)
            {
                int id = int.Parse((string)panel.Tag);
                Seleccionar(id);
            }
            
        }
    }
}
