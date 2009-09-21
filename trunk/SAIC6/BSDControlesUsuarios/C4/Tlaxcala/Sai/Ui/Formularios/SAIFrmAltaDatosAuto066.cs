//Autor : T.S.U. Angel Martinez Ortiz
//Fecha : Agosto del 2009
//Empresa :InfinitySoft TI Experts

using System;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{

    /// <summary>
    /// Formulario para capturar datos de una incidencia de tipo : Robo vehiculo totalidad.
    /// </summary>
    public partial class SAIFrmAltaDatosAuto066 : Form
    {

        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SAIFrmAltaDatosAuto066()
        {
            InitializeComponent();
            dgvVehiculo.RowHeadersVisible = true;
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Propietario del Vehículo.
        /// </summary>
        public PropietarioVehiculoObject Propietario { get; set; }

        /// <summary>
        /// Lista con el/los vehiculos que fueron reportados como robados.
        /// </summary>
        public VehiculoObjectList ListaVehiculos { get; set; }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Obtiene los datos del/los vehiculos robados.
        /// </summary>
        private void LlenarDatosAuto()
        {
            if (ListaVehiculos != null)
                ListaVehiculos.Clear();

            //Llenamos los datos del propietario.
            if (this.Propietario == null)
            {
                this.Propietario = new PropietarioVehiculoObject();
            }

            this.Propietario.Domicilio = this.txtDireccionPropietario.Text;
            this.Propietario.Nombre = this.txtNombrePropietario.Text;
            this.Propietario.Telefono = this.txtTelefonoPropietario.Text;

            //Llenamos los datos
            if (this.ListaVehiculos == null)
            {
                this.ListaVehiculos = new VehiculoObjectList();
            }

            VehiculoObject Vehiculo;
            foreach (DataGridViewRow row in this.dgvVehiculo.Rows)
            {
                //Vehiculo = new VehiculoObject();
                if (row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    Vehiculo = new VehiculoObject();
                    if (row.Cells[0].Value != null)
                    {
                        Vehiculo = VehiculoMapper.Instance().GetOne(Convert.ToInt32(row.Cells[0].Value));

                    }
                    if (Vehiculo == null)
                    { Vehiculo = new VehiculoObject(); }
                    //Capturamos los datos por vehiculo.
                    Vehiculo.Marca = row.Cells[1].Value != null ? Convert.ToString(row.Cells[1].Value).ToUpper() : string.Empty;
                    Vehiculo.Tipo = row.Cells[2].Value != null ? Convert.ToString(row.Cells[2].Value).ToUpper() : string.Empty;
                    Vehiculo.Modelo = row.Cells[3].Value != null ? Convert.ToString(row.Cells[3].Value).ToUpper() : string.Empty;
                    Vehiculo.Placas = row.Cells[4].Value != null ? Convert.ToString(row.Cells[4].Value).ToUpper() : string.Empty;
                    Vehiculo.Color = row.Cells[5].Value != null ? Convert.ToString(row.Cells[5].Value).ToUpper() : string.Empty;
                    Vehiculo.NumeroMotor = row.Cells[6].Value != null ? Convert.ToString(row.Cells[6].Value).ToUpper() : string.Empty;
                    Vehiculo.NumeroSerie = row.Cells[7].Value != null ? Convert.ToString(row.Cells[7].Value).ToUpper() : string.Empty;
                    Vehiculo.SeñasParticulares = row.Cells[8].Value != null ? Convert.ToString(row.Cells[8].Value).ToUpper() : string.Empty;
                    //Agregamos el vehiculo a la lista 
                    if (ListaVehiculos.Contains(Vehiculo))
                    {
                        this.ListaVehiculos.Replace(Vehiculo);
                    }
                    else
                    {
                        this.ListaVehiculos.Add(Vehiculo);
                    }

                }
            }
        }

        /// <summary>
        /// Muestra los datos del auto en caso de que ya tenga datos capturados.
        /// </summary>
        private void MostrarDatosAuto()
        {
            try
            {
                if (Propietario != null)
                {
                    this.txtDireccionPropietario.Text = Propietario.Domicilio;
                    this.txtNombrePropietario.Text = Propietario.Nombre;
                    this.txtTelefonoPropietario.Text = Propietario.Telefono;
                }

                if (ListaVehiculos != null)
                {
                    this.dgvVehiculo.Rows.Clear();
                    for (int i = 0; i < ListaVehiculos.Count; i++)
                    {
                        this.dgvVehiculo.Rows.Add(ListaVehiculos[i].Clave,
                            ListaVehiculos[i].Marca,
                            ListaVehiculos[i].Tipo,
                            ListaVehiculos[i].Modelo,
                            ListaVehiculos[i].Placas,
                            ListaVehiculos[i].Color,
                            ListaVehiculos[i].NumeroMotor,
                            ListaVehiculos[i].NumeroSerie,
                            ListaVehiculos[i].SeñasParticulares);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region MANEJADORES DE EVENTOS

        private void SAIFrmAltaDatosAuto066_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No permite introducir texto
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            //Para pasar el foco al control siguiente segun el TabIndex.
            switch (e.KeyData)
            {
                case Keys.Enter:
                    Control controlActual = (Control)sender;
                    this.FindForm().SelectNextControl(controlActual, true, false, true, true);

                    break;
            }
        }

        private void SAIFrmAltaDatosAuto066_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Obtenemos los datos de los autos que fueron capturados.
                this.LlenarDatosAuto();
            }
            catch (System.Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
            }

        }

        private void SAIFrmAltaDatosAuto066_Load(object sender, EventArgs e)
        {
            //Mostramos los vehículos que ya han sido capturados.
            this.MostrarDatosAuto();
        }

        #endregion

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehiculo.CurrentRow != null && !dgvVehiculo.CurrentRow.IsNewRow)
                    dgvVehiculo.Rows.Remove(dgvVehiculo.CurrentRow);
                else if (dgvVehiculo.Rows.Count == 1)
                    dgvVehiculo.Rows.Clear();
            }
            catch (Exception)
            {
            }
        }
    }
}
