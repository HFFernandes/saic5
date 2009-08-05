using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;
using System.Threading;

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
        public static List<SAIWinSwitchItem> Elementos = new List<SAIWinSwitchItem>();

        /// <summary>
        /// Clase donde persisten los permisos y configuraciones de un usuario especifico
        /// </summary>
        public static class UsuarioPersistencia
        {
            public static int intClaveUsuario { get; set; }
            public static string strNombreUsuario { get; set; }
            public static string[] strSistemas { get; set; }
            public static bool blnPuedeLeer
            {
                get
                {
                    return Thread.CurrentPrincipal.IsInRole("Lectura");
                }
            }

            public static bool blnPuedeEscribir
            {
                get
                {
                    return Thread.CurrentPrincipal.IsInRole("Escritura");
                }
            }

            public static bool blnPuedeLeeryEscribir
            {
                get
                {
                    return blnPuedeLeer && blnPuedeEscribir;
                }
            }
        }
    }
}
