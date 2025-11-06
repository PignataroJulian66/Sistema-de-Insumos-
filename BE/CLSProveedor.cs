using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CLSProveedor : CLSPersona
    {
		private int id_prov;

		public int ID_prov
		{
			get { return id_prov; }
			set { id_prov = value; }
		}

		private string _nombre;

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		private string _cuit;

		public string Cuit
		{
			get { return _cuit; }
			set { _cuit = value; }
		}


		private string _telefono;

		public string Telefono
		{
			get { return _telefono; }
			set { _telefono = value; }
		}


		private string _direccion;

		public string Direccion
		{
			get { return _direccion; }
			set { _direccion = value; }
		}
        public CLSProveedor()
        {
            	
        }
        public override string ToString()
        {
			return Nombre;
        }
	}
}
