
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 29/07/2009 - 02:18 p.m.
// This is a partial class file. The other one is DenuncianteGateway.cs
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

    public partial class DenuncianteGateway : BaseGateway<DenuncianteObject, DenuncianteObjectList>, IGenericGateway
    {

        #region "Singleton"

        static DenuncianteGateway _instance;

        private DenuncianteGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static DenuncianteGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new DenuncianteGateway();
                else {
                    DenuncianteGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.DenuncianteGatewaySingleton"] as DenuncianteGateway;
                    if (inst == null) {
                        inst = new DenuncianteGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.DenuncianteGatewaySingleton", inst);
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
            get { return "Denunciante"; }
        }

        protected override string RuleName
        {
            get {return typeof(DenuncianteGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, DenuncianteObject entity)
        {
            
            IMappeableDenuncianteObject Denunciante = (IMappeableDenuncianteObject)entity;
            Denunciante.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(DenuncianteObject entity)
        {

            IMappeableDenuncianteObject Denunciante = (IMappeableDenuncianteObject)entity;
            return Denunciante.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(DenuncianteObject entity)
        {

            IMappeableDenuncianteObject Denunciante = (IMappeableDenuncianteObject)entity;
            return Denunciante.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(DenuncianteObject entity)
        {

            IMappeableDenuncianteObject Denunciante = (IMappeableDenuncianteObject)entity;
            return Denunciante.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(DenuncianteObject row, object[] parameters)
        {
            ((IMappeableDenuncianteObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a DenuncianteObject by execute a SQL Query Text
        /// </summary>
        public DenuncianteObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a DenuncianteObjectList by execute a SQL Query Text
        /// </summary>
        public DenuncianteObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a DenuncianteObject by calling a Stored Procedure
        /// </summary>
        public DenuncianteObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new DenuncianteObject(Clave));
        }


        // GetBy Objects and Params
            


        

        

        /// <summary>
        /// Delete Denunciante
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Denunciante_Delete", Clave);
        }

        /// <summary>
        /// Delete Denunciante
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Denunciante_Delete", Clave);
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








