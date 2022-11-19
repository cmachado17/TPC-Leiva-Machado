﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class IncidenteNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<Incidente> listarIncidente()
        {
            List<Incidente> lista = new List<Incidente>();

            try
            {
                datos.setearConsulta("sp_listar_Incidentes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = new TipoIncidencia();
                    aux.Tipo.Id = (int)datos.Lector["IdTipoIncidencia"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.Id = (int)datos.Lector["IdPrioridad"];
                    aux.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    aux.Problematica = (string)datos.Lector["Problematica"];
                    aux.Estado = new Estado();
                    aux.Estado.Id = (int)datos.Lector["IdEstado"];
                    aux.Estado.Descripcion = (string)datos.Lector["Estado"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.Id = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Nombres = (string)datos.Lector["Cliente"];
                    //aux.Cliente.Apellidos = (string)datos.Lector["ApellidoCliente"];
                    aux.Cliente.DNI = (string)datos.Lector["DNICliente"];
                    aux.Cliente.Email = (string)datos.Lector["EmailCliente"];
                    aux.Cliente.Telefono = (string)datos.Lector["TelefonoCliente"];
                    aux.EmpleadoAsignado = new Empleado();
                    aux.EmpleadoAsignado.Id = (int)datos.Lector["IdEmpleado"];
                    aux.EmpleadoAsignado.Nombres = (string)datos.Lector["EmpleadoAsignado"];
                    //aux.EmpleadoAsignado.Apellidos = (string)datos.Lector["ApellidoTel"];
                    aux.Comentario = datos.Lector["Comentario"] != DBNull.Value ? (string)datos.Lector["Comentario"] : "";
                    aux.Motivo = new Motivo();
                    aux.Motivo.Descripcion = datos.Lector["Motivo"] != DBNull.Value ? (string)datos.Lector["Motivo"] : "";
                    aux.FechaDeAlta = datos.Lector["FechaDeAlta"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeAlta"]).ToShortDateString() : "";
                    aux.FechaDeBaja = datos.Lector["FechaDeBaja"] != DBNull.Value ? ((DateTime)datos.Lector["FechaDeBaja"]).ToShortDateString() : "";
                    aux.Activo = (Boolean)datos.Lector["Activo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarIncidencia(Incidente nuevo)
        {
            try
            {
                datos.limpiarParametros();
                datos.setearSP("sp_Agregar_Incidencia");
                datos.setearParametro("@IdTipo", nuevo.Tipo.Id);
                datos.setearParametro("@Prioridad", nuevo.Prioridad.Id);
                datos.setearParametro("@Problematica", nuevo.Problematica);
                datos.setearParametro("@Cliente", nuevo.Cliente.Id);
                datos.setearParametro("@Empleado", nuevo.EmpleadoAsignado.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
