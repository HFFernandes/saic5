using System.Timers;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    ///<summary>
    ///</summary>
    public partial class SAISpinnerBox : PictureBox
    {
        #region Campos

        protected bool esActivo;
        protected int posicionX;
        protected System.Timers.Timer timer;
        protected int velocidad;

        #endregion

        #region Propiedades

        ///<summary>
        ///</summary>
        public double Intervalo
        {
            get { return this.timer.Interval; }
            set { this.timer.Interval = (int) value; }
        }

        ///<summary>
        ///</summary>
        public int Velocidad
        {
            get { return this.velocidad; }
            set { this.velocidad = value; }
        }

        #endregion

        ///<summary>
        ///</summary>
        public SAISpinnerBox()
        {
            InitializeComponent();

            this.esActivo = false;
            this.timer = new System.Timers.Timer {Interval = ((int) 33.0)};
            this.timer.Elapsed += this.HandleTick;
            this.posicionX = 0;
            this.Velocidad = 1;
        }

        ///<summary>
        ///</summary>
        public void Activar()
        {
            this.timer.Start();
        }

        ///<summary>
        ///</summary>
        public void Desactivar()
        {
            this.timer.Stop();
            this.posicionX = 0;
        }

        private void HandleTick(object sender, ElapsedEventArgs e)
        {
            this.posicionX += this.Velocidad;
            if (this.posicionX > Size.Width)
            {
                this.posicionX = 0;
            }
            if (this.posicionX < 0)
            {
                this.posicionX = Size.Width;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var graphics = pe.Graphics;
            graphics.DrawImage(Image, this.posicionX, 0, Size.Width, Size.Height);
            if (this.posicionX != 0)
            {
                graphics.DrawImage(Image, (this.posicionX - Size.Width) + 1, 0, Size.Width,
                                   Size.Height);
            }
        }
    }
}