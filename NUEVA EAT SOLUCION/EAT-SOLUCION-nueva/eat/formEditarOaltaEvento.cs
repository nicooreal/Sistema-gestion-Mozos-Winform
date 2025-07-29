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


        public Action OnEventoEditado { get; set; } 

        public formEditarOaltaEvento(Evento evento)
        {
            InitializeComponent();
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
            textBoxCliente.Text = evento._cliente._idCliente.ToString();
            textBoxObservacion.Text = evento._observacion;
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
          //  evento._pagaPorHora = float.Parse(textBoxPagaPorHora.Text);
            evento._cliente._idCliente = int.Parse(textBoxCliente.Text);
           



            eventoConec.cambiarPropiedad(evento);



        }
    }
}
