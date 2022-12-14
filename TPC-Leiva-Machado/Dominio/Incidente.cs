using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Incidente
    {
        public int Id { get; set; }
        public TipoIncidencia Tipo { get; set; }
        public Prioridad Prioridad { get; set; }
        public string Problematica { get; set; }
        public Estado Estado { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado EmpleadoAsignado { get; set; }
        public string Comentario { get; set; }
        public Motivo Motivo { get; set; }
        public string FechaDeAlta { get; set; }
        public string FechaDeBaja { get; set; }
        public Boolean Activo { get; set; }
    }
}
