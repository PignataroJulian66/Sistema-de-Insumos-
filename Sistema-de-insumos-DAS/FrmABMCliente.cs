using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mensajes1;

namespace Sistema_de_insumos_DAS
{
    public partial class FrmABMCliente : Form
    {
        public FrmABMCliente()
        {
            InitializeComponent();
            GestorMensajes.MensajeGenerado -= MostrarMensaje;
            GestorMensajes.MensajeGenerado += MostrarMensaje;
            VerGrilla();
            dgvClientes.ReadOnly = true;
            dgvClientes.MultiSelect = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        BE.ClsCliente cliente; 
        BLL.ClsCliente gCliente = new BLL.ClsCliente(); 
        BE.ClsCliente tmp; 
        private void VerGrilla()
        {
            dgvClientes.DataSource = null; 
            dgvClientes.DataSource = gCliente.Listar(); 
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                GestorMensajes.Advertencia("Todos los campos son obligatorios.");
                return false;
            }

            if (txtNombre.Text.Any(char.IsDigit) || txtApellido.Text.Any(char.IsDigit))
            {
                GestorMensajes.Advertencia("El nombre y el apellido no deben contener números.");
                return false;
            }

            if (txtTelefono.Text.Length != 10 || !txtTelefono.Text.All(char.IsDigit))
            {
                GestorMensajes.Advertencia("El teléfono debe tener exactamente 10 números.");
                return false;
            }

            if (!txtDNI.Text.All(char.IsDigit) || txtDNI.Text.Length < 7 || txtDNI.Text.Length > 8)
            {
                GestorMensajes.Advertencia("El DNI debe tener entre 7 y 8 números.");
                return false;
            }

            return true;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (gCliente.Listar().Any(c => c.DNI == txtDNI.Text))
            {
                GestorMensajes.Advertencia("Ya existe un cliente con ese DNI.");
                return;
            }

            int fa = 0;
            cliente = new BE.ClsCliente();

           
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.DNI = txtDNI.Text;

            fa = gCliente.Agregar(cliente);
            if (fa != 0)
            {
                VerGrilla();
                LimpiarCampos();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar un cliente para eliminar.");
                return;
            }


            int fa = 0;
            cliente = new BE.ClsCliente();
            cliente = dgvClientes.SelectedRows[0].DataBoundItem as BE.ClsCliente;
            bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de eliminar este cliente?");
            if (resultado)
            {
                fa = gCliente.Eliminar(cliente);
                if (fa != 0)
                {
                    GestorMensajes.Exito("Proceso exitoso");
                    VerGrilla();
                    LimpiarCampos();
                }
            }
            else { return; }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            cliente = new BE.ClsCliente();
            if (!ValidarCampos()) return;
            cliente = dgvClientes.SelectedRows[0].DataBoundItem as BE.ClsCliente;
            bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de modificar este cliente?");
            if (resultado)
            {
                if (gCliente.Listar().Any(c => c.DNI == txtDNI.Text))
                {
                    GestorMensajes.Advertencia("Ya existe un cliente con ese DNI.");
                    return;
                }
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.DNI = txtDNI.Text;

                fa = gCliente.Editar(cliente);
                if (fa != 0)
                {
                    GestorMensajes.Exito("Proceso exitoso");
                    VerGrilla();
                    LimpiarCampos();
                }
            }
            else 
            {
            return;
            }
            
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDNI.Text = "";
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {

                tmp = (BE.ClsCliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                txtNombre.Text = tmp.Nombre;
                txtApellido.Text = tmp.Apellido;
                txtTelefono.Text = tmp.Telefono;
                txtDNI.Text = tmp.DNI;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Archivos XML (*.xml)|*.xml"; // Filtra para que solo se vean archivos XML
            saveDialog.Title = "Guardar listado de clientes";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaSegura = saveDialog.FileName;

                    BLL.ClsCliente gestor = new BLL.ClsCliente();
                    gestor.GenerarXML(rutaSegura);

                    MessageBox.Show("Archivo XML generado con éxito en:\n" + rutaSegura, "Éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar el archivo: " + ex.Message, "Error");
                }
            }
        }

        private void FrmABMCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorMensajes.MensajeGenerado -= MostrarMensaje;
        }

        private void FrmABMCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
