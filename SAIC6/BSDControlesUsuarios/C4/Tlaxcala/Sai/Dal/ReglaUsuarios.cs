using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;

namespace BSD.C4.Tlaxcala.Sai.Dal
{
    /// <summary>
    /// Clase donde persiste los permisos y configuraciones de un usuario especifico
    /// </summary>
    public static class ReglaUsuarios
    {
        /// <summary>
        /// Método para la obtención del catálogo de sistemas a los cuales un usuario tiene permisos de acceso
        /// </summary>
        /// <param name="strNombreUsuario">Nombre de usuario</param>
        /// <param name="strContraseña">Contraseña de acceso</param>
        /// <returns>Un arreglo de tipo cadena con los sistemas a los cuales tienen acceso</returns>
        public static List<string> ObtenerSistemas(string strNombreUsuario, string strContraseña)
        {
            var sistemas = new List<string>();
            var usuario = UsuarioMapper.Instance().GetOneBySQLQuery(string.Format(SQL_OBTENERUSUARIO, strNombreUsuario));

            if (usuario != null)
            {
                //Existe un usuario con las credenciales proporcionadas
                //Luego entonces, obtengo y presento los sistemas a los cuales puede accesar
                var sistema = SistemaMapper.Instance().GetBySQLQuery(string.Format(SQL_OBTENERSISTEMAS, usuario.Clave));
                foreach (var s in sistema)
                {
                    sistemas.Add(s.Descripcion);
                }
            }

            return sistemas;
        }

        public static Usuario AutenticarUsuario(string strNombreUsuario, string strContraseña)
        {
            return UsuarioMapper.Instance().GetOneBySQLQuery(string.Format(SQL_AUTENTICARUSUARIO,strNombreUsuario,strContraseña));
        }

        //Definición de constantes para consultas definidas por el desarrollador
        private const string SQL_OBTENERUSUARIO = "SELECT * FROM [Usuario] WHERE (NombreUsuario='{0}')";
        private const string SQL_OBTENERSISTEMAS = "SELECT Sistema.* FROM PermisoUsuario INNER JOIN Submodulo ON PermisoUsuario.ClaveSubmodulo = Submodulo.Clave INNER JOIN Sistema ON Submodulo.ClaveSistema = Sistema.Clave INNER JOIN Usuario ON PermisoUsuario.ClaveUsuario = Usuario.Clave WHERE Usuario.Clave = {0}";
        private const string SQL_AUTENTICARUSUARIO =
            "SELECT * FROM [Usuario] WHERE (NombreUsuario='{0}' AND Contraseña='{1}')";
    }

    public static class UsuarioPersistencia
    {
        public static int intClaveUsuario{ get; set; }
        public static string strNombreUsuario { get; set; }
        public static string[] strSistemas { get; set; }
    }
}
