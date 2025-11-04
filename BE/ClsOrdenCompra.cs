using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsOrdenCompra
    {
		private string _idEmp;

		public string ID_Emp
		{
			get { return _idEmp; }
			set { _idEmp = value; }
		}

		private BE.ClsInsumo _insumo;

		public BE.ClsInsumo Insumo
		{
			get { return _insumo; }
			set { _insumo = value; }
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

    }
}
