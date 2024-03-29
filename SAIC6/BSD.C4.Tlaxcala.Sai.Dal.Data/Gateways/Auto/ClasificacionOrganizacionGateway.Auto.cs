
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 18/08/2009 - 09:55 p.m.
// This is a partial class file. The other one is ClasificacionOrganizacionGateway.cs
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

    public partial class ClasificacionOrganizacionGateway : BaseGateway<ClasificacionOrganizacionObject, ClasificacionOrganizacionObjectList>, IGenericGateway
    {

        #region "Singleton"

        static ClasificacionOrganizacionGateway _instance;

        private ClasificacionOrganizacionGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static ClasificacionOrganizacionGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new ClasificacionOrganizacionGateway();
                else {
                    ClasificacionOrganizacionGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.ClasificacionOrganizacionGatewaySingleton"] as ClasificacionOrganizacionGateway;
                    if (inst == null) {
                        inst = new ClasificacionOrganizacionGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.ClasificacionOrganizacionGatewaySingleton", inst);
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
            get { return "ClasificacionOrganizacion"; }
        }

        protected override string RuleName
        {
            get {return typeof(ClasificacionOrganizacionGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, ClasificacionOrganizacionObject entity)
        {
            
            IMappeableClasificacionOrganizacionObject ClasificacionOrganizacion = (IMappeableClasificacionOrganizacionObject)entity;
            ClasificacionOrganizacion.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(ClasificacionOrganizacionObject entity)
        {

            IMappeableClasificacionOrganizacionObject ClasificacionOrganizacion = (IMappeableClasificacionOrganizacionObject)entity;
            return ClasificacionOrganizacion.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(ClasificacionOrganizacionObject entity)
        {

            IMappeableClasificacionOrganizacionObject ClasificacionOrganizacion = (IMappeableClasificacionOrganizacionObject)entity;
            return ClasificacionOrganizacion.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(ClasificacionOrganizacionObject entity)
        {

            IMappeableClasificacionOrganizacionObject ClasificacionOrganizacion = (IMappeableClasificacionOrganizacionObject)entity;
            return ClasificacionOrganizacion.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(ClasificacionOrganizacionObject row, object[] parameters)
        {
            ((IMappeableClasificacionOrganizacionObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a ClasificacionOrganizacionObject by execute a SQL Query Text
        /// </summary>
        public ClasificacionOrganizacionObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a ClasificacionOrganizacionObjectList by execute a SQL Query Text
        /// </summary>
        public ClasificacionOrganizacionObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a ClasificacionOrganizacionObject by calling a Stored Procedure
        /// </summary>
        public ClasificacionOrganizacionObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new ClasificacionOrganizacionObject(Clave));
        }


        // GetBy Objects and Params
            


        

        

        /// <summary>
        /// Delete ClasificacionOrganizacion
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "ClasificacionOrganizacion_Delete", Clave);
        }

        /// <summary>
        /// Delete ClasificacionOrganizacion
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "ClasificacionOrganizacion_Delete", Clave);
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








