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
           

            if (Request.QueryString["id"] != null && !IsPostBack)
            {
            
                ClienteNegocio negocio = new ClienteNegocio();
                List<Cliente> seleccionado = new List<Cliente>(); 
                seleccionado.Add(negocio.listarClientePorId(Int32.Parse(Request.QueryString["id"])));

                //lo guardamos en session
                Session.Add("ClienteSeleccionado", seleccionado);
                dgvDetalleCliente.DataSource =Session["ClienteSeleccionado"];
                dgvDetalleCliente.DataBind();
            }
        }
    }
}