using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mensajes1;
using BE;
using System.Data;

namespace BLL
{
    public class ClsCliente
    {
        private mp_Cliente mapper = new mp_Cliente();
        public DataTable Listar()
        {
            try
            {
                var dt = mapper.Listar();

                if (dt == null)
                GestorMensajes.Advertencia("No se encontraron clientes registrados.");
                return dt;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al listar clientes: " + ex.Message);
                return new DataTable();
            }
        }

        public void GenerarXML(string rutaSegura)
        {
            mapper.GenerarXML(rutaSegura);
        }

        public int GuardarDatosClientes()
        {
            return mapper.GuardarCambios();
        }
    }
}

