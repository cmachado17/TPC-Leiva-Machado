using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helpers;

namespace TPC
{
    public partial class FormularioAdministracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                txbDescripcion.BorderColor = System.Drawing.Color.Black;
                MetodosCompartidos helper = new MetodosCompartidos();

                //los helpers devuelven FALSE si no validan
                if (!helper.soloLetras(txbDescripcion.Text) || string.IsNullOrEmpty(txbDescripcion.Text))
                {
                    txbDescripcion.BorderColor = System.Drawing.Color.Red;
                    return;
                }

                if (Request.QueryString["categoria"] == "prioridad")
                {
                    Prioridad nuevo = new Prioridad();
                    PrioridadNegocio negocio = new PrioridadNegocio();

                    nuevo.Descripcion = txbDescripcion.Text.ToUpper();

                    if (negocio.buscarPrioridad(nuevo.Descripcion))
                    {
                        txbDescripcion.BorderColor = System.Drawing.Color.Red;
                        return;
                    }
                      
                    negocio.agregarPrioridad(nuevo);
                    Response.Redirect("Administracion.aspx", false);
                }
                else
                {
                    TipoIncidencia nuevo = new TipoIncidencia();
                    TipoNegocio negocio = new TipoNegocio();

                    nuevo.Descripcion = txbDescripcion.Text.ToUpper();

                    if (negocio.buscarTipo(nuevo.Descripcion))
                    {
                        txbDescripcion.BorderColor = System.Drawing.Color.Red;
                        return;
                    }

                    negocio.agregarTipo(nuevo);
                    Response.Redirect("Administracion.aspx", false);
                }
                    
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}