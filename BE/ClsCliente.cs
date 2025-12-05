using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsCliente : CLSPersona
    {
		private int _id;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _apellido;

		public string Apellido
		{
			get { return _apellido; }
			set { _apellido = value; }
		}

		private string _dni;

		public string DNI
		{
			get { return _dni; }
			set { _dni = value; }
		}
        public ClsCliente(int id, string a, string dni,string n, string t) : base(n,t)
        {
            ID = id;
			Apellido = a;
			DNI = dni;
        }

        public ClsCliente() : base()
        {
            
        }
    }
}
