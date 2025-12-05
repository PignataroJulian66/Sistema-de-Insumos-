using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mp_Usuarios
    {
        public byte[] ObtenerHashAlmacenado(string email)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@Email", email);
            return (byte[])DAL.Acceso.Instancia.leerEscalar("ObtenerHashAlmacenado", parametros);
        }
    }
}
