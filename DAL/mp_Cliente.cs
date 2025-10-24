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
        Acceso acceso = new Acceso();

        public int Agregar(BE.ClsCliente cliente)
        {
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@ID", cliente.ID);
            parametros[1] = new SqlParameter("@Nombre", cliente.Nombre);
            parametros[2] = new SqlParameter("@Apellido", cliente.Apellido);
            parametros[3] = new SqlParameter("@Telefono", cliente.Telefono);
            parametros[4] = new SqlParameter("@DNI", cliente.DNI);

            
            fa = acceso.escribir("sp_InsertarCliente", parametros);
            return fa;
        }

        public int Eliminar(BE.ClsCliente cliente)
        {
            int fa = 0;
            
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID", cliente.ID);

            fa = acceso.escribir("sp_EliminarCliente", parametros);
            return fa;
        }

        public int Editar(BE.ClsCliente cliente)
        {
            int fa = 0;
            
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@ID", cliente.ID);
            parametros[1] = new SqlParameter("@Nombre", cliente.Nombre);
            parametros[2] = new SqlParameter("@Apellido", cliente.Apellido);
            parametros[3] = new SqlParameter("@Telefono", cliente.Telefono);
            parametros[4] = new SqlParameter("@DNI", cliente.DNI);

            
            fa = acceso.escribir("sp_EditarCliente", parametros);
            return fa;
        }

        public List<BE.ClsCliente> Listar()
        {
            List<BE.ClsCliente> lista = new List<BE.ClsCliente>();

           
            DataTable tabla = acceso.leer("sp_ListarClientes", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.ClsCliente cliente = new BE.ClsCliente();
                cliente.ID = int.Parse(dr["ID"].ToString());
                cliente.Nombre = dr["Nombre"].ToString();
                cliente.Apellido = dr["Apellido"].ToString();
                cliente.Telefono = dr["Telefono"].ToString();
                cliente.DNI = dr["DNI"].ToString();
                lista.Add(cliente);
            }
            return lista;
        }
    }
}

