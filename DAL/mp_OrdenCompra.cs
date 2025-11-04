using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mp_OrdenCompra
    {
        Acceso acceso = new Acceso();
        public int Agregar(BE.ClsOrdenCompra OC)
        {
            try
            {
                int fa = 0;

                SqlParameter[] parametros = new SqlParameter[7];
                parametros[0] = new SqlParameter("@ID_Emp", OC.ID_Emp);
                parametros[1] = new SqlParameter("@ID_Insumo", OC.Insumo.ID);
                parametros[2] = new SqlParameter("@Cantidad", OC.Insumo.Cantidad);
                parametros[3] = new SqlParameter("@Unidad", OC.Insumo.Unidad);
                parametros[4] = new SqlParameter("@Fecha", OC.FechaEntrega.ToString());
                parametros[5] = new SqlParameter("@Finalizado", OC.Finalizado.ToString());
                parametros[6] = new SqlParameter("@ID_prov", OC.ID_prov);

                fa = acceso.escribir("sp_AgregarOrdenCompra", parametros);

                return fa;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }   

        public List<ClsOrdenCompra> Listar()
        {
            try
            {
                List<BE.ClsOrdenCompra> listaOrden = new List<BE.ClsOrdenCompra>();


                DataTable tabla = acceso.leer("sp_ListarOrdenCompra", null);

                foreach (DataRow dr in tabla.Rows)
                {
                    BE.ClsOrdenCompra OC = new BE.ClsOrdenCompra();
                    OC.ID_Emp = dr["ID_Emp"].ToString();
                    OC.Insumo.ID =int.Parse(dr["ID_Inusmo"].ToString());
                    OC.Insumo.Cantidad = decimal.Parse(dr["Cantidad"].ToString());
                    OC.Insumo.Unidad = dr["Unidad"].ToString();
                    OC.FechaEntrega = DateTime.Parse(dr["Fecha"].ToString());
                    OC.Finalizado = bool.Parse(dr["Finalizado"].ToString());
                    OC.ID_prov = dr["ID_prov"].ToString();

                    listaOrden.Add(OC);
                }
                return listaOrden;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
