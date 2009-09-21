using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BSD.C4.Tlaxcala.Sai.Administracion.Utilerias
{
    internal class CzSecurity
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor
        /// </summary>
        public CzSecurity()
        {
        }

        #endregion

        #region MIEMBROS

        private string _UserName;
        private string _Password;

        #endregion

        #region PROPIEDADES

        /// <summary>
        ///Set,string, Usuario del empleado
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
        }

        /// <summary>
        ///Set, string, Contraseña del usuario
        /// </summary>
        public string Password
        {
            set { _Password = value; }
        }

        /// <summary>
        /// get,string, Contraseña cifrada
        /// </summary>
        public string PassWordCifrado()
        {
            // Creamos una nueva instancia del objeto MD5CryptoServiceProvider 
            MD5 md5Hasher = MD5.Create();

            // Cobertimos el password en un arreglo de bytes
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(_Password));

            // Creamos un Stringbuilder 
            //y.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Cifra una cadena a MD5
        /// </summary>
        /// <param name="password">Cadena a cifrar</param>
        /// <returns></returns>
        public string PassWordCifrado(string password)
        {
            // Creamos una nueva instancia del objeto MD5CryptoServiceProvider 
            MD5 md5Hasher = MD5.Create();

            // Cobertimos el password en un arreglo de bytes
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password));

            // Creamos un Stringbuilder 
            //y.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        #endregion
    }
}