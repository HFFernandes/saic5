using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Interfaces;

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
        /// Constructor
        /// </summary>
        public SAIFrmBase()
        {
            InitializeComponent();
        }
    }
}
