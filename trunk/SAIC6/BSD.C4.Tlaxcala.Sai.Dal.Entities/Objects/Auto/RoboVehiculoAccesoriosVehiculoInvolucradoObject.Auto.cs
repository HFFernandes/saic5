
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 06:03 p.m.
// This is a partial class file. The other one is RoboVehiculoAccesoriosVehiculoInvolucradoObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RoboVehiculoAccesoriosVehiculoInvolucradoObject : BaseObject, IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject, IUniqueIdentifiable, IEquatable<RoboVehiculoAccesoriosVehiculoInvolucradoObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObject(): base()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObject(
			System.Int32 ClaveVehiculo, System.Int32 ClaveRoboAccesorios): base()
        {

			_ClaveVehiculo = ClaveVehiculo;
			_ClaveRoboAccesorios = ClaveRoboAccesorios;

            Initialized();
        }

        

        #endregion

        #region "Events"
        
        
        #endregion

        #region "Fields"

            /// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveVehiculo;
/// <summary>
/// 
/// </summary>
protected System.Int32 _ClaveRoboAccesorios;

        #endregion

        #region "Properties"
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 ClaveVehiculo
        {
            get
            {
                return _ClaveVehiculo;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveVehiculo = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.Int32 ClaveRoboAccesorios
        {
            get
            {
                return _ClaveRoboAccesorios;
            }
            
            set
            {
                base.PropertyModified();
                _ClaveRoboAccesorios = value;
                
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
            RoboVehiculoAccesoriosVehiculoInvolucradoObject newObject;
            RoboVehiculoAccesoriosVehiculoInvolucradoObject newOriginalValue;

            newObject = (RoboVehiculoAccesoriosVehiculoInvolucradoObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (RoboVehiculoAccesoriosVehiculoInvolucradoObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new RoboVehiculoAccesoriosVehiculoInvolucradoObject OriginalValue()
        {
            return (RoboVehiculoAccesoriosVehiculoInvolucradoObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject.HydrateFields(
			System.Int32 ClaveVehiculo,
			System.Int32 ClaveRoboAccesorios)
        {
        _ClaveVehiculo = ClaveVehiculo;
_ClaveRoboAccesorios = ClaveRoboAccesorios;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[2];
            _myArray[0] = _ClaveVehiculo;
_myArray[1] = _ClaveRoboAccesorios;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[4];
            _myArray[0] = _ClaveVehiculo;
_myArray[1] = _ClaveRoboAccesorios;
_myArray[2] = this.OriginalValue()._ClaveVehiculo;
_myArray[3] = this.OriginalValue()._ClaveRoboAccesorios;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[2];
            _myArray[0] = _ClaveVehiculo;
_myArray[1] = _ClaveRoboAccesorios;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            
        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            RoboVehiculoAccesoriosVehiculoInvolucradoObject o = null;
            if (ObjectStateHelper.IsModified(this))
                o = this.OriginalValue();
            else
                o = this;

            return new object[]
            {o.ClaveVehiculo, o.ClaveRoboAccesorios};
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Equals(RoboVehiculoAccesoriosVehiculoInvolucradoObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableRoboVehiculoAccesoriosVehiculoInvolucradoObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 ClaveVehiculo, 
			System.Int32 ClaveRoboAccesorios);

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
    public partial class RoboVehiculoAccesoriosVehiculoInvolucradoObjectList : ObjectList<RoboVehiculoAccesoriosVehiculoInvolucradoObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RoboVehiculoAccesoriosVehiculoInvolucradoObjectListView
        : ObjectListView<Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosVehiculoInvolucradoObjectListView(Objects.RoboVehiculoAccesoriosVehiculoInvolucradoObjectList list): base(list)
        {
        }
    }
}


