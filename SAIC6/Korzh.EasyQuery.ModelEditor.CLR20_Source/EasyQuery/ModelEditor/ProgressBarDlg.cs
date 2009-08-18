namespace Korzh.EasyQuery.ModelEditor
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ProgressBarDlg : Form
    {
        private Container components;
        private ProgressBar progressBar1;

        public ProgressBarDlg()
        {
            this.InitializeComponent();
            XPStyle.ApplyVisualStyles(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.progressBar1 = new ProgressBar();
            base.SuspendLayout();
            this.progressBar1.Location = new Point(8, 0x10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(0x138, 0x17);
            this.progressBar1.TabIndex = 0;
            this.AutoScaleBaseSize = new Size(5, 13);
            base.ClientSize = new Size(0x150, 0x36);
            base.ControlBox = false;
            base.Controls.Add(this.progressBar1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ProgressBarDlg";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Progress Bar";
            base.Load += new EventHandler(this.ProgressBarDlg_Load);
            base.ResumeLayout(false);
        }

        private void ProgressBarDlg_Load(object sender, EventArgs e)
        {
        }

        public void SetMinMax(int min, int max)
        {
            this.progressBar1.Minimum = min;
            this.progressBar1.Maximum = max;
        }

        public void SetPosition(int position)
        {
            this.progressBar1.Value = position;
            this.progressBar1.Update();
        }
    }
}

