using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClsInsumo
    {
        mp_Insumo mapper = new mp_Insumo();

        public int Agregar(BE.ClsInsumo insumo)
        {
            int fa = 0;
            fa = mapper.Agregar(insumo);
            return fa;
        }

        public int Eliminar(BE.ClsInsumo insumo)
        {
            int fa = 0;
            fa = mapper.Eliminar(insumo);
            return fa;
        }

        /*public int Editar(BE.ClsInsumo insumo)
        {
            int fa = 0;
            fa = mapper.Editar(insumo);
            return fa;
        }*/

        public List<BE.ClsInsumo> Listar()
        {
            List<BE.ClsInsumo> lista = mapper.Listar();
            return lista;
        }
    }
}
