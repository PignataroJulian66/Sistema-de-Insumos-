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
    public partial class MiControlEmail : UserControl
    {
        public MiControlEmail()
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
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ok = false;
                SetearColor(Color.Red);
                textBox1.openTooltip("El email ingresado no tiene un formato válido.");

            }
            else
            {
                SetearColor(Color.Black);
            }
            return ok;
        }
    }
}
