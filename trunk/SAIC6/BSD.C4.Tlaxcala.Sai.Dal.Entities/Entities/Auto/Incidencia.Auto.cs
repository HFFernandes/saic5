

//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 01:50 p.m.
// This is a partial class file. The other one is IncidenciaEntity.cs
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
    public partial class Incidencia : Objects.IncidenciaObject, IMappeableIncidencia, IEquatable<Incidencia>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public Incidencia()
            : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public Incidencia(
            System.Int32 Folio)
            : base()
        {

            _Folio = Folio;


            Initialized();
        }



        /// <summary>
        /// 
        /// </summary>
        public Incidencia(
            System.Int32 Folio,
            System.Nullable<System.Int32> FolioPadre,
            System.String Descripcion,
            System.String Direccion,
            System.String Referencias,
            System.DateTime HoraRecepcion,
            System.Nullable<System.Int32> ClaveEstado,
            System.Nullable<System.Int32> ClaveMunicipio,
            System.Nullable<System.Int32> ClaveLocalidad,
            System.Nullable<System.Int32> ClaveColonia,
            System.Nullable<System.Int32> ClaveCodigoPostal,
            System.String Telefono,
            System.Nullable<System.Int32> ClaveDenunciante,
            System.Int32 ClaveEstatus,
            System.Int32 ClaveUsuario,
            System.Boolean Activo,
            System.Nullable<System.Int32> ClaveTipo,
            System.Nullable<System.Int32> Prioridad,
            System.Nullable<System.DateTime> FechaEnvio,
            System.Nullable<System.DateTime> FechaEnvioDependencia,
            System.Nullable<System.DateTime> FechaNotificacion,
            System.String NumeroOficio,
            System.Nullable<System.DateTime> FechaSuceso)
            : base()
        {

            _Folio = Folio;
            _FolioPadre = FolioPadre;
            _Descripcion = Descripcion;
            _Direccion = Direccion;
            _Referencias = Referencias;
            _HoraRecepcion = HoraRecepcion;
            _ClaveEstado = ClaveEstado;
            _ClaveMunicipio = ClaveMunicipio;
            _ClaveLocalidad = ClaveLocalidad;
            _ClaveColonia = ClaveColonia;
            _ClaveCodigoPostal = ClaveCodigoPostal;
            _Telefono = Telefono;
            _ClaveDenunciante = ClaveDenunciante;
            _ClaveEstatus = ClaveEstatus;
            _ClaveUsuario = ClaveUsuario;
            _Activo = Activo;
            _ClaveTipo = ClaveTipo;
            _Prioridad = Prioridad;
            _FechaEnvio = FechaEnvio;
            _FechaEnvioDependencia = FechaEnvioDependencia;
            _FechaNotificacion = FechaNotificacion;
            _NumeroOficio = NumeroOficio;
            _FechaSuceso = FechaSuceso;


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
        public new Incidencia OriginalValue()
        {
            return (Incidencia)base.OriginalValue();
        }

        /// <summary>
        /// 
        /// </summary>
        object ICloneable.Clone()
        {
            Incidencia newObject;


            newObject = (Incidencia)this.MemberwiseClone();
            // Entities

            // Colections

            // OriginalValue
            Incidencia newOriginalValue;
            if (base._OriginalValue != null)
            {
                newOriginalValue = (Incidencia)this.OriginalValue().MemberwiseClone();
                // Entities

                // Colections

                newObject._OriginalValue = newOriginalValue;

            }
            return newObject;
        }



        /// <summary>
        /// 
        /// </summary>
        void IMappeableIncidencia.CompleteEntity()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeableIncidencia.SetFKValuesForChilds(Incidencia entity)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(Incidencia other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeableIncidencia
    {
        /// <summary>
        /// 
        /// </summary>
        void CompleteEntity();

        /// <summary>
        /// 
        /// </summary>
        void SetFKValuesForChilds(Incidencia entity);
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class IncidenciaList : ObjectList<Incidencia>
    {
    }
}
namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class IncidenciaListView
        : ObjectListView<Entities.Incidencia>
    {
        /// <summary>
        /// 
        /// </summary>
        public IncidenciaListView(Entities.IncidenciaList list)
            : base(list)
        {
        }
    }
}

