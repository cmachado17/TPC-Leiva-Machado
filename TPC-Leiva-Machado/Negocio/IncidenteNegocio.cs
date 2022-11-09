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
                datos.setearConsulta("select INC.Id, INC.IdTipoIncidencia, TI.Descripcion 'Tipo', INC.IdPrioridad, PRI.descripcion 'Prioridad', INC.Problematica,INC.IdEstado, EI.Descripcion 'Estado', INC.IdCliente, CL.Nombre 'NombreCliente', CL.Apellido 'ApellidoCliente', CL.Email 'EmailCliente', INC.Resolucion, INC.IdTelefonista, TEL.Nombre 'NombreTel', TEL.Apellido 'ApellidoTel', TEL.Email 'EmailTel', TEL.Legajo, INC.Motivo from Incidente INC INNER JOIN TipoIncidencia TI ON TI.ID = INC.IdTipoIncidencia INNER JOIN PrioridadIncidencia PRI ON PRI.Id = INC.IdPrioridadIncidencia INNER JOIN EstadoIncidencia EI ON EI.ID = INC.IdEstadoIncidencia INNER JOIN Cliente CL ON CL.id = INC.idCliente INNER JOIN Telefonista TEL ON TEL.id = INC.idTelefonista");
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
                    aux.Estado.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Cliente = new Clientes();
                    aux.Cliente.Id = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Nombre = (string)datos.Lector["NombreCliente"];
                    aux.Cliente.Apellido = (string)datos.Lector["ApellidoCliente"];
                    aux.Cliente.Email = (string)datos.Lector["EmailCliente"];
                    aux.Resolucion = (string)datos.Lector["Resolucion"];
                    aux.Telefonista = new Telefonista();
                    aux.Telefonista.Id = (int)datos.Lector["IdTelefonista"];
                    aux.Telefonista.Nombre = (string)datos.Lector["NombreTel"];
                    aux.Telefonista.Apellido = (string)datos.Lector["ApellidoTel"];
                    aux.Telefonista.Email = (string)datos.Lector["EmailTel"];
                    aux.Telefonista.Legajo = (int)datos.Lector["Legajo"];
                    aux.Motivo = (string)datos.Lector["Motivo"];

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
    }
}
