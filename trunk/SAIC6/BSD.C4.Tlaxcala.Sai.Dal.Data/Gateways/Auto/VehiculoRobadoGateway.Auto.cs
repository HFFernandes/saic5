
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 06:03 p.m.
// This is a partial class file. The other one is VehiculoRobadoGateway.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using System;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using Cooperator.Framework.Data;
using Cooperator.Framework.Data.Exceptions;
using Cooperator.Framework.Core;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Web;




namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Gateways
{

    public partial class VehiculoRobadoGateway : BaseGateway<VehiculoRobadoObject, VehiculoRobadoObjectList>, IGenericGateway
    {

        #region "Singleton"

        static VehiculoRobadoGateway _instance;

        private VehiculoRobadoGateway()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        
        public static VehiculoRobadoGateway Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new VehiculoRobadoGateway();
                else {
                    VehiculoRobadoGateway inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.VehiculoRobadoGatewaySingleton"] as VehiculoRobadoGateway;
                    if (inst == null) {
                        inst = new VehiculoRobadoGateway();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.VehiculoRobadoGatewaySingleton", inst);
                    }
                    return inst;
                }
            }
            return _instance;
        }

        #endregion

        /// <summary>
        /// Return the mapped table name
        /// </summary>
        protected override string TableName
        {
            get { return "VehiculoRobado"; }
        }

        protected override string RuleName
        {
            get {return typeof(VehiculoRobadoGateway).FullName;}
        }


        

        /// <summary>
        /// Assign properties values based on DataReader
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, VehiculoRobadoObject entity)
        {
            
            IMappeableVehiculoRobadoObject VehiculoRobado = (IMappeableVehiculoRobadoObject)entity;
            VehiculoRobado.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? new System.Nullable<System.Int32>() : reader.GetInt32(2));
            ((IObject)entity).State = ObjectState.Restored;
        }

        /// <summary>
        /// Get field values to call insertion stored procedure
        /// </summary>
        protected override object[] GetFieldsForInsert(VehiculoRobadoObject entity)
        {

            IMappeableVehiculoRobadoObject VehiculoRobado = (IMappeableVehiculoRobadoObject)entity;
            return VehiculoRobado.GetFieldsForInsert();
        }

        /// <summary>
        /// Get field values to call update stored procedure
        /// </summary>
        protected override object[] GetFieldsForUpdate(VehiculoRobadoObject entity)
        {

            IMappeableVehiculoRobadoObject VehiculoRobado = (IMappeableVehiculoRobadoObject)entity;
            return VehiculoRobado.GetFieldsForUpdate();
        }

        /// <summary>
        /// Get field values to call deletion stored procedure
        /// </summary>
        protected override object[] GetFieldsForDelete(VehiculoRobadoObject entity)
        {

            IMappeableVehiculoRobadoObject VehiculoRobado = (IMappeableVehiculoRobadoObject)entity;
            return VehiculoRobado.GetFieldsForDelete();
        }

        /// <summary>
        /// Raised after insert and update. Update properties from Output parameters
        /// </summary>
        protected override void UpdateObjectFromOutputParams(VehiculoRobadoObject row, object[] parameters)
        {
            ((IMappeableVehiculoRobadoObject) row).UpdateObjectFromOutputParams(parameters);
            ((IObject)row).State = ObjectState.Restored;
        }

        /// <summary>
        /// StoredProceduresPrefix, for example: coop_
        /// </summary>
        protected override string StoredProceduresPrefix()
        {
            return "up_";
        }


        /// <summary>
        /// Get a VehiculoRobadoObject by execute a SQL Query Text
        /// </summary>
        public VehiculoRobadoObject GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a VehiculoRobadoObjectList by execute a SQL Query Text
        /// </summary>
        public VehiculoRobadoObjectList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// Get a VehiculoRobadoObject by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObject GetOne(System.Int32 ClaveVehiculo, System.Int32 Folio)
        {
            return base.GetOne(new VehiculoRobadoObject(ClaveVehiculo, Folio));
        }


        // GetBy Objects and Params
            


        

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByIncidencia(DbTransaction transaction,System.Int32 Folio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_GetByIncidencia", Folio);
        }

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByIncidencia(DbTransaction transaction, IUniqueIdentifiable Incidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_GetByIncidencia", Incidencia.Identifier());
        }

    

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByPropietarioVehiculo(DbTransaction transaction,System.Int32 ClavePropietario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_GetByPropietarioVehiculo", ClavePropietario);
        }

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByPropietarioVehiculo(DbTransaction transaction, IUniqueIdentifiable PropietarioVehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_GetByPropietarioVehiculo", PropietarioVehiculo.Identifier());
        }

    

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByVehiculo(DbTransaction transaction,System.Int32 ClaveVehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_GetByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByVehiculo(DbTransaction transaction, IUniqueIdentifiable Vehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_GetByVehiculo", Vehiculo.Identifier());
        }

    

        

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByIncidencia(System.Int32 Folio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_GetByIncidencia", Folio);
        }

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByIncidencia(IUniqueIdentifiable Incidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_GetByIncidencia", Incidencia.Identifier());
        }

    

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByPropietarioVehiculo(System.Int32 ClavePropietario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_GetByPropietarioVehiculo", ClavePropietario);
        }

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByPropietarioVehiculo(IUniqueIdentifiable PropietarioVehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_GetByPropietarioVehiculo", PropietarioVehiculo.Identifier());
        }

    

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByVehiculo(System.Int32 ClaveVehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_GetByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// Get a VehiculoRobadoObjectList by calling a Stored Procedure
        /// </summary>
        public VehiculoRobadoObjectList GetByVehiculo(IUniqueIdentifiable Vehiculo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_GetByVehiculo", Vehiculo.Identifier());
        }

    

        /// <summary>
        /// Delete VehiculoRobado
        /// </summary>
        public void Delete(System.Int32 ClaveVehiculo, System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_Delete", ClaveVehiculo, Folio);
        }

        /// <summary>
        /// Delete VehiculoRobado
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 ClaveVehiculo, System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_Delete", ClaveVehiculo, Folio);
        }

            

        

        /// <summary>
        /// Delete VehiculoRobado by Incidencia
        /// </summary>
        public void DeleteByIncidencia(System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_DeleteByIncidencia", Folio);
        }

        /// <summary>
        /// Delete VehiculoRobado by Incidencia
        /// </summary>
        public void DeleteByIncidencia(DbTransaction transaction, System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_DeleteByIncidencia", Folio);
        }

        /// <summary>
        /// Delete VehiculoRobado by Incidencia
        /// </summary>
        public void DeleteByIncidencia(IUniqueIdentifiable Incidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_DeleteByIncidencia", Incidencia.Identifier());
        }

        /// <summary>
        /// Delete VehiculoRobado by Incidencia
        /// </summary>
        public void DeleteByIncidencia(DbTransaction transaction, IUniqueIdentifiable Incidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_DeleteByIncidencia", Incidencia.Identifier());
        }


    

        /// <summary>
        /// Delete VehiculoRobado by PropietarioVehiculo
        /// </summary>
        public void DeleteByPropietarioVehiculo(System.Int32 ClavePropietario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_DeleteByPropietarioVehiculo", ClavePropietario);
        }

        /// <summary>
        /// Delete VehiculoRobado by PropietarioVehiculo
        /// </summary>
        public void DeleteByPropietarioVehiculo(DbTransaction transaction, System.Int32 ClavePropietario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_DeleteByPropietarioVehiculo", ClavePropietario);
        }

        /// <summary>
        /// Delete VehiculoRobado by PropietarioVehiculo
        /// </summary>
        public void DeleteByPropietarioVehiculo(IUniqueIdentifiable PropietarioVehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_DeleteByPropietarioVehiculo", PropietarioVehiculo.Identifier());
        }

        /// <summary>
        /// Delete VehiculoRobado by PropietarioVehiculo
        /// </summary>
        public void DeleteByPropietarioVehiculo(DbTransaction transaction, IUniqueIdentifiable PropietarioVehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_DeleteByPropietarioVehiculo", PropietarioVehiculo.Identifier());
        }


    

        /// <summary>
        /// Delete VehiculoRobado by Vehiculo
        /// </summary>
        public void DeleteByVehiculo(System.Int32 ClaveVehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_DeleteByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// Delete VehiculoRobado by Vehiculo
        /// </summary>
        public void DeleteByVehiculo(DbTransaction transaction, System.Int32 ClaveVehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_DeleteByVehiculo", ClaveVehiculo);
        }

        /// <summary>
        /// Delete VehiculoRobado by Vehiculo
        /// </summary>
        public void DeleteByVehiculo(IUniqueIdentifiable Vehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "VehiculoRobado_DeleteByVehiculo", Vehiculo.Identifier());
        }

        /// <summary>
        /// Delete VehiculoRobado by Vehiculo
        /// </summary>
        public void DeleteByVehiculo(DbTransaction transaction, IUniqueIdentifiable Vehiculo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "VehiculoRobado_DeleteByVehiculo", Vehiculo.Identifier());
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







