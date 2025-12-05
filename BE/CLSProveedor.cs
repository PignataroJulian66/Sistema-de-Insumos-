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

		private string _cuit;

		public string Cuit
		{
			get { return _cuit; }
			set { _cuit = value; }
		}

		private string _direccion;

		public string Direccion
		{
			get { return _direccion; }
			set { _direccion = value; }
		}
        public CLSProveedor() : base() 
        {
            	
        }

        public CLSProveedor(int id, string c, string d, string n, string t) : base(n, t)
        {
            ID_prov = id;
			Cuit = c;
			Direccion = d;
        }
        public override string ToString()
        {
			return Nombre;
        }
	}
}
