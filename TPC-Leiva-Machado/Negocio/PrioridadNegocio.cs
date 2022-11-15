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
                datos.setearConsulta("sp_listar_Prioridad");
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

        public void agregarPrioridad(Prioridad nuevo)
        {
            try
            {
                datos.setearConsulta("INSERT INTO PrioridadIncidencias VALUES (@Descripcion,1)");
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


        public void borrarPrioridad(string id)
        {
            try
            {
                datos.setearConsulta("DELETE FROM PrioridadIncidencias WHERE Id = @Id");
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
