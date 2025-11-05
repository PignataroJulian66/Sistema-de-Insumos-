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
                parametros[1] = new SqlParameter("@ID_Insumo", OC.NInsumo);
                parametros[2] = new SqlParameter("@Cantidad", OC.Cantidad);
                parametros[3] = new SqlParameter("@Unidad", OC.Unidad);
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

        public int Editar(ClsOrdenCompra OC)
        {
            try
            {
                int fa = 0;

                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@ID_OC", OC.ID);
                parametros[1] = new SqlParameter("@Cotizacion", OC.Cotizacion);

                fa = acceso.escribir("sp_EditarOrdenCompra", parametros);

                return fa;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public int Editar2(ClsOrdenCompra OC)
        {
            try
            {
                int fa = 0;

                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@ID_OC", OC.ID);
                parametros[1] = new SqlParameter("@Cantidad", OC.Cantidad);

                fa = acceso.escribir("sp_EditarOrdenCompra2", parametros);

                return fa;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public List<ClsOrdenCompra> Listar(CLSProveedor prov)
        {
            try
            {
                List<BE.ClsOrdenCompra> listaOrden = new List<BE.ClsOrdenCompra>();

                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Id_prov", prov.ID_prov);

                DataTable tabla = acceso.leer("sp_ListarOrdenCompra", parametros);

                foreach (DataRow dr in tabla.Rows)
                {
                    BE.ClsOrdenCompra OC = new BE.ClsOrdenCompra();
                    OC.ID = int.Parse(dr["ID_OC"].ToString());
                    OC.ID_Emp = dr["Id_emp"].ToString();
                    OC.NInsumo =dr["Insumo"].ToString();
                    OC.Cantidad = decimal.Parse(dr["Cantidad"].ToString());
                    OC.Unidad = dr["Unidad"].ToString();
                    OC.FechaEntrega = DateTime.Parse(dr["Fecha_Entrega"].ToString());
                    OC.Finalizado = bool.Parse(dr["Finalizada"].ToString());
                    OC.ID_prov = dr["ID_prov"].ToString();
                    if (decimal.TryParse(dr["Cotizacion"].ToString(), out decimal result))
                    {
                        OC.Cotizacion = result;
                    }
                    else
                    {
                        OC.Cotizacion = 0;
                    }


                        listaOrden.Add(OC);
                }
                return listaOrden;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ClsOrdenCompra> Listar2(CLSEmpleado emp)
        {
            try
            {
                List<BE.ClsOrdenCompra> listaOrden = new List<BE.ClsOrdenCompra>();

                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@Id_emp", emp.ID_emp);

                DataTable tabla = acceso.leer("sp_ListarOrdenCompra2", parametros);

                foreach (DataRow dr in tabla.Rows)
                {
                    BE.ClsOrdenCompra OC = new BE.ClsOrdenCompra();
                    OC.ID = int.Parse(dr["ID_OC"].ToString());
                    OC.ID_Emp = dr["Id_emp"].ToString();
                    OC.NInsumo = dr["Insumo"].ToString();
                    OC.Cantidad = decimal.Parse(dr["Cantidad"].ToString());
                    OC.Unidad = dr["Unidad"].ToString();
                    OC.FechaEntrega = DateTime.Parse(dr["Fecha_Entrega"].ToString());
                    OC.Finalizado = bool.Parse(dr["Finalizada"].ToString());
                    OC.ID_prov = dr["ID_prov"].ToString();
                    if (decimal.TryParse(dr["Cotizacion"].ToString(), out decimal result))
                    {
                        OC.Cotizacion = result;
                    }
                    else
                    {
                        OC.Cotizacion = 0;
                    }


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
