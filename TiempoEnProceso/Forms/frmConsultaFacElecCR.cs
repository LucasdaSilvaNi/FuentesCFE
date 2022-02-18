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
using System.Xml;
using System.Xml.Linq;

namespace TiempoEnProceso.Forms
{
    public partial class frmConsultaFacElecCR : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);
        List<tbl_cuenta_corriente> lst = new List<tbl_cuenta_corriente>();
        List<tbl_clientes> lstClientes = new List<tbl_clientes>();

        public frmConsultaFacElecCR()
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
            IQueryable query = from emp in db.tbl_empleados
                        join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                        join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                        where emp.id_empleado == Helper.usuario
                        select ofi;

            tbloficinaBindingSource.DataSource = query.Cast<tbl_oficina>().ToList(); 

            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar(true);

            IQueryable qry = db.tbl_clientes.Where(d => d.id_pais == Helper.Pais);
            lstClientes = qry.Cast<tbl_clientes>().ToList();

            ucTipoSolicitud.DataSource = db.sp_lista_tipo_FElectronicaCR().ToList();

            ugData.DataSource = lst;
            ugData.DataBind();

            ucOficce.Value = Helper.Oficina;
            ucTipoSolicitud.Value = "FAC            ";
        }


        private bool Grabar()
        {
            ugData.PerformAction(UltraGridAction.CommitRow);

            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                bool Genero = false;

                foreach (UltraGridRow ugr in ugData.Rows)
                {
                    if (Convert.ToBoolean( ugr.Cells["select"].Value ))
                    {
                        ugr.Cells["resConsulta"].Value = string.Empty;
                        tbl_cuenta_corriente item = ugr.ListObject as tbl_cuenta_corriente;
                        Genero = true;
                        ugr.Cells["resConsulta"].Value = GeneraArchivo("",item.tipo_documento,item.numero_documento, item);
                        ugr.Cells["select"].Value = false;
                    }
                }

                if (!Genero)
                {
                    MessageBox.Show("Debe seleccionar al menos una Factura");
                    return false;
                }
                
                //Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Proceso", "Documentos Electrónicos consultadas satisfactoriamente");
                

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

        private void Imprimir()
        {
            /*FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Carpeta destino";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = fbd.SelectedPath;
            */
            

            //}
        }

        private string GeneraArchivo(string path, string tipo, decimal documento, tbl_cuenta_corriente item)
        {
            /*consulta*/
            
            string sCliente = "<InformacionCliente CodigoEntidad=\"PWC\"></InformacionCliente>";
            //string docto = string.Format("<acClaveDocumento>{0}</acClaveDocumento>", "50615021800310401669300100001010000000004177384910");
            //string docto = string.Format("{0}", "50615021800310401669300100001010000000004177384910");
            string docto = string.Format("{0}", item.clave_electronica);
            string sMensaje = string.Empty, sRespFiscal = string.Empty ;
            ServicioFElectCR.wesDocumentosFiscalesSoapClient cl = new ServicioFElectCR.wesDocumentosFiscalesSoapClient();
            bool bProc = cl.ConsultaRespuestaHaciendaDocumentoEmision(sCliente, docto, ref sRespFiscal, ref sMensaje);

            if (!bProc)
                return sMensaje;

            return "Recibido";
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
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            Helper.SetUltraComboWidth(this);

            EstableceHabilitacion();
            CargaCombos();
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            udteFechaDesde.Value = dt;
            udteFechaHasta.Value = dt.AddMonths(1).AddDays(-1);
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

            tbl_oficina _oficina = ucOficce.SelectedRow.ListObject as tbl_oficina;
            string _cliente = e.Row.Cells["id_cliente"].Value.ToString();
            tbl_clientes _cl = lstClientes.FirstOrDefault(d => d.id_cliente == _cliente && d.id_pais == _oficina.id_pais);
            if (_cl != null)
                e.Row.Cells["cliente"].Value = _cl.Razon_Social;

            e.Row.Cells["resConsulta"].Value = string.Empty;
            /*if (e.Row.Cells["select"].Value == null ||
    e.Row.Cells["select"].Value == DBNull.Value)*/
            e.Row.Cells["select"].Value = false;
        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);

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

            try
            {
                Cursor = Cursors.WaitCursor;
                string _tipo = ucTipoSolicitud.Value.ToString();
                DateTime dtFrom = Convert.ToDateTime(udteFechaDesde.Value);
                DateTime dtTo = Convert.ToDateTime(udteFechaHasta.Value);
                IQueryable query = from a in db.tbl_cuenta_corriente
                                   where
                                       a.id_oficina == Helper.Oficina &&
                                       a.tipo_documento == _tipo &&
                                       !string.IsNullOrEmpty(a.numero_documento_fiscal_electronico) &&
                                       a.fecha >= dtFrom && a.fecha <= dtTo &&
                                       a.id_entidad == ucEntidad.Value.ToString()
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

        private void udteFechaDesde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(udteFechaDesde, true, true, true, true);

        }

        private void udteFechaHasta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(udteFechaHasta, true, true, true, true);
        }
    }
}
