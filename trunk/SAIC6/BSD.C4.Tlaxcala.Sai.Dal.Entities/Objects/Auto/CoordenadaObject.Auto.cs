
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 8/31/2009 - 11:48 PM
// This is a partial class file. The other one is CoordenadaObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CoordenadaObject : BaseObject, IMappeableCoordenadaObject, IUniqueIdentifiable, IEquatable<CoordenadaObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public CoordenadaObject(): base()
        {

			_ClaveCoordenada =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public CoordenadaObject(
			System.Int32 ClaveCoordenada): base()
        {

			_ClaveCoordenada = ClaveCoordenada;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public CoordenadaObject(
			System.Int32 ClaveCoordenada,
			System.Nullable<System.Double> Longitud,
			System.Nullable<System.Double> Latitud): base()
        {

			_ClaveCoordenada = ClaveCoordenada;
			_Longitud = Longitud;
			_Latitud = Latitud;

            Initialized();
        }
        

        #endregion

        #region "Events"
        
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveCoordenada;
/// <summary>
///
/// </summary>
protected System.Nullable<System.Double> _Longitud;
/// <summary>
///
/// </summary>
protected System.Nullable<System.Double> _Latitud;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 ClaveCoordenada
        {
            get
            {
                return _ClaveCoordenada;
            }
            
        }
        
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Double> Longitud
        {
            get
            {
                return _Longitud;
            }
            
            set
            {
                base.PropertyModified();
                _Longitud = value;                
                
            }
            
        }
                
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Double> Latitud
        {
            get
            {
                return _Latitud;
            }
            
            set
            {
                base.PropertyModified();
                _Latitud = value;                
                
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
            CoordenadaObject newObject;
            CoordenadaObject newOriginalValue;

            newObject = (CoordenadaObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (CoordenadaObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new CoordenadaObject OriginalValue()
        {
            return (CoordenadaObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableCoordenadaObject.HydrateFields(
			System.Int32 ClaveCoordenada,
			System.Nullable<System.Double> Longitud,
			System.Nullable<System.Double> Latitud)
        {
        _ClaveCoordenada = ClaveCoordenada;
_Longitud = Longitud;
_Latitud = Latitud;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCoordenadaObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[3];
            _myArray[0] = _ClaveCoordenada;
if (_Longitud.HasValue) _myArray[1] = _Longitud.Value;
if (_Latitud.HasValue) _myArray[2] = _Latitud.Value;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCoordenadaObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[3];
            _myArray[0] = _ClaveCoordenada;
if (_Longitud.HasValue) _myArray[1] = _Longitud.Value;
if (_Latitud.HasValue) _myArray[2] = _Latitud.Value;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCoordenadaObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _ClaveCoordenada;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableCoordenadaObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _ClaveCoordenada = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            CoordenadaObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.ClaveCoordenada};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(CoordenadaObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableCoordenadaObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 ClaveCoordenada, 
			System.Nullable<System.Double> Longitud, 
			System.Nullable<System.Double> Latitud);

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
    public partial class CoordenadaObjectList : ObjectList<CoordenadaObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CoordenadaObjectListView
        : ObjectListView<Objects.CoordenadaObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public CoordenadaObjectListView(Objects.CoordenadaObjectList list): base(list)
        {
        }
    }
}

