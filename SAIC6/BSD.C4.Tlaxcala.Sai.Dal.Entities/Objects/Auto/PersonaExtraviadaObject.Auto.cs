
//------------------------------------------------------------------------------
// This file was generated by Cooperator Modeler, version 1.3.2.0
// Created: 04/08/2009 - 01:50 p.m.
// This is a partial class file. The other one is PersonaExtraviadaObject.cs
// You should not modifiy this file, please edit the other partial class file.
//------------------------------------------------------------------------------

using Cooperator.Framework.Core;
using System;

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PersonaExtraviadaObject : BaseObject, IMappeablePersonaExtraviadaObject, IUniqueIdentifiable, IEquatable<PersonaExtraviadaObject>, ICloneable
    {

        #region "Ctor"

        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviadaObject(): base()
        {

			_Clave =  ValuesGenerator.GetInt32;

        }

        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviadaObject(
			System.Int32 Clave): base()
        {

			_Clave = Clave;

            Initialized();
        }

        
        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviadaObject(
			System.Int32 Clave,
			System.Int32 Folio,
			System.String Parentesco,
			System.DateTime FechaExtravio,
			System.String Destino,
			System.String Nombre,
			System.Nullable<System.Int32> Edad,
			System.String Sexo,
			System.Nullable<System.Double> Estatura,
			System.String Tez,
			System.String TipoCabello,
			System.String ColorCabello,
			System.String LargoCabello,
			System.String Frente,
			System.String Cejas,
			System.String OjosColor,
			System.String OjosForma,
			System.String NarizForma,
			System.String BocaTamaño,
			System.String Labios,
			System.String Vestimenta,
			System.String Caracteristicas): base()
        {

			_Clave = Clave;
			_Folio = Folio;
			_Parentesco = Parentesco;
			_FechaExtravio = FechaExtravio;
			_Destino = Destino;
			_Nombre = Nombre;
			_Edad = Edad;
			_Sexo = Sexo;
			_Estatura = Estatura;
			_Tez = Tez;
			_TipoCabello = TipoCabello;
			_ColorCabello = ColorCabello;
			_LargoCabello = LargoCabello;
			_Frente = Frente;
			_Cejas = Cejas;
			_OjosColor = OjosColor;
			_OjosForma = OjosForma;
			_NarizForma = NarizForma;
			_BocaTamaño = BocaTamaño;
			_Labios = Labios;
			_Vestimenta = Vestimenta;
			_Caracteristicas = Caracteristicas;

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
protected System.Int32 _Folio;
/// <summary>
/// 
/// </summary>
protected System.String _Parentesco;
/// <summary>
/// 
/// </summary>
protected System.DateTime _FechaExtravio;
/// <summary>
/// 
/// </summary>
protected System.String _Destino;
/// <summary>
/// 
/// </summary>
protected System.String _Nombre;
/// <summary>
///
/// </summary>
protected System.Nullable<System.Int32> _Edad;
/// <summary>
/// 
/// </summary>
protected System.String _Sexo;
/// <summary>
///
/// </summary>
protected System.Nullable<System.Double> _Estatura;
/// <summary>
/// 
/// </summary>
protected System.String _Tez;
/// <summary>
/// 
/// </summary>
protected System.String _TipoCabello;
/// <summary>
/// 
/// </summary>
protected System.String _ColorCabello;
/// <summary>
/// 
/// </summary>
protected System.String _LargoCabello;
/// <summary>
/// 
/// </summary>
protected System.String _Frente;
/// <summary>
/// 
/// </summary>
protected System.String _Cejas;
/// <summary>
/// 
/// </summary>
protected System.String _OjosColor;
/// <summary>
/// 
/// </summary>
protected System.String _OjosForma;
/// <summary>
/// 
/// </summary>
protected System.String _NarizForma;
/// <summary>
/// 
/// </summary>
protected System.String _BocaTamaño;
/// <summary>
/// 
/// </summary>
protected System.String _Labios;
/// <summary>
/// 
/// </summary>
protected System.String _Vestimenta;
/// <summary>
/// 
/// </summary>
protected System.String _Caracteristicas;

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
            
        }
        
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
        public virtual System.String Parentesco
        {
            get
            {
                return _Parentesco;
            }
            
            set
            {
                base.PropertyModified();
                _Parentesco = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.DateTime FechaExtravio
        {
            get
            {
                return _FechaExtravio;
            }
            
            set
            {
                base.PropertyModified();
                _FechaExtravio = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Destino
        {
            get
            {
                return _Destino;
            }
            
            set
            {
                base.PropertyModified();
                _Destino = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Nombre
        {
            get
            {
                return _Nombre;
            }
            
            set
            {
                base.PropertyModified();
                _Nombre = value;
                
            }
            
        }
        
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Int32> Edad
        {
            get
            {
                return _Edad;
            }
            
            set
            {
                base.PropertyModified();
                _Edad = value;                
                
            }
            
        }
                
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Sexo
        {
            get
            {
                return _Sexo;
            }
            
            set
            {
                base.PropertyModified();
                _Sexo = value;
                
            }
            
        }
        
        /// <summary>
        /// Nullable property
        /// </summary>
        public virtual System.Nullable<System.Double> Estatura
        {
            get
            {
                return _Estatura;
            }
            
            set
            {
                base.PropertyModified();
                _Estatura = value;                
                
            }
            
        }
                
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Tez
        {
            get
            {
                return _Tez;
            }
            
            set
            {
                base.PropertyModified();
                _Tez = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String TipoCabello
        {
            get
            {
                return _TipoCabello;
            }
            
            set
            {
                base.PropertyModified();
                _TipoCabello = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String ColorCabello
        {
            get
            {
                return _ColorCabello;
            }
            
            set
            {
                base.PropertyModified();
                _ColorCabello = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String LargoCabello
        {
            get
            {
                return _LargoCabello;
            }
            
            set
            {
                base.PropertyModified();
                _LargoCabello = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Frente
        {
            get
            {
                return _Frente;
            }
            
            set
            {
                base.PropertyModified();
                _Frente = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Cejas
        {
            get
            {
                return _Cejas;
            }
            
            set
            {
                base.PropertyModified();
                _Cejas = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String OjosColor
        {
            get
            {
                return _OjosColor;
            }
            
            set
            {
                base.PropertyModified();
                _OjosColor = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String OjosForma
        {
            get
            {
                return _OjosForma;
            }
            
            set
            {
                base.PropertyModified();
                _OjosForma = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String NarizForma
        {
            get
            {
                return _NarizForma;
            }
            
            set
            {
                base.PropertyModified();
                _NarizForma = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String BocaTamaño
        {
            get
            {
                return _BocaTamaño;
            }
            
            set
            {
                base.PropertyModified();
                _BocaTamaño = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Labios
        {
            get
            {
                return _Labios;
            }
            
            set
            {
                base.PropertyModified();
                _Labios = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Vestimenta
        {
            get
            {
                return _Vestimenta;
            }
            
            set
            {
                base.PropertyModified();
                _Vestimenta = value;
                
            }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual System.String Caracteristicas
        {
            get
            {
                return _Caracteristicas;
            }
            
            set
            {
                base.PropertyModified();
                _Caracteristicas = value;
                
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
            PersonaExtraviadaObject newObject;
            PersonaExtraviadaObject newOriginalValue;

            newObject = (PersonaExtraviadaObject) this.MemberwiseClone();
            if (base._OriginalValue != null)
            {
                newOriginalValue = (PersonaExtraviadaObject)this.OriginalValue().MemberwiseClone();
                newObject._OriginalValue = newOriginalValue;
            }
            return newObject;
        }


        /// <summary>
        /// Returns de original value of object since was created or restored.
        /// </summary>
        public new PersonaExtraviadaObject OriginalValue()
        {
            return (PersonaExtraviadaObject)base.OriginalValue();
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeablePersonaExtraviadaObject.HydrateFields(
			System.Int32 Clave,
			System.Int32 Folio,
			System.String Parentesco,
			System.DateTime FechaExtravio,
			System.String Destino,
			System.String Nombre,
			System.Nullable<System.Int32> Edad,
			System.String Sexo,
			System.Nullable<System.Double> Estatura,
			System.String Tez,
			System.String TipoCabello,
			System.String ColorCabello,
			System.String LargoCabello,
			System.String Frente,
			System.String Cejas,
			System.String OjosColor,
			System.String OjosForma,
			System.String NarizForma,
			System.String BocaTamaño,
			System.String Labios,
			System.String Vestimenta,
			System.String Caracteristicas)
        {
        _Clave = Clave;
_Folio = Folio;
_Parentesco = Parentesco;
_FechaExtravio = FechaExtravio;
_Destino = Destino;
_Nombre = Nombre;
_Edad = Edad;
_Sexo = Sexo;
_Estatura = Estatura;
_Tez = Tez;
_TipoCabello = TipoCabello;
_ColorCabello = ColorCabello;
_LargoCabello = LargoCabello;
_Frente = Frente;
_Cejas = Cejas;
_OjosColor = OjosColor;
_OjosForma = OjosForma;
_NarizForma = NarizForma;
_BocaTamaño = BocaTamaño;
_Labios = Labios;
_Vestimenta = Vestimenta;
_Caracteristicas = Caracteristicas;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePersonaExtraviadaObject.GetFieldsForInsert()
        {
            object[] _myArray = new object[22];
            _myArray[0] = _Clave;
_myArray[1] = _Folio;
if (!System.String.IsNullOrEmpty(_Parentesco)) _myArray[2] = _Parentesco;
_myArray[3] = _FechaExtravio;
if (!System.String.IsNullOrEmpty(_Destino)) _myArray[4] = _Destino;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[5] = _Nombre;
if (_Edad.HasValue) _myArray[6] = _Edad.Value;
if (!System.String.IsNullOrEmpty(_Sexo)) _myArray[7] = _Sexo;
if (_Estatura.HasValue) _myArray[8] = _Estatura.Value;
if (!System.String.IsNullOrEmpty(_Tez)) _myArray[9] = _Tez;
if (!System.String.IsNullOrEmpty(_TipoCabello)) _myArray[10] = _TipoCabello;
if (!System.String.IsNullOrEmpty(_ColorCabello)) _myArray[11] = _ColorCabello;
if (!System.String.IsNullOrEmpty(_LargoCabello)) _myArray[12] = _LargoCabello;
if (!System.String.IsNullOrEmpty(_Frente)) _myArray[13] = _Frente;
if (!System.String.IsNullOrEmpty(_Cejas)) _myArray[14] = _Cejas;
if (!System.String.IsNullOrEmpty(_OjosColor)) _myArray[15] = _OjosColor;
if (!System.String.IsNullOrEmpty(_OjosForma)) _myArray[16] = _OjosForma;
if (!System.String.IsNullOrEmpty(_NarizForma)) _myArray[17] = _NarizForma;
if (!System.String.IsNullOrEmpty(_BocaTamaño)) _myArray[18] = _BocaTamaño;
if (!System.String.IsNullOrEmpty(_Labios)) _myArray[19] = _Labios;
if (!System.String.IsNullOrEmpty(_Vestimenta)) _myArray[20] = _Vestimenta;
if (!System.String.IsNullOrEmpty(_Caracteristicas)) _myArray[21] = _Caracteristicas;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePersonaExtraviadaObject.GetFieldsForUpdate()
        {
            
            object[] _myArray = new object[22];
            _myArray[0] = _Clave;
_myArray[1] = _Folio;
if (!System.String.IsNullOrEmpty(_Parentesco)) _myArray[2] = _Parentesco;
_myArray[3] = _FechaExtravio;
if (!System.String.IsNullOrEmpty(_Destino)) _myArray[4] = _Destino;
if (!System.String.IsNullOrEmpty(_Nombre)) _myArray[5] = _Nombre;
if (_Edad.HasValue) _myArray[6] = _Edad.Value;
if (!System.String.IsNullOrEmpty(_Sexo)) _myArray[7] = _Sexo;
if (_Estatura.HasValue) _myArray[8] = _Estatura.Value;
if (!System.String.IsNullOrEmpty(_Tez)) _myArray[9] = _Tez;
if (!System.String.IsNullOrEmpty(_TipoCabello)) _myArray[10] = _TipoCabello;
if (!System.String.IsNullOrEmpty(_ColorCabello)) _myArray[11] = _ColorCabello;
if (!System.String.IsNullOrEmpty(_LargoCabello)) _myArray[12] = _LargoCabello;
if (!System.String.IsNullOrEmpty(_Frente)) _myArray[13] = _Frente;
if (!System.String.IsNullOrEmpty(_Cejas)) _myArray[14] = _Cejas;
if (!System.String.IsNullOrEmpty(_OjosColor)) _myArray[15] = _OjosColor;
if (!System.String.IsNullOrEmpty(_OjosForma)) _myArray[16] = _OjosForma;
if (!System.String.IsNullOrEmpty(_NarizForma)) _myArray[17] = _NarizForma;
if (!System.String.IsNullOrEmpty(_BocaTamaño)) _myArray[18] = _BocaTamaño;
if (!System.String.IsNullOrEmpty(_Labios)) _myArray[19] = _Labios;
if (!System.String.IsNullOrEmpty(_Vestimenta)) _myArray[20] = _Vestimenta;
if (!System.String.IsNullOrEmpty(_Caracteristicas)) _myArray[21] = _Caracteristicas;

            return _myArray;
        }

        /// <summary>
        /// 
        /// </summary>
        object[] IMappeablePersonaExtraviadaObject.GetFieldsForDelete()
        {
            
            object[] _myArray = new object[1];
            _myArray[0] = _Clave;

            return _myArray;
        }


        /// <summary>
        /// 
        /// </summary>
        void IMappeablePersonaExtraviadaObject.UpdateObjectFromOutputParams(object[] parameters){
            // Update properties from Output parameters
            _Clave = (System.Int32) parameters[0];

        }


        /// <summary>
        /// 
        /// </summary>
        object[] IUniqueIdentifiable.Identifier()
        {
            PersonaExtraviadaObject o = null;
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
        public bool Equals(PersonaExtraviadaObject other)
        {
            return UniqueIdentifierHelper.IsSameObject((IUniqueIdentifiable)this, (IUniqueIdentifiable)other);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMappeablePersonaExtraviadaObject
    {
        /// <summary>
        /// 
        /// </summary>
        void HydrateFields(System.Int32 Clave, 
			System.Int32 Folio, 
			System.String Parentesco, 
			System.DateTime FechaExtravio, 
			System.String Destino, 
			System.String Nombre, 
			System.Nullable<System.Int32> Edad, 
			System.String Sexo, 
			System.Nullable<System.Double> Estatura, 
			System.String Tez, 
			System.String TipoCabello, 
			System.String ColorCabello, 
			System.String LargoCabello, 
			System.String Frente, 
			System.String Cejas, 
			System.String OjosColor, 
			System.String OjosForma, 
			System.String NarizForma, 
			System.String BocaTamaño, 
			System.String Labios, 
			System.String Vestimenta, 
			System.String Caracteristicas);

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
    public partial class PersonaExtraviadaObjectList : ObjectList<PersonaExtraviadaObject>
    {
    }
}

namespace BSD.C4.Tlaxcala.Sai.Dal.Rules.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PersonaExtraviadaObjectListView
        : ObjectListView<Objects.PersonaExtraviadaObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public PersonaExtraviadaObjectListView(Objects.PersonaExtraviadaObjectList list): base(list)
        {
        }
    }
}


