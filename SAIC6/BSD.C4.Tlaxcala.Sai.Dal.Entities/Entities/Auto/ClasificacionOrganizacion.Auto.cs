
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 18/08/2009 - 09:55 p.m.
// This is a partial class file. The other one is ClasificacionOrganizacionEntity.cs
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
    public partial class ClasificacionOrganizacion : Objects.ClasificacionOrganizacionObject, IMappeableClasificacionOrganizacion, IEquatable<ClasificacionOrganizacion>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public ClasificacionOrganizacion()
            :base()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public ClasificacionOrganizacion(
			System.Int32 Clave)
            : base()
        {

			_Clave = Clave;

            
            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public ClasificacionOrganizacion(
			System.Int32 Clave,
			System.String Descripcion)
            : base()
        {

			_Clave = Clave;
			_Descripcion = Descripcion;

            
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
        public new ClasificacionOrganizacion OriginalValue()
        {
            return (ClasificacionOrganizacion)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            ClasificacionOrganizacion newObject;            
            

            newObject = (ClasificacionOrganizacion)this.MemberwiseClone();
            // Entities
            
            // Colections
            
            // OriginalValue
            ClasificacionOrganizacion newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (ClasificacionOrganizacion)this.OriginalValue().MemberwiseClone();
                // Entities
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableClasificacionOrganizacion.CompleteEntity()
        {
        
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableClasificacionOrganizacion.SetFKValuesForChilds(ClasificacionOrganizacion entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(ClasificacionOrganizacion other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableClasificacionOrganizacion
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(ClasificacionOrganizacion entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class ClasificacionOrganizacionList : ObjectList<ClasificacionOrganizacion>
    {
    }
}
namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class ClasificacionOrganizacionListView
        : ObjectListView<Entities.ClasificacionOrganizacion>
    {
        /// <summary>
        /// 
        /// </summary>
        public ClasificacionOrganizacionListView(Entities.ClasificacionOrganizacionList list): base(list)
        {
        }
    }
}

