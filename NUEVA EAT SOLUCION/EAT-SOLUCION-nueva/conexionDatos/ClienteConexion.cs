using DOMINIO;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace conexionDatos
{
    public class ClienteConexion
    {
        public List<cliente> listar()
        {
            List<cliente> lista = new List<cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("\r\nselect P.Nombre, C.IdCliente, P.Apellido, P.Correo, P.Cuil,  P.Dni, P.FechaNacimiento, P.Telefono, C.Observacion from Cliente C inner join Persona P on C.IdPersona = P.IdPersona");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cliente cliente = new cliente();

                    cliente._idCliente = (int)datos.Lector["IdCliente"];
                    cliente._nombre = datos.Lector["Nombre"].ToString();
                    cliente._apellido = datos.Lector["Apellido"].ToString();
                    cliente._correo = datos.Lector["Correo"].ToString();
                    cliente._telefono = datos.Lector["Telefono"].ToString();
                    cliente._dni = (long)datos.Lector["Dni"];
                    cliente._cuil = (long)datos.Lector["Cuil"];
                    cliente._fechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    cliente._observacion = datos.Lector["Observacion"].ToString();
                    



                    lista.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public int cambiarPropiedad(cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                    UPDATE Cliente
                    SET 
                        Nombre = @Nombre,
                        Apellido = @Apellido,
                        CorreoElectronico = @Correo,
                        Telefono = @Telefono
                    WHERE Id = @Id
                ");

                datos.setearParametro("@Nombre", cliente._nombre);
                datos.setearParametro("@Apellido", cliente._apellido);
                datos.setearParametro("@Correo", cliente._correo);
                datos.setearParametro("@Telefono", cliente._telefono);
                datos.setearParametro("@Id", cliente._idCliente);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }
    }
}
