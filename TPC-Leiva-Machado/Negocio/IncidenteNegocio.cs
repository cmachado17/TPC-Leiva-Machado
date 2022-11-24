using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class IncidenteNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<Incidente> listarIncidente()
        {
            List<Incidente> lista = new List<Incidente>();

            try
            {
                datos.setearConsulta("sp_listar_Incidentes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = new TipoIncidencia();
                    aux.Tipo.Id = (int)datos.Lector["IdTipoIncidencia"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.Id = (int)datos.Lector["IdPrioridad"];
                    aux.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    aux.Problematica = (string)datos.Lector["Problematica"];
                    aux.Estado = new Estado();
                    aux.Estado.Id = (int)datos.Lector["IdEstado"];
                    aux.Estado.Descripcion = (string)datos.Lector["Estado"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.Id = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Nombres = (string)datos.Lector["Cliente"];
                    //aux.Cliente.Apellidos = (string)datos.Lector["ApellidoCliente"];
                    aux.Cliente.DNI = (string)datos.Lector["DNICliente"];
                    aux.Cliente.Email = (string)datos.Lector["EmailCliente"];
                    aux.Cliente.Telefono = (string)datos.Lector["TelefonoCliente"];
                    aux.EmpleadoAsignado = new Empleado();
                    aux.EmpleadoAsignado.Id = (int)datos.Lector["IdEmpleado"];
                    aux.EmpleadoAsignado.Nombres = (string)datos.Lector["EmpleadoAsignado"];
                    //aux.EmpleadoAsignado.Apellidos = (string)datos.Lector["ApellidoTel"];
                    aux.Comentario = datos.Lector["Comentario"] != DBNull.Value ? (string)datos.Lector["Comentario"] : "";
                    aux.Motivo = new Motivo();
                    aux.Motivo.Descripcion = datos.Lector["Motivo"] != DBNull.Value ? (string)datos.Lector["Motivo"] : "";
                    aux.FechaDeAlta = datos.Lector["FechaDeAlta"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeAlta"]).ToShortDateString() : "";
                    aux.FechaDeBaja = datos.Lector["FechaDeBaja"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeBaja"]).ToShortDateString() : "";
                    aux.Activo = (Boolean)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
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

        public int agregarIncidencia(Incidente nuevo)
        {
            try
            {
                datos.limpiarParametros();
                datos.setearSP("sp_Agregar_Incidencia");
                datos.setearParametro("@IdTipo", nuevo.Tipo.Id);
                datos.setearParametro("@Prioridad", nuevo.Prioridad.Id);
                datos.setearParametro("@Problematica", nuevo.Problematica);
                datos.setearParametro("@Cliente", nuevo.Cliente.Id);
                datos.setearParametro("@Empleado", nuevo.EmpleadoAsignado.Id);

                return datos.ejecutarAccionScalar();


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

        public List<Incidente> listarIncidenciasPorUsuario(int id)
        {
            List<Incidente> lista = new List<Incidente>();

            try
            {
                datos.setearConsulta("select INC.ID, TI.ID 'IdTipo', TI.Descripcion 'Tipo', PRI.ID 'IdPrioridad', PRI.Descripcion 'Prioridad',EI.ID 'IdEstado', EI.Descripcion 'Estado', CL.ID 'IdCliente', concat(CL.Nombres, ', ', CL.Apellidos) as 'Cliente', INC.Problematica, INC.FechaDeAlta FROM Incidentes INC LEFT JOIN TipoIncidencias TI ON TI.ID = INC.IdTipoIncidencia LEFT JOIN PrioridadIncidencias PRI ON PRI.Id = INC.IdPrioridad LEFT JOIN EstadoIncidencias EI ON EI.ID = INC.IdEstado LEFT JOIN Clientes CL ON CL.id = INC.idCliente LEFT JOIN Empleados as E ON E.ID = INC.IdEmpleado LEFT JOIN Motivos as M ON M.ID = INC.IdMotivo Where INC.IdEmpleado = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Tipo = new TipoIncidencia();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.Id = (int)datos.Lector["IdPrioridad"];
                    aux.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    aux.Estado = new Estado();
                    aux.Estado.Id = (int)datos.Lector["IdEstado"];
                    aux.Estado.Descripcion = (string)datos.Lector["Estado"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.Id = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Nombres = (string)datos.Lector["Cliente"];
                    aux.FechaDeAlta = datos.Lector["FechaDeAlta"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeAlta"]).ToShortDateString() : "";
                    aux.Problematica = (string)datos.Lector["Problematica"];
                    lista.Add(aux);
                }
                    return lista;
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

        public Incidente listarIncidentePorId(int id)
        {
            Incidente encontrado = new Incidente();
            try
            {
                datos.setearConsulta("select INC.ID, TI.ID 'IdTipo', TI.Descripcion 'Tipo', PRI.ID 'IdPrioridad', PRI.Descripcion 'Prioridad', CL.ID 'IdCliente', concat(CL.Nombres, ', ', CL.Apellidos) as 'Cliente', CL.Email 'EmailCliente', E.ID 'Empleado', INC.Problematica, INC.FechaDeAlta, EI.ID 'Estado' FROM Incidentes INC LEFT JOIN TipoIncidencias TI ON TI.ID = INC.IdTipoIncidencia LEFT JOIN PrioridadIncidencias PRI ON PRI.Id = INC.IdPrioridad LEFT JOIN EstadoIncidencias EI ON EI.ID = INC.IdEstado LEFT JOIN Clientes CL ON CL.id = INC.idCliente LEFT JOIN Empleados as E ON E.ID = INC.IdEmpleado LEFT JOIN Motivos as M ON M.ID = INC.IdMotivo Where INC.ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    encontrado.Id = (int)datos.Lector["ID"];
                    encontrado.Tipo = new TipoIncidencia();
                    encontrado.Tipo.Id = (int)datos.Lector["IdTipo"];
                    encontrado.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    encontrado.Prioridad = new Prioridad();
                    encontrado.Prioridad.Id = (int)datos.Lector["IdPrioridad"];
                    encontrado.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    encontrado.Cliente = new Cliente();
                    encontrado.Cliente.Id = (int)datos.Lector["IdCliente"];
                    encontrado.Cliente.Nombres = (string)datos.Lector["Cliente"];
                    encontrado.Cliente.Email = (string)datos.Lector["EmailCliente"];
                    encontrado.EmpleadoAsignado = new Empleado();
                    encontrado.EmpleadoAsignado.Id = (int)datos.Lector["Empleado"];
                    encontrado.Estado = new Estado();
                    encontrado.Estado.Id = (int)datos.Lector["Estado"];
                    encontrado.FechaDeAlta = datos.Lector["FechaDeAlta"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeAlta"]).ToShortDateString() : "";
                    encontrado.Problematica = (string)datos.Lector["Problematica"];
                }

                return encontrado;
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

        public void modificarEnAnalisis(Incidente nuevo)
        {
            try
            {
                datos.limpiarParametros();
                datos.setearSP("sp_modifica_incidente_analisis");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Problematica", nuevo.Problematica);

                datos.ejecutarAccion();
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

        public void cerrarIncidente(Incidente nuevo)
        {
            try
            {
                datos.limpiarParametros();
                datos.setearSP("sp_Cerrar_Incidencia");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Motivo", nuevo.Motivo.Id);
                datos.ejecutarAccion();
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

        public void resolverIncidente(Incidente nuevo)
        {
            try
            {
                datos.limpiarParametros();
                datos.setearSP("sp_Resolver_Incidencia");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Comentario", nuevo.Comentario);

                datos.ejecutarAccion();
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

        public void reasignarIncidente(Incidente nuevo)
        {
            try
            {
                datos.limpiarParametros();
                datos.setearSP("sp_Reasignar_Incidencia");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Empleado", nuevo.EmpleadoAsignado.Id);

                datos.ejecutarAccion();
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

        public Incidente listarDetallePorId(int id)
        {
            Incidente encontrado = new Incidente();
            try
            {
                datos.setearSP("sp_Detalle_Incidentes");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    encontrado.Id = (int)datos.Lector["ID"];
                    encontrado.Tipo = new TipoIncidencia();
                    encontrado.Tipo.Id = (int)datos.Lector["IdTipo"];
                    encontrado.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    encontrado.Prioridad = new Prioridad();
                    encontrado.Prioridad.Id = (int)datos.Lector["IdPrioridad"];
                    encontrado.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    encontrado.Cliente = new Cliente();
                    encontrado.Cliente.Id = (int)datos.Lector["IdCliente"];
                    encontrado.Cliente.Nombres = (string)datos.Lector["Cliente"];
                    encontrado.FechaDeAlta = datos.Lector["FechaDeAlta"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeAlta"]).ToShortDateString() : "";
                    encontrado.FechaDeBaja = datos.Lector["FechaDeBaja"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeBaja"]).ToShortDateString() : "";
                    encontrado.Problematica = (string)datos.Lector["Problematica"];
                    encontrado.Motivo = new Motivo();
                    encontrado.Motivo.Id = (int)datos.Lector["IdMotivo"];
                    encontrado.Motivo.Descripcion = (string)datos.Lector["Motivo"];
                    encontrado.Estado = new Estado();
                    encontrado.Estado.Id = (int)datos.Lector["IdEstado"];
                    encontrado.Estado.Descripcion = (string)datos.Lector["Estado"];
                    encontrado.Comentario = (string)datos.Lector["Comentario"];
                }

                return encontrado;
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
