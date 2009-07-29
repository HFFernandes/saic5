
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is PermisoObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PermisoObject : BaseObject, IMappeablePermisoObject, IUniqueIdentifiable, IEquatable<PermisoObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public PermisoObject(): base()
        {

			_Clave =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public PermisoObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PermisoObject(
			System.Int32 Clave,
			System.String Descripcion,
			System.Int32 Valor): base()
        {

			_Clave = Clave;
			_Descripcion = Descripcion;
			_Valor = Valor;

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
protected System.String _Descripcion;
/// <summary>
/// 
/// </summary>
protected System.Int32 _Valor;

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
        public virtual System.String Descripcion
        {
            get
            {
                return _Descripcion;
            }
            
            set
            {
                base.PropertyModified();
                _Descripcion = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Valor
        {
            get
            {
                return _Valor;
            }
            
            set
            {
                base.PropertyModified();
                _Valor = value;
                
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
            PermisoObject newObject;
            PermisoObject newOriginalValue;

            newObject = (PermisoObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (PermisoObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new PermisoObject OriginalValue()
        {
            return (PermisoObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeablePermisoObject.HydrateFields(
			System.Int32 Clave,
			System.String Descripcion,
			System.Int32 Valor)
        {
        _Clave = Clave;
_Descripcion = Descripcion;
_Valor = Valor;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePermisoObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[3];
            _myArray[0] = _Clave;
_myArray[1] = _Descripcion;
_myArray[2] = _Valor;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePermisoObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[3];
            _myArray[0] = _Clave;
_myArray[1] = _Descripcion;
_myArray[2] = _Valor;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePermisoObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeablePermisoObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Clave = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            PermisoObject o = null;
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
        public bool Equals(PermisoObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeablePermisoObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.String Descripcion, 
			System.Int32 Valor);

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
    public partial class PermisoObjectList : ObjectList<PermisoObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PermisoObjectListView
        : ObjectListView<Objects.PermisoObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public PermisoObjectListView(Objects.PermisoObjectList list): base(list)
        {
        }
    }
}


