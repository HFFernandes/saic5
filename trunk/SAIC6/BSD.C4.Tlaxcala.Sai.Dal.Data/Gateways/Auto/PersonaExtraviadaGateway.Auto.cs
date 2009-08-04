
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 01:50 p.m.
// This is a partial class file. The other one is PersonaExtraviadaGateway.cs
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

    public partial class PersonaExtraviadaGateway : BaseGateway<PersonaExtraviadaObject, PersonaExtraviadaObjectList>, IGenericGateway
    {

        #region "Singleton"

        static PersonaExtraviadaGateway _instance;

        private PersonaExtraviadaGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static PersonaExtraviadaGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PersonaExtraviadaGateway();
                else {
                    PersonaExtraviadaGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.PersonaExtraviadaGatewaySingleton"] as PersonaExtraviadaGateway;
                    if (inst == null) {
                        inst = new PersonaExtraviadaGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.PersonaExtraviadaGatewaySingleton", inst);
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
            get { return "PersonaExtraviada"; }
        }

        protected override string RuleName
        {
            get {return typeof(PersonaExtraviadaGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PersonaExtraviadaObject entity)
        {
            
            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            PersonaExtraviada.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
reader.GetDateTime(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? "" : reader.GetString(5),
(reader.IsDBNull(6)) ? new System.Nullable<System.Int32>() : reader.GetInt32(6),
(reader.IsDBNull(7)) ? "" : reader.GetString(7),
(reader.IsDBNull(8)) ? new System.Nullable<System.Double>() : reader.GetDouble(8),
(reader.IsDBNull(9)) ? "" : reader.GetString(9),
(reader.IsDBNull(10)) ? "" : reader.GetString(10),
(reader.IsDBNull(11)) ? "" : reader.GetString(11),
(reader.IsDBNull(12)) ? "" : reader.GetString(12),
(reader.IsDBNull(13)) ? "" : reader.GetString(13),
(reader.IsDBNull(14)) ? "" : reader.GetString(14),
(reader.IsDBNull(15)) ? "" : reader.GetString(15),
(reader.IsDBNull(16)) ? "" : reader.GetString(16),
(reader.IsDBNull(17)) ? "" : reader.GetString(17),
(reader.IsDBNull(18)) ? "" : reader.GetString(18),
(reader.IsDBNull(19)) ? "" : reader.GetString(19),
(reader.IsDBNull(20)) ? "" : reader.GetString(20),
(reader.IsDBNull(21)) ? "" : reader.GetString(21));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(PersonaExtraviadaObject entity)
        {

            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            return PersonaExtraviada.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(PersonaExtraviadaObject entity)
        {

            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            return PersonaExtraviada.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(PersonaExtraviadaObject entity)
        {

            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            return PersonaExtraviada.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(PersonaExtraviadaObject row, object[] parameters)
        {
            ((IMappeablePersonaExtraviadaObject) row).UpdateObjectFromOutputParams(parameters);
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
        /// Get a PersonaExtraviadaObject by execute a SQL Query Text
        /// </summary>
        public PersonaExtraviadaObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PersonaExtraviadaObjectList by execute a SQL Query Text
        /// </summary>
        public PersonaExtraviadaObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a PersonaExtraviadaObject by calling a Stored Procedure
        /// </summary>
        public PersonaExtraviadaObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new PersonaExtraviadaObject(Clave));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a PersonaExtraviadaObjectList by calling a Stored Procedure
        /// </summary>
        public PersonaExtraviadaObjectList GetByIncidencia(DbTransaction transaction,System.Int32 Folio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Folio);
        }

        /// <summary>
        /// Get a PersonaExtraviadaObjectList by calling a Stored Procedure
        /// </summary>
        public PersonaExtraviadaObjectList GetByIncidencia(DbTransaction transaction, IUniqueIdentifiable Incidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Incidencia.Identifier());
        }

    

        

        /// <summary>
        /// Get a PersonaExtraviadaObjectList by calling a Stored Procedure
        /// </summary>
        public PersonaExtraviadaObjectList GetByIncidencia(System.Int32 Folio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Folio);
        }

        /// <summary>
        /// Get a PersonaExtraviadaObjectList by calling a Stored Procedure
        /// </summary>
        public PersonaExtraviadaObjectList GetByIncidencia(IUniqueIdentifiable Incidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Incidencia.Identifier());
        }

    

        /// <summary>
        /// Delete PersonaExtraviada
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_Delete", Clave);
        }

        /// <summary>
        /// Delete PersonaExtraviada
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_Delete", Clave);
        }

            

        

        /// <summary>
        /// Delete PersonaExtraviada by Incidencia
        /// </summary>
        public void DeleteByIncidencia(System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_DeleteByIncidencia", Folio);
        }

        /// <summary>
        /// Delete PersonaExtraviada by Incidencia
        /// </summary>
        public void DeleteByIncidencia(DbTransaction transaction, System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_DeleteByIncidencia", Folio);
        }

        /// <summary>
        /// Delete PersonaExtraviada by Incidencia
        /// </summary>
        public void DeleteByIncidencia(IUniqueIdentifiable Incidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_DeleteByIncidencia", Incidencia.Identifier());
        }

        /// <summary>
        /// Delete PersonaExtraviada by Incidencia
        /// </summary>
        public void DeleteByIncidencia(DbTransaction transaction, IUniqueIdentifiable Incidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_DeleteByIncidencia", Incidencia.Identifier());
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








