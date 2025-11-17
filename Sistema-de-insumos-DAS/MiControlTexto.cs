using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace Sistema_de_insumos_DAS
{
    public partial class MiControlTexto : UserControl
    {
        public MiControlTexto()
        {
            InitializeComponent();
        }

        public string Texto
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public event EventHandler TextChanged1
        {
            add { textBox1.TextChanged += value; }
            remove { textBox1.TextChanged -= value; }
        }

        protected void SetearColor(Color unColor)
        {
            textBox1.ForeColor = unColor;
        }

        public virtual bool Validar()
        {
            bool ok = true;
            if (string.IsNullOrWhiteSpace(this.textBox1.Text) || textBox1.Text.Any(char.IsDigit) || textBox1.Text == string.Empty)
            {
                ok = false;
                SetearColor(Color.Red);
                textBox1.openTooltip("El nombre no debe estar vacio, contener espacios o contener números.");

            }
            else
            {
                SetearColor(Color.Black);
            }
            return ok;
        }
    }
}
