using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mensajes1;

namespace BLL
{
    public class ClsProveedor
    {
        private mp_Proveedor mapper = new mp_Proveedor();

        public int Agregar(CLSProveedor proveedor, string email)
        {
            try
            {
                int filasAfectadas = mapper.Agregar(proveedor, email);

                if (filasAfectadas > 0)
                GestorMensajes.Exito("Proveedor agregado correctamente.");
                else
                GestorMensajes.Advertencia("No se pudo agregar el proveedor.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar proveedor: " + ex.Message);
                return 0;
            }
        }

        public int Eliminar(CLSProveedor proveedor)
        {
            try
            {
                int filasAfectadas = mapper.Eliminar(proveedor);

                if (filasAfectadas > 0)
                GestorMensajes.Exito("Proveedor eliminado correctamente.");
                else
                GestorMensajes.Advertencia("No se encontró el proveedor a eliminar.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al eliminar proveedor: " + ex.Message);
                return 0;
            }
        }

        public int Editar(CLSProveedor proveedor, string email)
        {
            try
            {
                int filasAfectadas = mapper.Editar(proveedor, email);

                if (filasAfectadas > 0)
                GestorMensajes.Exito("Proveedor editado correctamente.");
                else
                GestorMensajes.Advertencia("No se pudo editar el proveedor.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al editar proveedor: " + ex.Message);
                return 0;
            }
        }

        public List<CLSProveedor> Listar()
        {
            try
            {
                List<CLSProveedor> lista = mapper.Listar();

                if (lista == null || lista.Count == 0)
                GestorMensajes.Advertencia("No se encontraron proveedores registrados.");
                return lista;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al listar proveedores: " + ex.Message);
                return new List<CLSProveedor>();
            }
        }

        public string ObtenerMailProveedor(CLSProveedor prov)
        {
            try
            {
                string mail = mapper.ObtenerMailProveedor(prov);

                if (string.IsNullOrEmpty(mail))
                GestorMensajes.Advertencia("No se encontró el email del proveedor.");

                return mail;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al obtener email del proveedor: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
