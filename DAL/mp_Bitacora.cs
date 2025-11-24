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
    public class mp_Bitacora
    {
        public void Guardar(ClsRegistroBitacora registro)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[4];
                parametros[0] = new SqlParameter("@Usuario", registro.Usuario ?? (object)DBNull.Value);
                parametros[1] = new SqlParameter("@TipoEvento", registro.TipoEvento);
                parametros[2] = new SqlParameter("@Criticidad", registro.Criticidad);
                parametros[3] = new SqlParameter("@Mensaje", registro.Mensaje);
                Acceso.Instancia.escribir("sp_InsertarRegistroBitacora", parametros);
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error al guardar en bitácora: " + ex.Message);
            }
        }

        public List<ClsRegistroBitacora> Listar()
        {
            DataTable tabla = Acceso.Instancia.leer("sp_ListarBitacora", null);
            List<ClsRegistroBitacora> lista = new List<ClsRegistroBitacora>();
            foreach(DataRow dr in tabla.Rows)
            {
                BE.ClsRegistroBitacora bitacora = new BE.ClsRegistroBitacora();
                bitacora.Id = Convert.ToInt32(dr["Id_Registro"]);
                bitacora.Fecha = Convert.ToDateTime(dr["FechaHora"]);
                bitacora.Usuario = dr["Usuario"].ToString();
                bitacora.TipoEvento = dr["TipoEvento"].ToString();
                bitacora.Criticidad = dr["Criticidad"].ToString();
                bitacora.Mensaje = dr["Mensaje"].ToString();
                lista.Add(bitacora);
            }
            return lista;
        }
    }
}
