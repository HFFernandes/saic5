
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is SubmoduloGateway.cs
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

    public partial class SubmoduloGateway : BaseGateway<SubmoduloObject, SubmoduloObjectList>, IGenericGateway
    {

        #region "Singleton"

        static SubmoduloGateway _instance;

        private SubmoduloGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static SubmoduloGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new SubmoduloGateway();
                else {
                    SubmoduloGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.SubmoduloGatewaySingleton"] as SubmoduloGateway;
                    if (inst == null) {
                        inst = new SubmoduloGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.SubmoduloGatewaySingleton", inst);
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
            get { return "Submodulo"; }
        }

        protected override string RuleName
        {
            get {return typeof(SubmoduloGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, SubmoduloObject entity)
        {
            
            IMappeableSubmoduloObject Submodulo = (IMappeableSubmoduloObject)entity;
            Submodulo.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetString(2));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(SubmoduloObject entity)
        {

            IMappeableSubmoduloObject Submodulo = (IMappeableSubmoduloObject)entity;
            return Submodulo.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(SubmoduloObject entity)
        {

            IMappeableSubmoduloObject Submodulo = (IMappeableSubmoduloObject)entity;
            return Submodulo.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(SubmoduloObject entity)
        {

            IMappeableSubmoduloObject Submodulo = (IMappeableSubmoduloObject)entity;
            return Submodulo.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(SubmoduloObject row, object[] parameters)
        {
            ((IMappeableSubmoduloObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a SubmoduloObject by execute a SQL Query Text
        /// </summary>
        public SubmoduloObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a SubmoduloObjectList by execute a SQL Query Text
        /// </summary>
        public SubmoduloObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a SubmoduloObject by calling a Stored Procedure
        /// </summary>
        public SubmoduloObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new SubmoduloObject(Clave));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a SubmoduloObjectList by calling a Stored Procedure
        /// </summary>
        public SubmoduloObjectList GetBySistema(DbTransaction transaction,System.Int32 ClaveSistema)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Submodulo_GetBySistema", ClaveSistema);
        }

        /// <summary>
        /// Get a SubmoduloObjectList by calling a Stored Procedure
        /// </summary>
        public SubmoduloObjectList GetBySistema(DbTransaction transaction, IUniqueIdentifiable Sistema)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Submodulo_GetBySistema", Sistema.Identifier());
        }

    

        

        /// <summary>
        /// Get a SubmoduloObjectList by calling a Stored Procedure
        /// </summary>
        public SubmoduloObjectList GetBySistema(System.Int32 ClaveSistema)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Submodulo_GetBySistema", ClaveSistema);
        }

        /// <summary>
        /// Get a SubmoduloObjectList by calling a Stored Procedure
        /// </summary>
        public SubmoduloObjectList GetBySistema(IUniqueIdentifiable Sistema)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Submodulo_GetBySistema", Sistema.Identifier());
        }

    

        /// <summary>
        /// Delete Submodulo
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Submodulo_Delete", Clave);
        }

        /// <summary>
        /// Delete Submodulo
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Submodulo_Delete", Clave);
        }

            

        

        /// <summary>
        /// Delete Submodulo by Sistema
        /// </summary>
        public void DeleteBySistema(System.Int32 ClaveSistema)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Submodulo_DeleteBySistema", ClaveSistema);
        }

        /// <summary>
        /// Delete Submodulo by Sistema
        /// </summary>
        public void DeleteBySistema(DbTransaction transaction, System.Int32 ClaveSistema)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Submodulo_DeleteBySistema", ClaveSistema);
        }

        /// <summary>
        /// Delete Submodulo by Sistema
        /// </summary>
        public void DeleteBySistema(IUniqueIdentifiable Sistema)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Submodulo_DeleteBySistema", Sistema.Identifier());
        }

        /// <summary>
        /// Delete Submodulo by Sistema
        /// </summary>
        public void DeleteBySistema(DbTransaction transaction, IUniqueIdentifiable Sistema)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Submodulo_DeleteBySistema", Sistema.Identifier());
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








