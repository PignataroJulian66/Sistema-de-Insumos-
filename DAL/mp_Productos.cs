using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mp_Productos
    {
        Acceso acceso = new Acceso();
        public int Agregar(ClsProductos producto)
        {
            try
            {
                int fa = 0;

                SqlParameter[] parametros = new SqlParameter[4];
                parametros[0] = new SqlParameter("@Nombre_Produc", producto.Nombre);
                parametros[1] = new SqlParameter("@Rubro", producto.Rubro);
                parametros[2] = new SqlParameter("@Precio_Produc", producto.Precio);
                parametros[3] = new SqlParameter("@Existencias", producto.Existencias);

                fa = acceso.escribir("sp_InsertarProducto", parametros);

                foreach (ClsDetalleProducto det in producto.ListaInsumos)
                {
                    SqlParameter[] parametros2 = new SqlParameter[3];
                    parametros2[0] = new SqlParameter("@ID_Insumo",det.IDinsumo);
                    parametros2[1] = new SqlParameter("@Cantidad", det.Cantidad);
                    parametros2[2] = new SqlParameter("@Unidad", det.Unidad);
                    fa += acceso.escribir("sp_InsertarDetalleProducto", parametros2);
                }
                return fa;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public int Editar(ClsProductos producto)
        {
            try
            {
                int fa = 0;

                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@ID_Prod", producto.Id_Producto);
                parametros[1] = new SqlParameter("@Nombre_Produc", producto.Nombre);
                parametros[2] = new SqlParameter("@Precio_Prod", producto.Precio);

                fa = acceso.escribir("sp_EditarProducto", parametros);
                return fa;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public int Eliminar(ClsProductos producto)
        {
            try
            {
                int fa = 0;

                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@ID_Prod", producto.Id_Producto);

                fa = acceso.escribir("sp_EliminarProducto", parametros);
                return fa;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public List<ClsProductos> Listar()
        {
            try
            {
                List<BE.ClsProductos> listaProductos = new List<BE.ClsProductos>();


                DataTable tabla = acceso.leer("sp_ListarProductos", null);

                foreach (DataRow dr in tabla.Rows)
                {
                    BE.ClsProductos producto = new BE.ClsProductos();
                    producto.Id_Producto = int.Parse(dr["ID_Prod"].ToString());
                    producto.Nombre = dr["Nombre_Produc"].ToString();
                    producto.Precio = decimal.Parse(dr["Precio_Produc"].ToString());
                    producto.Rubro = dr["Rubro"].ToString();
                    producto.Existencias = int.Parse(dr["Existencias"].ToString());


                    List<BE.ClsDetalleProducto> listaDetalles = new List<BE.ClsDetalleProducto>();
                    SqlParameter[] parametros = new SqlParameter[1];
                    parametros[0] = new SqlParameter("@ID_Prod", producto.Id_Producto);

                    DataTable tabla2 = acceso.leer("sp_DetallarProductos", parametros);
                    foreach (DataRow dr2 in tabla2.Rows)
                    {
                        BE.ClsDetalleProducto detalle = new ClsDetalleProducto();
                        detalle.Insumo = dr2["Insumo"].ToString();
                        detalle.Cantidad = decimal.Parse(dr2["Cantidad"].ToString());
                        detalle.Unidad = dr2["Unidad"].ToString();
                        listaDetalles.Add(detalle);
                    }

                    producto.ListaInsumos = listaDetalles;
                    listaProductos.Add(producto);
                }
                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
