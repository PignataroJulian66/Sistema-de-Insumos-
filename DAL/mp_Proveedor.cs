using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class mp_Proveedor
    {
        Acceso acceso = new Acceso();

        public int Agregar(BE.CLSProveedor proveedor, string email)
        {
            int fa = 0;
           
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@Nombre", proveedor.Nombre);
            parametros[1] = new SqlParameter("@Cuit", proveedor.Cuit);
            parametros[2] = new SqlParameter("@Telefono", proveedor.Telefono);
            parametros[3] = new SqlParameter("@Direccion", proveedor.Direccion);
            parametros[4] = new SqlParameter("@Email", email);


            fa = acceso.escribir("sp_InsertarProveedor", parametros);
            return fa;
        }

        public int Eliminar(BE.CLSProveedor proveedor)
        {
            int fa = 0;
          
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID_prov", proveedor.ID_prov);

            fa = acceso.escribir("sp_EliminarProveedor", parametros);
            return fa;
        }

        public int Editar(BE.CLSProveedor proveedor, string email)
        {
            int fa = 0;
           
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@ID_prov", proveedor.ID_prov);
            parametros[1] = new SqlParameter("@Nombre", proveedor.Nombre);
            parametros[2] = new SqlParameter("@Cuit", proveedor.Cuit);
            parametros[3] = new SqlParameter("@Telefono", proveedor.Telefono);
            parametros[4] = new SqlParameter("@Direccion", proveedor.Direccion);
            parametros[5] = new SqlParameter("@Email", email);



            fa = acceso.escribir("sp_EditarProveedor", parametros);
            return fa;
        }

        public List<BE.CLSProveedor> Listar()
        {
            List<BE.CLSProveedor> lista = new List<BE.CLSProveedor>();

           
            DataTable tabla = acceso.leer("sp_ListarProveedores", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.CLSProveedor proveedor = new BE.CLSProveedor();
                proveedor.ID_prov = int.Parse(dr["ID_prov"].ToString());
                proveedor.Nombre = dr["Nombre_prov"].ToString();
                proveedor.Cuit = dr["Cuit"].ToString();
                proveedor.Telefono = dr["Telefono_prov"].ToString();
                proveedor.Direccion = dr["Direccion_prov"].ToString();
                lista.Add(proveedor);
            }
            return lista;
        }

        public string ObtenerMailProveedor(CLSProveedor prov)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Id_prov", prov.ID_prov);
            DataTable tabla = acceso.leer("sp_ObtenerMailProveedor", parametros);

            string email = string.Empty;
            foreach (DataRow dr in tabla.Rows)
            {
                email = dr["Email"].ToString();
            }
            return email;
        }
    }
}
