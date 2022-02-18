using System;
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
using System.IO;

namespace TiempoEnProceso.Forms
{
    public partial class frmImpresionFactura : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);
        List<tbl_cuenta_corriente> lst = new List<tbl_cuenta_corriente>();
        List<decimal> lstFac = new List<decimal>();
        List<tbl_oficina> lstOf = new List<tbl_oficina>();
        List<tbl_clientes> lstCl = new List<tbl_clientes>();

        public frmImpresionFactura()
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

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).ubicacion_factura) &&
                string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).formato_facturas))
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            lstOf = db.tbl_oficina.ToList();
            lstCl = db.tbl_clientes.ToList();
            IQueryable query = from emp in db.tbl_empleados
                        join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                        join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                        where emp.id_empleado == Helper.usuario
                        select ofi;

            tbloficinaBindingSource.DataSource = query.Cast<tbl_oficina>().ToList(); 

            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar(true).OrderBy(d=> d.id_entidad);

            ugData.DataSource = lst;
            ugData.DataBind();

            ucOficce.Value = Helper.Oficina;
            ucTipoSolicitud.DataSource = db.sp_lista_tipo_FElectronicaGT().ToList();
            ucTipoSolicitud.Value = "FAC            ";

            periodoBindingSource.DataSource = (new PeriodoBL()).Listar();
        }


        private bool Grabar()
        {
            ugData.PerformAction(UltraGridAction.CommitRow);

            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                string strUbicacion = (ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).ubicacion_factura;
                bool Genero = false;
                lstFac = new List<decimal>();

                foreach (UltraGridRow ugr in ugData.Rows)
                {
                    if (Convert.ToBoolean( ugr.Cells["select"].Value ))
                    {
                        lstFac.Add(Convert.ToDecimal(ugr.Cells["numero_documento"].Value));
                        Genero = true;
                    }
                }

                if (Genero)
                {
                    
                        ImprimirGT();
                    
                }


                if (!Genero)
                {
                    MessageBox.Show("Debe seleccionar al menos una Factura");
                    return false;
                }

                ubConsultar_Click(null, null);

                /*lst.Clear();
                ugData.DataSource = lst;
                ugData.DataBind();*/
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

        private void ImprimirGT()
        {
            try
            {
                string _entidad = ucEntidad.Value.ToString();
                string _tipo = ucTipoSolicitud.Value.ToString();

                tbl_entidad_legal tbl_Entidad = ucEntidad.SelectedRow.ListObject as tbl_entidad_legal;
                if (string.IsNullOrEmpty(tbl_Entidad.Formato_FEL))
                {
                    Helper.ShowError("Imprimir", "Entidad no tiene asignado Formato FEL", null);
                    return;
                }

                foreach (decimal _factura in lstFac)
                {
                    List<rpt_imprime_factura_Net_New_Result> lst = db.rpt_imprime_factura_Net_New(_entidad, _factura.ToString(), Helper.Oficina, _tipo).ToList();
                    if (lst.Count != 0)
                    {

                        DataSet dsData = lst.ToDataSet();
                        dsData.Tables[0].TableName = "DataSet1";
                        
                        /*if (!string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).origen_datos_factura))
                            dsData.Tables[0].TableName = string.Format("{0};1", (ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).origen_datos_factura);*/

                        frmViewReport frm = new frmViewReport
                        {
                            _data = dsData,
                            _reportName = $"{tbl_Entidad.Formato_FEL.Trim()}.rdlc",
                            _showStatus = false,
                            _exportButton = true
                        };
                        frm._parameters.Add("entidad", _entidad);
                        frm._parameters.Add("facturas", _factura.ToString());
                        frm._parameters.Add("id_oficina", Helper.Oficina);
                        frm._parameters.Add("tipo_documento", _tipo.Trim());

                        frm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError("Execute", "Error al Ejecutar", ex);
            }
        }

        /*private void Imprimir()
        {
            string _entidad = ucEntidad.Value.ToString();
            string _factura = string.Empty;
            lstFac.ForEach(d => _factura = _factura + "," + d.ToString());
            List<rpt_imprime_factura_Net_New_Result> lst = db.rpt_imprime_factura_Net_New(_entidad, _factura.Substring(1), Helper.Oficina).ToList<rpt_imprime_factura_Net_New_Result>();
             if (lst.Count == 0)
            {
                MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                return;
            }
           
            DataSet dsData = Helper.ToDataSet<rpt_imprime_factura_Net_New_Result>(lst);
            dsData.Tables[0].TableName = "rpt_imprime_factura_Net;1";
            if (!string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).origen_datos_factura))
                dsData.Tables[0].TableName = string.Format("{0};1", (ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).origen_datos_factura);

            frmViewReportC frm = new frmViewReportC();
            frm._data = dsData;
            frm._exportFormat = CrystalDecisions.Shared.ViewerExportFormats.PdfFormat;
            frm._exportButton = false;
            frm._groupButton = false;
            frm._reportName = (ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).formato_facturas.Trim();
            frm._reportFileName = string.Format("Facturas");
            frm._parameters.Add("id_oficina", Helper.Oficina);
            frm._parameters.Add("entidad", _entidad);
            frm._parameters.Add("numero", 1202);
            frm._parameters.Add("numero_final", 1202);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MessageBox.Show("¿Las facturas se imprimieron correctamente?", Helper.NombreAplicacion, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    db.sp_MarcaImpresaFactura(_entidad, _factura.Substring(1), Helper.Oficina);
            }            

        }*/

        

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

            ucPeriodo.Value = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                //Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
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

        private void ucEntidad_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEntidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEntidad, true, true, true, true);
        }

        private void ucEntidad_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Razon_social"].Value.ToString().Trim());
        }

        private void upTipo_ValueChanged(object sender, EventArgs e)
        {
        }


        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            if (e.Row.Cells["select"].Value == null ||
                e.Row.Cells["select"].Value == DBNull.Value)
                e.Row.Cells["select"].Value = false;

            tbl_oficina _oficina = ucOficce.SelectedRow.ListObject as tbl_oficina;
            string _cliente = e.Row.Cells["id_cliente"].Value.ToString();
            tbl_clientes _cl = lstCl.FirstOrDefault(d => d.id_cliente == _cliente && d.id_pais == _oficina.id_pais);
            if (_cl != null)
                e.Row.Cells["cliente"].Value = _cl.Razon_Social;
        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = lstOf.FirstOrDefault(d => d.id_oficina == _oficina);

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
        }

        private void ubConsultar_Click(object sender, EventArgs e)
        {
            if (ucEntidad.Value == null)
            {
                MessageBox.Show("Debe seleccionar una Entidad Valida");
                return ;
            }

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Debe seleccionar una Entidad Valida");
                return;
            }
            if (ucTipoSolicitud.Value != null &&
                ucTipoSolicitud.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un Tipo Valido");
                return;
            }
            string _tipo = ucTipoSolicitud.Value.ToString();
            try
            {
                Cursor = Cursors.WaitCursor;
                string id_periodo = ucPeriodo.Value.ToString();

                IQueryable query = from a in db.tbl_cuenta_corriente
                                   where a.flag_impreso == 0 &&
                                       a.id_oficina == Helper.Oficina &&
                                       a.tipo_documento == _tipo &&
                                       a.id_entidad == ucEntidad.Value.ToString() &&
                                       a.periodo_tep == id_periodo
                                       orderby a.numero_documento descending
                                   select a;

                lst = query.Cast<tbl_cuenta_corriente>().ToList();
                ugData.DataSource = lst;
                ugData.DataBind();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Consultar", "Error", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ugData_ClickCellButton(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "edit")
            {
                decimal no_solicitud = Convert.ToDecimal(e.Cell.Row.Cells["id_solicitud"].Value);
                using (frmSolicitudFactura frm = new frmSolicitudFactura())
                {
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.EdicionLimitada = true;
                    frm.CargarItem(no_solicitud);
                    frm.ShowDialog();
                }
            }
        }
        private void ucTipoSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucTipoSolicitud, true, true, true, true);
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }
    }
}
