using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Perfil Perfil { get; set; }
        public string FechaDeAlta { get; set; }
        public string FechaDeBaja { get; set; }
        public int Clave { get; set; }
        public bool Activo { get; set; }


        public Empleado(string user, int pass)
        {
            Email = user;
            Clave = pass;

        }

        public Empleado()
        {
            
        }

    }


}
