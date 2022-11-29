using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Helpers
{
    public class MetodosCompartidos
    {
        public bool soloLetras(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsLetter(caracter))) return false;
            }
            return true;
        }
        public bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter))) return false;

            }
            return true;
        }

        public bool soloLetrasYNumeros(string cadena)
        {
            bool bandera = false;
            foreach (char caracter in cadena)
            {
                bandera = false;
                if (char.IsLetter(caracter) || char.IsNumber(caracter))
                    bandera = true;

            }
            return bandera;
        }

        public bool formatoEmail(string cadena)
        {
            int contador = 0;

            foreach(char c in cadena)
            {
                if(c == '@')
                {
                    contador++;
                }
            }

            if (contador == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int buscarEstadoIncidencia(string key)
        {
            IncidenteNegocio negocio = new IncidenteNegocio();

            return negocio.listarIncidentePorId(int.Parse(key)).Estado.Id;
        }

        public bool cantidadCaracteres(string cadena)
        {
            if (!(cadena.Length >= 3)) return false;
         
            return true;
        }

        public bool cantidadCaracteresDNI(string cadena)
        {
            if (!(cadena.Length >= 6)) return false;

            return true;
        }

        public string getFormatEmail(string accion, Incidente incidente)
        {
            string html = "";

            switch (accion)
            {
                case "resolver":
                    html = "<html><body><h2>" + incidente.Cliente.Nombres + "</h2><p> Tu incidencia #"+ incidente.Id + " fue resuelta satisfactoriamente. Esta es la respuesta del operador:</p> <div style=\"border: 1px solid gray; background-color: rgb(211, 209, 209); margin: 20px 0px; padding: 10px 20px;\"><p>" + incidente.Comentario + "</p></div><p>Gracias por utilizar nuestros servicios.</p></body></html>";
                    break;
                case "cerrar":
                    html = "<html><body><h2>" + incidente.Cliente.Nombres + "</h2><p> Tu incidencia #" + incidente.Id + " fue cerrada. Esta es la respuesta del operador:</p> <div style=\"border: 1px solid gray; background-color: rgb(211, 209, 209); margin: 20px 0px; padding: 10px 20px;\"><p>" + incidente.Comentario + "</p></div><p>Gracias por utilizar nuestros servicios.</p></body></html>";
                    break;
                case "alta":
                    html = "<html><body><h2>" + incidente.Cliente.Apellidos +", " + incidente.Cliente.Nombres + "</h2><p> Se dio de alta la incidencia #" + incidente.Id + "</p> <p>Esta es la problematica detallada: </p> <div style=\"border: 1px solid gray; background-color: rgb(211, 209, 209); margin: 20px 0px; padding: 10px 20px;\"><p>Tipo: "+ incidente.Tipo.Descripcion + "</p><p>Prioridad: "+ incidente.Prioridad.Descripcion +"</p><p>" + incidente.Problematica + "</p></div> <p>Gracias por utilizar nuestros servicios.</p></body></html>";
                    break;
            }

            return html;
        }
    }
}
