using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mp_Insumo
    {
        Acceso acceso = new Acceso();

        public int Agregar(BE.ClsInsumo insumo)
        {
            int fa = 0;
          
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("@ID", insumo.ID);
            parametros[1] = new SqlParameter("@Nombre", insumo.Nombre);
            parametros[2] = new SqlParameter("@Unidad", insumo.Unidad);
            parametros[3] = new SqlParameter("@Cantidad", insumo.Cantidad);
            parametros[4] = new SqlParameter("@Calidad", insumo.Calidad);
            parametros[5] = new SqlParameter("@Proporcion", insumo.Proporcion);
            parametros[6] = new SqlParameter("@PrecioActual", insumo.PrecioActual);

          
            fa = acceso.escribir("sp_InsertarInsumo", parametros);
            return fa;
        }

        public int Eliminar(BE.ClsInsumo insumo)
        {
            int fa = 0;
           
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID", insumo.ID);

           
            fa = acceso.escribir("sp_EliminarInsumo", parametros);
            return fa;
        }

        public int Editar(BE.ClsInsumo insumo)
        {
            int fa = 0;
         
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("@ID", insumo.ID);
            parametros[1] = new SqlParameter("@Nombre", insumo.Nombre);
            parametros[2] = new SqlParameter("@Unidad", insumo.Unidad);
            parametros[3] = new SqlParameter("@Cantidad", insumo.Cantidad);
            parametros[4] = new SqlParameter("@Calidad", insumo.Calidad);
            parametros[5] = new SqlParameter("@Proporcion", insumo.Proporcion);
            parametros[6] = new SqlParameter("@PrecioActual", insumo.PrecioActual);

           
            fa = acceso.escribir("sp_EditarInsumo", parametros);
            return fa;
        }

        public List<BE.ClsInsumo> Listar()
        {
            List<BE.ClsInsumo> lista = new List<BE.ClsInsumo>();

           
            DataTable tabla = acceso.leer("sp_ListarInsumos", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.ClsInsumo insumo = new BE.ClsInsumo();
                insumo.ID = int.Parse(dr["ID"].ToString());
                insumo.Nombre = dr["Nombre"].ToString();
                insumo.Unidad = dr["Unidad"].ToString();
                insumo.Cantidad = int.Parse(dr["Cantidad"].ToString());
                insumo.Calidad = dr["Calidad"].ToString();
                insumo.Proporcion = dr["Proporcion"].ToString();
                insumo.PrecioActual = decimal.Parse(dr["PrecioActual"].ToString());
                lista.Add(insumo);
            }
            return lista;
        }
    }
}
