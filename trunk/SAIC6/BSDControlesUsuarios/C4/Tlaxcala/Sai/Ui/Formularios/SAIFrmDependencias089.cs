using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mappers = BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;
using Entidades = BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using Objetos = BSD.C4.Tlaxcala.Sai.Dal.Rules.Objects;
using BSD.C4.Tlaxcala.Sai.Excepciones;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmDependencias089 : SAIFrmBase
    {
        protected int _iFolio;

        public SAIFrmDependencias089()
        {
            InitializeComponent();
        }

        public SAIFrmDependencias089(int iFolio)
        {
            this.InitializeComponent();
            _iFolio = iFolio;
        }

        private void SAIFrmDependencias089_Load(object sender, EventArgs e)
        {
            this.LlenarDependencias();
        }

        private void LlenarDependencias()
        {
            try
            {
                try
                {
                    Entidades.DependenciaList lstDependencia = Mappers.DependenciaMapper.Instance().GetAll();
                    foreach(Entidades.Dependencia dependencia in lstDependencia)
                    {
                        this.chklstDependencias.Items.Add(dependencia.Descripcion);
                    }
                    this.chklstDependencias.CheckOnClick = true;
                    lstDependencia = null;
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
        }

        private void chklstDependencias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    throw new SAIExcepcion(ex.Message);
                }
            }
            catch (SAIExcepcion)
            { }
        }

        private void LlenarIncidenciadependencia(int iFolio)
        {
            try
            {
                try
                {
                    this.gvDependencias.DataSource = Mappers.IncidenciaDependenciaMapper.Instance().GetByIncidencia(iFolio);
                }
                catch (Exception ex)
                { throw new SAIExcepcion(ex.Message); }
            }
            catch (SAIExcepcion)
            { }
        }




    }
}
