using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helpers;

namespace TPC
{
    public partial class FormularioClientes : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.esSupervisor(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador o telefonista para ingresar en esta seccion");
                Response.Redirect("Errores.aspx");
            }

            ConfirmarEliminacion = false;
            txtId.Visible = false;
            lbError.Visible = false;
            lbError.Visible = false;
            txtErrorNombreC.Visible = false;
            txtErrorApellidoC.Visible = false;
            txtErrorDNIC.Visible = false;
            txtErrorEmailC.Visible = false;
            txtErrorTelefonoC.Visible = false;
           

            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                txbNombre.Enabled = false;
                txbApellido.Enabled = false;
                txbDNI.Enabled = false;

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente seleccionado = negocio.listarClientePorId(Int32.Parse(Request.QueryString["id"]));

                //lo guardamos en session
                Session.Add("ClienteSeleccionado", seleccionado);

                //cargamos los campos del formulario
                txbNombre.Text = seleccionado.Nombres;
                txbApellido.Text = seleccionado.Apellidos;
                txbDNI.Text = seleccionado.DNI;
                txbEmail.Text = seleccionado.Email;
                txbTelefono.Text = seleccionado.Telefono;

                if (!seleccionado.Activo)
                    btnDesactivar.Text = "Reactivar";
            }
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();

                if (validarCargaCliente())
                {
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
                        Response.Redirect("Clientes.aspx", false);
                    }
                    else
                    {
                        //Si estoy agregando, tengo que validar que no agreguen el mismo DNI
                        if (!negocio.listarClientePorDNI(nuevo.DNI))
                        {
                            negocio.agregarCliente(nuevo);
                            Response.Redirect("Clientes.aspx", false);
                        }
                        else
                        {
                            string msg = "Ya existe un cliente con ese DNI.";
                            Response.Write("<script>alert('" + msg + "')</script>");
                        }

                    }

                }
            


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
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
                    ClienteNegocio negocio = new ClienteNegocio();
                    IncidenteNegocio incidenteNegocio = new IncidenteNegocio();

                    if (!incidenteNegocio.buscarIncidenciaCliente(int.Parse(id)))
                    {
                        negocio.EliminarCliente(id);

                        Response.Redirect("Clientes.aspx", false);
                    }

                    Session.Add("error", "No se puede eliminar el cliente ya que cuenta con incidencias en el sistema.");
                    Response.Redirect("Errores.aspx");
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
                Cliente seleccionado = (Cliente)Session["ClienteSeleccionado"];

                ClienteNegocio negocio = new ClienteNegocio();
                negocio.BajaLogicaCliente(seleccionado.Id, !seleccionado.Activo);

                Response.Redirect("Clientes.aspx", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarCargaCliente()
        {
            reiniciarFormato();
            bool bandera = true;
            MetodosCompartidos helper = new MetodosCompartidos();

            //los helpers devuelven FALSE si no validan
            if (!helper.soloLetras(txbNombre.Text) || string.IsNullOrEmpty(txbNombre.Text))
            {
                txbNombre.BorderColor = System.Drawing.Color.Red;
                txtErrorNombreC.Text = "Campo nombre vacío o formato incorrecto";
                txtErrorNombreC.Enabled = false;
                txtErrorNombreC.Visible = true;
                bandera = false;
            }
            if (!helper.soloLetras(txbApellido.Text) || string.IsNullOrEmpty(txbApellido.Text))
            {
                txbApellido.BorderColor = System.Drawing.Color.Red;
                txtErrorApellidoC.Text = "Campo apellido vacío o formato incorrecto";
                txtErrorApellidoC.Enabled = false;
                txtErrorApellidoC.Visible = true;
                bandera = false;
            }
            if (!helper.cantidadCaracteresDNI(txbDNI.Text))
            {
                txbDNI.BorderColor = System.Drawing.Color.Red;
                txtErrorDNIC.Text = "El DNI debe contener 6 o mas caracteres";
                txtErrorDNIC.Enabled = false;
                txtErrorDNIC.Visible = true;
                bandera = false;
            }
            if (!helper.soloNumeros(txbDNI.Text) || string.IsNullOrEmpty(txbDNI.Text))
            {
                txbDNI.BorderColor = System.Drawing.Color.Red;
                txtErrorDNIC.Text = "Campo DNI vacío o formato incorrecto. Sólo números.";
                txtErrorDNIC.Enabled = false;
                txtErrorDNIC.Visible = true;
                bandera = false;
            }
            if (!helper.soloNumeros(txbTelefono.Text) || string.IsNullOrEmpty(txbTelefono.Text))
            {
                txbTelefono.BorderColor = System.Drawing.Color.Red;
                txtErrorTelefonoC.Text = "Campo teléfono vacío o formato incorrecto";
                txtErrorTelefonoC.Enabled = false;
                txtErrorTelefonoC.Visible = true;
                bandera = false;
            }
            if (!helper.formatoEmail(txbEmail.Text) || string.IsNullOrEmpty(txbEmail.Text))
            {
                txbEmail.BorderColor = System.Drawing.Color.Red;
                txtErrorEmailC.Text = "Campo email vacío o formato incorrecto";
                txtErrorEmailC.Enabled = false;
                txtErrorEmailC.Visible = true;
                bandera = false;
            }

            return bandera;
        }

        private void reiniciarFormato()
        {
            txbNombre.BorderColor = System.Drawing.Color.Black;
            txbApellido.BorderColor = System.Drawing.Color.Black;
            txbDNI.BorderColor = System.Drawing.Color.Black;
            txbTelefono.BorderColor = System.Drawing.Color.Black;
            txbEmail.BorderColor = System.Drawing.Color.Black;
        }
    }
}