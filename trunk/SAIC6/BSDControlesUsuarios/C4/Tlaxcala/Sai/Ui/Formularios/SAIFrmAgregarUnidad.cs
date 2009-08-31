using System;
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
                        var unidad = UnidadMapper.Instance().GetOneBySQLQuery(string.Format(ID.SQL_VERIFICARUNIDAD, saiTxtUnidad.Text.Trim()));
                        if (unidad == null)
                        {
                            if (Aplicacion.UsuarioPersistencia.intCorporacion != null)
                            {
                                UnidadMapper.Instance().Insert(new Unidad
                                                                   {
                                                                       Activo = true,
                                                                       ClaveCorporacion = Aplicacion.UsuarioPersistencia.intCorporacion.Value,
                                                                       Codigo = saiTxtUnidad.Text
                                                                   });

                                DialogResult = DialogResult.OK;
                                Close();
                            }
                        }
                        else
                            throw new SAIExcepcion("La unidad ya existe para su corporación. Probablemente no este activa, consulte con el Administrador.");
                    }
                    else
                        throw new SAIExcepcion("Existen campos requeridos vacios.");
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
