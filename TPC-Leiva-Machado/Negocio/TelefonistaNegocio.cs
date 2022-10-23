using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TelefonistaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        public List<Telefonista> listarCliente()
        {
            List<Telefonista> lista = new List<Telefonista>();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre, Apellido, Email, Legajo FROM Telefonista");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Telefonista aux = new Telefonista();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Legajo = (int)datos.Lector["Legajo"];

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
