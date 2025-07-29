using CONEXIONDATOS;
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
    public partial class formEditarOaltaCliente : Form
    {

        private Cliente clienteSeleccionado;

        public Action OnClienteEditado { get; set; } // Delegate para notificar edición


        public formEditarOaltaCliente(Cliente mozo)
        {
            InitializeComponent();
            this.clienteSeleccionado = mozo;


            if (clienteSeleccionado != null) { 
            
                textBoxLegajo.Text = clienteSeleccionado._legajo.ToString();
                textBoxLegajo.ReadOnly = true;
                
                textBoxNombre.Text = clienteSeleccionado._nombre;
                textBoxApellido.Text = clienteSeleccionado._apellido;
                textBoxDni.Text = clienteSeleccionado._dni.ToString();
              

                textBoxCuil.Text = clienteSeleccionado._cuil.ToString();
                textBoxTelefono.Text = clienteSeleccionado._telefono;
                textBoxCorreo.Text = clienteSeleccionado._correo;
                textBoxAltaEventual.Text = clienteSeleccionado._altaEventual;
                checkBoxDisponible.Checked = clienteSeleccionado._disponible;
                checkBoxActivado.Checked = clienteSeleccionado._activado;

                dateTimePickerFechaAlta.Value = clienteSeleccionado._fechaAlta;
                dateTimePickerFechaNacimiento.Value = clienteSeleccionado._fechaNacimiento;
                textBoxCategoria.Text = clienteSeleccionado._categoria;
                textBoxTarea.Text = clienteSeleccionado._tarea;

            }
            
            else
            
            {
                MozoConexion mozoConec = new MozoConexion();
                int cantidadMozos = mozoConec.cantidadMozos() + 1;
                
                textBoxLegajo.Text = cantidadMozos.ToString();
                textBoxLegajo.ReadOnly = true;


            }

            
        }

     

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
         
            
            MozoConexion mozoConec = new MozoConexion();

            Cliente mozoCambiado = new Cliente();
     

            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(textBoxDni.Text) ||
                string.IsNullOrWhiteSpace(textBoxCuil.Text) ||
                string.IsNullOrWhiteSpace(textBoxTelefono.Text) ||
                string.IsNullOrWhiteSpace(textBoxCorreo.Text) ||
                string.IsNullOrWhiteSpace(textBoxAltaEventual.Text) ||
                string.IsNullOrWhiteSpace(textBoxCategoria.Text) ||
                string.IsNullOrWhiteSpace(textBoxTarea.Text) ||
                string.IsNullOrWhiteSpace(textBoxLegajo.Text))
            
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            
            else
            {

                if (!int.TryParse(textBoxDni.Text, out int dni) ||
                   !long.TryParse(textBoxCuil.Text, out long cuil) ||
                   !int.TryParse(textBoxLegajo.Text, out int legajo))
                {
                    MessageBox.Show("DNI, CUIL y Legajo deben ser valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                  mozoCambiado._nombre = textBoxNombre.Text;
                  mozoCambiado._apellido = textBoxApellido.Text;
                  mozoCambiado._dni = int.Parse(textBoxDni.Text);
                  mozoCambiado._cuil = long.Parse(textBoxCuil.Text);
                  mozoCambiado._telefono = textBoxTelefono.Text;
                  mozoCambiado._correo = textBoxCorreo.Text;
                  mozoCambiado._altaEventual = textBoxAltaEventual.Text;
                  mozoCambiado._disponible = checkBoxDisponible.Checked;
                  mozoCambiado._activado = checkBoxActivado.Checked;
                  mozoCambiado._fechaAlta = dateTimePickerFechaAlta.Value;
                  mozoCambiado._fechaNacimiento = dateTimePickerFechaNacimiento.Value;
                  mozoCambiado._categoria = textBoxCategoria.Text;
                  mozoCambiado._tarea = textBoxTarea.Text;
                  mozoCambiado._legajo = int.Parse(textBoxLegajo.Text);


            }





            if (int.Parse(textBoxLegajo.Text) > mozoConec.cantidadMozos()) 
            
            {
            
            mozoConec.agregarMozo(mozoCambiado);
                MessageBox.Show("¡Mozo nuevo agregado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnMozoEditado?.Invoke();
                ActiveForm.Close();

            } 
            
            else
            
            {


            mozoConec.cambiarPropiedad(mozoCambiado);
            MessageBox.Show("¡Cambios guardados exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OnMozoEditado?.Invoke();
            ActiveForm.Close();


           
            }
            
         




        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
           
           
            this.Close();
        }
    }
}
