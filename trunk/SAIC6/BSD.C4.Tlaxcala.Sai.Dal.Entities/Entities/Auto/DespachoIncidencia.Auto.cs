
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 17/08/2009 - 04:24 p.m.
// This is a partial class file. The other one is DespachoIncidenciaEntity.cs
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
    public partial class DespachoIncidencia : Objects.DespachoIncidenciaObject, IMappeableDespachoIncidencia, IEquatable<DespachoIncidencia>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public DespachoIncidencia()
            :base()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public DespachoIncidencia(
			System.Int32 Clave)
            : base()
        {

			_Clave = Clave;

            
            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public DespachoIncidencia(
			System.Int32 Clave,
			System.Int32 ClaveCorporacion,
			System.Nullable<System.Int32> ClaveUnidad,
			System.Int32 Folio,
			System.Nullable<System.DateTime> HoraDespachada,
			System.Nullable<System.DateTime> HoraLlegada,
			System.Nullable<System.DateTime> HoraLiberada,
			System.Nullable<System.Int32> ClaveUnidadApoyo,
			System.Int32 ClaveUsuario)
            : base()
        {

			_Clave = Clave;
			_ClaveCorporacion = ClaveCorporacion;
			_ClaveUnidad = ClaveUnidad;
			_Folio = Folio;
			_HoraDespachada = HoraDespachada;
			_HoraLlegada = HoraLlegada;
			_HoraLiberada = HoraLiberada;
			_ClaveUnidadApoyo = ClaveUnidadApoyo;
			_ClaveUsuario = ClaveUsuario;

            
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
        public new DespachoIncidencia OriginalValue()
        {
            return (DespachoIncidencia)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            DespachoIncidencia newObject;            
            

            newObject = (DespachoIncidencia)this.MemberwiseClone();
            // Entities
            
            // Colections
            
            // OriginalValue
            DespachoIncidencia newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (DespachoIncidencia)this.OriginalValue().MemberwiseClone();
                // Entities
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableDespachoIncidencia.CompleteEntity()
        {
        
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableDespachoIncidencia.SetFKValuesForChilds(DespachoIncidencia entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(DespachoIncidencia other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableDespachoIncidencia
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(DespachoIncidencia entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class DespachoIncidenciaList : ObjectList<DespachoIncidencia>
    {
    }
}
namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class DespachoIncidenciaListView
        : ObjectListView<Entities.DespachoIncidencia>
    {
        /// <summary>
        /// 
        /// </summary>
        public DespachoIncidenciaListView(Entities.DespachoIncidenciaList list): base(list)
        {
        }
    }
}


