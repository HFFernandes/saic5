using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Ui.Controles;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmIncidencia089 : SAIFrmIncidencia
    {
        public SAIFrmIncidencia089()
        {
            int intHeight = base.Height;
            int intWidth = base.Width;

            InitializeComponent();
            this.lblTitulo.Text = "REGISTRO DE DENUNCIA 089";
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Height = intHeight;
            this.Width = intWidth;
            this.ResumeLayout(false);
            if (this._entIncidencia != null)
            {
                this.Text = this._entIncidencia.Folio.ToString();
            }
            this.InicializaCampos();
        }

        public SAIFrmIncidencia089(Incidencia EntIncidencia)
            : base(EntIncidencia, false)
        {

            int intHeight = base.Height;
            int intWidth = base.Width;

            InitializeComponent();
            this.lblTitulo.Text = "ACTUALIZACIÓN DE DENUNCIA 089";
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Height = intHeight;
            this.Width = intWidth;
            this.ResumeLayout(false);
            this.CambiaHabilitadoTipoIncidencia(false);
            this.Text = this._entIncidencia.Folio.ToString();
            this.InicializaCampos();
           
        }

        /// <summary>
        /// Carga las listas y la información de la incidencia en los controles del formulario
        /// </summary>
        private void InicializaCampos()
        {
            DependenciaList lstDependencias;
            String[] arrDepandencias;
            Dependencia entDependencia;
            int i;
            int j;
            int k;

            //Se cargan los elementos en dependencias
            lstDependencias = DependenciaMapper.Instance().GetAll();
            if (lstDependencias != null && lstDependencias.Count > 0)
            {
                arrDepandencias = new String[lstDependencias.Count];

                i = 0;
                foreach (Dependencia entElementoDependencia in lstDependencias)
                {
                    arrDepandencias[i] = entElementoDependencia.Descripcion;
                    i++;
                }
                this.cklDependencia.Items.AddRange(arrCorporaciones);
                this.cklDependencia.CheckOnClick = true;
            }
            //Si la incidencia no es nula, se carga la información en los campos correspondientes:
            if (this._entIncidencia != null)
            {
                this.txtAlias.Text = this._entIncidencia.AliasDelincuente;
                this.txtNumeroOficio.Text = this._entIncidencia.NumeroOficio;
                if (this._entIncidencia.FechaDocumento.HasValue)
                {
                    this.dtmFechaDocumento.Value = this._entIncidencia.FechaDocumento.Value;
                    this.dtmFechaDocumento.Enabled = true;
                    this.chkFechaDocumento.Checked = true;
                }
                else
                {
                    this.dtmFechaDocumento.Enabled = false;
                    this.chkFechaDocumento.Checked = false;
                }
                //Se palomean las dependencias relacionadas a la incidencia:
                IncidenciaDependenciaList  lstIncidenciaDependencia = IncidenciaDependenciaMapper.Instance().GetByIncidencia(this._entIncidencia.Folio);
                if (lstIncidenciaDependencia != null && lstIncidenciaDependencia.Count > 0)
                {
                    for (j = 0; j < lstIncidenciaDependencia.Count; j++)
                    {
                        Dependencia entDependencia = CorporacionMapper.Instance().GetOne(lstIncidenciaDependencia[j].ClaveDependencia);

                        for (i = 0; i < this.cklDependencia.Items.Count; i++)
                        {
                            if (this.cklDependencia.Items[i].ToString() == entDependencia.Descripcion)
                            {
                                k++;
                                this.cklDependencia.SetItemChecked(j, true);
                                //Se llena el grid con las dependencias relacionadas a la incidencia:
                                this.dgvDependencias.Rows.Add();
                                this.dgvDependencias[0, k - 1].Value = entDependencia.Clave;
                                this.dgvDependencias[1, k - 1].Value = entDependencia.Descripcion;
                                if (lstIncidenciaDependencia[j].FechaEnvioDependencia.HasValue)
                                {
                                    this.dgvDependencias[2, k - 1].Value = lstIncidenciaDependencia[j].FechaEnvioDependencia.Value;
                                }
                                if (lstIncidenciaDependencia[j].FechaNotificacion.HasValue)
                                {
                                    this.dgvDependencias[3, k - 1].Value = lstIncidenciaDependencia[j].FechaNotificacion.Value;
                                }
                                this.dgvDependencias[4, k - 1].Value = lstIncidenciaDependencia[j].ClaveDependencia;
                            }
                        }
                    }
                }
                

            }          
        }


        /// <summary>
        /// Obtiene la lista de dependencias que se encuentran palomeadas en la lista check
        /// </summary>
        /// <returns></returns>
        private DependenciaList ObtenDependenciasEnLista()
        {
            DependenciaList lstDependencias = new DependenciaList();
            DependenciaList ListaTodasDependencias = DependenciaMapper.Instance().GetAll();
            int y;
            var myEnumerator;

            if (ListaTodasDependencias == null || ListaTodasDependencias.Count == 0)
            {
                return lstDependencias;
            }
            myEnumerator = this.cklDependencia.CheckedIndices.GetEnumerator();
            while (myEnumerator.MoveNext() != false)
            {
                y = (int)myEnumerator.Current;
                foreach (Dependencia objDependencia in ListaTodasDependencias)
                {
                    if (this.cklCorporacion.Items[y].ToString() == objDependencia.Descripcion)
                    {
                        lstDependencias.Add(objDependencia);
                    }
                }
            }

            return lstDependencias;
        }

        /// <summary>
        /// Obtiene la lista de IncidenciasDependencias que se encuentran en el grid
        /// </summary>
        /// <returns></returns>
        private IncidenciaDependenciaList ObtenIncidenciasDependenciasEnGrid()
        {
            IncidenciaDependenciaList lstIncidenciaDependencia = new IncidenciaDependenciaList();
            IncidenciaDependencia entIncidenciaDependencia;


            foreach(Dependencia entDependencia in ObtenDependenciasEnLista())
            {
                for (int i = 0; i < this.dgvDependencias.Rows.Count; i++)
                {
                    if (int.Parse(dgvDependencias[4, i].Value.ToString()) == entDependencia.Clave)
                    {
                        //La dependencia se encuentra en el grid
                        entIncidenciaDependencia = IncidenciaDependenciaMapper.Instance().GetOne(entDependencia.Clave, this._entIncidencia.Folio);

                        if (dgvDependencias[2, i].Value != null)
                        {
                            entIncidenciaDependencia.FechaEnvioDependencia = DateTime.Parse(dgvDependencias[2, i].Value.ToString());
                        }
                        if (dgvDependencias[3, i].Value != null)
                        {
                            entIncidenciaDependencia.FechaNotificacion  = DateTime.Parse(dgvDependencias[3, i].Value.ToString());
                        }
                        lstIncidenciaDependencia.Add(entIncidenciaDependencia);
                    }
                }
            }

            return lstIncidenciaDependencia;
        }

        private void RecuperaDatosEnIncidencia()
        {
            Boolean blnFechasEnvio = true;
            Boolean blnFechasNotificacion = true;

            if (this._entIncidencia != null)
            {

                if (ObtenDependenciasEnLista().Count > 0)
                {
                    //Es incidencia activa
                    this._entIncidencia.ClaveEstatus = 2;
                    IncidenciaDependenciaMapper.Instance().DeleteByIncidencia(this._entIncidencia.Folio);
                    //Se registran otra vez las dependencias
                    foreach (IncidenciaDependencia entIncidenciaDependencia in ObtenIncidenciasDependenciasEnGrid())
                    {
                        IncidenciaDependenciaMapper.Instance().Insert(entIncidenciaDependencia);
                        if (blnFechasEnvio)
                        {
                            blnFechasEnvio = entIncidenciaDependencia.FechaEnvioDependencia.HasValue;
                        }
                        if (blnFechasNotificacion)
                        {
                            blnFechasNotificacion = entIncidenciaDependencia.FechaNotificacion.HasValue;
                        }

                    }
                    if (blnFechasEnvio)
                    {
                        //Es incidencia pendiente
                        this._entIncidencia.ClaveEstatus = 3;
                    }
                    if (blnFechasNotificacion)
                    {
                        //Es incidencia cerrada
                        this._entIncidencia.ClaveEstatus = 4;
                    }
                    
                    
                }
                else
                {
                    //Es nueva incidencia
                    this._entIncidencia.ClaveEstatus = 1;
                }
                this._entIncidencia.NumeroOficio = this.txtNumeroOficio.Text;
                this._entIncidencia.AliasDelincuente = this.txtAlias.Text;
               
            }
        }
      


        private void chkFechaDocumento_CheckedChanged(object sender, EventArgs e)
        {
            this.dtmFechaDocumento.Enabled = !this.dtmFechaDocumento.Enabled;
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void dtmFechaDocumento_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

      

        private void txtNumeroOficio_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

      
        protected override void OnClosed(EventArgs e)
        {
            this.RecuperaDatosEnIncidencia();
            base.OnClosed(e);
        }

      
        private void dtmFechaDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtmFechaNotificacion.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

       
        private void txtAlias_Leave(object sender, EventArgs e)
        {
            if (!this._blnSeActivoClosed)
            {
                base.RecuperaDatosEnIncidencia();
                this.RecuperaDatosEnIncidencia();
                this.GuardaIncidencia();
            }
        }

        private void txtAlias_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtmFechaEnvioDependencia.Focus();
            }
            this.SAIFrmIncidenciaKeyUp(e);
        }

        

      
    }
}
