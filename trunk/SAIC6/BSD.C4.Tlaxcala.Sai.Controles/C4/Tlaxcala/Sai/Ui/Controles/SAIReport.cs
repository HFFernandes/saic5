using System;
using System.Windows.Forms;
using XtremeReportControl;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    /// <summary>
    /// Control de presentación de registros que implementa funciones de filtrado y agrupamiento
    /// </summary>
    public partial class SAIReport : UserControl
    {
        //Variable estática que almacenala referencia a la instancia generada para
        //la manipulación de controles con modificadores de acceso publico
        public static SAIReport SAIInstancia;

        /// <summary>
        /// Constructor
        /// </summary>
        public SAIReport()
        {
            InitializeComponent();

            SAIInstancia = this;
        }

        /// <summary>
        /// Método para la creación de una nueva columna del control en base a los parametros
        /// </summary>
        /// <param name="intIndice">Posición que ocupará en la colección de columnas</param>
        /// <param name="strCaption">Texto que representa el encabezado de la columna</param>
        /// <param name="intTamaño">Tamaño en pixeles que ocupará la columna</param>
        /// <param name="blnCambiaTamaño">Propiedad que establece si el usuario podrá cambiar de tamaño la columna</param>
        /// <param name="blnVisible">Propiedad que establece si la columna sera o no visible</param>
        /// <param name="blnMostrarEnChooser">Propiedad que establece si la columna aparece o no en el selector de campos cuando esta oculta o agrupada</param>
        /// <param name="blnTreeColumn">Propiedad que establece si la columna será raiz de más nodos para generar un tree</param>
        /// <param name="blnPlusMinus"></param>
        /// <param name="intBloque"></param>
        public void AgregarColumna(int intIndice, string strCaption, int intTamaño, bool blnCambiaTamaño,
                                   bool blnVisible, bool blnMostrarEnChooser, bool blnTreeColumn, bool blnPlusMinus,
                                   int intBloque)
        {
            var columna = reportControl.Columns.Add(intIndice, strCaption, intTamaño, blnCambiaTamaño);
            columna.Visible = blnVisible;
            columna.ShowInFieldChooser = blnMostrarEnChooser;
            columna.TreeColumn = blnTreeColumn;

            if (!blnPlusMinus) return;
            columna.PlusMinus = true;
            columna.NextVisualBlock = intBloque;
            columna.Expanded = true;
        }

        /// <summary>
        /// Método para la creación de una nueva columna del control en base a los parametros
        /// </summary>
        /// <param name="intIndice">Posición que ocupará en la colección de columnas</param>
        /// <param name="strCaption">Texto que representa el encabezado de la columna</param>
        /// <param name="intTamaño">Tamaño en pixeles que ocupará la columna</param>
        /// <param name="blnCambiaTamaño">Propiedad que establece si el usuario podrá cambiar de tamaño la columna</param>
        /// <param name="blnVisible">Propiedad que establece si la columna sera o no visible</param>
        /// <param name="blnMostrarEnChooser">Propiedad que establece si la columna aparece o no en el selector de campos cuando esta oculta o agrupada</param>
        /// <param name="blnTreeColumn">Propiedad que establece si la columna será raiz de más nodos para generar un tree</param>
        public void AgregarColumna(int intIndice, string strCaption, int intTamaño, bool blnCambiaTamaño,
                                   bool blnVisible, bool blnMostrarEnChooser, bool blnTreeColumn)
        {
            var columna = reportControl.Columns.Add(intIndice, strCaption, intTamaño, blnCambiaTamaño);
            columna.Visible = blnVisible;
            columna.ShowInFieldChooser = blnMostrarEnChooser;
            columna.TreeColumn = blnTreeColumn;
        }

        /// <summary>
        /// Método para la creación de una nueva columna del control en base a los parametros
        /// </summary>
        /// <param name="intIndice">Posición que ocupará en la colección de columnas</param>
        /// <param name="strCaption">Texto que representa el encabezado de la columna</param>
        /// <param name="intTamaño">Tamaño en pixeles que ocupará la columna</param>
        /// <param name="blnCambiaTamaño">Propiedad que establece si el usuario podrá cambiar de tamaño la columna</param>
        /// <param name="blnVisible">Propiedad que establece si la columna sera o no visible</param>
        /// <param name="blnMostrarEnChooser">Propiedad que establece si la columna aparece o no en el selector de campos cuando esta oculta o agrupada</param>
        public void AgregarColumna(int intIndice, string strCaption, int intTamaño, bool blnCambiaTamaño,
                                   bool blnVisible, bool blnMostrarEnChooser)
        {
            var columna = reportControl.Columns.Add(intIndice, strCaption, intTamaño, blnCambiaTamaño);
            columna.Visible = blnVisible;
            columna.ShowInFieldChooser = blnMostrarEnChooser;
        }

        /// <summary>
        /// Método para la creación de una nueva columna del control en base a los parametros
        /// </summary>
        /// <param name="intIndice">Posición que ocupará en la colección de columnas</param>
        /// <param name="strCaption">Texto que representa el encabezado de la columna</param>
        /// <param name="intTamaño">Tamaño en pixeles que ocupará la columna</param>
        /// <param name="blnCambiaTamaño">Propiedad que establece si el usuario podrá cambiar de tamaño la columna</param>
        /// <param name="blnVisible">Propiedad que establece si la columna sera o no visible</param>
        public void AgregarColumna(int intIndice, string strCaption, int intTamaño, bool blnCambiaTamaño,
                                   bool blnVisible)
        {
            var columna = reportControl.Columns.Add(intIndice, strCaption, intTamaño, blnCambiaTamaño);
            columna.Visible = blnVisible;
        }

        /// <summary>
        /// Método para limpiar todos los registros del control
        /// </summary>
        public void LimpiarListado()
        {
            reportControl.Records.DeleteAll();
        }

        /// <summary>
        /// Método para la creación de un nuevo registro en base a los parametros
        /// </summary>
        /// <param name="rPadre">Registro superior al cual pertenece</param>
        /// <param name="intID">Identificador</param>
        /// <param name="strSubItems">Colección de sub-elementos para el registro</param>
        public ReportRecord AgregarRegistro(ReportRecord rPadre, int intID, params string[] strSubItems)
        {
            var registro = rPadre != null ? rPadre.Childs.Add() : reportControl.Records.Add();
            var elemento = registro.AddItem(intID);

            if (strSubItems.Length > 0)
                foreach (var s in strSubItems)
                {
                    if (s != string.Empty)
                        registro.AddItem(s);
                    else
                        registro.AddItem("(sin registro)");
                }

            registro.Tag = intID;
            reportControl.Populate();
            return registro;
        }

        /// <summary>
        /// Método para eliminar un registro especifico dentro del listado
        /// </summary>
        /// <param name="record">Registro a eliminar</param>
        public void QuitarRegistro(ReportRecord record)
        {
            reportControl.RemoveRecordEx(record);
        }

        /// <summary>
        /// Método que asigna y muestra un selector de campos para la instancia activa
        /// </summary>
        /// <param name="sender">Enviador del método</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnCampos_Click(object sender, EventArgs e)
        {
            //Generamos una instancia del selector de campos
            //e indicamos su pertenencia a la instancia del reportControl activa
            var chooser = new SAICamposReportControl();
            chooser.Show(this);

            var chooserOcx = (FieldChooser) chooser.axFieldChooser1.GetOcx();
            reportControl.FieldChooser = chooserOcx;

            //Desactivamos el control de invocación para evitar
            //generar más de una instancia del selector de campos
            btnCampos.Enabled = false;
        }

        /// <summary>
        /// Método que filtrará cualquier campo de cualquier columna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFiltroRegistros_KeyUp(object sender, KeyEventArgs e)
        {
            reportControl.FilterText = txtFiltroRegistros.Text;
            reportControl.Populate();
        }
    }
}