
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is IncidenciaMapper.cs
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
    public partial class IncidenciaMapper : BaseGateway<Incidencia, IncidenciaList>, IGenericGateway
    {


        #region "Singleton"

        static IncidenciaMapper _instance;

        private IncidenciaMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static IncidenciaMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new IncidenciaMapper();
                else {
                    IncidenciaMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.IncidenciaMapperSingleton"] as IncidenciaMapper;
                    if (inst == null) {
                        inst = new IncidenciaMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.IncidenciaMapperSingleton", inst);
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
            
            string[] s ={"Folio"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(Incidencia);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Incidencia"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(IncidenciaMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Incidencia entity)
        {
            
            IMappeableIncidenciaObject Incidencia = (IMappeableIncidenciaObject)entity;
            Incidencia.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? new System.Nullable<System.Int32>() : reader.GetInt32(1),
reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
reader.GetDateTime(5),
(reader.IsDBNull(6)) ? new System.Nullable<System.Int32>() : reader.GetInt32(6),
(reader.IsDBNull(7)) ? new System.Nullable<System.Int32>() : reader.GetInt32(7),
(reader.IsDBNull(8)) ? new System.Nullable<System.Int32>() : reader.GetInt32(8),
(reader.IsDBNull(9)) ? new System.Nullable<System.Int32>() : reader.GetInt32(9),
(reader.IsDBNull(10)) ? new System.Nullable<System.Int32>() : reader.GetInt32(10),
(reader.IsDBNull(11)) ? "" : reader.GetString(11),
(reader.IsDBNull(12)) ? new System.Nullable<System.Int32>() : reader.GetInt32(12),
reader.GetInt32(13),
reader.GetInt32(14),
reader.GetBoolean(15),
(reader.IsDBNull(16)) ? new System.Nullable<System.Int32>() : reader.GetInt32(16));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(Incidencia entity)
        {

            IMappeableIncidenciaObject Incidencia = (IMappeableIncidenciaObject)entity;
            return Incidencia.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(Incidencia entity)
        {

            IMappeableIncidenciaObject Incidencia = (IMappeableIncidenciaObject)entity;
            return Incidencia.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(Incidencia entity)
        {

            IMappeableIncidenciaObject Incidencia = (IMappeableIncidenciaObject)entity;
            return Incidencia.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(Incidencia entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeableIncidenciaObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(Incidencia entity)
        {
            
            ((IMappeableIncidencia)entity).CompleteEntity();
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
        /// Get a Incidencia by execute a SQL Query Text
        /// </summary>
        public Incidencia GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a IncidenciaList by execute a SQL Query Text
        /// </summary>
        public IncidenciaList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public Incidencia GetOne(System.Int32 Folio)
        {
            return base.GetOne(new Incidencia(Folio));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByDenunciante(DbTransaction transaction, System.Int32 ClaveDenunciante)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByDenunciante", ClaveDenunciante);
        }

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByDenunciante(DbTransaction transaction, IUniqueIdentifiable Denunciante)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByDenunciante", Denunciante.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByEstatusIncidencia(DbTransaction transaction, System.Int32 ClaveEstatus)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByEstatusIncidencia", ClaveEstatus);
        }

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByEstatusIncidencia(DbTransaction transaction, IUniqueIdentifiable EstatusIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByEstatusIncidencia", EstatusIncidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByTipoIncidencia(DbTransaction transaction, System.Int32 ClaveTipo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByTipoIncidencia", ClaveTipo);
        }

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByTipoIncidencia(DbTransaction transaction, IUniqueIdentifiable TipoIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByTipoIncidencia", TipoIncidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByUsuario(DbTransaction transaction, System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByUsuario", Usuario.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByDenunciante(System.Int32 ClaveDenunciante)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByDenunciante", ClaveDenunciante);
        }

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByDenunciante(IUniqueIdentifiable Denunciante)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByDenunciante", Denunciante.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByEstatusIncidencia(System.Int32 ClaveEstatus)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByEstatusIncidencia", ClaveEstatus);
        }

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByEstatusIncidencia(IUniqueIdentifiable EstatusIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByEstatusIncidencia", EstatusIncidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByTipoIncidencia(System.Int32 ClaveTipo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByTipoIncidencia", ClaveTipo);
        }

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByTipoIncidencia(IUniqueIdentifiable TipoIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByTipoIncidencia", TipoIncidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByUsuario(System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// 
        /// </summary>
        public IncidenciaList GetByUsuario(IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByUsuario", Usuario.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_Delete", Folio);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_Delete", Folio);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByDenunciante(System.Int32 ClaveDenunciante)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_DeleteByDenunciante", ClaveDenunciante);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByDenunciante(DbTransaction transaction, System.Int32 ClaveDenunciante)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_DeleteByDenunciante", ClaveDenunciante);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByDenunciante(IUniqueIdentifiable Denunciante)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_DeleteByDenunciante", Denunciante.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByDenunciante(DbTransaction transaction, IUniqueIdentifiable Denunciante)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_DeleteByDenunciante", Denunciante.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByEstatusIncidencia(System.Int32 ClaveEstatus)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_DeleteByEstatusIncidencia", ClaveEstatus);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByEstatusIncidencia(DbTransaction transaction, System.Int32 ClaveEstatus)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_DeleteByEstatusIncidencia", ClaveEstatus);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByEstatusIncidencia(IUniqueIdentifiable EstatusIncidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_DeleteByEstatusIncidencia", EstatusIncidencia.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByEstatusIncidencia(DbTransaction transaction, IUniqueIdentifiable EstatusIncidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_DeleteByEstatusIncidencia", EstatusIncidencia.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByTipoIncidencia(System.Int32 ClaveTipo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_DeleteByTipoIncidencia", ClaveTipo);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByTipoIncidencia(DbTransaction transaction, System.Int32 ClaveTipo)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_DeleteByTipoIncidencia", ClaveTipo);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByTipoIncidencia(IUniqueIdentifiable TipoIncidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_DeleteByTipoIncidencia", TipoIncidencia.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByTipoIncidencia(DbTransaction transaction, IUniqueIdentifiable TipoIncidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_DeleteByTipoIncidencia", TipoIncidencia.Identifier());
        }


    

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByUsuario(System.Int32 ClaveUsuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_DeleteByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByUsuario(DbTransaction transaction, System.Int32 ClaveUsuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_DeleteByUsuario", ClaveUsuario);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByUsuario(IUniqueIdentifiable Usuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "Incidencia_DeleteByUsuario", Usuario.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_DeleteByUsuario", Usuario.Identifier());
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
    public class IncidenciaMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.IncidenciaMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.IncidenciaMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a IncidenciaEntity by calling a Stored Procedure
        /// </summary>
        public Entities.Incidencia GetOne(System.Int32 Folio) {
            return Instance().GetOne( Folio);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a IncidenciaList by calling a Stored Procedure
        /// </summary>
        public Entities.IncidenciaList GetByDenunciante(System.Int32 ClaveDenunciante)
        {
            return Instance().GetByDenunciante(ClaveDenunciante);
        }

        /// <summary>
        /// Get a IncidenciaList by calling a Stored Procedure
        /// </summary>
        public Entities.IncidenciaList GetByDenunciante(IUniqueIdentifiable Denunciante)
        {
            return Instance().GetByDenunciante(Denunciante);
        }

    

        /// <summary>
        /// Get a IncidenciaList by calling a Stored Procedure
        /// </summary>
        public Entities.IncidenciaList GetByEstatusIncidencia(System.Int32 ClaveEstatus)
        {
            return Instance().GetByEstatusIncidencia(ClaveEstatus);
        }

        /// <summary>
        /// Get a IncidenciaList by calling a Stored Procedure
        /// </summary>
        public Entities.IncidenciaList GetByEstatusIncidencia(IUniqueIdentifiable EstatusIncidencia)
        {
            return Instance().GetByEstatusIncidencia(EstatusIncidencia);
        }

    

        /// <summary>
        /// Get a IncidenciaList by calling a Stored Procedure
        /// </summary>
        public Entities.IncidenciaList GetByTipoIncidencia(System.Int32 ClaveTipo)
        {
            return Instance().GetByTipoIncidencia(ClaveTipo);
        }

        /// <summary>
        /// Get a IncidenciaList by calling a Stored Procedure
        /// </summary>
        public Entities.IncidenciaList GetByTipoIncidencia(IUniqueIdentifiable TipoIncidencia)
        {
            return Instance().GetByTipoIncidencia(TipoIncidencia);
        }

    

        /// <summary>
        /// Get a IncidenciaList by calling a Stored Procedure
        /// </summary>
        public Entities.IncidenciaList GetByUsuario(System.Int32 ClaveUsuario)
        {
            return Instance().GetByUsuario(ClaveUsuario);
        }

        /// <summary>
        /// Get a IncidenciaList by calling a Stored Procedure
        /// </summary>
        public Entities.IncidenciaList GetByUsuario(IUniqueIdentifiable Usuario)
        {
            return Instance().GetByUsuario(Usuario);
        }

    

       

        /// <summary>
        /// Delete children for Incidencia
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, Incidencia entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete Incidencia by Denunciante
        /// </summary>
        public void DeleteByDenunciante(System.Int32 ClaveDenunciante)
        {
            Instance().DeleteByDenunciante(ClaveDenunciante);
        }

        /// <summary>
        /// Delete Incidencia by Denunciante
        /// </summary>
        public void DeleteByDenunciante(IUniqueIdentifiable Denunciante)
        {
            Instance().DeleteByDenunciante(Denunciante);
        }

    

        /// <summary>
        /// Delete Incidencia by EstatusIncidencia
        /// </summary>
        public void DeleteByEstatusIncidencia(System.Int32 ClaveEstatus)
        {
            Instance().DeleteByEstatusIncidencia(ClaveEstatus);
        }

        /// <summary>
        /// Delete Incidencia by EstatusIncidencia
        /// </summary>
        public void DeleteByEstatusIncidencia(IUniqueIdentifiable EstatusIncidencia)
        {
            Instance().DeleteByEstatusIncidencia(EstatusIncidencia);
        }

    

        /// <summary>
        /// Delete Incidencia by TipoIncidencia
        /// </summary>
        public void DeleteByTipoIncidencia(System.Int32 ClaveTipo)
        {
            Instance().DeleteByTipoIncidencia(ClaveTipo);
        }

        /// <summary>
        /// Delete Incidencia by TipoIncidencia
        /// </summary>
        public void DeleteByTipoIncidencia(IUniqueIdentifiable TipoIncidencia)
        {
            Instance().DeleteByTipoIncidencia(TipoIncidencia);
        }

    

        /// <summary>
        /// Delete Incidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(System.Int32 ClaveUsuario)
        {
            Instance().DeleteByUsuario(ClaveUsuario);
        }

        /// <summary>
        /// Delete Incidencia by Usuario
        /// </summary>
        public void DeleteByUsuario(IUniqueIdentifiable Usuario)
        {
            Instance().DeleteByUsuario(Usuario);
        }

    
        /// <summary>
        /// Delete Incidencia 
        /// </summary>
        public void Delete(System.Int32 Folio){
            Instance().Delete(Folio);
        }

        /// <summary>
        /// Delete Incidencia 
        /// </summary>
        public void Delete(Entities.Incidencia entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save Incidencia  
        /// </summary>
        public void Save(Entities.Incidencia entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Incidencia 
        /// </summary>
        public void Insert(Entities.Incidencia entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll Incidencia 
        /// </summary>
        public Entities.IncidenciaList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save Incidencia 
        /// </summary>
        public void Save(System.Int32 Folio, System.Int32 FolioPadre, System.String Descripcion, System.String Direccion, System.String Referencias, System.DateTime HoraRecepcion, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad, System.Int32 ClaveColonia, System.Int32 ClaveCodigoPostal, System.String Telefono, System.Int32 ClaveDenunciante, System.Int32 ClaveEstatus, System.Int32 ClaveUsuario, System.Boolean Activo, System.Int32 ClaveTipo){
            Entities.Incidencia entity = Instance().GetOne(Folio);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Folio", Folio));

            entity.FolioPadre = FolioPadre;
            entity.Descripcion = Descripcion;
            entity.Direccion = Direccion;
            entity.Referencias = Referencias;
            entity.HoraRecepcion = HoraRecepcion;
            entity.ClaveEstado = ClaveEstado;
            entity.ClaveMunicipio = ClaveMunicipio;
            entity.ClaveLocalidad = ClaveLocalidad;
            entity.ClaveColonia = ClaveColonia;
            entity.ClaveCodigoPostal = ClaveCodigoPostal;
            entity.Telefono = Telefono;
            entity.ClaveDenunciante = ClaveDenunciante;
            entity.ClaveEstatus = ClaveEstatus;
            entity.ClaveUsuario = ClaveUsuario;
            entity.Activo = Activo;
            entity.ClaveTipo = ClaveTipo;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert Incidencia
        /// </summary>
        public void Insert(System.Int32 FolioPadre, System.String Descripcion, System.String Direccion, System.String Referencias, System.DateTime HoraRecepcion, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad, System.Int32 ClaveColonia, System.Int32 ClaveCodigoPostal, System.String Telefono, System.Int32 ClaveDenunciante, System.Int32 ClaveEstatus, System.Int32 ClaveUsuario, System.Boolean Activo, System.Int32 ClaveTipo){
            Entities.Incidencia entity = new Entities.Incidencia();

            entity.FolioPadre = FolioPadre;
            entity.Descripcion = Descripcion;
            entity.Direccion = Direccion;
            entity.Referencias = Referencias;
            entity.HoraRecepcion = HoraRecepcion;
            entity.ClaveEstado = ClaveEstado;
            entity.ClaveMunicipio = ClaveMunicipio;
            entity.ClaveLocalidad = ClaveLocalidad;
            entity.ClaveColonia = ClaveColonia;
            entity.ClaveCodigoPostal = ClaveCodigoPostal;
            entity.Telefono = Telefono;
            entity.ClaveDenunciante = ClaveDenunciante;
            entity.ClaveEstatus = ClaveEstatus;
            entity.ClaveUsuario = ClaveUsuario;
            entity.Activo = Activo;
            entity.ClaveTipo = ClaveTipo;
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
    public partial class IncidenciaLoader<T> : BaseLoader< T, Incidencia, ObjectList<T>>, IGenericGateway where T : Incidencia, new()
    {

        #region "Singleton"

        static IncidenciaLoader<T> _instance;

        private IncidenciaLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static IncidenciaLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new IncidenciaLoader<T>();
                else {
                    IncidenciaLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.IncidenciaLoaderSingleton"] as IncidenciaLoader<T>;
                    if (inst == null) {
                        inst = new IncidenciaLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.IncidenciaLoaderSingleton", inst);
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
            
            string[] s ={"Folio"};
            return s;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type GetMappingType()
        {
            return typeof(Incidencia);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "Incidencia"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, Incidencia entity)
        {
            
            IMappeableIncidenciaObject Incidencia = (IMappeableIncidenciaObject)entity;
            Incidencia.HydrateFields(
            reader.GetInt32(0),
(reader.IsDBNull(1)) ? new System.Nullable<System.Int32>() : reader.GetInt32(1),
reader.GetString(2),
(reader.IsDBNull(3)) ? "" : reader.GetString(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
reader.GetDateTime(5),
(reader.IsDBNull(6)) ? new System.Nullable<System.Int32>() : reader.GetInt32(6),
(reader.IsDBNull(7)) ? new System.Nullable<System.Int32>() : reader.GetInt32(7),
(reader.IsDBNull(8)) ? new System.Nullable<System.Int32>() : reader.GetInt32(8),
(reader.IsDBNull(9)) ? new System.Nullable<System.Int32>() : reader.GetInt32(9),
(reader.IsDBNull(10)) ? new System.Nullable<System.Int32>() : reader.GetInt32(10),
(reader.IsDBNull(11)) ? "" : reader.GetString(11),
(reader.IsDBNull(12)) ? new System.Nullable<System.Int32>() : reader.GetInt32(12),
reader.GetInt32(13),
reader.GetInt32(14),
reader.GetBoolean(15),
(reader.IsDBNull(16)) ? new System.Nullable<System.Int32>() : reader.GetInt32(16));
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
            
            ((IMappeableIncidencia)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a Incidencia by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a IncidenciaList by execute a SQL Query Text
        /// </summary>
        public ObjectList<T> GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }

        /// <summary>
        /// GetOne By Params
        /// </summary>
        public T GetOne(System.Int32 Folio)
        {
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetOne", Folio);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByDenunciante(DbTransaction transaction, System.Int32 ClaveDenunciante)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByDenunciante", ClaveDenunciante);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByDenunciante(DbTransaction transaction, IUniqueIdentifiable Denunciante)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByDenunciante", Denunciante.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByEstatusIncidencia(DbTransaction transaction, System.Int32 ClaveEstatus)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByEstatusIncidencia", ClaveEstatus);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByEstatusIncidencia(DbTransaction transaction, IUniqueIdentifiable EstatusIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByEstatusIncidencia", EstatusIncidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByTipoIncidencia(DbTransaction transaction, System.Int32 ClaveTipo)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByTipoIncidencia", ClaveTipo);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByTipoIncidencia(DbTransaction transaction, IUniqueIdentifiable TipoIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByTipoIncidencia", TipoIncidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByUsuario(DbTransaction transaction, System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByUsuario(DbTransaction transaction, IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "Incidencia_GetByUsuario", Usuario.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByDenunciante(System.Int32 ClaveDenunciante)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByDenunciante", ClaveDenunciante);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByDenunciante(IUniqueIdentifiable Denunciante)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByDenunciante", Denunciante.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByEstatusIncidencia(System.Int32 ClaveEstatus)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByEstatusIncidencia", ClaveEstatus);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByEstatusIncidencia(IUniqueIdentifiable EstatusIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByEstatusIncidencia", EstatusIncidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByTipoIncidencia(System.Int32 ClaveTipo)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByTipoIncidencia", ClaveTipo);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByTipoIncidencia(IUniqueIdentifiable TipoIncidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByTipoIncidencia", TipoIncidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByUsuario(System.Int32 ClaveUsuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByUsuario", ClaveUsuario);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByUsuario(IUniqueIdentifiable Usuario)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "Incidencia_GetByUsuario", Usuario.Identifier());
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





