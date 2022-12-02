using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace TPC
{
    public partial class FomularioEmpleados : System.Web.UI.Page
    {

        public bool ConfirmarEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador para ingresar en esta seccion");
                Response.Redirect("Errores.aspx");
            }

            ConfirmarEliminacion = false;
            txtId.Visible = false;
            lbClave.Visible = false;
            txbClave.Visible = false;

            if (Request.QueryString["id"] == null)
            {
                lbClave.Visible = true;
                txbClave.Visible = true;
            }


            lbError.Visible = false;
            txtErrorNombreE.Visible = false;
            txtErrorApellidoE.Visible = false;
            txtErrorDNIE.Visible = false;
            txtErrorEmailE.Visible = false;
            txtErrorTelefonoE.Visible = false;
            txtErrorClaveE.Visible = false;

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

                    EmpleadoNegocio negocio = new EmpleadoNegocio();
                    Empleado seleccionado = negocio.listarEmpleadoPorId(Int32.Parse(Request.QueryString["id"]));

                    //lo guardamos en session
                    Session.Add("EmpleadoSeleccionado", seleccionado);

                    //cargamos los campos del formulario

                    //txtId.Text = seleccionado.Id.ToString();
                    txbNombre.Text = seleccionado.Nombres;
                    txbApellido.Text = seleccionado.Apellidos;
                    txbDNI.Text = seleccionado.DNI;
                    txbEmail.Text = seleccionado.Email;
                    txbTelefono.Text = seleccionado.Telefono;
                    ddlPerfil.SelectedValue = seleccionado.Perfil.Id.ToString();

                    if (!seleccionado.Activo)
                        btnDesactivar.Text = "Reactivar";
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al listar los empleados");
                Response.Redirect("Errores.aspx", false);
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado nuevo = new Empleado();
                EmpleadoNegocio negocio = new EmpleadoNegocio();

                if (validarCargaEmpleado())
                {
                    nuevo.Nombres = txbNombre.Text;
                    nuevo.Apellidos = txbApellido.Text;
                    nuevo.DNI = txbDNI.Text;
                    nuevo.Email = txbEmail.Text;
                    nuevo.Telefono = txbTelefono.Text;
                    if (Request.QueryString["id"] == null)
                    {
                        nuevo.Clave = int.Parse(txbClave.Text);
                    }

                    nuevo.Perfil = new Perfil();
                    nuevo.Perfil.Id = int.Parse(ddlPerfil.SelectedValue);

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    if (Request.QueryString["id"] != null)
                    {
                        nuevo.Id = int.Parse(id);
                        negocio.ModificarEmpleado(nuevo);
                        Response.Redirect("Empleados.aspx", false);
                    }
                    else
                    {
                        bool banderaEmail = false;
                        bool banderaDNI = false;
                        //Si estoy agregando, tengo que validar que no agreguen el mismo DNI
                        if (negocio.listarEmpleadoPorDNI(nuevo.DNI))
                        {
                            //negocio.AgregarEmpleado(nuevo);
                            //Response.Redirect("Empleados.aspx", false);
                            banderaDNI = true;
                        }
                        /*else
                        {
                            string msg = "Ya existe un empleado con ese DNI.";
                            Response.Write("<script>alert('" + msg + "')</script>");
                        }*/
                        if (negocio.VerificarEmail(nuevo))
                        {
                            //negocio.AgregarEmpleado(nuevo);
                            //Response.Redirect("Empleados.aspx", false);
                            banderaEmail = true;
                        }

                       /* else
                        {
                            string msg = "Ya existe un empleado con ese Email.";
                            Response.Write("<script>alert('" + msg + "')</script>");
                        }*/
                       if(banderaDNI == true)
                        {
                            string msg = "Ya existe un empleado con ese DNI.";
                            Response.Write("<script>alert('" + msg + "')</script>");
                        }

                        if (banderaEmail == true)
                        {
                            string msg = "Ya existe un empleado con ese Email.";
                            Response.Write("<script>alert('" + msg + "')</script>");
                        }

                        if(banderaDNI == false && banderaEmail == false)
                        {
                            negocio.AgregarEmpleado(nuevo);
                            Response.Redirect("Empleados.aspx", false);
                        }

                  

                    }
                 
                }
              
            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al intentar agregar un empleado");
                Response.Redirect("Errores.aspx", false);
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
                    EmpleadoNegocio negocio = new EmpleadoNegocio();
                    IncidenteNegocio negocioIncidente = new IncidenteNegocio();

                    if (!negocioIncidente.buscarIncidenciaEmpleado(int.Parse(id)) && Request.QueryString["id"] != ((Empleado)Session["empleadoLogueado"]).Id.ToString())
                    {
                        negocio.EliminarEmpleado(id);
                        Response.Redirect("Empleados.aspx", false);
                    }

                    if (Request.QueryString["id"] == ((Empleado)Session["empleadoLogueado"]).Id.ToString())
                    {
                        Session.Add("error", "El usuario no puede eliminarse a si mismo.");
                        Response.Redirect("Errores.aspx");
                    }
                    else if (negocioIncidente.buscarIncidenciaEmpleado(int.Parse(id)))
                    {
                        Session.Add("error", "No se puede eliminar el empleado ya que tiene incidencias asignadas.");
                        Response.Redirect("Errores.aspx");
                    }

                }
                else
                {
                    string msg = "Favor de confirmar la eliminación.";
                    Response.Write("<script>alert('" + msg + "')</script>");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al querer eliminar un empleado.");
                Response.Redirect("Errores.aspx");
            }

        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado seleccionado = (Empleado)Session["EmpleadoSeleccionado"];

                EmpleadoNegocio negocio = new EmpleadoNegocio();
                negocio.BajaLogicaEmpleado(seleccionado.Id, !seleccionado.Activo);

                Response.Redirect("Empleados.aspx", false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarCargaEmpleado()
        {
            reiniciarFormato();
            bool bandera = true;
            MetodosCompartidos helper = new MetodosCompartidos();
            

            //los helpers devuelven FALSE si no validan
            if (!helper.soloLetras(txbNombre.Text) || string.IsNullOrEmpty(txbNombre.Text))
            {
                txbNombre.BorderColor = System.Drawing.Color.Red;
                txtErrorNombreE.Text = "Campo nombre vacío o formato incorrecto";
                txtErrorNombreE.Enabled = false;
                txtErrorNombreE.Visible = true;
                bandera = false;

            }
            if (!helper.soloLetras(txbApellido.Text) || string.IsNullOrEmpty(txbApellido.Text))
            {
                txbApellido.BorderColor = System.Drawing.Color.Red;
                txtErrorApellidoE.Text = "Campo apellido vacío o formato incorrecto";
                txtErrorApellidoE.Enabled = false;
                txtErrorApellidoE.Visible = true;
                bandera = false;
            }

           
            if (!helper.formatoEmail(txbEmail.Text) || string.IsNullOrEmpty(txbEmail.Text))
            {
                txbEmail.BorderColor = System.Drawing.Color.Red;
                txtErrorEmailE.Text = "Campo email vacío o formato incorrecto";
                txtErrorEmailE.Enabled = false;
                txtErrorEmailE.Visible = true;
                bandera = false;
            }
            if (!helper.soloNumeros(txbTelefono.Text) || string.IsNullOrEmpty(txbTelefono.Text))
            {
                txbTelefono.BorderColor = System.Drawing.Color.Red;
                txtErrorTelefonoE.Text = "Campo teléfono vacío o formato incorrecto";
                txtErrorTelefonoE.Enabled = false;
                txtErrorTelefonoE.Visible = true;
                bandera = false;
            }
            if (!helper.cantidadCaracteresDNI(txbDNI.Text))
            {
                txbDNI.BorderColor = System.Drawing.Color.Red;
                txtErrorDNIE.Text = "El DNI debe contener 6 o mas caracteres";
                txtErrorDNIE.Enabled = false;
                txtErrorDNIE.Visible = true;
                bandera = false;
            }
            if (!helper.soloNumeros(txbDNI.Text) || string.IsNullOrEmpty(txbDNI.Text))
            {
                txbDNI.BorderColor = System.Drawing.Color.Red;
                txtErrorDNIE.Text = "Campo DNI vacío o formato incorrecto. Sólo números.";
                txtErrorDNIE.Enabled = false;
                txtErrorDNIE.Visible = true;
                bandera = false;
            }
            if (Request.QueryString["id"] == null)
            {
                if (!helper.cantidadCaracteres(txbClave.Text))
                {
                    txbClave.BorderColor = System.Drawing.Color.Red;
                    txtErrorClaveE.Text = "La clave debe contener 3 o mas caracteres";
                    txtErrorClaveE.Enabled = false;
                    txtErrorClaveE.Visible = true;
                    bandera = false;
                }
                if (!helper.soloNumeros(txbClave.Text))
                {
                    txbClave.BorderColor = System.Drawing.Color.Red;
                    txtErrorClaveE.Text = "Clave incorrecta.Solo se aceptan números.";
                    txtErrorClaveE.Enabled = false;
                    txtErrorClaveE.Visible = true;
                    bandera = false;
                }
                if (string.IsNullOrEmpty(txbClave.Text))
                {
                    txbClave.BorderColor = System.Drawing.Color.Red;
                    txtErrorClaveE.Text = "Campo clave no puede estar vacío";
                    txtErrorClaveE.Enabled = false;
                    txtErrorClaveE.Visible = true;
                    bandera = false;
                }
           
            }

            return bandera;
        }

        private void reiniciarFormato()
        {
            txbNombre.BorderColor = System.Drawing.Color.Black;
            txbApellido.BorderColor = System.Drawing.Color.Black;
            txbDNI.BorderColor = System.Drawing.Color.Black;
            txbEmail.BorderColor = System.Drawing.Color.Black;
            txbTelefono.BorderColor = System.Drawing.Color.Black;
            txbClave.BorderColor = System.Drawing.Color.Black;
        }
    }
}