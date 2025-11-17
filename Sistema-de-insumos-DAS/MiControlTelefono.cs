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
    public partial class MiControlTelefono : UserControl
    {
        public MiControlTelefono()
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
            if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^[0-9+\- ]+$"))
            {
                ok = false;
                SetearColor(Color.Red);
                textBox1.openTooltip("El teléfono solo debe contener números y signos válidos (+, -).");

            }
            else
            {
                SetearColor(Color.Black);
            }
            return ok;
        }
    }
}
