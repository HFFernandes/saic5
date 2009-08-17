
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 17/08/2009 - 04:24 p.m.
// This is a partial class file. The other one is DependenciaObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DependenciaObject : BaseObject, IMappeableDependenciaObject, IUniqueIdentifiable, IEquatable<DependenciaObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public DependenciaObject(): base()
        {

			_Clave =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public DependenciaObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public DependenciaObject(
			System.Int32 Clave,
			System.String Descripcion): base()
        {

			_Clave = Clave;
			_Descripcion = Descripcion;

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
            DependenciaObject newObject;
            DependenciaObject newOriginalValue;

            newObject = (DependenciaObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (DependenciaObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new DependenciaObject OriginalValue()
        {
            return (DependenciaObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableDependenciaObject.HydrateFields(
			System.Int32 Clave,
			System.String Descripcion)
        {
        _Clave = Clave;
_Descripcion = Descripcion;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDependenciaObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[2];
            _myArray[0] = _Clave;
if (!System.String.IsNullOrEmpty(_Descripcion)) _myArray[1] = _Descripcion;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDependenciaObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[2];
            _myArray[0] = _Clave;
if (!System.String.IsNullOrEmpty(_Descripcion)) _myArray[1] = _Descripcion;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableDependenciaObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableDependenciaObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Clave = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            DependenciaObject o = null;
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
        public bool Equals(DependenciaObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableDependenciaObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.String Descripcion);

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
    public partial class DependenciaObjectList : ObjectList<DependenciaObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DependenciaObjectListView
        : ObjectListView<Objects.DependenciaObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public DependenciaObjectListView(Objects.DependenciaObjectList list): base(list)
        {
        }
    }
}


