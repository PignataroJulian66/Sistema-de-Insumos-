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
    public partial class FrmABMCliente : Form
    {
        public FrmABMCliente()
        {
            InitializeComponent();
            VerGrilla();
        }

        BE.ClsCliente cliente; 
        BLL.ClsCliente gCliente = new BLL.ClsCliente(); 
        BE.ClsCliente tmp; 
        private void VerGrilla()
        {
            dgvClientes.DataSource = null; 
            dgvClientes.DataSource = gCliente.Listar(); 
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            int fa = 0;
            cliente = new BE.ClsCliente();

           
            cliente.ID = int.Parse(txtID.Text); 
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.DNI = txtDNI.Text;

            fa = gCliente.Agregar(cliente);
            if (fa != 0)
            {
                MessageBox.Show("Cliente agregado con éxito.");
                VerGrilla();
                LimpiarCampos(); // Método opcional para limpiar TextBoxes
            }
            else
            {
                MessageBox.Show("No se pudo agregar el cliente.");
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            int fa = 0;
            cliente = new BE.ClsCliente();

           
            cliente.ID = int.Parse(txtID.Text);

            fa = gCliente.Eliminar(cliente);
            if (fa != 0)
            {
                MessageBox.Show("Cliente eliminado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el cliente.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            cliente = new BE.ClsCliente();

         
            cliente.ID = int.Parse(txtID.Text);
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.DNI = txtDNI.Text;

            fa = gCliente.Editar(cliente);
            if (fa != 0)
            {
                MessageBox.Show("Cliente editado con éxito.");
                VerGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se pudo editar el cliente.");
            }
        }

        private void LimpiarCampos()
        {
            txtID.Text = "";
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

               
                txtID.Text = tmp.ID.ToString();
                txtNombre.Text = tmp.Nombre;
                txtApellido.Text = tmp.Apellido;
                txtTelefono.Text = tmp.Telefono;
                txtDNI.Text = tmp.DNI;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"";

            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Clientes", cn);
            da.Fill(dataSet, "Clientes");
            cn.Close();
            dataSet.WriteXml("aca copiar la ruta de acceso del directorio");
        }
    }
}
