
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 01:50 p.m.
// This is a partial class file. The other one is RoboVehiculoAccesoriosEntity.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;



using Cooperator.Framework.Core;
using Cooperator.Framework.Core.LazyLoad;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities
{

    /// <summary>
    /// 
    /// </summary>
    public partial class RoboVehiculoAccesorios : Objects.RoboVehiculoAccesoriosObject, IMappeableRoboVehiculoAccesorios, IEquatable<RoboVehiculoAccesorios>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesorios()
            :base()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesorios(
			System.Int32 Clave)
            : base()
        {

			_Clave = Clave;

            
            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesorios(
			System.Int32 Clave,
			System.Int32 Folio,
			System.String ClaveVehiculo,
			System.String AccesoriosRobados,
			System.String SePercato,
			System.Nullable<System.DateTime> FechaPercato,
			System.String DescripcionResponsables)
            : base()
        {

			_Clave = Clave;
			_Folio = Folio;
			_ClaveVehiculo = ClaveVehiculo;
			_AccesoriosRobados = AccesoriosRobados;
			_SePercato = SePercato;
			_FechaPercato = FechaPercato;
			_DescripcionResponsables = DescripcionResponsables;

            
            Initialized();
        }
        
        #endregion

        #region "Fields"

        
        #endregion

        #region "Properties"
        
        #endregion

        /// <summary>
        /// Returns de original value of entity since was created or restored.
        /// </summary>
        public new RoboVehiculoAccesorios OriginalValue()
        {
            return (RoboVehiculoAccesorios)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            RoboVehiculoAccesorios newObject;            
            

            newObject = (RoboVehiculoAccesorios)this.MemberwiseClone();
            // Entities
            
            // Colections
            
            // OriginalValue
            RoboVehiculoAccesorios newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (RoboVehiculoAccesorios)this.OriginalValue().MemberwiseClone();
                // Entities
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableRoboVehiculoAccesorios.CompleteEntity()
        {
        
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableRoboVehiculoAccesorios.SetFKValuesForChilds(RoboVehiculoAccesorios entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(RoboVehiculoAccesorios other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableRoboVehiculoAccesorios
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(RoboVehiculoAccesorios entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class RoboVehiculoAccesoriosList : ObjectList<RoboVehiculoAccesorios>
    {
    }
}
namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class RoboVehiculoAccesoriosListView
        : ObjectListView<Entities.RoboVehiculoAccesorios>
    {
        /// <summary>
        /// 
        /// </summary>
        public RoboVehiculoAccesoriosListView(Entities.RoboVehiculoAccesoriosList list): base(list)
        {
        }
    }
}

