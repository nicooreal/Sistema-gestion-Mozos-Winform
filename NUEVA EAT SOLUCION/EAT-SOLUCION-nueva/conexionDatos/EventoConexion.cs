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

                Dat.setearConsulta(@"
    SELECT 
        E.Id,
        E.Estado,
        E.Nombre,
        E.FechaInicio,
        E.FechaFinalizacion,
        E.CantidadInvitados,
        E.Direccion,
        E.Observacion,
        E.Lugar,
        E.TipoDeEvento,
        E.Presupuesto,
        E.PagaPorHora,
        C.IdCliente,
        C.Observacion AS ObservacionCliente,
        C.Activo,
        P.IdPersona,
        P.Dni,
        P.Nombre AS NombrePersona,
        P.Apellido,
        P.Cuil,
        P.FechaNacimiento,
        P.Correo,
        P.Telefono
    FROM Evento E
    INNER JOIN Cliente C ON E.ClienteId = C.IdCliente
    INNER JOIN Persona P ON C.IdPersona = P.IdPersona
");

                Dat.ejecutarLectura();
                while (Dat.Lector.Read())
                {
                    Evento eventoAux = new Evento();
                    Cliente clienteAux = new Cliente();
                  
                    eventoAux.cliente = clienteAux;
                    
                    eventoAux.id = (int)Dat.Lector["Id"];
                    eventoAux.estado = (string)Dat.Lector["Estado"];
                    eventoAux.nombre = (string)Dat.Lector["Nombre"];
                    eventoAux.fechaInicio = (DateTime)Dat.Lector["FechaInicio"];
                    eventoAux.fechaFinalizacion = (DateTime)Dat.Lector["FechaFinalizacion"];
                    eventoAux.cantidadInvitados = (int)Dat.Lector["CantidadInvitados"];
                    eventoAux.direccion = (string)Dat.Lector["Direccion"];
                    eventoAux.observacion = (string)Dat.Lector["Observacion"];
                    eventoAux.lugar = (string)Dat.Lector["Lugar"];
                    eventoAux.tipoDeEvento = (string)Dat.Lector["TipoDeEvento"];
                    eventoAux.presupuesto = Convert.ToSingle(Dat.Lector["Presupuesto"]);
                    eventoAux.pagaPorHora = Convert.ToSingle(Dat.Lector["PagaPorHora"]);
                    eventoAux.cliente._idCliente = (int)Dat.Lector["IdCliente"];
                    eventoAux.cliente._observacion = (string)Dat.Lector["ObservacionCliente"];
                    eventoAux.cliente._activo = (bool)Dat.Lector["Activo"];
                    eventoAux.cliente._nombre = (string)Dat.Lector["NombrePersona"];
                    eventoAux.cliente._apellido = (string)Dat.Lector["Apellido"];
                    eventoAux.cliente._dni = (long)Dat.Lector["Dni"];
                    eventoAux.cliente._cuil = (long)Dat.Lector["Cuil"];
                    eventoAux.cliente._fechaNacimiento = (DateTime)Dat.Lector["FechaNacimiento"];
                    eventoAux.cliente._correo = (string)Dat.Lector["Correo"];
                    eventoAux.cliente._telefono = (string)Dat.Lector["Telefono"];




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

                datosEvento.setearParametro("@Estado", evento.estado);
                datosEvento.setearParametro("@Nombre", evento.nombre);
                datosEvento.setearParametro("@FechaInicio", evento.fechaInicio);
                datosEvento.setearParametro("@FechaFinalizacion", evento.fechaFinalizacion);
                datosEvento.setearParametro("@CantidadInvitados", evento.cantidadInvitados);
                datosEvento.setearParametro("@Direccion", evento.direccion);
                datosEvento.setearParametro("@Observacion", evento.observacion);
                datosEvento.setearParametro("@Presupuesto", evento.presupuesto);
                datosEvento.setearParametro("@ClienteId", evento.cliente._idCliente);
                datosEvento.setearParametro("@PagaPorHora", evento.pagaPorHora);
                datosEvento.setearParametro("@Lugar", evento.lugar);
                datosEvento.setearParametro("@TipoDeEvento", evento.tipoDeEvento);
                datosEvento.setearParametro("@Id", evento.id);

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
