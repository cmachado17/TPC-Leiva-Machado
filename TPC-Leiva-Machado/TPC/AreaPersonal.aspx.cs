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
    public partial class AreaPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.sesionActiva(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita estar logueado para ingresar en esta seccion");
                Response.Redirect("Errores.aspx", false);
            }
            IncidenteNegocio negocio = new IncidenteNegocio();
            dgvIncidenciasAsignadas.DataSource = negocio.listarIncidenciasPorUsuario(((Empleado)Session["empleadoLogueado"]).Id);
            dgvIncidenciasAsignadas.DataBind();
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvIncidenciasAsignadas.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("FormularioIncidencia.aspx?incidencia=" + key);

            }
        }

        protected void BtnResolver_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvIncidenciasAsignadas.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("FormularioIncidencia.aspx?accion=resolver&incidencia=" + key);

            }
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvIncidenciasAsignadas.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("FormularioIncidencia.aspx?accion=cerrar&incidencia=" + key);

            }
        }
    }
}