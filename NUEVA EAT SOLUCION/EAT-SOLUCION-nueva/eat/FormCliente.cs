using conexionDatos;
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
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
            cargarGridView();
        }
        public void cargarGridView()
        {
            ClienteConexion clienteConexion = new ClienteConexion();
            List<cliente> lista = clienteConexion.listar();

            // Limpiar el grid por completo
            dataGridViewCliente.DataSource = null;
            dataGridViewCliente.Columns.Clear();
            dataGridViewCliente.AutoGenerateColumns = false;

            // Crear columnas manualmente (en el orden que quieras)

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_idCliente",
                HeaderText = "ID"
            });

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_nombre",
                HeaderText = "Nombre"
            });

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_apellido",
                HeaderText = "Apellido"
            });

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_correo",
                HeaderText = "Correo Electrónico"
            });

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_telefono",
                HeaderText = "Teléfono"
            });

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_Dni",
                HeaderText = "DNI"
            });

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_observacion",
                HeaderText = "Observación"
            });

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_fechaNacimiento",
                HeaderText = "Fecha de Nacimiento"
            });

            dataGridViewCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "_cuil",
                HeaderText = "CUIL"
            });

            // ✅ Columna de botón "Editar" al final
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
            {
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Name = "btnEditar",
                HeaderText = "",
                Width = 80
            };
            dataGridViewCliente.Columns.Add(btnEditar);

            // Asignar el DataSource (ahora no rompe el orden porque las columnas están manuales)
            dataGridViewCliente.DataSource = lista;
        }


        private void dataGridViewCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificá que no sea un clic en el encabezado y que sea la columna del botón
            if (e.RowIndex >= 0 && dataGridViewCliente.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                // Obtener el cliente seleccionado
                var clienteSeleccionado = (cliente)dataGridViewCliente.Rows[e.RowIndex].DataBoundItem;

                // Abrir formulario de edición, pasando el cliente
                FormEditarOaltaCliente formEditar = new FormEditarOaltaCliente(clienteSeleccionado);
              
                formEditar.ShowDialog();
               
                // Volver a cargar los datos después de editar
                cargarGridView();
            }
        }









    }
}
    