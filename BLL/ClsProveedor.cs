using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClsProveedor
    {
        mp_Proveedor mapper = new mp_Proveedor();

        public int Agregar(BE.CLSProveedor proveedor, string email)
        {
            int fa = 0;
            fa = mapper.Agregar(proveedor, email);
            return fa;
        }

        public int Eliminar(BE.CLSProveedor proveedor)
        {
            int fa = 0;
            fa = mapper.Eliminar(proveedor);
            return fa;
        }

        public int Editar(BE.CLSProveedor proveedor, string email)
        {
            int fa = 0;
            fa = mapper.Editar(proveedor, email);
            return fa;
        }

        public List<BE.CLSProveedor> Listar()
        {
            List<BE.CLSProveedor> lista = mapper.Listar();
            return lista;
        }

        public string ObtenerMailProveedor(CLSProveedor prov)
        {
            return mapper.ObtenerMailProveedor(prov);
        }
    }
}
