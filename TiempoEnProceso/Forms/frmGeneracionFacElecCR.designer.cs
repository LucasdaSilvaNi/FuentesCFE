namespace TiempoEnProceso.Forms
{
    partial class frmGeneracionFacElecCR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Misc.ValidationGroup validationGroup1 = new Infragistics.Win.Misc.ValidationGroup("required");
            Infragistics.Win.Misc.ValidationGroup validationGroup2 = new Infragistics.Win.Misc.ValidationGroup("requiredFecha");
            Infragistics.Win.Misc.ValidationGroup validationGroup3 = new Infragistics.Win.Misc.ValidationGroup("requiredPeriodo");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_oficina", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("direccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("periodo_proceso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("parametro_reportes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("permite_facturar_en_periodo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_Telefono");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_Fax");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correo_electronico");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("codigo_fiscal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_entidad_legal", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_entidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Razon_social");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NIT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_facturas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_cobranzas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn87 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_notas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn88 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_anulaciones");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn89 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("impuesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn90 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("incluido");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn91 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("formato_facturas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn92 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("financiera");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn93 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ubicacion_factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn94 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn95 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("origen_datos_factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("control_fel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn96 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_tipo_documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn97 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Generar Factura Electrónica", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Mostrar Facturas a Imprimir", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_cuenta_corriente", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_entidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tipo_documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("numero_documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("periodo_tep");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("valor_total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("impuesto_porcentaje");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("impuesto_incluido");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("valor_impuesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("saldo");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("saldo_impuesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("factura_preliminar");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("anticipo_aplicar");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("factura_definitiva");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("concepto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_solicitud");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_job");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tasa_cambio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("flag_impreso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("linea");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("numero_documento_fiscal_electronico");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("clave_electronica");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_documento_sustituye");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lenguaje_Impresion_spanish1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("valor_total_moneda_local");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("fecha_timbrado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("numero_documento_fiscal_electronico_cobro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("clave_electronica_cobro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tipo_documento_fiscal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_certificacion_documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_cuenta_corriente_gestion_cobro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("edit", 0);
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneracionFacElecCR));
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("delete", 1);
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("select", 2);
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("cliente", 3);
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ucOficce = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tbloficinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucTipoSolicitud = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.splistatipoFElectronicaCRResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucEntidad = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tblentidadlegalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ubConsultar = new Infragistics.Win.Misc.UltraButton();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ugData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tblcuentacorrienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.periodoENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sptextfelectronicaCRResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblentessolicitudBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.periodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucOficce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTipoSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splistatipoFElectronicaCRResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcuentacorrienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptextfelectronicaCRResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentessolicitudBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uvValidador
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.exclamation;
            this.uvValidador.ErrorAppearance = appearance1;
            this.uvValidador.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.Asterisk;
            this.uvValidador.NotificationSettings.Action = Infragistics.Win.Misc.NotificationAction.None;
            validationGroup1.Key = "required";
            validationGroup2.Enabled = false;
            validationGroup2.Key = "requiredFecha";
            validationGroup3.Enabled = false;
            validationGroup3.Key = "requiredPeriodo";
            this.uvValidador.ValidationGroups.Add(validationGroup1);
            this.uvValidador.ValidationGroups.Add(validationGroup2);
            this.uvValidador.ValidationGroups.Add(validationGroup3);
            this.uvValidador.ValidationTrigger = Infragistics.Win.Misc.ValidationTrigger.OnPropertyValueChanged;
            // 
            // ucOficce
            // 
            this.ucOficce.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucOficce.DataSource = this.tbloficinaBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucOficce.DisplayLayout.Appearance = appearance2;
            this.ucOficce.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn67.Header.Editor = null;
            ultraGridColumn67.Header.VisiblePosition = 0;
            ultraGridColumn67.Hidden = true;
            ultraGridColumn68.Header.Editor = null;
            ultraGridColumn68.Header.VisiblePosition = 2;
            ultraGridColumn68.Hidden = true;
            ultraGridColumn69.Header.Editor = null;
            ultraGridColumn69.Header.VisiblePosition = 3;
            ultraGridColumn69.Hidden = true;
            ultraGridColumn70.Header.Editor = null;
            ultraGridColumn70.Header.VisiblePosition = 4;
            ultraGridColumn70.Hidden = true;
            ultraGridColumn71.Header.Editor = null;
            ultraGridColumn71.Header.VisiblePosition = 1;
            ultraGridColumn71.Hidden = true;
            ultraGridColumn72.Header.Editor = null;
            ultraGridColumn72.Header.VisiblePosition = 5;
            ultraGridColumn72.Hidden = true;
            ultraGridColumn73.Header.Editor = null;
            ultraGridColumn73.Header.VisiblePosition = 6;
            ultraGridColumn73.Hidden = true;
            ultraGridColumn74.Header.Editor = null;
            ultraGridColumn74.Header.VisiblePosition = 7;
            ultraGridColumn74.Hidden = true;
            ultraGridColumn75.Header.Editor = null;
            ultraGridColumn75.Header.VisiblePosition = 8;
            ultraGridColumn76.Header.Editor = null;
            ultraGridColumn76.Header.VisiblePosition = 9;
            ultraGridColumn77.Header.Editor = null;
            ultraGridColumn77.Header.VisiblePosition = 11;
            ultraGridColumn78.Header.Editor = null;
            ultraGridColumn78.Header.VisiblePosition = 12;
            ultraGridColumn79.Header.Caption = "Oficina";
            ultraGridColumn79.Header.Editor = null;
            ultraGridColumn79.Header.VisiblePosition = 10;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72,
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76,
            ultraGridColumn77,
            ultraGridColumn78,
            ultraGridColumn79});
            this.ucOficce.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucOficce.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucOficce.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.ucOficce.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucOficce.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucOficce.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucOficce.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.ucOficce.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ucOficce.DisplayLayout.MaxBandDepth = 1;
            this.ucOficce.DisplayLayout.MaxColScrollRegions = 1;
            this.ucOficce.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucOficce.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucOficce.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.ucOficce.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucOficce.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.ucOficce.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucOficce.DisplayLayout.Override.CellAppearance = appearance9;
            this.ucOficce.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucOficce.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.ucOficce.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.ucOficce.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ucOficce.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucOficce.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ucOficce.DisplayLayout.Override.RowAppearance = appearance12;
            this.ucOficce.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucOficce.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ucOficce.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucOficce.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucOficce.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucOficce.DisplayMember = "Nombre";
            this.ucOficce.Enabled = false;
            this.ucOficce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucOficce.LimitToList = true;
            this.ucOficce.Location = new System.Drawing.Point(109, 10);
            this.ucOficce.Name = "ucOficce";
            this.ucOficce.Size = new System.Drawing.Size(330, 22);
            this.ucOficce.TabIndex = 53;
            this.uvValidador.GetValidationSettings(this.ucOficce).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucOficce).NotificationSettings.Text = "Oficina Invalida";
            this.uvValidador.GetValidationSettings(this.ucOficce).ValidationGroupKey = "required";
            this.ucOficce.ValueMember = "id_oficina";
            this.ucOficce.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucOficce_InitializeRow);
            // 
            // tbloficinaBindingSource
            // 
            this.tbloficinaBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_oficina);
            // 
            // ucTipoSolicitud
            // 
            this.ucTipoSolicitud.DataSource = this.splistatipoFElectronicaCRResultBindingSource;
            this.ucTipoSolicitud.DisplayMember = "id_tipo_documento";
            this.ucTipoSolicitud.Location = new System.Drawing.Point(109, 65);
            this.ucTipoSolicitud.Name = "ucTipoSolicitud";
            this.ucTipoSolicitud.Size = new System.Drawing.Size(116, 21);
            this.ucTipoSolicitud.TabIndex = 1;
            this.uvValidador.GetValidationSettings(this.ucTipoSolicitud).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucTipoSolicitud).NotificationSettings.Text = "Selección Tipo Documento Invalida";
            this.uvValidador.GetValidationSettings(this.ucTipoSolicitud).ValidationGroupKey = "required";
            this.ucTipoSolicitud.ValueMember = "id_tipo_documento";
            this.ucTipoSolicitud.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucTipoSolicitud_KeyDown);
            // 
            // splistatipoFElectronicaCRResultBindingSource
            // 
            this.splistatipoFElectronicaCRResultBindingSource.DataSource = typeof(TiempoEnProcesoDL.sp_lista_tipo_FElectronicaCR_Result);
            // 
            // ucEntidad
            // 
            this.ucEntidad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucEntidad.DataSource = this.tblentidadlegalBindingSource;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucEntidad.DisplayLayout.Appearance = appearance14;
            this.ucEntidad.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn80.Header.Editor = null;
            ultraGridColumn80.Header.VisiblePosition = 0;
            ultraGridColumn80.Hidden = true;
            ultraGridColumn81.Header.Editor = null;
            ultraGridColumn81.Header.VisiblePosition = 1;
            ultraGridColumn81.Hidden = true;
            ultraGridColumn82.Header.Editor = null;
            ultraGridColumn82.Header.VisiblePosition = 2;
            ultraGridColumn82.Hidden = true;
            ultraGridColumn83.Header.Editor = null;
            ultraGridColumn83.Header.VisiblePosition = 4;
            ultraGridColumn83.Hidden = true;
            ultraGridColumn84.Header.Editor = null;
            ultraGridColumn84.Header.VisiblePosition = 5;
            ultraGridColumn84.Hidden = true;
            ultraGridColumn85.Header.Editor = null;
            ultraGridColumn85.Header.VisiblePosition = 6;
            ultraGridColumn85.Hidden = true;
            ultraGridColumn86.Header.Editor = null;
            ultraGridColumn86.Header.VisiblePosition = 7;
            ultraGridColumn86.Hidden = true;
            ultraGridColumn87.Header.Editor = null;
            ultraGridColumn87.Header.VisiblePosition = 8;
            ultraGridColumn87.Hidden = true;
            ultraGridColumn88.Header.Editor = null;
            ultraGridColumn88.Header.VisiblePosition = 9;
            ultraGridColumn88.Hidden = true;
            ultraGridColumn89.Header.Editor = null;
            ultraGridColumn89.Header.VisiblePosition = 10;
            ultraGridColumn89.Hidden = true;
            ultraGridColumn90.Header.Editor = null;
            ultraGridColumn90.Header.VisiblePosition = 11;
            ultraGridColumn90.Hidden = true;
            ultraGridColumn91.Header.Editor = null;
            ultraGridColumn91.Header.VisiblePosition = 12;
            ultraGridColumn91.Hidden = true;
            ultraGridColumn92.Header.Editor = null;
            ultraGridColumn92.Header.VisiblePosition = 13;
            ultraGridColumn92.Hidden = true;
            ultraGridColumn93.Header.Editor = null;
            ultraGridColumn93.Header.VisiblePosition = 14;
            ultraGridColumn93.Hidden = true;
            ultraGridColumn94.Header.Editor = null;
            ultraGridColumn94.Header.VisiblePosition = 15;
            ultraGridColumn94.Hidden = true;
            ultraGridColumn95.Header.Editor = null;
            ultraGridColumn95.Header.VisiblePosition = 16;
            ultraGridColumn95.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 17;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn96.Header.Editor = null;
            ultraGridColumn96.Header.VisiblePosition = 18;
            ultraGridColumn97.Header.Caption = "Entidad";
            ultraGridColumn97.Header.Editor = null;
            ultraGridColumn97.Header.VisiblePosition = 3;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82,
            ultraGridColumn83,
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn86,
            ultraGridColumn87,
            ultraGridColumn88,
            ultraGridColumn89,
            ultraGridColumn90,
            ultraGridColumn91,
            ultraGridColumn92,
            ultraGridColumn93,
            ultraGridColumn94,
            ultraGridColumn95,
            ultraGridColumn8,
            ultraGridColumn96,
            ultraGridColumn97});
            this.ucEntidad.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ucEntidad.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucEntidad.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.BorderColor = System.Drawing.SystemColors.Window;
            this.ucEntidad.DisplayLayout.GroupByBox.Appearance = appearance15;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucEntidad.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.ucEntidad.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance17.BackColor2 = System.Drawing.SystemColors.Control;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucEntidad.DisplayLayout.GroupByBox.PromptAppearance = appearance17;
            this.ucEntidad.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ucEntidad.DisplayLayout.MaxBandDepth = 1;
            this.ucEntidad.DisplayLayout.MaxColScrollRegions = 1;
            this.ucEntidad.DisplayLayout.MaxRowScrollRegions = 1;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucEntidad.DisplayLayout.Override.ActiveCellAppearance = appearance18;
            appearance19.BackColor = System.Drawing.SystemColors.Highlight;
            appearance19.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucEntidad.DisplayLayout.Override.ActiveRowAppearance = appearance19;
            this.ucEntidad.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucEntidad.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            this.ucEntidad.DisplayLayout.Override.CardAreaAppearance = appearance20;
            appearance21.BorderColor = System.Drawing.Color.Silver;
            appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucEntidad.DisplayLayout.Override.CellAppearance = appearance21;
            this.ucEntidad.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucEntidad.DisplayLayout.Override.CellPadding = 0;
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance22.BorderColor = System.Drawing.SystemColors.Window;
            this.ucEntidad.DisplayLayout.Override.GroupByRowAppearance = appearance22;
            appearance23.TextHAlignAsString = "Left";
            this.ucEntidad.DisplayLayout.Override.HeaderAppearance = appearance23;
            this.ucEntidad.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucEntidad.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            appearance24.BorderColor = System.Drawing.Color.Silver;
            this.ucEntidad.DisplayLayout.Override.RowAppearance = appearance24;
            this.ucEntidad.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucEntidad.DisplayLayout.Override.TemplateAddRowAppearance = appearance25;
            this.ucEntidad.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucEntidad.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucEntidad.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucEntidad.DisplayMember = "Razon_social";
            this.ucEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucEntidad.LimitToList = true;
            this.ucEntidad.Location = new System.Drawing.Point(109, 37);
            this.ucEntidad.Name = "ucEntidad";
            this.ucEntidad.Size = new System.Drawing.Size(330, 22);
            this.ucEntidad.TabIndex = 0;
            this.ucEntidad.ValueMember = "id_entidad";
            this.ucEntidad.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucEntidad_InitializeRow);
            this.ucEntidad.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucEntidad_ItemNotInList);
            this.ucEntidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucEntidad_KeyDown);
            // 
            // tblentidadlegalBindingSource
            // 
            this.tblentidadlegalBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_entidad_legal);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ubAgregar
            // 
            appearance32.Image = global::TiempoEnProceso.Properties.Resources.services;
            appearance32.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance32.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance32;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(602, 62);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(90, 40);
            this.ubAgregar.TabIndex = 2;
            this.ubAgregar.Text = "Generar";
            ultraToolTipInfo3.ToolTipText = "Generar Factura Electrónica";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregar, ultraToolTipInfo3);
            this.ubAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregar.Click += new System.EventHandler(this.ubAgregar_Click);
            // 
            // ubCerrar
            // 
            appearance31.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance31.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance31.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance31;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(602, 108);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(90, 40);
            this.ubCerrar.TabIndex = 3;
            this.ubCerrar.Text = "Cancelar";
            ultraToolTipInfo2.ToolTipText = "Cancelar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubCerrar, ultraToolTipInfo2);
            this.ubCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubCerrar.Click += new System.EventHandler(this.ubCerrar_Click);
            // 
            // ubConsultar
            // 
            appearance30.Image = global::TiempoEnProceso.Properties.Resources.View_Details;
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance30.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubConsultar.Appearance = appearance30;
            this.ubConsultar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubConsultar.Location = new System.Drawing.Point(602, 10);
            this.ubConsultar.Name = "ubConsultar";
            this.ubConsultar.ShowOutline = false;
            this.ubConsultar.Size = new System.Drawing.Size(90, 40);
            this.ubConsultar.TabIndex = 50;
            this.ubConsultar.Text = "Detalle";
            ultraToolTipInfo1.ToolTipText = "Mostrar Facturas a Imprimir";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubConsultar, ultraToolTipInfo1);
            this.ubConsultar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubConsultar.Click += new System.EventHandler(this.ubConsultar_Click);
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // _frmGeneracionFactura_UltraFormManager_Dock_Area_Left
            // 
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 32);
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.Name = "_frmGeneracionFactura_UltraFormManager_Dock_Area_Left";
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 285);
            // 
            // _frmGeneracionFactura_UltraFormManager_Dock_Area_Right
            // 
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(706, 32);
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.Name = "_frmGeneracionFactura_UltraFormManager_Dock_Area_Right";
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 285);
            // 
            // _frmGeneracionFactura_UltraFormManager_Dock_Area_Top
            // 
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.Name = "_frmGeneracionFactura_UltraFormManager_Dock_Area_Top";
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(714, 32);
            // 
            // _frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 317);
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.Name = "_frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom";
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(714, 8);
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.ucTipoSolicitud);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel13);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel5);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucOficce);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraPanel1);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubConsultar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucEntidad);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(698, 285);
            this.ultraPanel3.TabIndex = 3;
            this.ultraPanel3.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel3_PaintClient);
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.AutoSize = true;
            this.ultraLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel13.Location = new System.Drawing.Point(25, 69);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(31, 14);
            this.ultraLabel13.TabIndex = 59;
            this.ultraLabel13.Text = "Tipo:";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(25, 15);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(45, 14);
            this.ultraLabel5.TabIndex = 54;
            this.ultraLabel5.Text = "Oficina:";
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ugData);
            this.ultraPanel1.Location = new System.Drawing.Point(6, 90);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(580, 183);
            this.ultraPanel1.TabIndex = 52;
            // 
            // ugData
            // 
            this.ugData.DataSource = this.tblcuentacorrienteBindingSource;
            this.ugData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 6;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 7;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 9;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn37.Header.Caption = "Documento";
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 3;
            ultraGridColumn37.Width = 86;
            ultraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 12;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn39.Header.Caption = "Fecha";
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 4;
            ultraGridColumn39.Width = 88;
            ultraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn40.Header.Caption = "Valor Total";
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 5;
            ultraGridColumn40.Width = 97;
            ultraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 15;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 16;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 17;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance26.TextHAlignAsString = "Right";
            ultraGridColumn44.CellAppearance = appearance26;
            ultraGridColumn44.Header.Caption = "Saldo";
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 14;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn44.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Double;
            ultraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn45.Header.Editor = null;
            ultraGridColumn45.Header.VisiblePosition = 18;
            ultraGridColumn45.Hidden = true;
            ultraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn46.Header.Editor = null;
            ultraGridColumn46.Header.VisiblePosition = 19;
            ultraGridColumn46.Hidden = true;
            ultraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn47.Header.Editor = null;
            ultraGridColumn47.Header.VisiblePosition = 20;
            ultraGridColumn47.Hidden = true;
            ultraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn48.Header.Editor = null;
            ultraGridColumn48.Header.VisiblePosition = 21;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn49.Header.Editor = null;
            ultraGridColumn49.Header.VisiblePosition = 22;
            ultraGridColumn49.Hidden = true;
            ultraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn50.Header.Caption = "Solicitud";
            ultraGridColumn50.Header.Editor = null;
            ultraGridColumn50.Header.VisiblePosition = 10;
            ultraGridColumn50.Hidden = true;
            ultraGridColumn50.MaxWidth = 100;
            ultraGridColumn50.MinWidth = 100;
            ultraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn51.Header.Editor = null;
            ultraGridColumn51.Header.VisiblePosition = 23;
            ultraGridColumn51.Hidden = true;
            ultraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn52.Header.Caption = "Cliente";
            ultraGridColumn52.Header.Editor = null;
            ultraGridColumn52.Header.VisiblePosition = 2;
            ultraGridColumn52.Hidden = true;
            ultraGridColumn52.Width = 237;
            ultraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn53.Header.Editor = null;
            ultraGridColumn53.Header.VisiblePosition = 24;
            ultraGridColumn53.Hidden = true;
            ultraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn54.Header.Editor = null;
            ultraGridColumn54.Header.VisiblePosition = 27;
            ultraGridColumn54.Hidden = true;
            ultraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn55.Header.Editor = null;
            ultraGridColumn55.Header.VisiblePosition = 35;
            ultraGridColumn55.Hidden = true;
            ultraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn56.Header.Caption = "Emitir a:";
            ultraGridColumn56.Header.Editor = null;
            ultraGridColumn56.Header.VisiblePosition = 11;
            ultraGridColumn56.Hidden = true;
            ultraGridColumn56.MaxWidth = 100;
            ultraGridColumn56.MinWidth = 100;
            ultraGridColumn57.Header.Editor = null;
            ultraGridColumn57.Header.VisiblePosition = 25;
            ultraGridColumn57.Hidden = true;
            ultraGridColumn58.Header.Editor = null;
            ultraGridColumn58.Header.VisiblePosition = 34;
            ultraGridColumn58.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 29;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 26;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 28;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 31;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 30;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 33;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 32;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn59.Header.Editor = null;
            ultraGridColumn59.Header.VisiblePosition = 36;
            ultraGridColumn59.Hidden = true;
            ultraGridColumn60.Header.Editor = null;
            ultraGridColumn60.Header.VisiblePosition = 37;
            ultraGridColumn61.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn61.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance27.Image = ((object)(resources.GetObject("appearance27.Image")));
            ultraGridColumn61.CellButtonAppearance = appearance27;
            ultraGridColumn61.Header.Caption = "";
            ultraGridColumn61.Header.Editor = null;
            ultraGridColumn61.Header.VisiblePosition = 8;
            ultraGridColumn61.Hidden = true;
            ultraGridColumn61.MaxWidth = 20;
            ultraGridColumn61.MinLength = 14;
            ultraGridColumn61.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn61.Width = 20;
            ultraGridColumn62.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn62.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance28.Image = ((object)(resources.GetObject("appearance28.Image")));
            ultraGridColumn62.CellButtonAppearance = appearance28;
            ultraGridColumn62.Header.Caption = "";
            ultraGridColumn62.Header.Editor = null;
            ultraGridColumn62.Header.VisiblePosition = 13;
            ultraGridColumn62.Hidden = true;
            ultraGridColumn62.MaxWidth = 20;
            ultraGridColumn62.MinWidth = 14;
            ultraGridColumn62.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn62.Tag = "B_BANCOS";
            ultraGridColumn62.Width = 20;
            appearance29.TextHAlignAsString = "Center";
            ultraGridColumn63.CellAppearance = appearance29;
            ultraGridColumn63.Header.Caption = "Sel";
            ultraGridColumn63.Header.CheckBoxAlignment = Infragistics.Win.UltraWinGrid.HeaderCheckBoxAlignment.Center;
            ultraGridColumn63.Header.CheckBoxSynchronization = Infragistics.Win.UltraWinGrid.HeaderCheckBoxSynchronization.RowsCollection;
            ultraGridColumn63.Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.WhenUsingCheckEditor;
            ultraGridColumn63.Header.Editor = null;
            ultraGridColumn63.Header.VisiblePosition = 0;
            ultraGridColumn63.MaxWidth = 50;
            ultraGridColumn63.MinWidth = 50;
            ultraGridColumn63.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn63.Width = 50;
            ultraGridColumn64.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn64.Header.Caption = "Cliente";
            ultraGridColumn64.Header.Editor = null;
            ultraGridColumn64.Header.VisiblePosition = 1;
            ultraGridColumn64.Width = 221;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38,
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52,
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58,
            ultraGridColumn2,
            ultraGridColumn1,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62,
            ultraGridColumn63,
            ultraGridColumn64});
            this.ugData.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.ugData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ugData.DisplayLayout.MaxBandDepth = 1;
            this.ugData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ugData.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.ugData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.ugData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ugData.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ugData.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugData.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ugData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ugData.Location = new System.Drawing.Point(0, 0);
            this.ugData.Name = "ugData";
            this.ugData.Size = new System.Drawing.Size(580, 183);
            this.ugData.TabIndex = 51;
            this.ugData.Text = "ultraGrid1";
            this.ugData.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ugData_InitializeRow);
            this.ugData.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugData_ClickCellButton);
            // 
            // tblcuentacorrienteBindingSource
            // 
            this.tblcuentacorrienteBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_cuenta_corriente);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(25, 41);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel6.TabIndex = 46;
            this.ultraLabel6.Text = "Entidad:";
            // 
            // periodoENBindingSource
            // 
            this.periodoENBindingSource.DataSource = typeof(TiempoEnProcesoEN.PeriodoEN);
            // 
            // sptextfelectronicaCRResultBindingSource
            // 
            this.sptextfelectronicaCRResultBindingSource.DataSource = typeof(TiempoEnProcesoDL.sp_text_felectronica_CR_Result);
            // 
            // tblentessolicitudBindingSource
            // 
            this.tblentessolicitudBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_entes_solicitud);
            // 
            // periodoBindingSource
            // 
            this.periodoBindingSource.DataSource = typeof(TiempoEnProcesoDL.Periodo);
            // 
            // frmGeneracionFacElecCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 325);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGeneracionFacElecCR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generacion Documento Electrónico";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucOficce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTipoSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splistatipoFElectronicaCRResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcuentacorrienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptextfelectronicaCRResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentessolicitudBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraValidator uvValidador;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmGeneracionFactura_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmGeneracionFactura_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmGeneracionFactura_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom;
        private System.Windows.Forms.BindingSource periodoBindingSource;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Infragistics.Win.Misc.UltraButton ubCerrar;
        private Infragistics.Win.Misc.UltraButton ubAgregar;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucEntidad;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private System.Windows.Forms.BindingSource tblentidadlegalBindingSource;
        private System.Windows.Forms.BindingSource periodoENBindingSource;
        private Infragistics.Win.Misc.UltraButton ubConsultar;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugData;
        private System.Windows.Forms.BindingSource tblentessolicitudBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucOficce;
        private System.Windows.Forms.BindingSource tbloficinaBindingSource;
        private System.Windows.Forms.BindingSource tblcuentacorrienteBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucTipoSolicitud;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private System.Windows.Forms.BindingSource sptextfelectronicaCRResultBindingSource;
        private System.Windows.Forms.BindingSource splistatipoFElectronicaCRResultBindingSource;
    }
}