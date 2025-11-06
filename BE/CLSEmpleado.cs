using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CLSEmpleado : CLSPersona
    {
        private int id_emp;

        public int ID_emp
        {
            get { return id_emp; }
            set { id_emp = value; }
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

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _rol;

        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        private string _dni;

        public string DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }


        public CLSEmpleado()
        {
            
        }
        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
