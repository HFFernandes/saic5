using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;

namespace BSD.C4.Tlaxcala.Sai.Dal
{
    /// <summary>
    /// Clase donde persiste los permisos y configuraciones de un usuario especifico
    /// </summary>
    public static class ReglaUsuarios
    {
        public static List<string> AutenticaUsuario(string strNombreUsuario, string strContraseña)
        {
            List<string> sistemas = new List<string>();

            Usuario usuario = UsuarioMapper.Instance().GetOneBySQLQuery(string.Format("SELECT * FROM [Usuario] WHERE (NombreUsuario='{0}' AND Contraseña='{1}')", strNombreUsuario, strContraseña));
            
            if (usuario != null)
            {
                //Existe un usuario con las credenciales proporcionadas
                //Luego entonces, obtengo y presento los sistemas a los cuales puede accesar
                SistemaObjectList sistema = SistemaMapper.Instance().GetBySQLQuery("SELECT Sistema.* FROM PermisoUsuario INNER JOIN Submodulo ON PermisoUsuario.ClaveSubmodulo = Submodulo.Clave INNER JOIN Sistema ON Submodulo.ClaveSistema = Sistema.Clave INNER JOIN Usuario ON PermisoUsuario.ClaveUsuario = Usuario.Clave WHERE Usuario.Clave = 1");
                foreach (var s in sistema)
                {
                    sistemas.Add(s.Descripcion);
                }
            }

            return sistemas;
        }
    }


}
