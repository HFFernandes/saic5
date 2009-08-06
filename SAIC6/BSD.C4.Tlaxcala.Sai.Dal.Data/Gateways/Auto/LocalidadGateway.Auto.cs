
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 05/08/2009 - 08:55 p.m.
// This is a partial class file. The other one is LocalidadGateway.cs
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

    public partial class LocalidadGateway : BaseGateway<LocalidadObject, LocalidadObjectList>, IGenericGateway
    {

        #region "Singleton"

        static LocalidadGateway _instance;

        private LocalidadGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static LocalidadGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new LocalidadGateway();
                else {
                    LocalidadGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.LocalidadGatewaySingleton"] as LocalidadGateway;
                    if (inst == null) {
                        inst = new LocalidadGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.LocalidadGatewaySingleton", inst);
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
            get { return "Localidad"; }
        }

        protected override string RuleName
        {
            get {return typeof(LocalidadGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, LocalidadObject entity)
        {
            
            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            Localidad.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(LocalidadObject entity)
        {

            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            return Localidad.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(LocalidadObject entity)
        {

            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            return Localidad.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(LocalidadObject entity)
        {

            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            return Localidad.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(LocalidadObject row, object[] parameters)
        {
            ((IMappeableLocalidadObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a LocalidadObject by execute a SQL Query Text
        /// </summary>
        public LocalidadObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a LocalidadObjectList by execute a SQL Query Text
        /// </summary>
        public LocalidadObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a LocalidadObject by calling a Stored Procedure
        /// </summary>
        public LocalidadObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new LocalidadObject(Clave));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a LocalidadObjectList by calling a Stored Procedure
        /// </summary>
        public LocalidadObjectList GetByColoniaAggregation(DbTransaction transaction,System.Int32 Clave)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Clave);
        }

        /// <summary>
        /// Get a LocalidadObjectList by calling a Stored Procedure
        /// </summary>
        public LocalidadObjectList GetByColoniaAggregation(DbTransaction transaction, IUniqueIdentifiable Colonia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Colonia.Identifier());
        }

    

        /// <summary>
        /// Get a LocalidadObjectList by calling a Stored Procedure
        /// </summary>
        public LocalidadObjectList GetByMunicipio(DbTransaction transaction,System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// Get a LocalidadObjectList by calling a Stored Procedure
        /// </summary>
        public LocalidadObjectList GetByMunicipio(DbTransaction transaction, IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByMunicipio", Municipio.Identifier());
        }

    

        

        /// <summary>
        /// Get a LocalidadObjectList by calling a Stored Procedure
        /// </summary>
        public LocalidadObjectList GetByColoniaAggregation(System.Int32 Clave)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Clave);
        }

        /// <summary>
        /// Get a LocalidadObjectList by calling a Stored Procedure
        /// </summary>
        public LocalidadObjectList GetByColoniaAggregation(IUniqueIdentifiable Colonia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Colonia.Identifier());
        }

    

        /// <summary>
        /// Get a LocalidadObjectList by calling a Stored Procedure
        /// </summary>
        public LocalidadObjectList GetByMunicipio(System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// Get a LocalidadObjectList by calling a Stored Procedure
        /// </summary>
        public LocalidadObjectList GetByMunicipio(IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByMunicipio", Municipio.Identifier());
        }

    

        /// <summary>
        /// Delete Localidad
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_Delete", Clave);
        }

        /// <summary>
        /// Delete Localidad
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_Delete", Clave);
        }

            

        

        /// <summary>
        /// Delete Localidad by ColoniaAggregation
        /// </summary>
        public void DeleteByColoniaAggregation(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_DeleteByColoniaAggregation", Clave);
        }

        /// <summary>
        /// Delete Localidad by ColoniaAggregation
        /// </summary>
        public void DeleteByColoniaAggregation(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_DeleteByColoniaAggregation", Clave);
        }

        /// <summary>
        /// Delete Localidad by ColoniaAggregation
        /// </summary>
        public void DeleteByColoniaAggregation(IUniqueIdentifiable Colonia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_DeleteByColoniaAggregation", Colonia.Identifier());
        }

        /// <summary>
        /// Delete Localidad by ColoniaAggregation
        /// </summary>
        public void DeleteByColoniaAggregation(DbTransaction transaction, IUniqueIdentifiable Colonia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_DeleteByColoniaAggregation", Colonia.Identifier());
        }


    

        /// <summary>
        /// Delete Localidad by Municipio
        /// </summary>
        public void DeleteByMunicipio(System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_DeleteByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// Delete Localidad by Municipio
        /// </summary>
        public void DeleteByMunicipio(DbTransaction transaction, System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_DeleteByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// Delete Localidad by Municipio
        /// </summary>
        public void DeleteByMunicipio(IUniqueIdentifiable Municipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_DeleteByMunicipio", Municipio.Identifier());
        }

        /// <summary>
        /// Delete Localidad by Municipio
        /// </summary>
        public void DeleteByMunicipio(DbTransaction transaction, IUniqueIdentifiable Municipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_DeleteByMunicipio", Municipio.Identifier());
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








