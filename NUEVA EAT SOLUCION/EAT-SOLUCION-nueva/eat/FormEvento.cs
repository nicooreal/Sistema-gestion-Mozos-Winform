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


        private void FormEvento_Load(object sender, EventArgs e)
        {
            cargarGridView();
        }

        public FormEvento()
        {
            this.StartPosition = FormStartPosition.CenterScreen; // opcional
          //  this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Load += FormEvento_Load; 
        }

        public void cargarGridView()
        {
            try
            {
                EventoConexion EventoConec = new EventoConexion();
                List<Evento> lista = EventoConec.listar();

                // Asignar fuente de datos
                dataGridViewEventos.DataSource = lista;

                // Forzar que termine el binding/creación de columnas antes de manipularlas
                dataGridViewEventos.Refresh();
                Application.DoEvents();

                // --- COMPORTAMIENTO: columnas al mínimo, contenido visible ---
                // 1) Permitir wrap para que el texto largo se muestre en varias líneas
                dataGridViewEventos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewEventos.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

                // 2) Autoajustar la altura de las filas para mostrar todo el texto
                dataGridViewEventos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // 3) Calcular el ancho mínimo necesario por contenido (no usar Fill aquí)
                dataGridViewEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridViewEventos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // 4) Poner un mínimo razonable por columna para que no queden ridículamente angostas
                if (dataGridViewEventos.Columns.Contains("_id"))
                    dataGridViewEventos.Columns["_id"].MinimumWidth = 50;
                if (dataGridViewEventos.Columns.Contains("_estado"))
                    dataGridViewEventos.Columns["_estado"].MinimumWidth = 80;
                if (dataGridViewEventos.Columns.Contains("_nombre"))
                    dataGridViewEventos.Columns["_nombre"].MinimumWidth = 150;
                if (dataGridViewEventos.Columns.Contains("_observacion"))
                    dataGridViewEventos.Columns["_observacion"].MinimumWidth = 180;

                // --- Encabezados (solo si existen) ---
                if (dataGridViewEventos.Columns.Contains("_id"))
                    dataGridViewEventos.Columns["_id"].HeaderText = "ID";
                if (dataGridViewEventos.Columns.Contains("_nombre"))
                    dataGridViewEventos.Columns["_nombre"].HeaderText = "Nombre del Evento";
                if (dataGridViewEventos.Columns.Contains("_fechaInicio"))
                    dataGridViewEventos.Columns["_fechaInicio"].HeaderText = "Fecha de Inicio";
                if (dataGridViewEventos.Columns.Contains("_fechaFinalizacion"))
                    dataGridViewEventos.Columns["_fechaFinalizacion"].HeaderText = "Fecha de Finalización";
                if (dataGridViewEventos.Columns.Contains("_lugar"))
                    dataGridViewEventos.Columns["_lugar"].HeaderText = "Lugar";
                if (dataGridViewEventos.Columns.Contains("_cantidadInvitados"))
                    dataGridViewEventos.Columns["_cantidadInvitados"].HeaderText = "Cantidad de Personas";
                if (dataGridViewEventos.Columns.Contains("_tipoEvento"))
                    dataGridViewEventos.Columns["_tipoEvento"].HeaderText = "Tipo de Evento";
                if (dataGridViewEventos.Columns.Contains("_estado"))
                    dataGridViewEventos.Columns["_estado"].HeaderText = "Estado";
                if (dataGridViewEventos.Columns.Contains("_pagaPorHora"))
                    dataGridViewEventos.Columns["_pagaPorHora"].HeaderText = "Paga por Hora";
                if (dataGridViewEventos.Columns.Contains("_presupuesto"))
                    dataGridViewEventos.Columns["_presupuesto"].HeaderText = "Presupuesto";
                if (dataGridViewEventos.Columns.Contains("_observacion"))
                    dataGridViewEventos.Columns["_observacion"].HeaderText = "Observación";
                if (dataGridViewEventos.Columns.Contains("_direccion"))
                    dataGridViewEventos.Columns["_direccion"].HeaderText = "Dirección";
                if (dataGridViewEventos.Columns.Contains("ClienteNombre"))
                    dataGridViewEventos.Columns["ClienteNombre"].HeaderText = "Cliente";

                if (dataGridViewEventos.Columns.Contains("_cliente"))
                    dataGridViewEventos.Columns.Remove("_cliente");

                // Ajuste fino: asegurar que algunas columnas tengan al menos un ancho razonable
                if (dataGridViewEventos.Columns.Contains("_nombre"))
                    dataGridViewEventos.Columns["_nombre"].Width = Math.Max(dataGridViewEventos.Columns["_nombre"].Width, 150);
                if (dataGridViewEventos.Columns.Contains("_lugar"))
                    dataGridViewEventos.Columns["_lugar"].Width = Math.Max(dataGridViewEventos.Columns["_lugar"].Width, 120);
                if (dataGridViewEventos.Columns.Contains("_observacion"))
                    dataGridViewEventos.Columns["_observacion"].Width = Math.Max(dataGridViewEventos.Columns["_observacion"].Width, 180);

                // DisplayIndex (solo si existen)
                if (dataGridViewEventos.Columns.Contains("_id")) dataGridViewEventos.Columns["_id"].DisplayIndex = 0;
                if (dataGridViewEventos.Columns.Contains("_estado")) dataGridViewEventos.Columns["_estado"].DisplayIndex = 1;
                if (dataGridViewEventos.Columns.Contains("_nombre")) dataGridViewEventos.Columns["_nombre"].DisplayIndex = 2;
                if (dataGridViewEventos.Columns.Contains("_fechaInicio")) dataGridViewEventos.Columns["_fechaInicio"].DisplayIndex = 3;
                if (dataGridViewEventos.Columns.Contains("_fechaFinalizacion")) dataGridViewEventos.Columns["_fechaFinalizacion"].DisplayIndex = 4;
                if (dataGridViewEventos.Columns.Contains("_lugar")) dataGridViewEventos.Columns["_lugar"].DisplayIndex = 5;
                if (dataGridViewEventos.Columns.Contains("_cantidadInvitados")) dataGridViewEventos.Columns["_cantidadInvitados"].DisplayIndex = 6;
                if (dataGridViewEventos.Columns.Contains("_tipoEvento")) dataGridViewEventos.Columns["_tipoEvento"].DisplayIndex = 7;
                if (dataGridViewEventos.Columns.Contains("_pagaPorHora")) dataGridViewEventos.Columns["_pagaPorHora"].DisplayIndex = 8;
                if (dataGridViewEventos.Columns.Contains("_presupuesto")) dataGridViewEventos.Columns["_presupuesto"].DisplayIndex = 9;
                if (dataGridViewEventos.Columns.Contains("_observacion")) dataGridViewEventos.Columns["_observacion"].DisplayIndex = 10;
                if (dataGridViewEventos.Columns.Contains("_direccion")) dataGridViewEventos.Columns["_direccion"].DisplayIndex = 11;

                // --- Botones: agregarlos solo si no existen (evita duplicados / reordenamiento) ---
                if (!dataGridViewEventos.Columns.Contains("btnEditar"))
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
                    {
                        Text = "EDITAR",
                        UseColumnTextForButtonValue = true,
                        Name = "btnEditar",
                        HeaderText = ""
                    };
                    dataGridViewEventos.Columns.Add(btnEditar);
                }

                if (!dataGridViewEventos.Columns.Contains("btnMozos"))
                {
                    DataGridViewButtonColumn btnMozos = new DataGridViewButtonColumn
                    {
                        Text = "MOZOS",
                        UseColumnTextForButtonValue = true,
                        Name = "btnMozos",
                        HeaderText = "EQUIPO"
                    };
                    dataGridViewEventos.Columns.Add(btnMozos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando eventos: " + ex.Message);
            }


            // --- FORZAR ORDEN FINAL DE COLUMNAS (evita que Cliente se vaya al final) ---
            string clienteColName = null;
            if (dataGridViewEventos.Columns.Contains("Cliente")) clienteColName = "Cliente";
            else if (dataGridViewEventos.Columns.Contains("colCliente")) clienteColName = "colCliente";
            else if (dataGridViewEventos.Columns.Contains("ClienteNombre")) clienteColName = "ClienteNombre";

            // Lista del orden deseado (ajustala si querés cambiar posiciones)
            var ordenDeseado = new List<string>()
{
    "_id",
    "_estado",
    "_nombre",
    "_fechaInicio",
    "_fechaFinalizacion",
    "_lugar",
    "_cantidadInvitados",
    "_tipoEvento",
    "_pagaPorHora",
    "_presupuesto",
    "_observacion",
    "_direccion"
};

            // si existe la columna cliente, la insertamos donde corresponde
            if (!string.IsNullOrEmpty(clienteColName)) ordenDeseado.Add(clienteColName);

            // por último los botones (o donde quieras que estén)
            ordenDeseado.Add("btnEditar");
            ordenDeseado.Add("btnMozos");

            // Asignar DisplayIndex en orden (solo si la columna existe)
            int idx = 0;
            foreach (var colName in ordenDeseado)
            {
                if (dataGridViewEventos.Columns.Contains(colName))
                {
                    try
                    {
                        dataGridViewEventos.Columns[colName].DisplayIndex = idx;
                        idx++;
                    }
                    catch
                    {
                        // en casos raros puede lanzar si otro DisplayIndex está en uso; lo ignoramos
                        // pero normalmente esto funciona bien porque recorremos el orden final
                    }
                }
            }

            // --- Asegurar ancho estable para las columnas botón ---
            if (dataGridViewEventos.Columns.Contains("btnEditar"))
            {
                var c = dataGridViewEventos.Columns["btnEditar"];
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // no permitir autosize automático
                c.Width = 80;          // ancho en píxeles, ajustá al valor que quieras
                c.MinimumWidth = 70;   // evita que se reduzca demasiado
                c.Resizable = DataGridViewTriState.False;
            }

            if (dataGridViewEventos.Columns.Contains("btnMozos"))
            {
                var c2 = dataGridViewEventos.Columns["btnMozos"];
                c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                c2.Width = 80;         // o 70, 90 según prefieras
                c2.MinimumWidth = 70;
                c2.Resizable = DataGridViewTriState.False;
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
