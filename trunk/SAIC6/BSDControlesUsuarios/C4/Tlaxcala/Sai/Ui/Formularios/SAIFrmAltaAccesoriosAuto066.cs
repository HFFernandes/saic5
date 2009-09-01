﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmAltaAccesoriosAuto066 : Form
    {

        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SAIFrmAltaAccesoriosAuto066()
        {
            InitializeComponent();
        }

        #endregion

        #region PROPIEDADES

        public VehiculoObjectList ListaVehiculosInvolucrados { get; set; }

        public RoboAccesoriosObject DatosRoboAccesorio { get; set; }

        public RoboVehiculoAccesoriosObjectList ListaAccesoriosRobados { get; set; }

        /// <summary>
        /// Vehiculo que se esta editanto.
        /// </summary>
        VehiculoObject VehiculoInvolucrado;



        #endregion

        #region MÉTODOS

        /// <summary>
        /// Obtiene los datos acerca de los accesorios robados.
        /// </summary>
        private void ObtenerDatosAccesorios()
        {
            if (DatosRoboAccesorio==null)
            {
                DatosRoboAccesorio = new RoboAccesoriosObject();
            }
            DatosRoboAccesorio.DescripcionResponsable = this.txtAccesoriosResponsables.Text;
            DatosRoboAccesorio.FechaPercato = this.dtpAccesoriosFechaPercato.Value.Date;
            DatosRoboAccesorio.PersonaPercato = this.txtAccesoriosPersonaSePercato.Text;
        }

        /// <summary>
        /// Agrega un vehiculo a la lista de vehiculos
        /// </summary>
        private void AgregarVehiculoALista()
        {
            bool EsNuevo = false;
            if(this.ListaVehiculosInvolucrados==null)
            {this.ListaVehiculosInvolucrados = new VehiculoObjectList();}

            if (this.VehiculoInvolucrado == null)
            {
                VehiculoInvolucrado = new VehiculoObject();
                EsNuevo = true;
            }
            VehiculoInvolucrado.Marca = this.txtMarca.Text;
            VehiculoInvolucrado.Modelo = this.txtModelo.Text;
            VehiculoInvolucrado.Placas = this.txtPlacas.Text;

            if (!EsNuevo)
            {
                ListaVehiculosInvolucrados.Replace(VehiculoInvolucrado);
            }
            else
            {
                this.ListaVehiculosInvolucrados.Add(VehiculoInvolucrado);
            }
            

            //Agregamos los accesorios de este vehiculo
            this.AgregarAccesoriosALista(VehiculoInvolucrado.Clave);

            //Limpiamos los campos
            this.txtMarca.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtPlacas.Text = string.Empty;

            //Mostramos la listas de vehiculos capturados.
            this.MostrarVehiculos(this.ListaVehiculosInvolucrados);
            this.VehiculoInvolucrado = null;

        }

        /// <summary>
        /// Obtiene los accesorios capturados y los mete a la lista.
        /// </summary>
        /// <param name="idVehiculo"></param>
        private void AgregarAccesoriosALista(int idVehiculo)
        {
            bool EsNuevo = false;
            //Validamos que no sea nula
            if(this.ListaAccesoriosRobados==null)
            {
                this.ListaAccesoriosRobados = new RoboVehiculoAccesoriosObjectList();
            }

            RoboVehiculoAccesoriosObject AccesorioRobado;
            foreach(DataGridViewRow row in this.dgvAccesorios.Rows)
            {
                if (row.Cells[1].Value!=null)
                {
                    if (row.Cells[0].Value == null)
                    {
                        AccesorioRobado = new RoboVehiculoAccesoriosObject();
                        EsNuevo = true;
                    }
                    else
                    {
                        AccesorioRobado = this.ObtenerAccesorioEditado(Convert.ToInt32(row.Cells[0].Value));
                    }
                    AccesorioRobado.AccesorioRobado = row.Cells[1].Value.ToString();
                    AccesorioRobado.ClaveVehiculo = idVehiculo;
                    if (EsNuevo)
                    {
                        this.ListaAccesoriosRobados.Add(AccesorioRobado);
                    }
                    else
                    {
                        this.ListaAccesoriosRobados.Replace(AccesorioRobado);
                    }
                    
                }
                
            }
            this.dgvAccesorios.Rows.Clear();
        }

        private RoboVehiculoAccesoriosObject ObtenerAccesorioEditado(int idAccesorio)
        {
            RoboVehiculoAccesoriosObject encontrado = new RoboVehiculoAccesoriosObject();
            foreach(RoboVehiculoAccesoriosObject accesorio in this.ListaAccesoriosRobados)
            {
                if (accesorio.IdAccesorio == idAccesorio)
                {
                    encontrado= accesorio;
                }
            }
            return encontrado;
        }

        /// <summary>
        /// Muestra los accesorios de un vehiculo especificado.
        /// </summary>
        /// <param name="idVehiculo">int,Id del vehiculo.</param>
        private void MostrarAccesorioPorVehiculo(int idVehiculo)
        {
            this.dgvAccesorios.Rows.Clear();
            int count = 1;
            foreach (RoboVehiculoAccesoriosObject accesorio in this.ListaAccesoriosRobados)
            {
                if(accesorio.ClaveVehiculo==idVehiculo)
                {
                    this.dgvAccesorios.Rows[dgvAccesorios.RowCount - count].Cells[0].Value = accesorio.IdAccesorio;
                    this.dgvAccesorios.Rows[dgvAccesorios.RowCount-count].Cells[1].Value = accesorio.AccesorioRobado;
                    this.dgvAccesorios.Rows.Add(1);
                    count++;
                }
            }
            //For para quitar las filas vacias.
            for (int i = 0; i < count; i++)
            {
                if ((dgvAccesorios.RowCount - 1) >= i)
                    if (this.dgvAccesorios.Rows[i].Cells[1].Value == null)
                    {
                        this.dgvAccesorios.Rows.RemoveAt(i);
                        i--;
                    }
                
            }

        }

        /// <summary>
        /// Muestra la lista de vehiculos en el grid.
        /// </summary>
        /// <param name="vehiculos"></param>
        private void MostrarVehiculos(VehiculoObjectList vehiculos)
        {
            this.dgvVehiculoAccesorios.Rows.Clear();
            foreach(VehiculoObject vehiculo in vehiculos)
            {
                this.dgvVehiculoAccesorios.Rows.Add(1);
                this.dgvVehiculoAccesorios.Rows[dgvVehiculoAccesorios.RowCount - 1].Cells[0].Value = vehiculo.Clave;
                this.dgvVehiculoAccesorios.Rows[dgvVehiculoAccesorios.RowCount - 1].Cells[1].Value = vehiculo.Marca;
                this.dgvVehiculoAccesorios.Rows[dgvVehiculoAccesorios.RowCount - 1].Cells[2].Value = vehiculo.Modelo;
                this.dgvVehiculoAccesorios.Rows[dgvVehiculoAccesorios.RowCount - 1].Cells[3].Value = vehiculo.Placas;
            }
            
        }

        private void MostrarDatosVehiculo(int idVehiculo)
        {
            if(this.ListaVehiculosInvolucrados!=null)
            {
                foreach(VehiculoObject vehiculo in this.ListaVehiculosInvolucrados)
                {
                    if(vehiculo.Clave==idVehiculo)
                    {
                        this.VehiculoInvolucrado = vehiculo;
                        this.txtMarca.Text = vehiculo.Marca;
                        this.txtModelo.Text = vehiculo.Modelo;
                        this.txtPlacas.Text = vehiculo.Placas;
                        this.MostrarAccesorioPorVehiculo(idVehiculo);
                        break;
                    }

                }
            }
            
        }

        #endregion

        #region MANEJADORES DE EVENTOS

        private void SAIAltaAccesoriosAuto066_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.ObtenerDatosAccesorios();
                    this.Close();
                    break;
            }
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            this.AgregarVehiculoALista();
        }

        private void dgvVehiculoAccesorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvVehiculoAccesorios.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int idVehiculo = Convert.ToInt32(this.dgvVehiculoAccesorios.Rows[e.RowIndex].Cells[0].Value);
                this.MostrarDatosVehiculo(idVehiculo);
            }

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

        private void SAIFrmAltaAccesoriosAuto066_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.ObtenerDatosAccesorios();
            }
            catch (System.Exception ex)
            {
                throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
            }
        }

        #endregion

        

        
  
    }
}
