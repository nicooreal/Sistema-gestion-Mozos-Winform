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
            List<Cliente> lista = clienteConexion.listar();
            dataGridViewCliente.DataSource = lista;
            dataGridViewCliente.Columns["_idCliente"].HeaderText = "ID";
            dataGridViewCliente.Columns["_nombre"].HeaderText = "Nombre";
            dataGridViewCliente.Columns["_apellido"].HeaderText = "Apellido";
            dataGridViewCliente.Columns["_correo"].HeaderText = "Correo Electrónico";
            dataGridViewCliente.Columns["_telefono"].HeaderText = "Teléfono";
            dataGridViewCliente.Columns["_Dni"].HeaderText = "DNI";
            dataGridViewCliente.Columns["_observacion"].HeaderText = "observacion";
            dataGridViewCliente.Columns["_fechaNacimiento"].HeaderText = "Fecha de nacimiento";
            dataGridViewCliente.Columns["_cuil"].HeaderText = "Cuil";

            dataGridViewCliente.Columns["_idCliente"].DisplayIndex = 0;
            dataGridViewCliente.Columns["_nombre"].DisplayIndex = 1;
            dataGridViewCliente.Columns["_apellido"].DisplayIndex = 2;
            dataGridViewCliente.Columns["_correo"].DisplayIndex = 3;
            dataGridViewCliente.Columns["_telefono"].DisplayIndex = 4;










        }
    }
}
    