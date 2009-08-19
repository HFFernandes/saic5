using System;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmAgendaTelefonica : SAIFrmBase
    {
        public SAIFrmAgendaTelefonica()
        {
            InitializeComponent();

            Width = Screen.GetWorkingArea(this).Width;
            saiReport1.btnLigarIncidencias.Click += btnLigarIncidencias_Click;
            saiReport1.btnDespacharIncidencias.Click += btnDespacharIncidencias_Click;
            saiReport1.btnBajaUnidad.Click += btnBajaUnidad_Click;
            saiReport1.btnAltaUnidad.Click += btnAltaUnidad_Click;
            saiReport1.btnVistaPrevia.Click += btnVistaPrevia_Click;
            saiReport1.reportControl.RowDblClick += reportControl_RowDblClick;
        }

        void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                if (Aplicacion.UsuarioPersistencia.blnPuedeLeeroEscribir(ID.CMD_TEL))
                {
                    saiReport1.reportControl.PrintPreviewOptions.Title = "Agenda Telefónica";
                    saiReport1.reportControl.PrintPreview(true);
                }
                else
                    throw new SAIExcepcion("No tiene los permisos suficientes para realizar esta acción.");
            }
            catch (SAIExcepcion)
            {
            }
        }

        void reportControl_RowDblClick(object sender, AxXtremeReportControl._DReportControlEvents_RowDblClickEvent e)
        {
        }

        void btnAltaUnidad_Click(object sender, EventArgs e)
        {
        }

        void btnBajaUnidad_Click(object sender, EventArgs e)
        {
        }

        void btnDespacharIncidencias_Click(object sender, EventArgs e)
        {
        }

        void btnLigarIncidencias_Click(object sender, EventArgs e)
        {
        }

        private void SAIFrmAgendaTelefonica_Load(object sender, EventArgs e)
        {

            saiReport1.btnAltaUnidad.Visible = false;
            saiReport1.btnBajaUnidad.Visible = false;
            saiReport1.btnSeparador2.Visible = false;
            saiReport1.btnDespacharIncidencias.Visible = false;
            saiReport1.btnLigarIncidencias.Visible = false;

            //Definir las columnas del listado y obtener los registros
            saiReport1.AgregarColumna(0, "ID", 20, false, false, false, false);
            saiReport1.AgregarColumna(1, "Nombre", 200, true, true, true, false);
            saiReport1.AgregarColumna(2, "Dirección", 200, true, true, true, false);
            saiReport1.AgregarColumna(3, "Teléfono", 80, true, true, true, false, true, 4);
            saiReport1.AgregarColumna(4, "Fax", 80, true, true, true, false);
            saiReport1.AgregarColumna(5, "Email", 80, true, true, true, false);
            saiReport1.AgregarColumna(6, "Dirección Web", 90, true, true, true, false);
            saiReport1.AgregarColumna(7, "Clasificación", 150, true, true, true, false);

            ObtenerRegistros();
            saiReport1.reportControl.Redraw();
        }

        private void ObtenerRegistros()
        {
            try
            {
                try
                {
                    OrganizacionList organizacion = OrganizacionMapper.Instance().GetAll();
                    foreach (var o in organizacion)
                    {
                        saiReport1.AgregarRegistro(null, o.Clave,
                                                   o.Nombre,
                                                   o.Dirección,
                                                   o.Telefono,
                                                   o.Fax,
                                                   o.Email,
                                                   o.DireccionWeb,
                                                   ClasificacionOrganizacionMapper.Instance().GetOne(o.ClaveClasificacion).Descripcion);
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
