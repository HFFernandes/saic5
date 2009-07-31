using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmVentana : Form
    {
        public SAIFrmVentana(List<SAIWinSwitchItem> Elementos, Form Owner)
        {
            InitializeComponent(Elementos, Owner);
            this.winSwitch1.onClose += winSwitch1_onClose;
        }
        
        private void winSwitch1_onClose()
        {
            this.Close();
        }

        protected override void OnGotFocus(EventArgs e)
        {
           this.winSwitch1.Focus();
        }
    }
}
