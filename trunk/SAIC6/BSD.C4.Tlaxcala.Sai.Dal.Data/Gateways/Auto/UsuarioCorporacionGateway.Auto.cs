
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 06:03 p.m.
// This is a partial class file. The other one is UsuarioCorporacionGateway.cs
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

    public partial class UsuarioCorporacionGateway : BaseGateway<UsuarioCorporacionObject, UsuarioCorporacionObjectList>, IGenericGateway
    {

        #region "Singleton"

        static UsuarioCorporacionGateway _instance;

        private UsuarioCorporacionGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static UsuarioCorporacionGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new UsuarioCorporacionGateway();
                else {
                    UsuarioCorporacionGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.UsuarioCorporacionGatewaySingleton"] as UsuarioCorporacionGateway;
                    if (inst == null) {
                        inst = new UsuarioCorporacionGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.UsuarioCorporacionGatewaySingleton", inst);
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
            get { return "UsuarioCorporacion"; }
        }

        protected override string RuleName
        {
            get {return typeof(UsuarioCorporacionGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, UsuarioCorporacionObject entity)
        {
            
            IMappeableUsuarioCorporacionObject UsuarioCorporacion = (IMappeableUsuarioCorporacionObject)entity;
            UsuarioCorporacion.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(UsuarioCorporacionObject entity)
        {

            IMappeableUsuarioCorporacionObject UsuarioCorporacion = (IMappeableUsuarioCorporacionObject)entity;
            return UsuarioCorporacion.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(UsuarioCorporacionObject entity)
        {

            IMappeableUsuarioCorporacionObject UsuarioCorporacion = (IMappeableUsuarioCorporacionObject)entity;
            return UsuarioCorporacion.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(UsuarioCorporacionObject entity)
        {

            IMappeableUsuarioCorporacionObject UsuarioCorporacion = (IMappeableUsuarioCorporacionObject)entity;
            return UsuarioCorporacion.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(UsuarioCorporacionObject row, object[] parameters)
        {
            ((IMappeableUsuarioCorporacionObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a UsuarioCorporacionObject by execute a SQL Query Text
        /// </summary>
        public UsuarioCorporacionObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by execute a SQL Query Text
        /// </summary>
        public UsuarioCorporacionObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a UsuarioCorporacionObject by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObject GetOne(System.Int32 ClaveUsuario, System.Int32 ClaveCorporacion)
        {
            return base.GetOne(new UsuarioCorporacionObject(ClaveUsuario, ClaveCorporacion));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObjectList GetByCorporacion(DbTransaction transaction,System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_GetByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObjectList GetByCorporacion(DbTransaction transaction, IUniqueIdentifiable Corporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_GetByCorporacion", Corporacion.Identifier());
        }

    

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObjectList GetByUsuario(DbTransaction transaction,System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObjectList GetByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_GetByUsuario", Usuario.Identifier());
        }

    

        

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObjectList GetByCorporacion(System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_GetByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObjectList GetByCorporacion(IUniqueIdentifiable Corporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_GetByCorporacion", Corporacion.Identifier());
        }

    

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObjectList GetByUsuario(System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Get a UsuarioCorporacionObjectList by calling a Stored Procedure
        /// </summary>
        public UsuarioCorporacionObjectList GetByUsuario(IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_GetByUsuario", Usuario.Identifier());
        }

    

        /// <summary>
        /// Delete UsuarioCorporacion
        /// </summary>
        public void Delete(System.Int32 ClaveUsuario, System.Int32 ClaveCorporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_Delete", ClaveUsuario, ClaveCorporacion);
        }

        /// <summary>
        /// Delete UsuarioCorporacion
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 ClaveUsuario, System.Int32 ClaveCorporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_Delete", ClaveUsuario, ClaveCorporacion);
        }

            

        

        /// <summary>
        /// Delete UsuarioCorporacion by Corporacion
        /// </summary>
        public void DeleteByCorporacion(System.Int32 ClaveCorporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_DeleteByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// Delete UsuarioCorporacion by Corporacion
        /// </summary>
        public void DeleteByCorporacion(DbTransaction transaction, System.Int32 ClaveCorporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_DeleteByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// Delete UsuarioCorporacion by Corporacion
        /// </summary>
        public void DeleteByCorporacion(IUniqueIdentifiable Corporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_DeleteByCorporacion", Corporacion.Identifier());
        }

        /// <summary>
        /// Delete UsuarioCorporacion by Corporacion
        /// </summary>
        public void DeleteByCorporacion(DbTransaction transaction, IUniqueIdentifiable Corporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_DeleteByCorporacion", Corporacion.Identifier());
        }


    

        /// <summary>
        /// Delete UsuarioCorporacion by Usuario
        /// </summary>
        public void DeleteByUsuario(System.Int32 ClaveUsuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_DeleteByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Delete UsuarioCorporacion by Usuario
        /// </summary>
        public void DeleteByUsuario(DbTransaction transaction, System.Int32 ClaveUsuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_DeleteByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Delete UsuarioCorporacion by Usuario
        /// </summary>
        public void DeleteByUsuario(IUniqueIdentifiable Usuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "UsuarioCorporacion_DeleteByUsuario", Usuario.Identifier());
        }

        /// <summary>
        /// Delete UsuarioCorporacion by Usuario
        /// </summary>
        public void DeleteByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "UsuarioCorporacion_DeleteByUsuario", Usuario.Identifier());
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








