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
            List<ClsRegistroBitacora> lista = Acceso.Instancia.LeerQuery("SELECT * FROM Bitacora");
            return lista;
        }
    }
}
