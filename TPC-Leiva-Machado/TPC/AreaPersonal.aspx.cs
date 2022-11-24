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
            Session.Add("IncidenciasLogueado", negocio.listarIncidenciasPorUsuario(((Empleado)Session["empleadoLogueado"]).Id));
            dgvIncidenciasAsignadas.DataSource = Session["IncidenciasLogueado"];
            dgvIncidenciasAsignadas.DataBind();

            if (!IsPostBack)
            {
                EstadoNegocio estadoNegocio = new EstadoNegocio();
                List<Estado> listEstado = estadoNegocio.listarEstado();

                dwEstados.DataSource = listEstado;
                dwEstados.DataValueField = "Id";
                dwEstados.DataTextField = "Descripcion";
                dwEstados.DataBind();
            }

        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            MetodosCompartidos helper = new MetodosCompartidos();
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvIncidenciasAsignadas.DataKeys[rowIndex].Value.ToString();

                int estadoIncidencidencia = helper.buscarEstadoIncidencia(key);

                if (estadoIncidencidencia != 1 && estadoIncidencidencia != 2 && estadoIncidencidencia!= 5)
                {
                    Session.Add("error", "Solo se pueden modificar incidencias en estado: abierto, en analisis o asignado");
                    Response.Redirect("Errores.aspx", false);
                    return;
                }

                Response.Redirect("FormularioIncidencia.aspx?incidencia=" + key);
            }
        }

        protected void BtnResolver_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            MetodosCompartidos helper = new MetodosCompartidos();
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvIncidenciasAsignadas.DataKeys[rowIndex].Value.ToString();

                int estadoIncidencidencia = helper.buscarEstadoIncidencia(key);

                if (estadoIncidencidencia == 3 || estadoIncidencidencia == 6)
                {
                    Session.Add("error", "Solo se pueden resolver incidencias en estado: abierto, en analisis o asignado");
                    Response.Redirect("Errores.aspx", false);
                    return;
                }

                Response.Redirect("FormularioIncidencia.aspx?accion=resolver&incidencia=" + key);

            }
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            MetodosCompartidos helper = new MetodosCompartidos();
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvIncidenciasAsignadas.DataKeys[rowIndex].Value.ToString();

                int estadoIncidencidencia = helper.buscarEstadoIncidencia(key);

                if (estadoIncidencidencia != 1 && estadoIncidencidencia != 2 && estadoIncidencidencia != 5)
                {
                    Session.Add("error", "Solo se pueden cerrar incidencias en estado: abierto, en analisis o asignado");
                    Response.Redirect("Errores.aspx", false);
                    return;
                }

                Response.Redirect("FormularioIncidencia.aspx?accion=cerrar&incidencia=" + key);

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Incidente> listaIncidentes = (List<Incidente>)Session["IncidenciasLogueado"];
            List<Incidente> listaFiltrada = listaIncidentes.FindAll(x => x.Estado.Id == int.Parse(dwEstados.SelectedValue));
            dgvIncidenciasAsignadas.DataSource = listaFiltrada;
            dgvIncidenciasAsignadas.DataBind();
        }
    }
}

