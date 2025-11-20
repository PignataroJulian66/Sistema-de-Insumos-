using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface IComponenteInventario
    {
        
        int Id { get; set; }
        string Nombre { get; set; }

        
        decimal ObtenerPrecio();
        int CalcularExistencias();
        string MostrarDetalles(int nivel);
    }
}
