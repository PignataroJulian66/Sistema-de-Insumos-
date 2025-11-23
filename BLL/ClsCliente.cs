using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mensajes1;
using BE;

namespace BLL
{
    public class ClsCliente : IABM<BE.ClsCliente>
    {
        private mp_Cliente mapper = new mp_Cliente();
        string usuarioActual = "Sistema";
        public int Agregar(BE.ClsCliente cliente)
        {
            try
            {
                int filasAfectadas = mapper.Agregar(cliente);

                if (filasAfectadas > 0)
                {
                    GestorBitacora.Instancia.RegistrarEvento(usuarioActual, "INFO", $"Cliente agregado: {cliente.Nombre}", "ALTA_CLIENTE");
                    GestorMensajes.Exito("Cliente agregado correctamente.");
                }
                else 
                {
                    GestorBitacora.Instancia.RegistrarEvento(usuarioActual, "ADVERTENCIA", $"Intento fallido de agregar cliente: {cliente.Nombre}", "ALTA_CLIENTE");
                    GestorMensajes.Advertencia("No se pudo agregar el cliente.");
                }
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar cliente: " + ex.Message);
                return 0;
            }
        }

        public int Eliminar(BE.ClsCliente cliente)
        {
            try
            {
                int filasAfectadas = mapper.Eliminar(cliente);

                if (filasAfectadas > 0)
                {
                    GestorBitacora.Instancia.RegistrarEvento(usuarioActual, "INFO", $"Cliente Eliminado: {cliente.Nombre}", "BAJA_CLIENTE");
                    GestorMensajes.Exito("Cliente eliminado correctamente.");
                }
                else
                {
                    GestorBitacora.Instancia.RegistrarEvento(usuarioActual, "ADVERTENCIA", $"Intento fallido de eliminar cliente: {cliente.Nombre}", "BAJA_CLIENTE");
                    GestorMensajes.Advertencia("No se encontró el cliente a eliminar.");
                }
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al eliminar cliente: " + ex.Message);
                return 0;
            }
        }

        public int Editar(BE.ClsCliente cliente)
        {
            try
            {
                int filasAfectadas = mapper.Editar(cliente);

                if (filasAfectadas > 0)
                GestorMensajes.Exito("Cliente editado correctamente.");
                else
                GestorMensajes.Advertencia("No se pudo editar el cliente.");
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al editar cliente: " + ex.Message);
                return 0;
            }
        }

        public List<BE.ClsCliente> Listar()
        {
            try
            {
                var lista = mapper.Listar();

                if (lista == null || lista.Count == 0)
                GestorMensajes.Advertencia("No se encontraron clientes registrados.");
                return lista;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al listar clientes: " + ex.Message);
                return new List<BE.ClsCliente>();
            }
        }

        public void GenerarXML(string rutaSegura)
        {
            mapper.GenerarXML(rutaSegura);
        }
    }
}

