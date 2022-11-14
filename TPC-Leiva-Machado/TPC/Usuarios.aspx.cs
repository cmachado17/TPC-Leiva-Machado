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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Session.Add("listaUsuarios", negocio.listarUsuarios());
            dgvUsuarios.DataSource = Session["listaUsuarios"];
            dgvUsuarios.DataBind();
        }

        protected void FiltroUsuarios_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            List<Usuario> listaFiltrada = lista.FindAll(x => x.Nombres.ToUpper().Contains(FiltroUsuarios.Text.ToUpper()));
            dgvUsuarios.DataSource = listaFiltrada;
            dgvUsuarios.DataBind();
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = dgvUsuarios.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioUsuarios.aspx?id=" + id);
        }

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUsuarios.PageIndex = e.NewPageIndex;
            dgvUsuarios.DataBind();
        }

        protected void BtnModificarU_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvUsuarios.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("FormularioUsuarios.aspx?id=" + key);

            }
        }

        protected void BtnDetalleU_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvUsuarios.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("DetalleUsuarios.aspx?id=" + key);

            }
        }
    }
}