using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.DynamicData;

namespace TPC
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            ClienteNegocio negocio = new ClienteNegocio();
            Session.Add("listaClientes", negocio.listarCliente());
            dgvClientes.DataSource = Session["listaClientes"];
            dgvClientes.DataBind();

            if (Session["empleadoLogueado"] != null)
            {
                if (Session["Perfil"].Equals(3))
                {
                    dgvClientes.Columns[5].Visible = false;
                    dgvClientes.Columns[6].Visible = false;
                }

                if (Session["Perfil"].Equals(1))
                {
                    dgvClientes.Columns[5].Visible = false;

                }
            }
        }
        //protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    String id = dgvClientes.SelectedDataKey.Value.ToString();
        //    Response.Redirect("FormularioClientes.aspx?id=" + id);
        //}

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientes.PageIndex = e.NewPageIndex;
            dgvClientes.DataBind();
        }

        protected void FiltroClientes_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["listaClientes"];
            List<Cliente> listaFiltrada = lista.FindAll(x => x.Nombres.ToUpper().Contains(FiltroClientes.Text.ToUpper()));
            dgvClientes.DataSource = listaFiltrada;
            dgvClientes.DataBind();
        }

        protected void BtnIncidencia_Click(object sender, EventArgs e)
        {
            if (Session["Perfil"].Equals(2))
            {
                Button b = (Button)sender;
                GridViewRow row = (GridViewRow)b.NamingContainer;
                if (row != null)
                {
                    //Obtenemos el indice de la fila
                    int rowIndex = row.RowIndex;

                    
                    //obtenemos el Datakey de la row, que es el ID Cliente
                    string key = dgvClientes.DataKeys[rowIndex].Value.ToString();
                    Response.Redirect("FormularioIncidencia.aspx?id=" + key);
                }
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            if (Session["Perfil"].Equals(2) || Session["Perfil"].Equals(1))
            {
                ImageButton b = (ImageButton)sender;
                GridViewRow row = (GridViewRow)b.NamingContainer;
                if (row != null)
                {
                    //Obtenemos el indice de la fila
                    int rowIndex = row.RowIndex;
                    //obtenemos el Datakey de la row, que es el ID Cliente
                    string key = dgvClientes.DataKeys[rowIndex].Value.ToString();

                    Response.Redirect("FormularioClientes.aspx?id=" + key);

                }
            }
        }

        protected void BtnDetalle_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                //Obtenemos el indice de la fila
                int rowIndex = row.RowIndex;
                //obtenemos el Datakey de la row, que es el ID Cliente
                string key = dgvClientes.DataKeys[rowIndex].Value.ToString();

                Response.Redirect("DetalleCliente.aspx?id=" + key);

            }
        }
    }
}