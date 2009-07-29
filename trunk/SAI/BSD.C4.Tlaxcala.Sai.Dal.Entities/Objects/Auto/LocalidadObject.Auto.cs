
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is LocalidadObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LocalidadObject : BaseObject, IMappeableLocalidadObject, IUniqueIdentifiable, IEquatable<LocalidadObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public LocalidadObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public LocalidadObject(
			System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio): base()
        {

			_Clave = Clave;
			_ClaveEstado = ClaveEstado;
			_ClaveMunicipio = ClaveMunicipio;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public LocalidadObject(
			System.Int32 Clave,
			System.Int32 ClaveEstado,
			System.Int32 ClaveMunicipio,
			System.String Nombre): base()
        {

			_Clave = Clave;
			_ClaveEstado = ClaveEstado;
			_ClaveMunicipio = ClaveMunicipio;
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
protected System.Int32 _ClaveEstado;
/// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveMunicipio;
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
        public virtual System.Int32 ClaveEstado
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
        public virtual System.Int32 ClaveMunicipio
        {
            get
            {
                return _ClaveMunicipio;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveMunicipio = value;
                
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
            LocalidadObject newObject;
            LocalidadObject newOriginalValue;

            newObject = (LocalidadObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (LocalidadObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new LocalidadObject OriginalValue()
        {
            return (LocalidadObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableLocalidadObject.HydrateFields(
			System.Int32 Clave,
			System.Int32 ClaveEstado,
			System.Int32 ClaveMunicipio,
			System.String Nombre)
        {
        _Clave = Clave;
_ClaveEstado = ClaveEstado;
_ClaveMunicipio = ClaveMunicipio;
_Nombre = Nombre;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableLocalidadObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[4];
            _myArray[0] = _Clave;
_myArray[1] = _ClaveEstado;
_myArray[2] = _ClaveMunicipio;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[3] = _Nombre;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableLocalidadObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[7];
            _myArray[0] = _Clave;
_myArray[1] = _ClaveEstado;
_myArray[2] = _ClaveMunicipio;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[3] = _Nombre;
_myArray[4] = this.OriginalValue()._Clave;
_myArray[5] = this.OriginalValue()._ClaveEstado;
_myArray[6] = this.OriginalValue()._ClaveMunicipio;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableLocalidadObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[3];
            _myArray[0] = _Clave;
_myArray[1] = _ClaveEstado;
_myArray[2] = _ClaveMunicipio;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableLocalidadObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            
        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            LocalidadObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Clave, o.ClaveEstado, o.ClaveMunicipio};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(LocalidadObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableLocalidadObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.Int32 ClaveEstado, 
			System.Int32 ClaveMunicipio, 
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
    public partial class LocalidadObjectList : ObjectList<LocalidadObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LocalidadObjectListView
        : ObjectListView<Objects.LocalidadObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public LocalidadObjectListView(Objects.LocalidadObjectList list): base(list)
        {
        }
    }
}


