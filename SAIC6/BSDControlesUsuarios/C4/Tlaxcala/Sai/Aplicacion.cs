using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;

namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase que maneja los objetos globales a nivel de la aplicación
    /// </summary>
    public static class Aplicacion
    {
        /// <summary>
        /// Contiene los numero de telefono que estan siendo atendidos actualmente.
        /// </summary>
        public static List<string> LlamadasActuales = new List<string>();

        /// <summary>
        /// Lista de elementos que tienen la referencia hacia los formularios que se van abriendo
        /// <remarks>Cada ventana Incidencia que se levente tiene que incluirse en esta lista</remarks>
        /// </summary>
        public static List<SAIWinSwitchItem> VentanasIncidencias = new List<SAIWinSwitchItem>();

        /// <summary>
        /// Apuntador hacia la instancia actual de SAIFrmComandos
        /// </summary>
        //public static SAIFrmComandos frmComandos;
        /// <summary>
        /// 
        /// </summary>
        public static int? intFolioPorCancelar;

        /// <summary>
        /// 
        /// </summary>
        public static SAIFrmBase frmIncidenciaActiva;

        /// <summary>
        /// Método para la conversion de un número hexadecimal a decimal para los colores
        /// </summary>
        /// <param name="strHex">Codigo hexadecimal a convertir</param>
        /// <returns>Valor decimal correspondiente</returns>
        public static int HexadecimalADecimal(string strHex)
        {
            return Int32.Parse(strHex, System.Globalization.NumberStyles.HexNumber);
        }

        /// <summary>
        /// Método para remover de un listado tipado los elementos duplicados
        /// </summary>
        /// <param name="listaEntrada">Lista del cual serán removidos los duplicados</param>
        /// <returns>Una nueva colección depurada</returns>
        public static List<string> removerDuplicados(List<string> listaEntrada)
        {
            var diccionario = new Dictionary<string, int>();
            var listaFinal = new List<string>();

            foreach (var valorActual in listaEntrada)
            {
                if (diccionario.ContainsKey(valorActual)) continue;

                diccionario.Add(valorActual, 0);
                listaFinal.Add(valorActual);
            }
            return listaFinal;
        }

        /// <summary>
        /// Clase donde persisten los permisos y configuraciones del usuario actual
        /// </summary>
        public static class UsuarioPersistencia
        {
            #region Campos

            ///<summary>
            ///</summary>
            public static int intClaveUsuario { get; set; }

            ///<summary>
            ///</summary>
            public static string strNombreUsuario { get; set; }

            ///<summary>
            ///</summary>
            public static string[] strSistemas { get; set; }

            ///<summary>
            ///</summary>
            public static string strSistemaActual { get; set; }

            ///<summary>
            ///</summary>
            public static bool? blnEsDespachador { get; set; }

            ///<summary>
            ///</summary>
            public static int? intClaveSistema { get; set; }

            ///<summary>
            ///</summary>
            public static int? intCorporacion
            {
                get
                {
                    //Comprobamos que sea un despachador para poder determinar su corporación
                    if (blnEsDespachador == true)
                    {
                        //Obtenemos una instancia de la entidad usuario por corporación
                        var usuarioCorporacion =
                            UsuarioCorporacionMapper.Instance().GetByUsuario(intClaveUsuario);
                        if (usuarioCorporacion != null && usuarioCorporacion.Count > 0)
                        {
                            //Retornamos la clave obtenida
                            return usuarioCorporacion[0].ClaveCorporacion;
                        }
                    }

                    return null;
                }
            }

            #endregion

            /// <summary>
            /// Función que determina si el usuario actual tiene permisos de LECTURA sobre el modulo specificado
            /// </summary>
            /// <param name="intSubModulo">Módulo sobre el cual se consultan los permisos</param>
            /// <returns>verdadero o falso</returns>
            public static bool blnPuedeLeer(int intSubModulo)
            {
                //Obtenemos una lista de permisos para el módulo definido del sistema en el cual fue logeado
                var permisoObjectList =
                    PermisoMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_OBTENERPERMISOS, intClaveUsuario,
                                                                         intSubModulo, ObtenerClaveSistema()));
                foreach (var o in permisoObjectList)
                {
                    if (o.Valor.Equals(2))
                        return true;
                }

                return false;
            }

            /// <summary>
            /// Función que determina si el usuario actual tiene permisos de ESCRIBIR sobre el modulo specificado
            /// </summary>
            /// <param name="intSubModulo">Módulo sobre el cual se consultan los permisos</param>
            /// <returns>verdadero o falso</returns>
            public static bool blnPuedeEscribir(int intSubModulo)
            {
                //Obtenemos una lista de permisos para el módulo definido del sistema en el cual fue logeado
                var permisoObjectList =
                    PermisoMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_OBTENERPERMISOS, intClaveUsuario,
                                                                         intSubModulo, ObtenerClaveSistema()));
                foreach (var o in permisoObjectList)
                {
                    if (o.Valor.Equals(4))
                        return true;
                }

                return false;
            }

            ///<summary>
            ///</summary>
            ///<param name="intSubModulo"></param>
            ///<returns></returns>
            public static bool blnPuedeLeeryEscribir(int intSubModulo)
            {
                return blnPuedeLeer(intSubModulo) && blnPuedeEscribir(intSubModulo);
            }

            ///<summary>
            ///</summary>
            ///<param name="intSubModulo"></param>
            ///<returns></returns>
            public static bool blnPuedeLeeroEscribir(int intSubModulo)
            {
                return blnPuedeLeer(intSubModulo) || blnPuedeEscribir(intSubModulo);
            }

            internal static string ObtenerClaveSistema()
            {
                switch (strSistemaActual)
                {
                    case "066":
                        intClaveSistema = 2;
                        break;
                    case "089":
                        intClaveSistema = 1;
                        break;
                        //default:
                        //    intClaveSistema = null;
                        //    break;
                }
                return intClaveSistema.ToString();
            }
        }

        /// <summary>
        /// Clase que implementa métodos de cifrado del tipo MD5
        /// </summary>
        public class CzSecurity
        {
            #region CONSTRUCTOR

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
                StringBuilder sBuilder = new StringBuilder();

                // Se recorre cada byte del hash obtenido y se le da
                // formato como cadena hexadecimal
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Retorna la cadena en formato hexadecimal concatenada en el stringbuilder
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
                StringBuilder sBuilder = new StringBuilder();

                // Se recorre cada byte del hash obtenido y se le da
                // formato como cadena hexadecimal
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Retorna la cadena en formato hexadecimal concatenada en el stringbuilder
                return sBuilder.ToString();
            }

            #endregion
        }
    }

    ///<summary>
    ///</summary>
    public enum ESTATUSINCIDENCIAS
    {
        ///<summary>
        ///</summary>
        NUEVA = 1,
        ///<summary>
        ///</summary>
        PENDIENTE = 2,
        ///<summary>
        ///</summary>
        ACTIVA = 3,
        ///<summary>
        ///</summary>
        CERRADA = 4,
        ///<summary>
        ///</summary>
        CANCELADA = 5
    }

    ///<summary>
    ///</summary>
    public enum ESTATUSUNIDADES
    {
        ///<summary>
        ///</summary>
        LIBRE = 1, //Unidad que puede ser asignada a una incidencia (VERDE)
        ///<summary>
        ///</summary>
        DESPACHADA = 2, //Unidad que va en camino a atender la incidencia (ROJO)
        ///<summary>
        ///</summary>
        LLEGADA = 3 //Unidad que se encuentra ya en el lugar de la incidencia 
    }
}