using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mp_Cliente
    {
        public int Agregar(BE.ClsCliente cliente)
        {
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@Nombre_Cliente", cliente.Nombre);
            parametros[1] = new SqlParameter("@Apellido_Cliente", cliente.Apellido);
            parametros[2] = new SqlParameter("@Telefono_Cliente", cliente.Telefono);
            parametros[3] = new SqlParameter("@DNI_Cliente", cliente.DNI);

            
            fa = DAL.Acceso.Instancia.escribir("sp_InsertarCliente", parametros);
            return fa;
        }

        public int Eliminar(BE.ClsCliente cliente)
        {
            int fa = 0;
            
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID_Cliente", cliente.ID);

            fa = DAL.Acceso.Instancia.escribir("sp_EliminarCliente", parametros);
            return fa;
        }

        public int Editar(BE.ClsCliente cliente)
        {
            int fa = 0;
            
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@ID_Cliente", cliente.ID);
            parametros[1] = new SqlParameter("@Nombre_Cliente", cliente.Nombre);
            parametros[2] = new SqlParameter("@Apellido_Cliente", cliente.Apellido);
            parametros[3] = new SqlParameter("@Telefono_Cliente", cliente.Telefono);
            parametros[4] = new SqlParameter("@DNI_Cliente", cliente.DNI);

            
            fa = DAL.Acceso.Instancia.escribir("sp_EditarCliente", parametros);
            return fa;
        }

        public List<BE.ClsCliente> Listar()
        {
            List<BE.ClsCliente> lista = new List<BE.ClsCliente>();


            DataTable tabla = DAL.Acceso.Instancia.leer("sp_ListarClientes", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.ClsCliente cliente = new BE.ClsCliente();
                cliente.ID = int.Parse(dr["ID_Cliente"].ToString());
                cliente.Nombre = dr["Nombre_Cliente"].ToString();
                cliente.Apellido = dr["Apellido_Cliente"].ToString();
                cliente.Telefono = dr["Telefono_Cliente"].ToString();
                cliente.DNI = dr["DNI_Cliente"].ToString();
                lista.Add(cliente);
            }
            return lista;
        }

        public void GenerarXML(string rutaSegura)
        {
            DataTable DT = DAL.Acceso.Instancia.leer("SP_ListarClientes", null);
            DataSet ds = new DataSet("Clientes");
            ds.Tables.Add(DT);
            ds.WriteXml(rutaSegura);
        }
    }
}

