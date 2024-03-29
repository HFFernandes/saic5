
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is MunicipioGateway.cs
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

    public partial class MunicipioGateway : BaseGateway<MunicipioObject, MunicipioObjectList>, IGenericGateway
    {

        #region "Singleton"

        static MunicipioGateway _instance;

        private MunicipioGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static MunicipioGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new MunicipioGateway();
                else {
                    MunicipioGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.MunicipioGatewaySingleton"] as MunicipioGateway;
                    if (inst == null) {
                        inst = new MunicipioGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.MunicipioGatewaySingleton", inst);
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
            get { return "Municipio"; }
        }

        protected override string RuleName
        {
            get {return typeof(MunicipioGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, MunicipioObject entity)
        {
            
            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            Municipio.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(MunicipioObject entity)
        {

            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            return Municipio.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(MunicipioObject entity)
        {

            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            return Municipio.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(MunicipioObject entity)
        {

            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            return Municipio.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(MunicipioObject row, object[] parameters)
        {
            ((IMappeableMunicipioObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a MunicipioObject by execute a SQL Query Text
        /// </summary>
        public MunicipioObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a MunicipioObjectList by execute a SQL Query Text
        /// </summary>
        public MunicipioObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a MunicipioObject by calling a Stored Procedure
        /// </summary>
        public MunicipioObject GetOne(System.Int32 Clave, System.Int32 ClaveEstado)
        {
            return base.GetOne(new MunicipioObject(Clave, ClaveEstado));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a MunicipioObjectList by calling a Stored Procedure
        /// </summary>
        public MunicipioObjectList GetByEstado(DbTransaction transaction,System.Int32 ClaveEstado)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_GetByEstado", ClaveEstado);
        }

        /// <summary>
        /// Get a MunicipioObjectList by calling a Stored Procedure
        /// </summary>
        public MunicipioObjectList GetByEstado(DbTransaction transaction, IUniqueIdentifiable Estado)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_GetByEstado", Estado.Identifier());
        }

    

        

        /// <summary>
        /// Get a MunicipioObjectList by calling a Stored Procedure
        /// </summary>
        public MunicipioObjectList GetByEstado(System.Int32 ClaveEstado)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Municipio_GetByEstado", ClaveEstado);
        }

        /// <summary>
        /// Get a MunicipioObjectList by calling a Stored Procedure
        /// </summary>
        public MunicipioObjectList GetByEstado(IUniqueIdentifiable Estado)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Municipio_GetByEstado", Estado.Identifier());
        }

    

        /// <summary>
        /// Delete Municipio
        /// </summary>
        public void Delete(System.Int32 Clave, System.Int32 ClaveEstado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Municipio_Delete", Clave, ClaveEstado);
        }

        /// <summary>
        /// Delete Municipio
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave, System.Int32 ClaveEstado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_Delete", Clave, ClaveEstado);
        }

            

        

        /// <summary>
        /// Delete Municipio by Estado
        /// </summary>
        public void DeleteByEstado(System.Int32 ClaveEstado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Municipio_DeleteByEstado", ClaveEstado);
        }

        /// <summary>
        /// Delete Municipio by Estado
        /// </summary>
        public void DeleteByEstado(DbTransaction transaction, System.Int32 ClaveEstado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_DeleteByEstado", ClaveEstado);
        }

        /// <summary>
        /// Delete Municipio by Estado
        /// </summary>
        public void DeleteByEstado(IUniqueIdentifiable Estado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Municipio_DeleteByEstado", Estado.Identifier());
        }

        /// <summary>
        /// Delete Municipio by Estado
        /// </summary>
        public void DeleteByEstado(DbTransaction transaction, IUniqueIdentifiable Estado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_DeleteByEstado", Estado.Identifier());
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








