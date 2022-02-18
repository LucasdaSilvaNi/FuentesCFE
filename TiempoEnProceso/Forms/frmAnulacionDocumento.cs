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
using TiempoEnProcesoEN;
using System.Xml.Linq;
using System.Xml;

namespace TiempoEnProceso.Forms
{
    public partial class frmAnulacionDocumento : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);
        List<AnulacionDoctoEN> lst = new List<AnulacionDoctoEN>();
        private bool esGT = Helper.EsGt;

        public frmAnulacionDocumento()
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

            if (!uvValidador.Validate("requeAnu", false, true).IsValid)
                return false;

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string _periodo = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
            DateTime dt = (new PeriodoBL()).PorId(_periodo).AddMonths(-1);

            DateTime dtSel = Convert.ToDateTime(udteFechaAnulacion.Value);

            if (dtSel > dt.AddMonths(1).AddDays(-1) ||
                dtSel < dt)
            {
                MessageBox.Show("Fecha transaccion  esta fuera de rango", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return MessageBox.Show("Esta seguro de Anular la Solicitud", Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes;
        }

        private void LimpiaEspacios()
        {
            if (uteAutorizo.Value != null)
                uteAutorizo.Value = uteAutorizo.Value.ToString().Trim();

            if (uteMotivo.Value != null)
                uteMotivo.Value = uteMotivo.Value.ToString().Trim();
        }

        public void CargarItem(string _oficina, string _reporte, string _descripcion)
        {
        }

        private void AsignaCampos()
        {
        }

        public void CargaCombos()
        {
            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();

            ugData.DataSource = lst;
            ugData.DataBind();
        }


        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                AnulacionDoctoEN _anu = ugData.ActiveRow.ListObject as AnulacionDoctoEN;
                tbl_cuenta_corriente _tbl = db.tbl_cuenta_corriente.FirstOrDefault(d => d.id_oficina == _anu.id_oficina &&
                                                                                        d.id_entidad == _anu.id_entidad &&
                                                                                        d.tipo_documento == _anu.tipo_docto &&
                                                                                        d.numero_documento == _anu.documento);
                if (_tbl != null)
                {
                    _tbl.estado = 2;
                    //db.SaveChanges();

                    tbl_anulacion_facturas _anulacion = new tbl_anulacion_facturas()
                    {
                        id_oficina = _tbl.id_oficina,
                        id_entidad = _tbl.id_entidad,
                        tipo_documento = _tbl.tipo_documento,
                        numero_documento = _tbl.numero_documento,
                        fecha_anulacion = Convert.ToDateTime(udteFechaAnulacion.Value),
                        fecha_transaccion = DateTime.Now,
                        autorizo_anulacion = uteAutorizo.Value.ToString(),
                        motivo_anulacion = uteMotivo.Value.ToString(),
                        usuario = (Helper.UsuarioActivo as tbl_empleados).Nombres.Substring(0,10),
                        id_cliente = _tbl.id_cliente,
                        id_pais = (Helper.OficinaActiva as tbl_oficina).id_pais,

                        preliminar = _tbl.factura_preliminar,
                        definitiva = _tbl.factura_definitiva,
                        saldo = _tbl.saldo,
                        saldo_impuesto = _tbl.saldo_impuesto,
                        id_job = _tbl.id_job
                    };

                    db.tbl_anulacion_facturas.Add(_anulacion);

                    if (esGT && 
                        ucTipoSolicitud.Value.ToString()!= "COBRANZA" &&
                        uteDoctoElect.Value!=null &&
                        !string.IsNullOrEmpty( uteDoctoElect.Value.ToString())) //anulacion para GT
                    { 
                        sp_text_felectronica_GT_Result lst = db.sp_text_felectronica_GT(_tbl.id_oficina, _tbl.id_entidad, _tbl.tipo_documento,
                                    _tbl.numero_documento).FirstOrDefault();

                        string sPath = Application.ExecutablePath.ToUpper().Replace("TIEMPOENPROCESO.EXE", "");

                        XNamespace myPrefix = "http://www.sat.gob.gt/dte/fel/0.1.0";
                        DateTime dtFecha = _tbl.tipo_documento.Trim() == "FAC" ? lst.Fecha_Emision_Documento_Original.Value : lst.Fecha_Emision_Documento_OriginalNC;

                        XDocument doc = new XDocument(
                            new XDeclaration("1.0", "UTF-8", "no"),
                            new XElement(myPrefix + "GTAnulacionDocumento",
                                new XAttribute("Version", "0.1"),
                                new XAttribute(XNamespace.Xmlns + "xd", "http://www.we.org/2000/09/xmldsig#"),
                                new XAttribute(XNamespace.Xmlns + "ns", "http://www.sat.gob.gt/dte/fel/0.1.0"),
                                new XElement(myPrefix + "SAT",
                                    new XElement(myPrefix + "AnulacionDTE",
                                        new XAttribute("ID", "DatosCertificados"),
                                        new XElement(myPrefix+"DatosGenerales",
                                            new XAttribute("ID", "DatosAnulacion"),
                                            new XAttribute("NumeroDocumentoAAnular", uteDoctoElect.Value.ToString()),
                                            new XAttribute("NITEmisor", lst.nit.Trim()),
                                            new XAttribute("IDReceptor", lst.Nit_Receptor.Trim()),
                                            new XAttribute("FechaEmisionDocumentoAnular",  dtFecha.ToString("yyyy-MM-ddTHH:mm:ss-06:00")),
                                            new XAttribute("FechaHoraAnulacion", DateTime.Now.AddMinutes(-3).ToString("yyyy-MM-ddTHH:mm:ss-06:00")),
                                            new XAttribute("MotivoAnulacion", uteMotivo.Value.ToString())
                                        )
                                    )
                                )
                            )
                        );
                        string docto = Guid.NewGuid().ToString().ToUpper();// string.Format("{0}-{1}-{2}", ucEntidad.Value.ToString(), tipo.Trim(), documento);
                        doc.Save(string.Format("{0}{1}.xml", sPath, docto), SaveOptions.DisableFormatting);
                        string salida = doc.Root.ToString().Replace("\n", "").Replace("\r", "").Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "").Replace("reemplazarSchema=\"aqui\"", "xsi:schemaLocation=\"http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0 GT_Complemento_Referencia_Nota-0.1.0.xsd\"");

                        /*XmlDocument xml_fel = FirmaDocumento.FirmarDocumento(sPath + Helper.GetConfigValue("FEL_F"), Helper.GetConfigValue("FEL_C", true),
                           "DatosAnulacion", string.Format("{0}{1}.xml", sPath, docto));
                           
                        string sLinea = xml_fel.OuterXml.Replace("\n", "").Replace("\r", "").Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");
                        */
                        tbl_entidad_legal entidad = ucEntidad.SelectedRow.ListObject as tbl_entidad_legal;

                        tbl_empleados usuario = Helper.UsuarioActivo as tbl_empleados;
                        DateTime FechaVenc = DateTime.Now.AddYears(-1);
                        tbl_empleado_entidad_legal entidadFEL = db.tbl_empleado_entidad_legal.FirstOrDefault(d => d.Id_Empleado == Helper.usuario && d.Id_Entidad == entidad.id_entidad && d.Id_Oficina == entidad.id_oficina);
                        if (entidadFEL == null)
                        {
                            entidadFEL = new tbl_empleado_entidad_legal()
                            {
                                Id_Empleado = Helper.usuario,
                                Id_Entidad = entidad.id_entidad,
                                Id_Oficina = Helper.Oficina
                            };
                            db.tbl_empleado_entidad_legal.Add(entidadFEL);
                            db.SaveChanges();
                        }
                        if (entidadFEL.Fecha_Hora_Expira_Token != null)
                            FechaVenc = entidadFEL.Fecha_Hora_Expira_Token.Value;

                        string data = string.Empty;
                        string url_action = string.Empty;

                        /*envio*/

                        if (FechaVenc.AddMinutes(-2) < DateTime.Now)
                        {
                            /*TOKEN EXPIRADO, solicitar nuevo*/
                            data = string.Format(
                                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SolicitaTokenRequest><usuario>{0}</usuario><apikey>{1}</apikey></SolicitaTokenRequest>",
                                    entidad.NIT.Trim(), entidad.Clave_Api);
                            url_action = string.Format("{0}{1}", Helper.GetConfigValue("FEL_GT"),
                                Helper.GetConfigValue("GetToken"));

                            MessageBox.Show($"Direccion Obtencion Token: {url_action}");
                            SolicitaTokenResponse response =
                                Helper.SendToFEL<SolicitaTokenResponse>(url_action, data, string.Empty);

                            if (response.tipo_respuesta == "1")
                            {
                                Helper.ShowError("Obtener Token", response.errores, null, MessageBoxButtons.OK,
                                    "Generación Factura Electrónica");
                                return false;
                            }

                            entidadFEL.FE_Token = response.token;
                            entidadFEL.Fecha_Hora_Expira_Token = response.vigencia;

                            db.SaveChanges();
                        }

                        DateTime dtEnvio = DateTime.Now;

                        data = string.Format(
                            "<FirmaDocumentoRequest id=\"{0}\"><xml_dte><![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>{1}]]></xml_dte></FirmaDocumentoRequest>",
                                docto, salida);
                        url_action = string.Format("{0}{1}", Helper.GetConfigValue("FEL_Firma"),
                            Helper.GetConfigValue("solicitaFirma"));
                        FirmaDocumentoResponse responseFirmaDocto = Helper.SendToFEL<FirmaDocumentoResponse>(url_action, data,
                            entidadFEL.FE_Token);

                        bool bProc = responseFirmaDocto.tipo_respuesta == "0";
                        if (bProc)
                        {
                            data = string.Format(
                            "<?xml version=\"1.0\" encoding=\"UTF-8\"?><AnulaDocumentoXMLRequest id=\"{0}\"><xml_dte><![CDATA[{1}]]></xml_dte></AnulaDocumentoXMLRequest>",
                            docto, responseFirmaDocto.xml_dte);
                            url_action = string.Format("{0}{1}", Helper.GetConfigValue("FEL_GT"),
                                Helper.GetConfigValue("anularDocto"));
                            AnulaDocumentoXMLResponse responseDocto = Helper.SendToFEL<AnulaDocumentoXMLResponse>(url_action, data,
                                entidadFEL.FE_Token);
                             bProc = responseDocto.tipo_respuesta == "0";
                            tbl_Log_Documento_Electronico _log = new tbl_Log_Documento_Electronico
                            {
                                detalle_envio = data,
                                docto_electronico = responseDocto.xml_dte,
                                Fecha_Hora_Envio = dtEnvio,
                                id_oficina = Helper.Oficina,
                                numero_documento = Convert.ToDecimal(uneDocumento.Value),
                                respuesta_fiscal = responseDocto.errores,
                                resultado_envio = responseDocto.uuid,
                                tipo_documento = ucTipoSolicitud.Value.ToString(),
                                id_entidad = ucEntidad.Value.ToString(),
                                Anulado = true
                            };

                            db.tbl_Log_Documento_Electronico.Add(_log);
                            //db.SaveChanges();

                            if (!bProc)
                                throw new Exception(responseDocto.errores);
                        }
                    }

                    db.SaveChanges();
                }

                lst.Remove(_anu);
                ugData.DataSource = lst;
                ugData.DataBind();

                

                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Anulación de Documento Satisfactoria");

                NuevoItem();
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
            uteTipo.Value = null;
            uteAutorizo.Value = null;
            uteCliente.Value = null;
            uteMotivo.Value = null;
            uneDocumento.Value = null;
            uneTotalSol.Value = null;
            udteFecha.Value = null;
        }

        private void SetEnableControls(bool Enable)
        {
            
        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            Helper.SetUltraComboWidth(this);
            CargaCombos();
            string _periodo = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
            udteFechaAnulacion.Value = DateTime.Now.Date;//(new PeriodoBL()).PorId(_periodo);
            uteDoctoElect.Visible = esGT;
            ultraLabel9.Visible = esGT;
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {

            Grabar();
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
        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void ubConsultar_Click(object sender, EventArgs e)
        {
            if (!uvValidador.Validate("required", false, true).IsValid)
                return;

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

            if (ucTipoSolicitud.Value == null)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Documento Valido");
                return;
            }

            tbl_oficina _tbl = Helper.OficinaActiva as tbl_oficina;

            if (ucTipoSolicitud.Value.ToString() == "FAC")
            {
                var query = from a in db.tbl_cuenta_corriente
                            join c in db.tbl_clientes on a.id_cliente equals c.id_cliente
                            where c.id_pais == _tbl.id_pais &&
                                  a.id_oficina == _tbl.id_oficina &&
                                  a.estado == 1 && a.tipo_documento == ucTipoSolicitud.Value.ToString() &&
                                  a.id_entidad == ucEntidad.Value.ToString() &&
                                  a.periodo_tep == _tbl.periodo_proceso && (a.factura_definitiva??0)== 0 && 
                                  (a.anticipo_aplicar??0)==0 &&
                                  (a.saldo ?? 0) + (a.saldo_impuesto ?? 0) == a.valor_total
                            select new AnulacionDoctoEN()
                            {
                                id_entidad = a.id_entidad,
                                tipo_docto = a.tipo_documento,
                                tipo_docto_descripcion = a.tipo_documento == "FAC" ? "FACTURA" : (a.tipo_documento == "COBRANZA" ? "COBRANZA" : "NOTA CREDITO"),
                                id_oficina = a.id_oficina,
                                documento = a.numero_documento,
                                razon_social = c.Razon_Social,
                                total = a.valor_total ?? 0,
                                Fecha = a.fecha.Value,
                                documento_electronico=a.clave_electronica
                            };

                lst = query.ToList<AnulacionDoctoEN>();
            }
            else
            {

                var queryA = from a in db.tbl_detalle_cobros_anulaciones
                             join b in db.tbl_anticipo_preliminar on
                                new { id_oficina = a.id_oficina, id_entidad = a.id_entidad, tipo_documento = a.tipo_documento, numero_documento = a.numero_documento } equals
                                new { id_oficina = b.id_oficina, id_entidad = b.id_entidad, tipo_documento = b.tipo_documento, numero_documento = b.numero_documento }
                             where b.anticipo != 0
                             select new { a.id_oficina, a.id_entidad, a.tipo_documento, a.numero_documento };

                var query = from a in db.tbl_cuenta_corriente
                            join c in db.tbl_clientes on a.id_cliente equals c.id_cliente
                            where c.id_pais == _tbl.id_pais &&
                                  a.id_oficina == _tbl.id_oficina &&
                                  a.estado == 1 && a.tipo_documento == ucTipoSolicitud.Value.ToString() &&
                                  a.id_entidad == ucEntidad.Value.ToString() &&
                                  a.periodo_tep == _tbl.periodo_proceso &&
                                  !queryA.Any(d=> d.id_entidad == a.id_entidad && d.id_oficina == a.id_oficina && d.tipo_documento == a.tipo_documento && d.numero_documento == a.numero_documento )
                                                                                
                            select new AnulacionDoctoEN()
                            {
                                id_entidad = a.id_entidad,
                                tipo_docto = a.tipo_documento,
                                tipo_docto_descripcion = a.tipo_documento == "FAC" ? "FACTURA" : (a.tipo_documento == "COBRANZA" ? "COBRANZA" : "NOTA CREDITO"),
                                id_oficina = a.id_oficina,
                                documento = a.numero_documento,
                                razon_social = c.Razon_Social,
                                total = a.valor_total ?? 0,
                                Fecha = a.fecha.Value,
                                documento_electronico=a.clave_electronica
                            };

                lst = query.ToList<AnulacionDoctoEN>();
            }

            
            ugData.DataSource = lst;
            ugData.DataBind();
        }

        private void ugData_AfterRowActivate(object sender, EventArgs e)
        {
            if (ugData.ActiveRow.Index >= 0)
            {
                AnulacionDoctoEN _tbl = ugData.ActiveRow.ListObject as AnulacionDoctoEN;
                uteCliente.Value = _tbl.razon_social;
                uneTotalSol.Value = _tbl.total;
                udteFecha.Value = _tbl.Fecha;
                uteTipo.Value = _tbl.tipo_docto_descripcion;
                uneDocumento.Value = _tbl.documento;
                uteDoctoElect.Value = _tbl.documento_electronico;
            }
        }

        private void ucTipoSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucTipoSolicitud, true, true, true, true);
        }

        private void uteAutorizo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteAutorizo, true, true, true, true);
        }

        private void uteMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteMotivo, true, true, true, true);
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["documento_electronico"].Hidden = !esGT;
        }
    }
}
