
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 01:50 p.m.
// This is a partial class file. The other one is VehiculoMapper.cs
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
    public partial class VehiculoMapper : BaseGateway<VehiculoObject, VehiculoObjectList>, IGenericGateway
    {


        #region "Singleton"

        static VehiculoMapper _instance;

        private VehiculoMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static VehiculoMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new VehiculoMapper();
                else {
                    VehiculoMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.VehiculoMapperSingleton"] as VehiculoMapper;
                    if (inst == null) {
                        inst = new VehiculoMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.VehiculoMapperSingleton", inst);
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
            return typeof(VehiculoObject);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Vehiculo"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(VehiculoMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, VehiculoObject entity)
        {
            
            IMappeableVehiculoObject Vehiculo = (IMappeableVehiculoObject)entity;
            Vehiculo.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? "" : reader.GetString(5),
(reader.IsDBNull(6)) ? "" : reader.GetString(6),
(reader.IsDBNull(7)) ? "" : reader.GetString(7));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(VehiculoObject entity)
        {

            IMappeableVehiculoObject Vehiculo = (IMappeableVehiculoObject)entity;
            return Vehiculo.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(VehiculoObject entity)
        {

            IMappeableVehiculoObject Vehiculo = (IMappeableVehiculoObject)entity;
            return Vehiculo.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(VehiculoObject entity)
        {

            IMappeableVehiculoObject Vehiculo = (IMappeableVehiculoObject)entity;
            return Vehiculo.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(VehiculoObject entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableVehiculoObject) entity).UpdateObjectFromOutputParams(parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


          





        /// <summary>
        /// Get a VehiculoObject by execute a SQL Query Text
        /// </summary>
        public VehiculoObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a VehiculoObjectList by execute a SQL Query Text
        /// </summary>
        public VehiculoObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public VehiculoObject GetOne(System.Int32 Clave)
        {
            return base.GetOne(new VehiculoObject(Clave));
        }


        // GetOne By Objects and Params
            


        


        

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Vehiculo_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Vehiculo_Delete", Clave);
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
    public class VehiculoMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.VehiculoMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.VehiculoMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a VehiculoEntity by calling a Stored Procedure
        /// </summary>
        public Objects.VehiculoObject GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

       

            

        
        /// <summary>
        /// Delete Vehiculo 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete VehiculoObject 
        /// </summary>
        public void Delete(Objects.VehiculoObject entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save VehiculoObject  
        /// </summary>
        public void Save(Objects.VehiculoObject entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert VehiculoObject 
        /// </summary>
        public void Insert(Objects.VehiculoObject entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll VehiculoObject 
        /// </summary>
        public Objects.VehiculoObjectList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Vehiculo 
        /// </summary>
        public void Save(System.Int32 Clave, System.String Marca, System.String Tipo, System.String Modelo, System.String Placas, System.String Color, System.String NumeroSerie, System.String SeñasParticulares){
            Objects.VehiculoObject entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.Marca = Marca;
            entity.Tipo = Tipo;
            entity.Modelo = Modelo;
            entity.Placas = Placas;
            entity.Color = Color;
            entity.NumeroSerie = NumeroSerie;
            entity.SeñasParticulares = SeñasParticulares;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert VehiculoObject
        /// </summary>
        public void Insert(System.String Marca, System.String Tipo, System.String Modelo, System.String Placas, System.String Color, System.String NumeroSerie, System.String SeñasParticulares){
            Objects.VehiculoObject entity = new Objects.VehiculoObject();

            entity.Marca = Marca;
            entity.Tipo = Tipo;
            entity.Modelo = Modelo;
            entity.Placas = Placas;
            entity.Color = Color;
            entity.NumeroSerie = NumeroSerie;
            entity.SeñasParticulares = SeñasParticulares;
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
    public partial class VehiculoLoader<T> : BaseLoader< T, VehiculoObject, ObjectList<T>>, IGenericGateway where T : VehiculoObject, new()
    {

        #region "Singleton"

        static VehiculoLoader<T> _instance;

        private VehiculoLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static VehiculoLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new VehiculoLoader<T>();
                else {
                    VehiculoLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.VehiculoLoaderSingleton"] as VehiculoLoader<T>;
                    if (inst == null) {
                        inst = new VehiculoLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.VehiculoLoaderSingleton", inst);
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
            return typeof(VehiculoObject);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Vehiculo"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, VehiculoObject entity)
        {
            
            IMappeableVehiculoObject Vehiculo = (IMappeableVehiculoObject)entity;
            Vehiculo.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? "" : reader.GetString(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? "" : reader.GetString(5),
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
        /// Get a Vehiculo by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a VehiculoList by execute a SQL Query Text
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
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Vehiculo_GetOne", Clave);
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





