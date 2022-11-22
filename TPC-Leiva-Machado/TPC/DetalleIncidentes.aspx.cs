﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class DetalleIncidentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.esTelefonista(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de administrador o supervisor para ingresar en esta seccion");
                Response.Redirect("Errores.aspx", false);
            }

            btnAceptarI.Visible = false;
            lbEmpleadoAsignado.Visible = false;
            dwEmpleadoAsignado.Visible = false;

            if (Session["Perfil"] != null && Session["Perfil"].Equals(3))
            {
                btnAceptarI.Visible = true;
                //lbEmpleadoAsignado.Visible = true;
                //dwEmpleadoAsignado.Visible = true;
            }


            try
            {
                if (!IsPostBack)
                {
                    TipoNegocio tipoNegocio = new TipoNegocio();
                    PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                    EstadoNegocio estadoNegocio = new EstadoNegocio();
                    MotivoNegocio motivoNegocio = new MotivoNegocio();
                    EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();

                    List<TipoIncidencia> listaTipo = tipoNegocio.listarTipo();
                    List<Prioridad> listaPrioridad = prioridadNegocio.listarPrioridad();
                    List<Estado> listaEstados = estadoNegocio.listarEstado();
                    //List<Motivo> listaMotivos = motivoNegocio.listarMotivos();
                    //List<Empleado> listaEmpleados = empleadoNegocio.listarEmpleados();

                    dwTipoI.DataSource = listaTipo;
                    dwTipoI.DataValueField = "Id";
                    dwTipoI.DataTextField = "Descripcion";
                    dwTipoI.DataBind();

                    dwPrioridadI.DataSource = listaPrioridad;
                    dwPrioridadI.DataValueField = "Id";
                    dwPrioridadI.DataTextField = "Descripcion";
                    dwPrioridadI.DataBind();

                    dwEstadoI.DataSource = listaEstados;
                    dwEstadoI.DataValueField = "Id";
                    dwEstadoI.DataTextField = "Descripcion";
                    dwEstadoI.DataBind();

                    /*dwMotivoI.DataSource = listaMotivos;
                    dwMotivoI.DataValueField = "Id";
                    dwMotivoI.DataTextField = "Descripcion";
                    dwMotivoI.DataBind();

                    dwEmpleadoAsignado.DataSource = listaEmpleados;
                    dwEmpleadoAsignado.DataValueField = "Id";
                    dwEmpleadoAsignado.DataTextField = "Apellidos";
                    dwEmpleadoAsignado.DataBind();*/
                }
                if (Request.QueryString["id"] != null && !IsPostBack)
                {
                    dwTipoI.Enabled = false;
                    dwPrioridadI.Enabled = false;
                    txProblematicaI.Enabled = false;
                    //dwEstadoI.Enabled = false;
                    //dwMotivoI.Enabled = false;
                    //txComentarioI.Enabled = false;
                    //txFechaAltaI.Enabled = false;
                    //txFechaBajaI.Enabled = false;



                    IncidenteNegocio negocio = new IncidenteNegocio();
                    Incidente seleccionado = negocio.listarDetallePorId(Int32.Parse(Request.QueryString["id"]));
                    ;
                    //lo guardamos en session
                    Session.Add("IncidenteSeleccionado", seleccionado);

                    //cargamos los campos del formulario
                    dwTipoI.SelectedValue = seleccionado.Tipo.Id.ToString();
                    dwPrioridadI.SelectedValue = seleccionado.Prioridad.Id.ToString();
                    txProblematicaI.Text = seleccionado.Problematica;
                    dwEstadoI.SelectedValue = seleccionado.Estado.Id.ToString();
                    //dwMotivoI.SelectedValue = seleccionado.Motivo.Id.ToString();
                    //dwEmpleadoAsignado.SelectedValue = seleccionado.EmpleadoAsignado.Id.ToString();
                    //txComentarioI.Text = seleccionado.Comentario;
                    //txFechaAltaI.Text = seleccionado.FechaDeAlta;
                    //txFechaBajaI.Text = seleccionado.FechaDeBaja;

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "No se econtro la incidencia");
                Response.Redirect("Errores.aspx", false);
            }
        }

        protected void btnAceptarI_Click(object sender, EventArgs e)
        {
            if (Session["Perfil"] != null && Session["Perfil"].Equals(3))
            {

            }
        }
    }
}