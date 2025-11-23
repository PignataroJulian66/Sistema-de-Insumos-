using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsRegistroBitacora
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; } 
        public string Criticidad { get; set; } 
        public string Mensaje { get; set; } 
        public string TipoEvento { get; set; } 
    }
}
