using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mp_Proveedor
    {
        Acceso acceso = new Acceso();

        public int Agregar(BE.CLSProveedor proveedor)
        {
            int fa = 0;
           
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@ID_prov", proveedor.ID_prov);
            parametros[1] = new SqlParameter("@Nombre", proveedor.Nombre);
            parametros[2] = new SqlParameter("@Cuit", proveedor.Cuit);
            parametros[3] = new SqlParameter("@Telefono", proveedor.Telefono);
            parametros[4] = new SqlParameter("@Direccion", proveedor.Direccion);

          
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

        public int Editar(BE.CLSProveedor proveedor)
        {
            int fa = 0;
           
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@ID_prov", proveedor.ID_prov);
            parametros[1] = new SqlParameter("@Nombre", proveedor.Nombre);
            parametros[2] = new SqlParameter("@Cuit", proveedor.Cuit);
            parametros[3] = new SqlParameter("@Telefono", proveedor.Telefono);
            parametros[4] = new SqlParameter("@Direccion", proveedor.Direccion);

         
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
                proveedor.Nombre = dr["Nombre"].ToString();
                proveedor.Cuit = dr["Cuit"].ToString();
                proveedor.Telefono = dr["Telefono"].ToString();
                proveedor.Direccion = dr["Direccion"].ToString();
                lista.Add(proveedor);
            }
            return lista;
        }
    }
}
