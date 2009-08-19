using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    /// <summary>
    /// Formulario base del cual deberá heredarse cualquier implementación de ventana y que
    /// contiene métodos y funciones para la creación de barras de comandos y proveedores de
    /// validación para los controles de captura
    /// 
    /// Los formularios derivados deberán implementar la interfaz <see cref="IEventosFormulario">IEventosFormulario</see>
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
        ///// Hace la llamada a la función de la ventana Owner para mostrar el control switch
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
        /// Detecta cuando se presionó la tecla control
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
