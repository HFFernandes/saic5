using System;
using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai
{
    /// <summary>
    /// Clase que maneja los objetos globales a nivel de la aplicación
    /// </summary>
    public static class Aplicacion
    {
        /// <summary>
        /// Lista de elementos que tienen la referencia hacia los formularios que se van abriendo
        /// <remarks>Cada ventana Incidencia que se levente tiene que incluirse en esta lista</remarks>
        /// </summary>
        public static List<SAIWinSwitchItem> VentanasIncidencias = new List<SAIWinSwitchItem>();

        /// <summary>
        /// Método para la conversion de hexadecimal a decimal para los colores
        /// </summary>
        /// <param name="strHex">Codigo hexadecimal a convertir</param>
        /// <returns>Valor decimal correspondiente</returns>
        public static int HexadecimalADecimal(string strHex)
        {
            var ColorHex = strHex.ToCharArray();
            var ColorDecimal = 0;
            var iLength = ColorHex.Length - 1;
            int NumeroDecimal;

            foreach (var ValorHex in ColorHex)
            {
                if (char.IsNumber(ValorHex))
                {
                    NumeroDecimal = int.Parse(ValorHex.ToString());
                }
                else
                {
                    NumeroDecimal = Convert.ToInt32(ValorHex) - 55;
                }

                ColorDecimal += NumeroDecimal * (Convert.ToInt32(Math.Pow(16, iLength)));
                iLength--;
            }

            return ColorDecimal;
        }

        /// <summary>
        /// Clase donde persisten los permisos y configuraciones de un usuario especifico
        /// </summary>
        public static class UsuarioPersistencia
        {
            public static int intClaveUsuario { get; set; }
            public static string strNombreUsuario { get; set; }
            public static string[] strSistemas { get; set; }
            public static string strSistemaActual { get; set; }
            public static bool? blnEsDespachador { get; set; }

            /// <summary>
            /// Función que determina si el usuario actual tiene permisos de LECTURA sobre el modulo specificado
            /// </summary>
            /// <param name="intSubModulo">Módulo sobre el cual se consultan los permisos</param>
            /// <returns>verdadero o falso</returns>
            public static bool blnPuedeLeer(int intSubModulo)
            {
                var permisoObjectList = PermisoMapper.Instance().GetBySQLQuery(string.Format(SQL_OBTENERPERMISOS, intClaveUsuario, intSubModulo));
                foreach (var o in permisoObjectList)
                {
                    if (o.Valor == 2)
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
                var permisoObjectList = PermisoMapper.Instance().GetBySQLQuery(string.Format(SQL_OBTENERPERMISOS, intClaveUsuario, intSubModulo));
                foreach (var o in permisoObjectList)
                {
                    if (o.Valor == 4)
                        return true;
                }

                return false;
            }

            public static bool blnPuedeLeeryEscribir(int intSubModulo)
            {
                return blnPuedeLeer(intSubModulo) && blnPuedeEscribir(intSubModulo);
            }

            public static bool blnPuedeLeeroEscribir(int intSubModulo)
            {
                return blnPuedeLeer(intSubModulo) || blnPuedeEscribir(intSubModulo);
            }

            private const string SQL_OBTENERPERMISOS =
                "SELECT Permiso.* FROM PermisoUsuario INNER JOIN Permiso ON PermisoUsuario.ClavePermiso = Permiso.Clave WHERE (PermisoUsuario.ClaveUsuario = {0}) AND (PermisoUsuario.ClaveSubmodulo = {1})";
        }
    }
}
