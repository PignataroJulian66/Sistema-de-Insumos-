using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mensajes1;

namespace BLL
{
    public class ClsInsumo
    {
        private mp_Insumo mapper = new mp_Insumo();

        public int Agregar(BE.ClsInsumo insumo)
        {
            try
            {
                int filasAfectadas = mapper.Agregar(insumo);

                if (filasAfectadas > 0)
                    GestorMensajes.Exito("Insumo agregado correctamente.");
                else
                    GestorMensajes.Advertencia("No se pudo agregar el insumo.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar insumo: " + ex.Message);
                return 0;
            }
        }
        
        public int Eliminar(BE.ClsInsumo insumo)
        {
            try
            {
                int filasAfectadas = mapper.Eliminar(insumo);

                if (filasAfectadas > 0)
                    GestorMensajes.Exito("Insumo eliminado correctamente.");
                else
                    GestorMensajes.Advertencia("No se encontró el insumo a eliminar.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al eliminar insumo: " + ex.Message);
                return 0;
            }
        }

        public List<BE.ClsInsumo> Listar()
        {
            try
            {
                List<BE.ClsInsumo> lista = mapper.Listar();

                if (lista == null || lista.Count == 0)
                    GestorMensajes.Advertencia("No se encontraron insumos registrados.");

                return lista;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al listar insumos: " + ex.Message);
                return new List<BE.ClsInsumo>();
            }
        }
    }
}
