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
using Infragistics.Win.UltraWinSchedule;

namespace TiempoEnProceso.Forms
{
    public partial class frmCliente : Form
    {
        public tbl_clientes Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }
        private List<tbl_entes_clientes> lstO;
        private List<tbl_entes_clientes> lstE= new List<tbl_entes_clientes>();

        private TEPEntities db;

        public frmCliente()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
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

        private bool ValidaControlesEnte()
        {
            LimpiaEspaciosEnte();

            if (!uvValidador.Validate("reqEntes", false, true).IsValid)
                return false;

            if (ucPaisENTE.Value != null &&
                ucPaisENTE.SelectedRow == null)
            {
                MessageBox.Show("Selección de País Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucDeptoENTE.Value != null &&
                ucDeptoENTE.SelectedRow == null)
            {
                MessageBox.Show("Selección de Provincia Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucMunicipioENTE.Value != null &&
                ucMunicipioENTE.SelectedRow == null)
            {
                MessageBox.Show("Selección de Municipio Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void LimpiaEspaciosEnte()
        {
            if (uteNIT.Value != null)
                uteNIT.Value = uteNIT.Value.ToString().Trim();

            if (uteRazSocENTE.Value!=null)
                uteRazSocENTE.Value = uteRazSocENTE.Value.ToString().Trim();

            if (uteDireccion1ENTE.Value != null)
                uteDireccion1ENTE.Value = uteDireccion1ENTE.Value.ToString().Trim();

            if (uteDireccion2ENTE.Value != null)
                uteDireccion2ENTE.Value = uteDireccion2ENTE.Value.ToString().Trim();

            if (uteDireccion3ENTE.Value != null)
                uteDireccion3ENTE.Value = uteDireccion3ENTE.Value.ToString().Trim();

            if (uteAtencionENTE.Value != null)
                uteAtencionENTE.Value = uteAtencionENTE.Value.ToString().Trim();

            if (uteAdicional1ENTE.Value != null)
                uteAdicional1ENTE.Value = uteAdicional1ENTE.Value.ToString().Trim();

            if (uteAdicional2ENTE.Value != null)
                uteAdicional2ENTE.Value = uteAdicional2ENTE.Value.ToString().Trim();
        }
        private bool ValidataControles()
        {
            LimpiaEspacios();

            if (!uvValidador.Validate("required", false, true).IsValid)
                return false;

            /*if (!uvValidador.Validate("reqData", false, true).IsValid)
            {
                ultraDockManager1.DockAreas[1].Closed = false;
                uteNationalID.Focus();
                SetEnableControls3(false);
                SetEnableControls4(false);

                Helper.GetControls<UltraButton>(this.ultraPanel4).ForEach(p => p.Enabled = false);
                uteOficina.Enabled = false;
                if (AccionActual != Helper.Acciones.Agregar)
                    uneId.Enabled = false;

                return false;
            }*/

            if (ucGrupo.Value != null &&
                ucGrupo.SelectedRow == null)
            {
                MessageBox.Show("Selección de Grupo Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucIndustria.Value != null &&
                ucIndustria.SelectedRow == null)
            {
                MessageBox.Show("Selección de Industria Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucPaisCliente.Value != null &&
                ucPaisCliente.SelectedRow == null)
            {
                MessageBox.Show("Selección de País Cliente Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            string _id = uneId.Value.ToString();
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_clientes.Any(d => d.id_cliente == _id && d.id_pais == Helper.Pais))
                {
                    MessageBox.Show("Cliente ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (AccionActual == Helper.Acciones.Editar)
            {
            }


            return true;
        }

        private void LimpiaEspacios()
        {
            /*if (uteRazonSocial.Value != null)
                uteRazonSocial.Value = uteRazonSocial.Value.ToString().Trim();

            if (uteDireccion2.Value != null)
                uteDireccion2.Value = uteDireccion2.Value.ToString().Trim();

            if (uteTelefono.Value != null)
                uteTelefono.Value = uteTelefono.Value.ToString().Trim();

            if (uteNationalID.Value != null)
                uteNationalID.Value = uteNationalID.Value.ToString().Trim();

            if (uneId.Value != null)
                uneId.Value = uneId.Value.ToString().Trim();

            if (uteDireccion.Value != null)
                uteDireccion.Value = uteDireccion.Value.ToString().Trim();

            if (uteCiudad.Value != null)
                uteCiudad.Value = uteCiudad.Value.ToString().Trim();

            if (uteEMail.Value != null)
                uteEMail.Value = uteEMail.Value.ToString().Trim();

            if (uteProvincia.Value != null)
                uteProvincia.Value = uteProvincia.Value.ToString().Trim();

            if (uteCodigoPostal.Value != null)
                uteCodigoPostal.Value = uteCodigoPostal.Value.ToString().Trim();

            if (uteTelefono.Value != null)
                uteTelefono.Value = uteTelefono.Value.ToString().Trim();

            if (uteNationalID.Value != null)
                uteNationalID.Value = uteNationalID.Value.ToString().Trim();*/

            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).Where(d => d.Value != null).ToList<UltraTextEditor>().ForEach(d => d.Value = d.Value.ToString().Trim());
            Helper.GetControls<UltraTextEditor>(this.ultraPanel5).Where(d=> d.Value!=null).ToList<UltraTextEditor>().ForEach(d => d.Value = d.Value.ToString().Trim());
            Helper.GetControls<UltraTextEditor>(this.ultraPanel6).Where(d => d.Value != null).ToList<UltraTextEditor>().ForEach(d => d.Value = d.Value.ToString().Trim());
        }

        private void LimpiaEspaciosEntidad()
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel1).Where(d => d.Value != null).ToList<UltraTextEditor>().ForEach(d => d.Value = d.Value.ToString().Trim());
        }
        public void CargarItem(string _empleado)
        {
            Item = db.tbl_clientes.FirstOrDefault(d => d.id_cliente == _empleado && d.id_pais == Helper.Pais);
            var qry = from c in db.tbl_entes_clientes
                      where c.id_cliente == _empleado && c.id_pais == Helper.Pais
                      select c;

            lstO = qry.Cast<tbl_entes_clientes>().ToList();

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uneId.Value = Item.id_cliente;
            uteRazonSocial.Value = Item.Razon_Social.Trim();
            ucGrupo.Value = Item.id_grupo;
            ucIndustria.Value = Item.id_industria;
            uteDireccion.Value = (Item.direccion1??"").Trim();
            uceExento.Value = Item.exento_impuesto;
            uteCiudad.Value = Item.ciudad;
            uteProvincia.Value = Item.provincia;
            uteCodigoPostal.Value = Item.codigo_postal;
            uteTelefono.Value = Item.telefonos;
            uteDireccion2.Value = Item.direccion2;
            uteEMail.Value = Item.email;
            uckInactiva.Checked = Item.estado == Helper.SI;
            uteCierreFiscal.Value = Item.cierre_anio_financiero;

            uteNationalID.Value = Item.nacional_id;
            uteEntityDuns.Value = Item.entity_duns;
            uteEntityCES.Value = Item.Entity_CES_id;
            uteParent.Value = Item.parent;
            uteParentalDuns.Value = Item.hq_parent_duns;
            uteGlobalUltDun.Value = Item.ultimate_parent_duns;
            uteGlobalUlt.Value = Item.global_ultimate;
            utePRID.Value = Item.Party_Ref_Id;
            uteInmediateDuns.Value = Item.Inmediate_Parent_Duns;
            uteCRP.Value = Item.crp;
            uteChannel.Value = Item.channel;
            ucPaisCliente.Value = Item.id_pais_cliente.Trim();

            uteAuditorExterno.Value = Item.Auditor_ext;
            uteWebAddress.Value = Item.webadress;
            uteRNC.Value = Item.rnc;
            uteFax.Value = Item.fax;
            uteClienteRef.Value = Item.cliente_referido;
            uteContactoCliente.Value = Item.contacto;
            utePosicionContacto.Value = Item.posicion_contac;
            uteMailContacto.Value = Item.email_contac;
            uteMovilContacto.Value = Item.movil_contac;

            ugData.DataSource = lstO;

        }

        public void CargaCombos()
        {
            tblgruposBindingSource.DataSource = (new GruposBL()).ListarTodos();
            tblindustriasBindingSource.DataSource = (new IndustriasBL()).Listar();
            tblgeografiaBindingSource.DataSource = (new GeografiaBL()).ListarTodos();
            tblpaisesBindingSource.DataSource = (new PaisBL()).Listar();
            tblcondicioncobroBindingSource.DataSource = db.Tbl_condicion_cobro.ToList();
        }

        private bool Grabar()
        {
            if (AccionActual == Helper.Acciones.Consultar)
                return true;

            if (!ValidataControles())
                return false;

            try
            {
                ConstruyeItem();

                if (AccionActual == Helper.Acciones.Agregar)
                    db.tbl_clientes.Add(Item);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Save", "Error al guardar", ex);
                return false;
            }

            return true;
        }

        private void ConstruyeItem()
        {

            if (AccionActual == Helper.Acciones.Agregar)
            {
                Item.id_cliente = uneId.Value.ToString();
                Item.id_pais = Helper.Pais;
            }

            Item.Razon_Social = string.Empty;
            if (uteRazonSocial.Value != null)
                Item.Razon_Social = uteRazonSocial.Value.ToString();

            Item.id_grupo = null;
            if (ucGrupo.Value != null)
                Item.id_grupo = Convert.ToDecimal( ucGrupo.Value);

            Item.id_industria = null;
            if (ucIndustria.Value != null)
                Item.id_industria = Convert.ToDecimal(ucIndustria.Value);

            Item.direccion1 = null;
            if (uteDireccion.Value != null)
                Item.direccion1 = uteDireccion.Value.ToString();

            Item.exento_impuesto = uceExento.Value.ToString();

            Item.cierre_anio_financiero = string.Empty;
            if (uteCierreFiscal.Value != null)
                Item.cierre_anio_financiero = uteCierreFiscal.Value.ToString();

            Item.ciudad = uteCiudad.Value.ToString();
            Item.provincia = uteProvincia.Value.ToString();
            Item.codigo_postal = uteCodigoPostal.Value.ToString();

            Item.telefonos = string.Empty;
            if (uteTelefono.Value != null)
                Item.telefonos = uteTelefono.Value.ToString();

            Item.direccion2 = string.Empty;
            if (uteDireccion2.Value != null)
                Item.direccion2 = uteDireccion2.Value.ToString();

            Item.email = string.Empty;
            if (uteEMail.Value != null)
                Item.email = uteEMail.Value.ToString();

            Item.estado = uckInactiva.Checked ? Helper.SI : 0;

            Item.nacional_id = string.Empty;
            if (uteNationalID.Value!=null)
                Item.nacional_id = uteNationalID.Value.ToString();

            Item.entity_duns = string.Empty;
            if (uteEntityDuns.Value!=null)
                Item.entity_duns = uteEntityDuns.Value.ToString();

            Item.Entity_CES_id =string.Empty;
            if (uteEntityCES.Value != null)
                Item.Entity_CES_id = uteEntityCES.Value.ToString();

            Item.parent = null;
            if (uteParent.Value != null)
                Item.parent = uteParent.Value.ToString();

            Item.hq_parent_duns = string.Empty;
            if (uteParentalDuns.Value!=null)
                Item.hq_parent_duns = uteParentalDuns.Value.ToString();

            Item.ultimate_parent_duns = string.Empty;
            if (uteGlobalUltDun.Value!=null)
                Item.ultimate_parent_duns = uteGlobalUltDun.Value.ToString();

            Item.global_ultimate = string.Empty;
            if (uteGlobalUlt.Value != null)
                Item.global_ultimate = uteGlobalUlt.Value.ToString();

            Item.Party_Ref_Id=string.Empty;
            if (utePRID.Value != null)
                Item.Party_Ref_Id = utePRID.Value.ToString();

            Item.Inmediate_Parent_Duns = string.Empty;
            if (uteInmediateDuns.Value != null)
                Item.Inmediate_Parent_Duns = uteInmediateDuns.Value.ToString();

            Item.crp = string.Empty;
            if (uteCRP.Value!=null)
                Item.crp = uteCRP.Value.ToString();

            Item.channel=string.Empty;
            if (uteChannel.Value != null)
                Item.channel = uteChannel.Value.ToString();

            Item.id_pais_cliente=string.Empty;
            if (ucPaisCliente.Value != null)
                Item.id_pais_cliente = ucPaisCliente.Value.ToString();

            Item.Auditor_ext = string.Empty;
            if (uteAuditorExterno.Value != null)
                Item.Auditor_ext = uteAuditorExterno.Value.ToString();

            Item.webadress = string.Empty;
            if (uteWebAddress.Value != null)
                Item.webadress = uteWebAddress.Value.ToString();

            Item.rnc = string.Empty;
            if (uteRNC.Value != null)
                Item.rnc = uteRNC.Value.ToString();

            Item.fax = string.Empty;
            if (uteFax.Value != null)
                Item.fax = uteFax.Value.ToString();

            Item.cliente_referido = string.Empty;
            if (uteClienteRef.Value != null)
                Item.cliente_referido = uteClienteRef.Value.ToString();

            Item.contacto = string.Empty; 
            if (uteContactoCliente.Value != null)
                Item.contacto = uteContactoCliente.Value.ToString();

            Item.posicion_contac = string.Empty;
            if (utePosicionContacto.Value != null)
                Item.posicion_contac = utePosicionContacto.Value.ToString();

            Item.email_contac = string.Empty;
            if (uteMailContacto.Value != null)
                Item.email_contac = uteMailContacto.Value.ToString();

            Item.movil_contac = string.Empty;
            if (uteMovilContacto.Value != null)
                Item.movil_contac = uteMovilContacto.Value.ToString();

            /*Defaults*/
            Item.direccion3 = string.Empty;
            Item.auditor_anterior = string.Empty;

            decimal dLinea = 1;

            if (db.tbl_entes_clientes.Any())
                dLinea = db.tbl_entes_clientes.Max(d => d.linea);

            foreach (tbl_entes_clientes _op in (List<tbl_entes_clientes>)ugData.DataSource)
            {
                if (string.IsNullOrEmpty(_op.id_cliente))
                {
                    _op.id_cliente = Item.id_cliente;
                    _op.id_pais = Item.id_pais;
                }

                if (_op.linea == 0)
                    _op.linea = dLinea++;

                if (!db.tbl_entes_clientes.Any(d => d.id_pais == _op.id_pais && d.id_cliente == _op.id_cliente && d.nit == _op.nit))
                    db.tbl_entes_clientes.Add(_op);
            }

            foreach (tbl_entes_clientes _del in lstE)
                if (_del.linea != 0)
                    db.tbl_entes_clientes.Remove(_del);

        }

        private void EstableceHabilitacion()
        {
            switch (AccionActual)
            {
                case Helper.Acciones.Agregar:
                    break;
                case Helper.Acciones.Consultar:
                    SetEnableControls(false);
                    break;
                case Helper.Acciones.Editar:
                    uneId.Enabled = false;
                    break;
            }
        }

        private void NuevoItem()
        {
            Item = new tbl_clientes();
            lstO = new List<tbl_entes_clientes>();
            lstE = new List<tbl_entes_clientes>();

            ugData.DataSource = lstO;
            ugData.DataBind();

            uneId.Value = null;
            uteRazonSocial.Value = null;
            ucGrupo.Value = null;
            ucIndustria.Value = null;
            uteDireccion.Value = null;
            uceExento.Value = "N";
            uteCiudad.Value = null;
            uteProvincia.Value = null;
            uteCodigoPostal.Value = null;
            uteTelefono.Value = null;
            uteDireccion2.Value = null;
            uteEMail.Value = null;
            uckInactiva.Checked = true;

            uteNationalID.Value = null;
            uteEntityDuns.Value = null;
            uteEntityCES.Value = null;
            uteParent.Value = null;
            uteParentalDuns.Value = null;
            uteGlobalUltDun.Value = null;
            uteGlobalUlt.Value = null;
            utePRID.Value = null;
            uteInmediateDuns.Value = null;
            uteCRP.Value = null;
            uteChannel.Value = null;
            ucPaisCliente.Value = null;

            uteAuditorExterno.Value = null;
            uteWebAddress.Value = null;
            uteRNC.Value = null;
            uteFax.Value = null;
            uteClienteRef.Value = null;
            uteContactoCliente.Value = null;
            utePosicionContacto.Value = null;
            uteMailContacto.Value = null;
            uteMovilContacto.Value = null;

            Helper.GetControls<UltraTextEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
            Helper.GetControls<UltraCombo>(this.ultraPanel1).ForEach(d => d.Value = null);
            Helper.GetControls<UltraComboEditor>(this.ultraPanel1).ForEach(d => d.Value = null);

            uteOficina.Enabled = false;
            uneId.Focus();

        }

        private void SetEnableControls3(bool Enable)
        {
            Helper.GetControls<UltraButton>(this.ultraPanel3).ForEach(p => p.Enabled = Enable);
        }

        private void SetEnableControls4(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraComboEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraDateTimeEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCalendarCombo>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraNumericEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCheckEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
        }

        private void SetEnableControls1(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel1).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel1).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraComboEditor>(this.ultraPanel1).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraButton>(this.ultraPanel1).ForEach(p => p.Enabled = Enable);
        }

        private void SetEnableControls5(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel5).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel5).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraComboEditor>(this.ultraPanel5).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraButton>(this.ultraPanel5).ForEach(p => p.Enabled = Enable);
        }

        private void SetEnableControls6(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel6).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraButton>(this.ultraPanel6).ForEach(p => p.Enabled = Enable);
        }
        private void SetEnableControls(bool Enable)
        {
            SetEnableControls4(Enable);
            SetEnableControls1(Enable);
            SetEnableControls5(Enable);
            SetEnableControls6(Enable);            
        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);

            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);

            Helper.GetControls<UltraLabel>(this.ultraPanel4).ForEach(d => d.Appearance.FontData.Bold = DefaultableBoolean.True);
            Helper.GetControls<UltraLabel>(this.ultraPanel5).ForEach(d => d.Appearance.FontData.Bold = DefaultableBoolean.True);
            Helper.GetControls<UltraLabel>(this.ultraPanel6).ForEach(d => d.Appearance.FontData.Bold = DefaultableBoolean.True);
            Helper.GetControls<UltraLabel>(this.ultraPanel1).ForEach(d => d.Appearance.FontData.Bold = DefaultableBoolean.True);
            Helper.SetUltraComboWidth(this);

            ultraDockManager1.DockAreas[0].Closed = true;
            ultraDockManager1.DockAreas[1].Closed = true;
            ultraDockManager1.DockAreas[2].Closed = true;

            if (Helper.Oficina == Helper.CR)
            {
                Infragistics.Win.UltraWinToolTip.UltraToolTipInfo toolT = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                toolT.ToolTipText = "Código de identificacion del Receptor";

                ultraToolTipManager1.SetUltraToolTip(uteAdicional1ENTE, toolT);

                Infragistics.Win.UltraWinToolTip.UltraToolTipInfo toolT2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                toolT.ToolTipText = "Identificacion Receptor Extranjero";
                ultraToolTipManager1.SetUltraToolTip(uteAdicional2ENTE, toolT);
            }

            CargaCombos();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                NuevoItem();
                

            }

