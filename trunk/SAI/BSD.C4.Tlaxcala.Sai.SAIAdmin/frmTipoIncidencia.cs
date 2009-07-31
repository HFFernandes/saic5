using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSD.C4.Tlaxcala.Sai.SAIAdmin
{
    /// <summary>
    /// Forma Base para el mantenimiento a catálogos.
    /// </summary>
    /// <param name=""></param>
    /// 
    public partial class frmTipoIncidencia : Form
    {


        #region Campos

        private string _strEtiquetaTituloCatalogo;

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el color de fondo que toma el control cuando obtiene el foco
        /// </summary>
        [Category("Appearance"), Description("Obtiene o establece el mensaje titulo de la ventana.")]
        public string EtiquetaTituloCatalogo
        {
            get
            {
                return this._strEtiquetaTituloCatalogo;
            }
            set
            {
                this._strEtiquetaTituloCatalogo = value;
            }
        }



      #endregion



        public frmTipoIncidencia()
        {
            InitializeComponent();
            this.lblTitulo.Text = _strEtiquetaTituloCatalogo;
        }


        /// <summary>
        /// Método para cerrar la forma.
        /// </summary>
        /// <param name=""></param>
        private void mnuBtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
