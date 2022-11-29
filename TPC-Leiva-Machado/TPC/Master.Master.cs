using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuAdmin.Visible = false;
            MenuTel.Visible = false;
            MenuSup.Visible = false;
            Logout.Visible = false;
            Menu1.Visible = true;
            Menu2.Visible = false;
            

            if (Session["empleadoLogueado"] != null)
            {
                Logout.Visible = true;
                Menu1.Visible = false;
                Menu2.Visible = true;
                Empleado empleado = (Empleado)Session["empleadoLogueado"];

                //se guarda el perfil para manejar lo que se ve de html
                Session.Add("Perfil", empleado.Perfil.Id);

                switch (empleado.Perfil.Id)
                {
                    case 1:
                        MenuAdmin.Visible = true;
                        break;
                    case 2:
                        MenuTel.Visible = true;
                        break;
                    case 3:
                        MenuSup.Visible = true;
                        break;
                    default:
                        break;
                }
            }


            if (!(Page is Login || Page is Home || Page is Errores))
            {
                if (!Seguridad.sesionActiva(Session["empleadoLogueado"]))
                {

                    Response.Redirect("Login.aspx");

                    if (Session["error"] != null)
                    {
                        Response.Redirect("Errores.aspx", false);
                       
                    }
       
                }
                    
                      
            }

     

        }

        protected void Logout_Click(object sender, EventArgs e)
        {

            if (Session["empleadoLogueado"] != null)
            {
                Session.Remove("empleadoLogueado");
                Response.Redirect("Home.aspx");
            }
        }
    }
}