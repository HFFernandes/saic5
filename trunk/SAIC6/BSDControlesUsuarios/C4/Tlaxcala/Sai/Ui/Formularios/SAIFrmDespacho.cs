using System;
using System.Windows.Forms;
using XtremeReportControl;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmDespacho : Form
    {
        private ReportRecord Registro;
        private ReportColumn Columna;
        private ReportRecordItem Item;
        private ReportRecord RegistroActual;

        public SAIFrmDespacho()
        {
            InitializeComponent();

            axComentarios.PaintManager.HeaderRowsDividerStyle =
                XTPReportFixedRowsDividerStyle.xtpReportFixedRowsDividerOutlook;
        }

        private void SAIFrmDespacho_Load(object sender, EventArgs e)
        {
            Columna = axComentarios.Columns.Add(0, "Comentarios", 250, true);
            Columna = axComentarios.Columns.Add(1, "Despachador", 100, true);
            Columna.EditOptions.AllowEdit = false;
            Columna.EditOptions.ConstraintEdit = true;

            Registro = axComentarios.HeaderRecords.Add();
            Item = Registro.AddItem(string.Empty);
            Item = Registro.AddItem(string.Empty);

            LimpiarEncabezado(true);
            axComentarios.Populate();
        }

        private void LimpiarEncabezado(bool blnLimpiar)
        {
            RegistroActual = axComentarios.HeaderRecords[0];
            RegistroActual[0].Value = blnLimpiar ? ID.STR_NUEVOCOMENTARIO : string.Empty;
            RegistroActual[1].Value = Aplicacion.UsuarioPersistencia.strNombreUsuario;
        }

        private void axComentarios_KeyUpEvent(object sender, AxXtremeReportControl._DReportControlEvents_KeyUpEvent e)
        {
            if (axComentarios.Navigator.CurrentFocusInHeadersRows && (e.keyCode == 13 && e.shift == 0))
                AgregarComentario();
        }

        private void AgregarComentario()
        {
            RegistroActual = axComentarios.HeaderRecords[0];

            var strComentario = Convert.ToString(RegistroActual[0].Value);
            if (strComentario != ID.STR_NUEVOCOMENTARIO)
            {
                //validar campos

                //agregar campos
                AgregarRegistro(strComentario,"despachador");

                LimpiarEncabezado(true);
                axComentarios.Populate();
                axComentarios.Navigator.CurrentFocusInHeadersRows = true;
            }
        }

        private void AgregarRegistro(string strComentario, string strDespachador)
        {
            if (strComentario.Trim() != string.Empty)
            {
                RegistroActual = axComentarios.Records.Insert(0);
                Item = RegistroActual.AddItem(strComentario);
                Item = RegistroActual.AddItem(strDespachador);
            }
        }

        private void axComentarios_MouseDownEvent(object sender, AxXtremeReportControl._DReportControlEvents_MouseDownEvent e)
        {
            int l, t, r, b;
            l = t = r = b = 0;

            if (axComentarios.HeaderRows.Count > 0)
            {
                axComentarios.HeaderRows[0].GetRect(ref l, ref t, ref r, ref b);
                if (e.y > b)
                    AgregarComentario();
                else
                    if (Convert.ToString(axComentarios.HeaderRecords[0][0].Value) == ID.STR_NUEVOCOMENTARIO)
                        LimpiarEncabezado(false);
            }
        }
    }
}
