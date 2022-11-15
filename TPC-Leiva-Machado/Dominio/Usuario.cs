using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
        public string FechaDeAlta { get; set; }
        public string FechaDeBaja{ get; set; }
        public Boolean Activo { get; set; }

    }
}
