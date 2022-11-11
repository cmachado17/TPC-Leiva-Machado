using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.listarCliente();
            dgvClientes.DataBind();
        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = dgvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("ModificarCliente.aspx?id=" + id);

        }

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientes.PageIndex = e.NewPageIndex;
            dgvClientes.DataBind();
        }
    }
}