using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SEGURIDAD
{
    public class Encriptación
    {
        private static Encriptación _instancia = null;
        public static Encriptación Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Encriptación();
                }
                return _instancia;
            }
        }
        public byte[] Encriptar(string texto)
        {
            byte[] datos = Encoding.UTF8.GetBytes(texto);
            return ProtectedData.Protect(datos, null, DataProtectionScope.CurrentUser);
        }
            
        public string Desencriptar(byte[] cifrado)
        {
            byte[] datos = ProtectedData.Unprotect(cifrado, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(datos);
        }
    }
}
