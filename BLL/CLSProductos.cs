using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CLSProductos
    {
        mp_Productos mapper = new mp_Productos();

        public int Agregar(BE.ClsProductos Producto)
        {
            int fa = 0;
            fa = mapper.Agregar(Producto);
            return fa;
        }

        public int Eliminar(BE.ClsProductos Producto)
        {
            int fa = 0;
            fa = mapper.Eliminar(Producto);
            return fa;
        }

        public int Editar(BE.ClsProductos Producto)
        {
            int fa = 0;
            fa = mapper.Editar(Producto);
            return fa;
        }

        public List<BE.ClsProductos> Listar()
        {
            List<BE.ClsProductos> lista = mapper.Listar();
            return lista;
        }

    }
}
