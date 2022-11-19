using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using Helpers;

namespace TPC
{
    public partial class FormularioIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //tiene q entrar tele
            if (!Seguridad.esTelefonista(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de telefonista para ingresar en esta seccion");
                Response.Redirect("Errores.aspx");
            }
        }
    }
}