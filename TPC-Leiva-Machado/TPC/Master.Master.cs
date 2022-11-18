using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuAdmin.Visible = false;
            MenuTel.Visible = false;
            MenuSup.Visible = false;

            Empleado usuario = new Empleado();

            if (Session["empleadoLogueado"] != null)
            {
                usuario = (Empleado)Session["empleadoLogueado"];

                switch (usuario.Perfil.Id)
                {
                    case 1: MenuAdmin.Visible = true;
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
           
         
        }
    }
}