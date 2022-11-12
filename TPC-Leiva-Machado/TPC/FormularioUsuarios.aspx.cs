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
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarEliminacion = false;
            txtId.Visible = false;
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

                if (Request.QueryString["id"] != null && !IsPostBack)
                {
                    txbNombre.Enabled = false;
                    txbApellido.Enabled = false;
                    txbDNI.Enabled = false;

                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario seleccionado = negocio.listarUsuarioPorId(Int32.Parse(Request.QueryString["id"]));

                    //lo guardamos en session
                    Session.Add("UsuarioSeleccionado", seleccionado);

                    //cargamos los campos del formulario

                    //txtId.Text = seleccionado.Id.ToString();
                    txbNombre.Text = seleccionado.Nombres;
                    txbApellido.Text = seleccionado.Apellidos;
                    txbDNI.Text = seleccionado.DNI;
                    txbEmail.Text = seleccionado.Email;
                    ddlPerfil.SelectedValue = seleccionado.Perfil.Id.ToString();

                    if (!seleccionado.Activo)
                        btnDesactivar.Text = "Reactivar";
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

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(id);
                    negocio.ModificarUsuario(nuevo);
                }
                else
                    negocio.AgregarUsuario(nuevo);


                Response.Redirect("Usuarios.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    string id = Request.QueryString["id"].ToString();
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    negocio.EliminarUsuario(id);

                    Response.Redirect("Usuarios.aspx", false);
                }
                else
                {
                    string msg = "Favor de confirmar la eliminación.";
                    Response.Write("<script>alert('" + msg + "')</script>");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario seleccionado = (Usuario)Session["UsuarioSeleccionado"];

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.BajaLogicaUsuario(seleccionado.Id, !seleccionado.Activo);

                Response.Redirect("Usuarios.aspx", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}