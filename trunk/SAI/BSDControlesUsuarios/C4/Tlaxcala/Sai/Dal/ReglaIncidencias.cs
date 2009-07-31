using System;
using System.Collections.Generic;
using System.Text;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using System.Data.Common;

namespace BSD.C4.Tlaxcala.Sai.Dal
{
    public class ReglaIncidencias : Cooperator.Framework.Data.BaseRule, BSD.C4.Tlaxcala.Sai.Interfaces.IReacciones<Incidencia, IncidenciaMapper>
    {
        public void Guardar(Incidencia entidad, IncidenciaMapper mapper)
        {
            var transaccion = (new ReglaIncidencias()).DataBaseHelper.GetAndBeginTransaction();
            var conexion = transaccion.Connection;

            try
            {
                mapper.Insert(transaccion, entidad);
                transaccion.Commit();
            }
            catch (Exception)
            {
                transaccion.Rollback();
                throw;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();

                transaccion.Dispose();
            }
        }
    }
}
