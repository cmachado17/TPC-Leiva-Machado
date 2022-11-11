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
    public partial class FormularioClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                txbNombre.Enabled = false;
                txbApellido.Enabled = false;
                txbDNI.Enabled = false;

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente seleccionado = negocio.listarClientePorId(Int32.Parse(Request.QueryString["id"]));

                //cargamos los campos del formulario
                txbNombre.Text = seleccionado.Nombres;
                txbApellido.Text = seleccionado.Apellidos;
                txbDNI.Text = seleccionado.DNI;
                txbEmail.Text = seleccionado.Email;
                txbTelefono.Text = seleccionado.Telefono;
            }
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();

                nuevo.Nombres = txbNombre.Text;
                nuevo.Apellidos = txbApellido.Text;
                nuevo.DNI = txbDNI.Text;
                nuevo.Email = txbEmail.Text;
                nuevo.Telefono = txbTelefono.Text;

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(id);
                    negocio.modificarConSp(nuevo);
                }
                else
                    negocio.agregarCliente(nuevo);

                Response.Redirect("Clientes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

    }
}