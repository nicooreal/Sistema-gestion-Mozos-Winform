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
    public partial class FormMozoEvento : Form
    {
        
        Evento eventoSeleccionado;

        public FormMozoEvento()
        {
            InitializeComponent();
        }


        public FormMozoEvento(Evento eventoSeleccionado)
        {
            InitializeComponent();
            this.eventoSeleccionado = eventoSeleccionado;
           cargarGridViewMozosPorEvento(eventoSeleccionado.id);
        }


        public void cargarGridViewMozosPorEvento(int idEvento)
        {
            MozoConexion conec = new MozoConexion();
            List<Mozo> lista = conec.listarPorEvento(idEvento);

         //   dataGridViewEventoMozo.ClearSelection();
            dataGridViewEventoMozo.DataSource = lista;
            // cargaColumnasDeGridView();
        }






    }
}
