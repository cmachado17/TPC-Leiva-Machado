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
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador para ingresar en esta seccion");
                Response.Redirect("Errores.aspx");
            }
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            Session.Add("listaEmpleados", negocio.listarEmpleados());
            dgvEmpleados.DataSource = Session["listaEmpleados"];
            dgvEmpleados.DataBind();
        }

        protected void FiltroEmpleados_TextChanged(object sender, EventArgs e)
        {
            List<Empleado> lista = (List<Empleado>)Session["listaEmpleados"];
            List<Empleado> listaFiltrada = lista.FindAll(x => x.Nombres.ToUpper().Contains(FiltroEmpleados.Text.ToUpper()));
            dgvEmpleados.DataSource = listaFiltrada;
            dgvEmpleados.DataBind();
        }

        protected void dgvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = dgvEmpleados.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioEmpleados.aspx?id=" + id);
        }

        protected void dgvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvEmpleados.PageIndex = e.NewPageIndex;
            dgvEmpleados.DataBind();
        }

        protected void BtnModificarE_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvEmpleados.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("FormularioEmpleados.aspx?id=" + key);

            }
        }

        protected void BtnDetalleE_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvEmpleados.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("DetalleEmpleados.aspx?id=" + key);

            }
        }
    }
}