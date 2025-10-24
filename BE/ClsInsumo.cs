using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsInsumo
    {
		private int _id;

		public int ID
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

		private int _cantidad;

		public int Cantidad
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

		private string _proporcion;

		public string Proporcion
		{
			get { return _proporcion; }
			set { _proporcion = value; }
		}

		private decimal _precioactual;

		public decimal PrecioActual
		{
			get { return _precioactual; }
			set { _precioactual = value; }
		}

	}
}
