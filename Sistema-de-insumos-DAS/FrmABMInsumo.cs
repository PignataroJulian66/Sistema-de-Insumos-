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

               
                txtID.Text = tmp.ID.ToString();
                txtNombre.Text = tmp.Nombre;
                txtUnidad.Text = tmp.Unidad;
                txtCantidad.Text = tmp.Cantidad.ToString(); 
                txtCalidad.Text = tmp.Calidad;
                txtProporcion.Text = tmp.Proporcion.ToString(); 
                txtPrecioActual.Text = tmp.PrecioActual.ToString(); 
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            int fa = 0;
            insumo = new BE.ClsInsumo();

            try
            {
               
                insumo.ID = int.Parse(txtID.Text);
                insumo.Nombre = txtNombre.Text;
                insumo.Unidad = txtUnidad.Text;
                insumo.Cantidad = int.Parse(txtCantidad.Text); 
                insumo.Calidad = txtCalidad.Text;
                insumo.Proporcion = (txtProporcion.Text);
                insumo.PrecioActual = decimal.Parse(txtPrecioActual.Text);

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
                
                insumo.ID = int.Parse(txtID.Text);

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            insumo = new BE.ClsInsumo();

            try
            {
               
                insumo.ID = int.Parse(txtID.Text);
                insumo.Nombre = txtNombre.Text;
                insumo.Unidad = txtUnidad.Text;
                insumo.Cantidad = int.Parse(txtCantidad.Text);
                insumo.Calidad = txtCalidad.Text;
                insumo.Proporcion = (txtProporcion.Text);
                insumo.PrecioActual = decimal.Parse(txtPrecioActual.Text);

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
        private void LimpiarCampos()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtUnidad.Text = "";
            txtCantidad.Text = ""; 
            txtCalidad.Text = "";
            txtProporcion.Text = ""; 
            txtPrecioActual.Text = ""; 
        }
    }
}
