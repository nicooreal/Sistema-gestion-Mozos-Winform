using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Mozo : Persona

    {
        public int _legajo { get; set; }
        public bool _activado { get; set; }
        public bool _disponible { get; set; }
        public string _categoria { get; set; }
        public string _tarea { get; set; }
        public DateTime _fechaAlta { get; set; }

        public string _altaEventual { get; set; }



    }
}
