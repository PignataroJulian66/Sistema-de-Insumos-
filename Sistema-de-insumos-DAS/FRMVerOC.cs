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
    public partial class FRMVerOC : Form
    {
        BE.ClsOrdenCompra orden = new BE.ClsOrdenCompra();
        BLL.ClsOrdenCompra gorden = new BLL.ClsOrdenCompra();
        public FRMVerOC()
        {
            InitializeComponent();
            dataGridView1.DataSource = gorden.Listar();
        }
    }
}
