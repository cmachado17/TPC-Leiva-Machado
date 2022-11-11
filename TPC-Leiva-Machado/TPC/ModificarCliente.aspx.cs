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
    public partial class ModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtModificarNombre.Enabled = false;
            txtModificarApellido.Enabled = false;
            txtModificarDNI.Enabled = false;

            //traemos el cliente del id que viajo por url
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente seleccionado = negocio.listarClientePorId(Int32.Parse(Request.QueryString["id"]));

                //cargamos los campos del formulario
                txtModificarNombre.Text = seleccionado.Nombres;
                txtModificarApellido.Text = seleccionado.Apellidos;
                txtModificarDNI.Text = seleccionado.DNI;
                txtModificarEmail.Text = seleccionado.Email;
                txtModificarTelefono.Text = seleccionado.Telefono;
            
            }
        }

        protected void btnConfirmarM_Click(object sender, EventArgs e)
        {

        }
    }
}