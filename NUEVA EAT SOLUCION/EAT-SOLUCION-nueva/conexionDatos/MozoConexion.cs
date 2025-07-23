using DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using negocio;

namespace CONEXIONDATOS
{
    public class MozoConexion
    {


        public void agregarMozo(Mozo mozoNuevo)
        {
            AccesoDatos datosPersona = new AccesoDatos();
            AccesoDatos datosMozo = new AccesoDatos();

            try
            {
                // INSERTAR EN PERSONA Y OBTENER IdPersona
                datosPersona.setearConsulta(@"INSERT INTO Persona (Dni, Nombre, Apellido, Cuil, FechaNacimiento, Correo, Telefono) 
                                      OUTPUT INSERTED.IdPersona 
                                      VALUES (@Dni, @Nombre, @Apellido, @Cuil, @FechaNacimiento, @Correo, @Telefono)");

                datosPersona.setearParametro("@Dni", mozoNuevo._dni);
                datosPersona.setearParametro("@Nombre", mozoNuevo._nombre);
                datosPersona.setearParametro("@Apellido", mozoNuevo._apellido);
                datosPersona.setearParametro("@Cuil", mozoNuevo._cuil);
                datosPersona.setearParametro("@FechaNacimiento", mozoNuevo._fechaNacimiento);
                datosPersona.setearParametro("@Correo", mozoNuevo._correo);
                datosPersona.setearParametro("@Telefono", mozoNuevo._telefono);

                int idPersona = (int)datosPersona.ejecutarScalar(); // ← Obtener el IdPersona insertado

                // INSERTAR EN MOZO
                datosMozo.setearConsulta(@"INSERT INTO Mozo (Activado, Disponible, Categoria, Tarea, FechaAlta, AltaEventual, IdPersona) 
                                   VALUES ( @Activado, @Disponible, @Categoria, @Tarea, @FechaAlta, @AltaEventual, @IdPersona)");

             
                datosMozo.setearParametro("@Activado", mozoNuevo._activado);
                datosMozo.setearParametro("@Disponible", mozoNuevo._disponible);
                datosMozo.setearParametro("@Categoria", mozoNuevo._categoria);
                datosMozo.setearParametro("@Tarea", mozoNuevo._tarea);
                datosMozo.setearParametro("@FechaAlta", mozoNuevo._fechaAlta);
                datosMozo.setearParametro("@AltaEventual", mozoNuevo._altaEventual);
                datosMozo.setearParametro("@IdPersona", idPersona);

                datosMozo.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosPersona.cerrarConexion();
                datosMozo.cerrarConexion();
            }
        }



        public int cantidadMozos()
        {
            AccesoDatos datos = new AccesoDatos();
            int cantidad = 0;
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Mozo");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    cantidad = (int)datos.Lector[0];
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
            return cantidad;
        }


        public List<Mozo> listar()
        {
            List<Mozo> lista = new List<Mozo>();
            AccesoDatos Dat = new AccesoDatos();

            try
            {
                Dat.setearConsulta("SELECT \r\n    m.Legajo, \r\n    m.Activado, \r\n    m.Disponible, \r\n    m.Categoria, \r\n    m.Tarea, \r\n    m.FechaAlta, \r\n    m.AltaEventual, \r\n    p.Dni,\r\n    p.Nombre, \r\n    p.Apellido, \r\n    p.Cuil, \r\n    p.FechaNacimiento, \r\n    p.Correo, \r\n    p.Telefono\r\nFROM Mozo m\r\nJOIN Persona p ON m.IdPersona = p.IdPersona;\r\n");
                Dat.ejecutarLectura();

                while (Dat.Lector.Read())
                {
                    
                    Mozo mozoDat = new Mozo();
           

                    if (!(Dat.Lector["Dni"] is DBNull))
                        mozoDat._dni = (long)Dat.Lector["Dni"];  

                    if (!(Dat.Lector["Nombre"] is DBNull))
                        mozoDat._nombre = Dat.Lector["Nombre"].ToString();


                    if (!(Dat.Lector["Apellido"] is DBNull))
                        mozoDat._apellido = Dat.Lector["Apellido"].ToString();

                    if (!(Dat.Lector["Cuil"] is DBNull))
                        mozoDat._cuil = (long)Dat.Lector["Cuil"];
 
                   if (!(Dat.Lector["FechaNacimiento"] is DBNull))
                        mozoDat._fechaNacimiento = (DateTime)Dat.Lector["FechaNacimiento"];

                    if (!(Dat.Lector["Correo"] is DBNull))
                        mozoDat._correo = Dat.Lector["Correo"].ToString();

                    if (!(Dat.Lector["Telefono"] is DBNull))
                        mozoDat._telefono = Dat.Lector["Telefono"].ToString();   
                    






                    if (!(Dat.Lector["Legajo"] is DBNull))
                        mozoDat._legajo = (int)Dat.Lector["Legajo"];

                    if (!(Dat.Lector["Activado"] is DBNull))
                        mozoDat._activado = (bool)Dat.Lector["Activado"];

                    if (!(Dat.Lector["Disponible"] is DBNull))
                        mozoDat._disponible = (bool)Dat.Lector["Disponible"];

                    if (!(Dat.Lector["Categoria"] is DBNull))
                        mozoDat._categoria = Dat.Lector["Categoria"].ToString();

                    if (!(Dat.Lector["Tarea"] is DBNull))
                        mozoDat._tarea = Dat.Lector["Tarea"].ToString();

                    if (!(Dat.Lector["FechaAlta"] is DBNull))
                        mozoDat._fechaAlta = (DateTime)Dat.Lector["FechaAlta"];

                    if (!(Dat.Lector["AltaEventual"] is DBNull))
                        mozoDat._altaEventual = Dat.Lector["AltaEventual"].ToString();



                    lista.Add(mozoDat);
                }

                return lista;
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
            finally
            {
                Dat.cerrarConexion();
            }
        }

        public  int  cambiarPropiedad(Mozo mozo)
        {
            AccesoDatos datosPersona = new AccesoDatos();
            AccesoDatos datosMozo = new AccesoDatos();
            try
            {
                datosMozo.setearConsulta(@"UPDATE M
SET 
    M.Activado = @Activado,
    M.Disponible = @Disponible,
    M.Categoria = @Categoria,
    M.Tarea = @Tarea,
    M.FechaAlta = @FechaAlta,
    M.AltaEventual = @AltaEventual
FROM Mozo M
WHERE M.Legajo = @Legajo");

                datosMozo.setearParametro("@Activado", mozo._activado);
                datosMozo.setearParametro("@Disponible", mozo._disponible);
                datosMozo.setearParametro("@Categoria", mozo._categoria);
                datosMozo.setearParametro("@Tarea", mozo._tarea);
                datosMozo.setearParametro("@FechaAlta", mozo._fechaAlta);
                datosMozo.setearParametro("@AltaEventual", mozo._altaEventual);
                datosMozo.setearParametro("@Legajo", mozo._legajo);
          
                
                datosMozo.ejecutarAccion();

                datosPersona.setearConsulta(
                    
                    
 @"UPDATE P
SET 
    P.Nombre = @Nombre,
    P.Dni = @Dni,
    P.Apellido = @Apellido,
    P.Cuil = @Cuil,
    P.FechaNacimiento = @FechaNacimiento,
    P.Correo = @Correo,
    P.Telefono = @Telefono
FROM Persona P
INNER JOIN Mozo M ON P.IdPersona = M.IdPersona
WHERE M.Legajo = @Legajo"
);


                datosPersona.setearParametro("@Nombre", mozo._nombre);
                datosPersona.setearParametro("@Apellido", mozo._apellido);
                datosPersona.setearParametro("@Cuil", mozo._cuil);
                datosPersona.setearParametro("@FechaNacimiento", mozo._fechaNacimiento);
                datosPersona.setearParametro("@Correo", mozo._correo);
                datosPersona.setearParametro("@Telefono", mozo._telefono);
                datosPersona.setearParametro("@Dni", mozo._dni);
                datosPersona.setearParametro("@Legajo", mozo._legajo);

                datosPersona.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }






            return 0;
        }





    


    public List<Mozo> listarActivados()
        {
            List<Mozo> lista = new List<Mozo>();
            lista = listar();

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i]._activado == false)
                {
                    lista.RemoveAt(i);
                    i--;
                }
            }


            return lista;



        }


        public List<Mozo> listarDisponibles()
        {
            List<Mozo> lista = new List<Mozo>();
            lista = listar();
            
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i]._disponible == false)
                {
                    lista.RemoveAt(i);
                    i--;
                }
            }


            return lista;


        }










    }




    }
