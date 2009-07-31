using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    /// <summary>
    /// Grid que implementa propiedades,metodos y funciones rutinarios durante el desarrollo
    /// </summary>
    public partial class SAIDataGridView : DataGridView
    {
        #region Campos

        private Color _clrBackColorFoco;

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

        #endregion

        #region Metodos
        /// <summary>
        /// Constructor
        /// </summary>
        public SAIDataGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor con parametro
        /// </summary>
        /// <param name="container">Contenedor en el cual estará embebido</param>
        public SAIDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Eventos

        /// <summary>
        /// Ocurre cuando el contenido de una celda necesita ser formateada para desplegarse
        /// </summary>
        /// <param name="e">Argumentos del evento</param>
        /// <remarks>
        /// Se sobreescribe la implementación de la clase base para cambiar el color de fondo cuando la celda obtiene el foco
        /// </remarks>
        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);
            e.CellStyle.SelectionBackColor = ClrBackColorFoco;
        }

        #endregion
    }
}
