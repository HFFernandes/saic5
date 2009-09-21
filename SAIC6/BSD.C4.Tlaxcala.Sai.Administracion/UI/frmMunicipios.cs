using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Formularios;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using System.Configuration;

namespace BSD.C4.Tlaxcala.Sai.Administracion.UI
{
    public partial class frmMunicipios : SAIFrmBase
    {
        public frmMunicipios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Llena el Datagrid y combobox de estados
        /// </summary>
        private void frmMunicipios_Load(object sender, EventArgs e)
        {
            this.SAIBarraEstado.SizingGrip = false;
            this.LlenarEstados();
            this.LlenarGrid();
            this.Limpiar();
        }

        /// <summary>
        /// Llena el Datagrid con el catalogo de Municipios
        /// </summary>
        private void LlenarGrid()
        {
            try
            {
                DataTable catMunicipios = new DataTable("CatMunicipios");
                try
                {
                    catMunicipios.Columns.Add(new DataColumn("ClaveCartografia", Type.GetType("System.Int32")));
                    catMunicipios.Columns.Add(new DataColumn("ClaveEstado", Type.GetType("System.Int32")));
                    catMunicipios.Columns.Add(new DataColumn("Estado", Type.GetType("System.String")));
                    catMunicipios.Columns.Add(new DataColumn("Nombre", Type.GetType("System.String")));

                    Entidades.MunicipioList lstMunicipios = Mappers.MunicipioMapper.Instance().GetAll();

                    foreach (Entidades.Municipio municipio in lstMunicipios)
                    {
                        object[] registro = new object[]
                                                {
                                                    municipio.Clave, municipio.ClaveEstado,
                                                    Mappers.EstadoMapper.Instance().GetOne(municipio.ClaveEstado.Value).
                                                        Nombre, municipio.Nombre
                                                };

                        catMunicipios.Rows.Add(registro);
                    }

                    this.gvMunicipios.DataSource = catMunicipios;
                    //this.gvMunicipios.Columns["ClaveCartografia"].Visible = false;
                    this.gvMunicipios.Columns["ClaveEstado"].Visible = false;
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
        /// Llena el combobox xon el catalogo de Estados(Solo Tlaxcala)
        /// </summary>
        private void LlenarEstados()
        {
            try
            {
                try
                {
                    this.ddlEstado.DataSource = Mappers.EstadoMapper.Instance().GetAll();
                    this.ddlEstado.DisplayMember = "Nombre";
                    this.ddlEstado.ValueMember = "Clave";
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

        #region ABC

        /// <summary>
        /// Fauncion que agrega un nuevo municipio
        /// </summary>
        private void Agregar()
        {
            try
            {
                try
                {
                    Entidades.Municipio newMunicipio = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Municipio();
                    newMunicipio.Clave = Convert.ToInt32(this.saiClave.Text);
                    newMunicipio.ClaveEstado = Convert.ToInt32(this.ddlEstado.SelectedValue);
                    newMunicipio.Nombre = this.saiTxtNombre.Text;
                    Mappers.MunicipioMapper.Instance().Insert(newMunicipio);
                    //Agrega operacion a bitacora
                    Entidades.Bitacora bitacora = new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Bitacora();
                    bitacora.Descripcion = "Se agrego el Municipio: " + newMunicipio.Nombre;
                    bitacora.FechaOperacion = DateTime.Today;
                    bitacora.NombreCatalogo = "Municipios";
                    bitacora.NombrePropio = ConfigurationSettings.AppSettings["strUsrKey"];
                    bitacora.Operacion = "INSERT";

                    Mappers.BitacoraMapper.Instance().Insert(bitacora);
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
        /// Funcion que modifica un municipio existente (Deshabilitada)
        /// </summary>
        private void Modificar()
        {
            try
            {
                try
                {
                    int municipioSelected =
                        Convert.ToInt32(this.gvMunicipios.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value);
                    Entidades.Municipio updMunicipio =
                        new BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities.Municipio(municipioSelected);
                    updMunicipio.Clave = Convert.ToInt32(this.saiClave.Text);
                    updMunicipio.Nombre = this.saiTxtNombre.Text;
                    updMunicipio.ClaveEstado = Convert.ToInt32(this.ddlEstado.SelectedValue);
                    Mappers.MunicipioMapper.Instance().Save(updMunicipio);
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
        /// Funcion que Elimina un Municipio existente (Deshabilitada)
        /// </summary>
        private void Eliminar()
        {
            try
            {
                try
                {
                    int municipioSelected =
                        Convert.ToInt32(this.gvMunicipios.Rows[this.ObtenerIndiceSeleccionado()].Cells["Clave"].Value);
                    Mappers.MunicipioMapper.Instance().Delete(municipioSelected);
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
        /// Limpia campos del formulario de Municipios
        /// </summary>
        private void Limpiar()
        {
            this.saiClave.Text = string.Empty;
            this.saiTxtNombre.Text = string.Empty;
            //this.btnAgregar.Enabled = true;
        }

        #endregion

        /// <summary>
        /// Llama  a la funcion Limpiar
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Cierra la ventana de Municipios
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Llama la funcion Modificar y actualiza el Datagrid
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Modificar();
            this.LlenarGrid();
            this.Limpiar();
        }

        /// <summary>
        /// Llama a la funcion agregar y actualiza Datagrid
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.SAIProveedorValidacion.ValidarCamposRequeridos(this.gpbDatosGenerales))
            {
                this.Agregar();
                this.LlenarGrid();
                this.Limpiar();
            }
        }

        /// <summary>
        /// Obtiene el indice del registro seleccionado
        /// </summary>
        /// <returns>Indice</returns>
        private int ObtenerIndiceSeleccionado()
        {
            return this.gvMunicipios.CurrentCellAddress.Y;
        }

        /// <summary>
        /// Validado para que solo acepte digitos
        /// </summary>
        private void saiClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}