using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    /// <summary>
    /// Formulario que mostrará aquellos campos adicionales que pueden ser insertados en un control <see cref="SAIReport">SAIReport</see>
    /// </summary>
    public partial class SAICamposReportControl : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SAICamposReportControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que notificará a la instancia <see cref="SAIReport">SAIReport</see> a la cual pertenece
        /// que ha sido cerrado para habilitar nuevamente el control que lo inicio
        /// </summary>
        /// <param name="sender">Enviador del evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void SAICamposReportControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            SAIReport.SAIInstancia.btnCampos.Enabled = true;
        }
    }
}