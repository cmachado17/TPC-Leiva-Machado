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
                datos.setearConsulta("sp_listar_TiposInc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoIncidencia aux = new TipoIncidencia();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (Boolean)datos.Lector["Estado"];

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

        public void agregarTipo(TipoIncidencia nuevo)
        {
            try
            {
                datos.setearConsulta("INSERT INTO TipoIncidencias VALUES (@Descripcion,1)");
                datos.setearParametro("@Descripcion", nuevo.Descripcion);

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

        public void borrarTipo(string id)
        {
            try
            {
                datos.setearConsulta("DELETE FROM TipoIncidencias WHERE Id = @Id");
                datos.setearParametro("@Id", id);

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

    }
}
