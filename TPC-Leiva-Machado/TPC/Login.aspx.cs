using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogin usuario;
            UsuarioLoginNegocio negocio = new UsuarioLoginNegocio();

            try
            {
                usuario = new UsuarioLogin(txtUser.Text, txtClave.Text, 0);

                int perfil = negocio.Loguear(usuario);
                if ( perfil != 0) 
                 {
                    Session.Add("perfil", perfil);
                    Session.Add("usuarioLogueado", usuario);
                    Response.Redirect("Home.aspx", false);
                //te envia a home, despues en en load de cada pagina
                //va a mostrar o no dependiendo del perfil que se
                //encuentra en session

                 } else
                {
                    Session.Add("error", "user o pass incorecto");
                    //Response.Redirect("Error.aspx", false);
                }
            } catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                //Response.Redirect("Error.aspx", false);
            }
        }
    }
}