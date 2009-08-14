
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 13/08/2009 - 08:13 p.m.
// This is a partial class file. The other one is DespachoIncidenciaObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DespachoIncidenciaObject : BaseObject, IMappeableDespachoIncidenciaObject, IUniqueIdentifiable, IEquatable<DespachoIncidenciaObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public DespachoIncidenciaObject(): base()
        {

			_Clave =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public DespachoIncidenciaObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public DespachoIncidenciaObject(
			System.Int32 Clave,
			System.Int32 ClaveCorporacion,
			System.Nullable<System.Int32> ClaveUnidad,
			System.Int32 Folio,
			System.Nullable<System.DateTime> HoraDespachada,
			System.Nullable<System.DateTime> HoraLlegada,
			System.Nullable<System.DateTime> HoraLiberada,
			System.Nullable<System.Int32> ClaveUnidadApoyo,
			System.Nullable<System.Int32> ClaveUsuario): base()
        {

			_Clave = Clave;
			_ClaveCorporacion = ClaveCorporacion;
			_ClaveUnidad = ClaveUnidad;
			_Folio = Folio;
			_HoraDespachada = HoraDespachada;
			_HoraLlegada = HoraLlegada;
			_HoraLiberada = HoraLiberada;
			_ClaveUnidadApoyo = ClaveUnidadApoyo;
			_ClaveUsuario = ClaveUsuario;

            Initialized();
        }
        

        #endregion

        #region "Events"
        
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _Clave;
/// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveCorporacion;
/// <summary>
///
/// </summary>
protected System.Nullable<System.Int32> _ClaveUnidad;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Folio;
/// <summary>
///
/// </summary>
protected System.Nullable<System.DateTime> _HoraDespachada;
/// <summary>
///
/// </summary>
protected System.Nullable<System.DateTime> _HoraLlegada;
/// <summary>
///
/// </summary>
protected System.Nullable<System.DateTime> _HoraLiberada;
/// <summary>
///
/// </summary>
protected System.Nullable<System.Int32> _ClaveUnidadApoyo;
/// <summary>
///
/// </summary>
protected System.Nullable<System.Int32> _ClaveUsuario;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Clave
        {
            get
            {
                return _Clave;
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 ClaveCorporacion
        {
            get
            {
                return _ClaveCorporacion;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveCorporacion = value;
                
            }
            
        }
        
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Int32> ClaveUnidad
        {
            get
            {
                return _ClaveUnidad;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveUnidad = value;                
                
            }
            
        }
                
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Folio
        {
            get
            {
                return _Folio;
            }
            
            set
            {
                base.PropertyModified();
                _Folio = value;
                
            }
            
        }
        
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.DateTime> HoraDespachada
        {
            get
            {
                return _HoraDespachada;
            }
            
            set
            {
                base.PropertyModified();
                _HoraDespachada = value;                
                
            }
            
        }
                
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.DateTime> HoraLlegada
        {
            get
            {
                return _HoraLlegada;
            }
            
            set
            {
                base.PropertyModified();
                _HoraLlegada = value;                
                
            }
            
        }
                
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.DateTime> HoraLiberada
        {
            get
            {
                return _HoraLiberada;
            }
            
            set
            {
                base.PropertyModified();
                _HoraLiberada = value;                
                
            }
            
        }
                
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Int32> ClaveUnidadApoyo
        {
            get
            {
                return _ClaveUnidadApoyo;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveUnidadApoyo = value;                
                
            }
            
        }
                
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Int32> ClaveUsuario
        {
            get
            {
                return _ClaveUsuario;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveUsuario = value;                
                
            }
            
        }
                
        #endregion

        
            
                
        /// <summary>
        /// 
        /// </summary>
        protected override void SetOriginalValue()
        {
            base._OriginalValue = (IObject) this.MemberwiseClone();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            DespachoIncidenciaObject newObject;
            DespachoIncidenciaObject newOriginalValue;

            newObject = (DespachoIncidenciaObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (DespachoIncidenciaObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new DespachoIncidenciaObject OriginalValue()
        {
            return (DespachoIncidenciaObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableDespachoIncidenciaObject.HydrateFields(
			System.Int32 Clave,
			System.Int32 ClaveCorporacion,
			System.Nullable<System.Int32> ClaveUnidad,
			System.Int32 Folio,
			System.Nullable<System.DateTime> HoraDespachada,
			System.Nullable<System.DateTime> HoraLlegada,
			System.Nullable<System.DateTime> HoraLiberada,
			System.Nullable<System.Int32> ClaveUnidadApoyo,
			System.Nullable<System.Int32> ClaveUsuario)
        {
        _Clave = Clave;
_ClaveCorporacion = ClaveCorporacion;
_ClaveUnidad = ClaveUnidad;
_Folio = Folio;
_HoraDespachada = HoraDespachada;
_HoraLlegada = HoraLlegada;
_HoraLiberada = HoraLiberada;
_ClaveUnidadApoyo = ClaveUnidadApoyo;
_ClaveUsuario = ClaveUsuario;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDespachoIncidenciaObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[9];
            _myArray[0] = _Clave;
_myArray[1] = _ClaveCorporacion;
if (_ClaveUnidad.HasValue) _myArray[2] = _ClaveUnidad.Value;
_myArray[3] = _Folio;
if (_HoraDespachada.HasValue) _myArray[4] = _HoraDespachada.Value;
if (_HoraLlegada.HasValue) _myArray[5] = _HoraLlegada.Value;
if (_HoraLiberada.HasValue) _myArray[6] = _HoraLiberada.Value;
if (_ClaveUnidadApoyo.HasValue) _myArray[7] = _ClaveUnidadApoyo.Value;
if (_ClaveUsuario.HasValue) _myArray[8] = _ClaveUsuario.Value;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDespachoIncidenciaObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[9];
            _myArray[0] = _Clave;
_myArray[1] = _ClaveCorporacion;
if (_ClaveUnidad.HasValue) _myArray[2] = _ClaveUnidad.Value;
_myArray[3] = _Folio;
if (_HoraDespachada.HasValue) _myArray[4] = _HoraDespachada.Value;
if (_HoraLlegada.HasValue) _myArray[5] = _HoraLlegada.Value;
if (_HoraLiberada.HasValue) _myArray[6] = _HoraLiberada.Value;
if (_ClaveUnidadApoyo.HasValue) _myArray[7] = _ClaveUnidadApoyo.Value;
if (_ClaveUsuario.HasValue) _myArray[8] = _ClaveUsuario.Value;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDespachoIncidenciaObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableDespachoIncidenciaObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Clave = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            DespachoIncidenciaObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Clave};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(DespachoIncidenciaObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableDespachoIncidenciaObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.Int32 ClaveCorporacion, 
			System.Nullable<System.Int32> ClaveUnidad, 
			System.Int32 Folio, 
			System.Nullable<System.DateTime> HoraDespachada, 
			System.Nullable<System.DateTime> HoraLlegada, 
			System.Nullable<System.DateTime> HoraLiberada, 
			System.Nullable<System.Int32> ClaveUnidadApoyo, 
			System.Nullable<System.Int32> ClaveUsuario);

        /// <summary>
        /// 
        /// </summary>
        object[] GetFieldsForInsert();

        /// <summary>
        /// 
        /// </summary>
        object[] GetFieldsForUpdate();

        /// <summary>
        /// 
        /// </summary>
        object[] GetFieldsForDelete();

        /// <summary>
        /// 
        /// </summary>
        void UpdateObjectFromOutputParams(object[] parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class DespachoIncidenciaObjectList : ObjectList<DespachoIncidenciaObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DespachoIncidenciaObjectListView
        : ObjectListView<Objects.DespachoIncidenciaObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public DespachoIncidenciaObjectListView(Objects.DespachoIncidenciaObjectList list): base(list)
        {
        }
    }
}


