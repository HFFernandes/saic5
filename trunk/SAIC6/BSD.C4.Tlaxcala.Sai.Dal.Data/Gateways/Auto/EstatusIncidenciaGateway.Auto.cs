
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 29/07/2009 - 02:18 p.m.
// This is a partial class file. The other one is EstatusIncidenciaGateway.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using System;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using Cooperator.Framework.Data;
using Cooperator.Framework.Data.Exceptions;
using Cooperator.Framework.Core;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Web;




namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Gateways
{

    public partial class EstatusIncidenciaGateway : BaseGateway<EstatusIncidenciaObject, EstatusIncidenciaObjectList>, IGenericGateway
    {

        #region "Singleton"

        static EstatusIncidenciaGateway _instance;

        private EstatusIncidenciaGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static EstatusIncidenciaGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new EstatusIncidenciaGateway();
                else {
                    EstatusIncidenciaGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.EstatusIncidenciaGatewaySingleton"] as EstatusIncidenciaGateway;
                    if (inst == null) {
                        inst = new EstatusIncidenciaGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.EstatusIncidenciaGatewaySingleton", inst);
                    }
                    return inst;
                }
            }
            return _instance;
        }

        #endregion

        /// <summary>
        /// Return the mapped table name
        /// </summary>
        protected override string TableName
        {
            get { return "EstatusIncidencia"; }
        }

        protected override string RuleName
        {
            get {return typeof(EstatusIncidenciaGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, EstatusIncidenciaObject entity)
        {
            
            IMappeableEstatusIncidenciaObject EstatusIncidencia = (IMappeableEstatusIncidenciaObject)entity;
            EstatusIncidencia.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(EstatusIncidenciaObject entity)
        {

            IMappeableEstatusIncidenciaObject EstatusIncidencia = (IMappeableEstatusIncidenciaObject)entity;
            return EstatusIncidencia.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(EstatusIncidenciaObject entity)
        {

            IMappeableEstatusIncidenciaObject EstatusIncidencia = (IMappeableEstatusIncidenciaObject)entity;
            return EstatusIncidencia.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(EstatusIncidenciaObject entity)
        {

            IMappeableEstatusIncidenciaObject EstatusIncidencia = (IMappeableEstatusIncidenciaObject)entity;
            return EstatusIncidencia.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(EstatusIncidenciaObject row, object[] parameters)
        {
            ((IMappeableEstatusIncidenciaObject) row).UpdateObjectFromOutputParams(parameters);
            ((IObject)row).State = ObjectState.Restored;
        }

        /// <summary>
        /// StoredProceduresPrefix, for example: coop_
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


        /// <summary>
        /// Get a EstatusIncidenciaObject by execute a SQL Query Text
        /// </summary>
        public EstatusIncidenciaObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a EstatusIncidenciaObjectList by execute a SQL Query Text
        /// </summary>
        public EstatusIncidenciaObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a EstatusIncidenciaObject by calling a Stored Procedure
        /// </summary>
        public EstatusIncidenciaObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new EstatusIncidenciaObject(Clave));
        }


        // GetBy Objects and Params
            


        

        

        /// <summary>
        /// Delete EstatusIncidencia
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "EstatusIncidencia_Delete", Clave);
        }

        /// <summary>
        /// Delete EstatusIncidencia
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "EstatusIncidencia_Delete", Clave);
        }

            

        


        //Database Queries 
        



        #region IGenericGateway

        object IGenericGateway.GetOne(IUniqueIdentifiable identifier)
        {
            return base.GetOne(identifier);
        }

        object IGenericGateway.GetAll()
        {
            return base.GetAll();
        }

        object IGenericGateway.GetByParent(IUniqueIdentifiable parentEntity)
        {
            return base.GetByParent(parentEntity);
        }

        #endregion


    }

}








