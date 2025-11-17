using BE;
using DAL;
using SEGURIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorUsuarios
    {

        public bool EsEmpleado(int usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];          
            parametros[0] = new SqlParameter("@ID_Usuario", usuario);
            bool Esempleado = bool.Parse(DAL.Acceso.Instancia.leerEscalar("sp_EsEmpleado", parametros).ToString());
            return Esempleado;
        }

        public bool EsProveedor(int usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID_Usuario", usuario);
            bool esproveedor = bool.Parse(DAL.Acceso.Instancia.leerEscalar("sp_EsProveedor", parametros).ToString());
            return esproveedor;
        }

        public int InicioSesion(string email, string contraseña)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                int Id_usuario = -1;
                parametros[0] = new SqlParameter("@Email", email);
                parametros[1] = new SqlParameter("@Contraseña", Encriptación.Instancia.Encriptar(contraseña));
                if(DAL.Acceso.Instancia.leerEscalar("sp_InicioSesion", parametros) != null)
                {
                    Id_usuario = int.Parse(DAL.Acceso.Instancia.leerEscalar("sp_InicioSesion", parametros).ToString());          
                }
                return Id_usuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine("error al iniciar sesion" + ex.Message);
                return -1;
            }
           
        }

        public CLSProveedor BuscarProveedor(int id_usuario)
        {
            try
            {
                CLSProveedor proveedor = new CLSProveedor();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@ID_Usuario", id_usuario);
                DataTable dt = DAL.Acceso.Instancia.leer("SP_BuscarProveedor", parametros);
                foreach(DataRow dr in dt.Rows)
                {
                    proveedor.ID_prov = int.Parse(dr["ID_prov"].ToString());
                    proveedor.Nombre = dr["Nombre_prov"].ToString();
                    proveedor.Cuit = dr["Cuit"].ToString();
                    proveedor.Direccion = dr["Direccion_prov"].ToString();
                    proveedor.Telefono = dr["Telefono_prov"].ToString();
                }
                return proveedor;
            }catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public CLSEmpleado BuscarEmpleado(int id_usuario)
        {
            try
            {
                CLSEmpleado empleado = new CLSEmpleado();
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@ID_Usuario", id_usuario);
                DataTable dt = DAL.Acceso.Instancia.leer("SP_BuscarEmpleado", parametros);
                foreach (DataRow dr in dt.Rows)
                {
                    empleado.ID_emp = int.Parse(dr["Id_emp"].ToString());
                    empleado.Nombre = dr["Nombre_emp"].ToString();
                    empleado.Apellido = dr["Apellido_emp"].ToString();
                    empleado.DNI = dr["Dni"].ToString();
                    empleado.Direccion = dr["Direccion_emp"].ToString();
                    empleado.Telefono = dr["Telefono_emp"].ToString();
                    empleado.Rol = dr["Rol"].ToString();
                }
                return empleado;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
