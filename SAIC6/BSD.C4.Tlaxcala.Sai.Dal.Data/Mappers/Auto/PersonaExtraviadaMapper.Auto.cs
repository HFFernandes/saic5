
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 01:50 p.m.
// This is a partial class file. The other one is PersonaExtraviadaMapper.cs
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
    public partial class PersonaExtraviadaMapper : BaseGateway<PersonaExtraviada, PersonaExtraviadaList>, IGenericGateway
    {


        #region "Singleton"

        static PersonaExtraviadaMapper _instance;

        private PersonaExtraviadaMapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PersonaExtraviadaMapper Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PersonaExtraviadaMapper();
                else {
                    PersonaExtraviadaMapper inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.PersonaExtraviadaMapperSingleton"] as PersonaExtraviadaMapper;
                    if (inst == null) {
                        inst = new PersonaExtraviadaMapper();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.PersonaExtraviadaMapperSingleton", inst);
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
            return typeof(PersonaExtraviada);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "PersonaExtraviada"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string RuleName
        {
            get {return typeof(PersonaExtraviadaMapper).FullName;}
        }


        

        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PersonaExtraviada entity)
        {
            
            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            PersonaExtraviada.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
reader.GetDateTime(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? "" : reader.GetString(5),
(reader.IsDBNull(6)) ? new System.Nullable<System.Int32>() : reader.GetInt32(6),
(reader.IsDBNull(7)) ? "" : reader.GetString(7),
(reader.IsDBNull(8)) ? new System.Nullable<System.Double>() : reader.GetDouble(8),
(reader.IsDBNull(9)) ? "" : reader.GetString(9),
(reader.IsDBNull(10)) ? "" : reader.GetString(10),
(reader.IsDBNull(11)) ? "" : reader.GetString(11),
(reader.IsDBNull(12)) ? "" : reader.GetString(12),
(reader.IsDBNull(13)) ? "" : reader.GetString(13),
(reader.IsDBNull(14)) ? "" : reader.GetString(14),
(reader.IsDBNull(15)) ? "" : reader.GetString(15),
(reader.IsDBNull(16)) ? "" : reader.GetString(16),
(reader.IsDBNull(17)) ? "" : reader.GetString(17),
(reader.IsDBNull(18)) ? "" : reader.GetString(18),
(reader.IsDBNull(19)) ? "" : reader.GetString(19),
(reader.IsDBNull(20)) ? "" : reader.GetString(20),
(reader.IsDBNull(21)) ? "" : reader.GetString(21));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForInsert(PersonaExtraviada entity)
        {

            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            return PersonaExtraviada.GetFieldsForInsert();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForUpdate(PersonaExtraviada entity)
        {

            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            return PersonaExtraviada.GetFieldsForUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override object[] GetFieldsForDelete(PersonaExtraviada entity)
        {

            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            return PersonaExtraviada.GetFieldsForDelete();
        }


        /// <summary>
        /// Raised after insert and update
        /// </summary>
        protected override void UpdateObjectFromOutputParams(PersonaExtraviada entity, object[] parameters)
        {
            // Update properties from Output parameters
            ((IMappeablePersonaExtraviadaObject) entity).UpdateObjectFromOutputParams(parameters);
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
        protected override void CompleteEntity(PersonaExtraviada entity)
        {
            
            ((IMappeablePersonaExtraviada)entity).CompleteEntity();
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
        /// Get a PersonaExtraviada by execute a SQL Query Text
        /// </summary>
        public PersonaExtraviada GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PersonaExtraviadaList by execute a SQL Query Text
        /// </summary>
        public PersonaExtraviadaList GetBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectListBySQLText(sqlQueryText);
        }


        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviada GetOne(System.Int32 Clave)
        {
            return base.GetOne(new PersonaExtraviada(Clave));
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviadaList GetByIncidencia(DbTransaction transaction, System.Int32 Folio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Folio);
        }

        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviadaList GetByIncidencia(DbTransaction transaction, IUniqueIdentifiable Incidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Incidencia.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviadaList GetByIncidencia(System.Int32 Folio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Folio);
        }

        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviadaList GetByIncidencia(IUniqueIdentifiable Incidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Incidencia.Identifier());
        }

    

        /// <summary>
        /// 
        /// </summary>
        public void Delete(System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_Delete", Clave);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Delete(DbTransaction transaction, System.Int32 Clave)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_Delete", Clave);
        }


        // Delete By Objects and Params
            



        

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByIncidencia(System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_DeleteByIncidencia", Folio);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByIncidencia(DbTransaction transaction, System.Int32 Folio)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_DeleteByIncidencia", Folio);
        }


        /// <summary>
        /// 
        /// </summary>
        public void DeleteByIncidencia(IUniqueIdentifiable Incidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_DeleteByIncidencia", Incidencia.Identifier());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteByIncidencia(DbTransaction transaction, IUniqueIdentifiable Incidencia)
        {
            base.DataBaseHelper.ExecuteNoQueryByStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_DeleteByIncidencia", Incidencia.Identifier());
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
    public class PersonaExtraviadaMapperWrapper
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
        public BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.PersonaExtraviadaMapper Instance()
        {
            return BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers.PersonaExtraviadaMapper.Instance(); 
        }
        
        /// <summary>
        /// Get a PersonaExtraviadaEntity by calling a Stored Procedure
        /// </summary>
        public Entities.PersonaExtraviada GetOne(System.Int32 Clave) {
            return Instance().GetOne( Clave);
        }

        // GetBy Objects and Params
            

        

        /// <summary>
        /// Get a PersonaExtraviadaList by calling a Stored Procedure
        /// </summary>
        public Entities.PersonaExtraviadaList GetByIncidencia(System.Int32 Folio)
        {
            return Instance().GetByIncidencia(Folio);
        }

        /// <summary>
        /// Get a PersonaExtraviadaList by calling a Stored Procedure
        /// </summary>
        public Entities.PersonaExtraviadaList GetByIncidencia(IUniqueIdentifiable Incidencia)
        {
            return Instance().GetByIncidencia(Incidencia);
        }

    

       

        /// <summary>
        /// Delete children for PersonaExtraviada
        /// </summary>
        public void DeleteChildren(DbTransaction transaction, PersonaExtraviada entity)
        {
            Instance().DeleteChildren(transaction, entity);
        }

        

            

        

        /// <summary>
        /// Delete PersonaExtraviada by Incidencia
        /// </summary>
        public void DeleteByIncidencia(System.Int32 Folio)
        {
            Instance().DeleteByIncidencia(Folio);
        }

        /// <summary>
        /// Delete PersonaExtraviada by Incidencia
        /// </summary>
        public void DeleteByIncidencia(IUniqueIdentifiable Incidencia)
        {
            Instance().DeleteByIncidencia(Incidencia);
        }

    
        /// <summary>
        /// Delete PersonaExtraviada 
        /// </summary>
        public void Delete(System.Int32 Clave){
            Instance().Delete(Clave);
        }

        /// <summary>
        /// Delete PersonaExtraviada 
        /// </summary>
        public void Delete(Entities.PersonaExtraviada entity ){
            Instance().Delete(entity);
        }

        /// <summary>
        /// Save PersonaExtraviada  
        /// </summary>
        public void Save(Entities.PersonaExtraviada entity){
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PersonaExtraviada 
        /// </summary>
        public void Insert(Entities.PersonaExtraviada entity){
            Instance().Insert(entity);
        }

        /// <summary>
        /// GetAll PersonaExtraviada 
        /// </summary>
        public Entities.PersonaExtraviadaList GetAll(){  
            return Instance().GetAll();
        }

        /// <summary>
        /// Save PersonaExtraviada 
        /// </summary>
        public void Save(System.Int32 Clave, System.Int32 Folio, System.String Parentesco, System.DateTime FechaExtravio, System.String Destino, System.String Nombre, System.Int32 Edad, System.String Sexo, System.Double Estatura, System.String Tez, System.String TipoCabello, System.String ColorCabello, System.String LargoCabello, System.String Frente, System.String Cejas, System.String OjosColor, System.String OjosForma, System.String NarizForma, System.String BocaTamaño, System.String Labios, System.String Vestimenta, System.String Caracteristicas){
            Entities.PersonaExtraviada entity = Instance().GetOne(Clave);
            if (entity == null)
                throw new ApplicationException(String.Format("Entity not found. IUniqueIdentifiable Values: {0} = {1}", "Clave", Clave));

            entity.Folio = Folio;
            entity.Parentesco = Parentesco;
            entity.FechaExtravio = FechaExtravio;
            entity.Destino = Destino;
            entity.Nombre = Nombre;
            entity.Edad = Edad;
            entity.Sexo = Sexo;
            entity.Estatura = Estatura;
            entity.Tez = Tez;
            entity.TipoCabello = TipoCabello;
            entity.ColorCabello = ColorCabello;
            entity.LargoCabello = LargoCabello;
            entity.Frente = Frente;
            entity.Cejas = Cejas;
            entity.OjosColor = OjosColor;
            entity.OjosForma = OjosForma;
            entity.NarizForma = NarizForma;
            entity.BocaTamaño = BocaTamaño;
            entity.Labios = Labios;
            entity.Vestimenta = Vestimenta;
            entity.Caracteristicas = Caracteristicas;
            Instance().Save(entity);
        }

        /// <summary>
        /// Insert PersonaExtraviada
        /// </summary>
        public void Insert(System.Int32 Folio, System.String Parentesco, System.DateTime FechaExtravio, System.String Destino, System.String Nombre, System.Int32 Edad, System.String Sexo, System.Double Estatura, System.String Tez, System.String TipoCabello, System.String ColorCabello, System.String LargoCabello, System.String Frente, System.String Cejas, System.String OjosColor, System.String OjosForma, System.String NarizForma, System.String BocaTamaño, System.String Labios, System.String Vestimenta, System.String Caracteristicas){
            Entities.PersonaExtraviada entity = new Entities.PersonaExtraviada();

            entity.Folio = Folio;
            entity.Parentesco = Parentesco;
            entity.FechaExtravio = FechaExtravio;
            entity.Destino = Destino;
            entity.Nombre = Nombre;
            entity.Edad = Edad;
            entity.Sexo = Sexo;
            entity.Estatura = Estatura;
            entity.Tez = Tez;
            entity.TipoCabello = TipoCabello;
            entity.ColorCabello = ColorCabello;
            entity.LargoCabello = LargoCabello;
            entity.Frente = Frente;
            entity.Cejas = Cejas;
            entity.OjosColor = OjosColor;
            entity.OjosForma = OjosForma;
            entity.NarizForma = NarizForma;
            entity.BocaTamaño = BocaTamaño;
            entity.Labios = Labios;
            entity.Vestimenta = Vestimenta;
            entity.Caracteristicas = Caracteristicas;
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
    public partial class PersonaExtraviadaLoader<T> : BaseLoader< T, PersonaExtraviada, ObjectList<T>>, IGenericGateway where T : PersonaExtraviada, new()
    {

        #region "Singleton"

        static PersonaExtraviadaLoader<T> _instance;

        private PersonaExtraviadaLoader()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static PersonaExtraviadaLoader<T> Instance() {
            if (_instance == null) {
                if (HttpContext.Current == null) 
                    _instance = new PersonaExtraviadaLoader<T>();
                else {
                    PersonaExtraviadaLoader<T> inst = HttpContext.Current.Items["BSD.C4.Tlaxcala.Sai.Dal.Rules.PersonaExtraviadaLoaderSingleton"] as PersonaExtraviadaLoader<T>;
                    if (inst == null) {
                        inst = new PersonaExtraviadaLoader<T>();
                        HttpContext.Current.Items.Add("BSD.C4.Tlaxcala.Sai.Dal.Rules.PersonaExtraviadaLoaderSingleton", inst);
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
            return typeof(PersonaExtraviada);
        }


        /// <summary>
        /// 
        /// </summary>
        protected override string TableName
        {
            get { return "PersonaExtraviada"; }
        }

        
        
        /// <summary>
        /// 
        /// </summary>
        protected override void HydrateFields(DbDataReader reader, PersonaExtraviada entity)
        {
            
            IMappeablePersonaExtraviadaObject PersonaExtraviada = (IMappeablePersonaExtraviadaObject)entity;
            PersonaExtraviada.HydrateFields(
            reader.GetInt32(0),
reader.GetInt32(1),
(reader.IsDBNull(2)) ? "" : reader.GetString(2),
reader.GetDateTime(3),
(reader.IsDBNull(4)) ? "" : reader.GetString(4),
(reader.IsDBNull(5)) ? "" : reader.GetString(5),
(reader.IsDBNull(6)) ? new System.Nullable<System.Int32>() : reader.GetInt32(6),
(reader.IsDBNull(7)) ? "" : reader.GetString(7),
(reader.IsDBNull(8)) ? new System.Nullable<System.Double>() : reader.GetDouble(8),
(reader.IsDBNull(9)) ? "" : reader.GetString(9),
(reader.IsDBNull(10)) ? "" : reader.GetString(10),
(reader.IsDBNull(11)) ? "" : reader.GetString(11),
(reader.IsDBNull(12)) ? "" : reader.GetString(12),
(reader.IsDBNull(13)) ? "" : reader.GetString(13),
(reader.IsDBNull(14)) ? "" : reader.GetString(14),
(reader.IsDBNull(15)) ? "" : reader.GetString(15),
(reader.IsDBNull(16)) ? "" : reader.GetString(16),
(reader.IsDBNull(17)) ? "" : reader.GetString(17),
(reader.IsDBNull(18)) ? "" : reader.GetString(18),
(reader.IsDBNull(19)) ? "" : reader.GetString(19),
(reader.IsDBNull(20)) ? "" : reader.GetString(20),
(reader.IsDBNull(21)) ? "" : reader.GetString(21));
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
            
            ((IMappeablePersonaExtraviada)entity).CompleteEntity();
        }


        



        /// <summary>
        /// Get a PersonaExtraviada by execute a SQL Query Text
        /// </summary>
        public T GetOneBySQLQuery(string sqlQueryText)
        {
            return base.GetObjectBySQLText(sqlQueryText);
        }

        /// <summary>
        /// Get a PersonaExtraviadaList by execute a SQL Query Text
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
            return base.GetObjectByAnyStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_GetOne", Clave);
        }


        // GetOne By Objects and Params
            


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByIncidencia(DbTransaction transaction, System.Int32 Folio)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Folio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByIncidencia(DbTransaction transaction, IUniqueIdentifiable Incidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(transaction, StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Incidencia.Identifier());
        }

    


        

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByIncidencia(System.Int32 Folio)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Folio);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObjectList<T> GetByIncidencia(IUniqueIdentifiable Incidencia)
        {
            return base.GetObjectListByAnyStoredProcedure(StoredProceduresPrefix() + "PersonaExtraviada_GetByIncidencia", Incidencia.Identifier());
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




