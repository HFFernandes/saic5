using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmAltaDatosAuto066 : Form
    {

        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SAIFrmAltaDatosAuto066()
        {
            InitializeComponent();
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Propietario del Vehículo.
        /// </summary>
        public PropietarioVehiculoObject Propietario {get; set; }

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
            //Llenamos los datos del propietario.
            if(this.Propietario==null)
            {
                this.Propietario = new PropietarioVehiculoObject();
            }
            
            this.Propietario.Domicilio = this.txtDireccionPropietario.Text;
            this.Propietario.Nombre = this.txtNombrePropietario.Text;
            this.Propietario.Telefono = this.txtTelefonoPropietario.Text;

            //Llenamos los datos
            if(this.ListaVehiculos==null)
            {
                this.ListaVehiculos = new VehiculoObjectList();
            }

            VehiculoObject Vehiculo;
            foreach(DataGridViewRow row in this.dgvVehiculo.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value!=null)
                {
                    //Capturamos los datos por vehiculo.
                    Vehiculo = new VehiculoObject();
                    Vehiculo.Marca = row.Cells[1].Value != null ? Convert.ToString(row.Cells[1].Value).ToUpper() : string.Empty;
                    Vehiculo.Tipo = row.Cells[2].Value != null ? Convert.ToString(row.Cells[2].Value).ToUpper() : string.Empty;
                    Vehiculo.Modelo = row.Cells[3].Value != null ? Convert.ToString(row.Cells[3].Value).ToUpper() : string.Empty;
                    Vehiculo.Placas = row.Cells[4].Value != null ? Convert.ToString(row.Cells[4].Value).ToUpper() : string.Empty;
                    Vehiculo.Color = row.Cells[5].Value != null ? Convert.ToString(row.Cells[5].Value).ToUpper() : string.Empty;
                    Vehiculo.NumeroMotor = row.Cells[6].Value != null ? Convert.ToString(row.Cells[6].Value).ToUpper() : string.Empty;
                    Vehiculo.NumeroSerie = row.Cells[7].Value != null ? Convert.ToString(row.Cells[7].Value).ToUpper() : string.Empty;
                    Vehiculo.SeñasParticulares = row.Cells[8].Value != null ? Convert.ToString(row.Cells[8].Value).ToUpper() : string.Empty;
                    //Agregamos el vehiculo a la lista 
                    this.ListaVehiculos.Add(Vehiculo);
                }
                
              
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

        private void SAIFrmAltaDatosAuto066_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.LlenarDatosAuto();
            }
            catch (System.Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
            }

        }

        #endregion

        

    }
}
