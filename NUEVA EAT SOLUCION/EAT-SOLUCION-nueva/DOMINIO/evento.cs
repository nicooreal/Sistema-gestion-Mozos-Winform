using System.Collections.Generic;
using System;

namespace DOMINIO
{
    public class Evento
    {
        public string estado { get; set; }
        public string nombre { get; set; }

        public int id { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFinalizacion { get; set; }

        public List<Cliente> mozos { get; set; }

        public int cantidadInvitados { get; set; }

        public string direccion { get; set; }

        public string observacion { get; set; }

        public float pagaPorHora { get; set; }
        public float presupuesto { get; set; }

        public string tipoDeEvento { get; set; }

        public string lugar { get; set; }

        public Cliente cliente { get; set; }

        public string ClienteNombre => cliente?._nombre + " " + cliente?._apellido;



    }
}
