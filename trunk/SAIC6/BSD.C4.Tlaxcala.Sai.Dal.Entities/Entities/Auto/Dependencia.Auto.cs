
        
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 16/08/2009 - 11:50 a.m.
// This is a partial class file. The other one is DependenciaEntity.cs
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
    public partial class Dependencia : Objects.DependenciaObject, IMappeableDependencia, IEquatable<Dependencia>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public Dependencia()
            :base()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public Dependencia(
			System.Int32 Clave)
            : base()
        {

			_Clave = Clave;

            
            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public Dependencia(
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
        public new Dependencia OriginalValue()
        {
            return (Dependencia)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            Dependencia newObject;            
            

            newObject = (Dependencia)this.MemberwiseClone();
            // Entities
            
            // Colections
            
            // OriginalValue
            Dependencia newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (Dependencia)this.OriginalValue().MemberwiseClone();
                // Entities
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableDependencia.CompleteEntity()
        {
        
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableDependencia.SetFKValuesForChilds(Dependencia entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(Dependencia other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableDependencia
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(Dependencia entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class DependenciaList : ObjectList<Dependencia>
    {
    }
}
namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class DependenciaListView
        : ObjectListView<Entities.Dependencia>
    {
        /// <summary>
        /// 
        /// </summary>
        public DependenciaListView(Entities.DependenciaList list): base(list)
        {
        }
    }
}

