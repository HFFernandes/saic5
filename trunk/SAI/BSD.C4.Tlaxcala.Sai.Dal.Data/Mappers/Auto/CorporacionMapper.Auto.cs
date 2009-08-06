
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is CorporacionMapper.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using System;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using Cooperator.Framework.Data;
using Cooperator.Framework.Data.Exceptions;
using Cooperator.Framework.Core;
using System.Data.Common;
using System.Reflection;
using System.Web;
using System.Data;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers
{

    
    /// <summary>
    /// 
    /// </summary>
    public partial class CorporacionMapper : BaseGateway<Corporacion, CorporacionList>, IGenericGateway
    {


        #region "Singleton"

        static CorporacionMapper _instance;

        private CorporacionMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static CorporacionMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new CorporacionMapper();
                else {
                    CorporacionMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.CorporacionMapperSingleton"] as CorporacionMapper;
                    if (inst == null) {
                        inst = new CorporacionMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.CorporacionMapperSingleton", inst);
                    }
                    return inst;
                }
            }
            return _instance;
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        public string[] GetPKPropertiesNames()
        {
            
            string[] s ={"Clave"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(Corporacion);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Corporacion"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(CorporacionMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Corporacion entity)
        {
            
            IMappeableCorporacionObject Corporacion = (IMappeableCorporacionObject)entity;
            Corporacion.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
(reader.IsDBNull(2)) ? new System.Nullable<System.Int32>() : reader.GetInt32(2),
reader.GetBoolean(3),
reader.GetBoolean(4));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(Corporacion entity)
        {

            IMappeableCorporacionObject Corporacion = (IMappeableCorporacionObject)entity;
            return Corporacion.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(Corporacion entity)
        {

            IMappeableCorporacionObject Corporacion = (IMappeableCorporacionObject)entity;
            return Corporacion.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(Corporacion entity)
        {

            IMappeableCorporacionObject Corporacion = (IMappeableCorporacionObject)entity;
            return Corporacion.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(Corporacion entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableCorporacionObject) entity).UpdateObjectFromOutputParams(parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


        


        

        /// <summary>
        /// Complete the aggregations for this entity. 
        /// </summary>
        protected override void CompleteEntity(Corporacion entity)
        {
            
            ((IMappeableCorporacion)entity).CompleteEntity();
        }


        # region CRUD Operations
        

        # endregion

        /// <summary>
        /// Delete children for this entity
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, IUniqueIdentifiable entity)
        {
                        
        }


          





        /// <summary>
        /// Get a Corporacion by execute a SQL Query Text
        /// </summary>
        public Corporacion GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a CorporacionList by execute a SQL Query Text
        /// </summary>
        public CorporacionList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public Corporacion GetOne(System.Int32 Clave)
        {
            return base.GetOne(new Corporacion(Clave));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public CorporacionList GetBySistema(DbTransaction transaction, System.Int32 ClaveSistema)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Corporacion_GetBySistema", ClaveSistema);
        }

        /// <summary>
        /// 
        /// </summary>
        public CorporacionList GetBySistema(DbTransaction transaction, IUniqueIdentifiable Sistema)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Corporacion_GetBySistema", Sistema.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public CorporacionList GetBySistema(System.Int32 ClaveSistema)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Corporacion_GetBySistema", ClaveSistema);
        }

        /// <summary>
        /// 
        /// </summary>
        public CorporacionList GetBySistema(IUniqueIdentifiable Sistema)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Corporacion_GetBySistema", Sistema.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Corporacion_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Corporacion_Delete", Clave);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySistema(System.Int32 ClaveSistema)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Corporacion_DeleteBySistema", ClaveSistema);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySistema(DbTransaction transaction, System.Int32 ClaveSistema)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Corporacion_DeleteBySistema", ClaveSistema);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySistema(IUniqueIdentifiable Sistema)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Corporacion_DeleteBySistema", Sistema.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteBySistema(DbTransaction transaction, IUniqueIdentifiable Sistema)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Corporacion_DeleteBySistema", Sistema.Identifier());
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

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Wrappers
{
    /// <summary>
    /// 
    /// </summary>
    public class CorporacionMapperWrapper
    {

        /// <summary>
        /// 
        /// </summary>
        public string[] GetPKPropertiesNames()
        {
            return Instance().GetPKPropertiesNames();
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return Instance().GetMappingType();
        }



        /// <summary>
        /// 
        /// </summary>
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.CorporacionMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.CorporacionMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a CorporacionEntity by calling a Stored Procedure
        /// </summary>
        public Entities.Corporacion GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a CorporacionList by calling a Stored Procedure
        /// </summary>
        public Entities.CorporacionList GetBySistema(System.Int32 ClaveSistema)
        {
            return Instance().GetBySistema(ClaveSistema);
        }

        /// <summary>
        /// Get a CorporacionList by calling a Stored Procedure
        /// </summary>
        public Entities.CorporacionList GetBySistema(IUniqueIdentifiable Sistema)
        {
            return Instance().GetBySistema(Sistema);
        }

    

       

        /// <summary>
        /// Delete children for Corporacion
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, Corporacion entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete Corporacion by Sistema
        /// </summary>
        public void DeleteBySistema(System.Int32 ClaveSistema)
        {
            Instance().DeleteBySistema(ClaveSistema);
        }

        /// <summary>
        /// Delete Corporacion by Sistema
        /// </summary>
        public void DeleteBySistema(IUniqueIdentifiable Sistema)
        {
            Instance().DeleteBySistema(Sistema);
        }

    
        /// <summary>
        /// Delete Corporacion 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete Corporacion 
        /// </summary>
        public void Delete(Entities.Corporacion entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save Corporacion  
        /// </summary>
        public void Save(Entities.Corporacion entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Corporacion 
        /// </summary>
        public void Insert(Entities.Corporacion entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll Corporacion 
        /// </summary>
        public Entities.CorporacionList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Corporacion 
        /// </summary>
        public void Save(System.Int32 Clave, System.String Descripcion, System.Int32 ClaveSistema, System.Boolean UnidadesVirtuales, System.Boolean Activo){
            Entities.Corporacion entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.Descripcion = Descripcion;
            entity.ClaveSistema = ClaveSistema;
            entity.UnidadesVirtuales = UnidadesVirtuales;
            entity.Activo = Activo;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Corporacion
        /// </summary>
        public void Insert(System.String Descripcion, System.Int32 ClaveSistema, System.Boolean UnidadesVirtuales, System.Boolean Activo){
            Entities.Corporacion entity = new Entities.Corporacion();

            entity.Descripcion = Descripcion;
            entity.ClaveSistema = ClaveSistema;
            entity.UnidadesVirtuales = UnidadesVirtuales;
            entity.Activo = Activo;
            Instance().Insert(entity);
        }


        //Database Queries 
        


    }
}





namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Loaders
{

    /// <summary>
    /// 
    /// </summary>
    public partial class CorporacionLoader<T> : BaseLoader< T, Corporacion, ObjectList<T>>, IGenericGateway where T : Corporacion, new()
    {

        #region "Singleton"

        static CorporacionLoader<T> _instance;

        private CorporacionLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static CorporacionLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new CorporacionLoader<T>();
                else {
                    CorporacionLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.CorporacionLoaderSingleton"] as CorporacionLoader<T>;
                    if (inst == null) {
                        inst = new CorporacionLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.CorporacionLoaderSingleton", inst);
                    }
                    return inst;
                }
            }
            return _instance;
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        public string[] GetPKPropertiesNames()
        {
            
            string[] s ={"Clave"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(Corporacion);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Corporacion"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Corporacion entity)
        {
            
            IMappeableCorporacionObject Corporacion = (IMappeableCorporacionObject)entity;
            Corporacion.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
(reader.IsDBNull(2)) ? new System.Nullable<System.Int32>() : reader.GetInt32(2),
reader.GetBoolean(3),
reader.GetBoolean(4));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


        
    

        

        /// <summary>
        /// Complete the aggregations for this entity. 
        /// </summary>
        protected override void CompleteEntity(T entity)
        {
            
            ((IMappeableCorporacion)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a Corporacion by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a CorporacionList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 Clave)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Corporacion_GetOne", Clave);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySistema(DbTransaction transaction, System.Int32 ClaveSistema)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Corporacion_GetBySistema", ClaveSistema);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySistema(DbTransaction transaction, IUniqueIdentifiable Sistema)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Corporacion_GetBySistema", Sistema.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySistema(System.Int32 ClaveSistema)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Corporacion_GetBySistema", ClaveSistema);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetBySistema(IUniqueIdentifiable Sistema)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Corporacion_GetBySistema", Sistema.Identifier());
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




