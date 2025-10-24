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
    public partial class FRMGerente : Form
    {
        public Form formularioactual = null;
        public FRMGerente() //recibe un clsgerente gerente
        {
            InitializeComponent();
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
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void operacionesClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmABMCliente fm = new FrmABMCliente();
            AbrirFormularioHijo(fm);

        }

        private void operacionesEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmABMEmpleado fm = new FrmABMEmpleado();
            AbrirFormularioHijo(fm);
        }

        private void operacionesProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmABMProveedor fm = new FrmABMProveedor();
            AbrirFormularioHijo(fm);
        }

        private void operacionesInsumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmABMInsumo fm = new FrmABMInsumo();
            AbrirFormularioHijo(fm);
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMInicioSesion f = new FRMInicioSesion();
            f.Show();
            this.Close();
        }
    }
}
