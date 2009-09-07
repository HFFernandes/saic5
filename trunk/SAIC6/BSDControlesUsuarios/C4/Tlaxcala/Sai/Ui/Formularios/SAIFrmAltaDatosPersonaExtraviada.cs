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
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Entities;
using BSD.C4.Tlaxcala.Sai.Excepciones;
using BSD.C4.Tlaxcala.Sai.Dal.Rules.Mappers;

namespace BSD.C4.Tlaxcala.Sai.Ui.Formularios
{
    public partial class SAIFrmAltaDatosPersonaExtraviada : Form
    {


        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SAIFrmAltaDatosPersonaExtraviada()
        {
            InitializeComponent();
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Obtiene o Establece el/las persona(s) reportadas como extraviadas.
        /// </summary>
        public PersonaExtraviadaList ListaPersonas { get; set; }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Obtiene los datos de las personas capturadas en el grid.
        /// </summary>
        private void ObtenerDatosPersonas()
        {
            if(this.ListaPersonas==null)
            {
                this.ListaPersonas = new PersonaExtraviadaList();
            }
            PersonaExtraviada Persona;
            int intEdad;
            float fltEstatura;
            DateTime dtmFecha;
            foreach(DataGridViewRow row in this.dgvPersonaExtraviada.Rows)
            {
                Persona = new PersonaExtraviada();
                if (row.Cells[2].Value != null && !string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
                {
                    if (row.Cells[0].Value != null)
                    {
                        Persona = PersonaExtraviadaMapper.Instance().GetOne(Convert.ToInt32(row.Cells[0].Value));
                        
                    }
                    if (Persona == null) 
                    { Persona = new PersonaExtraviada(); }

                    //Nombre:
                    Persona.Nombre = row.Cells[2].Value != null ? row.Cells[2].Value.ToString().ToUpper() : string.Empty;
                    //Edad:
                    if (row.Cells[3].Value != null)
                    {

                        try
                        {
                            intEdad = Convert.ToInt32(row.Cells[3].Value);
                            if (intEdad <= 0)
                            {
                                MessageBox.Show("La edad no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            Persona.Edad = intEdad;
                        }
                        catch
                        {
                            MessageBox.Show("La edad no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    //Sexo:
                    if (row.Cells[4].Value != null)
                    {
                        Persona.Sexo = row.Cells[4].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Debe especificar el sexo de la persona, F (Femenino) y M (Masculino)", "Especifique el sexo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //Estatura:
                    if (row.Cells[5].Value != null)
                    {
                        try
                        {
                            fltEstatura = float.Parse(row.Cells[5].Value.ToString());
                            if (fltEstatura <= 0)
                            {
                                dgvPersonaExtraviada.CurrentCell.Value = string.Empty;
                                dgvPersonaExtraviada.Refresh();
                                //e.Cancel = true;
                                throw new SAIExcepcion("La estatura no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0 con decimales", this);
                            }
                            Persona.Estatura = fltEstatura;
                        }
                        catch
                        {
                            throw new SAIExcepcion("La estatura no se encuentra en el formato correcto, debe de ser un valor numérico mayor a 0 con decimales", this);
                        }
                    }
                    //Parentesco: 
                    Persona.Parentesco = row.Cells[6].Value != null ? row.Cells[6].Value.ToString().ToUpper() : string.Empty;
                    //Fecha de extravio:
                    if (row.Cells[7].Value != null)
                    {
                        try
                        {
                            dtmFecha = DateTime.Parse(row.Cells[7].Value.ToString());
                            if (dtmFecha > DateTime.Today)
                            {
                                throw new SAIExcepcion("La fecha de extravío no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
                            }
                            Persona.FechaExtravio = dtmFecha;
                        }
                        catch
                        {
                            throw new SAIExcepcion("La fecha de extravío no se encuentra en el formato correcto, debe de ser una fecha menor o igual al dia actual", this);
                        }
                    }
                    //Tez :
                    Persona.Tez = row.Cells[8].Value != null ? row.Cells[8].Value.ToString().ToUpper() : string.Empty;
                    //Tipo cabello :
                    Persona.TipoCabello = row.Cells[9].Value != null ? row.Cells[9].Value.ToString().ToUpper() : string.Empty;
                    //Color cabello :
                    Persona.ColorCabello = row.Cells[10].Value != null ? row.Cells[10].Value.ToString().ToUpper() : string.Empty;
                    //Largo de cabello :
                    Persona.LargoCabello = row.Cells[11].Value != null ? row.Cells[11].Value.ToString().ToUpper() : string.Empty;
                    //Frente : 
                    Persona.Frente = row.Cells[12].Value != null ? row.Cells[12].Value.ToString().ToUpper() : string.Empty;
                    //Cejas :
                    Persona.Cejas = row.Cells[13].Value != null ? row.Cells[13].Value.ToString().ToUpper() : string.Empty;
                    //Color de ojos :
                    Persona.OjosColor = row.Cells[14].Value != null ? row.Cells[14].Value.ToString().ToUpper() : string.Empty;
                    //Forma de ojos
                    Persona.OjosForma = row.Cells[15].Value != null ? row.Cells[15].Value.ToString().ToUpper() : string.Empty;
                    //Forma de nariz
                    Persona.NarizForma= row.Cells[16].Value != null ? row.Cells[16].Value.ToString().ToUpper() : string.Empty;
                    //Tamaño de boca.
                    Persona.BocaTamaño=row.Cells[17].Value != null ? row.Cells[17].Value.ToString().ToUpper() : string.Empty;
                    //Labios :
                    Persona.Labios = row.Cells[18].Value != null ? row.Cells[18].Value.ToString().ToUpper() : string.Empty;
                    //Vestimenta :
                    Persona.Vestimenta = row.Cells[19].Value != null ? row.Cells[19].Value.ToString().ToUpper() : string.Empty;
                    //Destino :
                    Persona.Destino = row.Cells[20].Value != null ? row.Cells[20].Value.ToString().ToUpper() : string.Empty;
                    //Caracteristicas:
                    Persona.Caracteristicas = row.Cells[21].Value != null ? row.Cells[21].Value.ToString().ToUpper() : string.Empty;

                    //Agregamos la persona a la lista:
                    if (ListaPersonas.Contains(Persona))
                    {
                        this.ListaPersonas.Replace(Persona);
                    }
                    else
                    {
                        this.ListaPersonas.Add(Persona);
                    }
                    

                }
                
            }
        }

        private void MostrarDatosPersonas()
        {
            if(this.ListaPersonas!=null)
            try
            {
                this.dgvPersonaExtraviada.Rows.Clear();
                int count = 1;
                foreach(PersonaExtraviada persona in  this.ListaPersonas)
                {
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[0].Value = persona.Clave;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[1].Value = persona.Folio;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[2].Value = persona.Nombre;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[3].Value = persona.Edad;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[4].Value = persona.Sexo;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[5].Value = persona.Estatura.Value.ToString("N2");
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[6].Value = persona.Parentesco;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[7].Value = persona.FechaExtravio.ToShortDateString();
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[8].Value = persona.Tez;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[9].Value = persona.TipoCabello;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[10].Value = persona.ColorCabello;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[11].Value = persona.LargoCabello;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[12].Value = persona.Frente;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[13].Value = persona.Cejas;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[14].Value = persona.OjosColor;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[15].Value = persona.OjosForma;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[16].Value = persona.NarizForma;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[17].Value = persona.BocaTamaño;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[18].Value = persona.Labios;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[19].Value = persona.Vestimenta;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[20].Value = persona.Destino;
                    this.dgvPersonaExtraviada.Rows[dgvPersonaExtraviada.RowCount - count].Cells[21].Value = persona.Caracteristicas;
                    this.dgvPersonaExtraviada.Rows.Add(1);
                    count++;
                }
                //For para quitar las filas vacias.
                for (int i = 0; i < count; i++)
                {
                    if ((dgvPersonaExtraviada.RowCount - 1) >= i)
                        if (this.dgvPersonaExtraviada.Rows[i].Cells[2].Value == null)
                        {
                            this.dgvPersonaExtraviada.Rows.RemoveAt(i);
                            i--;
                        }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al mostrar información de personas : "+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        #endregion

        #region MANEJADORES DE EVENTOS.

        private void SAIFrmAltaDatosPersonaExtraviada_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;

            }
        }

        private void dgvPersonaExtraviada_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;

            }
        }

        private void SAIFrmAltaDatosPersonaExtraviada_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                try
                {
                    this.ObtenerDatosPersonas();
                }
                catch (System.Exception ex)
                {
                    throw new SAIExcepcion(ex.Message + " " + ex.StackTrace, this);
                }
            }
            catch (SAIExcepcion) { }
        }

        private void SAIFrmAltaDatosPersonaExtraviada_Load(object sender, EventArgs e)
        {
            this.MostrarDatosPersonas();
        }

        #endregion

       

        
    }
}
