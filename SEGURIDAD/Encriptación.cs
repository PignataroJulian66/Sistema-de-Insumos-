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

        // Configuración de Hashing
        private const int SaltSize = 16;         // 16 bytes para el Salt
        private const int HashSize = 32;         // 32 bytes (256 bits) para el Hash
        private const int Iterations = 10000;    // Iteraciones para la resistencia a la fuerza bruta

        public byte[] Encriptar(string password)
        {
            byte[] salt;
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt = new byte[SaltSize]);
            }

            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            byte[] finalHashBytes = new byte[SaltSize + HashSize];

            Array.Copy(salt, 0, finalHashBytes, 0, SaltSize);
            Array.Copy(hash, 0, finalHashBytes, SaltSize, HashSize);

            return finalHashBytes;
        }

        public bool VerifyPassword(string password, byte[] storedHashBytes)
        {
            // 1. Verificar el tamaño del byte array almacenado
            if (storedHashBytes.Length != SaltSize + HashSize)
                return false;

            // 2. Extraer el Salt (primeros 16 bytes)
            byte[] salt = new byte[SaltSize];
            Array.Copy(storedHashBytes, 0, salt, 0, SaltSize);

            // 3. Generar un nuevo Hash con la contraseña ingresada y el Salt recuperado
            byte[] newHash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                newHash = pbkdf2.GetBytes(HashSize);
            }

            // 4. Extraer el Hash original almacenado (los 32 bytes siguientes al Salt)
            byte[] storedPasswordHash = new byte[HashSize];
            Array.Copy(storedHashBytes, SaltSize, storedPasswordHash, 0, HashSize);

            // 5. Comparar los dos hashes byte por byte (comparación de tiempo constante para evitar ataques de temporización)
            return SlowEquals(storedPasswordHash, newHash);
        }

        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        //public byte[] Encriptar(string texto)
        //{
        //    byte[] datos = Encoding.UTF8.GetBytes(texto);
        //    return ProtectedData.Protect(datos, null, DataProtectionScope.CurrentUser);
        //}

        //public string Desencriptar(byte[] cifrado)
        //{
        //    byte[] datos = ProtectedData.Unprotect(cifrado, null, DataProtectionScope.CurrentUser);
        //    return Encoding.UTF8.GetString(datos);
        //}
    }
}
