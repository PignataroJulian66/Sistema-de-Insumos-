using BE;
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
    public partial class FRMVerPerfil : Form
    {
        BE.CLSEmpleado emp = new CLSEmpleado();
        public FRMVerPerfil(CLSEmpleado empleado)
        {
            InitializeComponent();
            label1.Text = empleado.Nombre;
            label2.Text = empleado.Apellido;
            label3.Text = empleado.Telefono;
            label4.Text = empleado.Direccion;
            emp = empleado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCambiarContraseñaEmpleado CCE = new FrmCambiarContraseñaEmpleado(emp);
            this.Hide();
            CCE.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCambiarCorreoEmpleado CE = new FrmCambiarCorreoEmpleado(emp);
            this.Hide();
            CE.ShowDialog();
            this.Show();
        }
    }
}
