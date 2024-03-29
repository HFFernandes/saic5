
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 29/07/2009 - 02:18 p.m.
// This is a partial class file. The other one is ListaUnidadesEntity.cs
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
    public partial class ListaUnidades : Objects.ListaUnidadesObject, IMappeableListaUnidades, IEquatable<ListaUnidades>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidades()
            :base()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidades(
			System.Int32 Clave)
            : base()
        {

			_Clave = Clave;

            
            Initialized();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public ListaUnidades(
			System.Int32 Clave,
			System.String Codigo,
			System.Int32 ClaveCorporacion,
			System.Boolean Activo)
            : base()
        {

			_Clave = Clave;
			_Codigo = Codigo;
			_ClaveCorporacion = ClaveCorporacion;
			_Activo = Activo;

            
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
        public new ListaUnidades OriginalValue()
        {
            return (ListaUnidades)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            ListaUnidades newObject;            
            

            newObject = (ListaUnidades)this.MemberwiseClone();
            // Entities
            
            // Colections
            
            // OriginalValue
            ListaUnidades newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (ListaUnidades)this.OriginalValue().MemberwiseClone();
                // Entities
                
                // Colections
                            
                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;            
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableListaUnidades.CompleteEntity()
        {
        
        }
        

        /// <summary>
        /// 
        /// </summary>
        void IMappeableListaUnidades.SetFKValuesForChilds(ListaUnidades entity)
        {
                
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(ListaUnidades other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        } 

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableListaUnidades
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity();
        
        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(ListaUnidades entity);
    }

        /// <summary>
        /// 
        /// </summary>
    public partial class ListaUnidadesList : ObjectList<ListaUnidades>
    {
    }
}
namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
        /// <summary>
        /// 
        /// </summary>
    public partial class ListaUnidadesListView
        : ObjectListView<Entities.ListaUnidades>
    {
        /// <summary>
        /// 
        /// </summary>
        public ListaUnidadesListView(Entities.ListaUnidadesList list): base(list)
        {
        }
    }
}


