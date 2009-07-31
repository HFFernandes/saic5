using System.Timers;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    public partial class SAISpinnerBox : PictureBox
    {
        #region Campos

        protected bool esActivo;
        protected int posicionX;
        protected System.Timers.Timer timer;
        protected int velocidad;

        #endregion

        #region Propiedades

        public double Intervalo
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = (int)value;
            }
        }

        public int Velocidad
        {
            get
            {
                return this.velocidad;
            }
            set
            {
                this.velocidad = value;
            }
        }

        #endregion

        public SAISpinnerBox()
        {
            InitializeComponent();

            this.esActivo = false;
            this.timer = new System.Timers.Timer { Interval = ((int)33.0) };
            this.timer.Elapsed += this.HandleTick;
            this.posicionX = 0;
            this.Velocidad = 1;
        }

        public void Activar()
        {
            this.timer.Start();
        }

        public void Desactivar()
        {
            this.timer.Stop();
            this.posicionX = 0;
        }

        private void HandleTick(object sender, ElapsedEventArgs e)
        {
            this.posicionX += this.Velocidad;
            if (this.posicionX > base.Size.Width)
            {
                this.posicionX = 0;
            }
            if (this.posicionX < 0)
            {
                this.posicionX = base.Size.Width;
            }
            base.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var graphics = pe.Graphics;
            graphics.DrawImage(base.Image, this.posicionX, 0, base.Size.Width, base.Size.Height);
            if (this.posicionX != 0)
            {
                graphics.DrawImage(base.Image, (this.posicionX - base.Size.Width) + 1, 0, base.Size.Width, base.Size.Height);
            }
        }
    }
}
