using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso : IDisposable
    {
        private static Acceso _instancia;
        protected SqlConnection conexion = null;
        SqlCommand comando = new SqlCommand();
        private bool disposed = false;

        private Acceso()
        {
            conexion = new SqlConnection();
            
        }

        public static Acceso Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Acceso();
                }
                return _instancia;
            }
        }

        public void conectar()
        {
            //DESKTOP-1R961GN
            //JULIÁN
            try
            {
                conexion.ConnectionString = @"Data Source=.;Initial Catalog=BaseCompleta;Integrated Security=True;TrustServerCertificate=True";
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
                //desconectar();
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
                return 1;
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

        public List<BE.ClsRegistroBitacora> LeerQuery(string query)
        {
            List < BE.ClsRegistroBitacora> lst = new List<BE.ClsRegistroBitacora> ();
            conectar();
            using (SqlCommand comando = new SqlCommand(query, conexion))
            using (SqlDataReader dr = comando.ExecuteReader())
            {
                comando.CommandType = System.Data.CommandType.Text;
                try
                {
                    while (dr.Read())  //mientras haya registros me crea una persona y le agrega los valores del reaedr a los atributos. La agrega a la lista
                    {
                        BE.ClsRegistroBitacora bitacora = new BE.ClsRegistroBitacora();
                        {
                            bitacora.Id = Convert.ToInt32(dr["Id_Registro"]);
                            bitacora.Fecha = Convert.ToDateTime(dr["FechaHora"]);
                            bitacora.Usuario = dr["Usuario"].ToString();
                            bitacora.TipoEvento = dr["TipoEvento"].ToString();
                            bitacora.Criticidad = dr["Criticidad"].ToString();
                            bitacora.Mensaje = dr["Mensaje"].ToString();
                        };
                        lst.Add(bitacora);
                    }

                    return lst;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar de la base de datos", ex);
                }
                finally
                {
                    desconectar();
                }
            }
        }

        DataTable dataTable;
        SqlDataAdapter dataAdapter;
        public DataTable ObtenerClientes()
        {
            conectar();
            try
            {
                // 1. Inicializa el dataAdapter con el comando SELECT
                string selectQuery = "SELECT * FROM Cliente";
                dataAdapter = new SqlDataAdapter(selectQuery, conexion);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataColumn idColumn = dataTable.Columns["ID_Cliente"];

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = idColumn;
                dataTable.PrimaryKey = keyColumns;

                idColumn.AutoIncrement = true; 
                idColumn.AutoIncrementSeed = -1; 
                idColumn.AutoIncrementStep = -1;

                return dataTable;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                desconectar() ;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!disposed) 
            {
             if (disposing)
                {
                    // Liberar recursos administrados (SqlConnection y SqlCommand)
                    if (conexion != null)
                    {
                        // Asegurarse de que la conexión esté cerrada
                        if (conexion.State != ConnectionState.Closed)
                        {
                            conexion.Close();
                        }
                        conexion.Dispose();
                        conexion = null;
                    }
                    if (comando != null)
                    {
                        comando.Dispose();
                        comando = null;
                    }
                }
            }

        }

        internal int GuardarCambios()
        {
            if (dataAdapter != null && dataTable != null)
            {
                // Retorna el número de filas afectadas en la base de datos.
                return dataAdapter.Update(dataTable);
            }
            return 0;
        }

        public void Backup(string v)
        {
            try
            {
                comando.Connection = conexion;
                conectar();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex.Message);
            }
        }
    }
}


    

