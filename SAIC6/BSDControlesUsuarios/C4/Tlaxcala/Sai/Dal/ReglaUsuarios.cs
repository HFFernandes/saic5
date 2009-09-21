using System.Collections.Generic;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;

namespace BSD.C4.Tlaxcala.Sai.Dal
{
    /// <summary>
    /// Clase que maneja las reglas de negocio para la entidad de usuarios
    /// </summary>
    public static class ReglaUsuarios
    {
        /// <summary>
        /// M�todo para la obtenci�n del cat�logo de sistemas a los cuales un usuario tiene permisos de acceso
        /// </summary>
        /// <param name="strNombreUsuario">Nombre de usuario</param>
        /// <param name="strContrase�a">Contrase�a de acceso</param>
        /// <returns>Un arreglo de tipo cadena con los sistemas a los cuales tienen acceso</returns>
        public static List<string> ObtenerSistemas(string strNombreUsuario, string strContrase�a)
        {
            var sistemas = new List<string>();

            var usuario =
                UsuarioMapper.Instance().GetOneBySQLQuery(string.Format(ID.SQL_OBTENERUSUARIO, strNombreUsuario));
            if (usuario != null)
            {
                sistemas.Clear();

                //Existe un usuario con las credenciales proporcionadas
                //Luego entonces, obtengo y presento los sistemas a los cuales puede accesar
                var sistema =
                    SistemaMapper.Instance().GetBySQLQuery(string.Format(ID.SQL_OBTENERSISTEMAS, usuario.Clave));
                foreach (var s in sistema)
                {
                    sistemas.Add(s.Descripcion);
                }
            }

            return sistemas;
        }

        /// <summary>
        /// M�todo para la autenticaci�n del usuario
        /// </summary>
        /// <param name="strNombreUsuario">nombre de usuario</param>
        /// <param name="strContrase�a">contrase�a de acceso</param>
        /// <returns>Una instancia de la entidad usuario pasada, pudiendo ser nula</returns>
        public static Usuario AutenticarUsuario(string strNombreUsuario, string strContrase�a)
        {
            return
                UsuarioMapper.Instance().GetOneBySQLQuery(string.Format(ID.SQL_AUTENTICARUSUARIO, strNombreUsuario,
                                                                        new Aplicacion.CzSecurity().PassWordCifrado(
                                                                            strContrase�a)));
        }
    }
}