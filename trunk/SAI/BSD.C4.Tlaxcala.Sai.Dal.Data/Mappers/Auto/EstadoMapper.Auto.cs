
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is EstadoMapper.cs
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
    public partial class EstadoMapper : BaseGateway<Estado, EstadoList>, IGenericGateway
    {


        #region "Singleton"

        static EstadoMapper _instance;

        private EstadoMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static EstadoMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new EstadoMapper();
                else {
                    EstadoMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.EstadoMapperSingleton"] as EstadoMapper;
                    if (inst == null) {
                        inst = new EstadoMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.EstadoMapperSingleton", inst);
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
            return typeof(Estado);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Estado"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(EstadoMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Estado entity)
        {
            
            IMappeableEstadoObject Estado = (IMappeableEstadoObject)entity;
            Estado.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(Estado entity)
        {

            IMappeableEstadoObject Estado = (IMappeableEstadoObject)entity;
            return Estado.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(Estado entity)
        {

            IMappeableEstadoObject Estado = (IMappeableEstadoObject)entity;
            return Estado.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(Estado entity)
        {

            IMappeableEstadoObject Estado = (IMappeableEstadoObject)entity;
            return Estado.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(Estado entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableEstadoObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(Estado entity)
        {
            
            ((IMappeableEstado)entity).CompleteEntity();
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
        /// Get a Estado by execute a SQL Query Text
        /// </summary>
        public Estado GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a EstadoList by execute a SQL Query Text
        /// </summary>
        public EstadoList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public Estado GetOne(System.Int32 Clave)
        {
            return base.GetOne(new Estado(Clave));
        }


        // GetOne By Objects and Params
            


        


        

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Estado_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Estado_Delete", Clave);
        }


        // Delete By Objects and Params
            



        


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
    public class EstadoMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.EstadoMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.EstadoMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a EstadoEntity by calling a Stored Procedure
        /// </summary>
        public Entities.Estado GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

       

        /// <summary>
        /// Delete children for Estado
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, Estado entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        
        /// <summary>
        /// Delete Estado 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete Estado 
        /// </summary>
        public void Delete(Entities.Estado entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save Estado  
        /// </summary>
        public void Save(Entities.Estado entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Estado 
        /// </summary>
        public void Insert(Entities.Estado entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll Estado 
        /// </summary>
        public Entities.EstadoList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Estado 
        /// </summary>
        public void Save(System.Int32 Clave, System.String Nombre){
            Entities.Estado entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.Nombre = Nombre;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Estado
        /// </summary>
        public void Insert(System.Int32 Clave, System.String Nombre){
            Entities.Estado entity = new Entities.Estado();

            entity.Clave = Clave;
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
    public partial class EstadoLoader<T> : BaseLoader< T, Estado, ObjectList<T>>, IGenericGateway where T : Estado, new()
    {

        #region "Singleton"

        static EstadoLoader<T> _instance;

        private EstadoLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static EstadoLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new EstadoLoader<T>();
                else {
                    EstadoLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.EstadoLoaderSingleton"] as EstadoLoader<T>;
                    if (inst == null) {
                        inst = new EstadoLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.EstadoLoaderSingleton", inst);
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
            return typeof(Estado);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Estado"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Estado entity)
        {
            
            IMappeableEstadoObject Estado = (IMappeableEstadoObject)entity;
            Estado.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1));
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
            
            ((IMappeableEstado)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a Estado by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a EstadoList by execute a SQL Query Text
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
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Estado_GetOne", Clave);
        }


        // GetOne By Objects and Params
            


        


        

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





