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
          
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@Nombre_insumo", insumo.Nombre);
            parametros[1] = new SqlParameter("@Unidad", insumo.Unidad);
            parametros[2] = new SqlParameter("@Cantidad", insumo.Cantidad);
            parametros[3] = new SqlParameter("@Calidad", insumo.Calidad);

          
            fa = acceso.escribir("sp_InsertarInsumo", parametros);
            return fa;
        }

        public int Eliminar(BE.ClsInsumo insumo)
        {
            int fa = 0;
           
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID_Insumo", insumo.ID);

           
            fa = acceso.escribir("sp_EliminarInsumo", parametros);
            return fa;
        }

        /*public int Editar(BE.ClsInsumo insumo)
        {
            int fa = 0;
         
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@ID_Insumo", insumo.ID);
            parametros[1] = new SqlParameter("@Nombre_insumo", insumo.Nombre);
            parametros[2] = new SqlParameter("@Unidad", insumo.Unidad);
            parametros[3] = new SqlParameter("@Cantidad", insumo.Cantidad);
            parametros[4] = new SqlParameter("@Calidad", insumo.Calidad);

           
            fa = acceso.escribir("sp_EditarInsumo", parametros);
            return fa;
        }
        DECDIMOS QUE NO SE PUEDAN MODIFICAR INSUMOS, LO DEJAMOS POR SI LAS DUDAS
        */

        public List<BE.ClsInsumo> Listar()
        {
            List<BE.ClsInsumo> lista = new List<BE.ClsInsumo>();

           
            DataTable tabla = acceso.leer("sp_ListarInsumos", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.ClsInsumo insumo = new BE.ClsInsumo();
                insumo.ID = int.Parse(dr["ID_Insumo"].ToString());
                insumo.Nombre = dr["Nombre_insumo"].ToString();
                insumo.Unidad = dr["Unidad"].ToString();
                insumo.Cantidad = decimal.Parse(dr["Cantidad"].ToString());
                insumo.Calidad = dr["Calidad"].ToString();
                lista.Add(insumo);
            }
            return lista;
        }
    }
}
