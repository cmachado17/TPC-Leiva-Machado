using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Cliente> listarCliente()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                datos.setearSP("sp_listar_Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombres = (string)datos.Lector["Nombres"];
                    aux.Apellidos = (string)datos.Lector["Apellidos"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    //aux.FechaDeAlta = (DateTime)datos.Lector["FechaDeAlta"];
                    //aux.FechaDeBaja = (DateTime)datos.Lector["FechaDeBaja"];
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


        public void agregarCliente(Cliente nuevo)
        {
            try
            {
                datos.setearSP("sp_Agregar_Cliente");
                datos.setearParametro("@Nombres", nuevo.Nombres);
                datos.setearParametro("@Apellidos", nuevo.Apellidos);
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Telefono", nuevo.Telefono);

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

        public Cliente listarClientePorId(int id)
        {
            Cliente cliente = new Cliente();

            try
            {
                datos.setearConsulta("Select Nombres, Apellidos,DNI, Email, Telefono " +
                "from Clientes where Id =" + id);
                datos.ejecutarLectura();

                 if(datos.Lector.Read())
                 {
                    Cliente aux = new Cliente();
                    aux.Nombres = (string)datos.Lector["Nombres"];
                    aux.Apellidos = (string)datos.Lector["Apellidos"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
         
                    cliente = aux;
                }
                return cliente;
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


        public void modificarConSp(Cliente cliente)
        {
            try
            {
                datos.setearSP("sp_modificar_cliente");
                datos.setearParametro("@id", cliente.Id);
                datos.setearParametro("@Nombre", cliente.Nombres);
                datos.setearParametro("@Apellido", cliente.Apellidos);
                datos.setearParametro("@dni", cliente.DNI);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@telefono", cliente.Telefono);

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
