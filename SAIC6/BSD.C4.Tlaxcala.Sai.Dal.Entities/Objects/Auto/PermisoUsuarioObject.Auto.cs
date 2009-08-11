
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 10/08/2009 - 08:53 p.m.
// This is a partial class file. The other one is PermisoUsuarioObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PermisoUsuarioObject : BaseObject, IMappeablePermisoUsuarioObject, IUniqueIdentifiable, IEquatable<PermisoUsuarioObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public PermisoUsuarioObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public PermisoUsuarioObject(
			System.Int32 ClaveUsuario, System.Int32 ClaveSubmodulo, System.Int32 ClavePermiso, System.Int32 ClaveSistema): base()
        {

			_ClaveUsuario = ClaveUsuario;
			_ClaveSubmodulo = ClaveSubmodulo;
			_ClavePermiso = ClavePermiso;
			_ClaveSistema = ClaveSistema;

            Initialized();
        }

        

        #endregion

        #region "Events"
        
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveUsuario;
/// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveSubmodulo;
/// <summary>
/// 
/// </summary>
protected System.Int32 _ClavePermiso;
/// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveSistema;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 ClaveUsuario
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
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 ClaveSubmodulo
        {
            get
            {
                return _ClaveSubmodulo;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveSubmodulo = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 ClavePermiso
        {
            get
            {
                return _ClavePermiso;
            }
            
            set
            {
                base.PropertyModified();
                _ClavePermiso = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 ClaveSistema
        {
            get
            {
                return _ClaveSistema;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveSistema = value;
                
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
            PermisoUsuarioObject newObject;
            PermisoUsuarioObject newOriginalValue;

            newObject = (PermisoUsuarioObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (PermisoUsuarioObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new PermisoUsuarioObject OriginalValue()
        {
            return (PermisoUsuarioObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeablePermisoUsuarioObject.HydrateFields(
			System.Int32 ClaveUsuario,
			System.Int32 ClaveSubmodulo,
			System.Int32 ClavePermiso,
			System.Int32 ClaveSistema)
        {
        _ClaveUsuario = ClaveUsuario;
_ClaveSubmodulo = ClaveSubmodulo;
_ClavePermiso = ClavePermiso;
_ClaveSistema = ClaveSistema;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePermisoUsuarioObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[4];
            _myArray[0] = _ClaveUsuario;
_myArray[1] = _ClaveSubmodulo;
_myArray[2] = _ClavePermiso;
_myArray[3] = _ClaveSistema;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePermisoUsuarioObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[8];
            _myArray[0] = _ClaveUsuario;
_myArray[1] = _ClaveSubmodulo;
_myArray[2] = _ClavePermiso;
_myArray[3] = _ClaveSistema;
_myArray[4] = this.OriginalValue()._ClaveUsuario;
_myArray[5] = this.OriginalValue()._ClaveSubmodulo;
_myArray[6] = this.OriginalValue()._ClavePermiso;
_myArray[7] = this.OriginalValue()._ClaveSistema;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePermisoUsuarioObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[4];
            _myArray[0] = _ClaveUsuario;
_myArray[1] = _ClaveSubmodulo;
_myArray[2] = _ClavePermiso;
_myArray[3] = _ClaveSistema;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeablePermisoUsuarioObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            
        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            PermisoUsuarioObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.ClaveUsuario, o.ClaveSubmodulo, o.ClavePermiso, o.ClaveSistema};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(PermisoUsuarioObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeablePermisoUsuarioObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 ClaveUsuario, 
			System.Int32 ClaveSubmodulo, 
			System.Int32 ClavePermiso, 
			System.Int32 ClaveSistema);

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
    public partial class PermisoUsuarioObjectList : ObjectList<PermisoUsuarioObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PermisoUsuarioObjectListView
        : ObjectListView<Objects.PermisoUsuarioObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public PermisoUsuarioObjectListView(Objects.PermisoUsuarioObjectList list): base(list)
        {
        }
    }
}


