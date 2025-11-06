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
    public partial class FrmVerPerfilProveedor : Form
    {
        public FrmVerPerfilProveedor(CLSProveedor proveedor)
        {
            InitializeComponent();
            label1.Text = proveedor.Nombre;
            label2.Text = proveedor.Direccion;
            label3.Text = proveedor.Telefono;
        }
    }
}
