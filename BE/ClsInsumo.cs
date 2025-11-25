using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsInsumo : IComponenteInventario, ICloneable
    {
		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _nombre;

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		private string _unidad;

		public string Unidad
		{
			get { return _unidad; }
			set { _unidad = value; }
		}

		private decimal _cantidad;

		public decimal Cantidad
		{
			get { return _cantidad; }
			set { _cantidad = value; }
		}

		private string _calidad;

		public string Calidad
		{
			get { return _calidad; }
			set { _calidad = value; }
		}

        public decimal PrecioUnitario { get; set; }
        public int StockActual { get; set; }


        public override string ToString()
        {
            return Nombre;
        }

        public decimal ObtenerPrecio()
        {
            return PrecioUnitario;
        }

        public int CalcularExistencias()
        {
            return StockActual;
        }

        public string MostrarDetalles(int nivel)
        {
            return new string('-', nivel * 2) + $" Insumo: {Nombre} ({Unidad}), Precio Unitario: {PrecioUnitario:C}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
