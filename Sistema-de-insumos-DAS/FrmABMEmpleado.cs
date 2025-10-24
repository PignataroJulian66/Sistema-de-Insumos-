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
    public partial class FrmABMEmpleado : Form
    {
        public FrmABMEmpleado()
        {
            InitializeComponent();
            VerGrilla();
        }
        BE.CLSEmpleado empleado; 
        BLL.ClsEmpleado gEmpleado = new BLL.ClsEmpleado(); 
        BE.CLSEmpleado tmp;

        private void VerGrilla()
        {
            dgvEmpleados.DataSource = null; 
            dgvEmpleados.DataSource = gEmpleado.Listar(); 
        }
        private void btnAlta_Click(object sender, EventArgs e)
        {
            int fa = 0;
            empleado = new BE.CLSEmpleado();

            
            empleado.ID_emp = int.Parse(txtID.Text);
            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Telefono = txtTelefono.Text;
            empleado.Direccion = txtDireccion.Text;
            empleado.Rol = txtRol.Text; 
            empleado.DNI = txtDNI.Text;

            fa = gEmpleado.Agregar(empleado);
            if (fa != 0)
            {
                MessageBox.Show("Empleado agregado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el empleado.");
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            int fa = 0;
            empleado = new BE.CLSEmpleado();

           
            empleado.ID_emp = int.Parse(txtID.Text);

            fa = gEmpleado.Eliminar(empleado);
            if (fa != 0)
            {
                MessageBox.Show("Empleado eliminado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el empleado.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            empleado = new BE.CLSEmpleado();

          
            empleado.ID_emp = int.Parse(txtID.Text);
            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Telefono = txtTelefono.Text;
            empleado.Direccion = txtDireccion.Text;
            empleado.Rol = txtRol.Text; // O podrías usar un ComboBox: cmbRol.Text
            empleado.DNI = txtDNI.Text;

            fa = gEmpleado.Editar(empleado);
            if (fa != 0)
            {
                MessageBox.Show("Empleado editado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo editar el empleado.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
              
                tmp = (BE.CLSEmpleado)dgvEmpleados.Rows[e.RowIndex].DataBoundItem;

                txtID.Text = tmp.ID_emp.ToString();
                txtNombre.Text = tmp.Nombre;
                txtApellido.Text = tmp.Apellido;
                txtTelefono.Text = tmp.Telefono;
                txtDireccion.Text = tmp.Direccion;
                txtRol.Text = tmp.Rol;
                txtDNI.Text = tmp.DNI;
            }
        }
        private void LimpiarCampos()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtRol.Text = "";
            txtDNI.Text = "";
        }
    }
}