            uneId.Focus();

        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");

                if (Helper.Continuo && AccionActual == Helper.Acciones.Agregar)
                    NuevoItem();
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            if (Helper.Continuo)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;

            Close();
        }

        private void uteDescripcion_KeyDown(object sender, KeyEventArgs e)
        {

            System.Diagnostics.Debug.WriteLine(e.KeyCode);
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteRazonSocial, true, true, true, true);
        }

        private void uteIdBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneId, true, true, true, true);
        }

        private void ucDepto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucDepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucIndustria, true, true, true, true);
        }

        private void ucDepto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_industria"].Value.ToString().Trim(), e.Row.Cells["nombre"].Value.ToString().Trim());
        }

        private void ucTeam_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_team"].Value.ToString().Trim(), e.Row.Cells["nombre"].Value.ToString().Trim());
        }

        private void ucTeam_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteCiudad, true, true, true, true);
        }

        private void uteCemCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteEMail, true, true, true, true);
        }

        private void ucSituacion_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ucSituacion_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteApellidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDireccion, true, true, true, true);
        }

        private void ucPuesto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_grupo"].Value.ToString().Trim(), e.Row.Cells["nombre"].Value.ToString().Trim());
        }

        private void ucPuesto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucGrupo, true, true, true, true);
        }

        private void uckSolicita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckInactiva, true, true, true, true);
        }

        private void uteProvincia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteProvincia, true, true, true, true);
        }

        private void uteCodigoPostal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                SelectNextControl(uteCodigoPostal, true, true, true, true);
        }

        private void uteTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                SelectNextControl(uteTelefono, true, true, true, true);
        }

        private void uteDireccion2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                SelectNextControl(uteDireccion2, true, true, true, true);
        }

        private void uceExento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                SelectNextControl(uceExento, true, true, true, true);
        }

        private void uckInactiva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                SelectNextControl(uckInactiva, true, true, true, true);
        }

        private void uteNIT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteRazSocENTE.Focus();
        }

        private void uteRazSocENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteDireccion1ENTE.Focus();
        }

        private void uteDireccionENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ucPaisENTE.Focus();
        }

        private void ucPaisENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ucDeptoENTE.Focus();
        }

        private void ucDeptoENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ucMunicipioENTE.Focus();
        }

        private void ucMunicipioENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteCodigoPostalENTE.Focus();
        }

        private void uteCodigoPostalENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteDireccion2ENTE.Focus();
        }

        private void uteDireccion1ENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteDireccion3ENTE.Focus();
        }

        private void uteDireccion2ENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteCorreEENTE.Focus();
        }

        private void uteAtencionENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteAdicional1ENTE.Focus();
        }

        private void uteAdicional1ENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteAdicional2ENTE.Focus();
        }

        private void uteAdicional2ENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteUbicacionENTE.Focus();
        }

        private void ucPaisENTE_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPaisENTE_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Descripcion"].Value.ToString().Trim());
        }

        private void ucDeptoENTE_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["Codigo_provincia"].Value.ToString().Trim(), e.Row.Cells["Descripcion"].Value.ToString().Trim());
        }

        private void ucDeptoENTE_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucDeptoENTE_ValueChanged(object sender, EventArgs e)
        {
            if (ucDeptoENTE.Value != null &&
                ucDeptoENTE.Value.ToString().Trim()!=string.Empty)
            {
                Tbl_provincia_depto _tbl = ucDeptoENTE.SelectedRow.ListObject as Tbl_provincia_depto;
                tblmunicipioBindingSource.DataSource = (new MunicipioBL()).ListarTodos(_tbl.Codigo_iso_alpha, _tbl.Codigo_provincia);
            }
        }

        private void ucPaisENTE_ValueChanged(object sender, EventArgs e)
        {
            if (ucPaisENTE.Value != null &&
                ucPaisENTE.Value.ToString().Trim()!=string.Empty &&
                ucPaisENTE.SelectedRow!=null)
            {
                Tbl_geografia _tbl = ucPaisENTE.SelectedRow.ListObject as Tbl_geografia;
                tblprovinciadeptoBindingSource.DataSource = (new ProvinciaBL()).ListarTodos(_tbl.Codigo_iso_alpha);
            }
        }

        private void ucMunicipioENTE_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucMunicipioENTE_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["codigo_municipio"].Value.ToString().Trim(), e.Row.Cells["municipio"].Value.ToString().Trim());
        }

        private void ubCerrarDataQ_Click(object sender, EventArgs e)
        {
            ultraDockManager1.DockAreas[1].Closed = true;
            SetEnableControls4(true);
            SetEnableControls3(true);

            Helper.GetControls<UltraButton>(this.ultraPanel4).ForEach(p => p.Enabled = true);
        }

        private void ubCerrarDA_Click(object sender, EventArgs e)
        {
            ultraDockManager1.DockAreas[2].Closed = true;
            SetEnableControls4(true);
            SetEnableControls3(true);

            Helper.GetControls<UltraButton>(this.ultraPanel4).ForEach(p => p.Enabled = true);
        }

        private void ubEnte_Click(object sender, EventArgs e)
        {
            ultraDockManager1.DockAreas[0].Closed = false;
            uvValidador.ValidationGroups["reqEntes"].Enabled = true;
            uteNIT.Focus();
            SetEnableControls4(false);
            SetEnableControls3(false);
            Helper.GetControls<UltraButton>(this.ultraPanel4).ForEach(p => p.Enabled = false);

            uteOficina.Enabled = false;
            if (AccionActual != Helper.Acciones.Agregar)
                uneId.Enabled = false;

        }

        private void ubData_Click(object sender, EventArgs e)
        {
            ultraDockManager1.DockAreas[1].Closed = false;
            uteNationalID.Focus();
            SetEnableControls3(false);
            SetEnableControls4(false);

            Helper.GetControls<UltraButton>(this.ultraPanel4).ForEach(p => p.Enabled = false);
            uteOficina.Enabled = false;
            if (AccionActual != Helper.Acciones.Agregar)
                uneId.Enabled = false;
        }

        private void ubAdicionales_Click(object sender, EventArgs e)
        {
            ultraDockManager1.DockAreas[2].Closed = false;
            uteAuditorExterno.Focus();
            SetEnableControls3(false);
            SetEnableControls4(false);

            Helper.GetControls<UltraButton>(this.ultraPanel4).ForEach(p => p.Enabled = false);
            uteOficina.Enabled = false;
            if (AccionActual != Helper.Acciones.Agregar)
                uneId.Enabled = false;
        }

        private void ubCerrarEntes_Click(object sender, EventArgs e)
        {
            ultraDockManager1.DockAreas[0].Closed = true;
            SetEnableControls4(true);
            SetEnableControls3(true);
            uvValidador.ValidationGroups["reqEntes"].Enabled = false;
            Helper.GetControls<UltraButton>(this.ultraPanel4).ForEach(p => p.Enabled = true);
            uteOficina.Enabled = false;
            if (AccionActual != Helper.Acciones.Agregar)
                uneId.Enabled = false;
        }

        private void ubAgregarEnte_Click(object sender, EventArgs e)
        {
            if (!ValidaControlesEnte())
                return ;

            string _o = uteNIT.Value.ToString();

            if (!lstO.Any(d => d.nit.Trim() == _o))
            {
                tbl_entes_clientes _ec = new tbl_entes_clientes();

                _ec.adicional1 = string.Empty;
                if (uteAdicional1ENTE.Value != null)
                    _ec.adicional1 = uteAdicional1ENTE.Value.ToString();

                _ec.adicional2 = string.Empty;
                if (uteAdicional2ENTE.Value != null)
                    _ec.adicional2 = uteAdicional2ENTE.Value.ToString();

                _ec.id_pais = Helper.Pais;
                _ec.nit = uteNIT.Value.ToString();

                _ec.correo_electronico = string.Empty;
                if (uteCorreEENTE.Value != null)
                    _ec.correo_electronico = uteCorreEENTE.Value.ToString();

                _ec.ente_cliente_ubicacion = string.Empty;
                if (uteUbicacionENTE.Value != null)
                    _ec.ente_cliente_ubicacion = uteUbicacionENTE.Value.ToString();

                _ec.nombre = string.Empty;
                if (uteRazSocENTE.Value != null)
                    _ec.nombre = uteRazSocENTE.Value.ToString();

                _ec.direccion1 = string.Empty;
                if (uteDireccion1ENTE.Value != null)
                    _ec.direccion1 = uteDireccion1ENTE.Value.ToString();

                _ec.direccion2 = string.Empty;
                if (uteDireccion2ENTE.Value != null)
                    _ec.direccion2 = uteDireccion2ENTE.Value.ToString();

                _ec.direccion3 = string.Empty;
                if (uteDireccion3ENTE.Value != null)
                    _ec.direccion3 = uteDireccion3ENTE.Value.ToString();

                _ec.Codigo_pais_iso = string.Empty;
                if (ucPaisENTE.Value != null)
                    _ec.Codigo_pais_iso = ucPaisENTE.Value.ToString();

                _ec.codigo_municipio = string.Empty;
                if (ucMunicipioENTE.Value != null)
                    _ec.codigo_municipio = ucMunicipioENTE.Value.ToString();

                _ec.codigo_provincia = string.Empty;
                if (ucDeptoENTE.Value != null)
                    _ec.codigo_provincia = ucDeptoENTE.Value.ToString();


                _ec.codigo_postal = string.Empty;
                if (uteCodigoPostalENTE.Value != null)
                    _ec.codigo_postal = uteCodigoPostalENTE.Value.ToString();

                _ec.atencion_a = string.Empty;
                if (uteAtencionENTE.Value != null)
                    _ec.atencion_a = uteAtencionENTE.Value.ToString();

                _ec.estado = uckEstado.Checked ? 0 : 1;
                _ec.Cliente_Exonerado = uckExonerado.Checked;
                _ec.Local_Extranjero = uckLocal.Checked;
                _ec.Id_Tbl_condicion_cobro = null;
                if (ucCondicion.Value != null)
                    _ec.Id_Tbl_condicion_cobro = Convert.ToInt32(ucCondicion.Value);

                _ec.Tipo_Exoneracion = string.Empty;
                if (ucTipoExoneracion.Value != null)
                    _ec.Tipo_Exoneracion = ucTipoExoneracion.Value.ToString();

                _ec.numero_exoneracion = string.Empty;
                if (uteNumeroExoneracion.Value != null)
                    _ec.numero_exoneracion = uteNumeroExoneracion.Value.ToString();

                if (udteFechaExoneracion.Value != null)
                    _ec.Fecha_EExoneracion = Convert.ToDateTime(udteFechaExoneracion.Value);

                _ec.RUC = string.Empty;
                if (uteRUC.Value != null)
                    _ec.RUC = uteRUC.Value.ToString();

                _ec.Monto_Exoneracion = 0;
                if (uneMontoExoneracion.Value != null)
                    _ec.Monto_Exoneracion = Convert.ToDecimal(uneMontoExoneracion.Value);

                _ec.Porcentaje_CExoneracion = 0;
                if (unePorcExoneracion.Value != null)
                    _ec.Porcentaje_CExoneracion = Convert.ToDecimal(unePorcExoneracion.Value);

                _ec.id_industria = null;
                if (uceIndustriaENTE.Value != null)
                    _ec.id_industria = Convert.ToDecimal(uceIndustriaENTE.Value);

                lstO.Add(_ec);

                ugData.DataBind();

                Helper.GetControls<UltraTextEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
                Helper.GetControls<UltraCombo>(this.ultraPanel1).ForEach(d => d.Value = null);
                Helper.GetControls<UltraComboEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
                Helper.GetControls<UltraCheckEditor>(this.ultraPanel1).ForEach(d => d.Checked = false);
                Helper.GetControls<UltraCombo>(ultraPanel1).ForEach(d => d.Value = null);
                Helper.GetControls<UltraDateTimeEditor>(ultraPanel1).ForEach(d => d.Value = null);
                Helper.GetControls<UltraNumericEditor>(ultraPanel1).ForEach(d => d.Value = null);
                uckEstado.Checked = true;
                uckExonerado.Checked = false;
                uckLocal.Checked = true;

            }
            else
            {
                if (ugData.ActiveRow != null)
                {
                    /*tbl_entes_clientes _tb = ugData.ActiveRow.ListObject as tbl_entes_clientes;

                    if (db.tbl_entes_clientes.Any(d => d.id_pais == _tb.id_pais && d.linea == _tb.linea))
                        db.tbl_entes_clientes.Remove(ugData.ActiveRow.ListObject as tbl_entes_clientes);
                    lstO.Remove(ugData.ActiveRow.ListObject as tbl_entes_clientes);
                    ugData.DataBind();*/
                    tbl_entes_clientes _ec = ugData.ActiveRow.ListObject as tbl_entes_clientes;
                    int i = lstO.IndexOf(_ec);

                    if (i >= 0)
                    {
                        lstO[i].adicional1 = string.Empty;
                        if (uteAdicional1ENTE.Value != null)
                            lstO[i].adicional1 = uteAdicional1ENTE.Value.ToString();

                        lstO[i].adicional2 = string.Empty;
                        if (uteAdicional2ENTE.Value != null)
                            lstO[i].adicional2 = uteAdicional2ENTE.Value.ToString();     

                        lstO[i].id_pais = Helper.Pais;
                        lstO[i].nit = uteNIT.Value.ToString();

                        lstO[i].nombre = string.Empty;
                        if (uteRazSocENTE.Value != null)
                            lstO[i].nombre = uteRazSocENTE.Value.ToString();

                        lstO[i].direccion1 = string.Empty;
                        if (uteDireccion1ENTE.Value != null)
                            lstO[i].direccion1 = uteDireccion1ENTE.Value.ToString();

                        lstO[i].correo_electronico = string.Empty;
                        if (uteCorreEENTE.Value != null)
                            lstO[i].correo_electronico = uteCorreEENTE.Value.ToString();

                        lstO[i].ente_cliente_ubicacion = string.Empty;
                        if (uteUbicacionENTE.Value != null)
                            lstO[i].ente_cliente_ubicacion = uteUbicacionENTE.Value.ToString();

                        lstO[i].direccion2 = string.Empty;
                        if (uteDireccion2ENTE.Value != null)
                            lstO[i].direccion2 = uteDireccion2ENTE.Value.ToString();

                        lstO[i].direccion3 = string.Empty;
                        if (uteDireccion3ENTE.Value != null)
                            lstO[i].direccion3 = uteDireccion3ENTE.Value.ToString();

                        lstO[i].Codigo_pais_iso = string.Empty;
                        if (ucPaisENTE.Value != null)
                            lstO[i].Codigo_pais_iso = ucPaisENTE.Value.ToString();

                        lstO[i].codigo_municipio = string.Empty;
                        if (ucMunicipioENTE.Value != null)
                            lstO[i].codigo_municipio = ucMunicipioENTE.Value.ToString();

                        lstO[i].codigo_provincia = string.Empty;
                        if (ucDeptoENTE.Value != null)
                            lstO[i].codigo_provincia = ucDeptoENTE.Value.ToString();

                        lstO[i].codigo_postal = string.Empty;
                        if (uteCodigoPostalENTE.Value != null)
                            lstO[i].codigo_postal = uteCodigoPostalENTE.Value.ToString();

                        lstO[i].atencion_a = string.Empty;
                        if (uteAtencionENTE.Value != null)
                            lstO[i].atencion_a = uteAtencionENTE.Value.ToString();

                        lstO[i].estado = uckEstado.Checked ? 0 : 1;
                        lstO[i].Cliente_Exonerado = uckExonerado.Checked;
                        _ec.Local_Extranjero = uckLocal.Checked;
                        _ec.Id_Tbl_condicion_cobro = null;
                        if (ucCondicion.Value != null)
                            _ec.Id_Tbl_condicion_cobro = Convert.ToInt32(ucCondicion.Value);

                        lstO[i].Tipo_Exoneracion = string.Empty;
                        if (ucTipoExoneracion.Value != null)
                            lstO[i].Tipo_Exoneracion = ucTipoExoneracion.Value.ToString();

                        lstO[i].numero_exoneracion = string.Empty;
                        if (uteNumeroExoneracion.Value != null)
                            lstO[i].numero_exoneracion = uteNumeroExoneracion.Value.ToString();

                        if (udteFechaExoneracion.Value != null)
                            lstO[i].Fecha_EExoneracion = Convert.ToDateTime(udteFechaExoneracion.Value);

                        lstO[i].RUC = string.Empty;
                        if (uteRUC.Value != null)
                            lstO[i].RUC = uteRUC.Value.ToString();

                        lstO[i].Monto_Exoneracion = 0;
                        if (uneMontoExoneracion.Value != null)
                            lstO[i].Monto_Exoneracion = Convert.ToDecimal(uneMontoExoneracion.Value);

                        lstO[i].Porcentaje_CExoneracion = 0;
                        if (unePorcExoneracion.Value != null)
                            lstO[i].Porcentaje_CExoneracion = Convert.ToDecimal(unePorcExoneracion.Value);

                        lstO[i].id_industria = null;
                        if (uceIndustriaENTE.Value != null)
                            lstO[i].id_industria = Convert.ToDecimal(uceIndustriaENTE.Value);

                        ugData.DataBind();

                        Helper.GetControls<UltraTextEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
                        Helper.GetControls<UltraCombo>(this.ultraPanel1).ForEach(d => d.Value = null);
                        Helper.GetControls<UltraComboEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
                        Helper.GetControls<UltraCheckEditor>(this.ultraPanel1).ForEach(d => d.Checked = false);
                        Helper.GetControls<UltraDateTimeEditor>(ultraPanel1).ForEach(d => d.Value = null);
                        Helper.GetControls<UltraNumericEditor>(ultraPanel1).ForEach(d => d.Value = null);

                        Helper.GetControls<UltraComboEditor>(ultraPanel1).ForEach(d => d.Value = null);
                        uckEstado.Checked = true;
                        uckExonerado.Checked = false;
                        uckLocal.Checked = true;
                    }
                }
            }
        }

        private void ubEliEnte_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                if (!ValidaControlesEnte())
                    return;

                /*tbl_entes_clientes _tb = ugData.ActiveRow.ListObject as tbl_entes_clientes;

                if (db.tbl_entes_clientes.Any(d => d.id_pais == _tb.id_pais && d.linea == _tb.linea))
                    db.tbl_entes_clientes.Remove(ugData.ActiveRow.ListObject as tbl_entes_clientes);
                lstO.Remove(ugData.ActiveRow.ListObject as tbl_entes_clientes);
                ugData.DataBind();*/
                tbl_entes_clientes _ec = ugData.ActiveRow.ListObject as tbl_entes_clientes;
                int i = lstO.IndexOf(_ec);

                if (i >= 0)
                {
                    lstO[i].adicional1 = string.Empty;
                    if (uteAdicional1ENTE.Value != null)
                        lstO[i].adicional1 = uteAdicional1ENTE.Value.ToString();

                    lstO[i].adicional2 = string.Empty;
                    if (uteAdicional2ENTE.Value != null)
                        lstO[i].adicional2 = uteAdicional2ENTE.Value.ToString();                    

                    lstO[i].id_pais = Helper.Pais;
                    lstO[i].nit = uteNIT.Value.ToString();

                    lstO[i].nombre = string.Empty;
                    if (uteRazSocENTE.Value != null)
                        lstO[i].nombre = uteRazSocENTE.Value.ToString();

                    lstO[i].direccion1 = string.Empty;
                    if (uteDireccion1ENTE.Value != null)
                        lstO[i].direccion1 = uteDireccion1ENTE.Value.ToString();

                    lstO[i].direccion2 = string.Empty;
                    if (uteDireccion2ENTE.Value != null)
                        lstO[i].direccion2 = uteDireccion2ENTE.Value.ToString();

                    lstO[i].direccion3 = string.Empty;
                    if (uteDireccion3ENTE.Value != null)
                        lstO[i].direccion3 = uteDireccion3ENTE.Value.ToString();

                    lstO[i].Codigo_pais_iso = string.Empty;
                    if (ucPaisENTE.Value != null)
                        lstO[i].Codigo_pais_iso = ucPaisENTE.Value.ToString();

                    lstO[i].codigo_municipio = string.Empty;
                    if (ucMunicipioENTE.Value != null)
                        lstO[i].codigo_municipio = ucMunicipioENTE.Value.ToString();

                    lstO[i].codigo_provincia = string.Empty;
                    if (ucDeptoENTE.Value != null)
                        lstO[i].codigo_provincia = ucDeptoENTE.Value.ToString();

                    
                    

                    lstO[i].codigo_postal = string.Empty;
                    if (uteCodigoPostalENTE.Value != null)
                        lstO[i].codigo_postal = uteCodigoPostalENTE.Value.ToString();

                    lstO[i].atencion_a = string.Empty;
                    if (uteAtencionENTE.Value != null)
                        lstO[i].atencion_a = uteAtencionENTE.Value.ToString();
                    
                    lstO[i].estado = uckEstado.Checked ? 0 : 1;
                    lstO[i].Cliente_Exonerado = uckExonerado.Checked;
                    _ec.Local_Extranjero = uckLocal.Checked;
                    _ec.Id_Tbl_condicion_cobro = null;
                    if (ucCondicion.Value != null)
                        _ec.Id_Tbl_condicion_cobro = Convert.ToInt32(ucCondicion.Value);

                    lstO[i].Tipo_Exoneracion = string.Empty;

                    if (ucTipoExoneracion.Value != null)
                        lstO[i].Tipo_Exoneracion = ucTipoExoneracion.Value.ToString();

                    lstO[i].numero_exoneracion = string.Empty;
                    if (uteNumeroExoneracion.Value != null)
                        lstO[i].numero_exoneracion = uteNumeroExoneracion.Value.ToString();

                    if (udteFechaExoneracion.Value != null)
                        lstO[i].Fecha_EExoneracion = Convert.ToDateTime(udteFechaExoneracion.Value);

                    lstO[i].RUC = string.Empty;
                    if (uteRUC.Value != null)
                        lstO[i].RUC = uteRUC.Value.ToString();

                    lstO[i].Monto_Exoneracion = 0;
                    if (uneMontoExoneracion.Value != null)
                        lstO[i].Monto_Exoneracion = Convert.ToDecimal(uneMontoExoneracion.Value);

                    lstO[i].Porcentaje_CExoneracion = 0;
                    if (unePorcExoneracion.Value != null)
                        lstO[i].Porcentaje_CExoneracion = Convert.ToDecimal(unePorcExoneracion.Value);

                    lstO[i].id_industria = null;
                    if (uceIndustriaENTE.Value != null)
                        lstO[i].id_industria = Convert.ToDecimal(uceIndustriaENTE.Value);

                    ugData.DataBind();

                    Helper.GetControls<UltraTextEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
                    Helper.GetControls<UltraCombo>(this.ultraPanel1).ForEach(d => d.Value = null);
                    Helper.GetControls<UltraComboEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
                    Helper.GetControls<UltraCheckEditor>(this.ultraPanel1).ForEach(d => d.Checked = false);
                    Helper.GetControls<UltraDateTimeEditor>(ultraPanel1).ForEach(d => d.Value = null);
                    Helper.GetControls<UltraNumericEditor>(ultraPanel1).ForEach(d => d.Value = null);
                }                
            }
        }

        private void ugData_MouseClick(object sender, MouseEventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                tbl_entes_clientes _ec = ugData.ActiveRow.ListObject as tbl_entes_clientes;
                uteUbicacionENTE.Value = _ec.ente_cliente_ubicacion;
                uteCorreEENTE.Value = _ec.correo_electronico;
                uteNIT.Value = _ec.nit;
                uteAdicional1ENTE.Value = _ec.adicional1;
                uteAdicional2ENTE.Value = _ec.adicional2;
                uteAtencionENTE.Value = _ec.atencion_a;

                ucPaisENTE.Value = string.IsNullOrWhiteSpace(_ec.Codigo_pais_iso) ? null : _ec.Codigo_pais_iso;
                ucDeptoENTE.Value = string.IsNullOrWhiteSpace(_ec.codigo_provincia) ? null : _ec.codigo_provincia;
                ucMunicipioENTE.Value = string.IsNullOrWhiteSpace(_ec.codigo_municipio) ? null : _ec.codigo_municipio;
                uteDireccion1ENTE.Value = _ec.direccion1;
                uteDireccion2ENTE.Value = _ec.direccion2;
                uteDireccion3ENTE.Value = _ec.direccion3;
                uteRazSocENTE.Value = _ec.nombre;
                uteCodigoPostalENTE.Value = _ec.codigo_postal;
                uckEstado.Checked = (_ec.estado ?? 0) == 0;
                uckExonerado.Checked = _ec.Cliente_Exonerado??false;
                uckLocal.Checked = _ec.Local_Extranjero??false;
                ucCondicion.Value = _ec.Id_Tbl_condicion_cobro;
                ucTipoExoneracion.Value = _ec.Tipo_Exoneracion;
                uteNumeroExoneracion.Value = _ec.numero_exoneracion;
                udteFechaExoneracion.Value = _ec.Fecha_EExoneracion;
                uteRUC.Value = _ec.RUC;
                uneMontoExoneracion.Value = _ec.Monto_Exoneracion;
                unePorcExoneracion.Value = _ec.Porcentaje_CExoneracion;
                uceIndustriaENTE.Value = _ec.id_industria;
            }
        }

        private void ucPaisCliente_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPaisCliente_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Nombre"].Value.ToString().Trim());
        }

        private void uteAuditorExterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteWebAddress.Focus();
        }

        private void uteWebAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteRNC.Focus();
        }

        private void uteRNC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteFax.Focus();
        }

        private void uteFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteClienteRef.Focus();
        }

        private void uteClienteRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteContactoCliente.Focus();
        }

        private void uteContactoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                utePosicionContacto.Focus();
        }

        private void utePosicionContacto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteMailContacto.Focus();
        }

        private void uteMailContacto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteMovilContacto.Focus();
        }

        private void uteMovilContacto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ubCerrarDA.Focus();

        }

        private void uteNationalID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteEntityDuns.Focus();
            

        }

        private void uteEntityDuns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteEntityCES.Focus();
        }

        private void uteEntityCES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteParentalDuns.Focus();
        }

        private void uteParentalDuns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteParent.Focus();
        }

        private void uteGlobalUltDun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteGlobalUlt.Focus();
        }

        private void uteParent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteGlobalUltDun.Focus();
        }

        private void uteGlobalUlt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                utePRID.Focus();
        }

        private void utePRID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteCRP.Focus();
        }

        private void uteInmediateDuns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteCRP.Focus();
        }

        private void uteCRP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteChannel.Focus();
        }

        private void uteChannel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ucPaisCliente.Focus();
        }

        private void ucPaisCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ubCerrarDataQ.Focus();
        }

        private void uckEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckEstado, true, true, true, true);
        }

        private void ubBuscar_Click(object sender, EventArgs e)
        {
            using (frmClientes frm = new frmClientes())
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    NuevoItem();
                    ubDel.Visible = true;
                    ubDelDet.Visible = true;
                        
                    AccionActual = Helper.Acciones.Editar;
                    CargarItem(frm.id_cliente);
                }
            }
        }

        private void ubGraDet_Click(object sender, EventArgs e)
        {
            try
            {
                if (AccionActual == Helper.Acciones.Editar)
                {
                    decimal dLinea = db.tbl_entes_clientes.Max(d => d.linea);
                    foreach (tbl_entes_clientes _op in (List<tbl_entes_clientes>)ugData.DataSource)
                    {
                        if (string.IsNullOrEmpty(_op.id_cliente))
                        {
                            _op.id_cliente = Item.id_cliente;
                            _op.id_pais = Item.id_pais;
                        }

                        if (_op.linea == 0)
                            _op.linea = dLinea++;

                        if (!db.tbl_entes_clientes.Any(d => d.id_pais == _op.id_pais && d.id_cliente == _op.id_cliente && d.nit == _op.nit))
                            db.tbl_entes_clientes.Add(_op);
                    }

                    foreach (tbl_entes_clientes _del in lstE)
                        if (_del.linea != 0)
                            db.tbl_entes_clientes.Remove(_del);

                    db.SaveChanges();
                    string _empleado = Item.id_cliente;

                    lstE = new List<tbl_entes_clientes>();
                    lstO = new List<tbl_entes_clientes>();
                    lstO = db.tbl_entes_clientes.Where(d => d.id_cliente == _empleado && d.id_pais == Helper.Pais).ToList<tbl_entes_clientes>();
                    ugData.DataSource = lstO;
                    ugData.DataBind();

                    Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                }
            }
            catch (Exception ex)
            {
                Helper.ShowError("Save", "Error al guardar", ex);
            }
        }

        private void ubDelDet_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                if (MessageBox.Show("¿Seguro desea eliminar el presente registro?", Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                    return;

                lstE.Add(ugData.ActiveRow.ListObject as tbl_entes_clientes);
                lstO.Remove(ugData.ActiveRow.ListObject as tbl_entes_clientes);
                ugData.DataBind();

                Helper.GetControls<UltraTextEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
                Helper.GetControls<UltraCombo>(this.ultraPanel1).ForEach(d => d.Value = null);
                Helper.GetControls<UltraComboEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
                Helper.GetControls<UltraCheckEditor>(this.ultraPanel1).ForEach(d => d.Checked = false);
            }
        }

        private void ubDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Seguro desea eliminar el presente registro?", Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                    return;

                db.tbl_clientes.Remove(Item);
                db.SaveChanges();

                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Eliminado Satisfactoriamente");

                NuevoItem();
            }
            catch (Exception)
            {

                throw;
            }            
            
        }

        private void ubLimpiar_Click(object sender, EventArgs e)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
            Helper.GetControls<UltraCombo>(this.ultraPanel1).ForEach(d => d.Value = null);
            Helper.GetControls<UltraComboEditor>(this.ultraPanel1).ForEach(d => d.Value = null);
            Helper.GetControls<UltraCheckEditor>(this.ultraPanel1).ForEach(d => d.Checked = false);
        }

        private void uteCorreEENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteAtencionENTE.Focus();
        }

        private void uteUbicacionENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteUbicacionENTE, true, true, true, true);
        }

        private void uteCierreFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteCierreFiscal, true, true, true, true);
        }

        private void OnlyDig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void uteNationalID_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ucTipoExoneracion_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucTipoExoneracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucTipoExoneracion, true, true, true, true);
        }

        private void uckExonerado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckExonerado, true, true, true, true);
        }

        private void uteNumeroExoneracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteNumeroExoneracion, true, true, true, true);
        }

        private void udteFechaExoneracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(udteFechaExoneracion, true, true, true, true);
        }

        private void uteInstitucionExo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteRUC, true, true, true, true);
        }

        private void uneMontoExoneracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneMontoExoneracion, true, true, true, true);
        }

        private void unePorcExoneracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                ubAgregarEnte.Focus();
        }

        private void uteRazonSocial_ValueChanged(object sender, EventArgs e)
        {
            /*if (uteRazonSocial.Value == null) return;

            if (uteRazonSocial.Value.ToString().IndexOf("|") >= 0)
            {
                uteRazonSocial.Value = uteRazonSocial.Value.ToString().Replace("|", "");
                uteRazonSocial.SelectionStart = uteRazonSocial.Value.ToString().Length ;
            }*/
        }

        private void uteRazonSocial_Leave(object sender, EventArgs e)
        {
            if (uteRazonSocial.Value == null) return;

            uteRazonSocial.Value = uteRazonSocial.Value.ToString().Replace("|", "");

        }

        private void uteRazSocENTE_Leave(object sender, EventArgs e)
        {
            if (uteRazSocENTE.Value == null) return;

            uteRazSocENTE.Value = uteRazSocENTE.Value.ToString().Replace("|", "");
        }

        private void uckExonerado_CheckedChanged(object sender, EventArgs e)
        {
            if (!uckExonerado.Checked)
            {
                /*uteNumeroExoneracion.Value = null;
                udteFechaExoneracion.Value = null;
                uteInstitucionExo.Value = null;
                unePorcExoneracion.Value = null;
                */
            }
        }

        private void uceIndustriaENTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uceIndustriaENTE, true, true, true, true);
        }

        private void uceIndustriaENTE_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uceIndustriaENTE_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_industria"].Value.ToString().Trim(), e.Row.Cells["nombre"].Value.ToString().Trim());
        }

        private void ucCondicion_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }
    }
}
