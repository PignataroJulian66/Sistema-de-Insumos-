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
        public DataTable Listar()
        {
            return DAL.Acceso.Instancia.ObtenerClientes();
        }

        public void GenerarXML(string rutaSegura)
        {
            DataTable DT = DAL.Acceso.Instancia.leer("SP_ListarClientes", null);
            DataSet ds = new DataSet("Clientes");
            ds.Tables.Add(DT);
            ds.WriteXml(rutaSegura);
        }

        public int GuardarCambios()
        {
            return DAL.Acceso.Instancia.GuardarCambios();
        }
    }
}

