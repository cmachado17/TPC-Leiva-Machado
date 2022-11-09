using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MotivoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<Motivo> listarMotivos()
        {
            List<Motivo> lista = new List<Motivo>();

            try
            {
                datos.setearConsulta("sp_listar_Motivos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Motivo aux = new Motivo();
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
    }
}

