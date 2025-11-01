using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mensajes1
{
    public static class GestorConfirmaciones
    {
        public static bool Confirmar(string mensaje, string titulo = "Confirmación")
        {
            DialogResult resultado = MessageBox.Show(mensaje,titulo,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            return resultado == DialogResult.Yes;
        }
    }
}
