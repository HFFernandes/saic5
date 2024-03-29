using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    /// <summary>
    /// Control de texto que implementa propiedades,metodos y funciones rutinarios durante el desarrollo
    /// </summary>
    public partial class SAITextBoxMascara : MaskedTextBox
    {
        #region Campos

        private Color _clrBackColorFoco;
        private Color _crlBackColor;
        private bool _blnEsRequerido;
        private string _strMensajeCampoRequerido;
        private bool _blnFueValido;

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el color de fondo que toma el control cuando obtiene el foco
        /// </summary>
        [Category("Appearance"), Description("Obtiene o establece el color que toma el control al tener el foco.")]
        public Color ClrBackColorFoco
        {
            get { return this._clrBackColorFoco; }
            set { this._clrBackColorFoco = value; }
        }

        /// <summary>
        /// Obtiene o establece si el control debe ser forsozamente llenado
        /// </summary>
        [Category("Behavior"), Description("Obtiene o establece si el control debe ser forsozamente llenado."),
         DefaultValue(false)]
        public bool BlnEsRequerido
        {
            get { return this._blnEsRequerido; }
            set { this._blnEsRequerido = value; }
        }

        /// <summary>
        /// Obtiene o establece el mensaje que deber� ser mostrado en caso de ser requerido.
        /// </summary>
        [Category("Behavior"),
         Description("Obtiene o establece el mensaje que deber� ser mostrado en caso de ser requerido."),
         DefaultValue("Campo requerido")]
        public string StrMensajeCampoRequerido
        {
            get { return _strMensajeCampoRequerido ?? "El campo es requerido."; }
            set { this._strMensajeCampoRequerido = value; }
        }

        /// <summary>
        /// Obtiene si el control pas� la validaci�n de campo requerido
        /// y el setter fue sellado para evitar la inyeccion de un valor distinto al real
        /// y que solo pueda ser manipulado desde este contenedor
        /// </summary>
        [Browsable(false)]
        public bool BlnFueValido
        {
            get { return this._blnFueValido; }
            protected set { this._blnFueValido = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Constructor
        /// </summary>
        public SAITextBoxMascara()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="container">Contenedor donde ser� embebido</param>
        public SAITextBoxMascara(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Se ejecuta cuando el control recibe el foco
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>
        /// Se sobreescribe la implementaci�n de la clase base para cambiar el color de fondo cuando el control obtiene el foco
        /// </remarks>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this._crlBackColor = this.BackColor;
            this.BackColor = ClrBackColorFoco;
        }

        /// <summary>
        /// Se ejecuta cuando el control pierde el foco
        /// </summary>
        /// <param name="e">Argumentos del evento</param>
        /// <remarks>
        /// Se sobreescribe la implementaci�n de la clase base para restaurar el color de fondo cuando el control pierde el foco
        /// </remarks>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.BackColor = this._crlBackColor;

            //Verificar si el campo est� marcado como requerido
            if (BlnEsRequerido && this.Text.Trim() == string.Empty)
                BlnFueValido = false;
            else
                BlnFueValido = true;
        }

        protected override void NotifyInvalidate(Rectangle invalidatedArea)
        {
            if (BlnEsRequerido)
                Validador.SetError(this, StrMensajeCampoRequerido);

            base.NotifyInvalidate(invalidatedArea);
        }

        #endregion

        #region Funciones

        #endregion
    }
}