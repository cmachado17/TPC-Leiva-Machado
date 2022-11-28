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

        }
    }
}