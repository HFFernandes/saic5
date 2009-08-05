
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 05/08/2009 - 01:41 p.m.
// This is a partial class file. The other one is MunicipioObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MunicipioObject : BaseObject, IMappeableMunicipioObject, IUniqueIdentifiable, IEquatable<MunicipioObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public MunicipioObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public MunicipioObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public MunicipioObject(
			System.Int32 Clave,
			System.Nullable<System.Int32> ClaveEstado,
			System.String Nombre): base()
        {

			_Clave = Clave;
			_ClaveEstado = ClaveEstado;
			_Nombre = Nombre;

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
protected System.Nullable<System.Int32> _ClaveEstado;
/// <summary>
/// 
/// </summary>
protected System.String _Nombre;

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
            
            set
            {
                base.PropertyModified();
                _Clave = value;
                
            }
            
        }
        
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Int32> ClaveEstado
        {
            get
            {
                return _ClaveEstado;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveEstado = value;                
                
            }
            
        }
                
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Nombre
        {
            get
            {
                return _Nombre;
            }
            
            set
            {
                base.PropertyModified();
                _Nombre = value;
                
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
            MunicipioObject newObject;
            MunicipioObject newOriginalValue;

            newObject = (MunicipioObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (MunicipioObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new MunicipioObject OriginalValue()
        {
            return (MunicipioObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableMunicipioObject.HydrateFields(
			System.Int32 Clave,
			System.Nullable<System.Int32> ClaveEstado,
			System.String Nombre)
        {
        _Clave = Clave;
_ClaveEstado = ClaveEstado;
_Nombre = Nombre;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableMunicipioObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[3];
            _myArray[0] = _Clave;
if (_ClaveEstado.HasValue) _myArray[1] = _ClaveEstado.Value;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[2] = _Nombre;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableMunicipioObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[4];
            _myArray[0] = _Clave;
if (_ClaveEstado.HasValue) _myArray[1] = _ClaveEstado.Value;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[2] = _Nombre;
_myArray[3] = this.OriginalValue()._Clave;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableMunicipioObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableMunicipioObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            
        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            MunicipioObject o = null;
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
        public bool Equals(MunicipioObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableMunicipioObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.Nullable<System.Int32> ClaveEstado, 
			System.String Nombre);

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
    public partial class MunicipioObjectList : ObjectList<MunicipioObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MunicipioObjectListView
        : ObjectListView<Objects.MunicipioObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public MunicipioObjectListView(Objects.MunicipioObjectList list): base(list)
        {
        }
    }
}


