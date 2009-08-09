using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmPruebas : Form
    {
        public SAIFrmPruebas()
        {
            InitializeComponent();
        }

        private void groupBox1_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("drag&drop");
            Debug.WriteLine(e.Effect.ToString());
        }

        private void groupBox1_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("enter");
            Debug.WriteLine(e.Effect.ToString());
        }

        private void groupBox1_DragLeave(object sender, EventArgs e)
        {
            Debug.WriteLine("leave");
        }

        private void groupBox1_DragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine("over");
            Debug.WriteLine(e.Effect.ToString());
        }

        private void SAIFrmPruebas_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("enter");
            Debug.WriteLine(e.Effect.ToString());
        }
    }
}
