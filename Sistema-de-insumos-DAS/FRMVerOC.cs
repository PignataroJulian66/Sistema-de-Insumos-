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
    public partial class FRMVerOC : Form
    {
        BLL.ClsOrdenCompra gorden = new BLL.ClsOrdenCompra();
        
        public FRMVerOC(CLSProveedor prov)
        {
            InitializeComponent();
            dgvOC.DataSource = gorden.Listar(prov);
            dgvOC.ReadOnly = true;
            dgvOC.MultiSelect = false;
            dgvOC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {
            BE.ClsOrdenCompra OC = dgvOC.SelectedRows[0].DataBoundItem as BE.ClsOrdenCompra;

            if(OC.Cotizacion != 0)
            {
                MessageBox.Show("La orden ya fue cotizada");
            }
            else
            {
                OC.Cotizacion = numericUpDown1.Value;
                gorden.Editar(OC);
                MessageBox.Show("Orden cotizada con exito");
            }
        }
    }
}
