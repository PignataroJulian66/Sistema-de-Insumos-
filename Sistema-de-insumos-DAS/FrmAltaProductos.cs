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
    public partial class FrmAltaProductos : Form
    {
        BLL.ClsInsumo Ginsumo = new BLL.ClsInsumo();
        BLL.CLSProductos GProductos = new BLL.CLSProductos();

        BE.ClsProductos producto = new BE.ClsProductos();

        List<BE.ClsInsumo> lstinsumos = new List<BE.ClsInsumo>();
        List<BE.ClsInsumo> lstDetalles = new List<BE.ClsInsumo>();
        public FrmAltaProductos()
        {
            InitializeComponent();
            CargaCombo();
            cmbinsumo.Text = string.Empty;
            txtUnidadInsumo.ReadOnly = true;
        }

        private void CargaCombo()
        {
            lstinsumos = Ginsumo.Listar();
            cmbinsumo.DataSource = lstinsumos;
        }

        private void cmbinsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUnidadInsumo.Text = lstinsumos[cmbinsumo.SelectedIndex].Unidad;
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            BE.ClsInsumo detalle = new BE.ClsInsumo();
            BE.ClsInsumo insumo = lstinsumos[cmbinsumo.SelectedIndex];
            detalle.Id = insumo.Id;
            detalle.Nombre = insumo.ToString();
            detalle.Unidad = insumo.Unidad;
            detalle.Cantidad = numericUpDown2.Value;
            lstDetalles.Add(detalle);
            listBox1.DataSource = null;
            listBox1.DataSource = lstDetalles;

            cmbinsumo.Text = string.Empty;
            txtUnidadInsumo.Text = string.Empty;
            numericUpDown2.Value = 0;
        }

        private void btnLimpiarLista_Click(object sender, EventArgs e)
        {
            lstDetalles.Clear();
            listBox1.DataSource= null;
            listBox1.DataSource = lstDetalles;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            int fa = 0;
            
            producto = new BE.ClsProductos();
            producto.Nombre = txtnombre.Text;
            producto.Precio = numericUpDown1.Value;
            producto.Rubro = txtRubro.Text;
            producto.Componentes = lstDetalles.Cast<BE.IComponenteInventario>().ToList();
            producto.Existencias = producto.CalcularExistencias(); 

            fa = GProductos.Agregar(producto);
            if (fa != 0)
            {
                MessageBox.Show("Producto agregado con éxito.");
                LimpiarCampos();
                lstDetalles.Clear();
                listBox1.DataSource = null;
                listBox1.DataSource = lstDetalles;
            }
            else
            {
                MessageBox.Show("No se pudo agregar el Producto.");
            }
        }

        private void LimpiarCampos()
        {
            txtnombre.Text = string.Empty;
            numericUpDown1.Value = 0;
            txtRubro.Text = string.Empty;
            cmbinsumo.Text = string.Empty;
            txtUnidadInsumo.Text = string.Empty;
            numericUpDown2.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Archivos XML (*.xml)|*.xml"; // Filtra para que solo se vean archivos XML
            saveDialog.Title = "Guardar listado de productos";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaSegura = saveDialog.FileName;

                    BLL.CLSProductos gestor = new BLL.CLSProductos();
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
