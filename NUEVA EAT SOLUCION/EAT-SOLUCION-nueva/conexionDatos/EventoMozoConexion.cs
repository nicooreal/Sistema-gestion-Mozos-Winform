using System;
using System.Collections.Generic;
using System.Diagnostics;
using CONEXIONDATOS; // o tu namespace de AccesoDatos
using DOMINIO;
using negocio;

public class EventoMozoConexion
{
    public List<EventoMozo> listar()
    {
        var lista = new List<EventoMozo>();
        var datos = new AccesoDatos();

        try
        {
            datos.setearConsulta(@"
                SELECT
                    em.EventoId,
                    em.LegajoMozo,
                    em.HorarioEntrada,
                    em.HorarioSalida,
                    em.Plus,
                    em.RolDelPersonal,

                  
                    m.Activado,
                    m.Disponible,
                    m.Categoria,
                    m.Tarea,
                    m.FechaAlta,
                    m.AltaEventual,

                    p.IdPersona,
                    p.Dni,
                    p.Nombre,
                    p.Apellido,
                    p.Cuil,
                    p.FechaNacimiento,
                    p.Correo,
                    p.Telefono

                FROM EventoMozo em
                INNER JOIN Mozo    m ON m.Legajo     = em.LegajoMozo
                INNER JOIN Persona p ON p.IdPersona  = m.IdPersona
                ORDER BY em.EventoId, em.LegajoMozo;
            ");

            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                var item = new EventoMozo
                {
                    EventoId = (int)datos.Lector["EventoId"],
                    LegajoMozo = (int)datos.Lector["LegajoMozo"],

                    HorarioEntrada = (DateTime)datos.Lector["HorarioEntrada"],
                    HorarioSalida = (DateTime)datos.Lector["HorarioSalida"],
                    Plus = datos.Lector["Plus"] == DBNull.Value ? 0m : Convert.ToDecimal(datos.Lector["Plus"]),
                    RolDelPersonal = datos.Lector["RolDelPersonal"] as string,

                    Mozo = new Mozo
                    {
                        _legajo = (int)datos.Lector["LegajoMozo"],        // o (int)datos.Lector["Legajo"]
                        _activado = (bool)datos.Lector["Activado"],
                        _disponible = (bool)datos.Lector["Disponible"],
                        _categoria = datos.Lector["Categoria"] as string,
                        _tarea = datos.Lector["Tarea"] as string,
                        _fechaAlta = (DateTime)datos.Lector["FechaAlta"],
                        _altaEventual = datos.Lector["AltaEventual"] as string,

                        _dni = (long)datos.Lector["Dni"],
                        _nombre = (string)datos.Lector["Nombre"],
                        _apellido = (string)datos.Lector["Apellido"],
                        _cuil = (long)datos.Lector["Cuil"],
                        _fechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"],
                        _correo = datos.Lector["Correo"] as string,
                        _telefono = datos.Lector["Telefono"] as string
                    }
                };

                lista.Add(item);
            }
        }
        finally
        {
            datos.cerrarConexion();
        }

        return lista;
    }

    // (Opcional) útil para el botón "MOZOS" en un evento específico:
    public List<EventoMozo> listarPorEvento(int eventoId)
    {
    
        List<EventoMozo> listaeventoMozos = new List<EventoMozo>();
        AccesoDatos datos = new AccesoDatos();

 
        try
        {
            datos.setearConsulta(@"
                SELECT
                    em.EventoId,
                    em.LegajoMozo,
                    em.HorarioEntrada,
                    em.HorarioSalida,
                    em.Plus,
                    em.RolDelPersonal,

                    m.Activado,
                    m.Disponible,
                    m.Categoria,
                    m.Tarea,
                    m.FechaAlta,
                    m.AltaEventual,

                    p.IdPersona,
                    p.Dni,
                    p.Nombre,
                    p.Apellido,
                    p.Cuil,
                    p.FechaNacimiento,
                    p.Correo,
                    p.Telefono
                FROM EventoMozo em
                INNER JOIN Mozo    m ON m.Legajo     = em.LegajoMozo
                INNER JOIN Persona p ON p.IdPersona  = m.IdPersona
                WHERE em.EventoId = @EventoId
                ORDER BY em.LegajoMozo;
            ");
            datos.setearParametro("@EventoId", eventoId);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                
                EventoMozo eventMoz = new EventoMozo();

                eventMoz.EventoId = (int)datos.Lector["EventoId"];
                eventMoz.LegajoMozo = (int)datos.Lector["LegajoMozo"];

                eventMoz.Plus = datos.Lector["Plus"] == DBNull.Value ? 0m : Convert.ToDecimal(datos.Lector["Plus"]);
                eventMoz.RolDelPersonal = datos.Lector["RolDelPersonal"] as string;
                eventMoz.HorarioEntrada = (DateTime)datos.Lector["HorarioEntrada"];
                eventMoz.HorarioSalida = (DateTime)datos.Lector["HorarioSalida"];

                Mozo moz = new Mozo();

                moz._legajo = (int)datos.Lector["LegajoMozo"];        // o (int)datos.Lector["Legajo"]
                moz._activado = (bool)datos.Lector["Activado"];
                moz._disponible = (bool)datos.Lector["Disponible"];
                moz._categoria = datos.Lector["Categoria"] as string;
                moz._tarea = datos.Lector["Tarea"] as string;
                moz._fechaAlta = (DateTime)datos.Lector["FechaAlta"];
                moz._altaEventual = datos.Lector["AltaEventual"] as string;
                moz._dni = (long)datos.Lector["Dni"];
                moz._nombre = (string)datos.Lector["Nombre"];
                moz._apellido = (string)datos.Lector["Apellido"];
                moz._cuil = (long)datos.Lector["Cuil"];
                moz._fechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                moz._correo = datos.Lector["Correo"] as string;
                moz._telefono = datos.Lector["Telefono"] as string;
           
            eventMoz.Mozo = moz;

                listaeventoMozos.Add(eventMoz);
            }
            
        }
        finally
        {
            datos.cerrarConexion();
        }

        return listaeventoMozos;
   
    
    
    }
}
