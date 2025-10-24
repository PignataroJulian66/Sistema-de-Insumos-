using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mp_Empleado
    {
        Acceso acceso = new Acceso();

        public int Agregar(BE.CLSEmpleado empleado)
        {
            int fa = 0;
          
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("@ID_emp", empleado.ID_emp);
            parametros[1] = new SqlParameter("@Nombre", empleado.Nombre);
            parametros[2] = new SqlParameter("@Apellido", empleado.Apellido);
            parametros[3] = new SqlParameter("@Telefono", empleado.Telefono);
            parametros[4] = new SqlParameter("@Direccion", empleado.Direccion);
            parametros[5] = new SqlParameter("@Rol", empleado.Rol);
            parametros[6] = new SqlParameter("@DNI", empleado.DNI);

          
            fa = acceso.escribir("sp_InsertarEmpleado", parametros);
            return fa;
        }

        public int Eliminar(BE.CLSEmpleado empleado)
        {
            int fa = 0;
          
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID_emp", empleado.ID_emp);

            fa = acceso.escribir("sp_EliminarEmpleado", parametros);
            return fa;
        }

        public int Editar(BE.CLSEmpleado empleado)
        {
            int fa = 0;
           
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("@ID_emp", empleado.ID_emp);
            parametros[1] = new SqlParameter("@Nombre", empleado.Nombre);
            parametros[2] = new SqlParameter("@Apellido", empleado.Apellido);
            parametros[3] = new SqlParameter("@Telefono", empleado.Telefono);
            parametros[4] = new SqlParameter("@Direccion", empleado.Direccion);
            parametros[5] = new SqlParameter("@Rol", empleado.Rol);
            parametros[6] = new SqlParameter("@DNI", empleado.DNI);

         
            fa = acceso.escribir("sp_EditarEmpleado", parametros);
            return fa;
        }

        public List<BE.CLSEmpleado> Listar()
        {
            List<BE.CLSEmpleado> lista = new List<BE.CLSEmpleado>();

            
            DataTable tabla = acceso.leer("sp_ListarEmpleados", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.CLSEmpleado empleado = new BE.CLSEmpleado();
                empleado.ID_emp = int.Parse(dr["ID_emp"].ToString());
                empleado.Nombre = dr["Nombre"].ToString();
                empleado.Apellido = dr["Apellido"].ToString();
                empleado.Telefono = dr["Telefono"].ToString();
                empleado.Direccion = dr["Direccion"].ToString();
                empleado.Rol = dr["Rol"].ToString();
                empleado.DNI = dr["DNI"].ToString();
                lista.Add(empleado);
            }
            return lista;
        }
    }
}
