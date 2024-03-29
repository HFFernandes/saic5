
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 17/08/2009 - 04:24 p.m.
// This is a partial class file. The other one is UnidadMapper.cs
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
    public partial class UnidadMapper : BaseGateway<Unidad, UnidadList>, IGenericGateway
    {


        #region "Singleton"

        static UnidadMapper _instance;

        private UnidadMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static UnidadMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new UnidadMapper();
                else {
                    UnidadMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.UnidadMapperSingleton"] as UnidadMapper;
                    if (inst == null) {
                        inst = new UnidadMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.UnidadMapperSingleton", inst);
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
            return typeof(Unidad);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Unidad"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(UnidadMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Unidad entity)
        {
            
            IMappeableUnidadObject Unidad = (IMappeableUnidadObject)entity;
            Unidad.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
reader.GetInt32(2),
reader.GetBoolean(3),
(reader.IsDBNull(4)) ? new System.Nullable<System.Int32>() : reader.GetInt32(4));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(Unidad entity)
        {

            IMappeableUnidadObject Unidad = (IMappeableUnidadObject)entity;
            return Unidad.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(Unidad entity)
        {

            IMappeableUnidadObject Unidad = (IMappeableUnidadObject)entity;
            return Unidad.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(Unidad entity)
        {

            IMappeableUnidadObject Unidad = (IMappeableUnidadObject)entity;
            return Unidad.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(Unidad entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableUnidadObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(Unidad entity)
        {
            
            ((IMappeableUnidad)entity).CompleteEntity();
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
        /// Get a Unidad by execute a SQL Query Text
        /// </summary>
        public Unidad GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a UnidadList by execute a SQL Query Text
        /// </summary>
        public UnidadList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public Unidad GetOne(System.Int32 Clave)
        {
            return base.GetOne(new Unidad(Clave));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public UnidadList GetByCorporacion(DbTransaction transaction, System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// 
        /// </summary>
        public UnidadList GetByCorporacion(DbTransaction transaction, IUniqueIdentifiable Corporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByCorporacion", Corporacion.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public UnidadList GetByMunicipio(DbTransaction transaction, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public UnidadList GetByMunicipio(DbTransaction transaction, IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByMunicipio", Municipio.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public UnidadList GetByCorporacion(System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// 
        /// </summary>
        public UnidadList GetByCorporacion(IUniqueIdentifiable Corporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByCorporacion", Corporacion.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public UnidadList GetByMunicipio(System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public UnidadList GetByMunicipio(IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByMunicipio", Municipio.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Unidad_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_Delete", Clave);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByCorporacion(System.Int32 ClaveCorporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Unidad_DeleteByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByCorporacion(DbTransaction transaction, System.Int32 ClaveCorporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_DeleteByCorporacion", ClaveCorporacion);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByCorporacion(IUniqueIdentifiable Corporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Unidad_DeleteByCorporacion", Corporacion.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByCorporacion(DbTransaction transaction, IUniqueIdentifiable Corporacion)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_DeleteByCorporacion", Corporacion.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMunicipio(System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Unidad_DeleteByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMunicipio(DbTransaction transaction, System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_DeleteByMunicipio", ClaveMunicipio);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMunicipio(IUniqueIdentifiable Municipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Unidad_DeleteByMunicipio", Municipio.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMunicipio(DbTransaction transaction, IUniqueIdentifiable Municipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_DeleteByMunicipio", Municipio.Identifier());
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
    public class UnidadMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.UnidadMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.UnidadMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a UnidadEntity by calling a Stored Procedure
        /// </summary>
        public Entities.Unidad GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a UnidadList by calling a Stored Procedure
        /// </summary>
        public Entities.UnidadList GetByCorporacion(System.Int32 ClaveCorporacion)
        {
            return Instance().GetByCorporacion(ClaveCorporacion);
        }

        /// <summary>
        /// Get a UnidadList by calling a Stored Procedure
        /// </summary>
        public Entities.UnidadList GetByCorporacion(IUniqueIdentifiable Corporacion)
        {
            return Instance().GetByCorporacion(Corporacion);
        }

    

        /// <summary>
        /// Get a UnidadList by calling a Stored Procedure
        /// </summary>
        public Entities.UnidadList GetByMunicipio(System.Int32 ClaveMunicipio)
        {
            return Instance().GetByMunicipio(ClaveMunicipio);
        }

        /// <summary>
        /// Get a UnidadList by calling a Stored Procedure
        /// </summary>
        public Entities.UnidadList GetByMunicipio(IUniqueIdentifiable Municipio)
        {
            return Instance().GetByMunicipio(Municipio);
        }

    

       

        /// <summary>
        /// Delete children for Unidad
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, Unidad entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete Unidad by Corporacion
        /// </summary>
        public void DeleteByCorporacion(System.Int32 ClaveCorporacion)
        {
            Instance().DeleteByCorporacion(ClaveCorporacion);
        }

        /// <summary>
        /// Delete Unidad by Corporacion
        /// </summary>
        public void DeleteByCorporacion(IUniqueIdentifiable Corporacion)
        {
            Instance().DeleteByCorporacion(Corporacion);
        }

    

        /// <summary>
        /// Delete Unidad by Municipio
        /// </summary>
        public void DeleteByMunicipio(System.Int32 ClaveMunicipio)
        {
            Instance().DeleteByMunicipio(ClaveMunicipio);
        }

        /// <summary>
        /// Delete Unidad by Municipio
        /// </summary>
        public void DeleteByMunicipio(IUniqueIdentifiable Municipio)
        {
            Instance().DeleteByMunicipio(Municipio);
        }

    
        /// <summary>
        /// Delete Unidad 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete Unidad 
        /// </summary>
        public void Delete(Entities.Unidad entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save Unidad  
        /// </summary>
        public void Save(Entities.Unidad entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Unidad 
        /// </summary>
        public void Insert(Entities.Unidad entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll Unidad 
        /// </summary>
        public Entities.UnidadList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Unidad 
        /// </summary>
        public void Save(System.Int32 Clave, System.String Codigo, System.Int32 ClaveCorporacion, System.Boolean Activo, System.Int32 ClaveMunicipio){
            Entities.Unidad entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.Codigo = Codigo;
            entity.ClaveCorporacion = ClaveCorporacion;
            entity.Activo = Activo;
            entity.ClaveMunicipio = ClaveMunicipio;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Unidad
        /// </summary>
        public void Insert(System.String Codigo, System.Int32 ClaveCorporacion, System.Boolean Activo, System.Int32 ClaveMunicipio){
            Entities.Unidad entity = new Entities.Unidad();

            entity.Codigo = Codigo;
            entity.ClaveCorporacion = ClaveCorporacion;
            entity.Activo = Activo;
            entity.ClaveMunicipio = ClaveMunicipio;
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
    public partial class UnidadLoader<T> : BaseLoader< T, Unidad, ObjectList<T>>, IGenericGateway where T : Unidad, new()
    {

        #region "Singleton"

        static UnidadLoader<T> _instance;

        private UnidadLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static UnidadLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new UnidadLoader<T>();
                else {
                    UnidadLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.UnidadLoaderSingleton"] as UnidadLoader<T>;
                    if (inst == null) {
                        inst = new UnidadLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.UnidadLoaderSingleton", inst);
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
            return typeof(Unidad);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Unidad"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Unidad entity)
        {
            
            IMappeableUnidadObject Unidad = (IMappeableUnidadObject)entity;
            Unidad.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
reader.GetInt32(2),
reader.GetBoolean(3),
(reader.IsDBNull(4)) ? new System.Nullable<System.Int32>() : reader.GetInt32(4));
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
            
            ((IMappeableUnidad)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a Unidad by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a UnidadList by execute a SQL Query Text
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
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetOne", Clave);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByCorporacion(DbTransaction transaction, System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByCorporacion(DbTransaction transaction, IUniqueIdentifiable Corporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByCorporacion", Corporacion.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMunicipio(DbTransaction transaction, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMunicipio(DbTransaction transaction, IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByMunicipio", Municipio.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByCorporacion(System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByCorporacion(IUniqueIdentifiable Corporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByCorporacion", Corporacion.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMunicipio(System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMunicipio(IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByMunicipio", Municipio.Identifier());
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





