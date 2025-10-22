using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public FRMInicioSesion()
        {
            InitializeComponent();
            txtContraseña.UseSystemPasswordChar = false;
            lblerror.Visible = false;
        }
       
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void btnIniciarsesion_Click(object sender, EventArgs e)
        {
        }



        private void msgerror(string v)
        {
            lblerror.Text = "       " + v;
            lblerror.Visible = true;
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "DNI")
            {
                txtEmail.Text = string.Empty;
                txtEmail.ForeColor = Color.LightGray;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty)
            {
                txtEmail.Text = "DNI";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FRMInicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            //FRMRegistrarse aux = new FRMRegistrarse();
            //aux.Show();
            //aux.Enabled = true;
            //this.Hide();
        }

        private void btnIniciarsesion_Click_1(object sender, EventArgs e)
        {
            try
            {
                BLL.GestorUsuarios gu = new BLL.GestorUsuarios();
                int usuario = gu.InicioSesion(txtEmail.Text, txtContraseña.Text);
                bool EsEmpleado = gu.EsEmpleado(usuario);
                bool EsProveedor = gu.EsProveedor(usuario);
                if (EsProveedor && EsEmpleado)
                {
                    this.Controls.Remove(txtEmail);
                    this.Controls.Remove(txtContraseña);
                    this.Controls.Remove(btnRegistrarse);
                    this.Controls.Remove(btnIniciarsesion);
                    this.Controls.Remove(lblerror);
                    this.Controls.Remove(label4);

                    Button nuevoBoton = new Button();

                    nuevoBoton.Text = "Ingresar como empleado";
                    nuevoBoton.Name = "btnEmpleado";
                    nuevoBoton.Location = new System.Drawing.Point(326, 74);
                    nuevoBoton.Size = new System.Drawing.Size(417, 68);
                    nuevoBoton.BackColor = Color.FromArgb(40, 40, 40);
                    nuevoBoton.ForeColor = Color.White;
                    nuevoBoton.Click += (s, ev) =>
                    {
                        MessageBox.Show("arbir form de empleado:");
                    };
                    this.Controls.Add(nuevoBoton);


                    Button nuevoBoton2 = new Button();
                    nuevoBoton2.Text = "Ingresar como proveedor";
                    nuevoBoton2.Name = "btnProveedor";
                    nuevoBoton2.Location = new System.Drawing.Point(326, 199);
                    nuevoBoton2.Size = new System.Drawing.Size(417, 68);
                    nuevoBoton2.BackColor = Color.FromArgb(40, 40, 40);
                    nuevoBoton2.ForeColor = Color.White;
                    nuevoBoton2.Click += (s, ev) =>
                    {
                        FRMProveedor f = new FRMProveedor(gu.BuscarProveedor(usuario));
                        f.Show();
                        this.Hide();
                    };
                    this.Controls.Add(nuevoBoton2);
                }
                else if (EsProveedor && !EsEmpleado)
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
                            MessageBox.Show("abre form encargado de almacen");
                            break;

                        case "encargado de produccion":
                            MessageBox.Show("abre form encargado de produccion");
                            break;
                        case "gerente":
                            MessageBox.Show("abre form gerente");
                            break;
                        case "vendedor":
                            MessageBox.Show("abre form vendedor");
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


            }catch(Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
           

        }
    }
}
