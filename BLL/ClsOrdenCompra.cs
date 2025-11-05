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
    public class ClsOrdenCompra
    {
        mp_OrdenCompra mapper = new mp_OrdenCompra();
        public int Agregar(BE.ClsOrdenCompra OC)
        {
            try
            {
                int filasAfectadas = mapper.Agregar(OC);

                if (filasAfectadas > 0)
                    GestorMensajes.Exito("orden de compra agregada correctamente.");
                else
                    GestorMensajes.Advertencia("No se pudo agregar la orden de compra.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar orden de compra: " + ex.Message);
                return 0;
            }
        }

        public int Editar(BE.ClsOrdenCompra OC)
        {
            try
            {
                int filasafectadas = mapper.Editar(OC);

                if (filasafectadas > 0)
                    GestorMensajes.Exito("orden de compra agregada correctamente.");
                else
                    GestorMensajes.Advertencia("No se pudo agregar la orden de compra.");

                return filasafectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar orden de compra: " + ex.Message);
                return 0;
            }
        }

        public int Editar2(BE.ClsOrdenCompra OC)
        {
            try
            {
                int filasafectadas = mapper.Editar2(OC);

                if (filasafectadas > 0)
                    GestorMensajes.Exito("orden de compra agregada correctamente.");
                else
                    GestorMensajes.Advertencia("No se pudo agregar la orden de compra.");

                return filasafectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar orden de compra: " + ex.Message);
                return 0;
            }
        }

        public List<BE.ClsOrdenCompra> Listar(CLSProveedor prov)
        {
            try
            {
                List<BE.ClsOrdenCompra> lista = mapper.Listar(prov);

                if (lista == null || lista.Count == 0)
                    GestorMensajes.Advertencia("No se encontraron ordenes de compra registradas.");
                return lista;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al listar ORDENES DE COMPRA: " + ex.Message);
                return new List<BE.ClsOrdenCompra>();
            }
        }

        public List<BE.ClsOrdenCompra> Listar2(CLSEmpleado emp)
        {
            try
            {
                List<BE.ClsOrdenCompra> lista = mapper.Listar2(emp);

                if (lista == null || lista.Count == 0)
                    GestorMensajes.Advertencia("No se encontraron ordenes de compra registradas.");
                return lista;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al listar ORDENES DE COMPRA: " + ex.Message);
                return new List<BE.ClsOrdenCompra>();
            }
        }
    }
}
