using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso
    {
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public void conectar()
        {
            conexion.ConnectionString = @"Data Source=DESKTOP-1R961GN;Initial Catalog=BaseCompleta;Integrated Security=True";
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión exitosa");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de conexión" + ex.Message);
            }
        }

        public void desconectar()
        {
            try
            {
                conexion.Close();
                conexion.Dispose();
                Console.WriteLine("Desconexión exitosa.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al desconectar: " + ex.Message);
            }
        }

        public SqlTransaction IniciarTransaccion()
        {
            conectar();
            return conexion.BeginTransaction();
        }

        public void ConfirmarTransaccion(SqlTransaction tx)
        {
            try
            {
                if (tx != null)
                {
                    tx.Commit();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al confirmar la transacción: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void CancelarTransaccion(SqlTransaction tx)
        {
            try
            {
                if (tx != null)
                {
                    tx.Rollback();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al cancelar la transacción: " + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public int escribir(string sp, SqlParameter[] parametro)
        {
            SqlTransaction tx = null;
            int filasAfectadas = 0;
            try
            {
                comando.Parameters.Clear();
                tx = IniciarTransaccion();
                comando.Connection = tx.Connection; // Asignar la conexión de la transacción al comando
                comando.Transaction = tx; // Asignar la transacción al comando
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = sp;
                if (parametro != null)
                {
                    comando.Parameters.AddRange(parametro);
                }
                filasAfectadas = comando.ExecuteNonQuery();
                ConfirmarTransaccion(tx);
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                CancelarTransaccion(tx);
                Console.WriteLine("error", ex.Message);
                return 0;
            }
        }

        public DataTable leer(string sp, SqlParameter[] parametro)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            conectar();
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
            comando.Parameters.Clear();

            if (parametro != null)
            {
                comando.Parameters.AddRange(parametro);
            }
            adaptador.SelectCommand = comando;
            adaptador.Fill(dt);
            desconectar();
            return dt;
        }


        public object leerEscalar(string sp, SqlParameter[] parametro)
        {
            object resultado = null;
            try
            {
                conectar();
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = sp;

                if (parametro != null)
                {
                    comando.Parameters.Clear();
                    comando.Parameters.AddRange(parametro);
                }
                resultado = comando.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al ejecutar ExecuteScalar: " + ex.Message);
            }
            finally
            {
                comando.Parameters.Clear();
                desconectar();
            }
            return resultado;
        }
    }
}
