using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Dal
{
    /// <summary>
    /// Clase donde persiste los permisos y configuraciones de un usuario especifico
    /// </summary>
    public static class ReglaUsuarios
    {
        public static List<string> ObtenerSistemas(string strNombreUsuario, string strContraseña)
        {
            var sistemas = new List<string>();
            var usuario = UsuarioMapper.Instance().GetOneBySQLQuery(string.Format(SQL_OBTENERUSUARIO, strNombreUsuario, strContraseña));

            if (usuario != null)
            {
                //Existe un usuario con las credenciales proporcionadas
                //Luego entonces, obtengo y presento los sistemas a los cuales puede accesar
                var sistema = SistemaMapper.Instance().GetBySQLQuery(string.Format(SQL_OBTENERSISTEMA, usuario.Clave));
                foreach (var s in sistema)
                {
                    sistemas.Add(s.Descripcion);
                }
            }

            return sistemas;
        }

        private const string SQL_OBTENERUSUARIO = "SELECT * FROM [Usuario] WHERE (NombreUsuario='{0}' AND Contraseña='{1}')";
        private const string SQL_OBTENERSISTEMA = "SELECT Sistema.* FROM PermisoUsuario INNER JOIN Submodulo ON PermisoUsuario.ClaveSubmodulo = Submodulo.Clave INNER JOIN Sistema ON Submodulo.ClaveSistema = Sistema.Clave INNER JOIN Usuario ON PermisoUsuario.ClaveUsuario = Usuario.Clave WHERE Usuario.Clave = {0}";
    }


}
