using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sistema_de_insumos_DAS
{
    public partial class FrmRegistrosBitacora : Form
    {
        BLL.GestorBitacora gestor = BLL.GestorBitacora.Instancia;
        public FrmRegistrosBitacora()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestor.listar();
        }

        private void FrmRegistrosBitacora_Load(object sender, EventArgs e)
        {
            DataTable datosCriticidad = gestor.Graficar();

            if (datosCriticidad == null || datosCriticidad.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el gráfico.");
                return;
            }

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends[0].Enabled = true;

            Series pieSeries = new Series
            {
                Name = "DistribucionCriticidad",
                ChartType = SeriesChartType.Pie,

                Label = string.Empty,

                IsValueShownAsLabel = false
            };

            foreach (DataRow row in datosCriticidad.Rows)
            {
                try
                {
                    string criticidad = row["Criticidad"].ToString();
                    int cantidad = Convert.ToInt32(row["Cantidad"]);

                    pieSeries.Points.AddXY(criticidad, cantidad);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar la fila: {ex.Message}");
                }
            }
            pieSeries.YValueMembers = "Cantidad";

            pieSeries.XValueMember = "Criticidad";

            pieSeries.LegendText = string.Empty;

            chart1.Series.Add(pieSeries);
            chart1.DataBind();

            chart1.Titles.Add("Distribución de registros por criticidad");
        }
    }
}
