
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is ColoniaMapper.cs
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
    public partial class ColoniaMapper : BaseGateway<Colonia, ColoniaList>, IGenericGateway
    {


        #region "Singleton"

        static ColoniaMapper _instance;

        private ColoniaMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static ColoniaMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new ColoniaMapper();
                else {
                    ColoniaMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.ColoniaMapperSingleton"] as ColoniaMapper;
                    if (inst == null) {
                        inst = new ColoniaMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.ColoniaMapperSingleton", inst);
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
            
            string[] s ={"Clave","ClaveEstado","ClaveMunicipio","ClaveLocalidad"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(Colonia);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Colonia"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(ColoniaMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Colonia entity)
        {
            
            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            Colonia.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
reader.GetInt32(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(Colonia entity)
        {

            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            return Colonia.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(Colonia entity)
        {

            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            return Colonia.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(Colonia entity)
        {

            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            return Colonia.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(Colonia entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableColoniaObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(Colonia entity)
        {
            
            ((IMappeableColonia)entity).CompleteEntity();
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
        /// Get a Colonia by execute a SQL Query Text
        /// </summary>
        public Colonia GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a ColoniaList by execute a SQL Query Text
        /// </summary>
        public ColoniaList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public Colonia GetOne(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad)
        {
            return base.GetOne(new Colonia(Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ColoniaList GetByLocalidad(DbTransaction transaction, System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_GetByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColoniaList GetByLocalidad(DbTransaction transaction, IUniqueIdentifiable Localidad)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_GetByLocalidad", Localidad.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ColoniaList GetByLocalidad(System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Colonia_GetByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ColoniaList GetByLocalidad(IUniqueIdentifiable Localidad)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Colonia_GetByLocalidad", Localidad.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Colonia_Delete", Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_Delete", Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByLocalidad(System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Colonia_DeleteByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByLocalidad(DbTransaction transaction, System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_DeleteByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByLocalidad(IUniqueIdentifiable Localidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Colonia_DeleteByLocalidad", Localidad.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByLocalidad(DbTransaction transaction, IUniqueIdentifiable Localidad)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_DeleteByLocalidad", Localidad.Identifier());
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
    public class ColoniaMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.ColoniaMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.ColoniaMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a ColoniaEntity by calling a Stored Procedure
        /// </summary>
        public Entities.Colonia GetOne(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad) {
            return Instance().GetOne( Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a ColoniaList by calling a Stored Procedure
        /// </summary>
        public Entities.ColoniaList GetByLocalidad(System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            return Instance().GetByLocalidad(ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// Get a ColoniaList by calling a Stored Procedure
        /// </summary>
        public Entities.ColoniaList GetByLocalidad(IUniqueIdentifiable Localidad)
        {
            return Instance().GetByLocalidad(Localidad);
        }

    

       

        /// <summary>
        /// Delete children for Colonia
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, Colonia entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete Colonia by Localidad
        /// </summary>
        public void DeleteByLocalidad(System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            Instance().DeleteByLocalidad(ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// Delete Colonia by Localidad
        /// </summary>
        public void DeleteByLocalidad(IUniqueIdentifiable Localidad)
        {
            Instance().DeleteByLocalidad(Localidad);
        }

    
        /// <summary>
        /// Delete Colonia 
        /// </summary>
        public void Delete(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad){
            Instance().Delete(Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad);
        }

        /// <summary>
        /// Delete Colonia 
        /// </summary>
        public void Delete(Entities.Colonia entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save Colonia  
        /// </summary>
        public void Save(Entities.Colonia entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Colonia 
        /// </summary>
        public void Insert(Entities.Colonia entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll Colonia 
        /// </summary>
        public Entities.ColoniaList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Colonia 
        /// </summary>
        public void Save(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad, System.String Nombre){
            Entities.Colonia entity = Instance().GetOne(Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}, {2} = {3}, {4} = {5}, {6} = {7}", "Clave", Clave, "ClaveEstado", ClaveEstado, "ClaveMunicipio", ClaveMunicipio, "ClaveLocalidad", ClaveLocalidad));

            entity.Nombre = Nombre;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Colonia
        /// </summary>
        public void Insert(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad, System.String Nombre){
            Entities.Colonia entity = new Entities.Colonia();

            entity.Clave = Clave;
            entity.ClaveEstado = ClaveEstado;
            entity.ClaveMunicipio = ClaveMunicipio;
            entity.ClaveLocalidad = ClaveLocalidad;
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
    public partial class ColoniaLoader<T> : BaseLoader< T, Colonia, ObjectList<T>>, IGenericGateway where T : Colonia, new()
    {

        #region "Singleton"

        static ColoniaLoader<T> _instance;

        private ColoniaLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static ColoniaLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new ColoniaLoader<T>();
                else {
                    ColoniaLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.ColoniaLoaderSingleton"] as ColoniaLoader<T>;
                    if (inst == null) {
                        inst = new ColoniaLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.ColoniaLoaderSingleton", inst);
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
            
            string[] s ={"Clave","ClaveEstado","ClaveMunicipio","ClaveLocalidad"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(Colonia);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Colonia"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Colonia entity)
        {
            
            IMappeableColoniaObject Colonia = (IMappeableColoniaObject)entity;
            Colonia.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
reader.GetInt32(2),
reader.GetInt32(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4));
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
            
            ((IMappeableColonia)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a Colonia by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a ColoniaList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Colonia_GetOne", Clave, ClaveEstado, ClaveMunicipio, ClaveLocalidad);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByLocalidad(DbTransaction transaction, System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_GetByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByLocalidad(DbTransaction transaction, IUniqueIdentifiable Localidad)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Colonia_GetByLocalidad", Localidad.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByLocalidad(System.Int32 ClaveLocalidad, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Colonia_GetByLocalidad", ClaveLocalidad, ClaveEstado, ClaveMunicipio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByLocalidad(IUniqueIdentifiable Localidad)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Colonia_GetByLocalidad", Localidad.Identifier());
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





