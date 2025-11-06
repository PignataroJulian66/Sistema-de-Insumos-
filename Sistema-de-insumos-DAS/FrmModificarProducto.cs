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
            GestorMensajes.MensajeGenerado += MostrarMensaje;
        }

        private void VerGrilla()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = GProductos.Listar();
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
                GestorMensajes.Advertencia("Debe seleccionar un producto para eliminar.");
                return;
            }
            BE.ClsProductos producto = (BE.ClsProductos)dgvProductos.SelectedRows[0].DataBoundItem;
            int fa = 0;
            bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de modificar este producto?");
            if (resultado)
            {
                producto.Nombre = txtNombre.Text;
                producto.Precio = numericUpDown1.Value;

                fa = GProductos.Editar(producto);
                if (fa != 0)
                {
                    VerGrilla();
                }
            }
            else { return; }
            
            
        }
    }
}
