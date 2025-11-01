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
    public partial class FrmABMProductos : Form
    {
        BLL.ClsInsumo Ginsumo = new BLL.ClsInsumo();
        BLL.CLSProductos GProductos = new BLL.CLSProductos();
        BE.ClsProductos producto = new BE.ClsProductos();
        public FrmABMProductos()
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
            cmbinsumo.DataSource = Ginsumo.Listar();
        }
        
        private void btnAlta_Click(object sender, EventArgs e)
        {
            int fa = 0;
            producto = new BE.ClsProductos();
            producto.Nombre = txtnombre.Text;
            producto.Precio = numericUpDown1.Value;
            producto.Rubro = txtRubro.Text;
            producto.Existencias = 0;

            fa = GProductos.Agregar(producto);
            if (fa != 0)
            {
                MessageBox.Show("Producto agregado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el Producto.");
            }
        }

        private void LimpiarCampos()
        {
           txtRubro.Text = string.Empty;
           txtnombre.Text = string.Empty;
           numericUpDown1.Value = 0;
           cmbinsumo.Text = string.Empty;
           cmbUnidad.Text = string.Empty;
           listBox1.Items.Clear();
           txtnombre.Focus();
           txtcantidadinsumo.Text = string.Empty;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            int fa = 0;
            producto = new BE.ClsProductos();
            producto = dgvProductos.SelectedRows[0].DataBoundItem as BE.ClsProductos;
            fa = GProductos.Eliminar(producto);
            if (fa != 0)
            {
                MessageBox.Show("Producto eliminado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el Producto.");
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            int fa = 0;
            producto = new BE.ClsProductos();
            producto = dgvProductos.SelectedRows[0].DataBoundItem as BE.ClsProductos;


            producto.Nombre = txtnombre.Text;
            producto.Precio = numericUpDown1.Value;
            producto.Rubro = txtRubro.Text;
            producto.Existencias = 0;

            fa = GProductos.Editar(producto);
            if (fa != 0)
            {
                MessageBox.Show("Producto editado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo editar el Producto.");
            }

        }
    }
}
