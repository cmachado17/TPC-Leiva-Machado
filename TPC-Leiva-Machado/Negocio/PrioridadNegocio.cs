using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PrioridadNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Prioridad> listarPrioridad()
        {
            List<Prioridad> lista = new List<Prioridad>();

            try
            {
                datos.setearConsulta("select Id, Descripcion from PrioridadIncidencia");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Prioridad aux = new Prioridad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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
