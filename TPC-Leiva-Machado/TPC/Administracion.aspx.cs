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
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador para ingresar en esta seccion");
                Response.Redirect("Errores.aspx", false);
            }

            PrioridadNegocio negocioPrioridad = new PrioridadNegocio();
            TipoNegocio negocioTipo = new TipoNegocio();

            Session.Add("listaPrioridades", negocioPrioridad.listarPrioridad());
            dgvPrioridades.DataSource = Session["listaPrioridades"];
            dgvPrioridades.DataBind();

            Session.Add("listaTipo", negocioTipo.listarTipo());
            dgvTipoIncidencias.DataSource = Session["listaTipo"];
            dgvTipoIncidencias.DataBind();
        }

        protected void BtnPrioridad_Click(object sender, EventArgs e)
        {
            PrioridadNegocio negocioPrioridad = new PrioridadNegocio();
            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;

            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvPrioridades.DataKeys[rowIndex].Value.ToString();

                negocioPrioridad.borrarPrioridad(key);

                Response.Redirect("Administracion.aspx");

            }
        }

        protected void BtnTipoIncidencias_Click(object sender, EventArgs e)
        {
            TipoNegocio negocioTipo = new TipoNegocio();
            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;

            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvTipoIncidencias.DataKeys[rowIndex].Value.ToString();

                negocioTipo.borrarTipo(key);

                Response.Redirect("Administracion.aspx");

            }
        }

        protected void Tipo_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioAdministracion.aspx?categoria=tipo");
        }

        protected void Prioridad_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioAdministracion.aspx?categoria=prioridad");
        }

    }
}