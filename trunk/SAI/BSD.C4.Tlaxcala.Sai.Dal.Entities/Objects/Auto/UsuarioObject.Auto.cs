
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is UsuarioObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UsuarioObject : BaseObject, IMappeableUsuarioObject, IUniqueIdentifiable, IEquatable<UsuarioObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public UsuarioObject(): base()
        {

			_Clave =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public UsuarioObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public UsuarioObject(
			System.Int32 Clave,
			System.String NombreUsuario,
			System.String NombrePropio,
			System.Nullable<System.Boolean> Activo,
			System.String Contraseña): base()
        {

			_Clave = Clave;
			_NombreUsuario = NombreUsuario;
			_NombrePropio = NombrePropio;
			_Activo = Activo;
			_Contraseña = Contraseña;

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
protected System.String _NombreUsuario;
/// <summary>
/// 
/// </summary>
protected System.String _NombrePropio;
/// <summary>
///
/// </summary>
protected System.Nullable<System.Boolean> _Activo;
/// <summary>
/// 
/// </summary>
protected System.String _Contraseña;

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
        public virtual System.String NombreUsuario
        {
            get
            {
                return _NombreUsuario;
            }
            
            set
            {
                base.PropertyModified();
                _NombreUsuario = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String NombrePropio
        {
            get
            {
                return _NombrePropio;
            }
            
            set
            {
                base.PropertyModified();
                _NombrePropio = value;
                
            }
            
        }
        
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Boolean> Activo
        {
            get
            {
                return _Activo;
            }
            
            set
            {
                base.PropertyModified();
                _Activo = value;                
                
            }
            
        }
                
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Contraseña
        {
            get
            {
                return _Contraseña;
            }
            
            set
            {
                base.PropertyModified();
                _Contraseña = value;
                
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
            UsuarioObject newObject;
            UsuarioObject newOriginalValue;

            newObject = (UsuarioObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (UsuarioObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new UsuarioObject OriginalValue()
        {
            return (UsuarioObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableUsuarioObject.HydrateFields(
			System.Int32 Clave,
			System.String NombreUsuario,
			System.String NombrePropio,
			System.Nullable<System.Boolean> Activo,
			System.String Contraseña)
        {
        _Clave = Clave;
_NombreUsuario = NombreUsuario;
_NombrePropio = NombrePropio;
_Activo = Activo;
_Contraseña = Contraseña;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUsuarioObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[5];
            _myArray[0] = _Clave;
_myArray[1] = _NombreUsuario;
if (!System.String.IsNullOrEmpty(_NombrePropio)) _myArray[2] = _NombrePropio;
if (_Activo.HasValue) _myArray[3] = _Activo.Value;
if (!System.String.IsNullOrEmpty(_Contraseña)) _myArray[4] = _Contraseña;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUsuarioObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[5];
            _myArray[0] = _Clave;
_myArray[1] = _NombreUsuario;
if (!System.String.IsNullOrEmpty(_NombrePropio)) _myArray[2] = _NombrePropio;
if (_Activo.HasValue) _myArray[3] = _Activo.Value;
if (!System.String.IsNullOrEmpty(_Contraseña)) _myArray[4] = _Contraseña;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableUsuarioObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableUsuarioObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Clave = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            UsuarioObject o = null;
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
        public bool Equals(UsuarioObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableUsuarioObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.String NombreUsuario, 
			System.String NombrePropio, 
			System.Nullable<System.Boolean> Activo, 
			System.String Contraseña);

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
    public partial class UsuarioObjectList : ObjectList<UsuarioObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UsuarioObjectListView
        : ObjectListView<Objects.UsuarioObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public UsuarioObjectListView(Objects.UsuarioObjectList list): base(list)
        {
        }
    }
}


