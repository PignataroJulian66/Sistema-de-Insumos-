using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_de_insumos_DAS
{
    public partial class FRMRegistrarse : Form
    {
        public FRMRegistrarse()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (miControlTexto1.Validar() ==true &&
                miControlTexto2.Validar() == true &&
                micontrolDNI1.Validar() == true &&
                miControlEmail1.Validar() == true &&
                miControlTelefono1.Validar() == true &&
                miControlContraseña1.Validar() ==true &&
                txtDireccion.Text != string.Empty)
            {
                try
                {
                    int fa = 0;
                    BE.CLSEmpleado empleado = new BE.CLSEmpleado();


                    empleado.Nombre = miControlTexto1.Texto;
                    empleado.Apellido = miControlTexto2.Texto;
                    empleado.Telefono = miControlTelefono1.Texto;
                    empleado.Direccion = txtDireccion.Text;
                    empleado.Rol = "5";
                    empleado.DNI = micontrolDNI1.Texto;

                    BLL.ClsEmpleado gEmpleado = new BLL.ClsEmpleado();
                    fa = gEmpleado.Agregar(empleado, miControlEmail1.Texto);
                    MessageBox.Show("Registro exitoso");
                    this.Close();
                    FRMInicioSesion f = new FRMInicioSesion();
                    f.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
        private void miControlTexto1_TextChanged1(object sender, EventArgs e)
        {
            miControlTexto1.Validar();
        }

        private void miControlTexto2_TextChanged1(object sender, EventArgs e)
        {
            miControlTexto2.Validar();
        }

        private void micontrolDNI1_TextChanged1(object sender, EventArgs e)
        {
            micontrolDNI1.Validar();
        }

        private void miControlEmail1_TextChanged1(object sender, EventArgs e)
        {
            miControlEmail1.Validar();
        }

        private void miControlTelefono1_TextChanged1(object sender, EventArgs e)
        {
            miControlTelefono1.Validar();
        }

        private void miControlContraseña1_TextChanged1(object sender, EventArgs e)
        {
            miControlContraseña1.Validar();
        }
    }
}
