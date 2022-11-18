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
            Empleado datosLogin;
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            Empleado empleado = new Empleado();

            try
            {
               datosLogin  = new Empleado(txtUser.Text, int.Parse(txtClave.Text));

               empleado = negocio.Loguear(datosLogin);

                if ( empleado.Id != 0)
                { 
                
                    Session.Add("empleadoLogueado", empleado);
                    Response.Redirect("Home.aspx", false);
                //te envia a home, despues en en load de cada pagina
                //va a mostrar o no dependiendo del perfil que se
                //encuentra en session

                 } else
                {
                    Session.Add("error", "User o pass incorecto");
                    Response.Redirect("Errores.aspx", false);
                }
            } catch (Exception ex)
            {
                Session.Add("error", "Error al intentar loguearse");
                Response.Redirect("Errores.aspx", false);
            }
        }
    }
}