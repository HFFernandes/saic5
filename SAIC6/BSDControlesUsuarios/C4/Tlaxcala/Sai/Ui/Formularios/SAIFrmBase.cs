using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    /// <summary>
    /// Formulario base del cual deber� heredarse cualquier implementaci�n de ventana y que
    /// contiene m�todos y funciones para la creaci�n de barras de comandos y proveedores de
    /// validaci�n para los controles de captura
    /// 
    /// Los formularios derivados deber�n implementar la interfaz <see cref="IEventosFormulario">IEventosFormulario</see>
    /// </summary>
    public partial class SAIFrmBase : Form
    {
        /// <summary>
        /// Lleva el estado del caso de la tecla control presionada.
        /// </summary>
        private bool bCtrPresionado = false;


        /// <summary>
        /// Constructor
        /// </summary>
        public SAIFrmBase()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// Hace la llamada a la funci�n de la ventana Owner para mostrar el control switch
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void OnKeyUp(KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Tab && this.bCtrPresionado)
        //    {
        //        if (this.Owner != null)
        //        {
        //            SAIFrmComandos frmPrincipal = (SAIFrmComandos)this.Owner;
        //            frmPrincipal.MuestraSwitch();
        //        }

        //    }
        //    this.bCtrPresionado = false;
        //}

        /// <summary>
        /// Detecta cuando se presion� la tecla control
        /// </summary>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.ControlKey | Keys.Control))
            {
                this.bCtrPresionado = true;
            }
            return false;
        }
    }
}