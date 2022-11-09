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
        public Usuario UsuarioAsignado { get; set; }
        public string Comentario { get; set; }
        public Motivo Motivo { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime FechaDeBaja { get; set; }
        public Boolean Activo { get; set; }
    }
}
