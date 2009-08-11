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
        /// <summary>
        /// Identificador del módulo en el sistema
        /// </summary>
        //public static int intSubModulo
        //{
        //    get
        //    {
        //        return ID.PNT_AU;
        //    }
        //}

        private List<Unidad> lstUnidadesRegistradas;
        private List<Unidad> lstUnidadesTemporales;
        private List<Unidad> lstUnidadesPorRemover;
        private List<ReportRecord> lstRegistrosReporte;

        public SAIFrmEstadoUnidades()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            lstUnidadesRegistradas=new List<Unidad>();
            lstUnidadesTemporales=new List<Unidad>();
            lstUnidadesPorRemover=new List<Unidad>();
            lstRegistrosReporte=new List<ReportRecord>();
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tmrRegistros_Tick(object sender, EventArgs e)
        {

        }

        private void SAIFrmEstadoUnidades_Load(object sender, EventArgs e)
        {
            saiReport1.AgregarColumna(0, "ID", 20, false, false, false);
            saiReport1.AgregarColumna(1, "No de Teléfono", 200, true, true, true);
            saiReport1.AgregarColumna(2, "Status", 200, true, true, true);
            saiReport1.AgregarColumna(3, "Hora de Entrada", 200, true, true, true);
            saiReport1.AgregarColumna(4, "Ubicación", 200, true, true, true);
            saiReport1.AgregarColumna(5, "Tipo de Incidencia", 200, true, true, true);
            saiReport1.AgregarColumna(6, "Dividido En", 200, true, true, true);
            saiReport1.AgregarColumna(7, "Folio", 200, true, true, true);
        }
    }
}
