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
            VerGrilla();
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

            
            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Telefono = txtTelefono.Text;
            empleado.Direccion = txtDireccion.Text;
            empleado.Rol = (comboBox1.SelectedIndex+1).ToString(); 
            empleado.DNI = txtDNI.Text;

            fa = gEmpleado.Agregar(empleado, txtEmail.Text);
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
            empleado = dgvEmpleados.SelectedRows[0].DataBoundItem as BE.CLSEmpleado;

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
            empleado = dgvEmpleados.SelectedRows[0].DataBoundItem as BE.CLSEmpleado;

            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Telefono = txtTelefono.Text;
            empleado.Direccion = txtDireccion.Text;
            empleado.Rol = (comboBox1.SelectedIndex + 1).ToString();
            empleado.DNI = txtDNI.Text;

            fa = gEmpleado.Editar(empleado, txtEmail.Text);
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
            /*// 1. Creamos el diálogo para "Guardar como..."
            SaveFileDialog saveDialog = new SaveFileDialog();

            // 2. Configuramos el diálogo
            saveDialog.Filter = "Archivos XML (*.xml)|*.xml"; // Filtra para que solo se vean archivos XML
            saveDialog.Title = "Guardar Listado de Vehículos";
            saveDialog.FileName = "Vehiculos.xml"; // Le damos un nombre por defecto

            // 3. Mostramos la ventana. Si el usuario presiona "Guardar"...
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 4. Obtenemos la ruta segura que el usuario eligió
                    string rutaSegura = saveDialog.FileName;

                    // --- Tu lógica original va aquí ---
                    DataSet DS = new DataSet();
                    SqlConnection CN = new SqlConnection(@"Data Source=JULIÁN;Initial Catalog=Ejercicio2_das;Integrated Security=True");
                    SqlDataAdapter DA = new SqlDataAdapter("Select * from Vehiculos", CN);
                    DA.Fill(DS, "Vehiculos");
                    CN.Close();

                    // 5. Guardamos el archivo en la ruta segura
                    DS.WriteXml(rutaSegura);

                    MessageBox.Show("Archivo Vehiculos.xml generado con éxito en:\n" + rutaSegura, "Éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar el archivo: " + ex.Message, "Error");
                }
            }*/
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
        }

        private void FrmABMEmpleado_Load(object sender, EventArgs e)
        {
        }
    }
}
