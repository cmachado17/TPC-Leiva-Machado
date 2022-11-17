using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioLoginNegocio
    {
        //va a devolver el perfil del usuario logueado
        public int Loguear(UsuarioLogin usuarioLogueado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_UsuarioLogin");
                datos.setearParametro("@user", usuarioLogueado.Usuario);
                datos.setearParametro("@pass", usuarioLogueado.Clave);
                datos.ejecutarLectura();

                int perfil = 0;

                while (datos.Lector.Read())
                {
                    //una vez que encontramos al usuario logueado
                    //buscamos en la tabla de usuarios su perfil
                    usuarioLogueado.IdUsuario = new Usuario();
                    usuarioLogueado.IdUsuario.Id = (int)datos.Lector["Id"];
                    usuarioLogueado.IdUsuario.Perfil = new Perfil();
                    perfil = usuarioLogueado.IdUsuario.Perfil.Id = (int)datos.Lector["IdPerfil"];
                    return perfil;
                }

                //si encuentra el usuario, en el while devuelve su id perfil
                //sino va a devolver 0.
                return perfil;

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
