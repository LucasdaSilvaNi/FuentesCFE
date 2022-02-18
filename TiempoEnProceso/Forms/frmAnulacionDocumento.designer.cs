namespace TiempoEnProceso.Forms
{
    partial class frmAnulacionDocumento
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
            Infragistics.Win.Misc.ValidationGroup validationGroup2 = new Infragistics.Win.Misc.ValidationGroup("requeAnu");
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_entidad_legal", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_entidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Razon_social");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NIT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_facturas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_cobranzas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_notas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_anulaciones");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("impuesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("incluido");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("formato_facturas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("financiera");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ubicacion_factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("origen_datos_factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("control_fel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Acceso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Api");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Certificado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Formato_FEL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_tipo_documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_frases");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_tipo_documento", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Count");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsReadOnly");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_frases", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Count");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsReadOnly");
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
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ejecución de Proceso de Cierre", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Ejecución de Proceso de Cierre", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("AnulacionDoctoEN", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_entidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("total");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("razon_social");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tipo_docto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tipo_docto_descripcion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("documento_electronico");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("edit", 0);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnulacionDocumento));
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("delete", 1);
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.udteFecha = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uteCliente = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uneTotalSol = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uneDocumento = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ucTipoSolicitud = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.udteFechaAnulacion = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uteAutorizo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteMotivo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteTipo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ucEntidad = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tblentidadlegalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uteDoctoElect = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
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
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ugData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.anulacionDoctoENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.anulacionSolicitudENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblcuentacorrienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneTotalSol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTipoSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFechaAnulacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteAutorizo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteMotivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDoctoElect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anulacionDoctoENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anulacionSolicitudENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcuentacorrienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uvValidador
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.exclamation;
            this.uvValidador.ErrorAppearance = appearance1;
            this.uvValidador.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.Asterisk;
            this.uvValidador.NotificationSettings.Action = Infragistics.Win.Misc.NotificationAction.None;
            validationGroup1.Key = "required";
            validationGroup2.Key = "requeAnu";
            this.uvValidador.ValidationGroups.Add(validationGroup1);
            this.uvValidador.ValidationGroups.Add(validationGroup2);
            this.uvValidador.ValidationTrigger = Infragistics.Win.Misc.ValidationTrigger.OnPropertyValueChanged;
            // 
            // udteFecha
            // 
            this.udteFecha.Enabled = false;
            this.udteFecha.Location = new System.Drawing.Point(365, 92);
            this.udteFecha.Name = "udteFecha";
            this.udteFecha.Size = new System.Drawing.Size(106, 21);
            this.udteFecha.TabIndex = 6;
            this.uvValidador.GetValidationSettings(this.udteFecha).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.udteFecha).NotificationSettings.Text = "Fecha Invalida";
            this.uvValidador.GetValidationSettings(this.udteFecha).ValidationGroupKey = "requeAnu";
            // 
            // uteCliente
            // 
            this.uteCliente.Enabled = false;
            this.uteCliente.Location = new System.Drawing.Point(103, 10);
            this.uteCliente.MaxLength = 100;
            this.uteCliente.Name = "uteCliente";
            this.uteCliente.Size = new System.Drawing.Size(540, 21);
            this.uteCliente.TabIndex = 2;
            this.uvValidador.GetValidationSettings(this.uteCliente).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteCliente).NotificationSettings.Text = "Descripción Invalida";
            this.uvValidador.GetValidationSettings(this.uteCliente).ValidationGroupKey = "requeAnu";
            // 
            // uneTotalSol
            // 
            this.uneTotalSol.Enabled = false;
            this.uneTotalSol.Location = new System.Drawing.Point(103, 92);
            this.uneTotalSol.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneTotalSol.MaskInput = "-nnnnnnnn.nn";
            this.uneTotalSol.MinValue = 0;
            this.uneTotalSol.Name = "uneTotalSol";
            this.uneTotalSol.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneTotalSol.Size = new System.Drawing.Size(106, 21);
            this.uneTotalSol.TabIndex = 5;
            this.uvValidador.GetValidationSettings(this.uneTotalSol).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneTotalSol).NotificationSettings.Text = "Valor Invalido";
            this.uvValidador.GetValidationSettings(this.uneTotalSol).ValidationGroupKey = "requeAnu";
            // 
            // uneDocumento
            // 
            this.uneDocumento.Enabled = false;
            this.uneDocumento.Location = new System.Drawing.Point(103, 65);
            this.uneDocumento.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneDocumento.MaskInput = "nnnnnnnnn";
            this.uneDocumento.MinValue = 0;
            this.uneDocumento.Name = "uneDocumento";
            this.uneDocumento.Size = new System.Drawing.Size(106, 21);
            this.uneDocumento.TabIndex = 3;
            this.uvValidador.GetValidationSettings(this.uneDocumento).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneDocumento).NotificationSettings.Text = "Valor Invalido";
            this.uvValidador.GetValidationSettings(this.uneDocumento).ValidationGroupKey = "requeAnu";
            // 
            // ucTipoSolicitud
            // 
            valueListItem3.DataValue = "FAC";
            valueListItem3.DisplayText = "FACTURA";
            valueListItem1.DataValue = "NOTA/CREDITO";
            valueListItem1.DisplayText = "NOTA CREDITO";
            valueListItem2.DataValue = "COBRANZA";
            valueListItem2.DisplayText = "COBRANZA";
            this.ucTipoSolicitud.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem1,
            valueListItem2});
            this.ucTipoSolicitud.Location = new System.Drawing.Point(109, 35);
            this.ucTipoSolicitud.Name = "ucTipoSolicitud";
            this.ucTipoSolicitud.Size = new System.Drawing.Size(116, 21);
            this.ucTipoSolicitud.TabIndex = 1;
            this.uvValidador.GetValidationSettings(this.ucTipoSolicitud).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucTipoSolicitud).NotificationSettings.Text = "Selección Tipo Documento Invalida";
            this.uvValidador.GetValidationSettings(this.ucTipoSolicitud).ValidationGroupKey = "required";
            this.ucTipoSolicitud.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucTipoSolicitud_KeyDown);
            // 
            // udteFechaAnulacion
            // 
            this.udteFechaAnulacion.Location = new System.Drawing.Point(104, 50);
            this.udteFechaAnulacion.Name = "udteFechaAnulacion";
            this.udteFechaAnulacion.Size = new System.Drawing.Size(106, 21);
            this.udteFechaAnulacion.TabIndex = 7;
            this.uvValidador.GetValidationSettings(this.udteFechaAnulacion).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.udteFechaAnulacion).NotificationSettings.Text = "Fecha Invalida";
            this.uvValidador.GetValidationSettings(this.udteFechaAnulacion).ValidationGroupKey = "requeAnu";
            // 
            // uteAutorizo
            // 
            this.uteAutorizo.Location = new System.Drawing.Point(104, 5);
            this.uteAutorizo.MaxLength = 200;
            this.uteAutorizo.Multiline = true;
            this.uteAutorizo.Name = "uteAutorizo";
            this.uteAutorizo.Size = new System.Drawing.Size(387, 39);
            this.uteAutorizo.TabIndex = 6;
            this.uvValidador.GetValidationSettings(this.uteAutorizo).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteAutorizo).NotificationSettings.Text = "Autorizador Invalido";
            this.uvValidador.GetValidationSettings(this.uteAutorizo).ValidationGroupKey = "requeAnu";
            this.uteAutorizo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteAutorizo_KeyDown);
            // 
            // uteMotivo
            // 
            this.uteMotivo.Location = new System.Drawing.Point(103, 77);
            this.uteMotivo.MaxLength = 80;
            this.uteMotivo.Multiline = true;
            this.uteMotivo.Name = "uteMotivo";
            this.uteMotivo.Size = new System.Drawing.Size(540, 38);
            this.uteMotivo.TabIndex = 8;
            this.uvValidador.GetValidationSettings(this.uteMotivo).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteMotivo).NotificationSettings.Text = "Motivo Anulación Invalido";
            this.uvValidador.GetValidationSettings(this.uteMotivo).ValidationGroupKey = "requeAnu";
            this.uteMotivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteMotivo_KeyDown);
            // 
            // uteTipo
            // 
            this.uteTipo.Enabled = false;
            this.uteTipo.Location = new System.Drawing.Point(103, 37);
            this.uteTipo.MaxLength = 100;
            this.uteTipo.Name = "uteTipo";
            this.uteTipo.Size = new System.Drawing.Size(329, 21);
            this.uteTipo.TabIndex = 59;
            this.uvValidador.GetValidationSettings(this.uteTipo).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteTipo).NotificationSettings.Text = "Descripción Invalida";
            this.uvValidador.GetValidationSettings(this.uteTipo).ValidationGroupKey = "requeAnu";
            // 
            // ucEntidad
            // 
            this.ucEntidad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucEntidad.DataSource = this.tblentidadlegalBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucEntidad.DisplayLayout.Appearance = appearance2;
            this.ucEntidad.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 9;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 10;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 11;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 12;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 13;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 14;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 15;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 16;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 17;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 18;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 19;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 20;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 21;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 22;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 23;
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 24;
            ultraGridColumn39.Header.Caption = "Entidad";
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 3;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn34,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn38,
            ultraGridColumn33,
            ultraGridColumn39});
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 0;
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 1;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn40,
            ultraGridColumn41});
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 0;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 1;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn35,
            ultraGridColumn36});
            this.ucEntidad.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucEntidad.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ucEntidad.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.ucEntidad.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucEntidad.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.ucEntidad.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucEntidad.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucEntidad.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucEntidad.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.ucEntidad.DisplayLayout.MaxColScrollRegions = 1;
            this.ucEntidad.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucEntidad.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucEntidad.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.ucEntidad.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucEntidad.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.ucEntidad.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucEntidad.DisplayLayout.Override.CellAppearance = appearance9;
            this.ucEntidad.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucEntidad.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.ucEntidad.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.ucEntidad.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ucEntidad.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucEntidad.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ucEntidad.DisplayLayout.Override.RowAppearance = appearance12;
            this.ucEntidad.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucEntidad.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ucEntidad.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucEntidad.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucEntidad.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucEntidad.DisplayMember = "Razon_social";
            this.ucEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucEntidad.LimitToList = true;
            this.ucEntidad.Location = new System.Drawing.Point(109, 10);
            this.ucEntidad.Name = "ucEntidad";
            this.ucEntidad.Size = new System.Drawing.Size(412, 22);
            this.ucEntidad.TabIndex = 0;
            this.uvValidador.GetValidationSettings(this.ucEntidad).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucEntidad).NotificationSettings.Text = "Selección de Entidad Invalida";
            this.uvValidador.GetValidationSettings(this.ucEntidad).ValidationGroupKey = "required";
            this.ucEntidad.ValueMember = "id_entidad";
            this.ucEntidad.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucEntidad_InitializeRow);
            this.ucEntidad.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucEntidad_ItemNotInList);
            this.ucEntidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucEntidad_KeyDown);
            // 
            // tblentidadlegalBindingSource
            // 
            this.tblentidadlegalBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_entidad_legal);
            // 
            // uteDoctoElect
            // 
            this.uteDoctoElect.Enabled = false;
            this.uteDoctoElect.Location = new System.Drawing.Point(365, 65);
            this.uteDoctoElect.MaxLength = 0;
            this.uteDoctoElect.Name = "uteDoctoElect";
            this.uteDoctoElect.Size = new System.Drawing.Size(278, 21);
            this.uteDoctoElect.TabIndex = 4;
            this.uteDoctoElect.Visible = false;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ubAgregar
            // 
            appearance18.Image = global::TiempoEnProceso.Properties.Resources.services;
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance18.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance18;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(687, 62);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(90, 40);
            this.ubAgregar.TabIndex = 2;
            this.ubAgregar.Text = "Anular";
            ultraToolTipInfo3.ToolTipText = "Ejecución de Proceso de Cierre";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregar, ultraToolTipInfo3);
            this.ubAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregar.Click += new System.EventHandler(this.ubAgregar_Click);
            // 
            // ubCerrar
            // 
            appearance17.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance17;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(687, 108);
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
            appearance16.Image = global::TiempoEnProceso.Properties.Resources.View_Details;
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubConsultar.Appearance = appearance16;
            this.ubConsultar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubConsultar.Location = new System.Drawing.Point(687, 10);
            this.ubConsultar.Name = "ubConsultar";
            this.ubConsultar.ShowOutline = false;
            this.ubConsultar.Size = new System.Drawing.Size(90, 40);
            this.ubConsultar.TabIndex = 50;
            this.ubConsultar.Text = "Detalle";
            ultraToolTipInfo1.ToolTipText = "Ejecución de Proceso de Cierre";
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
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 592);
            // 
            // _frmGeneracionFactura_UltraFormManager_Dock_Area_Right
            // 
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(807, 32);
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.Name = "_frmGeneracionFactura_UltraFormManager_Dock_Area_Right";
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 592);
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
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(815, 32);
            // 
            // _frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 624);
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.Name = "_frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom";
            this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(815, 8);
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraPanel4);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucTipoSolicitud);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel13);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraPanel2);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraPanel1);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubConsultar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucEntidad);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(799, 592);
            this.ultraPanel3.TabIndex = 3;
            this.ultraPanel3.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel3_PaintClient);
            // 
            // ultraPanel4
            // 
            // 
            // ultraPanel4.ClientArea
            // 
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel7);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteMotivo);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel5);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteAutorizo);
            this.ultraPanel4.ClientArea.Controls.Add(this.udteFechaAnulacion);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel4);
            this.ultraPanel4.Location = new System.Drawing.Point(6, 193);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(666, 125);
            this.ultraPanel4.TabIndex = 60;
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel7.Location = new System.Drawing.Point(18, 80);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(42, 14);
            this.ultraLabel7.TabIndex = 62;
            this.ultraLabel7.Text = "Motivo:";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(19, 9);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(51, 14);
            this.ultraLabel5.TabIndex = 60;
            this.ultraLabel5.Text = "Autorizo:";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(18, 48);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(65, 28);
            this.ultraLabel4.TabIndex = 58;
            this.ultraLabel4.Text = "Fecha Anulación:";
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.AutoSize = true;
            this.ultraLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel13.Location = new System.Drawing.Point(24, 39);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(64, 14);
            this.ultraLabel13.TabIndex = 59;
            this.ultraLabel13.Text = "Tipo Docto:";
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.uteDoctoElect);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraLabel9);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraLabel8);
            this.ultraPanel2.ClientArea.Controls.Add(this.uteTipo);
            this.ultraPanel2.ClientArea.Controls.Add(this.uneDocumento);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraLabel2);
            this.ultraPanel2.ClientArea.Controls.Add(this.udteFecha);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraLabel3);
            this.ultraPanel2.ClientArea.Controls.Add(this.uteCliente);
            this.ultraPanel2.ClientArea.Controls.Add(this.uneTotalSol);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraLabel10);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraLabel1);
            this.ultraPanel2.Location = new System.Drawing.Point(6, 62);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(666, 125);
            this.ultraPanel2.TabIndex = 55;
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.AutoSize = true;
            this.ultraLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel9.Location = new System.Drawing.Point(242, 69);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(103, 14);
            this.ultraLabel9.TabIndex = 62;
            this.ultraLabel9.Text = "Docto. Electrónico:";
            this.ultraLabel9.Visible = false;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.AutoSize = true;
            this.ultraLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel8.Location = new System.Drawing.Point(19, 41);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(64, 14);
            this.ultraLabel8.TabIndex = 60;
            this.ultraLabel8.Text = "Tipo Docto:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(19, 69);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(49, 14);
            this.ultraLabel2.TabIndex = 58;
            this.ultraLabel2.Text = "Número:";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(19, 14);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(41, 14);
            this.ultraLabel3.TabIndex = 55;
            this.ultraLabel3.Text = "Cliente";
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel10.Location = new System.Drawing.Point(19, 96);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(35, 14);
            this.ultraLabel10.TabIndex = 54;
            this.ultraLabel10.Text = "Valor:";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(242, 96);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(77, 14);
            this.ultraLabel1.TabIndex = 56;
            this.ultraLabel1.Text = "Fecha Docto.:";
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ugData);
            this.ultraPanel1.Location = new System.Drawing.Point(4, 324);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(666, 223);
            this.ultraPanel1.TabIndex = 52;
            // 
            // ugData
            // 
            this.ugData.DataSource = this.anulacionDoctoENBindingSource;
            this.ugData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.Caption = "Entidad";
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 5;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 6;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn21.Header.Caption = "Documento";
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 7;
            ultraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn22.Header.Caption = "Tipo Documento";
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 1;
            ultraGridColumn22.Width = 258;
            ultraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn23.Header.Caption = "Oficina";
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 3;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn23.Width = 52;
            ultraGridColumn24.Header.Caption = "Docto. Electronico";
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 8;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 9;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            ultraGridColumn26.CellButtonAppearance = appearance14;
            ultraGridColumn26.Header.Caption = "";
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 4;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn26.MaxWidth = 20;
            ultraGridColumn26.MinLength = 14;
            ultraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn26.Tag = "E_BANCOS";
            ultraGridColumn26.Width = 20;
            ultraGridColumn27.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            ultraGridColumn27.CellButtonAppearance = appearance15;
            ultraGridColumn27.Header.Caption = "";
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 10;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn27.MaxWidth = 20;
            ultraGridColumn27.MinWidth = 14;
            ultraGridColumn27.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn27.Tag = "B_BANCOS";
            ultraGridColumn27.Width = 20;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27});
            this.ugData.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.ugData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ugData.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.ugData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
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
            this.ugData.Size = new System.Drawing.Size(666, 223);
            this.ugData.TabIndex = 51;
            this.ugData.Text = "ultraGrid1";
            this.ugData.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugData_InitializeLayout);
            this.ugData.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ugData_InitializeRow);
            this.ugData.AfterRowActivate += new System.EventHandler(this.ugData_AfterRowActivate);
            // 
            // anulacionDoctoENBindingSource
            // 
            this.anulacionDoctoENBindingSource.DataSource = typeof(TiempoEnProcesoEN.AnulacionDoctoEN);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(24, 14);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel6.TabIndex = 46;
            this.ultraLabel6.Text = "Entidad:";
            // 
            // anulacionSolicitudENBindingSource
            // 
            this.anulacionSolicitudENBindingSource.DataSource = typeof(TiempoEnProcesoEN.AnulacionSolicitudEN);
            // 
            // tblcuentacorrienteBindingSource
            // 
            this.tblcuentacorrienteBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_cuenta_corriente);
            // 
            // frmAnulacionDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 632);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmGeneracionFactura_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmGeneracionFactura_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmGeneracionFactura_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmGeneracionFactura_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnulacionDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anulación de Documento";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneTotalSol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTipoSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFechaAnulacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteAutorizo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteMotivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDoctoElect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ClientArea.PerformLayout();
            this.ultraPanel4.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ClientArea.PerformLayout();
            this.ultraPanel2.ResumeLayout(false);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anulacionDoctoENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anulacionSolicitudENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblcuentacorrienteBindingSource)).EndInit();
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
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Infragistics.Win.Misc.UltraButton ubCerrar;
        private Infragistics.Win.Misc.UltraButton ubAgregar;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucEntidad;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private System.Windows.Forms.BindingSource tblentidadlegalBindingSource;
        private Infragistics.Win.Misc.UltraButton ubConsultar;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugData;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private System.Windows.Forms.BindingSource anulacionSolicitudENBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteFecha;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteCliente;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneTotalSol;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneDocumento;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucTipoSolicitud;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraPanel ultraPanel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteMotivo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteAutorizo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteFechaAnulacion;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private System.Windows.Forms.BindingSource tblcuentacorrienteBindingSource;
        private System.Windows.Forms.BindingSource anulacionDoctoENBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteTipo;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDoctoElect;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
    }
}