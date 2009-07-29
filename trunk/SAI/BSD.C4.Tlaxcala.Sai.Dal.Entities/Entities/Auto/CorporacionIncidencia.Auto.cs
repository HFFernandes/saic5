
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 28/07/2009 - 08:51 p.m.
// This is a partial class file. The other one is CorporacionIncidenciaEntity.cs
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
    public partial class CorporacionIncidencia : Objects.CorporacionIncidenciaObject, IMappeableCorporacionIncidencia, IEquatable<CorporacionIncidencia>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public CorporacionIncidencia()
            :base()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public CorporacionIncidencia(
			System.Int32 Folio, System.Int32 ClaveCorporacion)
            : base()
        {

			_Folio = Folio;
			_ClaveCorporacion = ClaveCorporacion;

            
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
        public new CorporacionIncidencia OriginalValue()
        {
            return (CorporacionIncidencia)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            CorporacionIncidencia newObject;            
            

            newObject = (CorporacionIncidencia)this.MemberwiseClone();
            // Entities
            
            // Colections
            
            // OriginalValue
            CorporacionIncidencia newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (CorporacionIncidencia)this.OriginalValue().MemberwiseClone();
                // Entities
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableCorporacionIncidencia.CompleteEntity()
        {
        
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableCorporacionIncidencia.SetFKValuesForChilds(CorporacionIncidencia entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(CorporacionIncidencia other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableCorporacionIncidencia
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(CorporacionIncidencia entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class CorporacionIncidenciaList : ObjectList<CorporacionIncidencia>
    {
    }
}
namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class CorporacionIncidenciaListView
        : ObjectListView<Entities.CorporacionIncidencia>
    {
        /// <summary>
        /// 
        /// </summary>
        public CorporacionIncidenciaListView(Entities.CorporacionIncidenciaList list): base(list)
        {
        }
    }
}


