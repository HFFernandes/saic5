
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 29/07/2009 - 02:18 p.m.
// This is a partial class file. The other one is ListaUnidadesObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ListaUnidadesObject : BaseObject, IMappeableListaUnidadesObject, IUniqueIdentifiable, IEquatable<ListaUnidadesObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesObject(): base()
        {

			_Clave =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesObject(
			System.Int32 Clave,
			System.String Codigo,
			System.Int32 ClaveCorporacion,
			System.Boolean Activo): base()
        {

			_Clave = Clave;
			_Codigo = Codigo;
			_ClaveCorporacion = ClaveCorporacion;
			_Activo = Activo;

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
protected System.String _Codigo;
/// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveCorporacion;
/// <summary>
/// 
/// </summary>
protected System.Boolean _Activo;

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
        public virtual System.String Codigo
        {
            get
            {
                return _Codigo;
            }
            
            set
            {
                base.PropertyModified();
                _Codigo = value;
                
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
        /// 
        /// </summary>
        public virtual System.Boolean Activo
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
            ListaUnidadesObject newObject;
            ListaUnidadesObject newOriginalValue;

            newObject = (ListaUnidadesObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (ListaUnidadesObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new ListaUnidadesObject OriginalValue()
        {
            return (ListaUnidadesObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableListaUnidadesObject.HydrateFields(
			System.Int32 Clave,
			System.String Codigo,
			System.Int32 ClaveCorporacion,
			System.Boolean Activo)
        {
        _Clave = Clave;
_Codigo = Codigo;
_ClaveCorporacion = ClaveCorporacion;
_Activo = Activo;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableListaUnidadesObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[4];
            _myArray[0] = _Clave;
_myArray[1] = _Codigo;
_myArray[2] = _ClaveCorporacion;
_myArray[3] = _Activo;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableListaUnidadesObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[4];
            _myArray[0] = _Clave;
_myArray[1] = _Codigo;
_myArray[2] = _ClaveCorporacion;
_myArray[3] = _Activo;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableListaUnidadesObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableListaUnidadesObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Clave = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            ListaUnidadesObject o = null;
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
        public bool Equals(ListaUnidadesObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableListaUnidadesObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.String Codigo, 
			System.Int32 ClaveCorporacion, 
			System.Boolean Activo);

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
    public partial class ListaUnidadesObjectList : ObjectList<ListaUnidadesObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ListaUnidadesObjectListView
        : ObjectListView<Objects.ListaUnidadesObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesObjectListView(Objects.ListaUnidadesObjectList list): base(list)
        {
        }
    }
}


