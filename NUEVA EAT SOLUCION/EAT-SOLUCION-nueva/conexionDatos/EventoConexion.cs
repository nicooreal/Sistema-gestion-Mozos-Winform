using DOMINIO;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionDatos
{
    public class EventoConexion
    {

        List<Evento> lista = new List<Evento>();
        AccesoDatos Dat = new AccesoDatos();
        public List<Evento> listar()
        {
            try
            {

                Dat.setearConsulta("SELECT * FROM Evento");
                Dat.ejecutarLectura();
                while (Dat.Lector.Read())
                {
                    Evento eventoAux = new Evento();
                    cliente clienteAux = new cliente();
                  
                    eventoAux._cliente = clienteAux;
                    
                    eventoAux._id = (int)Dat.Lector["Id"];
                    eventoAux._estado = (string)Dat.Lector["Estado"];
                    eventoAux._nombre = (string)Dat.Lector["Nombre"];
                    eventoAux._fechaInicio = (DateTime)Dat.Lector["FechaInicio"];
                    eventoAux._fechaFinalizacion = (DateTime)Dat.Lector["FechaFinalizacion"];
                    eventoAux._cantidadInvitados = (int)Dat.Lector["CantidadInvitados"];
                    eventoAux._direccion = (string)Dat.Lector["Direccion"];
                    eventoAux._observacion = (string)Dat.Lector["Observacion"];
                    eventoAux._lugar = (string)Dat.Lector["Lugar"];
                    eventoAux._tipoEvento = (string)Dat.Lector["TipoDeEvento"];
                    eventoAux._presupuesto = Convert.ToSingle(Dat.Lector["Presupuesto"]);
                    eventoAux._pagaPorHora = Convert.ToSingle(Dat.Lector["PagaPorHora"]);
                    eventoAux._cliente._idCliente = (int)Dat.Lector["ClienteId"];






                    lista.Add(eventoAux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dat.cerrarConexion();
            }
            return lista;
        }





        public int cambiarPropiedad(Evento evento)
        {
            AccesoDatos datosEvento = new AccesoDatos();

            try
            {
                datosEvento.setearConsulta(@"
            UPDATE Evento
            SET 
                Estado = @Estado,
                Nombre = @Nombre,
                FechaInicio = @FechaInicio,
                FechaFinalizacion = @FechaFinalizacion,
                CantidadInvitados = @CantidadInvitados,
                Direccion = @Direccion,
                Observacion = @Observacion,
                Presupuesto = @Presupuesto,
                ClienteId = @ClienteId,
                PagaPorHora = @PagaPorHora,
                Lugar = @Lugar,
                TipoDeEvento = @TipoDeEvento
            WHERE Id = @Id
        ");

                datosEvento.setearParametro("@Estado", evento._estado);
                datosEvento.setearParametro("@Nombre", evento._nombre);
                datosEvento.setearParametro("@FechaInicio", evento._fechaInicio);
                datosEvento.setearParametro("@FechaFinalizacion", evento._fechaFinalizacion);
                datosEvento.setearParametro("@CantidadInvitados", evento._cantidadInvitados);
                datosEvento.setearParametro("@Direccion", evento._direccion);
                datosEvento.setearParametro("@Observacion", evento._observacion);
                datosEvento.setearParametro("@Presupuesto", evento._presupuesto);
                datosEvento.setearParametro("@ClienteId", evento._cliente._idCliente);
                datosEvento.setearParametro("@PagaPorHora", evento._pagaPorHora);
                datosEvento.setearParametro("@Lugar", evento._lugar);
                datosEvento.setearParametro("@TipoDeEvento", evento._tipoEvento);
                datosEvento.setearParametro("@Id", evento._id);

                datosEvento.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }














    }
}
