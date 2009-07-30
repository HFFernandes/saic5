using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Dal
{
    public class PruebaReglas : Cooperator.Framework.Data.BaseRule
    {
        public PruebaReglas()
        {
        }

        public static void InsertarRegistro()
        {
            DbTransaction tr = (new PruebaReglas()).DataBaseHelper.GetAndBeginTransaction();
            DbConnection con = tr.Connection;

            try
            {
                Corporacion corporacion = new Corporacion(1);
                corporacion.Activo = true;
                corporacion.Descripcion = "Prueba de corporacion";
                corporacion.UnidadesVirtuales = true;

                CorporacionMapper.Instance().Insert(tr, corporacion);
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
            }finally
            {
                con.Close();
                tr.Dispose();
            }
        }


    }
}
