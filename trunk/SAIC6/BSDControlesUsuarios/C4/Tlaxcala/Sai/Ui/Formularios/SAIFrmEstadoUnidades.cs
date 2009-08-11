using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using XtremeReportControl;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmEstadoUnidades : SAIFrmBase
    {

        private List<Unidad> lstUnidadesRegistradas;
        private List<Unidad> lstUnidadesTemporales;
        private List<Unidad> lstUnidadesPorRemover;
        private List<ReportRecord> lstRegistrosReporte;

        public SAIFrmEstadoUnidades()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            saiReport1.btnDespacharIncidencias.Click += btnDespacharIncidencias_Click;
            saiReport1.btnBajaUnidad.Click += btnBajaUnidad_Click;
            saiReport1.btnAltaUnidad.Click += btnAltaUnidad_Click;

            lstUnidadesRegistradas = new List<Unidad>();
            lstUnidadesTemporales = new List<Unidad>();
            lstUnidadesPorRemover = new List<Unidad>();
            lstRegistrosReporte = new List<ReportRecord>();
        }

        void btnAltaUnidad_Click(object sender, EventArgs e)
        {
        }

        void btnBajaUnidad_Click(object sender, EventArgs e)
        {
        }

        void btnDespacharIncidencias_Click(object sender, EventArgs e)
        {
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
        }

        private void tmrRegistros_Tick(object sender, EventArgs e)
        {
        }

        private void SAIFrmEstadoUnidades_Load(object sender, EventArgs e)
        {
            saiReport1.btnDespacharIncidencias.Visible = false;
            saiReport1.btnLigarIncidencias.Visible = false;

            saiReport1.AgregarColumna(0, "ID", 20, false, false, false);
            saiReport1.AgregarColumna(1, "Folio", 200, true, true, true);
            saiReport1.AgregarColumna(2, "Unidad", 200, true, true, true);
            saiReport1.AgregarColumna(3, "Nombre", 200, true, true, true);
            saiReport1.AgregarColumna(4, "Status", 200, true, true, true);
            saiReport1.AgregarColumna(5, "Hora", 200, true, true, true);
            saiReport1.AgregarColumna(6, "Localizacion", 200, true, true, true);
            saiReport1.AgregarColumna(7, "Motivo", 200, true, true, true);
        }
    }
}
