using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sistema_Reservas.Botones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Reservas
{
    public partial class Transmision : Form
    {
        private readonly IConfiguration _configuration;

        public Transmision(int cantidad_asientos, IConfiguration configuration)
        {
            InitializeComponent();
            _configuration = configuration;
            this.cantidad_asientos = cantidad_asientos;
            Pantalla.Paint += Pantalla_Paint;
            foreach (var panel in GetAllPanels(this).Where(p => p.Name != "panel1" && p.Name != "panel2" && p.Name != "panel3"))
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

        // Color para los asientos seleccionados
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

        private void Transmision_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            int ancho_pantalla = Screen.PrimaryScreen.WorkingArea.Width;
            int alto_pantalla = Screen.PrimaryScreen.WorkingArea.Height;

            /* Inicio Panel 1 */

            int ancho_panel1 = (int)Math.Round(ancho_pantalla * 0.30);
            int alto_panel1 = (int)Math.Round(alto_pantalla * 0.83);
            panel1.Size = new Size(ancho_panel1,alto_panel1);
            int x_panel1 = (ancho_pantalla - ancho_panel1) / 2;
            int y_panel1 = (int)Math.Round(alto_pantalla * 0.12);
            panel1.Location = new Point(x_panel1,y_panel1);

            /* Fin Panel 1 */

            /* Inicio Panel 2 */

            int ancho_panel2 = (int)Math.Round(ancho_pantalla * 0.15);
            int alto_panel2 = (int)Math.Round(alto_pantalla * 0.83);
            panel2.Size = new Size(ancho_panel2, alto_panel2);
            int x_panel2 = 20;
            int y_panel2 = (int)Math.Round(alto_pantalla * 0.12);
            panel2.Location = new Point(x_panel2, y_panel2);

            /* Fin Panel 2 */

            /* Inicio Panel 3 */

            int x_panel3 = (ancho_panel1 - panel3.Size.Width) / 2;
            int y_panel3 = (alto_panel1 - panel3.Size.Height) / 2;
            panel3.Location = new Point(x_panel3, y_panel3);

            /* Fin Panel 3 */

            /* Inicio Label 1 */

            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font(label1.Font.FontFamily, 34, FontStyle.Regular);
            int x_label1 = (ancho_pantalla - label1.Size.Width) / 2;
            label1.Location = new Point(x_label1, 20);

            /* Fin Label 1 */

            /* Inicio btnReservar */

            int ancho_btnReservar = 250;
            int x_btnReservar = ancho_pantalla - (ancho_btnReservar + 50);
            Color color = ColorTranslator.FromHtml("#ED4F49");
            btnReservar.BackColor = color;
            btnReservar.TextAlign = ContentAlignment.MiddleCenter;
            btnReservar.Size = new Size(ancho_btnReservar, 50);
            btnReservar.Location = new Point(x_btnReservar, 20);
            btnReservar.Font = new Font(btnReservar.Font.FontFamily, 22, FontStyle.Regular);

            /* Fin btnReservar */ 

            /* Inicio pnlDisponible */

            pnlDisponible.Location = new Point(20, 50);
            pnlDisponible.BorderRadius = 7;

            /* Fin pnlDisponible */

            /* Inicio lblDisponible */

            lblDisponible.Font = new Font(lblDisponible.Font.FontFamily, 18, FontStyle.Regular);
            lblDisponible.Location = new Point(60, 55);

            /* Fin lblDisponible */

            /* Inicio pnlReservado */

            pnlReservado.Location = new Point(20, 150);
            pnlReservado.BorderRadius = 7;

            /* Fin pnlReservado */

            /* Inicio lblReservado */

            lblReservado.Font = new Font(lblReservado.Font.FontFamily, 18, FontStyle.Regular);
            lblReservado.Location = new Point(60, 155);

            /* Fin lblReservado */

            /* Inicio pnlSeleccionado */

            pnlSeleccionado.Location = new Point(20, 250);
            pnlSeleccionado.BorderRadius = 7;

            /* Fin pnlSeleccionado */

            /* Inicio lblSeleccionado */

            lblSeleccionado.Font = new Font(lblSeleccionado.Font.FontFamily, 18, FontStyle.Regular);
            lblSeleccionado.Location = new Point(60, 255);

            /* Fin lblSeleccionado */

            /* Inicio Pantalla */

            int ancho_lblpantalla = 300;
            int alto_lblpantalla = 70;
            Pantalla.AutoSize = false;
            Pantalla.TextAlign = ContentAlignment.MiddleCenter;
            Pantalla.Size = new Size(ancho_lblpantalla, alto_lblpantalla);
            Pantalla.Font = new Font(Pantalla.Font.FontFamily, 24, FontStyle.Bold);
            int x_lblpantalla = (ancho_panel1 - ancho_lblpantalla) / 2;
            Pantalla.Location = new Point(x_lblpantalla, 20);

            /* Fin Pantalla */

            Asignacion();
            Recomendacion();
        }

        // Asignar la categoría del asiento a los paneles
        private void Asignacion()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT ID_ASIENTO, CATEGORIA, RESERVADO FROM asientos_transmision";

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
                                else if (reservado == true)
                                {
                                    panelAsiento.BackColor = Color.Gray;
                                    panelAsiento.BorderRadius = 7;
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
            string consulta = "SELECT ID_ASIENTO, CATEGORIA, RESERVADO FROM asientos_transmision";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
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
        }

        // Seleccionar un asiento en específico
        public void Seleccionar(int idAsiento)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string consulta = "SELECT ID_ASIENTO, CATEGORIA, RESERVADO FROM asientos_transmision WHERE ID_ASIENTO = @idAsiento";

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

        // Controlar que por cada panel que se haga click, se ejecute la función de seleccionar
        private void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            if (panel.Tag != null)
            {
                int id = int.Parse((string)panel.Tag);
                Seleccionar(id);
            }
        }

        // Volver a la página para ingresar la cantidad de asientos
        private void btnAtras_Click(object sender, EventArgs e)
        {
            CantidadAsientosTransmision cantidadAsientosTransmision = new CantidadAsientosTransmision(_configuration);
            cantidadAsientosTransmision.Show();
            this.Close();
        }

        // Establecer bordes en la Pantalla 
        private void Pantalla_Paint(object sender, PaintEventArgs e)
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
                NumeroTelefonicoTransmision numerotelefonicotransmision = new NumeroTelefonicoTransmision(cantidad_asientos, asientosSeleccionados, _configuration);
                numerotelefonicotransmision.Show();
                this.Close();
            }
            else
            {
                CuadroAlerta(Color.LightPink, Color.DarkRed, "Error", "No hay asientos seleccionados", Properties.Resources.Error);
            }
        }
    }
}
