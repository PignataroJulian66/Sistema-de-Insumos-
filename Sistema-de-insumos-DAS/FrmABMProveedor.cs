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
    public partial class FrmABMProveedor : Form
    {
        public FrmABMProveedor()
        {
            InitializeComponent();
            VerGrilla();
            dgvProveedores.ReadOnly = true;
            dgvProveedores.MultiSelect = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        BE.CLSProveedor proveedor; 
        BLL.ClsProveedor gProveedor = new BLL.ClsProveedor();
        BE.CLSProveedor tmp;
        private void VerGrilla()
        {
            dgvProveedores.DataSource = null; 
            dgvProveedores.DataSource = gProveedor.Listar(); 
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            int fa = 0;
            proveedor = new BE.CLSProveedor();

            proveedor.Nombre = txtNombre.Text;
            proveedor.Cuit = txtCuit.Text;
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Direccion = txtDireccion.Text;

            fa = gProveedor.Agregar(proveedor, txtEmail.Text);
            if (fa != 0)
            {
                MessageBox.Show("Proveedor agregado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el proveedor.");
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            int fa = 0;
            proveedor = new BE.CLSProveedor();
            proveedor = dgvProveedores.SelectedRows[0].DataBoundItem as BE.CLSProveedor;

            fa = gProveedor.Eliminar(proveedor);
            if (fa != 0)
            {
                MessageBox.Show("Proveedor eliminado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el proveedor.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            proveedor = new BE.CLSProveedor();
            proveedor = dgvProveedores.SelectedRows[0].DataBoundItem as BE.CLSProveedor;

            proveedor.Nombre = txtNombre.Text;
            proveedor.Cuit = txtCuit.Text;
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Direccion = txtDireccion.Text;

            fa = gProveedor.Editar(proveedor, txtEmail.Text);
            if (fa != 0)
            {
                MessageBox.Show("Proveedor editado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo editar el proveedor.");
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
              
                tmp = (BE.CLSProveedor)dgvProveedores.Rows[e.RowIndex].DataBoundItem;

                txtNombre.Text = tmp.Nombre;
                txtCuit.Text = tmp.Cuit;
                txtTelefono.Text = tmp.Telefono;
                txtDireccion.Text = tmp.Direccion;
                txtEmail.Text = gProveedor.ObtenerMailProveedor(tmp);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCuit.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
        }
    }
}
