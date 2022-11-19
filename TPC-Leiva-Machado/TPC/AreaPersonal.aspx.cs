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
            IncidenteNegocio negocio = new IncidenteNegocio();
            dgvIncidenciasAsignadas.DataSource = negocio.listarIncidenciasPorUsuario(((Empleado)Session["empleadoLogueado"]).Id);
            dgvIncidenciasAsignadas.DataBind();
        }
    }
}