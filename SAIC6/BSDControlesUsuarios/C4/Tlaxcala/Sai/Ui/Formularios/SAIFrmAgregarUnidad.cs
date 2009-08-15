using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmAgregarUnidad : SAIFrmBase
    {
        public SAIFrmAgregarUnidad()
        {
            InitializeComponent();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (SAIProveedorValidacion.ValidarCamposRequeridos(this))
                    {
                        var unidad = new Unidad
                                         {
                                             Activo = true,
                                             ClaveCorporacion = Aplicacion.UsuarioPersistencia.intCorporacion ?? -1,
                                             Codigo = saiTxtUnidad.Text
                                         };

                        UnidadMapper.Instance().Insert(unidad);
                        DialogResult = DialogResult.OK;
                        base.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            {
            }
        }
    }
}
