
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 29/07/2009 - 02:18 p.m.
// This is a partial class file. The other one is CorporacionIncidenciaObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CorporacionIncidenciaObject : BaseObject, IMappeableCorporacionIncidenciaObject, IUniqueIdentifiable, IEquatable<CorporacionIncidenciaObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public CorporacionIncidenciaObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public CorporacionIncidenciaObject(
			System.Int32 Folio, System.Int32 ClaveCorporacion): base()
        {

			_Folio = Folio;
			_ClaveCorporacion = ClaveCorporacion;

            Initialized();
        }

        

        #endregion

        #region "Events"
        
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _Folio;
/// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveCorporacion;
/// <summary>
/// 
/// </summary>
protected System.Byte[] _HoraDespacho;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 Folio
        {
            get
            {
                return _Folio;
            }
            
            set
            {
                base.PropertyModified();
                _Folio = value;
                
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
        public virtual System.Byte[] HoraDespacho
        {
            get
            {
                return _HoraDespacho;
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
            CorporacionIncidenciaObject newObject;
            CorporacionIncidenciaObject newOriginalValue;

            newObject = (CorporacionIncidenciaObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (CorporacionIncidenciaObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new CorporacionIncidenciaObject OriginalValue()
        {
            return (CorporacionIncidenciaObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableCorporacionIncidenciaObject.HydrateFields(
			System.Int32 Folio,
			System.Int32 ClaveCorporacion,
			System.Byte[] HoraDespacho)
        {
        _Folio = Folio;
_ClaveCorporacion = ClaveCorporacion;
_HoraDespacho = HoraDespacho;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCorporacionIncidenciaObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[3];
            _myArray[0] = _Folio;
_myArray[1] = _ClaveCorporacion;
_myArray[2] = _HoraDespacho;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCorporacionIncidenciaObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[5];
            _myArray[0] = _Folio;
_myArray[1] = _ClaveCorporacion;
_myArray[2] = _HoraDespacho;
_myArray[3] = this.OriginalValue()._Folio;
_myArray[4] = this.OriginalValue()._ClaveCorporacion;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableCorporacionIncidenciaObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[3];
            _myArray[0] = _Folio;
_myArray[1] = _ClaveCorporacion;
_myArray[2] = _HoraDespacho;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableCorporacionIncidenciaObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _HoraDespacho = (System.Byte[]) parameters[2];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            CorporacionIncidenciaObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.Folio, o.ClaveCorporacion};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(CorporacionIncidenciaObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableCorporacionIncidenciaObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Folio, 
			System.Int32 ClaveCorporacion, 
			System.Byte[] HoraDespacho);

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
    public partial class CorporacionIncidenciaObjectList : ObjectList<CorporacionIncidenciaObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CorporacionIncidenciaObjectListView
        : ObjectListView<Objects.CorporacionIncidenciaObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public CorporacionIncidenciaObjectListView(Objects.CorporacionIncidenciaObjectList list): base(list)
        {
        }
    }
}


