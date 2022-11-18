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
            /*if (!IsPostBack)
            {
                lbUser.Visible = true;
                txtUser.Visible = true;
                lbClave.Visible = true;
                txtClave.Visible = true;
                btnIngresar.Visible = true;
            }*/
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogin datosLogin;
            UsuarioLoginNegocio negocio = new UsuarioLoginNegocio();
            Usuario usuario= new Usuario();

            try
            {
               datosLogin  = new UsuarioLogin(txtUser.Text, txtClave.Text);

               usuario = negocio.Loguear(datosLogin);

                if ( usuario != null)
                { 
                
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
                throw ex;;
               // Session.Add("error", ex.ToString());
                //Response.Redirect("Error.aspx", false);
            }
        }
    }
}