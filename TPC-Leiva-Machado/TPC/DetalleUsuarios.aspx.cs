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
    public partial class DetalleUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && !IsPostBack)
            {

                UsuarioNegocio negocio = new UsuarioNegocio();
                List<Usuario> seleccionado = new List<Usuario>();
                seleccionado.Add(negocio.listarUsuarioPorId(Int32.Parse(Request.QueryString["id"])));

                //lo guardamos en session
                Session.Add("UsuarioSeleccionado", seleccionado);
                dgvDetalleUsuarios.DataSource = Session["UsuarioSeleccionado"];
                dgvDetalleUsuarios.DataBind();
            }
        }
    }
}