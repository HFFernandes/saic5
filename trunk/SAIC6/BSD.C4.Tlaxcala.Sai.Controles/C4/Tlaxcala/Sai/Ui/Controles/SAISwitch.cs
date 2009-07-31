using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;


namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{

    public delegate void dCerrar();



    public partial class SAIWinSwitch : UserControl
    {

        public event dCerrar onClose;

        private List<SAIWinSwitchItem> _elementos = new List<SAIWinSwitchItem>();
        private List<SAIWinSwitchLabel> _etiquetas = new List<SAIWinSwitchLabel>();
        private int Indice = 0;
        SAIWinSwitchLabel wstEtiqueta;
        private Form _oWner;

        public SAIWinSwitch(List<SAIWinSwitchItem> Elementos, Form Owner)
        {
            this._elementos = Elementos;
            InitializeComponent();

            this._oWner = Owner;
            this.pnlIzquierda.SuspendLayout();
            this.SuspendLayout();

            for (int i = 0; i < this._elementos.Count; i++)
            {
                wstEtiqueta = new SAIWinSwitchLabel();
                wstEtiqueta.Valor = this._elementos[i].Folio;
                wstEtiqueta.onSelected += this.wnsEtiqueta_onSelected;
                wstEtiqueta.onKeyUp += this.wstEtiqueta_OnKeyUp;
                wstEtiqueta.onMouseUp += this.wstEtiqueta_OnMouseUp;
                wstEtiqueta.Indice = i;
                wstEtiqueta.TabStop = false;
                wstEtiqueta.Height = 15;
                this._etiquetas.Add(wstEtiqueta);
                this.pnlIzquierda.Controls.Add(this._etiquetas[i]);
                this._etiquetas[i].Location = new System.Drawing.Point(5, (i*this._etiquetas[i].Height));

                
            }
            this.pnlIzquierda.ResumeLayout();
            this.ResumeLayout();

          
        }

        public SAIWinSwitch()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this._etiquetas.Count > 0)
                this._etiquetas[0].Focus();
        }


        private void wnsEtiqueta_onSelected(String strSelected)
        {
            for (int i=0; i< this._elementos.Count; i++)
            {
                if (this._elementos[i].Folio == strSelected)
                {
                    this.txtInfo.Text = this._elementos[i].Informacion;
                }
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.pnlIzquierda.Focus();
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }


        private void wstEtiqueta_OnMouseUp(MouseEventArgs e, int Indice)
        {
            try
            {
                if (this._elementos[Indice].Ventana.WindowState == FormWindowState.Minimized)
                    this._elementos[Indice].Ventana.WindowState = FormWindowState.Normal;

                this._elementos[Indice].Ventana.Visible = false;
                this._elementos[Indice].Ventana.Show(this._oWner);
                this._elementos[Indice].Ventana.Focus();

            }

            finally
            {
                this.onClose();
            }
        }


        private void wstEtiqueta_OnKeyUp(KeyEventArgs e)
        {
           if (e.KeyCode == Keys.ControlKey)
            {
                if (this.onClose != null)
                {
                    try
                    {
                        if (this._elementos[this.Indice].Ventana.WindowState == FormWindowState.Minimized)
                            this._elementos[this.Indice].Ventana.WindowState = FormWindowState.Normal;

                        this._elementos[this.Indice].Ventana.Visible = false;
                        this._elementos[this.Indice].Ventana.Show(this._oWner);
                        this._elementos[this.Indice].Ventana.Focus();
                        
                    }
                   
                    finally
                    {
                        this.onClose();
                    }
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                this.Indice++;

                if (Indice == this._elementos.Count)
                    Indice = 0;

                this._etiquetas[Indice].Focus();
            }

        }


        

    }


    public class SAIWinSwitchItem
    {

        public String Folio;
        public String Informacion;
        public Form Ventana;

        public SAIWinSwitchItem(String strFolio, String strInfo, Form frmVentana)
        {
            this.Folio = strFolio;
            this.Informacion = strInfo;
            this.Ventana = frmVentana;
        }


    }


}
