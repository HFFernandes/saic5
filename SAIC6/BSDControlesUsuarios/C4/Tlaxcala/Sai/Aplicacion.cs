using System;
using System.Collections.Generic;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

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

        public static class UsuarioPersistencia
        {
            public static int intClaveUsuario { get; set; }
            public static string strNombreUsuario { get; set; }
            public static string[] strSistemas { get; set; }
        }
    }
}
