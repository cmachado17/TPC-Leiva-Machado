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
    public partial class CambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtErrorClaveActual.Visible = false;
            txtErrorClaveNueva.Visible = false;
            txtErrorConfirmarNuevaClave.Visible = false;
        }

        protected void btnConfirmarClave_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                Empleado empleado = new Empleado();

                if (Session["empleadoLogueado"] != null)
                {
                    empleado = (Empleado)Session["empleadoLogueado"];

                    if (validarClave())
                    {
                        if(empleado.Clave == (int.Parse(txtClaveActual.Text)))
                        {
                            empleado.Clave = int.Parse(txtClaveActual.Text);
                            negocio.cambiarClave(empleado);
                            Response.Redirect("AreaPersonal.aspx", false);
                        }
                        else
                        {
                            Session.Add("error", "Error al querer cambiar la clave");
                            Response.Redirect("Errores.aspx", false);
                        }
                    }

                }
               

            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al querer cambiar la clave");
                Response.Redirect("Errores.aspx", false);
            }
        }

             private bool validarClave()
            {
                reiniciarFormato();
                bool bandera = true;
                MetodosCompartidos helper = new MetodosCompartidos();

                if (!helper.cantidadCaracteres(txtClaveActual.Text))
                {
                    txtClaveActual.BorderColor = System.Drawing.Color.Red;

                    txtErrorClaveActual.Text = "Debe contener 3 o mas caracteres";
                    txtErrorClaveActual.Enabled = false;
                    txtErrorClaveActual.Visible = true;

                    bandera = false;
                }
                if (!helper.cantidadCaracteres(txtClaveNueva.Text))
                {
                    txtClaveNueva.BorderColor = System.Drawing.Color.Red;

                    txtErrorClaveNueva.Text = "Debe contener 3 o mas caracteres";
                    txtErrorClaveNueva.Enabled = false;
                    txtErrorClaveNueva.Visible = true;

                    bandera = false;
                }


            if (txtClaveActual.Text == txtClaveNueva.Text)
            {
                txtClaveNueva.BorderColor = System.Drawing.Color.Red;

                txtErrorClaveNueva.Text = "La nueva clave no puede ser igual a la anterior";
                txtErrorClaveNueva.Enabled = false;
                txtErrorClaveNueva.Visible = true;

                bandera = false;
            }

            if (txtClaveNueva.Text != txtConfirmarNuevaClave.Text)
            {
                txtConfirmarNuevaClave.BorderColor = System.Drawing.Color.Red;

                txtErrorConfirmarNuevaClave.Text = "Deben coincidir las claves";
                txtErrorConfirmarNuevaClave.Enabled = false;
                txtErrorConfirmarNuevaClave.Visible = true;

                bandera = false;
            }




            //los helpers devuelven FALSE si no validan
            if (!helper.soloNumeros(txtClaveActual.Text) || string.IsNullOrEmpty(txtClaveActual.Text))
                {
                    txtClaveActual.BorderColor = System.Drawing.Color.Red;

                    txtErrorClaveActual.Text = "Formato incorrecto o campo incompleto. Solo se admiten numeros";
                    txtErrorClaveActual.Enabled = false;
                    txtErrorClaveActual.Visible = true;

                    bandera = false;

                }

            if (!helper.soloNumeros(txtClaveNueva.Text) || string.IsNullOrEmpty(txtClaveNueva.Text))
            {
                txtClaveNueva.BorderColor = System.Drawing.Color.Red;

                txtErrorClaveNueva.Text = "Formato incorrecto o campo incompleto. Solo se admiten numeros";
                txtErrorClaveNueva.Enabled = false;
                txtErrorClaveNueva.Visible = true;

                bandera = false;

            }

            if (!helper.soloNumeros(txtConfirmarNuevaClave.Text) || string.IsNullOrEmpty(txtConfirmarNuevaClave.Text))
            {
                txtConfirmarNuevaClave.BorderColor = System.Drawing.Color.Red;

                txtErrorConfirmarNuevaClave.Text = "Formato incorrecto o campo incompleto. Solo se admiten numeros";
                txtErrorConfirmarNuevaClave.Enabled = false;
                txtErrorConfirmarNuevaClave.Visible = true;

                bandera = false;

            }



            return bandera;
            }

            private void reiniciarFormato()
            {
                txtClaveActual.BorderColor = System.Drawing.Color.Black;
                txtClaveNueva.BorderColor = System.Drawing.Color.Black;
                txtConfirmarNuevaClave.BorderColor = System.Drawing.Color.Black;
            }
        }
    }