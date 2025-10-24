using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsCliente
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

		private string _apellido;

		public string Apellido
		{
			get { return _apellido; }
			set { _apellido = value; }
		}

		private string _telefono;

		public string Telefono
		{
			get { return _telefono; }
			set { _telefono = value; }
		}

		private string _dni;

		public string DNI
		{
			get { return _dni; }
			set { _dni = value; }
		}

	}
}
