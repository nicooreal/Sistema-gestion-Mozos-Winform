using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONEXIONDATOS;
using DOMINIO;

namespace eat
{
    public partial class formMozos : Form
    {
        private int contador = 0;

        private Evento eventoSeleccionado;

        public formMozos()
        {
          
            InitializeComponent();
        }

       
        public formMozos(Evento evento)
        {
            InitializeComponent();
            this.eventoSeleccionado = evento;

            //if (eventoSeleccionado != null)
            //    cargarGridViewMozosPorEvento(eventoSeleccionado._id);
          
        }

        
        
        private void formMozos_Load(object sender, EventArgs e)
        {

            try
            {
               // if (eventoSeleccionado != null)
               // {
               //     // Mostrar SOLO los mozos del evento
               //cargaColumnasDeGridView();
               //     cargarGridViewMozosPorEvento(eventoSeleccionado._id);
               // }
               // else
               // {
               //     // Modo general: todos / activados / etc.
               // }
                    cargarGridViewNormal();
            }
            catch (Exception)
            {
                throw;
            }


        }

        
        //public void cargarGridViewMozosPorEvento(int idEvento)
        //{
        //    MozoConexion conec = new MozoConexion();
        //    List<Mozo> lista = conec.listarPorEvento(idEvento);

        //    dataGridViewMozos.ClearSelection();
        //    dataGridViewMozos.DataSource = lista;
        //   // cargaColumnasDeGridView();
        //}






        public void cargarGridViewMozosActivados()
        {
         


                MozoConexion conec = new MozoConexion();
                List<Mozo> lista = conec.listarActivados();
                dataGridViewMozos.DataSource = lista;
                cargaColumnasDeGridView();
        }



        public void cargarGridViewMozosDisponibles()
        {
            try
            {


                MozoConexion conec = new MozoConexion();
                List<Mozo> lista = conec.listarDisponibles();
                dataGridViewMozos.DataSource = lista;
               // cargaColumnasDeGridView();


            }
            catch (Exception)
            {
                throw;
            }
        }




  public void cargaColumnasDeGridView()
        {
            try
            {



                dataGridViewMozos.Columns["_legajo"].HeaderText = "Legajo";
                dataGridViewMozos.Columns["_nombre"].HeaderText = "Nombre";
                dataGridViewMozos.Columns["_apellido"].HeaderText = "Apellido";
                dataGridViewMozos.Columns["_dni"].HeaderText = "DNI";
                dataGridViewMozos.Columns["_cuil"].HeaderText = "CUIL";
                dataGridViewMozos.Columns["_disponible"].HeaderText = "Disponible";
                dataGridViewMozos.Columns["_correo"].HeaderText = "Correo Electrónico";
                dataGridViewMozos.Columns["_telefono"].HeaderText = "Teléfono";
                dataGridViewMozos.Columns["_activado"].HeaderText = "Activado";
                dataGridViewMozos.Columns["_altaEventual"].HeaderText = "Alta Eventual";
                dataGridViewMozos.Columns["_fechaNacimiento"].HeaderText = "Fecha de Nacimiento";
                dataGridViewMozos.Columns["_fechaAlta"].HeaderText = "Fecha de Alta";
                dataGridViewMozos.Columns["_tarea"].HeaderText = "Tarea";
                dataGridViewMozos.Columns["_categoria"].HeaderText = "Categoría";






                dataGridViewMozos.Columns["_tarea"].Width = 250; // Cuarta columna



                dataGridViewMozos.Columns["_legajo"].DisplayIndex = 0; // Cuarta columna

                dataGridViewMozos.Columns["_nombre"].DisplayIndex = 1; // Primera columna

                dataGridViewMozos.Columns["_apellido"].DisplayIndex = 2; // Segunda columna

                dataGridViewMozos.Columns["_activado"].DisplayIndex = 3; // Cuarta columna

                dataGridViewMozos.Columns["_cuil"].DisplayIndex = 4; // Cuarta columna


                dataGridViewMozos.Columns["_disponible"].DisplayIndex = 5; // Cuarta columna

                dataGridViewMozos.Columns["_correo"].DisplayIndex = 6; // Cuarta columna

                dataGridViewMozos.Columns["_telefono"].DisplayIndex = 7; // Cuarta columna

                dataGridViewMozos.Columns["_dni"].DisplayIndex = 8; // Tercera columna


                dataGridViewMozos.Columns["_altaEventual"].DisplayIndex = 9; // Cuarta columna

                dataGridViewMozos.Columns["_fechaNacimiento"].DisplayIndex = 10; // Cuarta columna

                dataGridViewMozos.Columns["_fechaAlta"].DisplayIndex = 11; // Cuarta columna

                dataGridViewMozos.Columns["_tarea"].DisplayIndex = 12; // Cuarta columna

                dataGridViewMozos.Columns["_categoria"].DisplayIndex = 13; // Cuarta columna



                // Agregar una columna con botón
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();

                if (contador == 0)
                {
                    btnEditar.Text = "editar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    btnEditar.Name = "btnEditar";
                    btnEditar.HeaderText = "";
                    dataGridViewMozos.Columns.Add(btnEditar);
                    contador++;
                }
                else
                {
                    btnEditar.HeaderText = "";
                }
            }

            catch (Exception)
            {
                throw;
            }

        }


        public void cargarGridViewNormal()
        {
        
                

                MozoConexion conec = new MozoConexion();
                List<Mozo> lista = conec.listar();
                dataGridViewMozos.DataSource = lista;
                cargaColumnasDeGridView();
               
        }


        private void dataGridViewMozos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMozos.Columns[e.ColumnIndex].Name == "btnEditar" && e.RowIndex >= 0)
            {
              
               Mozo mozoSeleccionado = (Mozo)dataGridViewMozos.Rows[e.RowIndex].DataBoundItem;

                formEditarOaltaMozo nuevoFormEditMozo = new formEditarOaltaMozo(mozoSeleccionado);


                nuevoFormEditMozo.OnMozoEditado = () =>
                {
                    cargarGridViewNormal();
                };

                nuevoFormEditMozo.ShowDialog();


              
           
            
            
            
            }
        }

        private void aGREGARMOZOToolStripMenuItem_Click(object sender, EventArgs e)
        {

            formEditarOaltaMozo nuevoForm = new formEditarOaltaMozo(null);
            nuevoForm.ShowDialog();
            cargarGridViewNormal();
        }

        private void lISTARDISPONIBLESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarGridViewMozosActivados();
        }

        private void lISTARDISPONIBLESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cargarGridViewMozosDisponibles();
        }

        private void lISTARTODOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarGridViewNormal();
        }
    }
}
