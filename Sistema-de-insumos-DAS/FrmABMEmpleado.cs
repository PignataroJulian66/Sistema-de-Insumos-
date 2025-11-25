using Mensajes1;
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

namespace Sistema_de_insumos_DAS
{
    public partial class FrmABMEmpleado : Form
    {
        public FrmABMEmpleado()
        {
            InitializeComponent();
            gEmpleado.EmpleadoChanged -= Empleado_Cambio;
            gEmpleado.EmpleadoChanged += Empleado_Cambio;
            GestorMensajes.MensajeGenerado -= MostrarMensaje;
            GestorMensajes.MensajeGenerado += MostrarMensaje;
            VerGrilla();
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Empleado_Cambio(object sender, EventArgs e)
        {
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

        BE.CLSEmpleado empleado; 
        BLL.ClsEmpleado gEmpleado = new BLL.ClsEmpleado(); 
        BE.CLSEmpleado tmp;

        private void VerGrilla()
        {
            dgvEmpleados.DataSource = null; 
            dgvEmpleados.DataSource = gEmpleado.Listar(); 
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||string.IsNullOrWhiteSpace(txtApellido.Text) ||string.IsNullOrWhiteSpace(txtDireccion.Text) ||string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                GestorMensajes.Advertencia("Todos los campos obligatorios deben estar completos.");
                return false;
            }

            if (txtNombre.Text.Any(char.IsDigit) || txtApellido.Text.Any(char.IsDigit))
            {
                GestorMensajes.Advertencia("El nombre y el apellido no deben contener números.");
                return false;
            }

            if (!long.TryParse(txtDNI.Text, out _) || txtDNI.Text.Length < 7 || txtDNI.Text.Length > 8)
            {
                GestorMensajes.Advertencia("El DNI debe ser numérico y tener entre 7 y 8 dígitos.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^[0-9+\- ]+$"))
            {
                GestorMensajes.Advertencia("El teléfono solo debe contener números y signos válidos (+, -).");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                GestorMensajes.Advertencia("El email ingresado no tiene un formato válido.");
                return false;
            }

            if (comboBox1.SelectedIndex < 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar un rol.");
                return false;
            }
            return true;
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            if (gEmpleado.Listar().Any(c => c.DNI == txtDNI.Text))
            {
                GestorMensajes.Advertencia("Ya existe un empleado con ese DNI.");
                return;
            }

            int fa = 0;
            empleado = new BE.CLSEmpleado();

            
            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Telefono = txtTelefono.Text;
            empleado.Direccion = txtDireccion.Text;
            empleado.Rol = (comboBox1.SelectedIndex+1).ToString(); 
            empleado.DNI = txtDNI.Text;

            fa = gEmpleado.Agregar(empleado, txtEmail.Text);
            if (fa != 0)
            {
                VerGrilla();
                LimpiarCampos();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Debe seleccionar un empleado para eliminar.");
                return;
            }

            int fa = 0;
            empleado = new BE.CLSEmpleado();
            empleado = dgvEmpleados.SelectedRows[0].DataBoundItem as BE.CLSEmpleado;
            bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de quiere eliminar este empleado?");
            if (resultado)
            {
                fa = gEmpleado.Eliminar(empleado);
                if (fa != 0)
                {
                    VerGrilla();
                    LimpiarCampos();
                }
            }
            else 
            {
                return;
            
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            empleado = new BE.CLSEmpleado();
            if (!ValidarCampos())
            return;
            empleado = dgvEmpleados.SelectedRows[0].DataBoundItem as BE.CLSEmpleado;
            //if (gEmpleado.Listar().Any(c => c.DNI == txtDNI.Text))
            //{
            //    GestorMensajes.Advertencia("Ya existe un empleado con ese DNI.");
            //    return;
            //}

            bool resultado = GestorConfirmaciones.Confirmar("¿Estas seguro de modificar este empleado?");
            if (resultado)
            {
                empleado.Nombre = txtNombre.Text;
                empleado.Apellido = txtApellido.Text;
                empleado.Telefono = txtTelefono.Text;
                empleado.Direccion = txtDireccion.Text;
                empleado.Rol = (comboBox1.SelectedIndex + 1).ToString();
                empleado.DNI = txtDNI.Text;

                fa = gEmpleado.Editar(empleado, txtEmail.Text);
                if (fa != 0)
                {
                    
                    VerGrilla();
                    LimpiarCampos();
                }
            }
            else 
            {
            return;
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Archivos XML (*.xml)|*.xml"; // Filtra para que solo se vean archivos XML
            saveDialog.Title = "Guardar Listado de empleados";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaSegura = saveDialog.FileName;

                    BLL.ClsEmpleado gestor = new BLL.ClsEmpleado();
                    gestor.GenerarXML(rutaSegura);

                    MessageBox.Show("Archivo XML generado con éxito en:\n" + rutaSegura, "Éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar el archivo: " + ex.Message, "Error");
                }
            }
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
              
                tmp = (BE.CLSEmpleado)dgvEmpleados.Rows[e.RowIndex].DataBoundItem;

                txtNombre.Text = tmp.Nombre;
                txtApellido.Text = tmp.Apellido;
                txtTelefono.Text = tmp.Telefono;
                txtDireccion.Text = tmp.Direccion;
                comboBox1.Text = tmp.Rol;
                txtDNI.Text = tmp.DNI;
                txtEmail.Text = gEmpleado.ObtenerMail(tmp);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            comboBox1.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
        }

        private void FrmABMEmpleado_Load(object sender, EventArgs e)
        {
        }
    }
}
