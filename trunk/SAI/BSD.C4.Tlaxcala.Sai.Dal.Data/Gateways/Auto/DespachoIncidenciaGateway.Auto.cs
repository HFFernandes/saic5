
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is DespachoIncidenciaGateway.cs
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

    public partial class DespachoIncidenciaGateway : BaseGateway<DespachoIncidenciaObject, DespachoIncidenciaObjectList>, IGenericGateway
    {

        #region "Singleton"

        static DespachoIncidenciaGateway _instance;

        private DespachoIncidenciaGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static DespachoIncidenciaGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new DespachoIncidenciaGateway();
                else {
                    DespachoIncidenciaGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.DespachoIncidenciaGatewaySingleton"] as DespachoIncidenciaGateway;
                    if (inst == null) {
                        inst = new DespachoIncidenciaGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.DespachoIncidenciaGatewaySingleton", inst);
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
            get { return "DespachoIncidencia"; }
        }

        protected override string RuleName
        {
            get {return typeof(DespachoIncidenciaGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, DespachoIncidenciaObject entity)
        {
            
            IMappeableDespachoIncidenciaObject DespachoIncidencia = (IMappeableDespachoIncidenciaObject)entity;
            DespachoIncidencia.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
reader.GetInt32(3),
(reader.IsDBNull(4)) ? new System.Nullable<System.DateTime>() : reader.GetDateTime(4),
(reader.IsDBNull(5)) ? new System.Nullable<System.DateTime>() : reader.GetDateTime(5),
(reader.IsDBNull(6)) ? new System.Nullable<System.DateTime>() : reader.GetDateTime(6),
(reader.IsDBNull(7)) ? new System.Nullable<System.Int32>() : reader.GetInt32(7),
reader.GetInt32(8));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(DespachoIncidenciaObject entity)
        {

            IMappeableDespachoIncidenciaObject DespachoIncidencia = (IMappeableDespachoIncidenciaObject)entity;
            return DespachoIncidencia.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(DespachoIncidenciaObject entity)
        {

            IMappeableDespachoIncidenciaObject DespachoIncidencia = (IMappeableDespachoIncidenciaObject)entity;
            return DespachoIncidencia.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(DespachoIncidenciaObject entity)
        {

            IMappeableDespachoIncidenciaObject DespachoIncidencia = (IMappeableDespachoIncidenciaObject)entity;
            return DespachoIncidencia.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(DespachoIncidenciaObject row, object[] parameters)
        {
            ((IMappeableDespachoIncidenciaObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a DespachoIncidenciaObject by execute a SQL Query Text
        /// </summary>
        public DespachoIncidenciaObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by execute a SQL Query Text
        /// </summary>
        public DespachoIncidenciaObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a DespachoIncidenciaObject by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new DespachoIncidenciaObject(Clave));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByCorporacionIncidencia(DbTransaction transaction,System.Int32 Folio, System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_GetByCorporacionIncidencia", Folio, ClaveCorporacion);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByCorporacionIncidencia(DbTransaction transaction, IUniqueIdentifiable CorporacionIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_GetByCorporacionIncidencia", CorporacionIncidencia.Identifier());
        }

    

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUnidad(DbTransaction transaction,System.Int32 ClaveUnidad)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_GetByUnidad", ClaveUnidad);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUnidad(DbTransaction transaction, IUniqueIdentifiable ListaUnidades)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_GetByUnidad", ListaUnidades.Identifier());
        }

    

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUnidadApoyo(DbTransaction transaction,System.Int32 ClaveUnidadApoyo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_GetByUnidadApoyo", ClaveUnidadApoyo);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUnidadApoyo(DbTransaction transaction, IUniqueIdentifiable ListaUnidades)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_GetByUnidadApoyo", ListaUnidades.Identifier());
        }

    

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUsuario(DbTransaction transaction,System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_GetByUsuario", Usuario.Identifier());
        }

    

        

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByCorporacionIncidencia(System.Int32 Folio, System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_GetByCorporacionIncidencia", Folio, ClaveCorporacion);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByCorporacionIncidencia(IUniqueIdentifiable CorporacionIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_GetByCorporacionIncidencia", CorporacionIncidencia.Identifier());
        }

    

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUnidad(System.Int32 ClaveUnidad)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_GetByUnidad", ClaveUnidad);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUnidad(IUniqueIdentifiable ListaUnidades)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_GetByUnidad", ListaUnidades.Identifier());
        }

    

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUnidadApoyo(System.Int32 ClaveUnidadApoyo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_GetByUnidadApoyo", ClaveUnidadApoyo);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUnidadApoyo(IUniqueIdentifiable ListaUnidades)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_GetByUnidadApoyo", ListaUnidades.Identifier());
        }

    

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUsuario(System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Get a DespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DespachoIncidenciaObjectList GetByUsuario(IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_GetByUsuario", Usuario.Identifier());
        }

    

        /// <summary>
        /// Delete DespachoIncidencia
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_Delete", Clave);
        }

        /// <summary>
        /// Delete DespachoIncidencia
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_Delete", Clave);
        }

            

        

        /// <summary>
        /// Delete DespachoIncidencia by CorporacionIncidencia
        /// </summary>
        public void DeleteByCorporacionIncidencia(System.Int32 Folio, System.Int32 ClaveCorporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_DeleteByCorporacionIncidencia", Folio, ClaveCorporacion);
        }

        /// <summary>
        /// Delete DespachoIncidencia by CorporacionIncidencia
        /// </summary>
        public void DeleteByCorporacionIncidencia(DbTransaction transaction, System.Int32 Folio, System.Int32 ClaveCorporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_DeleteByCorporacionIncidencia", Folio, ClaveCorporacion);
        }

        /// <summary>
        /// Delete DespachoIncidencia by CorporacionIncidencia
        /// </summary>
        public void DeleteByCorporacionIncidencia(IUniqueIdentifiable CorporacionIncidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_DeleteByCorporacionIncidencia", CorporacionIncidencia.Identifier());
        }

        /// <summary>
        /// Delete DespachoIncidencia by CorporacionIncidencia
        /// </summary>
        public void DeleteByCorporacionIncidencia(DbTransaction transaction, IUniqueIdentifiable CorporacionIncidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_DeleteByCorporacionIncidencia", CorporacionIncidencia.Identifier());
        }


    

        /// <summary>
        /// Delete DespachoIncidencia by Unidad
        /// </summary>
        public void DeleteByUnidad(System.Int32 ClaveUnidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUnidad", ClaveUnidad);
        }

        /// <summary>
        /// Delete DespachoIncidencia by Unidad
        /// </summary>
        public void DeleteByUnidad(DbTransaction transaction, System.Int32 ClaveUnidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUnidad", ClaveUnidad);
        }

        /// <summary>
        /// Delete DespachoIncidencia by Unidad
        /// </summary>
        public void DeleteByUnidad(IUniqueIdentifiable ListaUnidades)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUnidad", ListaUnidades.Identifier());
        }

        /// <summary>
        /// Delete DespachoIncidencia by Unidad
        /// </summary>
        public void DeleteByUnidad(DbTransaction transaction, IUniqueIdentifiable ListaUnidades)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUnidad", ListaUnidades.Identifier());
        }


    

        /// <summary>
        /// Delete DespachoIncidencia by UnidadApoyo
        /// </summary>
        public void DeleteByUnidadApoyo(System.Int32 ClaveUnidadApoyo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUnidadApoyo", ClaveUnidadApoyo);
        }

        /// <summary>
        /// Delete DespachoIncidencia by UnidadApoyo
        /// </summary>
        public void DeleteByUnidadApoyo(DbTransaction transaction, System.Int32 ClaveUnidadApoyo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUnidadApoyo", ClaveUnidadApoyo);
        }

        /// <summary>
        /// Delete DespachoIncidencia by UnidadApoyo
        /// </summary>
        public void DeleteByUnidadApoyo(IUniqueIdentifiable ListaUnidades)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUnidadApoyo", ListaUnidades.Identifier());
        }

        /// <summary>
        /// Delete DespachoIncidencia by UnidadApoyo
        /// </summary>
        public void DeleteByUnidadApoyo(DbTransaction transaction, IUniqueIdentifiable ListaUnidades)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUnidadApoyo", ListaUnidades.Identifier());
        }


    

        /// <summary>
        /// Delete DespachoIncidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(System.Int32 ClaveUsuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Delete DespachoIncidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(DbTransaction transaction, System.Int32 ClaveUsuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Delete DespachoIncidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(IUniqueIdentifiable Usuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUsuario", Usuario.Identifier());
        }

        /// <summary>
        /// Delete DespachoIncidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DespachoIncidencia_DeleteByUsuario", Usuario.Identifier());
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







