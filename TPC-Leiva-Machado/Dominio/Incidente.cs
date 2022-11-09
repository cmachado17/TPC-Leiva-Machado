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
        public Clientes Cliente { get; set; }
        public string Resolucion { get; set; }
        public Telefonista Telefonista { get; set; }
        public string Motivo { get; set; }
    }
}
