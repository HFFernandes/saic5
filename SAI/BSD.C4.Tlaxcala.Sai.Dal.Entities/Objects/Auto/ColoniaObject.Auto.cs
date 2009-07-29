
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is ColoniaObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ColoniaObject : BaseObject, IMappeableColoniaObject, IUniqueIdentifiable, IEquatable<ColoniaObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public ColoniaObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public ColoniaObject(
			System.Int32 Clave, System.Int32 ClaveEstado, System.Int32 ClaveMunicipio, System.Int32 ClaveLocalidad): base()
        {

			_Clave = Clave;
			_ClaveEstado = ClaveEstado;
			_ClaveMunicipio = ClaveMunicipio;
			_ClaveLocalidad = ClaveLocalidad;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ColoniaObject(
			System.Int32 Clave,
			System.Int32 ClaveEstado,
			System.Int32 ClaveMunicipio,
			System.Int32 ClaveLocalidad,
			System.String Nombre): base()
        {

			_Clave = Clave;
			_ClaveEstado = ClaveEstado;
			_ClaveMunicipio = ClaveMunicipio;
			_ClaveLocalidad = ClaveLocalidad;
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
protected System.Int32 _ClaveLocalidad;
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
        public virtual System.Int32 ClaveLocalidad
        {
            get
            {
                return _ClaveLocalidad;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveLocalidad = value;
                
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
            ColoniaObject newObject;
            ColoniaObject newOriginalValue;

            newObject = (ColoniaObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (ColoniaObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new ColoniaObject OriginalValue()
        {
            return (ColoniaObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableColoniaObject.HydrateFields(
			System.Int32 Clave,
			System.Int32 ClaveEstado,
			System.Int32 ClaveMunicipio,
			System.Int32 ClaveLocalidad,
			System.String Nombre)
        {
        _Clave = Clave;
_ClaveEstado = ClaveEstado;
_ClaveMunicipio = ClaveMunicipio;
_ClaveLocalidad = ClaveLocalidad;
_Nombre = Nombre;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableColoniaObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[5];
            _myArray[0] = _Clave;
_myArray[1] = _ClaveEstado;
_myArray[2] = _ClaveMunicipio;
_myArray[3] = _ClaveLocalidad;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[4] = _Nombre;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableColoniaObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[9];
            _myArray[0] = _Clave;
_myArray[1] = _ClaveEstado;
_myArray[2] = _ClaveMunicipio;
_myArray[3] = _ClaveLocalidad;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[4] = _Nombre;
_myArray[5] = this.OriginalValue()._Clave;
_myArray[6] = this.OriginalValue()._ClaveEstado;
_myArray[7] = this.OriginalValue()._ClaveMunicipio;
_myArray[8] = this.OriginalValue()._ClaveLocalidad;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableColoniaObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[4];
            _myArray[0] = _Clave;
_myArray[1] = _ClaveEstado;
_myArray[2] = _ClaveMunicipio;
_myArray[3] = _ClaveLocalidad;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableColoniaObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            
        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            ColoniaObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Clave, o.ClaveEstado, o.ClaveMunicipio, o.ClaveLocalidad};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(ColoniaObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableColoniaObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.Int32 ClaveEstado, 
			System.Int32 ClaveMunicipio, 
			System.Int32 ClaveLocalidad, 
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
    public partial class ColoniaObjectList : ObjectList<ColoniaObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ColoniaObjectListView
        : ObjectListView<Objects.ColoniaObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public ColoniaObjectListView(Objects.ColoniaObjectList list): base(list)
        {
        }
    }
}


