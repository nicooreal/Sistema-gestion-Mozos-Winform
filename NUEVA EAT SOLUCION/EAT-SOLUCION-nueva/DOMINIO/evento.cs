using System.Collections.Generic;
using System;

namespace DOMINIO
{
    public class Evento
    {
        public string _estado { get; set; }
        public string _nombre { get; set; }

        public int _id { get; set; }

        public DateTime _fechaInicio { get; set; }

        public DateTime _fechaFinalizacion { get; set; }

        public List<cliente> _mozos { get; set; }

        public int _cantidadInvitados { get; set; }

        public string _direccion { get; set; }

        public string _observacion { get; set; }

        public float _pagaPorHora { get; set; }
        public float _presupuesto { get; set; }

        public string _tipoEvento { get; set; }

        public string _lugar { get; set; }

        public cliente _cliente { get; set; }


    
    }
}
