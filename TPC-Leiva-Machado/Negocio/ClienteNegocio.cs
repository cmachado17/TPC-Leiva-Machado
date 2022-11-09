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

        public List<Clientes> listarCliente()
        {
            List<Clientes> lista = new List<Clientes>();

            try
            {
                datos.setearConsulta("sp_listar_Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Clientes aux = new Clientes();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombres = (string)datos.Lector["Nombres"];
                    aux.Apellidos = (string)datos.Lector["Apellidos"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
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
