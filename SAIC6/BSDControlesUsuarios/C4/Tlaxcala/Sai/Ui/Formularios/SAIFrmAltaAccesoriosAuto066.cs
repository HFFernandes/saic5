//Autor : T.S.U. Angel Martinez Ortiz
//Fecha : Agosto del 2009
//Empresa :InfinitySoft TI Experts


using System;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using System.Diagnostics;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    /// <summary>
    /// Formulario para capturar los datos de una incidencia de tipo: Robo accesorios vehiculo.
    /// </summary>
    public partial class SAIFrmAltaAccesoriosAuto066 : Form
    {
        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SAIFrmAltaAccesoriosAuto066()
        {
            InitializeComponent();
            dgvAccesorios.RowHeadersVisible = true;
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Contiene la lisa de vehiculos involucrados en el robo.
        /// </summary>
        public VehiculoObjectList ListaVehiculosInvolucrados { get; set; }

        /// <summary>
        /// Contiene los datos generales del robo de accesorios.
        /// </summary>
        public RoboAccesorios DatosRoboAccesorio { get; set; }

        /// <summary>
        /// Contiene la lista de accesorios robados.
        /// </summary>
        public RoboVehiculoAccesoriosList ListaAccesoriosRobados { get; set; }

        /// <summary>
        /// Vehiculo que se esta editanto.
        /// </summary>
        private VehiculoObject VehiculoInvolucrado;

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Obtiene los datos acerca de los accesorios robados.
        /// </summary>
        private void ObtenerDatosAccesorios()
        {
            if (DatosRoboAccesorio == null)
            {
                DatosRoboAccesorio = new RoboAccesorios();
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
            if (this.ListaVehiculosInvolucrados == null)
                this.ListaVehiculosInvolucrados = new VehiculoObjectList();
            //else
            //    this.ListaVehiculosInvolucrados.Clear();

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
            //this.AgregarAccesoriosALista(VehiculoInvolucrado.Clave);

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
            if (this.ListaAccesoriosRobados == null)
                this.ListaAccesoriosRobados = new RoboVehiculoAccesoriosList();
            //else
            //    this.ListaAccesoriosRobados.Clear();

            RoboVehiculoAccesorios AccesorioRobado;
            foreach (DataGridViewRow row in this.dgvAccesorios.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    if (row.Cells[0].Value == null)
                    {
                        AccesorioRobado = new RoboVehiculoAccesorios();
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
            //this.dgvAccesorios.Rows.Clear();
        }

        /// <summary>
        /// Obtiene el accesorio que se esta editando
        /// </summary>
        /// <param name="idAccesorio">idAccesorio,int Id del accesorio</param>
        /// <returns></returns>
        private RoboVehiculoAccesorios ObtenerAccesorioEditado(int idAccesorio)
        {
            var encontrado = new RoboVehiculoAccesorios();
            foreach (var accesorio in this.ListaAccesoriosRobados)
            {
                if (accesorio.IdAccesorio == idAccesorio)
                {
                    encontrado = accesorio;
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
            //int count = 1;

            //if (ListaAccesoriosRobados != null)
            //    foreach (var accesorio in this.ListaAccesoriosRobados)
            //    {
            //        if (accesorio.ClaveVehiculo == idVehiculo)
            //        {
            //            this.dgvAccesorios.Rows[dgvAccesorios.RowCount - count].Cells[0].Value = accesorio.IdAccesorio;
            //            this.dgvAccesorios.Rows[dgvAccesorios.RowCount - count].Cells[1].Value = accesorio.AccesorioRobado;
            //            this.dgvAccesorios.Rows.Add(1);

            //            count++;
            //            blnCargando = false;
            //        }
            //    }
            ////For para quitar las filas vacias.
            //if (count > 1)
            //    for (int i = 0; i < count; i++)
            //    {
            //        if ((dgvAccesorios.RowCount - 1) >= i)
            //            if (this.dgvAccesorios.Rows[i].Cells[1].Value == null)
            //            {
            //                this.dgvAccesorios.Rows.RemoveAt(i);
            //                i--;
            //            }
            //    }

            if (ListaAccesoriosRobados != null)
                for (int i = 0; i < ListaAccesoriosRobados.Count; i++)
                {
                    if (ListaAccesoriosRobados[i].ClaveVehiculo == idVehiculo)
                    {
                        dgvAccesorios.Rows.Add(ListaAccesoriosRobados[i].IdAccesorio,
                                            ListaAccesoriosRobados[i].AccesorioRobado);
                    }

                    //blnCargando = false;
                }
        }

        /// <summary>
        /// Muestra la lista de vehiculos en el grid.
        /// </summary>
        /// <param name="vehiculos"></param>
        private void MostrarVehiculos(VehiculoObjectList vehiculos)
        {
            this.dgvVehiculoAccesorios.Rows.Clear();
            foreach (VehiculoObject vehiculo in vehiculos)
            {
                this.dgvVehiculoAccesorios.Rows.Add(1);
                this.dgvVehiculoAccesorios.Rows[dgvVehiculoAccesorios.RowCount - 1].Cells[0].Value = vehiculo.Clave;
                this.dgvVehiculoAccesorios.Rows[dgvVehiculoAccesorios.RowCount - 1].Cells[1].Value = vehiculo.Marca;
                this.dgvVehiculoAccesorios.Rows[dgvVehiculoAccesorios.RowCount - 1].Cells[2].Value = vehiculo.Modelo;
                this.dgvVehiculoAccesorios.Rows[dgvVehiculoAccesorios.RowCount - 1].Cells[3].Value = vehiculo.Placas;
            }
        }

        /// <summary>
        /// Muestra los datos de un vehiculo capturado, y sus accesorios robados.
        /// </summary>
        /// <param name="idVehiculo">int,Id del vehiculo a editar</param>
        private void MostrarDatosVehiculo(int idVehiculo)
        {
            if (this.ListaVehiculosInvolucrados != null)
            {
                foreach (VehiculoObject vehiculo in this.ListaVehiculosInvolucrados)
                {
                    if (vehiculo.Clave == idVehiculo)
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

        /// <summary>
        /// Muestra todos los datos del robo de accesorios.
        /// </summary>
        private void MostrarDatosRoboAccesorios()
        {
            if (DatosRoboAccesorio != null)
            {
                this.txtAccesoriosPersonaSePercato.Text = DatosRoboAccesorio.PersonaPercato;
                this.txtAccesoriosResponsables.Text = DatosRoboAccesorio.DescripcionResponsable;
                this.dtpAccesoriosFechaPercato.Value = DatosRoboAccesorio.FechaPercato.Value;
            }
            if (ListaVehiculosInvolucrados != null)
            {
                //Mostramos la listas de vehiculos capturados.
                this.MostrarVehiculos(this.ListaVehiculosInvolucrados);
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

                    var controlActual = (Control)sender;
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
                throw new SAIExcepcion(ex.Message, this);
            }
        }

        private void SAIFrmAltaAccesoriosAuto066_Load(object sender, EventArgs e)
        {
            this.MostrarDatosRoboAccesorios();
        }

        #endregion

        private void btnEliminarAccesorio_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dgvAccesorios.CurrentRow != null && !dgvAccesorios.CurrentRow.IsNewRow)
                //    dgvAccesorios.Rows.Remove(dgvAccesorios.CurrentRow);
                //else if (dgvAccesorios.Rows.Count == 1)
                //    dgvAccesorios.Rows.Clear();

                if (dgvAccesorios.CurrentRow != null && !dgvAccesorios.CurrentRow.IsNewRow)
                {
                    ListaAccesoriosRobados.RemoveAll(r => r.IdAccesorio == Convert.ToInt32(dgvAccesorios.CurrentRow.Cells[0].Value));
                    dgvAccesorios.Rows.Remove(dgvAccesorios.CurrentRow);
                }
                else if (dgvAccesorios.Rows.Count == 1)
                    dgvAccesorios.Rows.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void dgvAccesorios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVehiculoAccesorios.SelectedRows.Count > 0 /*&& !blnCargando*/)
                {
                    AgregarAccesoriosALista(Convert.ToInt32(dgvVehiculoAccesorios.CurrentRow.Cells[0].Value));
                    dgvVehiculoAccesorios_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
                }
            }
            catch (Exception)
            {
            }
        }
    }
}