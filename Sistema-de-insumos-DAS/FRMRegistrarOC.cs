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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_de_insumos_DAS
{ 
    public partial class FRMRegistrarOC : Form
    {
        BLL.ClsInsumo gInsumo = new BLL.ClsInsumo();
        BE.ClsInsumo tmp;
        BLL.ClsProveedor gprov = new BLL.ClsProveedor();
        BE.CLSEmpleado emp = new BE.CLSEmpleado();
        List<BE.CLSProveedor> proveedores = new List<BE.CLSProveedor>();
        BLL.ClsOrdenCompra gorden = new BLL.ClsOrdenCompra();
        public FRMRegistrarOC(BE.CLSEmpleado empleado)
        { 
            InitializeComponent();
            dgvInsumos.ReadOnly = true;
            dgvInsumos.MultiSelect = false;
            dgvInsumos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;        
            dgvInsumos.DataSource = gInsumo.Listar();
            proveedores = gprov.Listar();
            cmbProveedor.DataSource = proveedores;
            emp = empleado;
            GestorMensajes.MensajeGenerado += MostrarMensaje;
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

        private void dgvInsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {        
            if (e.RowIndex >= 0)
            {
                tmp = (BE.ClsInsumo)dgvInsumos.Rows[e.RowIndex].DataBoundItem;         
            }
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            if (dgvInsumos.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar un insumo.");
                return;
            }

            if (!(numericUpDown2.Value == 0 || cmbProveedor.Text == string.Empty))
            {
                BE.ClsOrdenCompra orden = new BE.ClsOrdenCompra();
                orden.ID_Emp = emp.ID_emp.ToString();

                orden.NInsumo = tmp.Id.ToString();
                orden.Unidad = tmp.Unidad;
                orden.Cantidad = numericUpDown2.Value;
                orden.FechaEntrega = dateTimePicker1.Value;
                orden.Finalizado = false;
                orden.ID_prov = proveedores[cmbProveedor.SelectedIndex].ID_prov.ToString();
                gorden.Agregar(orden);
                GestorMensajes.Exito("OC generada Exitosamente");
                numericUpDown2.Value = 0;
                cmbProveedor.Text = string.Empty;
            }
            else { GestorMensajes.Error("Complete todos los campos"); }
        }
    }
}
