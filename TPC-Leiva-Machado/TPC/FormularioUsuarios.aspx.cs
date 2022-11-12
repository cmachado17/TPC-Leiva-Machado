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
    public partial class FomularioUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PerfilNegocio negocio = new PerfilNegocio();
                    List<Perfil> lista = negocio.listarPerfiles();

                    ddlPerfil.DataSource = lista;
                    ddlPerfil.DataValueField = "Id";
                    ddlPerfil.DataTextField = "Descripcion";
                    ddlPerfil.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();

                nuevo.Nombres = txbNombre.Text;
                nuevo.Apellidos = txbApellido.Text;
                nuevo.Email = txbEmail.Text;
                nuevo.DNI = txbDNI.Text;
                nuevo.Perfil = new Perfil();
                nuevo.Perfil.Id = int.Parse(ddlPerfil.SelectedValue);

                negocio.AgregarUsuario(nuevo);

                Response.Redirect("Usuarios.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}