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
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( !Seguridad.esAdmin(Session["empleadoLogueado"]) && !Seguridad.esSupervisor(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador para ingresar en esta seccion");
                Response.Redirect("Errores.aspx");
            }

            IncidenteNegocio negocio = new IncidenteNegocio();
            Session.Add("listaIncidentes", negocio.listarIncidente());
            dgvIncidencias.DataSource = Session["listaIncidentes"];
            dgvIncidencias.DataBind();
        }
    }
}