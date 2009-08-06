namespace BSD.C4.Tlaxcala.Sai.Ui.Controles
{
    partial class SAIDatePicker
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAIDatePicker));
            this.Validador = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Validador)).BeginInit();
            this.SuspendLayout();
            // 
            // Validador
            // 
            this.Validador.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            // 
            // SAIDatePicker
            // 
            this.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this, "$this");
            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Validador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider Validador;
    }
}
