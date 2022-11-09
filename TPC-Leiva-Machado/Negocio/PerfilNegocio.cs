using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PerfilNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<Perfil> listarPerfiles()
        {
            List<Perfil> lista = new List<Perfil>();

            try
            {
                datos.setearConsulta("sp_listar_Perfiles");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Perfil aux = new Perfil();
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

