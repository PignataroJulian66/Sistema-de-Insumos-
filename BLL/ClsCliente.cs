using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mensajes1;

namespace BLL
{
    public class ClsCliente
    {
        private mp_Cliente mapper = new mp_Cliente();

        public int Agregar(BE.ClsCliente cliente)
        {
            try
            {
                int filasAfectadas = mapper.Agregar(cliente);

                if (filasAfectadas > 0)
                GestorMensajes.Exito("Cliente agregado correctamente.");
                else
                GestorMensajes.Advertencia("No se pudo agregar el cliente.");
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
                GestorMensajes.Exito("Cliente eliminado correctamente.");
                else
                GestorMensajes.Advertencia("No se encontró el cliente a eliminar.");
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
    }
}

