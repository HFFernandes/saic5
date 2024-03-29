
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is PermisoMapper.cs
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
    public partial class PermisoMapper : BaseGateway<PermisoObject, PermisoObjectList>, IGenericGateway
    {


        #region "Singleton"

        static PermisoMapper _instance;

        private PermisoMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PermisoMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PermisoMapper();
                else {
                    PermisoMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.PermisoMapperSingleton"] as PermisoMapper;
                    if (inst == null) {
                        inst = new PermisoMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.PermisoMapperSingleton", inst);
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
            return typeof(PermisoObject);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Permiso"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(PermisoMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PermisoObject entity)
        {
            
            IMappeablePermisoObject Permiso = (IMappeablePermisoObject)entity;
            Permiso.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
reader.GetInt32(2));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(PermisoObject entity)
        {

            IMappeablePermisoObject Permiso = (IMappeablePermisoObject)entity;
            return Permiso.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(PermisoObject entity)
        {

            IMappeablePermisoObject Permiso = (IMappeablePermisoObject)entity;
            return Permiso.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(PermisoObject entity)
        {

            IMappeablePermisoObject Permiso = (IMappeablePermisoObject)entity;
            return Permiso.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(PermisoObject entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeablePermisoObject) entity).UpdateObjectFromOutputParams(parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


          





        /// <summary>
        /// Get a PermisoObject by execute a SQL Query Text
        /// </summary>
        public PermisoObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PermisoObjectList by execute a SQL Query Text
        /// </summary>
        public PermisoObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public PermisoObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new PermisoObject(Clave));
        }


        // GetOne By Objects and Params
            


        


        

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Permiso_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Permiso_Delete", Clave);
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
    public class PermisoMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.PermisoMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.PermisoMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a PermisoEntity by calling a Stored Procedure
        /// </summary>
        public Objects.PermisoObject GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

       

            

        
        /// <summary>
        /// Delete Permiso 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete PermisoObject 
        /// </summary>
        public void Delete(Objects.PermisoObject entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save PermisoObject  
        /// </summary>
        public void Save(Objects.PermisoObject entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PermisoObject 
        /// </summary>
        public void Insert(Objects.PermisoObject entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll PermisoObject 
        /// </summary>
        public Objects.PermisoObjectList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Permiso 
        /// </summary>
        public void Save(System.Int32 Clave, System.String Descripcion, System.Int32 Valor){
            Objects.PermisoObject entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.Descripcion = Descripcion;
            entity.Valor = Valor;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PermisoObject
        /// </summary>
        public void Insert(System.String Descripcion, System.Int32 Valor){
            Objects.PermisoObject entity = new Objects.PermisoObject();

            entity.Descripcion = Descripcion;
            entity.Valor = Valor;
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
    public partial class PermisoLoader<T> : BaseLoader< T, PermisoObject, ObjectList<T>>, IGenericGateway where T : PermisoObject, new()
    {

        #region "Singleton"

        static PermisoLoader<T> _instance;

        private PermisoLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PermisoLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PermisoLoader<T>();
                else {
                    PermisoLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.PermisoLoaderSingleton"] as PermisoLoader<T>;
                    if (inst == null) {
                        inst = new PermisoLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.PermisoLoaderSingleton", inst);
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
            return typeof(PermisoObject);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Permiso"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PermisoObject entity)
        {
            
            IMappeablePermisoObject Permiso = (IMappeablePermisoObject)entity;
            Permiso.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
reader.GetInt32(2));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


        



        /// <summary>
        /// Get a Permiso by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PermisoList by execute a SQL Query Text
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
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Permiso_GetOne", Clave);
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





