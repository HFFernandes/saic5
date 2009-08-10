﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using XtremeReportControl;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmPruebas : Form
    {
        public SAIFrmPruebas()
        {
            InitializeComponent();
        }

        private void SAIFrmPruebas_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("enter");
        }

        private void SAIFrmPruebas_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("dragdrop");

        }

        private void SAIFrmPruebas_DragLeave(object sender, EventArgs e)
        {
            Debug.WriteLine("dragleave");
        }

        private void SAIFrmPruebas_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
            var res = (MemoryStream)e.Data.GetData("SAIC4:iPendientes");
            if (res != null)
            {
                var rec =SAIReport.SAIInstancia.reportControl.CreateRecordsFromDropArray(res.ToArray());
                for (var i = 0; i < rec.Count; i++)
                {
                    Debug.WriteLine(rec[i][0].Value);
                }
            }
        }

    }
}