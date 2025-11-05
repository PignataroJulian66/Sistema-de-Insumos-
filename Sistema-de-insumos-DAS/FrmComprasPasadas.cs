using BE;
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
    public partial class FrmComprasPasadas : Form
    {
        BLL.ClsOrdenCompra gorden = new BLL.ClsOrdenCompra();
        List<ClsOrdenCompra> lst = null;
        public FrmComprasPasadas(CLSEmpleado emp)
        {
            InitializeComponent();
            lst = gorden.Listar2(emp);
            var lstFiltrada = lst.Where(oc => oc.Finalizado == true).ToList();
            dgvOC.DataSource = lstFiltrada;
            dgvOC.ReadOnly = true;
            dgvOC.MultiSelect = false;
            dgvOC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
