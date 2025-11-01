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
    public partial class FrmModificarProducto : Form
    {
        BLL.CLSProductos GProductos = new BLL.CLSProductos();
        BE.ClsProductos tmp = new BE.ClsProductos();
        public FrmModificarProducto()
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

        private void dgvProductos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tmp = dgvProductos.SelectedRows[0].DataBoundItem as BE.ClsProductos;
                txtNombre.Text = tmp.Nombre;
                numericUpDown1.Value = tmp.Precio;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar un empleado para eliminar.");
                return;
            }
            BE.ClsProductos producto = (BE.ClsProductos)dgvProductos.SelectedRows[0].DataBoundItem;
            int fa = 0;

            producto.Nombre = txtNombre.Text;
            producto.Precio = numericUpDown1.Value;

            fa = GProductos.Editar(producto);
            if (fa != 0)
            {
                VerGrilla();
            }
        }
    }
}
