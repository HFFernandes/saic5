
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 29/07/2009 - 02:18 p.m.
// This is a partial class file. The other one is UsuarioGateway.cs
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

    public partial class UsuarioGateway : BaseGateway<UsuarioObject, UsuarioObjectList>, IGenericGateway
    {

        #region "Singleton"

        static UsuarioGateway _instance;

        private UsuarioGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static UsuarioGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new UsuarioGateway();
                else {
                    UsuarioGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.UsuarioGatewaySingleton"] as UsuarioGateway;
                    if (inst == null) {
                        inst = new UsuarioGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.UsuarioGatewaySingleton", inst);
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
            get { return "Usuario"; }
        }

        protected override string RuleName
        {
            get {return typeof(UsuarioGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, UsuarioObject entity)
        {
            
            IMappeableUsuarioObject Usuario = (IMappeableUsuarioObject)entity;
            Usuario.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? new System.Nullable<System.Boolean>() : reader.GetBoolean(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? new System.Nullable<System.Boolean>() : reader.GetBoolean(5));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(UsuarioObject entity)
        {

            IMappeableUsuarioObject Usuario = (IMappeableUsuarioObject)entity;
            return Usuario.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(UsuarioObject entity)
        {

            IMappeableUsuarioObject Usuario = (IMappeableUsuarioObject)entity;
            return Usuario.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(UsuarioObject entity)
        {

            IMappeableUsuarioObject Usuario = (IMappeableUsuarioObject)entity;
            return Usuario.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(UsuarioObject row, object[] parameters)
        {
            ((IMappeableUsuarioObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a UsuarioObject by execute a SQL Query Text
        /// </summary>
        public UsuarioObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a UsuarioObjectList by execute a SQL Query Text
        /// </summary>
        public UsuarioObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a UsuarioObject by calling a Stored Procedure
        /// </summary>
        public UsuarioObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new UsuarioObject(Clave));
        }


        // GetBy Objects and Params
            


        

        

        /// <summary>
        /// Delete Usuario
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Usuario_Delete", Clave);
        }

        /// <summary>
        /// Delete Usuario
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Usuario_Delete", Clave);
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








