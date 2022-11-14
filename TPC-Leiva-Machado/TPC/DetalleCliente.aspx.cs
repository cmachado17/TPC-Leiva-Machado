using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC
{
    public partial class DetalleCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            Session.Add("listaClientes", negocio.listarCliente());
            dgvDetalleCliente.DataSource = Session["listaClientes"];
            dgvDetalleCliente.DataBind();
        }
    }
}