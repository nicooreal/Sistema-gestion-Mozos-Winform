using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class EventoMozo
    {
        public int EventoId { get; set; }
        public int LegajoMozo { get; set; }
     

        public DateTime HorarioEntrada { get; set; }
        public DateTime HorarioSalida { get; set; }
        public decimal Plus { get; set; }
        public string RolDelPersonal { get; set; }

        public Evento Evento { get; set; }

        public Mozo Mozo { get; set; }
    }
}
