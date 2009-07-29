
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is ColoniaGateway.cs
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

    public partial class ColoniaGateway : BaseGateway<ColoniaObject, ColoniaObjectList>, IGenericGateway
    {

        #region "Singleton"

        static ColoniaGateway _instance;

        private ColoniaGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static ColoniaGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new ColoniaGateway();
                else {
                    ColoniaGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.ColoniaGatewaySingleton"] as ColoniaGateway;
                    if (inst == null) {
                        inst = new ColoniaGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.ColoniaGatewaySingleton", inst);
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
            get { return "Colonia"; }
        }

        protected override string RuleName
        {
            get {return typeof(ColoniaGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, ColoniaObject entity)
        {
            
            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            Colonia.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
reader.GetInt32(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(ColoniaObject entity)
        {

            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            return Colonia.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(ColoniaObject entity)
        {

            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            return Colonia.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(ColoniaObject entity)
        {

            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            return Colonia.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(ColoniaObject row, object[] parameters)
        {
            ((IMappeableColoniaObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a ColoniaObject by execute a SQL Query Text
        /// </summary>
        public ColoniaObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a ColoniaObjectList by execute a SQL Query Text
        /// </summary>
        public ColoniaObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a ColoniaObject by calling a Stored Procedure
        /// </summary>
        public ColoniaObject GetOne(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad)
        {
            return base.GetOne(new ColoniaObject(Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a ColoniaObjectList by calling a Stored Procedure
        /// </summary>
        public ColoniaObjectList GetByLocalidad(DbTransaction transaction,System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_GetByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// Get a ColoniaObjectList by calling a Stored Procedure
        /// </summary>
        public ColoniaObjectList GetByLocalidad(DbTransaction transaction, IUniqueIdentifiable Localidad)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_GetByLocalidad", Localidad.Identifier());
        }

    

        

        /// <summary>
        /// Get a ColoniaObjectList by calling a Stored Procedure
        /// </summary>
        public ColoniaObjectList GetByLocalidad(System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Colonia_GetByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// Get a ColoniaObjectList by calling a Stored Procedure
        /// </summary>
        public ColoniaObjectList GetByLocalidad(IUniqueIdentifiable Localidad)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Colonia_GetByLocalidad", Localidad.Identifier());
        }

    

        /// <summary>
        /// Delete Colonia
        /// </summary>
        public void Delete(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Colonia_Delete", Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad);
        }

        /// <summary>
        /// Delete Colonia
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_Delete", Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad);
        }

            

        

        /// <summary>
        /// Delete Colonia by Localidad
        /// </summary>
        public void DeleteByLocalidad(System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Colonia_DeleteByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// Delete Colonia by Localidad
        /// </summary>
        public void DeleteByLocalidad(DbTransaction transaction, System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_DeleteByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// Delete Colonia by Localidad
        /// </summary>
        public void DeleteByLocalidad(IUniqueIdentifiable Localidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Colonia_DeleteByLocalidad", Localidad.Identifier());
        }

        /// <summary>
        /// Delete Colonia by Localidad
        /// </summary>
        public void DeleteByLocalidad(DbTransaction transaction, IUniqueIdentifiable Localidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_DeleteByLocalidad", Localidad.Identifier());
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








