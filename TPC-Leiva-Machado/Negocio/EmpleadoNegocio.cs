using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Empleado> listarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {
                datos.setearConsulta("sp_listar_Empleados");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombres = (string)datos.Lector["Nombres"];
                    aux.Apellidos = (string)datos.Lector["Apellidos"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Perfil = new Perfil();
                    aux.Perfil.Id = (int)datos.Lector["IdPerfil"];
                    aux.Perfil.Descripcion = (string)datos.Lector["Perfil"];
                    aux.FechaDeAlta = datos.Lector["FechaDeAlta"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeAlta"]).ToShortDateString() : "";
                    aux.FechaDeBaja = datos.Lector["FechaDeBaja"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeBaja"]).ToShortDateString() : "";
                    aux.Activo = (bool)datos.Lector["Activo"];

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

        public List<Empleado> listarTelefonistas()
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {
                datos.setearConsulta("sp_listar_telefonistas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombres = (string)datos.Lector["Nombre"];
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

        public Empleado listarEmpleadoPorId(int id)
        {
            Empleado empleado = new Empleado();

            try
            {
                datos.setearSP("SP_ListarEmpleado_PorId");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    empleado.Id = (int)datos.Lector["Id"];
                    empleado.Nombres = (string)datos.Lector["Nombres"];
                    empleado.Apellidos = (string)datos.Lector["Apellidos"];
                    empleado.DNI = (string)datos.Lector["DNI"];
                    empleado.URLImagen = datos.Lector["URLImagen"] != DBNull.Value ? (string)datos.Lector["URLImagen"] : "";
                    empleado.Email = (string)datos.Lector["Email"];
                    empleado.Telefono = (string)datos.Lector["Telefono"];
                    empleado.Perfil = new Perfil();
                    empleado.Perfil.Id = (int)datos.Lector["IdPerfil"];
                    empleado.Perfil.Descripcion = (string)datos.Lector["Descripcion"];
                    empleado.FechaDeAlta = datos.Lector["FechaDeAlta"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeAlta"]).ToShortDateString() : "";
                    empleado.FechaDeBaja = datos.Lector["FechaDeBaja"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeBaja"]).ToShortDateString() : "";
                    empleado.Activo = (bool)datos.Lector["Activo"];
                }
                return empleado;
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

        public void AgregarEmpleado(Empleado nuevo)
        {
            try
            {
                datos.limpiarParametros();
                datos.setearSP("sp_Agregar_Empleado");
                datos.setearParametro("@Nombres", nuevo.Nombres);
                datos.setearParametro("@Apellidos", nuevo.Apellidos);
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@Clave", nuevo.Clave);
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

        public void ModificarEmpleado(Empleado empleado)
        {
            try
            {
                datos.setearSP("SP_Modificar_Empleados");
                datos.setearParametro("@Id", empleado.Id);
                datos.setearParametro("@Email", empleado.Email);
                datos.setearParametro("@Telefono", empleado.Telefono);
                datos.setearParametro("@Perfil", empleado.Perfil.Id);
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

        public void EliminarEmpleado(string id)
        {
            try
            {
                datos.setearConsulta("DELETE FROM EMPLEADOS WHERE Id =" + id);
                datos.ejecutarLectura();
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

        public void BajaLogicaEmpleado(int id, bool activo = false)
        {
            try
            {
                string consulta;
                if (!activo)
                    consulta = "UPDATE Empleados SET Activo = @activo, FechaDeBaja = GETDATE() WHERE Id = @id";
                else
                    consulta = "UPDATE Empleados SET Activo = @activo, FechaDeBaja = NULL WHERE Id = @id";

                datos.setearConsulta(consulta);
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
                datos.ejecutarLectura();
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
        public bool listarEmpleadoPorDNI(string dni)
        {
            bool bandera = false;

            try
            {
                datos.setearConsulta("SELECT * FROM Empleados WHERE DNI = @dni");
                datos.setearParametro("@dni", dni);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    bandera = true;
                    return bandera;
                }

                return bandera;
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

        //va a devolver los datos del empleado logueado o null
        public Empleado Loguear(Empleado empleado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_Login");
                datos.setearParametro("@user", empleado.Email);
                datos.setearParametro("@pass", empleado.Clave);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    
                    empleado.Id = (int)datos.Lector["Id"];
              
                }

                //una vez que se el id del usuario lo busco para devolverlo
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                empleado = negocio.listarEmpleadoPorId(empleado.Id);

                return empleado;

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

        public void actualizarFoto(Empleado empleado)
        {
            try
            {
                datos.setearConsulta("UPDATE Empleados SET URLImagen = @urlImagen WHERE Id = @id");
                datos.setearParametro("@id", empleado.Id);
                datos.setearParametro("@urlImagen", empleado.URLImagen);
                datos.ejecutarLectura();
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

        public bool VerificarClave(Empleado empleado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Clave from Empleados where Id = @id and Clave = @pass");
                datos.setearParametro("@id", empleado.Id);
                datos.setearParametro("@pass", empleado.Clave);
                datos.ejecutarLectura();


                 if (datos.Lector.Read())
                {

                   return true;

                }

                   return false;

            }
            catch (Exception ex)
            {
                //retorna false para que regrese al metodo y asi poder tomar el error en session
                return false;

            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public void cambiarClave(Empleado empleado)
        {
            try
            {
                datos.setearConsulta("UPDATE Empleados SET Clave = @clave WHERE Id = @id");
                datos.setearParametro("@id", empleado.Id);
                datos.setearParametro("@clave", empleado.Clave);
                datos.ejecutarLectura();
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

        public bool VerificarEmail(Empleado empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            bool bandera = false;

            try
            {
                datos.setearConsulta("Select * from Empleados where Email = @email");
                datos.setearParametro("@email", empleado.Email);
                datos.ejecutarLectura();


                if (datos.Lector.Read())
                {
                    bandera = true;
                    return bandera;

                }

                return bandera;

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
