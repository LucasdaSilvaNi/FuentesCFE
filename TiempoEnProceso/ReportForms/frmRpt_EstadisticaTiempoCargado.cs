﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TiempoEnProcesoDL;
using TiempoEnProcesoHelper;
using TiempoEnProcesoBL;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.Misc;

namespace TiempoEnProceso.Forms
{
    public partial class frmRpt_EstadisticaTiempoCargado : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_EstadisticaTiempoCargado()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
            db.Database.CommandTimeout = Helper.TimeOut;
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Grabar":    // ButtonTool
                    if (Grabar())
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    break;

                case "Cancelar":    // ButtonTool
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;

            }

        }

        #region Metodos
        private bool ValidataControles()
        {
            LimpiaEspacios();

            if (ucOficce.Value != null &&
                ucOficce.SelectedRow == null)
            {
                MessageBox.Show("Selección de Oficina Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void LimpiaEspacios()
        {
        }

        public void CargarItem(string _oficina, string _reporte, string _descripcion)
        {
        }

        private void AsignaCampos()
        {
        }

        public void CargaCombos()
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

            var query = from emp in db.tbl_empleados
                        join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                        join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                        where emp.id_empleado == Helper.usuario
                        select ofi;

            tbloficinaBindingSource.DataSource = query.ToList<tbl_oficina>(); 

            periodoBindingSource.DataSource = (new PeriodoBL()).Listar();
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;

                DataSet dsData = new DataSet();
                string _reporte = string.Empty;

                if (upTipo.Value.ToString() == "1")
                {
                    List<rpt_estadistica_tiempo_cargado_historico_Result> lst = db.rpt_estadistica_tiempo_cargado_historico(Helper.Oficina, unePeriodo.Value.ToString()).ToList<rpt_estadistica_tiempo_cargado_historico_Result>();

                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                        return false;
                    }
                    dsData = Helper.ToDataSet<rpt_estadistica_tiempo_cargado_historico_Result>(lst);
                    _reporte = "rpt_estadistica_tiempo_cargado_historico";
                }
                else
                {
                    List<rpt_estadistica_tiempo_teams_Result> lst = db.rpt_estadistica_tiempo_teams(Helper.Oficina, unePeriodo.Value.ToString()).ToList<rpt_estadistica_tiempo_teams_Result>();

                    if (lst.Count == 0)
                    {
                        MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                        return false;
                    }
                    dsData = Helper.ToDataSet<rpt_estadistica_tiempo_teams_Result>(lst);
                    _reporte = "rpt_estadistica_tiempo_cargado_team";
                }

               
                dsData.Tables[0].TableName = "pwcia";

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("Oficina", Helper.Oficina);
                frm._parameters.Add("Periodo", unePeriodo.Value.ToString());

                frm._data = dsData;
                frm._reportName = _reporte+".rdlc";
                frm._showStatus = false;
                frm._exportButton = true;
                frm.Show();
                //Close();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Execute", "Error al Ejecutar", ex);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return true;
        }

        private void ConstruyeItem()
        {
        }

        private void EstableceHabilitacion()
        {
        }

        private void NuevoItem()
        {
        }

        private void SetEnableControls(bool Enable)
        {
            
        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            CargaCombos();
            upTipo.Value = "1";
            ucOficce.Value = Helper.Oficina;
            unePeriodo.Value = (Helper.OficinaActiva as tbl_oficina).periodo_proceso.Substring(3);
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                //DialogResult = System.Windows.Forms.DialogResult.OK;
                //Close();
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
                
        private void ultraPanel4_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void uceEstado_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ultraPanel3_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void upTipo_ValueChanged(object sender, EventArgs e)
        {
        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
        }

        private void ucOficce_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        
      
    }
}
