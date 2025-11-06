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
            bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de eliminar este producto?");
            if (resultado) 
            {
            fa = GProductos.Eliminar(producto);
            if (fa != 0)
            {
                VerGrilla();
            }
            }
            
        }
    }
}
