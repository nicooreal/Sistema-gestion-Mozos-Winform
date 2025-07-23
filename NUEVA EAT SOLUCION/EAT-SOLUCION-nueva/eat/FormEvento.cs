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
    public partial class FormEvento : Form
    {
        private int contadorEvento = 0;

        public FormEvento()
        {
            InitializeComponent();
            cargarGridView();
        }



        public void cargarGridView()
        {
            try
            {
                EventoConexion EventoConec = new EventoConexion();
                List<Evento> lista = EventoConec.listar();
                dataGridViewEventos.DataSource = lista;

                dataGridViewEventos.Columns["_id"].HeaderText = "ID";
                dataGridViewEventos.Columns["_nombre"].HeaderText = "Nombre del Evento";
                dataGridViewEventos.Columns["_fechaInicio"].HeaderText = "Fecha de Inicio";
                dataGridViewEventos.Columns["_fechaFinalizacion"].HeaderText = "Fecha de Finalización";
                dataGridViewEventos.Columns["_lugar"].HeaderText = "Lugar";
                dataGridViewEventos.Columns["_cantidadInvitados"].HeaderText = "Cantidad de Personas";
                dataGridViewEventos.Columns["_tipoEvento"].HeaderText = "Tipo de Evento";
                dataGridViewEventos.Columns["_estado"].HeaderText = "Estado";
                dataGridViewEventos.Columns["_pagaPorHora"].HeaderText = "Paga por Hora";
                dataGridViewEventos.Columns["_presupuesto"].HeaderText = "Presupuesto";
                dataGridViewEventos.Columns["_observacion"].HeaderText = "Observación";
                dataGridViewEventos.Columns["_direccion"].HeaderText = "Direccion";
                dataGridViewEventos.Columns["_cliente"].HeaderText = "Cliente";


                // Ajustar anchos si es necesario
                dataGridViewEventos.Columns["_nombre"].Width = 200;
                dataGridViewEventos.Columns["_lugar"].Width = 150;

                //dataGridViewEventos.Columns["_estado"].DisplayIndex = -1;
                dataGridViewEventos.Columns["_id"].DisplayIndex = 0;
                dataGridViewEventos.Columns["_estado"].DisplayIndex = 1;
                dataGridViewEventos.Columns["_nombre"].DisplayIndex = 2;
                dataGridViewEventos.Columns["_fechaInicio"].DisplayIndex = 3;
                dataGridViewEventos.Columns["_fechaFinalizacion"].DisplayIndex = 4;
                dataGridViewEventos.Columns["_lugar"].DisplayIndex = 5;
                dataGridViewEventos.Columns["_cantidadInvitados"].DisplayIndex = 6;
                dataGridViewEventos.Columns["_tipoEvento"].DisplayIndex = 7;
                dataGridViewEventos.Columns["_pagaPorHora"].DisplayIndex = 8;
                dataGridViewEventos.Columns["_presupuesto"].DisplayIndex = 9;
                dataGridViewEventos.Columns["_observacion"].DisplayIndex = 10;
                dataGridViewEventos.Columns["_direccion"].DisplayIndex = 11;


                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Text = "EDITAR";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.Name = "btnEditar";
                btnEditar.HeaderText = "";
                dataGridViewEventos.Columns.Add(btnEditar);


                DataGridViewButtonColumn btnMozos = new DataGridViewButtonColumn();
                btnMozos.Text = "MOZOS";
                btnMozos.UseColumnTextForButtonValue = true;
                btnMozos.Name = "btnMozos";
                btnMozos.HeaderText = "EQUIPO";
                dataGridViewEventos.Columns.Add(btnMozos);




            }
            catch (Exception)
            {
                throw;
            }
        }







        private void dataGridViewEventos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewEventos.Columns[e.ColumnIndex].Name == "btnEditar" && e.RowIndex >= 0)
            {
                Evento eventoSeleccionado = (Evento)dataGridViewEventos.Rows[e.RowIndex].DataBoundItem;

                formEditarOaltaEvento nuevoFormEditEvento = new formEditarOaltaEvento(eventoSeleccionado);


                nuevoFormEditEvento.OnEventoEditado = () =>
                {
                    cargarGridView();
                };

                nuevoFormEditEvento.ShowDialog();



            }

            if (dataGridViewEventos.Columns[e.ColumnIndex].Name == "btnMozos" && e.RowIndex >= 0)
            {
                Evento eventoSeleccionado = (Evento)dataGridViewEventos.Rows[e.RowIndex].DataBoundItem;

                // Mostrar el formulario de mozos, podés crear este form
                formMozos formMoz = new formMozos(eventoSeleccionado);
                formMoz.ShowDialog();
            }





        }

    }
}
