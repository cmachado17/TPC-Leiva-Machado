using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<TipoIncidencia> listarTipo()
        {
            List<TipoIncidencia> lista = new List<TipoIncidencia>();

            try
            {
                datos.setearConsulta("select Id, Descripcion from TipoIncidencia");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoIncidencia aux = new TipoIncidencia();
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
