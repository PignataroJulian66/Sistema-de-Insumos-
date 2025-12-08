using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_insumos_DAS
{
    public partial class FRMInicioSesion : Form
    {
        BLL.GestorUsuarios gu = new BLL.GestorUsuarios();
        
        public FRMInicioSesion()
        {
            InitializeComponent();
            this.AcceptButton = btnIniciarsesion;
            txtContraseña.UseSystemPasswordChar = false;
            lblerror.Visible = false;
        }
       
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void msgerror(string v)
        {
            lblerror.Text = "       " + v;
            lblerror.Visible = true;
        }

        public bool IntentarLogin(string email, string passwordIngresada)
        {
            
            byte[] hashAlmacenado = gu.ObtenerHashAlmacenado(email); // hash almacenado

            
            if (hashAlmacenado == null) // Si el usuario no existe o el hash  nulo, no le doy el acceso.
            {
                msgerror("Usuario no encontrado");
                return false;
            }

           
         
            bool esValido = gu.VerifyPassword(passwordIngresada, hashAlmacenado);  //  Verifico contra

            if (esValido)
            {
                int usuario = gu.InicioSesion(txtEmail.Text);
                bool EsEmpleado = gu.EsEmpleado(usuario);
                bool EsProveedor = gu.EsProveedor(usuario);

                if (EsProveedor && !EsEmpleado)
                {
                    FRMProveedor f = new FRMProveedor(gu.BuscarProveedor(usuario));
                    f.Show();
                    this.Hide();
                }
                else if (EsEmpleado && !EsProveedor)
                {
                    CLSEmpleado empleado = gu.BuscarEmpleado(usuario);
                    switch (empleado.Rol.ToLower())
                    {
                        case "encargado de almacen":
                            FRMEncargadoAlmacen fm = new FRMEncargadoAlmacen(empleado);
                            fm.Show();
                            this.Hide();
                            break;

                        case "encargado de produccion":
                            MessageBox.Show("abre form encargado de produccion");
                            break;
                        case "gerente":
                            FRMGerente fm1 = new FRMGerente(empleado);
                            fm1.Show();
                            this.Hide();
                            break;
                        case "vendedor":
                            MessageBox.Show("abre form vendedor");
                            break;
                        case "ninguno":
                            FrmSinRol f = new FrmSinRol(empleado);
                            f.Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("Error");
                            break;
                    }
                }
                else
                {
                    msgerror("Usuario no encontrado.");
                }
                return true;
            }
            else
            {
                msgerror("Contraseña incorrecta.");
                return false;
            }
        }

        private void btnIniciarsesion_Click_1(object sender, EventArgs e)
        {
            try
            {
                IntentarLogin(txtEmail.Text, txtContraseña.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
           

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = string.Empty;
                txtEmail.ForeColor = Color.LightGray;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty)
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = string.Empty;
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FRMInicioSesion_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRegistrarse_Click_1(object sender, EventArgs e)
        {
            FRMRegistrarse aux = new FRMRegistrarse();
            aux.Show();
            aux.Enabled = true;
            this.Hide();
        }

        private void FRMInicioSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                gu.Desconectar();
                Console.WriteLine("Singleton de Acceso desechado correctamente.");
            }
            catch (Exception ex)
            {
              
                MessageBox.Show($"Error al cerrar la conexión de la base de datos: {ex.Message}", "Error Crítico de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
