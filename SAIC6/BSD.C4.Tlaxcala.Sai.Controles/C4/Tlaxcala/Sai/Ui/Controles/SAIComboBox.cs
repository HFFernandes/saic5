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

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el color de fondo que toma el control cuando obtiene el foco
        /// </summary>
        [Category("Appearance"), Description("Obtiene o establece el color que toma el control al tener el foco.")]
        public Color ClrBackColorFoco
        {
            get
            {
                return this._clrBackColorFoco;
            }
            set
            {
                this._clrBackColorFoco = value;
            }
        }

        /// <summary>
        /// Obtiene o establece si el control debe ser forsozamente llenado
        /// </summary>
        [Category("Behavior"), Description("Obtiene o establece si el control debe ser forsozamente llenado."), DefaultValue(false)]
        public bool BlnEsRequerido
        {
            get
            {
                return this._blnEsRequerido;
            }
            set
            {
                this._blnEsRequerido = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el mensaje que deberá ser mostrado en caso de ser requerido.
        /// </summary>
        [Category("Behavior"), Description("Obtiene o establece el mensaje que deberá ser mostrado en caso de ser requerido."), DefaultValue("Campo requerido")]
        public string StrMensajeCampoRequerido
        {
            get
            {
                return _strMensajeCampoRequerido ?? "El campo es requerido.";
            }
            set
            {
                this._strMensajeCampoRequerido = value;
            }
        }

        /// <summary>
        /// Obtiene si el control pasó la validación de campo requerido
        /// y el setter fue sellado para evitar la inyeccion de un valor distinto al real
        /// y que solo pueda ser manipulado desde este contenedor
        /// </summary>
        [Browsable(false)]
        public bool BlnFueValido
        {
            get
            {
                return this._blnFueValido;
            }
            protected set
            {
                this._blnFueValido = value;
            }
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
            if (this.SelectedIndex != -1)
            {
                    this._strCadenaEscrita = string.Empty;
            }
            

            base.OnSelectedIndexChanged(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {

            this._strCadenaEscrita = this.Text;
           
            this.AutoComplete();
            base.OnKeyUp(e);
        }

        public void AutoComplete()
        {
            int intIdx = -1;
            int i = 0;
            Boolean blnSeEncontro = false;

            if (this.SelectedIndex != -1 || this.Text == string.Empty)
            {
               
                return;
            }
               

            intIdx = this.FindString(this._strCadenaEscrita);

            if ( intIdx != -1)
            {
                blnSeEncontro = true;
            }
            else
            {

                foreach (Object objElemento in this.Items)
                {

                    string strElemento = string.Empty;

                    if (objElemento.GetType() == strElemento.GetType())
                    {
                        strElemento = (String)objElemento;

                        if (strElemento.ToUpper().Contains(this._strCadenaEscrita.ToUpper()))
                        {
                            intIdx = i;
                            blnSeEncontro = true;
                            break;
                        }
                    }
                    else if (objElemento.GetType().GetProperty(this.DisplayMember) != null)
                    {
                        //buscamos en el objeto la propiedad que coincide con el displaymember del combo:

                        //int intIndicePropiedad;
                        int j = 0;
                        for (j = 0; j < objElemento.GetType().GetProperties().Length; j++)
                        {
                            if (objElemento.GetType().GetProperties()[j].Name == this.DisplayMember)
                            {
                                break;
                            }
                        }

                        strElemento = objElemento.GetType().GetProperty(this.DisplayMember).GetValue(objElemento, null).ToString();

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
            if (blnSeEncontro)
            {
                    this.SelectedIndex = intIdx;
                    this.DroppedDown = true;
                    //this.
                    //string CadenaElemento = this.Items[i].GetType().
                    //this.SelectionStart = this.Text.ToUpper().IndexOf(_strCadenaEscrita.ToUpper());
                    //this.SelectionLength = this._strCadenaEscrita.Length;
            }
        }

        //public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    string strFindStr = "";

        //    if (e.KeyChar == (char)8)
        //    {
        //        if (cb.SelectionStart <= 1)
        //        {

        //            cb.SelectedIndex = -1;
        //            return;
        //        }

        //        if (cb.SelectionLength == 0)
        //            strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
        //        else
        //            strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
        //    }
        //    else
        //    {
        //        if (cb.SelectionLength == 0)
        //            strFindStr = cb.Text + e.KeyChar;
        //        else
        //            strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
        //    }

        //    int intIdx = -1;

        //    // Search the string in the ComboBox list.

        //    intIdx = cb.FindString(strFindStr);


        //    if (intIdx != -1)
        //    {
        //        cb.SelectedText = "";
        //        cb.SelectedIndex = intIdx;
        //        cb.SelectionStart = strFindStr.Length;
        //        cb.SelectionLength = cb.Text.Length;
        //        e.Handled = true;
        //    }
        //    else
        //    {
        //        // y si ahora que no lo encontramos en el principio de una cadena
        //        // lo buscamos dentro de la cadena???
        //        int i = 0;
        //        Boolean blnSeEncontro = false;

        //        foreach (Object objElemento in cb.Items)
        //        {

        //            string strElemento = string.Empty;

        //            if (objElemento.GetType() == strElemento.GetType())
        //            {
        //                strElemento = (String)objElemento;

        //                if (strElemento.Contains(strFindStr))
        //                {
        //                    intIdx = i;
        //                    blnSeEncontro = true;
        //                    break;
        //                }
        //            }
        //            else if (objElemento.GetType().GetProperty(cb.DisplayMember) != null)
        //            {
        //                //buscamos en el objeto la propiedad que coincide con el displaymember del combo:

        //                int intIndicePropiedad;
        //                int j = 0;
        //                for (j = 0; j < objElemento.GetType().GetProperties().Length; j++)
        //                {
        //                    if (objElemento.GetType().GetProperties()[j].Name == cb.DisplayMember)
        //                    {
        //                        break;
        //                    }
        //                }

        //                strElemento = objElemento.GetType().GetProperty(cb.DisplayMember).GetValue(objElemento, null).ToString();

        //                if (strElemento.ToUpper().Contains(strFindStr.ToUpper()))
        //                {
        //                    intIdx = i;
        //                    blnSeEncontro = true;
        //                    break;
        //                }

        //            }
        //            i++;
        //        }
        //        if (blnSeEncontro)
        //        {
        //            cb.SelectedText = "";
        //            cb.SelectedIndex = intIdx;
        //            cb.SelectionStart = strFindStr.Length;
        //            cb.SelectionLength = cb.Text.Length;
        //            e.Handled = true;
        //        }
        //        else
        //        {
        //            e.Handled = true;
        //        }
        //    }

        //}
        #region Funciones
        #endregion

    }
}
