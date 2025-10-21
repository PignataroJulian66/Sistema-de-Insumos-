using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorUsuarios
    {
        Acceso acceso = new Acceso();

        public bool EsEmpleado(int usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];          
            parametros[0] = new SqlParameter("@ID_Usuario", usuario);
            bool Esempleado = bool.Parse(acceso.leerEscalar("sp_EsEmpleado", parametros).ToString());
            return Esempleado;
        }

        public bool EsProveedor(int usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID_Usuario", usuario);
            bool esproveedor = bool.Parse(acceso.leerEscalar("sp_EsProveedor", parametros).ToString());
            return esproveedor;
        }

        public int InicioSesion(string email, string contraseña)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[2];
                int Id_usuario = -1;
                parametros[0] = new SqlParameter("@Email", email);
                parametros[1] = new SqlParameter("@Contraseña", contraseña);
                if(acceso.leerEscalar("sp_InicioSesion", parametros) != null)
                {
                    Id_usuario = int.Parse(acceso.leerEscalar("sp_InicioSesion", parametros).ToString());          
                }
                return Id_usuario;
            }
            catch(Exception ex)
            {
                Console.WriteLine("error al iniciar sesion" + ex.Message);
                return -1;
            }
           
        }
    }
}
