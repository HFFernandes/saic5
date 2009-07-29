
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is CodigoPostalObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CodigoPostalObject : BaseObject, IMappeableCodigoPostalObject, IUniqueIdentifiable, IEquatable<CodigoPostalObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public CodigoPostalObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public CodigoPostalObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public CodigoPostalObject(
			System.Int32 Clave,
			System.String Valor): base()
        {

			_Clave = Clave;
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
protected System.String _Valor;

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
        public virtual System.String Valor
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
            CodigoPostalObject newObject;
            CodigoPostalObject newOriginalValue;

            newObject = (CodigoPostalObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (CodigoPostalObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new CodigoPostalObject OriginalValue()
        {
            return (CodigoPostalObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableCodigoPostalObject.HydrateFields(
			System.Int32 Clave,
			System.String Valor)
        {
        _Clave = Clave;
_Valor = Valor;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCodigoPostalObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[2];
            _myArray[0] = _Clave;
_myArray[1] = _Valor;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCodigoPostalObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[3];
            _myArray[0] = _Clave;
_myArray[1] = _Valor;
_myArray[2] = this.OriginalValue()._Clave;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCodigoPostalObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableCodigoPostalObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            
        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            CodigoPostalObject o = null;
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
        public bool Equals(CodigoPostalObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableCodigoPostalObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.String Valor);

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
    public partial class CodigoPostalObjectList : ObjectList<CodigoPostalObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CodigoPostalObjectListView
        : ObjectListView<Objects.CodigoPostalObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public CodigoPostalObjectListView(Objects.CodigoPostalObjectList list): base(list)
        {
        }
    }
}


