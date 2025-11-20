using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClsProductos : IComponenteInventario
    {

		private int _Id_Producto;

		public int Id
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

        private List<IComponenteInventario> _Componentes;

        public List<IComponenteInventario> Componentes
        {
            get { return _Componentes; }
            set { _Componentes = value; }
        }


        public ClsProductos()
        {
            _Componentes = new List<IComponenteInventario>();
        }

        public void AgregarComponente(IComponenteInventario componente)
        {
            _Componentes.Add(componente);
        }

        public void EliminarComponente(IComponenteInventario componente)
        {
            _Componentes.Remove(componente);
        }


      
        public decimal ObtenerPrecio()
        {
            
            decimal precioTotalComponentes = _Componentes.Sum(c => c.ObtenerPrecio());
            return this.Precio + precioTotalComponentes;
        }

        public int CalcularExistencias()
        {
          

            if (!_Componentes.Any())
            {
                return this.Existencias;
            }

            
            int minComponenteStock = _Componentes.Min(c => c.CalcularExistencias());

            
            return Math.Min(this.Existencias, minComponenteStock);
        }

        public string MostrarDetalles(int nivel)
        {
            StringBuilder sb = new StringBuilder();
            string indent = new string(' ', nivel * 4);

            sb.AppendLine($"{indent} Producto Compuesto: {Nombre} (Precio Final: {ObtenerPrecio():C})");
            sb.AppendLine($"{indent}  Componentes:");

            foreach (var componente in _Componentes)
            {
               
                sb.AppendLine(componente.MostrarDetalles(nivel + 1));
            }

            return sb.ToString();
        }
    }
   
    
}
