using BE;
using SEGURIDAD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL
{
    public class mp_Empleado
    {
        public int Agregar(BE.CLSEmpleado empleado, string email)
        {
            int fa = 0;

            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = new SqlParameter("@Nombre_emp", empleado.Nombre);
            parametros[1] = new SqlParameter("@Apellido_emp", empleado.Apellido);
            parametros[2] = new SqlParameter("@Telefono_emp", empleado.Telefono);
            parametros[3] = new SqlParameter("@Direccion_emp", empleado.Direccion);
            parametros[4] = new SqlParameter("@ID_rol", int.Parse(empleado.Rol));
            parametros[5] = new SqlParameter("@Dni", empleado.DNI);
            parametros[6] = new SqlParameter("@Email", email);
            parametros[7] = new SqlParameter("@Contraseña", Encriptación.Instancia.Encriptar(empleado.DNI));
            fa = DAL.Acceso.Instancia.escribir("sp_InsertarEmpleado", parametros);
            return fa;
        }

        public int Eliminar(BE.CLSEmpleado empleado)
        {
            int fa = 0;
          
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Id_emp", empleado.ID_emp);

            fa = DAL.Acceso.Instancia.escribir("sp_EliminarEmpleado", parametros);
            return fa;
        }

        public int Editar(BE.CLSEmpleado empleado, string email)
        {
            int fa = 0;

            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = new SqlParameter("@ID_emp", empleado.ID_emp);
            parametros[1] = new SqlParameter("@Nombre", empleado.Nombre);
            parametros[2] = new SqlParameter("@Apellido", empleado.Apellido);
            parametros[3] = new SqlParameter("@Telefono", empleado.Telefono);
            parametros[4] = new SqlParameter("@Direccion", empleado.Direccion);
            parametros[5] = new SqlParameter("@Rol", empleado.Rol);
            parametros[6] = new SqlParameter("@DNI", empleado.DNI);
            parametros[7] = new SqlParameter("@Email", email);


            fa = DAL.Acceso.Instancia.escribir("sp_EditarEmpleado", parametros);
            return fa;
        }

        public List<BE.CLSEmpleado> Listar()
        {
            List<BE.CLSEmpleado> lista = new List<BE.CLSEmpleado>();

            
            DataTable tabla = DAL.Acceso.Instancia.leer("sp_ListarEmpleados", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.CLSEmpleado empleado = new BE.CLSEmpleado();
                empleado.ID_emp = int.Parse(dr["ID_emp"].ToString());
                empleado.Nombre = dr["Nombre_emp"].ToString();
                empleado.Apellido = dr["Apellido_emp"].ToString();
                empleado.Telefono = dr["Telefono_emp"].ToString();
                empleado.Direccion = dr["Direccion_emp"].ToString();
                empleado.Rol = dr["Rol"].ToString();
                empleado.DNI = dr["Dni"].ToString();
                lista.Add(empleado);
            }
            return lista;
        }

        public string ObtenerMail(CLSEmpleado empleado)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Id_emp", empleado.ID_emp);
            DataTable tabla = DAL.Acceso.Instancia.leer("sp_ObtenerMail", parametros);

            string email = string.Empty;
            foreach (DataRow dr in tabla.Rows)
            {
                email = dr["Email"].ToString();
            }
            return email;
        }

        public int CambiarContrasenia(int idEmp, string nuevaContra)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@ID_emp", idEmp);
                parametros[1] = new SqlParameter("@NuevaContrasenia", Encriptación.Instancia.Encriptar(nuevaContra));
                int fa = DAL.Acceso.Instancia.escribir("sp_CambiarContraseniaEmpleado", parametros);
                return fa;
            }
            catch
            {
                return 0;
            }
            
        }

        public int CambiarCorreo(int idEmp, string nuevoCorreo)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@ID_emp", idEmp);
                parametros[1] = new SqlParameter("@NuevoCorreo", nuevoCorreo);
                int fa = DAL.Acceso.Instancia.escribir("sp_CambiarCorreoEmpleado", parametros);
                return fa;
            }
            catch
            {
                return 0;
            }

        }

        public void GenerarXML(string rutaSegura)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BE.CLSEmpleado>));

            using (FileStream fs = new FileStream(rutaSegura, FileMode.Create))
            {
                serializer.Serialize(fs, Listar());
            }
        }

        public int AutoAgregar(CLSEmpleado empleado, string email, string contra)
        {
            int fa = 0;

            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = new SqlParameter("@Nombre_emp", empleado.Nombre);
            parametros[1] = new SqlParameter("@Apellido_emp", empleado.Apellido);
            parametros[2] = new SqlParameter("@Telefono_emp", empleado.Telefono);
            parametros[3] = new SqlParameter("@Direccion_emp", empleado.Direccion);
            parametros[4] = new SqlParameter("@ID_rol", int.Parse(empleado.Rol));
            parametros[5] = new SqlParameter("@Dni", empleado.DNI);
            parametros[6] = new SqlParameter("@Email", email);
            parametros[7] = new SqlParameter("@Contraseña", Encriptación.Instancia.Encriptar(contra));
            fa = DAL.Acceso.Instancia.escribir("sp_InsertarEmpleado", parametros);
            return fa;
        }
    }
}
