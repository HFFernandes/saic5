using System.ComponentModel;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    /// <summary>
    /// Control que implementa funciones de validación de campos
    /// </summary>
    public partial class SAIProveedorValidacion : Component
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SAIProveedorValidacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="container">Contenedor en el cual será embebido</param>
        public SAIProveedorValidacion(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Función booleana para realizar la validación de controles marcados como requeridos
        /// </summary>
        /// <param name="parentControls">Contenedor padre donde reside el proveedor de validación</param>
        /// <returns>Valor booleano que indica si la validación fue satisfactoria</returns>
        public bool ValidarCamposRequeridos(Control parentControls)
        {
            foreach (var t in parentControls.Controls)
            {
                if (t is SAITextBox)
                    if ((t as SAITextBox).BlnEsRequerido && !(t as SAITextBox).BlnFueValido)
                        goto Error;

                if (t is SAIComboBox)
                    if ((t as SAIComboBox).BlnEsRequerido && !(t as SAIComboBox).BlnFueValido)
                        goto Error;

                if (t is SAITextBoxMascara)
                    if ((t as SAITextBoxMascara).BlnEsRequerido && !(t as SAITextBoxMascara).BlnFueValido)
                        goto Error;

                continue;
            }

            return true;
        Error:
            return false;
        }
    }
}
