using Dominio;
using Helpers;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empleadoLogueado"] != null)
            {
                Session.Add("error", "Ya existe un usuario logueado");
                Response.Redirect("Errores.aspx");
            }
                txtErrorClave.Visible = false;
            txtErrorEmail.Visible = false;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Session.Remove("empleadoLogueado");
            Empleado datosLogin;
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            Empleado empleado = new Empleado();

            try
            {
                if (validarLogin())
                {
                    datosLogin = new Empleado(txtUser.Text, int.Parse(txtClave.Text));

                    empleado = negocio.Loguear(datosLogin);

                    if (empleado.Id != 0 && empleado.Activo)
                    {

                        Session.Add("empleadoLogueado", empleado);
                        Response.Redirect("Home.aspx", false);
                        //te envia a home, despues en en load de cada pagina
                        //va a mostrar o no dependiendo del perfil que se
                        //encuentra en session

                    }else if (empleado.Id != 0 && !empleado.Activo)
                    {
                        Session.Add("error", "El usuario se encuentra desactivado, contacte a un supervisor.");
                        Response.Redirect("Errores.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "User o pass incorecto");
                        Response.Redirect("Errores.aspx", false);
                    }
                }

            } catch (Exception ex)
            {
                Session.Add("error", "Error al intentar loguearse");
                Response.Redirect("Errores.aspx", false);
            }

                       
        }

        private bool validarLogin()
        {
            reiniciarFormato();
            bool bandera = true;
            MetodosCompartidos helper = new MetodosCompartidos();

            if (!helper.cantidadCaracteres(txtClave.Text))
                 {
                     txtClave.BorderColor = System.Drawing.Color.Red;

                     txtErrorClave.Text = "Debe contener 3 o mas caracteres";
                     txtErrorClave.Enabled = false;
                     txtErrorClave.Visible = true;

                     bandera = false;
                 }


            //los helpers devuelven FALSE si no validan
            if (!helper.soloNumeros(txtClave.Text) || string.IsNullOrEmpty(txtClave.Text))
            {
                txtClave.BorderColor = System.Drawing.Color.Red;
                
                txtErrorClave.Text = "Formato incorrecto o campo incompleto. Solo se admiten numeros";
                txtErrorClave.Enabled = false;
                txtErrorClave.Visible = true;
               
                bandera = false;

            }

            if (!helper.formatoEmail(txtUser.Text) || string.IsNullOrEmpty(txtUser.Text))
            {
                txtUser.BorderColor = System.Drawing.Color.Red;
               
                txtErrorEmail.Text = "Formato incorrecto o campo incompleto";
                txtErrorEmail.Enabled = false;
                txtErrorEmail.Visible = true;
                bandera = false;
            }
            return bandera;
        }

        private void reiniciarFormato()
        {
            txtUser.BorderColor = System.Drawing.Color.Black;
            txtClave.BorderColor = System.Drawing.Color.Black;

        }

        protected void btnOlvideMiPass_Click(object sender, EventArgs e)
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            EmailService emailService = new EmailService();
            try
            {
                if (validarOlvideMiPass())
                {
                    Empleado aux = negocio.buscarEmpleadoPorEmail(txtUser.Text);
                    string cuerpo = "<html><h1>" + aux.Nombres + "</h1><p>Hola, hemos recibido la solicitud de reestablecer tu contraseña. La misma es <span style=\"font-weight: bold;\">" + aux.Clave.ToString() +"</span></p><p>Gracias por utilizar nuestros servicios.</p></html>";
                    emailService.armarCorreo(aux.Email, "Restablecer contraseña", cuerpo);
                    emailService.enviarEmail();

                    string msg = "Se te enviaran las credenciales via email.";
                    Response.Write("<script>alert('" + msg + "')</script>");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al reiniciar contraseña");
                Response.Redirect("Errores.aspx", false);
            }
        }

        private bool validarOlvideMiPass()
        {
            reiniciarFormato();
            bool bandera = true;
            MetodosCompartidos helper = new MetodosCompartidos();

            if (!helper.formatoEmail(txtUser.Text) || string.IsNullOrEmpty(txtUser.Text))
            {
                txtUser.BorderColor = System.Drawing.Color.Red;

                txtErrorEmail.Text = "Debe completar el campo Email para resetear su contraseña.";
                txtErrorEmail.Enabled = false;
                txtErrorEmail.Visible = true;
                bandera = false;
            }
            return bandera;
        }
    }
}