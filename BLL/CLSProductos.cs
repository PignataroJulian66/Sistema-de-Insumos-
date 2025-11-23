using BE;
using DAL;
using Mensajes1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CLSProductos : IABM<BE.ClsProductos>
    {
        private mp_Productos mapper = new mp_Productos();
        private BLL.ClsInsumo gestorInsumos = new BLL.ClsInsumo();
        string usuarioActual = "Sistema";
        public int Agregar(BE.ClsProductos producto)
        {
            try
            {

                if (producto.Componentes == null || producto.Componentes.Count == 0)
                {
                   
                    GestorMensajes.Advertencia("No se puede agregar un producto sin componentes registrados.");
                    return 0;
                }

                int filasAfectadas = mapper.Agregar(producto);
                if (filasAfectadas > 0)
                {
                    GestorBitacora.Instancia.RegistrarEvento(usuarioActual, "INFO", $"Producto agregado: {producto.Nombre}", "ALTA_PRODUCTO");
                    GestorMensajes.Exito("Producto agregado correctamente.");
                }

                else
                {
                GestorBitacora.Instancia.RegistrarEvento(usuarioActual,"ADVERTENCIA",$"Intento fallido de agregar producto: {producto.Nombre}","ALTA_PRODUCTO");
                GestorMensajes.Advertencia("No se pudo agregar el producto.");
                }

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar producto: " + ex.Message);
                return 0;
            }
        }

        public int Eliminar(BE.ClsProductos producto)
        {
            try
            {              
                int filasAfectadas = mapper.Eliminar(producto);

                if (filasAfectadas > 0)
                {
                    GestorBitacora.Instancia.RegistrarEvento(usuarioActual, "INFO", $"Producto Eliminado: {producto.Nombre}", "BAJA_PRODUCTO");
                    GestorMensajes.Exito("Producto eliminado correctamente.");
                }
                else
                {
                    GestorBitacora.Instancia.RegistrarEvento(usuarioActual, "ADVERTENCIA", $"Intento fallido de eliminar producto: {producto.Nombre}", "BAJA_PRODUCTO");
                    GestorMensajes.Advertencia("No se encontró el producto a eliminar.");
                }
                    

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al eliminar producto: " + ex.Message);
                return 0;
            }
        }

        public int Editar(BE.ClsProductos producto)
        {
            try
            {
                int filasAfectadas = mapper.Editar(producto);

                if (filasAfectadas > 0)
                    GestorMensajes.Exito("Producto editado correctamente.");
                else
                    GestorMensajes.Advertencia("No se pudo editar el producto.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al editar producto: " + ex.Message);
                return 0;
            }
        }

        public List<BE.ClsProductos> Listar()
        {
            try
            {
                var lista = mapper.Listar();
                if (lista == null || lista.Count == 0)
                    GestorMensajes.Advertencia("No se encontraron productos registrados.");
                return lista;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al listar productos: " + ex.Message);
                return new List<BE.ClsProductos>();
            }
        }

        public void GenerarXML(string rutaSegura)
        {
            mapper.GenerarXML(rutaSegura);
        }
    }
}
