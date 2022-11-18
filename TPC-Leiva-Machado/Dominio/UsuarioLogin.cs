using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioLogin
    {
        public Usuario IdUsuario { get; set;}
        public string Usuario { get; set; }
        public string Clave { get; set; }


        public UsuarioLogin (string user, string pass)
        {
            Usuario = user;
            Clave = pass;
         
        }
    }
}
