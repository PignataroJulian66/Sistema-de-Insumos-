using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClsCliente
    {
        mp_Cliente mapper = new mp_Cliente();

        public int Agregar(BE.ClsCliente cliente)
        {
            int fa = 0;
            fa = mapper.Agregar(cliente);
            return fa;
        }

        public int Eliminar(BE.ClsCliente cliente)
        {
            int fa = 0;
            fa = mapper.Eliminar(cliente);
            return fa;
        }

        public int Editar(BE.ClsCliente cliente)
        {
            int fa = 0;
            fa = mapper.Editar(cliente);
            return fa;
        }

        public List<BE.ClsCliente> Listar()
        {
            List<BE.ClsCliente> lista = mapper.Listar();
            return lista;
        }
    }
}

