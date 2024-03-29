
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is CodigoPostalMapper.cs
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
    public partial class CodigoPostalMapper : BaseGateway<CodigoPostalObject, CodigoPostalObjectList>, IGenericGateway
    {


        #region "Singleton"

        static CodigoPostalMapper _instance;

        private CodigoPostalMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static CodigoPostalMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new CodigoPostalMapper();
                else {
                    CodigoPostalMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.CodigoPostalMapperSingleton"] as CodigoPostalMapper;
                    if (inst == null) {
                        inst = new CodigoPostalMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.CodigoPostalMapperSingleton", inst);
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
            return typeof(CodigoPostalObject);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "CodigoPostal"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(CodigoPostalMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, CodigoPostalObject entity)
        {
            
            IMappeableCodigoPostalObject CodigoPostal = (IMappeableCodigoPostalObject)entity;
            CodigoPostal.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(CodigoPostalObject entity)
        {

            IMappeableCodigoPostalObject CodigoPostal = (IMappeableCodigoPostalObject)entity;
            return CodigoPostal.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(CodigoPostalObject entity)
        {

            IMappeableCodigoPostalObject CodigoPostal = (IMappeableCodigoPostalObject)entity;
            return CodigoPostal.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(CodigoPostalObject entity)
        {

            IMappeableCodigoPostalObject CodigoPostal = (IMappeableCodigoPostalObject)entity;
            return CodigoPostal.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(CodigoPostalObject entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableCodigoPostalObject) entity).UpdateObjectFromOutputParams(parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


          





        /// <summary>
        /// Get a CodigoPostalObject by execute a SQL Query Text
        /// </summary>
        public CodigoPostalObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a CodigoPostalObjectList by execute a SQL Query Text
        /// </summary>
        public CodigoPostalObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public CodigoPostalObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new CodigoPostalObject(Clave));
        }


        // GetOne By Objects and Params
            


        


        

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "CodigoPostal_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "CodigoPostal_Delete", Clave);
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
    public class CodigoPostalMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.CodigoPostalMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.CodigoPostalMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a CodigoPostalEntity by calling a Stored Procedure
        /// </summary>
        public Objects.CodigoPostalObject GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

       

            

        
        /// <summary>
        /// Delete CodigoPostal 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete CodigoPostalObject 
        /// </summary>
        public void Delete(Objects.CodigoPostalObject entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save CodigoPostalObject  
        /// </summary>
        public void Save(Objects.CodigoPostalObject entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert CodigoPostalObject 
        /// </summary>
        public void Insert(Objects.CodigoPostalObject entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll CodigoPostalObject 
        /// </summary>
        public Objects.CodigoPostalObjectList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save CodigoPostal 
        /// </summary>
        public void Save(System.Int32 Clave, System.String Valor){
            Objects.CodigoPostalObject entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.Valor = Valor;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert CodigoPostalObject
        /// </summary>
        public void Insert(System.Int32 Clave, System.String Valor){
            Objects.CodigoPostalObject entity = new Objects.CodigoPostalObject();

            entity.Clave = Clave;
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
    public partial class CodigoPostalLoader<T> : BaseLoader< T, CodigoPostalObject, ObjectList<T>>, IGenericGateway where T : CodigoPostalObject, new()
    {

        #region "Singleton"

        static CodigoPostalLoader<T> _instance;

        private CodigoPostalLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static CodigoPostalLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new CodigoPostalLoader<T>();
                else {
                    CodigoPostalLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.CodigoPostalLoaderSingleton"] as CodigoPostalLoader<T>;
                    if (inst == null) {
                        inst = new CodigoPostalLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.CodigoPostalLoaderSingleton", inst);
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
            return typeof(CodigoPostalObject);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "CodigoPostal"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, CodigoPostalObject entity)
        {
            
            IMappeableCodigoPostalObject CodigoPostal = (IMappeableCodigoPostalObject)entity;
            CodigoPostal.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


        



        /// <summary>
        /// Get a CodigoPostal by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a CodigoPostalList by execute a SQL Query Text
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
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "CodigoPostal_GetOne", Clave);
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





