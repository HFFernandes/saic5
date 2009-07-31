
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 29/07/2009 - 02:18 p.m.
// This is a partial class file. The other one is DetalleDespachoIncidenciaGateway.cs
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

    public partial class DetalleDespachoIncidenciaGateway : BaseGateway<DetalleDespachoIncidenciaObject, DetalleDespachoIncidenciaObjectList>, IGenericGateway
    {

        #region "Singleton"

        static DetalleDespachoIncidenciaGateway _instance;

        private DetalleDespachoIncidenciaGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static DetalleDespachoIncidenciaGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new DetalleDespachoIncidenciaGateway();
                else {
                    DetalleDespachoIncidenciaGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.DetalleDespachoIncidenciaGatewaySingleton"] as DetalleDespachoIncidenciaGateway;
                    if (inst == null) {
                        inst = new DetalleDespachoIncidenciaGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.DetalleDespachoIncidenciaGatewaySingleton", inst);
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
            get { return "DetalleDespachoIncidencia"; }
        }

        protected override string RuleName
        {
            get {return typeof(DetalleDespachoIncidenciaGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, DetalleDespachoIncidenciaObject entity)
        {
            
            IMappeableDetalleDespachoIncidenciaObject DetalleDespachoIncidencia = (IMappeableDetalleDespachoIncidenciaObject)entity;
            DetalleDespachoIncidencia.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetString(2),
reader.GetInt32(3),
reader.GetDateTime(4));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(DetalleDespachoIncidenciaObject entity)
        {

            IMappeableDetalleDespachoIncidenciaObject DetalleDespachoIncidencia = (IMappeableDetalleDespachoIncidenciaObject)entity;
            return DetalleDespachoIncidencia.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(DetalleDespachoIncidenciaObject entity)
        {

            IMappeableDetalleDespachoIncidenciaObject DetalleDespachoIncidencia = (IMappeableDetalleDespachoIncidenciaObject)entity;
            return DetalleDespachoIncidencia.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(DetalleDespachoIncidenciaObject entity)
        {

            IMappeableDetalleDespachoIncidenciaObject DetalleDespachoIncidencia = (IMappeableDetalleDespachoIncidenciaObject)entity;
            return DetalleDespachoIncidencia.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(DetalleDespachoIncidenciaObject row, object[] parameters)
        {
            ((IMappeableDetalleDespachoIncidenciaObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a DetalleDespachoIncidenciaObject by execute a SQL Query Text
        /// </summary>
        public DetalleDespachoIncidenciaObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by execute a SQL Query Text
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a DetalleDespachoIncidenciaObject by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new DetalleDespachoIncidenciaObject(Clave));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetByDespachoIncidencia(DbTransaction transaction,System.Int32 ClaveDespacho)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_GetByDespachoIncidencia", ClaveDespacho);
        }

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetByDespachoIncidencia(DbTransaction transaction, IUniqueIdentifiable DespachoIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_GetByDespachoIncidencia", DespachoIncidencia.Identifier());
        }

    

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetByUsuario(DbTransaction transaction,System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_GetByUsuario", Usuario.Identifier());
        }

    

        

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetByDespachoIncidencia(System.Int32 ClaveDespacho)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_GetByDespachoIncidencia", ClaveDespacho);
        }

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetByDespachoIncidencia(IUniqueIdentifiable DespachoIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_GetByDespachoIncidencia", DespachoIncidencia.Identifier());
        }

    

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetByUsuario(System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Get a DetalleDespachoIncidenciaObjectList by calling a Stored Procedure
        /// </summary>
        public DetalleDespachoIncidenciaObjectList GetByUsuario(IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_GetByUsuario", Usuario.Identifier());
        }

    

        /// <summary>
        /// Delete DetalleDespachoIncidencia
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_Delete", Clave);
        }

        /// <summary>
        /// Delete DetalleDespachoIncidencia
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_Delete", Clave);
        }

            

        

        /// <summary>
        /// Delete DetalleDespachoIncidencia by DespachoIncidencia
        /// </summary>
        public void DeleteByDespachoIncidencia(System.Int32 ClaveDespacho)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_DeleteByDespachoIncidencia", ClaveDespacho);
        }

        /// <summary>
        /// Delete DetalleDespachoIncidencia by DespachoIncidencia
        /// </summary>
        public void DeleteByDespachoIncidencia(DbTransaction transaction, System.Int32 ClaveDespacho)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_DeleteByDespachoIncidencia", ClaveDespacho);
        }

        /// <summary>
        /// Delete DetalleDespachoIncidencia by DespachoIncidencia
        /// </summary>
        public void DeleteByDespachoIncidencia(IUniqueIdentifiable DespachoIncidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_DeleteByDespachoIncidencia", DespachoIncidencia.Identifier());
        }

        /// <summary>
        /// Delete DetalleDespachoIncidencia by DespachoIncidencia
        /// </summary>
        public void DeleteByDespachoIncidencia(DbTransaction transaction, IUniqueIdentifiable DespachoIncidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_DeleteByDespachoIncidencia", DespachoIncidencia.Identifier());
        }


    

        /// <summary>
        /// Delete DetalleDespachoIncidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(System.Int32 ClaveUsuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_DeleteByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Delete DetalleDespachoIncidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(DbTransaction transaction, System.Int32 ClaveUsuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_DeleteByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// Delete DetalleDespachoIncidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(IUniqueIdentifiable Usuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "DetalleDespachoIncidencia_DeleteByUsuario", Usuario.Identifier());
        }

        /// <summary>
        /// Delete DetalleDespachoIncidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "DetalleDespachoIncidencia_DeleteByUsuario", Usuario.Identifier());
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








