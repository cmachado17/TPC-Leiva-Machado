using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class ModificarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtModificarNombre.Enabled = false;
            txtModificarApellido.Enabled = false;
            txtModificarDNI.Enabled = false;
        }

        protected void btnConfirmarM_Click(object sender, EventArgs e)
        {

        }
    }
}