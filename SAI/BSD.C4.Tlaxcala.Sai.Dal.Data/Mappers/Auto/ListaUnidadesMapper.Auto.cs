
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is ListaUnidadesMapper.cs
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
    public partial class ListaUnidadesMapper : BaseGateway<ListaUnidades, ListaUnidadesList>, IGenericGateway
    {


        #region "Singleton"

        static ListaUnidadesMapper _instance;

        private ListaUnidadesMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static ListaUnidadesMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new ListaUnidadesMapper();
                else {
                    ListaUnidadesMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.ListaUnidadesMapperSingleton"] as ListaUnidadesMapper;
                    if (inst == null) {
                        inst = new ListaUnidadesMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.ListaUnidadesMapperSingleton", inst);
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
            return typeof(ListaUnidades);
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
            get {return typeof(ListaUnidadesMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, ListaUnidades entity)
        {
            
            IMappeableListaUnidadesObject ListaUnidades = (IMappeableListaUnidadesObject)entity;
            ListaUnidades.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
reader.GetInt32(2),
reader.GetBoolean(3));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(ListaUnidades entity)
        {

            IMappeableListaUnidadesObject ListaUnidades = (IMappeableListaUnidadesObject)entity;
            return ListaUnidades.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(ListaUnidades entity)
        {

            IMappeableListaUnidadesObject ListaUnidades = (IMappeableListaUnidadesObject)entity;
            return ListaUnidades.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(ListaUnidades entity)
        {

            IMappeableListaUnidadesObject ListaUnidades = (IMappeableListaUnidadesObject)entity;
            return ListaUnidades.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(ListaUnidades entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableListaUnidadesObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(ListaUnidades entity)
        {
            
            ((IMappeableListaUnidades)entity).CompleteEntity();
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
        /// Get a ListaUnidades by execute a SQL Query Text
        /// </summary>
        public ListaUnidades GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a ListaUnidadesList by execute a SQL Query Text
        /// </summary>
        public ListaUnidadesList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public ListaUnidades GetOne(System.Int32 Clave)
        {
            return base.GetOne(new ListaUnidades(Clave));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesList GetByCorporacion(DbTransaction transaction, System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesList GetByCorporacion(DbTransaction transaction, IUniqueIdentifiable Corporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Unidad_GetByCorporacion", Corporacion.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesList GetByCorporacion(System.Int32 ClaveCorporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByCorporacion", ClaveCorporacion);
        }

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesList GetByCorporacion(IUniqueIdentifiable Corporacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Unidad_GetByCorporacion", Corporacion.Identifier());
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
    public class ListaUnidadesMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.ListaUnidadesMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.ListaUnidadesMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a ListaUnidadesEntity by calling a Stored Procedure
        /// </summary>
        public Entities.ListaUnidades GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a ListaUnidadesList by calling a Stored Procedure
        /// </summary>
        public Entities.ListaUnidadesList GetByCorporacion(System.Int32 ClaveCorporacion)
        {
            return Instance().GetByCorporacion(ClaveCorporacion);
        }

        /// <summary>
        /// Get a ListaUnidadesList by calling a Stored Procedure
        /// </summary>
        public Entities.ListaUnidadesList GetByCorporacion(IUniqueIdentifiable Corporacion)
        {
            return Instance().GetByCorporacion(Corporacion);
        }

    

       

        /// <summary>
        /// Delete children for ListaUnidades
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, ListaUnidades entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete ListaUnidades by Corporacion
        /// </summary>
        public void DeleteByCorporacion(System.Int32 ClaveCorporacion)
        {
            Instance().DeleteByCorporacion(ClaveCorporacion);
        }

        /// <summary>
        /// Delete ListaUnidades by Corporacion
        /// </summary>
        public void DeleteByCorporacion(IUniqueIdentifiable Corporacion)
        {
            Instance().DeleteByCorporacion(Corporacion);
        }

    
        /// <summary>
        /// Delete ListaUnidades 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete ListaUnidades 
        /// </summary>
        public void Delete(Entities.ListaUnidades entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save ListaUnidades  
        /// </summary>
        public void Save(Entities.ListaUnidades entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert ListaUnidades 
        /// </summary>
        public void Insert(Entities.ListaUnidades entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll ListaUnidades 
        /// </summary>
        public Entities.ListaUnidadesList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save ListaUnidades 
        /// </summary>
        public void Save(System.Int32 Clave, System.String Codigo, System.Int32 ClaveCorporacion, System.Boolean Activo){
            Entities.ListaUnidades entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.Codigo = Codigo;
            entity.ClaveCorporacion = ClaveCorporacion;
            entity.Activo = Activo;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert ListaUnidades
        /// </summary>
        public void Insert(System.String Codigo, System.Int32 ClaveCorporacion, System.Boolean Activo){
            Entities.ListaUnidades entity = new Entities.ListaUnidades();

            entity.Codigo = Codigo;
            entity.ClaveCorporacion = ClaveCorporacion;
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
    public partial class ListaUnidadesLoader<T> : BaseLoader< T, ListaUnidades, ObjectList<T>>, IGenericGateway where T : ListaUnidades, new()
    {

        #region "Singleton"

        static ListaUnidadesLoader<T> _instance;

        private ListaUnidadesLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static ListaUnidadesLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new ListaUnidadesLoader<T>();
                else {
                    ListaUnidadesLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.ListaUnidadesLoaderSingleton"] as ListaUnidadesLoader<T>;
                    if (inst == null) {
                        inst = new ListaUnidadesLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.ListaUnidadesLoaderSingleton", inst);
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
            return typeof(ListaUnidades);
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
        protected override void HydrateFields(DbDataReader reader, ListaUnidades entity)
        {
            
            IMappeableListaUnidadesObject ListaUnidades = (IMappeableListaUnidadesObject)entity;
            ListaUnidades.HydrateFields(
            reader.GetInt32(0),
reader.GetString(1),
reader.GetInt32(2),
reader.GetBoolean(3));
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
            
            ((IMappeableListaUnidades)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a ListaUnidades by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a ListaUnidadesList by execute a SQL Query Text
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





