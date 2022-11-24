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
    }
}
