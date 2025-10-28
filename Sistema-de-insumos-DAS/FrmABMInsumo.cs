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
    public partial class FrmABMInsumo : Form
    {
        public FrmABMInsumo()
        {
            InitializeComponent();
            VerGrilla();
            dgvInsumos.ReadOnly = true;
            dgvInsumos.MultiSelect = false;
            dgvInsumos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        BE.ClsInsumo insumo; 
        BLL.ClsInsumo gInsumo = new BLL.ClsInsumo(); 
        BE.ClsInsumo tmp;

        private void VerGrilla()
        {
            dgvInsumos.DataSource = null; 
            dgvInsumos.DataSource = gInsumo.Listar(); 
        }
        private void dgvInsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                tmp = (BE.ClsInsumo)dgvInsumos.Rows[e.RowIndex].DataBoundItem;

                txtNombre.Text = tmp.Nombre;
                comboBox1.Text = tmp.Unidad;
                cmbCalidad.Text = tmp.Calidad;
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            int fa = 0;
            insumo = new BE.ClsInsumo();

            try
            {
                insumo.Nombre = txtNombre.Text;
                insumo.Unidad = comboBox1.Text;
                insumo.Cantidad = 0;
                insumo.Calidad = cmbCalidad.Text;

                fa = gInsumo.Agregar(insumo);
                if (fa != 0)
                {
                    MessageBox.Show("Insumo agregado con éxito.");
                    VerGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el insumo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar datos: " + ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            int fa = 0;
            insumo = new BE.ClsInsumo();

            try
            {
                insumo = dgvInsumos.SelectedRows[0].DataBoundItem as BE.ClsInsumo;
                fa = gInsumo.Eliminar(insumo);
                if (fa != 0)
                {
                    MessageBox.Show("Insumo eliminado con éxito.");
                    VerGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el insumo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar ID: " + ex.Message);
            }
        }

        /*private void btnEditar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            insumo = new BE.ClsInsumo();

            try
            {
                insumo.Nombre = txtNombre.Text;
                insumo.Unidad = comboBox1.Text;
                insumo.Calidad = cmbCalidad.Text;

                fa = gInsumo.Editar(insumo);
                if (fa != 0)
                {
                    MessageBox.Show("Insumo editado con éxito.");
                    VerGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo editar el insumo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar datos: " + ex.Message);
            }
        }
        DECDIMOS QUE NO SE PUEDAN MODIFICAR INSUMOS, LO DEJAMOS POR SI LAS DUDAS
         */
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            comboBox1.Text = "";
            cmbCalidad.Text = "";
        }
    }
}
