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
    public partial class DetalleIncidentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["empleadoLogueado"]) || !Seguridad.esSupervisor(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador o supervisor para ingresar en esta seccion");
                Response.Redirect("Errores.aspx");
            }

            btnAceptarI.Visible = false;
            lbEmpleadoAsignado.Visible = false;
            dwEmpleadoAsignado.Visible = false;

            if (Session["Perfil"].Equals(3))
            {
                btnAceptarI.Visible = true;
                lbEmpleadoAsignado.Visible = true;
                dwEmpleadoAsignado.Visible = true;
            }


            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                dwTipoI.Enabled = false;
                dwPrioridadI.Enabled = false;
                txProblematicaI.Enabled = false;


                IncidenteNegocio negocio = new IncidenteNegocio();
                Incidente seleccionado = negocio.listarIncidentePorId(Int32.Parse(Request.QueryString["id"]));
 ;
                //lo guardamos en session
                Session.Add("IncidenteSeleccionado", seleccionado);

                //cargamos los campos del formulario
                dwTipoI.SelectedValue = seleccionado.Tipo.Id.ToString();
                dwPrioridadI.SelectedValue = seleccionado.Prioridad.Id.ToString();
                txProblematicaI.Text = seleccionado.Problematica;

             }
        }

        protected void btnAceptarI_Click(object sender, EventArgs e)
        {
            if (Session["Perfil"].Equals(3))
            {
            }
        }
    }
}