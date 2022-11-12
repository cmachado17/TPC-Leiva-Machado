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
                    aux.Perfil.Id = (int)datos.Lector["IdPerfil"];
                    aux.Perfil.Descripcion = (string)datos.Lector["Perfil"];
                    aux.FechaDeAlta = (DateTime)datos.Lector["FechaDeAlta"];
                    aux.FechaDeBaja = datos.Lector["FechaDeBaja"] != DBNull.Value ? (DateTime)datos.Lector["FechaDeBaja"] : default;
                    //aux.FechaDeBaja = (DateTime)datos.Lector["FechaDeBaja"]
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

        public Usuario listarUsuarioPorId(int id)
        {
            Usuario usuario = new Usuario();

            try
            {
                datos.setearConsulta("Select Nombres, Apellidos,DNI, Email, IdPerfil, FechaDeAlta, FechaDeBaja, Activo, Descripcion from Usuarios U " +
                    "INNER JOIN Perfiles P ON P.ID = U.IdPerfil where U.Id =" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.Nombres = (string)datos.Lector["Nombres"];
                    usuario.Apellidos = (string)datos.Lector["Apellidos"];
                    usuario.DNI = (string)datos.Lector["DNI"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Perfil = new Perfil();
                    usuario.Perfil.Id = (int)datos.Lector["IdPerfil"];
                    usuario.Perfil.Descripcion = (string)datos.Lector["Descripcion"];
                    usuario.FechaDeAlta = (DateTime)datos.Lector["FechaDeAlta"];
                    usuario.FechaDeBaja = datos.Lector["FechaDeBaja"] != DBNull.Value ? (DateTime)datos.Lector["FechaDeBaja"] : default;
                    usuario.Activo = (Boolean)datos.Lector["Activo"];
                }
                return usuario;
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

        public void AgregarUsuario(Usuario nuevo)
        {
            try
            {
                datos.setearSP("sp_Agregar_Usuario");
                datos.setearParametro("@Nombres", nuevo.Nombres);
                datos.setearParametro("@Apellidos", nuevo.Apellidos);
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Perfil", nuevo.Perfil.Id);

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

        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                datos.setearSP("SP_Modificar_Usuario");
                datos.setearParametro("@Id", usuario.Id);
                datos.setearParametro("@Nombres", usuario.Nombres);
                datos.setearParametro("@Apellidos", usuario.Apellidos);
                datos.setearParametro("@DNI", usuario.DNI);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Perfil", usuario.Perfil.Id);
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
