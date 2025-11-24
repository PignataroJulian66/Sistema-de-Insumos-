using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class GestorBitacora
    {
        private static GestorBitacora _instancia;
        private readonly mp_Bitacora _mapper;

        private GestorBitacora()
        {
            _mapper = new mp_Bitacora(); 
        }

       
        public static GestorBitacora Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new GestorBitacora();
                }
                return _instancia;
            }
        }

        public void RegistrarEvento(string usuario, string criticidad, string mensaje, string tipoEvento)
        {
            var registro = new ClsRegistroBitacora
            {
                Fecha = DateTime.Now,
                Usuario = usuario,
                Criticidad = criticidad,
                Mensaje = mensaje,
                TipoEvento = tipoEvento
            };

            _mapper.Guardar(registro);
        }

        public List<BE.ClsRegistroBitacora> listar()
        {
            List<BE.ClsRegistroBitacora> lista = _mapper.Listar();
            return lista; ;
        }
    }
}
