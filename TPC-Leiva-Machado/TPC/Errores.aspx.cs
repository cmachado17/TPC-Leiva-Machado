﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPC
{
    public partial class Errores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            String error = null;

            if (Session["error"] != null)
            {
                txtError.Text = (String) Session["error"];
            }
        }
    }
}