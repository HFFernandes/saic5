
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is MunicipioMapper.cs
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
    public partial class MunicipioMapper : BaseGateway<Municipio, MunicipioList>, IGenericGateway
    {


        #region "Singleton"

        static MunicipioMapper _instance;

        private MunicipioMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static MunicipioMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new MunicipioMapper();
                else {
                    MunicipioMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.MunicipioMapperSingleton"] as MunicipioMapper;
                    if (inst == null) {
                        inst = new MunicipioMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.MunicipioMapperSingleton", inst);
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
            
            string[] s ={"Clave","ClaveEstado"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(Municipio);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Municipio"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(MunicipioMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Municipio entity)
        {
            
            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            Municipio.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(Municipio entity)
        {

            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            return Municipio.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(Municipio entity)
        {

            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            return Municipio.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(Municipio entity)
        {

            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            return Municipio.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(Municipio entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableMunicipioObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(Municipio entity)
        {
            
            ((IMappeableMunicipio)entity).CompleteEntity();
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
        /// Get a Municipio by execute a SQL Query Text
        /// </summary>
        public Municipio GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a MunicipioList by execute a SQL Query Text
        /// </summary>
        public MunicipioList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public Municipio GetOne(System.Int32 Clave, System.Int32 ClaveEstado)
        {
            return base.GetOne(new Municipio(Clave, ClaveEstado));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public MunicipioList GetByEstado(DbTransaction transaction, System.Int32 ClaveEstado)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_GetByEstado", ClaveEstado);
        }

        /// <summary>
        /// 
        /// </summary>
        public MunicipioList GetByEstado(DbTransaction transaction, IUniqueIdentifiable Estado)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_GetByEstado", Estado.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public MunicipioList GetByEstado(System.Int32 ClaveEstado)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Municipio_GetByEstado", ClaveEstado);
        }

        /// <summary>
        /// 
        /// </summary>
        public MunicipioList GetByEstado(IUniqueIdentifiable Estado)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Municipio_GetByEstado", Estado.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave, System.Int32 ClaveEstado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Municipio_Delete", Clave, ClaveEstado);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave, System.Int32 ClaveEstado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_Delete", Clave, ClaveEstado);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByEstado(System.Int32 ClaveEstado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Municipio_DeleteByEstado", ClaveEstado);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByEstado(DbTransaction transaction, System.Int32 ClaveEstado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_DeleteByEstado", ClaveEstado);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByEstado(IUniqueIdentifiable Estado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Municipio_DeleteByEstado", Estado.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByEstado(DbTransaction transaction, IUniqueIdentifiable Estado)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_DeleteByEstado", Estado.Identifier());
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
    public class MunicipioMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.MunicipioMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.MunicipioMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a MunicipioEntity by calling a Stored Procedure
        /// </summary>
        public Entities.Municipio GetOne(System.Int32 Clave, System.Int32 ClaveEstado) {
            return Instance().GetOne( Clave, ClaveEstado);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a MunicipioList by calling a Stored Procedure
        /// </summary>
        public Entities.MunicipioList GetByEstado(System.Int32 ClaveEstado)
        {
            return Instance().GetByEstado(ClaveEstado);
        }

        /// <summary>
        /// Get a MunicipioList by calling a Stored Procedure
        /// </summary>
        public Entities.MunicipioList GetByEstado(IUniqueIdentifiable Estado)
        {
            return Instance().GetByEstado(Estado);
        }

    

       

        /// <summary>
        /// Delete children for Municipio
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, Municipio entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete Municipio by Estado
        /// </summary>
        public void DeleteByEstado(System.Int32 ClaveEstado)
        {
            Instance().DeleteByEstado(ClaveEstado);
        }

        /// <summary>
        /// Delete Municipio by Estado
        /// </summary>
        public void DeleteByEstado(IUniqueIdentifiable Estado)
        {
            Instance().DeleteByEstado(Estado);
        }

    
        /// <summary>
        /// Delete Municipio 
        /// </summary>
        public void Delete(System.Int32 Clave, System.Int32 ClaveEstado){
            Instance().Delete(Clave, ClaveEstado);
        }

        /// <summary>
        /// Delete Municipio 
        /// </summary>
        public void Delete(Entities.Municipio entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save Municipio  
        /// </summary>
        public void Save(Entities.Municipio entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Municipio 
        /// </summary>
        public void Insert(Entities.Municipio entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll Municipio 
        /// </summary>
        public Entities.MunicipioList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Municipio 
        /// </summary>
        public void Save(System.Int32 Clave, System.Int32 ClaveEstado, System.String Nombre){
            Entities.Municipio entity = Instance().GetOne(Clave, ClaveEstado);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}, {2} = {3}", "Clave", Clave, "ClaveEstado", ClaveEstado));

            entity.Nombre = Nombre;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Municipio
        /// </summary>
        public void Insert(System.Int32 Clave, System.Int32 ClaveEstado, System.String Nombre){
            Entities.Municipio entity = new Entities.Municipio();

            entity.Clave = Clave;
            entity.ClaveEstado = ClaveEstado;
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
    public partial class MunicipioLoader<T> : BaseLoader< T, Municipio, ObjectList<T>>, IGenericGateway where T : Municipio, new()
    {

        #region "Singleton"

        static MunicipioLoader<T> _instance;

        private MunicipioLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static MunicipioLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new MunicipioLoader<T>();
                else {
                    MunicipioLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.MunicipioLoaderSingleton"] as MunicipioLoader<T>;
                    if (inst == null) {
                        inst = new MunicipioLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.MunicipioLoaderSingleton", inst);
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
            
            string[] s ={"Clave","ClaveEstado"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(Municipio);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Municipio"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Municipio entity)
        {
            
            IMappeableMunicipioObject Municipio = (IMappeableMunicipioObject)entity;
            Municipio.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2));
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
            
            ((IMappeableMunicipio)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a Municipio by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a MunicipioList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 Clave, System.Int32 ClaveEstado)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Municipio_GetOne", Clave, ClaveEstado);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByEstado(DbTransaction transaction, System.Int32 ClaveEstado)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_GetByEstado", ClaveEstado);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByEstado(DbTransaction transaction, IUniqueIdentifiable Estado)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Municipio_GetByEstado", Estado.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByEstado(System.Int32 ClaveEstado)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Municipio_GetByEstado", ClaveEstado);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByEstado(IUniqueIdentifiable Estado)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Municipio_GetByEstado", Estado.Identifier());
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





