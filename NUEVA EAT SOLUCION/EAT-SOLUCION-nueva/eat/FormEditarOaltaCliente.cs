using conexionDatos;
using DOMINIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eat
{
    public partial class FormEditarOaltaCliente : Form
    {


        public Action OnClienteEditado { get; set; } // Delegate para notificar edición

        private Cliente clienteSeleccionado;

        public FormEditarOaltaCliente()
        {
            InitializeComponent();
        }

        public FormEditarOaltaCliente(Cliente cli)
        {

            InitializeComponent();
            this.clienteSeleccionado = cli;

            if (clienteSeleccionado != null)
            {
                // Modo edición
                textBoxID.Text = clienteSeleccionado._idCliente.ToString();
                textBoxID.ReadOnly = true;

                textBoxNombre.Text = clienteSeleccionado._nombre;
                textBoxApellido.Text = clienteSeleccionado._apellido;
                textBoxDNI.Text = clienteSeleccionado._dni.ToString();
                textBoxCuil.Text = clienteSeleccionado._cuil.ToString();
                textBoxTelefono.Text = clienteSeleccionado._telefono;
                textBoxCorreo.Text = clienteSeleccionado._correo;
                textBoxObservacion.Text = clienteSeleccionado._observacion;
                dateTimePickerFechaAlta.Value = clienteSeleccionado._fechaNacimiento; // Usás este control como fecha de nacimiento
            }
            else
            {
                // Modo alta
                ClienteConexion clienteConec = new ClienteConexion();
                int ultimoID = clienteConec.obtenerUltimoIdCliente();

                textBoxID.Text = (ultimoID + 1).ToString();
                textBoxID.ReadOnly = true;

                // Inicializar campos vacíos
                textBoxNombre.Text = "";
                textBoxApellido.Text = "";
                textBoxDNI.Text = "";
                textBoxCuil.Text = "";
                textBoxTelefono.Text = "";
                textBoxCorreo.Text = "";
                textBoxObservacion.Text = "";
                dateTimePickerFechaAlta.Value = DateTime.Today;




            }


        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteConexion cliConec = new ClienteConexion();

            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(textBoxDNI.Text) ||
                string.IsNullOrWhiteSpace(textBoxCuil.Text) ||
                string.IsNullOrWhiteSpace(textBoxTelefono.Text) ||
                string.IsNullOrWhiteSpace(textBoxCorreo.Text) ||
                string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Todos los campos obligatorios deben estar completos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de números
            if (!long.TryParse(textBoxDNI.Text, out long dni) ||
                !long.TryParse(textBoxCuil.Text, out long cuil) ||
                !int.TryParse(textBoxID.Text, out int idCliente))
            {
                MessageBox.Show("DNI, CUIL e ID deben ser números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar los datos al objeto Cliente
            cliente._idCliente = int.Parse(textBoxDNI.Text);
            cliente._nombre = textBoxNombre.Text;
            cliente._apellido = textBoxApellido.Text;
            cliente._dni = long.Parse(textBoxDNI.Text);
            cliente._cuil = long.Parse(textBoxCuil.Text);
            cliente._telefono = textBoxTelefono.Text;
            cliente._correo = textBoxCorreo.Text;
            cliente._observacion = textBoxObservacion.Text;
            cliente._fechaNacimiento = dateTimePickerFechaAlta.Value;









            int ultimoID = cliConec.obtenerUltimoIdCliente();


            if (ultimoID + 1 == int.Parse(textBoxID.Text))
            {





                cliConec.agregarCliente(cliente);
                MessageBox.Show("¡Cliente nuevo agregado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnClienteEditado?.Invoke();
                ActiveForm.Close();
            }
            else
            {
                // Modo edición
                cliente._idCliente = int.Parse(textBoxID.Text);
                cliConec.cambiarPropiedad(cliente);
                MessageBox.Show("¡Cliente editado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnClienteEditado?.Invoke();
                ActiveForm.Close();

            }
        }
    }
}