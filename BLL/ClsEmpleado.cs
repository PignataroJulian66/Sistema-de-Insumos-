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
    public class ClsEmpleado
    {
        private mp_Empleado mapper = new mp_Empleado();
        public event EventHandler EmpleadoChanged;
        public int Agregar(BE.CLSEmpleado empleado, string email)
        {
            try
            {
                int filasAfectadas = mapper.Agregar(empleado, email);

                if (!(filasAfectadas == 0))
                {
                 GestorMensajes.Exito("Empleado agregado correctamente.");
                    EmpleadoChanged?.Invoke(this, EventArgs.Empty);
                
                }
                   
                else
                    GestorMensajes.Advertencia("No se pudo agregar el empleado.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar empleado: " + ex.Message);
                return 0;
            }
        }

        public int Eliminar(BE.CLSEmpleado empleado)
        {
            try
            {
                int filasAfectadas = mapper.Eliminar(empleado);

                if (filasAfectadas != 0)
                {
                 GestorMensajes.Exito("Empleado eliminado correctamente.");
                    EmpleadoChanged?.Invoke(this, EventArgs.Empty);
                }
                   
                else
                    GestorMensajes.Advertencia("No se encontró el empleado a eliminar.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al eliminar empleado: " + ex.Message);
                return 0;
            }
        }

        public int Editar(BE.CLSEmpleado empleado, string email)
        {
            try
            {
                int filasAfectadas = mapper.Editar(empleado, email);

                if (filasAfectadas != 0)
                {
                    GestorMensajes.Exito("Empleado editado correctamente.");
                    EmpleadoChanged?.Invoke(this, EventArgs.Empty);
                }

                else
                    GestorMensajes.Advertencia("No se pudo editar el empleado.");

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al editar empleado: " + ex.Message);
                return 0;
            }
        }

        public List<BE.CLSEmpleado> Listar()
        {
            try
            {
                List<CLSEmpleado> lista = mapper.Listar();

                if (lista == null || lista.Count == 0)
                    GestorMensajes.Advertencia("No se encontraron empleados registrados.");

                return lista;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al listar empleados: " + ex.Message);
                return new List<BE.CLSEmpleado>();
            }
        }

        public string ObtenerMail(BE.CLSEmpleado empleado)
        {
            try
            {
                string email = mapper.ObtenerMail(empleado);

                if (string.IsNullOrEmpty(email))
                    GestorMensajes.Advertencia("El empleado seleccionado no tiene un email asociado.");
                return email;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al obtener el email del empleado: " + ex.Message);
                return string.Empty;
            }
        }

        public int CambiarContrasenia(CLSEmpleado empleado, string nuevaContra)
        {
            try
            {
                int filas = mapper.CambiarContrasenia(empleado.ID_emp, nuevaContra);

                if (!(filas == 0))
                    GestorMensajes.Exito("Contraseña modificada correctamente.");
                else
                    GestorMensajes.Advertencia("No se pudo cambiar la contraseña.");

                return filas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al modificar contraseña: " + ex.Message);
                return 0;
            }
        }

        public int CambiarCorreo(CLSEmpleado empleado, string nuevoCorreo)
        {
            try
            {
                int filas = mapper.CambiarCorreo(empleado.ID_emp, nuevoCorreo);

                if (!(filas == 0))
                    GestorMensajes.Exito("Contraseña modificada correctamente.");
                else
                    GestorMensajes.Advertencia("No se pudo cambiar la contraseña.");

                return filas;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al modificar contraseña: " + ex.Message);
                return 0;
            }
        }

        public void GenerarXML(string rutaSegura)
        {
            mapper.GenerarXML(rutaSegura);
        }
    }
}

