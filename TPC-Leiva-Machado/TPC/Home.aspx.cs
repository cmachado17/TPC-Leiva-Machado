using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helpers;

namespace TPC
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbError.Visible = false;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();

            if (validarContacto())
            {
                string cuerpo = "<html><h1>Aviso de contacto</h1><p>Hola, hemos recibido tu contacto y te responderemos a la brevedad.</p><p>Gracias por utilizar nuestros servicios.</p></html>";
                emailService.armarCorreo(txtCorreoContacto.Text, "Contacto Callcenter", cuerpo);
                emailService.enviarEmail();
                Response.Redirect("Home.aspx", true);
            }
            else
            {
                lbError.Visible = true;
            }


          
        }

        protected bool validarContacto()
        {

            bool bandera = true;
            MetodosCompartidos helper = new MetodosCompartidos();

            if(!helper.formatoEmail(txtCorreoContacto.Text) || string.IsNullOrEmpty(txtCorreoContacto.Text))
            {
                txtCorreoContacto.BorderColor = System.Drawing.Color.Red;
                bandera = false;
            }

            if (string.IsNullOrEmpty(txComentario.Text))
            {
                txComentario.BorderColor = System.Drawing.Color.Red;
                bandera = false;
            }

            return bandera;
        }

        protected void reiniciarFormato()
        {
            txtCorreoContacto.BorderColor = System.Drawing.Color.Black;
            txComentario.BorderColor = System.Drawing.Color.Black;
        }
    }
}