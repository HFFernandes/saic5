//Autor : T.S.U. Angel Martinez Ortiz
//Fecha : Agosto del 2009
//Empresa :InfinitySoft TI Experts

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
                Vehiculo = new VehiculoObject();
                if (row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value!=null)
                {

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
            if (Propietario!=null)
            {
                this.txtDireccionPropietario.Text = Propietario.Domicilio;
                this.txtNombrePropietario.Text = Propietario.Nombre;
                this.txtTelefonoPropietario.Text = Propietario.Telefono;
            }
            if (ListaVehiculos!=null)
            {
                this.dgvVehiculo.Rows.Clear();
                int count = 1;
                foreach (VehiculoObject vehiculo in this.ListaVehiculos)
                {

                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[0].Value = vehiculo.Clave;
                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[1].Value = vehiculo.Marca;
                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[2].Value = vehiculo.Tipo;
                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[3].Value = vehiculo.Modelo;
                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[4].Value = vehiculo.Placas;
                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[5].Value = vehiculo.Color;
                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[6].Value = vehiculo.NumeroMotor;
                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[7].Value = vehiculo.NumeroSerie;
                    this.dgvVehiculo.Rows[dgvVehiculo.RowCount - count].Cells[8].Value = vehiculo.SeñasParticulares;
                    this.dgvVehiculo.Rows.Add(1);
                        count++;
                    
                }
                //For para quitar las filas vacias.
                for (int i = 0; i < count; i++)
                {
                    if ((dgvVehiculo.RowCount - 1) >= i)
                        if (this.dgvVehiculo.Rows[i].Cells[1].Value == null)
                        {
                            this.dgvVehiculo.Rows.RemoveAt(i);
                            i--;
                        }

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

        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            //Para pasar el foco al control siguiente.
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
                this.LlenarDatosAuto();
            }
            catch (System.Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
            }

        }

        private void SAIFrmAltaDatosAuto066_Load(object sender, EventArgs e)
        {
            this.MostrarDatosAuto();
        }

        #endregion

        

        

    }
}
