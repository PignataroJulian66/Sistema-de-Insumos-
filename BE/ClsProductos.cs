using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsProductos
    {

		private int _Id_Producto;

		public int Id_Producto
		{
			get { return _Id_Producto; }
			set { _Id_Producto = value; }
		}

		private string _Nombre;

		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Rubro;

		public string Rubro
		{
			get { return _Rubro; }
			set { _Rubro = value; }
		}

		private decimal _Precio;

		public decimal Precio
		{
			get { return _Precio; }
			set { _Precio = value; }
		}

		private int _Existencias;

		public int Existencias
		{
			get { return _Existencias; }
			set { _Existencias = value; }
		}

		private List<BE.ClsInsumo> _ListaInsumos;

		public List<BE.ClsInsumo> ListaInsumos
		{
			get { return _ListaInsumos; }
			set { _ListaInsumos = value; }
		}


		public ClsProductos()
        {
            
        }





    }
}
