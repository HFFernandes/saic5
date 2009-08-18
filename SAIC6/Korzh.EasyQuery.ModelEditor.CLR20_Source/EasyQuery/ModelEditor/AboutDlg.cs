namespace Korzh.EasyQuery.ModelEditor
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Resources;
    using System.Windows.Forms;

    public class AboutDlg : Form
    {
        private Button buttonOK;
        private Container components;
        private Label labelCopyright;
        private Label labelTitle;
        private Label labelVersion;
        private Panel panel1;
        private PictureBox pictureBox1;

        public AboutDlg()
        {
            this.InitializeComponent();
            XPStyle.ApplyVisualStyles(this);
        }

        private void AboutDlg_Load(object sender, EventArgs e)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            this.labelVersion.Text = "Version: " + executingAssembly.GetName().Version.ToString();
            AssemblyCopyrightAttribute customAttribute = (AssemblyCopyrightAttribute) Attribute.GetCustomAttribute(executingAssembly, typeof(AssemblyCopyrightAttribute));
            this.labelCopyright.Text = customAttribute.Copyright;
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
            ResourceManager manager = new ResourceManager(typeof(AboutDlg));
            this.buttonOK = new Button();
            this.panel1 = new Panel();
            this.labelCopyright = new Label();
            this.labelVersion = new Label();
            this.labelTitle = new Label();
            this.pictureBox1 = new PictureBox();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.buttonOK.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x80, 0xc0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.panel1.BorderStyle = BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelCopyright);
            this.panel1.Controls.Add(this.labelVersion);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x138, 0xb0);
            this.panel1.TabIndex = 4;
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new Point(8, 0x60);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new Size(50, 0x10);
            this.labelCopyright.TabIndex = 6;
            this.labelCopyright.Text = "copyright";
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new Point(120, 0x30);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new Size(0x29, 0x10);
            this.labelVersion.TabIndex = 5;
            this.labelVersion.Text = "version";
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0xcc);
            this.labelTitle.Location = new Point(120, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(170, 0x19);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Data Model Editor";
            this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            this.pictureBox1.Image = (Image) manager.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x60, 80);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.AutoScaleBaseSize = new Size(5, 13);
            base.CancelButton = this.buttonOK;
            base.ClientSize = new Size(330, 0xe0);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.buttonOK);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "AboutDlg";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "About";
            base.Load += new EventHandler(this.AboutDlg_Load);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

