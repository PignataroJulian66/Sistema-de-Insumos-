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
    public partial class FrmABMProductos : Form
    {
        BLL.ClsInsumo Ginsumo = new BLL.ClsInsumo();
        BLL.CLSProductos GProductos = new BLL.CLSProductos();
        BE.ClsProductos producto = new BE.ClsProductos();
        public FrmABMProductos()
        {
            InitializeComponent();
            GestorMensajes.MensajeGenerado += MostrarMensaje;
            dgvProductos.ReadOnly = true;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VerGrilla();
        }

        private void MostrarMensaje(object sender, MensajeEventArgs e)
        {
            switch (e.Tipo)
            {
                case TipoMensaje.Informacion:
                    MessageBox.Show(e.Texto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case TipoMensaje.Advertencia:
                    MessageBox.Show(e.Texto, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case TipoMensaje.Error:
                    MessageBox.Show(e.Texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case TipoMensaje.Exito:
                    MessageBox.Show(e.Texto, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
            }
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
                VerGrilla();
                LimpiarCampos();
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
            if (dgvProductos.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Selecciona un producto para Eliminar.");
            }
            int fa = 0;
            producto = new BE.ClsProductos();
            producto = dgvProductos.SelectedRows[0].DataBoundItem as BE.ClsProductos;
            if (!GestorConfirmaciones.Confirmar($"¿Estás seguro de eliminar \"{producto.Nombre}\"?"))
            return;

            fa = GProductos.Eliminar(producto);
            if (fa != 0)
            {
                VerGrilla();
                LimpiarCampos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Selecciona un producto para modificar.");
            }

            int fa = 0;
            producto = new BE.ClsProductos();
            producto = dgvProductos.SelectedRows[0].DataBoundItem as BE.ClsProductos;
            if (!GestorConfirmaciones.Confirmar($"¿Estás seguro de modificar \"{producto.Nombre}\"?"))
            return;

            producto.Nombre = txtnombre.Text;
            producto.Precio = numericUpDown1.Value;
            producto.Rubro = txtRubro.Text;
            producto.Existencias = 0;

            fa = GProductos.Editar(producto);
            if (fa != 0)
            {
                VerGrilla();
                LimpiarCampos();
            }

        }
    }
}
