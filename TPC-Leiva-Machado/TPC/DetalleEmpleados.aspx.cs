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
    public partial class DetalleEmpleados: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador para ingresar en esta seccion");
                Response.Redirect("Errores.aspx", false);
            }

            if (Request.QueryString["id"] != null && !IsPostBack)
            {

                EmpleadoNegocio negocio = new EmpleadoNegocio();
                List<Empleado> seleccionado = new List<Empleado>();
                seleccionado.Add(negocio.listarEmpleadoPorId(Int32.Parse(Request.QueryString["id"])));

                //lo guardamos en session
                Session.Add("EmpleadoSeleccionado", seleccionado);
                dgvDetalleEmpleados.DataSource = Session["EmpleadoSeleccionado"];
                dgvDetalleEmpleados.DataBind();
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx", false);
        }
    }
}