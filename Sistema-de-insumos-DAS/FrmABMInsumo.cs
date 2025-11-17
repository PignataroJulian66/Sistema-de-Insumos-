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
    public partial class FrmABMInsumo : Form
    {
        public FrmABMInsumo()
        {
            InitializeComponent();
            GestorMensajes.MensajeGenerado += MostrarMensaje;
            VerGrilla();
            dgvInsumos.ReadOnly = true;
            dgvInsumos.MultiSelect = false;
            dgvInsumos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                GestorMensajes.Advertencia("El campo 'Nombre' es obligatorio.");
                return false;
            }

            if (txtNombre.Text.Any(char.IsDigit))
            {
                GestorMensajes.Advertencia("El nombre no debe contener números.");
                return false;
            }

            if (txtNombre.Text.Length < 4)
            {
                GestorMensajes.Advertencia("El nombre debe tener al menos 4 caracteres.");
                return false;
            }

            if (comboBox1.SelectedIndex < 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar una unidad.");
                return false;
            }

            if (cmbCalidad.SelectedIndex < 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar una calidad.");
                return false;
            }

            return true;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
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
                  
                    VerGrilla();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar datos: " + ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvInsumos.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar un insumo para eliminar.");
                return;
            }
            int fa = 0;
            insumo = new BE.ClsInsumo();

            try
            {
                insumo = dgvInsumos.SelectedRows[0].DataBoundItem as BE.ClsInsumo;
                bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de modificar este insumo?");
                if (resultado)
                {
                    fa = gInsumo.Eliminar(insumo);
                    if (fa != 0)
                    {
                        VerGrilla();
                        LimpiarCampos();
                    }
                }
                else { return; }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar ID: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            comboBox1.Text = "";
            cmbCalidad.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Archivos XML (*.xml)|*.xml"; // Filtra para que solo se vean archivos XML
            saveDialog.Title = "Guardar listado de insumos";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaSegura = saveDialog.FileName;

                    BLL.ClsInsumo gestor = new BLL.ClsInsumo();
                    gestor.GenerarXML(rutaSegura);

                    MessageBox.Show("Archivo XML generado con éxito en:\n" + rutaSegura, "Éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar el archivo: " + ex.Message, "Error");
                }
            }
        }
    }
}
