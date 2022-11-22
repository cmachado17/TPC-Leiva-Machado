﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using Helpers;

namespace TPC
{
    public partial class FormularioIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //tiene q entrar tele
            if (((!Seguridad.esTelefonista(Session["empleadoLogueado"]) && !Seguridad.esSupervisor(Session["empleadoLogueado"]))))
            {
                Session.Add("error", "Se necesita perfil de telefonista o supervisor para ingresar en esta seccion");
                Response.Redirect("Errores.aspx", false);
            }

            lbMotivo.Visible = false;
            dwMotivo.Visible = false;
            lbComentario.Visible = false;
            txComentario.Visible = false;
            lbEmpleado.Visible = false;
            dwEmpleados.Visible = false;

            try
            {
                if (!IsPostBack)
                {
                    TipoNegocio tipoNegocio = new TipoNegocio();
                    PrioridadNegocio prioridadNegocio = new PrioridadNegocio();

                    List<TipoIncidencia> listaTipo = tipoNegocio.listarTipo();
                    List<Prioridad> listaPrioridad = prioridadNegocio.listarPrioridad();

                    dwTipo.DataSource = listaTipo;
                    dwTipo.DataValueField = "Id";
                    dwTipo.DataTextField = "Descripcion";
                    dwTipo.DataBind();

                    dwPrioridad.DataSource = listaPrioridad;
                    dwPrioridad.DataValueField = "Id";
                    dwPrioridad.DataTextField = "Descripcion";
                    dwPrioridad.DataBind();

                }

                if (Request.QueryString["incidencia"] != null && Request.QueryString["accion"] == null && !IsPostBack)
                {
                    btnAceptar.Text = "Modificar";
                    dwTipo.Enabled = false;
                    dwPrioridad.Enabled = false;

                    IncidenteNegocio negocio = new IncidenteNegocio();
                    Incidente seleccionado = negocio.listarIncidentePorId(Int32.Parse(Request.QueryString["incidencia"]));

                    //lo guardamos en session
                    Session.Add("IncidenteSeleccionado", seleccionado);

                    //cargamos los campos del formulario
                    dwTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    dwPrioridad.SelectedValue = seleccionado.Prioridad.Id.ToString();
                    txProblematica.Text = seleccionado.Problematica;
                }
                else if (Request.QueryString["accion"] != null && !IsPostBack)
                {
                    dwTipo.Enabled = false;
                    dwPrioridad.Enabled = false;
                    txProblematica.Enabled = false;

                    IncidenteNegocio negocio = new IncidenteNegocio();
                    Incidente seleccionado = negocio.listarIncidentePorId(Int32.Parse(Request.QueryString["incidencia"]));

                    dwTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    dwPrioridad.SelectedValue = seleccionado.Prioridad.Id.ToString();
                    txProblematica.Text = seleccionado.Problematica;

                    if (Request.QueryString["accion"] == "resolver")
                    {
                        lbComentario.Visible = true;
                        txComentario.Visible = true;
                        btnAceptar.Text = "Resolver";
                    } else if (Request.QueryString["accion"] == "reasignar")
                    {
                        lbEmpleado.Visible = true;
                        dwEmpleados.Visible = true;
                        btnAceptar.Text = "Reasignar";

                        EmpleadoNegocio negocioEmpleado = new EmpleadoNegocio();
                        List<Empleado> lista = negocioEmpleado.listarTelefonistas();

                        dwEmpleados.DataSource = lista;
                        dwEmpleados.DataValueField = "Id";
                        dwEmpleados.DataTextField = "Nombres";
                        dwEmpleados.DataBind();
                    }
                    else
                    {
                        MotivoNegocio motivoNegocio = new MotivoNegocio();

                        List<Motivo> motivos = motivoNegocio.listarMotivos();

                        dwMotivo.DataSource = motivos;
                        dwMotivo.DataValueField = "Id";
                        dwMotivo.DataTextField = "Descripcion";
                        dwMotivo.DataBind();

                        btnAceptar.Text = "Cerrar";
                        lbMotivo.Visible = true;
                        dwMotivo.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Incidente nuevo = new Incidente();
                IncidenteNegocio negocio = new IncidenteNegocio();
                ClienteNegocio negocioCliente = new ClienteNegocio();
                EmpleadoNegocio negocioEmpleado = new EmpleadoNegocio();
                EmailService emailService = new EmailService();

                if (Request.QueryString["incidencia"] != null && Request.QueryString["accion"] == null)
                {
                    nuevo = negocio.listarIncidentePorId(Int32.Parse(Request.QueryString["incidencia"]));
                    nuevo.Problematica = txProblematica.Text;
                    negocio.modificarEnAnalisis(nuevo);
                    Response.Redirect("AreaPersonal.aspx", false);
                }else if(Request.QueryString["accion"] == "resolver")
                {
                    nuevo = negocio.listarIncidentePorId(Int32.Parse(Request.QueryString["incidencia"]));
                    nuevo.Comentario = txComentario.Text;
                    negocio.resolverIncidente(nuevo);
                    Response.Redirect("AreaPersonal.aspx", false);
                }
                else if (Request.QueryString["accion"] == "cerrar")
                {
                    nuevo = negocio.listarIncidentePorId(Int32.Parse(Request.QueryString["incidencia"]));
                    nuevo.Motivo = new Motivo();
                    nuevo.Motivo.Id = int.Parse(dwMotivo.SelectedValue);
                    negocio.cerrarIncidente(nuevo);
                    Response.Redirect("AreaPersonal.aspx", false);
                }
                else if (Request.QueryString["accion"] == "reasignar")
                {
                    nuevo = negocio.listarIncidentePorId(Int32.Parse(Request.QueryString["incidencia"]));
                    nuevo.EmpleadoAsignado.Id = int.Parse(dwEmpleados.SelectedValue);
                    negocio.reasignarIncidente(nuevo);
                    Response.Redirect("Incidentes.aspx", false);
                }
                else if (Request.QueryString["id"] != null)
                {
                    nuevo.Tipo = new TipoIncidencia();
                    nuevo.Tipo.Id = int.Parse(dwTipo.SelectedValue);
                    nuevo.Prioridad = new Prioridad();
                    nuevo.Prioridad.Id = int.Parse(dwPrioridad.SelectedValue);
                    nuevo.Problematica = txProblematica.Text;
                    //estado?
                    nuevo.Cliente = negocioCliente.listarClientePorId(int.Parse(Request.QueryString["id"]));
                    nuevo.EmpleadoAsignado = negocioEmpleado.listarEmpleadoPorId(((Empleado)Session["empleadoLogueado"]).Id);
                    negocio.agregarIncidencia(nuevo);
                    emailService.armarCorreo(nuevo.Cliente.Email, "Probando", "hola");
                    emailService.enviarEmail();
                    Response.Redirect("Clientes.aspx", false);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}