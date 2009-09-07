using System;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using XtremeReportControl;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    /// <summary>
    /// Formulario que presenta el listado de unidades activas e inactivas
    /// de todas las corporaciones
    /// </summary>
    public partial class SAIFrmUnidades : SAIFrmBase
    {
        private ReportColumn _columna;
        private ReportRecordItem _item;
        private ReportRecord _registroActual;

        /// <summary>
        /// Constructor
        /// </summary>
        public SAIFrmUnidades()
        {
            InitializeComponent();

            //Configuramos el control Grid
            ConfigurarGrid();
        }

        private void SAIFrmUnidades_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    //Obtenemos la colección de unidades
                    var unidades = UnidadMapper.Instance().GetAll();
                    foreach (var unidad in unidades)
                    {
                        //Por cada unidad insertamos un registro
                        _registroActual = axUnidadesDispuestasOcupadas.Records.Insert(0);
                        _item = _registroActual.AddItem(unidad.Clave);
                        _item = _registroActual.AddItem(unidad.Codigo);
                        _item = _registroActual.AddItem(CorporacionMapper.Instance().GetOne(unidad.ClaveCorporacion).Descripcion);
                        _item = _registroActual.AddItem(unidad.Activo ? "Si" : "No");
                    }

                    //En base al resultado obtenido se agrupan los registros
                    if (unidades.Count > 0)
                    {
                        axUnidadesDispuestasOcupadas.SortOrder.Add(axUnidadesDispuestasOcupadas.Columns[2]);
                        axUnidadesDispuestasOcupadas.ShowItemsInGroups = true;
                        axUnidadesDispuestasOcupadas.Populate();
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

        /// <summary>
        /// Método para la inicialización del grid y la definición de sus columnas
        /// </summary>
        private void ConfigurarGrid()
        {
            _columna = axUnidadesDispuestasOcupadas.Columns.Add(0, "Id", 20, false);
            _columna.Visible = false;

            _columna = axUnidadesDispuestasOcupadas.Columns.Add(1, "Unidad", 90, true);
            _columna.Sortable = false;

            _columna = axUnidadesDispuestasOcupadas.Columns.Add(2, "Corporación", 100, true);
            _columna = axUnidadesDispuestasOcupadas.Columns.Add(3, "Activa", 50, false);
        }
    }
}
