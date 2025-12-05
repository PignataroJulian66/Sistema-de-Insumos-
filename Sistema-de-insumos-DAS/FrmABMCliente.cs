using BLL;
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
    public partial class FrmABMCliente : Form
    {
        public FrmABMCliente()
        {
            InitializeComponent();
            GestorMensajes.MensajeGenerado += MostrarMensaje;
            VerGrilla();
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

        BLL.ClsCliente gCliente = new BLL.ClsCliente(); 
        private void VerGrilla()
        {

            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = gCliente.Listar();
                dgvClientes.Columns["ID_Cliente"].ReadOnly = true;
                dgvClientes.AllowUserToDeleteRows = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                int filasAfectadas = gCliente.GuardarDatosClientes();
                MessageBox.Show($"Cambios guardados exitosamente. Filas afectadas: {filasAfectadas}");
                VerGrilla();
                GestorBitacora.Instancia.RegistrarEvento("Sistema", "INFO", "Se ejecuto correctamente SqlCommandBuilder", "CLIENTE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
                GestorBitacora.Instancia.RegistrarEvento("Sistema", "INFO", "Se ejecuto incorrectamente SqlCommandBuilder", "CLIENTE");
            }
        }
    }
}
