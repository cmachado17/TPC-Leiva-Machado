using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EstadoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Estado> listarEstado()
        {
            List<Estado> lista = new List<Estado>();

            try
            {
                datos.setearConsulta("select Id, Descripcion from EstadoIncidencia");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estado aux = new Estado();
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
