using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsDetalleProducto
    {
        private int _idInsumo;

        public int IDinsumo
        {
            get { return _idInsumo; }
            set { _idInsumo = value; }
        }

        private string _insumo;

        public string Insumo
        {
            get { return _insumo; }
            set { _insumo = value; }
        }

        private decimal _cantidad;

        public decimal Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private string _unidad;

        public string Unidad
        {
            get { return _unidad; }
            set { _unidad = value; }
        }

        public override string ToString()
        {
            return $"{Insumo}: {Cantidad} {Unidad}";
        }
    }
}
