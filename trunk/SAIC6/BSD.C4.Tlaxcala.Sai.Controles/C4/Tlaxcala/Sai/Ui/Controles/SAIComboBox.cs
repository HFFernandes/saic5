using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    /// <summary>
    /// Combobox que implementa propiedades,metodos y funciones rutinarios durante el desarrollo
    /// </summary>
    public partial class SAIComboBox : ComboBox
    {
        #region Campos

        private Color _clrBackColorFoco;
        private Color _crlBackColor;
        private bool _blnEsRequerido;
        private string _strMensajeCampoRequerido;
        private bool _blnFueValido;
        //Guarda el valor de la cadena escrita en el combo
        private string _strCadenaEscrita = string.Empty;
        private bool _blnBusqueda = false;
        //public delegate void DelegadoCambiaMapa();
        //public event DelegadoCambiaMapa CambiaMapa;

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
        /// Obtiene o establece el mensaje que deberá ser mostrado en caso de ser requerido.
        /// </summary>
        [Category("Behavior"),
         Description("Obtiene o establece el mensaje que deberá ser mostrado en caso de ser requerido."),
         DefaultValue("Campo requerido")]
        public string StrMensajeCampoRequerido
        {
            get { return _strMensajeCampoRequerido ?? "El campo es requerido."; }
            set { this._strMensajeCampoRequerido = value; }
        }

        /// <summary>
        /// Obtiene si el control pasó la validación de campo requerido
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

        /// <summary>
        /// Constructor
        /// </summary>
        public SAIComboBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor con parametro
        /// </summary>
        /// <param name="components">Contenedor en el cual estará embebido</param>
        public SAIComboBox(IContainer components)
        {
            components.Add(this);
            InitializeComponent();
        }

        #region Eventos

        /// <summary>
        /// Se ejecuta cuando el control recibe el foco
        /// </summary>
        /// <param name="e">Argumentos del evento</param>
        /// <remarks>
        /// Se sobreescribe la implementación de la clase base para cambiar el color de fondo cuando el control obtiene el foco
        /// </remarks>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            //Parche para arreglar el problema cuando desde un formulario se actualizan datos de otro:
            if (this.BackColor == ClrBackColorFoco)
            {
                return;
            }
            this._crlBackColor = this.BackColor;
            this.BackColor = ClrBackColorFoco;
        }

        /// <summary>
        /// Se ejecuta cuando el control pierde el foco
        /// </summary>
        /// <param name="e">Argumentos del evento</param>
        /// <remarks>
        /// Se sobreescribe la implementación de la clase base para restaurar el color de fondo cuando el control pierde el foco
        /// </remarks>
        protected override void OnLostFocus(EventArgs e)
        {
            this.BackColor = this._crlBackColor;
            base.OnLostFocus(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (BlnEsRequerido && (this.SelectedIndex < 0 || this.Text.Trim() == string.Empty))
                BlnFueValido = false;
            else
                BlnFueValido = true;

            if (BlnEsRequerido)
                Validador.SetError(this, StrMensajeCampoRequerido);

            base.OnTextChanged(e);
        }

        #endregion

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            //if (this._blnBusqueda)
            //{
            //if (this.CambiaMapa!= null)
            //{
            //    this.CambiaMapa();
            //}

            //this._blnBusqueda = false;
            //return;
            //}

            if (this.SelectedIndex != -1 && !this.DroppedDown)
            {
                this._strCadenaEscrita = string.Empty;
            }

            base.OnSelectedIndexChanged(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            this._strCadenaEscrita = this.Text;

            this.AutoComplete();
            //e.Handled = true;
            base.OnKeyUp(e);
        }

        public void AutoComplete()
        {
            int intIdx = -1;
            int i = 0;
            bool blnSeEncontro = false;

            if (this.SelectedIndex != -1 || this.Text.Trim() == string.Empty)
            {
                return;
            }

            intIdx = this.FindString(this._strCadenaEscrita);

            if (intIdx != -1)
            {
                blnSeEncontro = true;
            }
            else
            {
                foreach (var objElemento in this.Items)
                {
                    string strElemento = string.Empty;

                    if (objElemento.GetType() == strElemento.GetType())
                    {
                        strElemento = (string) objElemento;

                        if (strElemento.ToUpper().Contains(this._strCadenaEscrita.ToUpper()))
                        {
                            intIdx = i;
                            blnSeEncontro = true;
                            break;
                        }
                    }
                    else if (objElemento.GetType().GetProperty(this.DisplayMember) != null)
                    {
                        strElemento =
                            objElemento.GetType().GetProperty(this.DisplayMember).GetValue(objElemento, null).ToString();

                        if (strElemento.ToUpper().Contains(this._strCadenaEscrita.ToUpper()))
                        {
                            intIdx = i;
                            blnSeEncontro = true;
                            break;
                        }
                    }
                    i++;
                }
            }

            if (!blnSeEncontro) return;

            if (!this.DroppedDown)
            {
                this.DroppedDown = true;
            }
            this._blnBusqueda = true;
            this.SelectedIndex = intIdx;
            this.Text = this._strCadenaEscrita;
            this.SelectionStart = this.Text.Length;
        }
    }
}