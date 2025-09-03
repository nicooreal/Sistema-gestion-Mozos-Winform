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
            textBoxID.Text = evento.id.ToString();
            textBoxID.ReadOnly = true;

            dateTimePickerFechaFinal.Value = evento.fechaInicio;
            dateTimePickerFechaInicio.Value = evento.fechaFinalizacion;
            textBoxCantidadDeInvitados.Text = evento.cantidadInvitados.ToString();
            textBoxDireccion.Text = evento.direccion;
            textBoxNombre.Text = evento.nombre;
            textBoxPresupuesto.Text = evento.presupuesto.ToString();
            textBoxTipoEvento.Text = evento.tipoDeEvento;
            textBoxLugar.Text = evento.lugar;
            textBoxEstado.Text = evento.estado;
            //    textBoxCliente.Text = evento._cliente._idCliente.ToString();
            textBoxObservacion.Text = evento.observacion;
            textBoxPaga.Text = evento.pagaPorHora.ToString();

        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            EventoConexion eventoConec = new EventoConexion();
            Evento evento = new Evento();


            evento.id = int.Parse(textBoxID.Text);
            evento.estado = textBoxEstado.Text;
            evento.nombre = textBoxNombre.Text;
            evento.fechaInicio = dateTimePickerFechaInicio.Value;
            evento.fechaFinalizacion = dateTimePickerFechaFinal.Value;
            evento.cantidadInvitados = int.Parse(textBoxCantidadDeInvitados.Text);
            evento.direccion = textBoxDireccion.Text;
            evento.observacion = textBoxObservacion.Text;
            evento.lugar = textBoxLugar.Text;
            evento.tipoDeEvento = textBoxTipoEvento.Text;
            evento.presupuesto = float.Parse(textBoxPresupuesto.Text);
            evento.pagaPorHora = float.Parse(textBoxPaga.Text);
        

            var cli = comboBoxCliente.SelectedItem as Cliente;

            evento.cliente = new Cliente();
            evento.cliente._idCliente = cli._idCliente;


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
