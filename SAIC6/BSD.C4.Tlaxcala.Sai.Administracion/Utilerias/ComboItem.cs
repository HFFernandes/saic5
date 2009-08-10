using System;
using System.Collections.Generic;
using System.Text;

namespace BSD.C4.Tlaxcala.Sai.Administracion.Utilerias
{
    /// <summary>
    /// Representa un Item para un ComboBox
    /// </summary>
    class ComboItem
    {
        #region Campos
        /// <summary>
        /// Descripcion
        /// </summary>
        protected string _descripcion;
        /// <summary>
        /// Valor
        /// </summary>
        protected object _value;
        #endregion

        #region Constructores

        /// <summary>
        /// Crea un ComboItem
        /// </summary>
        /// 
        public ComboItem()
        {
            this._value = string.Empty;
            this._descripcion = string.Empty;
        }

        /// <summary>
        /// Constructor de ComboItem
        /// </summary>
        /// <param name="value">Valor para el Item</param>
        /// <param name="descripcion">Descripción del Item</param>
        public ComboItem(object value, string descripcion)
        {
            this._value = value;
            this._descripcion = descripcion;
        }
        #endregion

        /// <summary>
        /// Obtiene o asigna el valor de la Propiedad
        /// </summary>
        public object Valor
        {
            get { return this._value; }
            set { this._value = value; }
        }

        /// <summary>
        /// Obtiene o asigna el valor de la Descripción
        /// </summary>
        public string Descripcion
        {
            get { return this._descripcion; }
            set { this._descripcion = value; }
        }
    }
}
