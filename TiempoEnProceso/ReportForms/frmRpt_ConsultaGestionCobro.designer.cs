namespace TiempoEnProceso.Forms
{
    partial class frmRpt_ConsultaGestionCobro
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_entidad_legal", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_entidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Razon_social");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NIT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_facturas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_cobranzas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_notas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_anulaciones");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("impuesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("incluido");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("formato_facturas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("financiera");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ubicacion_factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("origen_datos_factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("control_fel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Acceso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Api");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Certificado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Formato_FEL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_tipo_documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_frases");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_tipo_documento", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Count");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsReadOnly");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_frases", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Count");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsReadOnly");
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
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Visualizar Reporte", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_ConsultaGestionCobro));
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.uneFactura = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ucEntidad = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tblentidadlegalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._frmUsuario_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.periodoENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.periodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.periodoENBindingSource)).BeginInit();
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
            // uneFactura
            // 
            this.uneFactura.Location = new System.Drawing.Point(109, 38);
            this.uneFactura.Name = "uneFactura";
            this.uneFactura.Size = new System.Drawing.Size(100, 21);
            this.uneFactura.TabIndex = 1;
            this.uvValidador.GetValidationSettings(this.uneFactura).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneFactura).NotificationSettings.Text = "Número de Factura Invalido";
            this.uvValidador.GetValidationSettings(this.uneFactura).ValidationGroupKey = "required";
            this.uneFactura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneFactura_KeyDown);
            // 
            // ucEntidad
            // 
            this.ucEntidad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucEntidad.DataSource = this.tblentidadlegalBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucEntidad.DisplayLayout.Appearance = appearance2;
            this.ucEntidad.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 15;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 16;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 17;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 18;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 19;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 20;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 21;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 22;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 23;
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 24;
            ultraGridColumn18.Header.Caption = "Entidad";
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 3;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
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
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn17,
            ultraGridColumn27,
            ultraGridColumn18});
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 0;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 1;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn19,
            ultraGridColumn20});
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 0;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 1;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn28,
            ultraGridColumn29});
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
            this.ucEntidad.Size = new System.Drawing.Size(330, 22);
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
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ubAgregar
            // 
            appearance15.Image = global::TiempoEnProceso.Properties.Resources.services;
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance15;
            this.ubAgregar.AutoSize = true;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(114, 64);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(86, 40);
            this.ubAgregar.TabIndex = 2;
            this.ubAgregar.Text = "Generar";
            ultraToolTipInfo2.ToolTipText = "Visualizar Reporte";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregar, ultraToolTipInfo2);
            this.ubAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregar.Click += new System.EventHandler(this.ubAgregar_Click);
            // 
            // ubCerrar
            // 
            appearance14.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance14;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(250, 64);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(90, 40);
            this.ubCerrar.TabIndex = 3;
            this.ubCerrar.Text = "Cancelar";
            ultraToolTipInfo1.ToolTipText = "Cancelar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubCerrar, ultraToolTipInfo1);
            this.ubCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubCerrar.Click += new System.EventHandler(this.ubCerrar_Click);
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Left
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Name = "_frmUsuario_UltraFormManager_Dock_Area_Left";
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 114);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Right
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(471, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Name = "_frmUsuario_UltraFormManager_Dock_Area_Right";
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 114);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Top
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmUsuario_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Name = "_frmUsuario_UltraFormManager_Dock_Area_Top";
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(479, 32);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 146);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(479, 8);
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.uneFactura);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel2);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucEntidad);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(463, 114);
            this.ultraPanel3.TabIndex = 3;
            this.ultraPanel3.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel3_PaintClient);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(24, 38);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel2.TabIndex = 49;
            this.ultraLabel2.Text = "Factura:";
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
            // periodoENBindingSource
            // 
            this.periodoENBindingSource.DataSource = typeof(TiempoEnProcesoEN.PeriodoEN);
            // 
            // periodoBindingSource
            // 
            this.periodoBindingSource.DataSource = typeof(TiempoEnProcesoDL.Periodo);
            // 
            // frmRpt_ConsultaGestionCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 154);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt_ConsultaGestionCobro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitacora de Cobro por Factura";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.periodoENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraValidator uvValidador;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Bottom;
        private System.Windows.Forms.BindingSource periodoBindingSource;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Infragistics.Win.Misc.UltraButton ubCerrar;
        private Infragistics.Win.Misc.UltraButton ubAgregar;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucEntidad;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private System.Windows.Forms.BindingSource tblentidadlegalBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private System.Windows.Forms.BindingSource periodoENBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneFactura;
    }
}