using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Negocio
{
    public class UsuarioLoginNegocio
    {
        //va a devolver los datos del usuario logueado o null
        public Usuario Loguear(UsuarioLogin usuarioLogueado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_UsuarioLogin");
                datos.setearParametro("@user", usuarioLogueado.Usuario);
                datos.setearParametro("@pass", usuarioLogueado.Clave);
                datos.ejecutarLectura();

            
                while (datos.Lector.Read())
                {
                    usuarioLogueado.IdUsuario = new Usuario();
                    usuarioLogueado.IdUsuario.Id =(int)datos.Lector["IdUsuario"];
               
                }

                //una vez que se el id del usuario lo busco para devolverlo
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario = negocio.listarUsuarioPorId(usuarioLogueado.IdUsuario.Id);
            
                return usuario;

            }
            catch (Exception ex)
            {
                //retorna null para que regrese al metodo y asi poder tomar el error en session
                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
