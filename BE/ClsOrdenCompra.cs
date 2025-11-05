using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsOrdenCompra
    {
		private int _id;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _idEmp;

		public string ID_Emp
		{
			get { return _idEmp; }
			set { _idEmp = value; }
		}

		private string _ninsumo;

		public string NInsumo
		{
			get { return _ninsumo; }
			set { _ninsumo = value; }
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



		private DateTime _fechaEntrega;

		public DateTime FechaEntrega
		{
			get { return _fechaEntrega; }
			set { _fechaEntrega = value; }
		}

		private bool _finalizado;

		public bool Finalizado
		{
			get { return _finalizado; }
			set { _finalizado = value; }
		}
        private string _idprov;

        public string ID_prov
        {
            get { return _idprov; }
            set { _idprov = value; }
        }

		private decimal _cotizacion;

		public decimal Cotizacion
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}


	}
}
