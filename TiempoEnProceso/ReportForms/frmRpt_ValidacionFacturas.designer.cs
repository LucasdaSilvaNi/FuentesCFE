namespace TiempoEnProceso.Forms
{
    partial class frmRpt_ValidacionFacturas
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Periodo", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_periodo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("descripcion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_entidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Razon_social");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NIT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_facturas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_cobranzas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_notas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correlativo_anulaciones");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("impuesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("incluido");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("formato_facturas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("financiera");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ubicacion_factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("origen_datos_factura");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("control_fel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Acceso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Api");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Clave_Cliente");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Certificado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Formato_FEL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_tipo_documento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_frases");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_tipo_documento", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Count");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsReadOnly");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_frases", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Count");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsReadOnly");
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
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Visualizar Reporte", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_ValidacionFacturas));
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ucPeriodo = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.periodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.uccFechaFinal = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccFechaInicial = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ulFechaF = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ulFechaI = new Infragistics.Win.Misc.UltraLabel();
            this.upTipo = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ulbPeriodo = new Infragistics.Win.Misc.UltraLabel();
            this.periodoENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoENBindingSource)).BeginInit();
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
            // ucPeriodo
            // 
            this.ucPeriodo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucPeriodo.DataSource = this.periodoBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucPeriodo.DisplayLayout.Appearance = appearance2;
            this.ucPeriodo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn50.Header.Editor = null;
            ultraGridColumn50.Header.VisiblePosition = 0;
            ultraGridColumn50.Hidden = true;
            ultraGridColumn51.Header.Caption = "Periodo";
            ultraGridColumn51.Header.Editor = null;
            ultraGridColumn51.Header.VisiblePosition = 1;
            ultraGridColumn52.Header.Caption = "Entidad";
            ultraGridColumn52.Header.Editor = null;
            ultraGridColumn52.Header.VisiblePosition = 2;
            ultraGridColumn52.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52});
            this.ucPeriodo.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucPeriodo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucPeriodo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.ucPeriodo.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucPeriodo.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucPeriodo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucPeriodo.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.ucPeriodo.DisplayLayout.MaxColScrollRegions = 1;
            this.ucPeriodo.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucPeriodo.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucPeriodo.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.ucPeriodo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucPeriodo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.ucPeriodo.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucPeriodo.DisplayLayout.Override.CellAppearance = appearance9;
            this.ucPeriodo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucPeriodo.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.ucPeriodo.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.ucPeriodo.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ucPeriodo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucPeriodo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ucPeriodo.DisplayLayout.Override.RowAppearance = appearance12;
            this.ucPeriodo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucPeriodo.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ucPeriodo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucPeriodo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucPeriodo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucPeriodo.DisplayMember = "descripcion";
            this.ucPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPeriodo.LimitToList = true;
            this.ucPeriodo.Location = new System.Drawing.Point(109, 71);
            this.ucPeriodo.Name = "ucPeriodo";
            this.ucPeriodo.Size = new System.Drawing.Size(158, 22);
            this.ucPeriodo.TabIndex = 4;
            this.uvValidador.GetValidationSettings(this.ucPeriodo).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucPeriodo).NotificationSettings.Text = "Selección de Periodo Invalida";
            this.uvValidador.GetValidationSettings(this.ucPeriodo).ValidationGroupKey = "requiredPeriodo";
            this.ucPeriodo.ValueMember = "id_periodo";
            this.ucPeriodo.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucPeriodo_ItemNotInList);
            // 
            // periodoBindingSource
            // 
            this.periodoBindingSource.DataSource = typeof(TiempoEnProcesoDL.Periodo);
            // 
            // ucEntidad
            // 
            this.ucEntidad.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucEntidad.DataSource = this.tblentidadlegalBindingSource;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucEntidad.DisplayLayout.Appearance = appearance14;
            this.ucEntidad.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 0;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 1;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 2;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 4;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 5;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 6;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 7;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 8;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 9;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 10;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 11;
            ultraGridColumn35.Hidden = true;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 12;
            ultraGridColumn36.Hidden = true;
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 13;
            ultraGridColumn37.Hidden = true;
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 14;
            ultraGridColumn38.Hidden = true;
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 15;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 16;
            ultraGridColumn40.Hidden = true;
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 17;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 18;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 19;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 20;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.Header.Editor = null;
            ultraGridColumn45.Header.VisiblePosition = 21;
            ultraGridColumn45.Hidden = true;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 22;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn46.Header.Editor = null;
            ultraGridColumn46.Header.VisiblePosition = 23;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 24;
            ultraGridColumn47.Header.Caption = "Entidad";
            ultraGridColumn47.Header.Editor = null;
            ultraGridColumn47.Header.VisiblePosition = 3;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
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
            ultraGridColumn1,
            ultraGridColumn46,
            ultraGridColumn2,
            ultraGridColumn47});
            ultraGridColumn48.Header.Editor = null;
            ultraGridColumn48.Header.VisiblePosition = 0;
            ultraGridColumn49.Header.Editor = null;
            ultraGridColumn49.Header.VisiblePosition = 1;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn48,
            ultraGridColumn49});
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 0;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 1;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4});
            this.ucEntidad.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ucEntidad.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.ucEntidad.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
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
            this.ucEntidad.Location = new System.Drawing.Point(109, 10);
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
            appearance27.Image = global::TiempoEnProceso.Properties.Resources.services;
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance27.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance27;
            this.ubAgregar.AutoSize = true;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(116, 116);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(86, 40);
            this.ubAgregar.TabIndex = 5;
            this.ubAgregar.Text = "Generar";
            ultraToolTipInfo2.ToolTipText = "Visualizar Reporte";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregar, ultraToolTipInfo2);
            this.ubAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregar.Click += new System.EventHandler(this.ubAgregar_Click);
            // 
            // ubCerrar
            // 
            appearance26.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance26.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance26.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance26;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(252, 116);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(90, 40);
            this.ubCerrar.TabIndex = 6;
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
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 171);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 171);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 203);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(479, 8);
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.uccFechaFinal);
            this.ultraPanel3.ClientArea.Controls.Add(this.uccFechaInicial);
            this.ultraPanel3.ClientArea.Controls.Add(this.ulFechaF);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel2);
            this.ultraPanel3.ClientArea.Controls.Add(this.ulFechaI);
            this.ultraPanel3.ClientArea.Controls.Add(this.upTipo);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucEntidad);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucPeriodo);
            this.ultraPanel3.ClientArea.Controls.Add(this.ulbPeriodo);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(463, 171);
            this.ultraPanel3.TabIndex = 3;
            this.ultraPanel3.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel3_PaintClient);
            // 
            // uccFechaFinal
            // 
            this.uccFechaFinal.Location = new System.Drawing.Point(348, 71);
            this.uccFechaFinal.Name = "uccFechaFinal";
            this.uccFechaFinal.Size = new System.Drawing.Size(93, 21);
            this.uccFechaFinal.TabIndex = 3;
            this.uccFechaFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uccFechaFinal_KeyDown);
            // 
            // uccFechaInicial
            // 
            this.uccFechaInicial.Location = new System.Drawing.Point(109, 71);
            this.uccFechaInicial.Name = "uccFechaInicial";
            this.uccFechaInicial.Size = new System.Drawing.Size(93, 21);
            this.uccFechaInicial.TabIndex = 2;
            this.uccFechaInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uccFechaInicial_KeyDown);
            // 
            // ulFechaF
            // 
            this.ulFechaF.AutoSize = true;
            this.ulFechaF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulFechaF.Location = new System.Drawing.Point(273, 75);
            this.ulFechaF.Name = "ulFechaF";
            this.ulFechaF.Size = new System.Drawing.Size(69, 14);
            this.ulFechaF.TabIndex = 52;
            this.ulFechaF.Text = "Fecha Final:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(24, 38);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(31, 14);
            this.ultraLabel2.TabIndex = 49;
            this.ultraLabel2.Text = "Tipo:";
            // 
            // ulFechaI
            // 
            this.ulFechaI.AutoSize = true;
            this.ulFechaI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulFechaI.Location = new System.Drawing.Point(24, 75);
            this.ulFechaI.Name = "ulFechaI";
            this.ulFechaI.Size = new System.Drawing.Size(74, 14);
            this.ulFechaI.TabIndex = 48;
            this.ulFechaI.Text = "Fecha Inicial:";
            // 
            // upTipo
            // 
            this.upTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = "1";
            valueListItem1.DisplayText = "Fecha";
            valueListItem2.DataValue = "2";
            valueListItem2.DisplayText = "Periodo";
            this.upTipo.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.upTipo.Location = new System.Drawing.Point(109, 38);
            this.upTipo.Name = "upTipo";
            this.upTipo.Size = new System.Drawing.Size(158, 32);
            this.upTipo.TabIndex = 1;
            this.upTipo.ValueChanged += new System.EventHandler(this.upTipo_ValueChanged);
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
            // ulbPeriodo
            // 
            this.ulbPeriodo.AutoSize = true;
            this.ulbPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulbPeriodo.Location = new System.Drawing.Point(24, 75);
            this.ulbPeriodo.Name = "ulbPeriodo";
            this.ulbPeriodo.Size = new System.Drawing.Size(48, 14);
            this.ulbPeriodo.TabIndex = 53;
            this.ulbPeriodo.Text = "Periodo:";
            // 
            // periodoENBindingSource
            // 
            this.periodoENBindingSource.DataSource = typeof(TiempoEnProcesoEN.PeriodoEN);
            // 
            // frmRpt_ValidacionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 211);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt_ValidacionFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validación de Facturas";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoENBindingSource)).EndInit();
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
        private Infragistics.Win.Misc.UltraLabel ulFechaI;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet upTipo;
        private Infragistics.Win.Misc.UltraLabel ulFechaF;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucPeriodo;
        private System.Windows.Forms.BindingSource periodoENBindingSource;
        private Infragistics.Win.Misc.UltraLabel ulbPeriodo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor uccFechaFinal;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor uccFechaInicial;
    }
}