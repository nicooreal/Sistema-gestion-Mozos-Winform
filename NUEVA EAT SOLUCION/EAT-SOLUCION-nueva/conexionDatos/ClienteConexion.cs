using DOMINIO;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace conexionDatos
{
    public class ClienteConexion
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("\r\nselect P.Nombre, C.IdCliente, P.Apellido, P.Correo, P.Cuil,  P.Dni, P.FechaNacimiento, P.Telefono, C.Observacion from Cliente C inner join Persona P on C.IdPersona = P.IdPersona");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();

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

        public int cambiarPropiedad(Cliente cliente)
        {
            AccesoDatos datosPersona = new AccesoDatos();
            AccesoDatos datosCliente = new AccesoDatos();

            try
            {
                // Actualiza la tabla Persona usando el IdPersona obtenido a través de Cliente
                datosPersona.setearConsulta(@"
            UPDATE P
            SET 
                P.Dni = @Dni,
                P.Nombre = @Nombre,
                P.Apellido = @Apellido,
                P.Cuil = @Cuil,
                P.FechaNacimiento = @FechaNacimiento,
                P.Correo = @Correo,
                P.Telefono = @Telefono
            FROM Persona P
            INNER JOIN Cliente C ON P.IdPersona = C.IdPersona
            WHERE C.IdCliente = @IdCliente
        ");

                datosPersona.setearParametro("@Dni", cliente._dni);
                datosPersona.setearParametro("@Nombre", cliente._nombre);
                datosPersona.setearParametro("@Apellido", cliente._apellido);
                datosPersona.setearParametro("@Cuil", cliente._cuil);
                datosPersona.setearParametro("@FechaNacimiento", cliente._fechaNacimiento);
                datosPersona.setearParametro("@Correo", cliente._correo);
                datosPersona.setearParametro("@Telefono", cliente._telefono);
                datosPersona.setearParametro("@IdCliente", cliente._idCliente);

                datosPersona.ejecutarAccion();

                // Ahora actualiza la tabla Cliente
                datosCliente.setearConsulta(@"
            UPDATE Cliente
            SET Observacion = @Observacion
            WHERE IdCliente = @IdCliente
        ");

                datosCliente.setearParametro("@Observacion", cliente._observacion);
                datosCliente.setearParametro("@IdCliente", cliente._idCliente);

                datosCliente.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosPersona.cerrarConexion();
                datosCliente.cerrarConexion();
            }

            return 0;
        }


        public void agregarCliente(Cliente clienteNuevo)
        {
            AccesoDatos datosPersona = new AccesoDatos();
            AccesoDatos datosCliente = new AccesoDatos();

            try
            {
                // INSERTAR EN PERSONA Y OBTENER IdPersona
                datosPersona.setearConsulta(@"INSERT INTO Persona (Dni, Nombre, Apellido, Cuil, FechaNacimiento, Correo, Telefono) 
                                      OUTPUT INSERTED.IdPersona 
                                      VALUES (@Dni, @Nombre, @Apellido, @Cuil, @FechaNacimiento, @Correo, @Telefono)");

                datosPersona.setearParametro("@Dni", clienteNuevo._dni);
                datosPersona.setearParametro("@Nombre", clienteNuevo._nombre);
                datosPersona.setearParametro("@Apellido", clienteNuevo._apellido);
                datosPersona.setearParametro("@Cuil", clienteNuevo._cuil);
                datosPersona.setearParametro("@FechaNacimiento", clienteNuevo._fechaNacimiento);
                datosPersona.setearParametro("@Correo", clienteNuevo._correo);
                datosPersona.setearParametro("@Telefono", clienteNuevo._telefono);

                int idPersona = (int)datosPersona.ejecutarScalar(); // ← Obtener el IdPersona insertado

                // INSERTAR EN CLIENTE
                datosCliente.setearConsulta(@"INSERT INTO Cliente (IdPersona, Observacion) 
                                      VALUES (@IdPersona, @Observacion)");

                datosCliente.setearParametro("@IdPersona", idPersona);
                datosCliente.setearParametro("@Observacion", clienteNuevo._observacion);

                datosCliente.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosPersona.cerrarConexion();
                datosCliente.cerrarConexion();
            }
        }

        public int obtenerUltimoIdCliente()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ISNULL(MAX(IdCliente), 0) FROM Cliente");
                return (int)datos.ejecutarScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }






    }
}
