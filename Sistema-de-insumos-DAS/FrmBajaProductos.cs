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
    public partial class FrmBajaProductos : Form
    {
        BLL.CLSProductos GProductos = new BLL.CLSProductos();
        BLL.ClsInsumo Ginsumo = new BLL.ClsInsumo();
        BE.ClsProductos tmp = new BE.ClsProductos();
        public FrmBajaProductos()
        {
            InitializeComponent();
            dgvProductos.ReadOnly = true;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VerGrilla();
        }

        private void VerGrilla()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = GProductos.Listar();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tmp = dgvProductos.SelectedRows[0].DataBoundItem as BE.ClsProductos;
                listBox1.DataSource = tmp.ListaInsumos;
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar un empleado para eliminar.");
                return;
            }
            BE.ClsProductos producto = (BE.ClsProductos)dgvProductos.SelectedRows[0].DataBoundItem;
            int fa = 0;

            fa = GProductos.Eliminar(producto);
            if (fa != 0)
            {
                VerGrilla();
            }
        }
    }
}
