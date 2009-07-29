﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidenciasActivas : SAIFrmBase
    {
        public SAIFrmIncidenciasActivas()
        {
            InitializeComponent();
        }

        private void SAIFrmIncidenciasActivas_Load(object sender, EventArgs e)
        {
            saiReport1.AgregarColumna(0,"Columna Uno",150,true);
            saiReport1.AgregarColumna(1,"Columna Dos",200,false);
            saiReport1.AgregarColumna(2, "Columna Tres", 200, false);
        }
    }
}