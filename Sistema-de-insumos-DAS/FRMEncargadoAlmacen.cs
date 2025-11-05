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
    public partial class FRMEncargadoAlmacen : Form
    {
        public Form formularioactual = null;
        BE.CLSEmpleado emp = new BE.CLSEmpleado();
        public FRMEncargadoAlmacen(CLSEmpleado empleado)
        {
            InitializeComponent();
            emp = empleado;
        }

        public void AbrirFormularioHijo(Form f)
        {
            if (formularioactual == null)
            {
                f.MdiParent = this;
                f.Show();
                f.Enabled = true;
                formularioactual = f;
                f.Dock = DockStyle.Fill;
            }
            else if (formularioactual.GetType() == f.GetType())
            {
                formularioactual.Close();
                formularioactual = null;
            }
            else
            {
                formularioactual.Close();
                formularioactual = null;
                AbrirFormularioHijo(f);
            }
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMInicioSesion f = new FRMInicioSesion();
            f.Show();
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registrarOrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMRegistrarOC fm = new FRMRegistrarOC(emp);
            AbrirFormularioHijo(fm);
        }

        private void realizarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMRealizarCompra fm = new FRMRealizarCompra(emp);
            AbrirFormularioHijo(fm);
        }

        private void verComprasPasadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComprasPasadas fm = new FrmComprasPasadas(emp);
            AbrirFormularioHijo(fm);
        }
    }
}
