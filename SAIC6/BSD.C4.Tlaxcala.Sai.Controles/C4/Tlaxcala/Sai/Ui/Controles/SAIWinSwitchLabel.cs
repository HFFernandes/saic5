using System;
using System.Drawing;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{

    public delegate void wnsSelected(String strFolio);
    public delegate void wnsOnKeyUp(KeyEventArgs e);
    public delegate void wnsOnMouseUp(MouseEventArgs e, int Indice);

    public partial class SAIWinSwitchLabel : UserControl
    {

        /// <summary>
        /// Apunta hacia el índice de la etiqueta que le corresponde según la lista de etiquetas que se está manejando.
        /// </summary>
        public int Indice;

        private bool _tabEnter = false;
        /// <summary>
        /// Evento que notifica que la etiqueta tiene el foco para el envío de la información al panel derecho del control switch
        /// </summary>
        public event wnsSelected onSelected;
        /// <summary>
        /// Evento que notifica cuando el usuario dejó de presonar una tecla
        /// </summary>
        public event wnsOnKeyUp onKeyUp;
        /// <summary>
        /// Constructor, inicializa el tamaño y colores de la etiqueta
        /// </summary>
        public event wnsOnMouseUp onMouseUp;

        public SAIWinSwitchLabel()
        {
            InitializeComponent();
            this.label1.Width = this.Width - 1;
            this.label1.Height = this.Height - 1;

            this.label1.BackColor = Color.FromArgb(255, 255, 192);
            this.label1.ForeColor = Color.Black;

            this.label1.MouseEnter += new EventHandler(label1_MouseEnter);
            this.label1.MouseLeave += new EventHandler(label1_MouseLeave);
            this.label1.MouseUp += new MouseEventHandler(label1_MouseUp);
        }
        /// <summary>
        /// Obtiene el valor que se muestra en la etiqueta
        /// </summary>
        public String Valor
        {
            set
            {
                this.label1.Text = value;
            }
        }
        /// <summary>
        /// Implementa el cambio de colores cuando la etiqueta obtiene el foco
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(EventArgs e)
        {
            this._tabEnter = true;
            this.label1.BackColor = Color.Blue;
            this.label1.ForeColor = Color.White;
            if (this.onSelected != null)
            {
                onSelected(this.label1.Text);
            }
        }
        /// <summary>
        /// Implementa el cambio de colores cuando la etiqueta pierde el foco
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            this.label1.BackColor = Color.FromArgb(255, 255, 192);
            this.label1.ForeColor = Color.Black;
            this._tabEnter = false;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //base.OnKeyUp(e);
            this._tabEnter = false;
            if (this.onKeyUp != null)
                this.onKeyUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            //base.OnMouseEnter(e);
            this.label1.BackColor = Color.Blue;
            this.label1.ForeColor = Color.White;

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this._tabEnter)
                return;

            this.Cursor = Cursors.Default;
            this.label1.BackColor = Color.FromArgb(255, 255, 192);
            this.label1.ForeColor = Color.Black;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            //base.OnMouseClick(e);
            this._tabEnter = false;
            if (this.onMouseUp != null)
                this.onMouseUp(e, this.Indice);

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.BackColor = Color.Blue;
            this.label1.ForeColor = Color.White;

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (this._tabEnter)
                return;

            this.Cursor = Cursors.Default;
            this.label1.BackColor = Color.FromArgb(255, 255, 192);
            this.label1.ForeColor = Color.Black;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            this._tabEnter = false;
            if (this.onMouseUp != null)
                this.onMouseUp(e, this.Indice);
        }



    }
}
