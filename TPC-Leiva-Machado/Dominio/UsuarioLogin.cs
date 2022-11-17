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
            /*IdUsuario = new Usuario();
            IdUsuario.Id= id;
            IdUsuario.Nombres = "0";
            IdUsuario.Apellidos = "0";
            IdUsuario.DNI = "0";
            IdUsuario.Email = "0";
            IdUsuario.Perfil = new Perfil();
            IdUsuario.Perfil.Id = 0;
            IdUsuario.Perfil.Descripcion = "0";
            IdUsuario.FechaDeAlta = "0/0/0";
            IdUsuario.FechaDeBaja = "";
            IdUsuario.Activo = false;*/
        }
    }
}
