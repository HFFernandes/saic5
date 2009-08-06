
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 05/08/2009 - 08:55 p.m.
// This is a partial class file. The other one is LocalidadMapper.cs
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
    public partial class LocalidadMapper : BaseGateway<Localidad, LocalidadList>, IGenericGateway
    {


        #region "Singleton"

        static LocalidadMapper _instance;

        private LocalidadMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static LocalidadMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new LocalidadMapper();
                else {
                    LocalidadMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.LocalidadMapperSingleton"] as LocalidadMapper;
                    if (inst == null) {
                        inst = new LocalidadMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.LocalidadMapperSingleton", inst);
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
            return typeof(Localidad);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Localidad"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(LocalidadMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Localidad entity)
        {
            
            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            Localidad.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(Localidad entity)
        {

            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            return Localidad.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(Localidad entity)
        {

            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            return Localidad.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(Localidad entity)
        {

            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            return Localidad.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(Localidad entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableLocalidadObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(Localidad entity)
        {
            
            ((IMappeableLocalidad)entity).CompleteEntity();
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
        /// Get a Localidad by execute a SQL Query Text
        /// </summary>
        public Localidad GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a LocalidadList by execute a SQL Query Text
        /// </summary>
        public LocalidadList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public Localidad GetOne(System.Int32 Clave)
        {
            return base.GetOne(new Localidad(Clave));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public LocalidadList GetByColoniaAggregation(DbTransaction transaction, System.Int32 Clave)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public LocalidadList GetByColoniaAggregation(DbTransaction transaction, IUniqueIdentifiable Colonia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Colonia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public LocalidadList GetByMunicipio(DbTransaction transaction, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public LocalidadList GetByMunicipio(DbTransaction transaction, IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByMunicipio", Municipio.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public LocalidadList GetByColoniaAggregation(System.Int32 Clave)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public LocalidadList GetByColoniaAggregation(IUniqueIdentifiable Colonia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Colonia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public LocalidadList GetByMunicipio(System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public LocalidadList GetByMunicipio(IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByMunicipio", Municipio.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_Delete", Clave);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByColoniaAggregation(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_DeleteByColoniaAggregation", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByColoniaAggregation(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_DeleteByColoniaAggregation", Clave);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByColoniaAggregation(IUniqueIdentifiable Colonia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_DeleteByColoniaAggregation", Colonia.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByColoniaAggregation(DbTransaction transaction, IUniqueIdentifiable Colonia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_DeleteByColoniaAggregation", Colonia.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMunicipio(System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_DeleteByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMunicipio(DbTransaction transaction, System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_DeleteByMunicipio", ClaveMunicipio);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByMunicipio(IUniqueIdentifiable Municipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Localidad_DeleteByMunicipio", Municipio.Identifier());
        }

        /// <summary>
        /// 
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

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Wrappers
{
    /// <summary>
    /// 
    /// </summary>
    public class LocalidadMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.LocalidadMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.LocalidadMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a LocalidadEntity by calling a Stored Procedure
        /// </summary>
        public Entities.Localidad GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a LocalidadList by calling a Stored Procedure
        /// </summary>
        public Entities.LocalidadList GetByColoniaAggregation(System.Int32 Clave)
        {
            return Instance().GetByColoniaAggregation(Clave);
        }

        /// <summary>
        /// Get a LocalidadList by calling a Stored Procedure
        /// </summary>
        public Entities.LocalidadList GetByColoniaAggregation(IUniqueIdentifiable Colonia)
        {
            return Instance().GetByColoniaAggregation(Colonia);
        }

    

        /// <summary>
        /// Get a LocalidadList by calling a Stored Procedure
        /// </summary>
        public Entities.LocalidadList GetByMunicipio(System.Int32 ClaveMunicipio)
        {
            return Instance().GetByMunicipio(ClaveMunicipio);
        }

        /// <summary>
        /// Get a LocalidadList by calling a Stored Procedure
        /// </summary>
        public Entities.LocalidadList GetByMunicipio(IUniqueIdentifiable Municipio)
        {
            return Instance().GetByMunicipio(Municipio);
        }

    

       

        /// <summary>
        /// Delete children for Localidad
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, Localidad entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete Localidad by ColoniaAggregation
        /// </summary>
        public void DeleteByColoniaAggregation(System.Int32 Clave)
        {
            Instance().DeleteByColoniaAggregation(Clave);
        }

        /// <summary>
        /// Delete Localidad by ColoniaAggregation
        /// </summary>
        public void DeleteByColoniaAggregation(IUniqueIdentifiable Colonia)
        {
            Instance().DeleteByColoniaAggregation(Colonia);
        }

    

        /// <summary>
        /// Delete Localidad by Municipio
        /// </summary>
        public void DeleteByMunicipio(System.Int32 ClaveMunicipio)
        {
            Instance().DeleteByMunicipio(ClaveMunicipio);
        }

        /// <summary>
        /// Delete Localidad by Municipio
        /// </summary>
        public void DeleteByMunicipio(IUniqueIdentifiable Municipio)
        {
            Instance().DeleteByMunicipio(Municipio);
        }

    
        /// <summary>
        /// Delete Localidad 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete Localidad 
        /// </summary>
        public void Delete(Entities.Localidad entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save Localidad  
        /// </summary>
        public void Save(Entities.Localidad entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Localidad 
        /// </summary>
        public void Insert(Entities.Localidad entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll Localidad 
        /// </summary>
        public Entities.LocalidadList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Localidad 
        /// </summary>
        public void Save(System.Int32 Clave, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidadCartografia, System.String Nombre){
            Entities.Localidad entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.ClaveMunicipio = ClaveMunicipio;
            entity.ClaveLocalidadCartografia = ClaveLocalidadCartografia;
            entity.Nombre = Nombre;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Localidad
        /// </summary>
        public void Insert(System.Int32 Clave, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidadCartografia, System.String Nombre){
            Entities.Localidad entity = new Entities.Localidad();

            entity.Clave = Clave;
            entity.ClaveMunicipio = ClaveMunicipio;
            entity.ClaveLocalidadCartografia = ClaveLocalidadCartografia;
            entity.Nombre = Nombre;
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
    public partial class LocalidadLoader<T> : BaseLoader< T, Localidad, ObjectList<T>>, IGenericGateway where T : Localidad, new()
    {

        #region "Singleton"

        static LocalidadLoader<T> _instance;

        private LocalidadLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static LocalidadLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new LocalidadLoader<T>();
                else {
                    LocalidadLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.LocalidadLoaderSingleton"] as LocalidadLoader<T>;
                    if (inst == null) {
                        inst = new LocalidadLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.LocalidadLoaderSingleton", inst);
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
            return typeof(Localidad);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Localidad"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Localidad entity)
        {
            
            IMappeableLocalidadObject Localidad = (IMappeableLocalidadObject)entity;
            Localidad.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3));
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
            
            ((IMappeableLocalidad)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a Localidad by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a LocalidadList by execute a SQL Query Text
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
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetOne", Clave);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByColoniaAggregation(DbTransaction transaction, System.Int32 Clave)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByColoniaAggregation(DbTransaction transaction, IUniqueIdentifiable Colonia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Colonia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMunicipio(DbTransaction transaction, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMunicipio(DbTransaction transaction, IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Localidad_GetByMunicipio", Municipio.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByColoniaAggregation(System.Int32 Clave)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByColoniaAggregation(IUniqueIdentifiable Colonia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByColoniaAggregation", Colonia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMunicipio(System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByMunicipio", ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByMunicipio(IUniqueIdentifiable Municipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Localidad_GetByMunicipio", Municipio.Identifier());
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





