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
    public partial class frmGeneracionFactura : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);
        List<tbl_entes_solicitud> lst = new List<tbl_entes_solicitud>();
        List<decimal> lstFac = new List<decimal>();
        List<tbl_oficina> lstOf = new List<tbl_oficina>();

        public frmGeneracionFactura()
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
            IQueryable query = from emp in db.tbl_empleados
                        join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                        join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                        where emp.id_empleado == Helper.usuario
                        select ofi;

            tbloficinaBindingSource.DataSource = query.Cast<tbl_oficina>().ToList();

            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();

            ugData.DataSource = lst;
            ugData.DataBind();

            ucOficce.Value = Helper.Oficina;
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
                

                foreach (UltraGridRow ugr in ugData.Rows)
                {
                    if (Convert.ToBoolean( ugr.Cells["select"].Value ))
                    {
                        tbl_entes_solicitud item = ugr.ListObject as tbl_entes_solicitud;
                        tbl_entes_solicitud tbl = db.tbl_entes_solicitud.FirstOrDefault(d => d.id_solicitud == item.id_solicitud &&
                                                                                            d.linea == item.linea);
                        if (tbl != null)
                        {
                            Genero = true;
                            tbl.Estado = 1;
                            db.SaveChanges();

                            tbl_cuenta_corriente _tb = db.tbl_cuenta_corriente.FirstOrDefault(d => d.id_solicitud == item.id_solicitud);
                            if (_tb != null)
                                lstFac.Add(_tb.numero_documento);

                        }
                        /*Generacion de archivo*/
                        if (!string.IsNullOrEmpty(strUbicacion))
                            GeneraMagicPOS(ugr.Cells["id_solicitud"].Value.ToString(), strUbicacion);
                    }
                }

                /*if (Genero &&
                    string.IsNullOrEmpty(strUbicacion) &&
                    !string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).formato_facturas))
                    Imprimir();*/


                if (!Genero)
                {
                    MessageBox.Show("Debe seleccionar al menos una Solicitud");
                    return false;
                }

                lst.Clear();
                ugData.DataSource = lst;
                ugData.DataBind();
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
            frm._reportFileName = "Facturas";
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

        private void GeneraMagicPOS(string id_solicitud, string ubicacion)
        {
            if (!Directory.Exists(ubicacion))
                Directory.CreateDirectory(ubicacion);

            List<sp_Get_Data_MagicPOS_Result> lst = db.sp_Get_Data_MagicPOS(id_solicitud).ToList<sp_Get_Data_MagicPOS_Result>();
            
            if (lst.Count==0)
                return;

            sp_Get_Data_MagicPOS_Result item = lst[0];

            using (StreamWriter file =new StreamWriter(string.Format("{0}\\FAC{1}{2}.txt",ubicacion,item.id_servicio.Trim(),item.numero_documento)))
            {
                file.WriteLine(string.Format("jC{0}", item.id_entidad.PadLeft(2, '0')));
                file.WriteLine(string.Format("jR{0}",item.nacional_id.Trim()));
                file.WriteLine(string.Format("jS{0}",item.razon_social.Trim()));
                file.WriteLine(string.Format("jO:{0}",item.numero_documento));
                foreach(sp_Get_Data_MagicPOS_Result _det in lst)
                    file.WriteLine(string.Format("{2}{0}00001000{1}", Convert.ToInt32(_det.valor * 100).ToString().PadLeft(10, '0'), _det.concepto.Trim().Substring(0, _det.concepto.Trim().Length > 115 ? 115 : _det.concepto.Trim().Length - 1), _det.Exento.Value ? "!" : " "));

                file.WriteLine("101");
            }
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
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
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

            IQueryable query = from a in db.tbl_solicitud_facturas
                        join b in db.tbl_entes_solicitud on a.id_solicitud equals b.id_solicitud
                        where a.estado != 2 && b.Estado == 0 &&
                            a.id_oficina == Helper.Oficina &&
                            a.id_entidad == ucEntidad.Value.ToString() &&
                            b.saldo > 0
                        orderby a.id_solicitud descending
                        select b;

            lst = query.Cast<tbl_entes_solicitud>().ToList();

            if (Helper.Pais == "49")
            {
                foreach (var item in lst)
                {
                    var desc = db.tbl_det_Solicitud.Where(d => d.id_solicitud == item.id_solicitud).Sum(d => d.Descuento_linea) ?? 0;
                    item.saldo = item.saldo - desc;

                }
            }
            ugData.DataSource = lst;
            ugData.DataBind();
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

        private void ucEntidad_ValueChanged(object sender, EventArgs e)
        {
            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow != null)
            {
                lblFac.Text = (ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).correlativo_facturas;
            }
        }

        
      
    }
}
