using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClsEmpleado
    {
        mp_Empleado mapper = new mp_Empleado();

        public int Agregar(BE.CLSEmpleado empleado, string email)
        {
            int fa = 0;
            fa = mapper.Agregar(empleado, email);
            return fa;
        }

        public int Eliminar(BE.CLSEmpleado empleado)
        {
            int fa = 0;
            fa = mapper.Eliminar(empleado);
            return fa;
        }

        public int Editar(BE.CLSEmpleado empleado, string email)
        {
            int fa = 0;
            fa = mapper.Editar(empleado, email);
            return fa;
        }

        public List<BE.CLSEmpleado> Listar()
        {
            List<BE.CLSEmpleado> lista = mapper.Listar();
            return lista;
        }

        public string ObtenerMail(CLSEmpleado empleado)
        {
            return mapper.ObtenerMail(empleado);
        }
    }
}

