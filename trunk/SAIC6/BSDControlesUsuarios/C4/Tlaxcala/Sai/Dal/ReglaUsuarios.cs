using System;
using System.Collections.Generic;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Dal
{
    /// <summary>
    /// Clase donde persiste los permisos y configuraciones de un usuario especifico
    /// </summary>
    public class ReglaUsuarios : Cooperator.Framework.Data.BaseRule,Interfaces.IReacciones<Usuario,UsuarioMapper>
    {
        public void GuardarEntidad(Usuario entidad, UsuarioMapper mapper)
        {
            throw new System.NotImplementedException();
        }

        public Usuario ObtenerEntidad(UsuarioMapper mapper, object identificadorEntidad)
        {
            try
            {
                return mapper.GetOne(Convert.ToInt32(identificadorEntidad));
            }
            catch (InvalidCastException)
            {
                return null;
            }
        }
    }
}
