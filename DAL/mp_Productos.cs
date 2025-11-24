using BE;
using System;
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
    public class mp_Productos
    {
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

                fa = DAL.Acceso.Instancia.escribir("sp_InsertarProducto", parametros);

                foreach (var componente in producto.Componentes)
                {
                    
                    if (componente is BE.ClsInsumo det)
                    {
                       
                        SqlParameter[] parametros2 = new SqlParameter[3];
                        parametros2[0] = new SqlParameter("@ID_Insumo", det.Id); 
                        parametros2[1] = new SqlParameter("@Cantidad", det.Cantidad);
                        parametros2[2] = new SqlParameter("@Unidad", det.Unidad);
                        fa += DAL.Acceso.Instancia.escribir("sp_InsertarDetalleProducto", parametros2);
                    }
                   
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
                parametros[0] = new SqlParameter("@ID_Prod", producto.Id);
                parametros[1] = new SqlParameter("@Nombre_Produc", producto.Nombre);
                parametros[2] = new SqlParameter("@Precio_Prod", producto.Precio);

                fa = DAL.Acceso.Instancia.escribir("sp_EditarProducto", parametros);
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
                parametros[0] = new SqlParameter("@ID_Prod", producto.Id);

                fa = DAL.Acceso.Instancia.escribir("sp_EliminarProducto", parametros);
                return fa;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public void GenerarXML(string rutaSegura)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BE.ClsProductos>));

            using (FileStream fs = new FileStream(rutaSegura, FileMode.Create))
            {
                serializer.Serialize(fs, Listar());
            }
        }

        public List<BE.ClsProductos> Listar()
        {
            try
            {
                List<BE.ClsProductos> listaProductos = new List<BE.ClsProductos>();


                DataTable tabla = DAL.Acceso.Instancia.leer("sp_ListarProductos", null);

                foreach (DataRow dr in tabla.Rows)
                {
                    BE.ClsProductos producto = new BE.ClsProductos();
                    producto.Id = int.Parse(dr["ID_Prod"].ToString());
                    producto.Nombre = dr["Nombre_Produc"].ToString();
                    producto.Precio = decimal.Parse(dr["Precio_Produc"].ToString());
                    producto.Rubro = dr["Rubro"].ToString();
                    producto.Existencias = int.Parse(dr["Existencias"].ToString());


                    List<BE.ClsInsumo> listaDetalles = new List<BE.ClsInsumo>();
                    SqlParameter[] parametros = new SqlParameter[1];
                    parametros[0] = new SqlParameter("@ID_Prod", producto.Id);

                    DataTable tabla2 = DAL.Acceso.Instancia.leer("sp_DetallarProductos", parametros);
                    foreach (DataRow dr2 in tabla2.Rows)
                    {
                        BE.ClsInsumo detalle = new ClsInsumo();
                        detalle.Nombre = dr2["Insumo"].ToString();
                        detalle.Cantidad = decimal.Parse(dr2["Cantidad"].ToString());
                        detalle.Unidad = dr2["Unidad"].ToString();
                        listaDetalles.Add(detalle);
                    }

                    producto.Componentes = listaDetalles.Cast<IComponenteInventario>().ToList();
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
