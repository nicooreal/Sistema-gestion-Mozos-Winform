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
            EventoMozoConexion conec = new EventoMozoConexion();
            
             EventoMozo eveMoz = new EventoMozo();
            List<EventoMozo> lista = conec.listarPorEvento(idEvento);

          

            var vm = lista.Select(x => new
            {
                x.EventoId,
                x.LegajoMozo,
                x.HorarioEntrada,
                x.HorarioSalida,
                x.Plus,
                x.RolDelPersonal,

                // 🔽 columnas “planas” que salen de la propiedad calculada y de Mozo
                Mozo = x.MozoDisplay,
                Categoria = x.Mozo?._categoria,
                Tarea = x.Mozo?._tarea,
                Disponible = x.Mozo?._disponible,
                Activado = x.Mozo?._activado,
                DNI = x.Mozo?._dni,
                CUIL = x.Mozo?._cuil,
                Correo = x.Mozo?._correo,
                Telefono = x.Mozo?._telefono
            }).ToList();

            dataGridViewEventoMozo.AutoGenerateColumns = true;   // o false si querés armar columnas a mano
            dataGridViewEventoMozo.DataSource = vm;

            // (Opcional) formatos
    

        }






    }
}
