
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 06:03 p.m.
// This is a partial class file. The other one is RoboVehiculoAccesoriosVehiculoInvolucradoMapper.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using System;

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
    public partial class RoboVehiculoAccesoriosVehiculoInvolucradoMapper : BaseGateway<RoboVehiculoAccesoriosVehiculoInvolucradoObject, RoboVehiculoAccesoriosVehiculoInvolucradoObjectList>, IGenericGateway
    {


        #region "Singleton"

        static RoboVehiculoAccesoriosVehiculoInvolucradoMapper _instance;

        private RoboVehiculoAccesoriosVehiculoInvolucradoMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static RoboVehiculoAccesoriosVehiculoInvolucradoMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new RoboVehiculoAccesoriosVehiculoInvolucradoMapper();
                else {
                    RoboVehiculoAccesoriosVehiculoInvolucradoMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.RoboVehiculoAccesoriosVehiculoInvolucradoMapperSingleton"] as RoboVehiculoAccesoriosVehiculoInvolucradoMapper;
                    if (inst == null) {
                        inst = new RoboVehiculoAccesoriosVehiculoInvolucradoMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.RoboVehiculoAccesoriosVehiculoInvolucradoMapperSingleton", inst);
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
            
            string[] s ={"ClaveVehiculo","ClaveRoboAccesorios"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(RoboVehiculoAccesoriosVehiculoInvolucradoObject);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "RoboVehiculoAccesoriosVehiculoInvolucrado"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(RoboVehiculoAccesoriosVehiculoInvolucradoMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, RoboVehiculoAccesoriosVehiculoInvolucradoObject entity)
        {
            
            IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject RoboVehiculoAccesoriosVehiculoInvolucrado = (IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject)entity;
            RoboVehiculoAccesoriosVehiculoInvolucrado.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(RoboVehiculoAccesoriosVehiculoInvolucradoObject entity)
        {

            IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject RoboVehiculoAccesoriosVehiculoInvolucrado = (IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject)entity;
            return RoboVehiculoAccesoriosVehiculoInvolucrado.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(RoboVehiculoAccesoriosVehiculoInvolucradoObject entity)
        {

            IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject RoboVehiculoAccesoriosVehiculoInvolucrado = (IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject)entity;
            return RoboVehiculoAccesoriosVehiculoInvolucrado.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(RoboVehiculoAccesoriosVehiculoInvolucradoObject entity)
        {

            IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject RoboVehiculoAccesoriosVehiculoInvolucrado = (IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject)entity;
            return RoboVehiculoAccesoriosVehiculoInvolucrado.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(RoboVehiculoAccesoriosVehiculoInvolucradoObject entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject) entity).UpdateObjectFromOutputParams(parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


          





        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucradoObject by execute a SQL Query Text
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucradoObjectList by execute a SQL Query Text
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObject GetOne(System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios)
        {
            return base.GetOne(new RoboVehiculoAccesoriosVehiculoInvolucradoObject(ClaveVehiculo, ClaveRoboAccesorios));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByRoboVehiculoAccesorios(DbTransaction transaction, System.Int32 ClaveRoboAccesorios)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByRoboVehiculoAccesorios", ClaveRoboAccesorios);
        }

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByRoboVehiculoAccesorios(DbTransaction transaction, IUniqueIdentifiable RoboVehiculoAccesorios)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByRoboVehiculoAccesorios", RoboVehiculoAccesorios.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByVehiculo(DbTransaction transaction, System.Int32 ClaveVehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByVehiculo(DbTransaction transaction, IUniqueIdentifiable Vehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByVehiculo", Vehiculo.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByRoboVehiculoAccesorios(System.Int32 ClaveRoboAccesorios)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByRoboVehiculoAccesorios", ClaveRoboAccesorios);
        }

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByRoboVehiculoAccesorios(IUniqueIdentifiable RoboVehiculoAccesorios)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByRoboVehiculoAccesorios", RoboVehiculoAccesorios.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByVehiculo(System.Int32 ClaveVehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByVehiculo(IUniqueIdentifiable Vehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByVehiculo", Vehiculo.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_Delete", ClaveVehiculo, ClaveRoboAccesorios);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_Delete", ClaveVehiculo, ClaveRoboAccesorios);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByRoboVehiculoAccesorios(System.Int32 ClaveRoboAccesorios)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_DeleteByRoboVehiculoAccesorios", ClaveRoboAccesorios);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByRoboVehiculoAccesorios(DbTransaction transaction, System.Int32 ClaveRoboAccesorios)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_DeleteByRoboVehiculoAccesorios", ClaveRoboAccesorios);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByRoboVehiculoAccesorios(IUniqueIdentifiable RoboVehiculoAccesorios)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_DeleteByRoboVehiculoAccesorios", RoboVehiculoAccesorios.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByRoboVehiculoAccesorios(DbTransaction transaction, IUniqueIdentifiable RoboVehiculoAccesorios)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_DeleteByRoboVehiculoAccesorios", RoboVehiculoAccesorios.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByVehiculo(System.Int32 ClaveVehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_DeleteByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByVehiculo(DbTransaction transaction, System.Int32 ClaveVehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_DeleteByVehiculo", ClaveVehiculo);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByVehiculo(IUniqueIdentifiable Vehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_DeleteByVehiculo", Vehiculo.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByVehiculo(DbTransaction transaction, IUniqueIdentifiable Vehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_DeleteByVehiculo", Vehiculo.Identifier());
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
    public class RoboVehiculoAccesoriosVehiculoInvolucradoMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.RoboVehiculoAccesoriosVehiculoInvolucradoMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.RoboVehiculoAccesoriosVehiculoInvolucradoMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucradoEntity by calling a Stored Procedure
        /// </summary>
        public Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObject GetOne(System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios) {
            return Instance().GetOne( ClaveVehiculo, ClaveRoboAccesorios);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucradoObjectList by calling a Stored Procedure
        /// </summary>
        public Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByRoboVehiculoAccesorios(System.Int32 ClaveRoboAccesorios)
        {
            return Instance().GetByRoboVehiculoAccesorios(ClaveRoboAccesorios);
        }

        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucradoObjectList by calling a Stored Procedure
        /// </summary>
        public Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByRoboVehiculoAccesorios(IUniqueIdentifiable RoboVehiculoAccesorios)
        {
            return Instance().GetByRoboVehiculoAccesorios(RoboVehiculoAccesorios);
        }

    

        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucradoObjectList by calling a Stored Procedure
        /// </summary>
        public Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByVehiculo(System.Int32 ClaveVehiculo)
        {
            return Instance().GetByVehiculo(ClaveVehiculo);
        }

        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucradoObjectList by calling a Stored Procedure
        /// </summary>
        public Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetByVehiculo(IUniqueIdentifiable Vehiculo)
        {
            return Instance().GetByVehiculo(Vehiculo);
        }

    

       

            

        

        /// <summary>
        /// Delete RoboVehiculoAccesoriosVehiculoInvolucrado by RoboVehiculoAccesorios
        /// </summary>
        public void DeleteByRoboVehiculoAccesorios(System.Int32 ClaveRoboAccesorios)
        {
            Instance().DeleteByRoboVehiculoAccesorios(ClaveRoboAccesorios);
        }

        /// <summary>
        /// Delete RoboVehiculoAccesoriosVehiculoInvolucradoObject by RoboVehiculoAccesorios
        /// </summary>
        public void DeleteByRoboVehiculoAccesorios(IUniqueIdentifiable RoboVehiculoAccesorios)
        {
            Instance().DeleteByRoboVehiculoAccesorios(RoboVehiculoAccesorios);
        }

    

        /// <summary>
        /// Delete RoboVehiculoAccesoriosVehiculoInvolucrado by Vehiculo
        /// </summary>
        public void DeleteByVehiculo(System.Int32 ClaveVehiculo)
        {
            Instance().DeleteByVehiculo(ClaveVehiculo);
        }

        /// <summary>
        /// Delete RoboVehiculoAccesoriosVehiculoInvolucradoObject by Vehiculo
        /// </summary>
        public void DeleteByVehiculo(IUniqueIdentifiable Vehiculo)
        {
            Instance().DeleteByVehiculo(Vehiculo);
        }

    
        /// <summary>
        /// Delete RoboVehiculoAccesoriosVehiculoInvolucrado 
        /// </summary>
        public void Delete(System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios){
            Instance().Delete(ClaveVehiculo, ClaveRoboAccesorios);
        }

        /// <summary>
        /// Delete RoboVehiculoAccesoriosVehiculoInvolucradoObject 
        /// </summary>
        public void Delete(Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObject entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save RoboVehiculoAccesoriosVehiculoInvolucradoObject  
        /// </summary>
        public void Save(Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObject entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert RoboVehiculoAccesoriosVehiculoInvolucradoObject 
        /// </summary>
        public void Insert(Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObject entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll RoboVehiculoAccesoriosVehiculoInvolucradoObject 
        /// </summary>
        public Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObjectList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save RoboVehiculoAccesoriosVehiculoInvolucrado 
        /// </summary>
        public void Save(System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios){
            Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObject entity = Instance().GetOne(ClaveVehiculo, ClaveRoboAccesorios);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}, {2} = {3}", "ClaveVehiculo", ClaveVehiculo, "ClaveRoboAccesorios", ClaveRoboAccesorios));

            Instance().Save(entity);
        }

        /// <summary>
        /// Insert RoboVehiculoAccesoriosVehiculoInvolucradoObject
        /// </summary>
        public void Insert(System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios){
            Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObject entity = new Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObject();

            entity.ClaveVehiculo = ClaveVehiculo;
            entity.ClaveRoboAccesorios = ClaveRoboAccesorios;
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
    public partial class RoboVehiculoAccesoriosVehiculoInvolucradoLoader<T> : BaseLoader< T, RoboVehiculoAccesoriosVehiculoInvolucradoObject, ObjectList<T>>, IGenericGateway where T : RoboVehiculoAccesoriosVehiculoInvolucradoObject, new()
    {

        #region "Singleton"

        static RoboVehiculoAccesoriosVehiculoInvolucradoLoader<T> _instance;

        private RoboVehiculoAccesoriosVehiculoInvolucradoLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static RoboVehiculoAccesoriosVehiculoInvolucradoLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new RoboVehiculoAccesoriosVehiculoInvolucradoLoader<T>();
                else {
                    RoboVehiculoAccesoriosVehiculoInvolucradoLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.RoboVehiculoAccesoriosVehiculoInvolucradoLoaderSingleton"] as RoboVehiculoAccesoriosVehiculoInvolucradoLoader<T>;
                    if (inst == null) {
                        inst = new RoboVehiculoAccesoriosVehiculoInvolucradoLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.RoboVehiculoAccesoriosVehiculoInvolucradoLoaderSingleton", inst);
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
            
            string[] s ={"ClaveVehiculo","ClaveRoboAccesorios"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(RoboVehiculoAccesoriosVehiculoInvolucradoObject);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "RoboVehiculoAccesoriosVehiculoInvolucrado"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, RoboVehiculoAccesoriosVehiculoInvolucradoObject entity)
        {
            
            IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject RoboVehiculoAccesoriosVehiculoInvolucrado = (IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject)entity;
            RoboVehiculoAccesoriosVehiculoInvolucrado.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


        



        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucrado by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a RoboVehiculoAccesoriosVehiculoInvolucradoList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetOne", ClaveVehiculo, ClaveRoboAccesorios);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByRoboVehiculoAccesorios(DbTransaction transaction, System.Int32 ClaveRoboAccesorios)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByRoboVehiculoAccesorios", ClaveRoboAccesorios);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByRoboVehiculoAccesorios(DbTransaction transaction, IUniqueIdentifiable RoboVehiculoAccesorios)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByRoboVehiculoAccesorios", RoboVehiculoAccesorios.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByVehiculo(DbTransaction transaction, System.Int32 ClaveVehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByVehiculo(DbTransaction transaction, IUniqueIdentifiable Vehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByVehiculo", Vehiculo.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByRoboVehiculoAccesorios(System.Int32 ClaveRoboAccesorios)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByRoboVehiculoAccesorios", ClaveRoboAccesorios);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByRoboVehiculoAccesorios(IUniqueIdentifiable RoboVehiculoAccesorios)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByRoboVehiculoAccesorios", RoboVehiculoAccesorios.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByVehiculo(System.Int32 ClaveVehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByVehiculo(IUniqueIdentifiable Vehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "RoboVehiculoAccesoriosVehiculoInvolucrado_GetByVehiculo", Vehiculo.Identifier());
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





