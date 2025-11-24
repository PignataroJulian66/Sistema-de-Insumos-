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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sistema_de_insumos_DAS
{
    public partial class FrmABMProveedor : Form
    {
        public FrmABMProveedor()
        {
            InitializeComponent();
            GestorMensajes.MensajeGenerado -= MostrarMensaje;
            GestorMensajes.MensajeGenerado += MostrarMensaje;
            VerGrilla();
            dgvProveedores.ReadOnly = true;
            dgvProveedores.MultiSelect = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void MostrarMensaje(object sender, MensajeEventArgs e)
        {
            switch (e.Tipo)
            {
                case TipoMensaje.Exito:
                    MessageBox.Show(e.Texto, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case TipoMensaje.Advertencia:
                    MessageBox.Show(e.Texto, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case TipoMensaje.Error:
                    MessageBox.Show(e.Texto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case TipoMensaje.Informacion:
                    MessageBox.Show(e.Texto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
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
            if (!ValidarCampos()) return;

            int fa = 0;
            proveedor = new BE.CLSProveedor();

            proveedor.Nombre = txtNombre.Text;
            proveedor.Cuit = txtCuit.Text;
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Direccion = txtDireccion.Text;

            fa = gProveedor.Agregar(proveedor, txtEmail.Text);
            if (fa != 0)
            {
                VerGrilla();
                LimpiarCampos();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar un proveedor para eliminar.");
                return;
            }
            int fa = 0;
            proveedor = new BE.CLSProveedor();
            proveedor = dgvProveedores.SelectedRows[0].DataBoundItem as BE.CLSProveedor;
            if (!GestorConfirmaciones.Confirmar($"¿Estás seguro de eliminar \"{proveedor.Nombre}\"?"))
            return;

            fa = gProveedor.Eliminar(proveedor);
            if (fa != 0)
            {
                VerGrilla();
                LimpiarCampos();
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            proveedor = new BE.CLSProveedor();
            proveedor = dgvProveedores.SelectedRows[0].DataBoundItem as BE.CLSProveedor;
            if (!ValidarCampos()) return;
            if (!GestorConfirmaciones.Confirmar($"¿Estás seguro de modificar \"{proveedor.Nombre}\"?"))
            return;
           if (gProveedor.Listar().Any(p => p.Cuit == txtCuit.Text))
            {
                GestorMensajes.Advertencia("Ya existe un proveedor con ese CUIT.");
                return;
            }

            proveedor.Nombre = txtNombre.Text;
            proveedor.Cuit = txtCuit.Text;
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Direccion = txtDireccion.Text;

            fa = gProveedor.Editar(proveedor, txtEmail.Text);
            if (fa != 0)
            {
                VerGrilla();
                LimpiarCampos();
            }
        }
        private bool ValidarCampos()
        {
            string nombre = txtNombre.Text.Trim();
            string cuit = txtCuit.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cuit) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(email))
            {
                GestorMensajes.Error("Todos los campos son obligatorios.");
                return false;
            }

            if (txtNombre.Text.Any(char.IsDigit))
            {
                GestorMensajes.Advertencia("El nombre no deben contener números.");
                return false;
            }

            if (cuit.Length != 11 || !cuit.All(char.IsDigit))
            {
                GestorMensajes.Error("El CUIT debe contener exactamente 11 números.");
                return false;
            }
            
            if (telefono.Length != 10 || !telefono.All(char.IsDigit))
            {
                GestorMensajes.Error("El teléfono debe contener exactamente 10 números.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                GestorMensajes.Advertencia("El formato del email no es válido.");
                return false;
            }
            return true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Archivos XML (*.xml)|*.xml"; // Filtra para que solo se vean archivos XML
            saveDialog.Title = "Guardar listado de proveedores";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaSegura = saveDialog.FileName;

                    BLL.ClsProveedor gestor = new BLL.ClsProveedor();
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
