
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is EstadoObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EstadoObject : BaseObject, IMappeableEstadoObject, IUniqueIdentifiable, IEquatable<EstadoObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public EstadoObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public EstadoObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public EstadoObject(
			System.Int32 Clave,
			System.String Nombre): base()
        {

			_Clave = Clave;
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
            EstadoObject newObject;
            EstadoObject newOriginalValue;

            newObject = (EstadoObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (EstadoObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new EstadoObject OriginalValue()
        {
            return (EstadoObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableEstadoObject.HydrateFields(
			System.Int32 Clave,
			System.String Nombre)
        {
        _Clave = Clave;
_Nombre = Nombre;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableEstadoObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[2];
            _myArray[0] = _Clave;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[1] = _Nombre;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableEstadoObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[3];
            _myArray[0] = _Clave;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[1] = _Nombre;
_myArray[2] = this.OriginalValue()._Clave;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableEstadoObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableEstadoObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            
        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            EstadoObject o = null;
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
        public bool Equals(EstadoObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableEstadoObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
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
    public partial class EstadoObjectList : ObjectList<EstadoObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EstadoObjectListView
        : ObjectListView<Objects.EstadoObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public EstadoObjectListView(Objects.EstadoObjectList list): base(list)
        {
        }
    }
}

