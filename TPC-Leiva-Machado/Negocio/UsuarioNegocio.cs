using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Usuario> listarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("sp_listar_Usuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombres = (string)datos.Lector["Nombres"];
                    aux.Apellidos = (string)datos.Lector["Apellidos"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Perfil = new Perfil();
                    aux.Perfil.Id = (int)datos.Lector["Id"];
                    aux.Perfil.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.FechaDeAlta = (DateTime)datos.Lector["FechaDeAlta"];
                    aux.FechaDeBaja = (DateTime)datos.Lector["FechaDeBaja"];
                    aux.Activo = (Boolean)datos.Lector["Activo"];

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
