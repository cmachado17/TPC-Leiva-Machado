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
            if (!Seguridad.esTelefonista(Session["empleadoLogueado"]))
            {
                Session.Add("error", "Se necesita perfil de telefonista para ingresar en esta seccion");
                Response.Redirect("Errores.aspx");
            }

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

                nuevo.Tipo = new TipoIncidencia();
                nuevo.Tipo.Id = int.Parse(dwTipo.SelectedValue);
                nuevo.Prioridad = new Prioridad();
                nuevo.Prioridad.Id = int.Parse(dwPrioridad.SelectedValue);
                nuevo.Problematica = txProblematica.Text;
                //estado?
                nuevo.Cliente = negocioCliente.listarClientePorId(int.Parse(Request.QueryString["id"]));
                nuevo.EmpleadoAsignado = negocioEmpleado.listarEmpleadoPorId(((Empleado)Session["empleadoLogueado"]).Id);

                negocio.agregarIncidencia(nuevo);

                Response.Redirect("Clientes.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}