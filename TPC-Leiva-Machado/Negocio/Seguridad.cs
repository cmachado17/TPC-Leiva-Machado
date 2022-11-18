using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Empleado empleado = user != null ? (Empleado)user : null;
            if((empleado != null && empleado.Id != 0))
                return true;
                else
                    return false;
        }

        public static bool esAdmin(object user)
        {
            Empleado empleado = user != null ? (Empleado)user : null;
            if(empleado != null)
            {
                if(empleado.Perfil.Descripcion == "Administrador")
                    return true;
                else
                    return false;
                
            }
            else
            {
                return false;
            }
        }

        public static bool esSupervisor(object user)
        {
            Empleado empleado = user != null ? (Empleado)user : null;
            if (empleado != null)
            {
                if (empleado.Perfil.Descripcion == "Supervisor")
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public static bool esTelefonista(object user)
        {
            Empleado empleado = user != null ? (Empleado)user : null;
            if (empleado != null)
            {
                if (empleado.Perfil.Descripcion == "Telefonista")
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
