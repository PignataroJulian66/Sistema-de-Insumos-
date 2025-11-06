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
    public partial class FrmCambiarCorreoEmpleado : Form
    {
        BE.CLSEmpleado empleadoActual = new BE.CLSEmpleado();
        BLL.ClsEmpleado gestorEmpleado = new BLL.ClsEmpleado();
        public FrmCambiarCorreoEmpleado(BE.CLSEmpleado emp)
        {
            InitializeComponent();
            empleadoActual = emp;
            GestorMensajes.MensajeGenerado += MostrarMensaje; GestorMensajes.MensajeGenerado += MostrarMensaje;
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
            string Correo = txtCorreo.Text.Trim();
            string ConfirmarCorreo = txtConfirmarCorreo.Text.Trim();
            bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de modificar este correo?");
            if (resultado)
            {
                if (Correo == string.Empty || ConfirmarCorreo == string.Empty)
                {
                    GestorMensajes.Advertencia("Complete los campos.");
                    return;
                }

                if (Correo != ConfirmarCorreo)
                {
                    GestorMensajes.Advertencia("Los correos no coinciden.");
                    return;
                }
                int fa = gestorEmpleado.CambiarCorreo(empleadoActual, Correo);
                if (fa != 0)
                    this.Close();
            }
            else { return; }
            
        }
    }
}
