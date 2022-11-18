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
        //va a devolver los datos del usuario logueado o null
        public bool Loguear(UsuarioLogin usuarioLogueado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_UsuarioLogin");
                datos.setearParametro("@user", usuarioLogueado.Usuario);
                datos.setearParametro("@pass", usuarioLogueado.Clave);
                datos.ejecutarLectura();

                Usuario usuario = new Usuario();

                while (datos.Lector.Read())
                {
                    usuarioLogueado.IdUsuario = new Usuario();
                    usuarioLogueado.IdUsuario.Id =(int)datos.Lector["IdUsuario"];
                    return true;
                }


                  /*  while (datos.Lector.Read())
                {
                    usua
                    //una vez que encontramos al usuario logueado lo guardamos
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Nombres = (string)datos.Lector["Nombres"];
                    usuario.Apellidos = (string)datos.Lector["Apellidos"];
                    usuario.DNI = (string)datos.Lector["DNI"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Perfil = new Perfil();
                    usuario.Perfil.Id = (int)datos.Lector["IdPerfil"];
                    usuario.Perfil.Descripcion = (string)datos.Lector["Descripcion"];
                    usuario.FechaDeAlta = datos.Lector["FechaDeAlta"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeAlta"]).ToShortDateString() : "";
                    usuario.FechaDeBaja = datos.Lector["FechaDeBaja"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeBaja"]).ToShortDateString() : "";
                    usuario.Activo = (Boolean)datos.Lector["Activo"];
                }

                //si encuentra el usuario, en el while devuelve su id perfil
                //sino va a devolver 0.*/
                return false;

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
