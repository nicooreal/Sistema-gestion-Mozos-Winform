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
    public partial class formEditarOaltaEvento : Form
    {
        private List<Cliente> _clientes;

        public Action OnEventoEditado { get; set; }


        //private void formEditarEvento_Load(object sender, EventArgs e)
        //{
        //    CargarComboClientes();
        //    // Si estás en modo edición, seleccioná el cliente del evento:
        //    //if (eventoSeleccionado != null)
        //    //    comboCliente.SelectedValue = eventoSeleccionado._cliente._idCliente;
        //}




        public formEditarOaltaEvento(Evento evento)
        {
            InitializeComponent();
            CargarComboClientes();
            textBoxID.Text = evento._id.ToString();
            textBoxID.ReadOnly = true;

            dateTimePickerFechaFinal.Value = evento._fechaInicio;
            dateTimePickerFechaInicio.Value = evento._fechaFinalizacion;
            textBoxCantidadDeInvitados.Text = evento._cantidadInvitados.ToString();
            textBoxDireccion.Text = evento._direccion;
            textBoxNombre.Text = evento._nombre;
            textBoxPresupuesto.Text = evento._presupuesto.ToString();
            textBoxTipoEvento.Text = evento._tipoEvento;
            textBoxLugar.Text = evento._lugar;
            textBoxEstado.Text = evento._estado;
            //    textBoxCliente.Text = evento._cliente._idCliente.ToString();
            textBoxObservacion.Text = evento._observacion;
            textBoxPaga.Text = evento._pagaPorHora.ToString();

        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            EventoConexion eventoConec = new EventoConexion();
            Evento evento = new Evento();


            evento._id = int.Parse(textBoxID.Text);
            evento._estado = textBoxEstado.Text;
            evento._nombre = textBoxNombre.Text;
            evento._fechaInicio = dateTimePickerFechaInicio.Value;
            evento._fechaFinalizacion = dateTimePickerFechaFinal.Value;
            evento._cantidadInvitados = int.Parse(textBoxCantidadDeInvitados.Text);
            evento._direccion = textBoxDireccion.Text;
            evento._observacion = textBoxObservacion.Text;
            evento._lugar = textBoxLugar.Text;
            evento._tipoEvento = textBoxTipoEvento.Text;
            evento._presupuesto = float.Parse(textBoxPresupuesto.Text);
            evento._pagaPorHora = float.Parse(textBoxPaga.Text);
        

            var cli = comboBoxCliente.SelectedItem as Cliente;

            evento._cliente = new Cliente();
            evento._cliente._idCliente = cli._idCliente;


            eventoConec.cambiarPropiedad(evento);

            MessageBox.Show("Los cambios se han guardado correctamente.", "Edición Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

            OnEventoEditado?.Invoke();
          
   
        }
        private void CargarComboClientes()
        {
            var cliRepo = new ClienteConexion();
            _clientes = cliRepo.listar();

            comboBoxCliente.DataSource = _clientes;
            comboBoxCliente.DisplayMember = "NombreCompleto"; // o "Nombre" si no agregás la propiedad
            comboBoxCliente.ValueMember = "_idCliente";

            // Si querés que se despliegue al hacer foco:
            comboBoxCliente.GotFocus += (s, e) => comboBoxCliente.DroppedDown = true;


        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No se han guardado los cambios.", "Edición Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
        }
    }
}
