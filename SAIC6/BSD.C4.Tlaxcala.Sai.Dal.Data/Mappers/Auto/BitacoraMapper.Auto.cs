
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 15/08/2009 - 05:12 p.m.
// This is a partial class file. The other one is BitacoraMapper.cs
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
    public partial class BitacoraMapper : BaseGateway<Bitacora, BitacoraList>, IGenericGateway
    {


        #region "Singleton"

        static BitacoraMapper _instance;

        private BitacoraMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static BitacoraMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new BitacoraMapper();
                else {
                    BitacoraMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.BitacoraMapperSingleton"] as BitacoraMapper;
                    if (inst == null) {
                        inst = new BitacoraMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.BitacoraMapperSingleton", inst);
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
            return typeof(Bitacora);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Bitacora"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(BitacoraMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Bitacora entity)
        {
            
            IMappeableBitacoraObject Bitacora = (IMappeableBitacoraObject)entity;
            Bitacora.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? new System.Nullable<System.DateTime>() : reader.GetDateTime(5),
(reader.IsDBNull(6)) ? "" : reader.GetString(6),
(reader.IsDBNull(7)) ? "" : reader.GetString(7));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(Bitacora entity)
        {

            IMappeableBitacoraObject Bitacora = (IMappeableBitacoraObject)entity;
            return Bitacora.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(Bitacora entity)
        {

            IMappeableBitacoraObject Bitacora = (IMappeableBitacoraObject)entity;
            return Bitacora.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(Bitacora entity)
        {

            IMappeableBitacoraObject Bitacora = (IMappeableBitacoraObject)entity;
            return Bitacora.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(Bitacora entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableBitacoraObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(Bitacora entity)
        {
            
            ((IMappeableBitacora)entity).CompleteEntity();
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
        /// Obtiene bitacora filtrado
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public BitacoraList GetFiltrado(System.String filtro)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Bitacora_GetByFiltro", filtro);
        }





        /// <summary>
        /// Get a Bitacora by execute a SQL Query Text
        /// </summary>
        public Bitacora GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a BitacoraList by execute a SQL Query Text
        /// </summary>
        public BitacoraList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public Bitacora GetOne(System.Int32 Clave)
        {
            return base.GetOne(new Bitacora(Clave));
        }


        // GetOne By Objects and Params

        /// <summary>
        /// Obtiene todos los registros por operacion
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public BitacoraList GetByOperacion(System.String operacion)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Bitacora_GetByOperacion", operacion);
        }

        /// <summary>
        /// Obtiene todos los registros por catalogo
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        public BitacoraList GetByCatalogo(System.String catalogo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Bitacora_GetByCatalogo", catalogo);
        }
        


        

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Bitacora_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Bitacora_Delete", Clave);
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
    public class BitacoraMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.BitacoraMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.BitacoraMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a BitacoraEntity by calling a Stored Procedure
        /// </summary>
        public Entities.Bitacora GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

       

        /// <summary>
        /// Delete children for Bitacora
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, Bitacora entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        
        /// <summary>
        /// Delete Bitacora 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete Bitacora 
        /// </summary>
        public void Delete(Entities.Bitacora entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save Bitacora  
        /// </summary>
        public void Save(Entities.Bitacora entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Bitacora 
        /// </summary>
        public void Insert(Entities.Bitacora entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll Bitacora 
        /// </summary>
        public Entities.BitacoraList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Bitacora 
        /// </summary>
        public void Save(System.Int32 Clave, System.String NombreCatalogo, System.String Descripcion, System.String NombrePropio, System.String Operacion, System.DateTime FechaOperacion, System.String ValorAnterior, System.String ValorActual){
            Entities.Bitacora entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.NombreCatalogo = NombreCatalogo;
            entity.Descripcion = Descripcion;
            entity.NombrePropio = NombrePropio;
            entity.Operacion = Operacion;
            entity.FechaOperacion = FechaOperacion;
            entity.ValorAnterior = ValorAnterior;
            entity.ValorActual = ValorActual;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Bitacora
        /// </summary>
        public void Insert(System.String NombreCatalogo, System.String Descripcion, System.String NombrePropio, System.String Operacion, System.DateTime FechaOperacion, System.String ValorAnterior, System.String ValorActual){
            Entities.Bitacora entity = new Entities.Bitacora();

            entity.NombreCatalogo = NombreCatalogo;
            entity.Descripcion = Descripcion;
            entity.NombrePropio = NombrePropio;
            entity.Operacion = Operacion;
            entity.FechaOperacion = FechaOperacion;
            entity.ValorAnterior = ValorAnterior;
            entity.ValorActual = ValorActual;
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
    public partial class BitacoraLoader<T> : BaseLoader< T, Bitacora, ObjectList<T>>, IGenericGateway where T : Bitacora, new()
    {

        #region "Singleton"

        static BitacoraLoader<T> _instance;

        private BitacoraLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static BitacoraLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new BitacoraLoader<T>();
                else {
                    BitacoraLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.BitacoraLoaderSingleton"] as BitacoraLoader<T>;
                    if (inst == null) {
                        inst = new BitacoraLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.BitacoraLoaderSingleton", inst);
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
            return typeof(Bitacora);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Bitacora"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Bitacora entity)
        {
            
            IMappeableBitacoraObject Bitacora = (IMappeableBitacoraObject)entity;
            Bitacora.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? new System.Nullable<System.DateTime>() : reader.GetDateTime(5),
(reader.IsDBNull(6)) ? "" : reader.GetString(6),
(reader.IsDBNull(7)) ? "" : reader.GetString(7));
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
            
            ((IMappeableBitacora)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a Bitacora by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a BitacoraList by execute a SQL Query Text
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
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Bitacora_GetOne", Clave);
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




