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
    public partial class FormularioAdministracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["categoria"] == "prioridad")
                {
                    Prioridad nuevo = new Prioridad();
                    PrioridadNegocio negocio = new PrioridadNegocio();

                    nuevo.Descripcion = txbDescripcion.Text;

                    negocio.agregarPrioridad(nuevo);
                    Response.Redirect("Administracion.aspx", false);
                }
                else
                {
                    TipoIncidencia nuevo = new TipoIncidencia();
                    TipoNegocio negocio = new TipoNegocio();

                    nuevo.Descripcion = txbDescripcion.Text;

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