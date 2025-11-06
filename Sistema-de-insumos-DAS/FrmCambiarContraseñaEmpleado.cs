using BE;
using BLL;
using Mensajes1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_insumos_DAS
{
    public partial class FrmCambiarContraseñaEmpleado : Form
    {
        BE.CLSEmpleado empleadoActual = new BE.CLSEmpleado();
        BLL.ClsEmpleado gestorEmpleado = new BLL.ClsEmpleado();

        public FrmCambiarContraseñaEmpleado(CLSEmpleado emp)
        {
            InitializeComponent();
            empleadoActual = emp;
            GestorMensajes.MensajeGenerado += MostrarMensaje;
        }

        private void MostrarMensaje(object sender, MensajeEventArgs e)
        {
            switch (e.Tipo)
            {
                case TipoMensaje.Informacion:
                    MessageBox.Show(e.Texto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case TipoMensaje.Advertencia:
                    MessageBox.Show(e.Texto, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case TipoMensaje.Error:
                    MessageBox.Show(e.Texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case TipoMensaje.Exito:
                    MessageBox.Show(e.Texto, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Contrasenia = txtContra.Text.Trim();
            string ConfirmarContrasenia = txtConfirmarContra.Text.Trim();
            bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de modificar la contrasenia?");
            if (resultado)
            {
                if (Contrasenia == string.Empty || ConfirmarContrasenia == string.Empty)
                {
                    GestorMensajes.Advertencia("Complete los campos.");
                    return;
                }

                if (Contrasenia != ConfirmarContrasenia)
                {
                    GestorMensajes.Advertencia("Las contraseñas no coinciden.");
                    return;
                }

                int fa = gestorEmpleado.CambiarContrasenia(empleadoActual, Contrasenia);
                if (fa != 0)
                    this.Close();
            }
            else { return; }
           
            
        }
    }
 }

