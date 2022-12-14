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
            if (!Seguridad.esAdmin(Session["empleadoLogueado"]) && !Seguridad.esSupervisor(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador o Supervisor para ingresar en esta seccion");
                Response.Redirect("Errores.aspx");
            }

            IncidenteNegocio negocio = new IncidenteNegocio();
            Session.Add("listaIncidentes", negocio.listarIncidente());
            dgvIncidencias.DataSource = Session["listaIncidentes"];
            dgvIncidencias.DataBind();

            if (Session["Perfil"].Equals(1))
            {
                dgvIncidencias.Columns[8].Visible = false;

            }
            if (!IsPostBack && Seguridad.sesionActiva(Session["empleadoLogueado"]))
            {
                EstadoNegocio estadoNegocio = new EstadoNegocio();
                List<Estado> listEstado = estadoNegocio.listarEstado();

                dwEstadosI.DataSource = listEstado;
                dwEstadosI.DataValueField = "Id";
                dwEstadosI.DataTextField = "Descripcion";
                dwEstadosI.DataBind();
            }
        }

        protected void dgvIncidencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvIncidencias.PageIndex = e.NewPageIndex;
            dgvIncidencias.DataBind();
        }

        protected void BtnDetalleI_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID del Incidente
                string key = dgvIncidencias.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("DetalleIncidentes.aspx?id=" + key);

            }
        }

        protected void BtnReAsignar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            MetodosCompartidos helper = new MetodosCompartidos();

            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID del Incidente
                string key = dgvIncidencias.DataKeys[rowIndex].Value.ToString();

                int estadoIncidencidencia = helper.buscarEstadoIncidencia(key);

                if (estadoIncidencidencia != 1 && estadoIncidencidencia != 2)
                {
                    Session.Add("error", "Solo se pueden reasignar incidencias abiertas o en analisis");
                    Response.Redirect("Errores.aspx", false);
                    return;
                }

                Response.Redirect("FormularioIncidencia.aspx?accion=reasignar&incidencia=" + key);

            }
        }

        protected void btnBuscarI_Click(object sender, EventArgs e)
        {
            List<Incidente> listaIncidentes = (List<Incidente>)Session["listaIncidentes"];
            List<Incidente> listaFiltrada = listaIncidentes.FindAll(x => x.Estado.Id == int.Parse(dwEstadosI.SelectedValue));
            dgvIncidencias.DataSource = listaFiltrada;
            dgvIncidencias.DataBind();
        }

        protected void FiltroClientesIn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Incidente> listaIncidentes = (List<Incidente>)Session["listaIncidentes"];
                List<Incidente> listaFiltrada = listaIncidentes.FindAll(x => x.Cliente.Nombres.ToUpper().Contains(FiltroClientesIn.Text.ToUpper()));
                dgvIncidencias.DataSource = listaFiltrada;
                dgvIncidencias.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", "No se encontraron datos");
                Response.Redirect("Errores.aspx", false);
            }

        }
    }
}