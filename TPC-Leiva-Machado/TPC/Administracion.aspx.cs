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

        }

        protected void BtnTipoIncidencias_Click(object sender, EventArgs e)
        {

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