namespace TiempoEnProceso.Forms
{
    partial class frmGastosAutomaticos
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
            Infragistics.Win.Misc.ValidationGroup validationGroup2 = new Infragistics.Win.Misc.ValidationGroup("reqNoCar");
            Infragistics.Win.Misc.ValidationGroup validationGroup3 = new Infragistics.Win.Misc.ValidationGroup("reqVal");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_gastos_administrativos", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_gasto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Distribucion_Proporcional_socios");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_gastos_administrativos_detalle_empresas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_gastos_administrativos_detalle_empresas", 0);
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Grabar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Grabar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_gts_automaticos_detalle", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id_transaccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_servicio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("estado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("edit", 0);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastosAutomaticos));
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("delete", 1);
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 2);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.uneGastos = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ucConcepto = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tblgastosadministrativosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uteDescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uccFechaNac = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraCalendarInfo1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(this.components);
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ubNuevo = new Infragistics.Win.Misc.UltraButton();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel7 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel6 = new Infragistics.Win.Misc.UltraPanel();
            this.ugData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tblgtsautomaticosdetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.upOption = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel5 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.utePeriodoB = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.utePeriodo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.uteOficina = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this._frmUsuario_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneGastos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucConcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblgastosadministrativosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaNac)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            this.ultraPanel7.ClientArea.SuspendLayout();
            this.ultraPanel7.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.ultraPanel6.ClientArea.SuspendLayout();
            this.ultraPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblgtsautomaticosdetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upOption)).BeginInit();
            this.ultraPanel5.SuspendLayout();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utePeriodoB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utePeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOficina)).BeginInit();
            this.SuspendLayout();
            // 
            // uvValidador
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.exclamation;
            this.uvValidador.ErrorAppearance = appearance1;
            this.uvValidador.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.Asterisk;
            this.uvValidador.NotificationSettings.Action = Infragistics.Win.Misc.NotificationAction.None;
            validationGroup1.Enabled = false;
            validationGroup1.Key = "required";
            validationGroup2.Key = "reqNoCar";
            validationGroup3.Key = "reqVal";
            this.uvValidador.ValidationGroups.Add(validationGroup1);
            this.uvValidador.ValidationGroups.Add(validationGroup2);
            this.uvValidador.ValidationGroups.Add(validationGroup3);
            this.uvValidador.ValidationTrigger = Infragistics.Win.Misc.ValidationTrigger.OnPropertyValueChanged;
            // 
            // uneGastos
            // 
            this.uneGastos.Location = new System.Drawing.Point(78, 95);
            this.uneGastos.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneGastos.MaskInput = "-nnnnnnnn.nn";
            this.uneGastos.MinValue = -2147483647D;
            this.uneGastos.Name = "uneGastos";
            this.uneGastos.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneGastos.Size = new System.Drawing.Size(106, 21);
            this.uneGastos.TabIndex = 5;
            this.uvValidador.GetValidationSettings(this.uneGastos).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneGastos).NotificationSettings.Text = "Valor Invalido";
            this.uvValidador.GetValidationSettings(this.uneGastos).ValidationGroupKey = "reqVal";
            this.uneGastos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneNotas_KeyDown);
            // 
            // ucConcepto
            // 
            this.ucConcepto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucConcepto.DataSource = this.tblgastosadministrativosBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucConcepto.DisplayLayout.Appearance = appearance2;
            this.ucConcepto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 0;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 1;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 2;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 4;
            ultraGridColumn10.Header.Caption = "Gasto";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 3;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn10});
            this.ucConcepto.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucConcepto.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ucConcepto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucConcepto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.ucConcepto.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucConcepto.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucConcepto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucConcepto.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.ucConcepto.DisplayLayout.MaxColScrollRegions = 1;
            this.ucConcepto.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucConcepto.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucConcepto.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.ucConcepto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucConcepto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.ucConcepto.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucConcepto.DisplayLayout.Override.CellAppearance = appearance9;
            this.ucConcepto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucConcepto.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.ucConcepto.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.ucConcepto.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ucConcepto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucConcepto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ucConcepto.DisplayLayout.Override.RowAppearance = appearance12;
            this.ucConcepto.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucConcepto.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ucConcepto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucConcepto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucConcepto.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucConcepto.DisplayMember = "Descripcion";
            this.ucConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucConcepto.LimitToList = true;
            this.ucConcepto.Location = new System.Drawing.Point(140, 100);
            this.ucConcepto.Name = "ucConcepto";
            this.ucConcepto.Size = new System.Drawing.Size(394, 22);
            this.ucConcepto.TabIndex = 3;
            this.uvValidador.GetValidationSettings(this.ucConcepto).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucConcepto).NotificationSettings.Text = "Concepto Invalido";
            this.uvValidador.GetValidationSettings(this.ucConcepto).ValidationGroupKey = "reqVal";
            this.ucConcepto.ValueMember = "id_gasto";
            this.ucConcepto.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucConcepto_InitializeRow);
            this.ucConcepto.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.ucConcepto_BeforeDropDown);
            this.ucConcepto.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucConcepto_ItemNotInList);
            this.ucConcepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucConcepto_KeyDown);
            this.ucConcepto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ucConcepto_KeyUp);
            // 
            // tblgastosadministrativosBindingSource
            // 
            this.tblgastosadministrativosBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_gastos_administrativos);
            // 
            // uteDescripcion
            // 
            this.uteDescripcion.Location = new System.Drawing.Point(140, 73);
            this.uteDescripcion.MaxLength = 100;
            this.uteDescripcion.Name = "uteDescripcion";
            this.uteDescripcion.Size = new System.Drawing.Size(392, 21);
            this.uteDescripcion.TabIndex = 2;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).NotificationSettings.Text = "Descripción Invalida";
            this.uvValidador.GetValidationSettings(this.uteDescripcion).ValidationGroupKey = "reqVal";
            this.uteDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteDescripcion_KeyDown);
            // 
            // uccFechaNac
            // 
            this.uccFechaNac.CalendarInfo = this.ultraCalendarInfo1;
            this.uccFechaNac.DateButtons.Add(dateButton1);
            this.uccFechaNac.Location = new System.Drawing.Point(397, 7);
            this.uccFechaNac.Name = "uccFechaNac";
            this.uccFechaNac.NonAutoSizeHeight = 21;
            this.uccFechaNac.Size = new System.Drawing.Size(129, 21);
            this.uccFechaNac.TabIndex = 1;
            this.uvValidador.GetValidationSettings(this.uccFechaNac).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uccFechaNac).NotificationSettings.Text = "Fecha Invalida";
            this.uvValidador.GetValidationSettings(this.uccFechaNac).ValidationGroupKey = "reqVal";
            this.uccFechaNac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uccFechaNac_KeyDown);
            // 
            // ultraCalendarInfo1
            // 
            this.ultraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = this;
            this.ultraCalendarInfo1.DataBindingsForOwners.BindingContextControl = this;
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.ubNuevo);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(615, 46);
            this.ultraPanel3.TabIndex = 22;
            // 
            // ubNuevo
            // 
            appearance16.Image = global::TiempoEnProceso.Properties.Resources.Agregar;
            appearance16.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubNuevo.Appearance = appearance16;
            this.ubNuevo.AutoSize = true;
            this.ubNuevo.ImageSize = new System.Drawing.Size(32, 32);
            this.ubNuevo.Location = new System.Drawing.Point(130, 3);
            this.ubNuevo.Name = "ubNuevo";
            this.ubNuevo.ShowOutline = false;
            this.ubNuevo.Size = new System.Drawing.Size(40, 40);
            this.ubNuevo.TabIndex = 10;
            ultraToolTipInfo1.ToolTipText = "Grabar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubNuevo, ultraToolTipInfo1);
            this.ubNuevo.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubNuevo.Visible = false;
            this.ubNuevo.Click += new System.EventHandler(this.ubNuevo_Click);
            // 
            // ubCerrar
            // 
            appearance17.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance17;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(47, 3);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(40, 40);
            this.ubCerrar.TabIndex = 17;
            ultraToolTipInfo2.ToolTipText = "Cancelar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubCerrar, ultraToolTipInfo2);
            this.ubCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubCerrar.Click += new System.EventHandler(this.ubCerrar_Click);
            // 
            // ubAgregar
            // 
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance18.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance18;
            this.ubAgregar.AutoSize = true;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(6, 3);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(40, 40);
            this.ubAgregar.TabIndex = 16;
            ultraToolTipInfo3.ToolTipText = "Grabar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregar, ultraToolTipInfo3);
            this.ubAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregar.Click += new System.EventHandler(this.ubAgregar_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // ultraPanel4
            // 
            // 
            // ultraPanel4.ClientArea
            // 
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraPanel7);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraPanel2);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel3);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteDescripcion);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraPanel5);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraPanel1);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel4);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteOficina);
            this.ultraPanel4.ClientArea.Controls.Add(this.ucConcepto);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel4.Location = new System.Drawing.Point(8, 78);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(615, 400);
            this.ultraPanel4.TabIndex = 20;
            // 
            // ultraPanel7
            // 
            // 
            // ultraPanel7.ClientArea
            // 
            this.ultraPanel7.ClientArea.Controls.Add(this.ultraLabel1);
            this.ultraPanel7.Location = new System.Drawing.Point(156, 128);
            this.ultraPanel7.Name = "ultraPanel7";
            this.ultraPanel7.Size = new System.Drawing.Size(192, 26);
            this.ultraPanel7.TabIndex = 7;
            this.ultraPanel7.Visible = false;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(192, 26);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Procesando...";
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraPanel6);
            this.ultraPanel2.ClientArea.Controls.Add(this.upOption);
            this.ultraPanel2.ClientArea.Controls.Add(this.uneGastos);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraLabel10);
            this.ultraPanel2.Location = new System.Drawing.Point(6, 136);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(602, 254);
            this.ultraPanel2.TabIndex = 52;
            this.ultraPanel2.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel2_PaintClient);
            // 
            // ultraPanel6
            // 
            // 
            // ultraPanel6.ClientArea
            // 
            this.ultraPanel6.ClientArea.Controls.Add(this.ugData);
            this.ultraPanel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraPanel6.Location = new System.Drawing.Point(198, 0);
            this.ultraPanel6.Name = "ultraPanel6";
            this.ultraPanel6.Size = new System.Drawing.Size(404, 254);
            this.ultraPanel6.TabIndex = 54;
            // 
            // ugData
            // 
            this.ugData.DataSource = this.tblgtsautomaticosdetalleBindingSource;
            this.ugData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 1;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 2;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn13.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn13.Header.Caption = "Servicio";
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 3;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn13.MinWidth = 280;
            ultraGridColumn14.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn14.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn14.Header.Caption = "Estado";
            ultraGridColumn14.Header.CheckBoxAlignment = Infragistics.Win.UltraWinGrid.HeaderCheckBoxAlignment.Center;
            ultraGridColumn14.Header.CheckBoxSynchronization = Infragistics.Win.UltraWinGrid.HeaderCheckBoxSynchronization.RowsCollection;
            ultraGridColumn14.Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.Always;
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 4;
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            ultraGridColumn14.Width = 100;
            ultraGridColumn15.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance14.Image = ((object)(resources.GetObject("appearance14.Image")));
            ultraGridColumn15.CellButtonAppearance = appearance14;
            ultraGridColumn15.Header.Caption = "";
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 6;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn15.MaxWidth = 20;
            ultraGridColumn15.MinLength = 14;
            ultraGridColumn15.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn15.Tag = "E_BANCOS";
            ultraGridColumn15.Width = 20;
            ultraGridColumn16.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            ultraGridColumn16.CellButtonAppearance = appearance15;
            ultraGridColumn16.Header.Caption = "";
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 5;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn16.MaxWidth = 20;
            ultraGridColumn16.MinWidth = 14;
            ultraGridColumn16.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn16.Tag = "B_BANCOS";
            ultraGridColumn16.Width = 20;
            ultraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn17.Header.Caption = "Servicio";
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 0;
            ultraGridColumn17.MaxWidth = 270;
            ultraGridColumn17.MinWidth = 270;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17});
            this.ugData.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
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
            this.ugData.Size = new System.Drawing.Size(404, 254);
            this.ugData.TabIndex = 6;
            this.ugData.Text = "ultraGrid1";
            this.ugData.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugData_InitializeLayout);
            this.ugData.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ugData_InitializeRow);
            this.ugData.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.ugData_BeforeCellUpdate);
            // 
            // tblgtsautomaticosdetalleBindingSource
            // 
            this.tblgtsautomaticosdetalleBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_gts_automaticos_detalle);
            // 
            // upOption
            // 
            this.upOption.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.upOption.CheckedIndex = 0;
            this.upOption.ItemOrigin = new System.Drawing.Point(3, 4);
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = "1";
            valueListItem1.DisplayText = "Fijo a Clientes con Saldo";
            valueListItem2.DataValue = "2";
            valueListItem2.DisplayText = "Proporcional a Saldos CTA";
            this.upOption.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.upOption.ItemSpacingHorizontal = 2;
            this.upOption.ItemSpacingVertical = 4;
            this.upOption.Location = new System.Drawing.Point(14, 15);
            this.upOption.Name = "upOption";
            this.upOption.Size = new System.Drawing.Size(170, 60);
            this.upOption.TabIndex = 4;
            this.upOption.Text = "Fijo a Clientes con Saldo";
            this.upOption.TextIndentation = 2;
            this.upOption.KeyDown += new System.Windows.Forms.KeyEventHandler(this.upOption_KeyDown);
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel10.Location = new System.Drawing.Point(14, 99);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(35, 14);
            this.ultraLabel10.TabIndex = 30;
            this.ultraLabel10.Text = "Valor:";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(33, 77);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(69, 14);
            this.ultraLabel3.TabIndex = 49;
            this.ultraLabel3.Text = "Descripción:";
            // 
            // ultraPanel5
            // 
            this.ultraPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraPanel5.Location = new System.Drawing.Point(0, 242);
            this.ultraPanel5.Name = "ultraPanel5";
            this.ultraPanel5.Size = new System.Drawing.Size(615, 158);
            this.ultraPanel5.TabIndex = 46;
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.utePeriodoB);
            this.ultraPanel1.ClientArea.Controls.Add(this.uccFechaNac);
            this.ultraPanel1.ClientArea.Controls.Add(this.ultraLabel12);
            this.ultraPanel1.ClientArea.Controls.Add(this.ultraLabel5);
            this.ultraPanel1.ClientArea.Controls.Add(this.utePeriodo);
            this.ultraPanel1.Location = new System.Drawing.Point(6, 33);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(551, 34);
            this.ultraPanel1.TabIndex = 33;
            this.ultraPanel1.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel1_PaintClient);
            // 
            // utePeriodoB
            // 
            this.utePeriodoB.Enabled = false;
            this.utePeriodoB.Location = new System.Drawing.Point(198, 7);
            this.utePeriodoB.MaxLength = 60;
            this.utePeriodoB.Name = "utePeriodoB";
            this.utePeriodoB.Size = new System.Drawing.Size(96, 21);
            this.utePeriodoB.TabIndex = 37;
            this.utePeriodoB.TabStop = false;
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.AutoSize = true;
            this.ultraLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel12.Location = new System.Drawing.Point(14, 11);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(117, 14);
            this.ultraLabel12.TabIndex = 34;
            this.ultraLabel12.Text = "Período CTA Proceso:";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(342, 11);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(40, 14);
            this.ultraLabel5.TabIndex = 50;
            this.ultraLabel5.Text = "Fecha:";
            // 
            // utePeriodo
            // 
            this.utePeriodo.Enabled = false;
            this.utePeriodo.Location = new System.Drawing.Point(134, 7);
            this.utePeriodo.MaxLength = 60;
            this.utePeriodo.Name = "utePeriodo";
            this.utePeriodo.Size = new System.Drawing.Size(58, 21);
            this.utePeriodo.TabIndex = 33;
            this.utePeriodo.TabStop = false;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(30, 10);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(43, 14);
            this.ultraLabel4.TabIndex = 18;
            this.ultraLabel4.Text = "Oficina:";
            // 
            // uteOficina
            // 
            this.uteOficina.Enabled = false;
            this.uteOficina.Location = new System.Drawing.Point(140, 6);
            this.uteOficina.MaxLength = 60;
            this.uteOficina.Name = "uteOficina";
            this.uteOficina.Size = new System.Drawing.Size(394, 21);
            this.uteOficina.TabIndex = 0;
            this.uteOficina.TabStop = false;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(33, 103);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(45, 14);
            this.ultraLabel6.TabIndex = 44;
            this.ultraLabel6.Text = "Gastos:";
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
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 446);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Right
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(623, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Name = "_frmUsuario_UltraFormManager_Dock_Area_Right";
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 446);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(631, 32);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 478);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(631, 8);
            // 
            // frmGastosAutomaticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 486);
            this.Controls.Add(this.ultraPanel4);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGastosAutomaticos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gastos Automáticos";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneGastos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucConcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblgastosadministrativosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaNac)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ClientArea.PerformLayout();
            this.ultraPanel4.ResumeLayout(false);
            this.ultraPanel7.ClientArea.ResumeLayout(false);
            this.ultraPanel7.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ClientArea.PerformLayout();
            this.ultraPanel2.ResumeLayout(false);
            this.ultraPanel6.ClientArea.ResumeLayout(false);
            this.ultraPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblgtsautomaticosdetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upOption)).EndInit();
            this.ultraPanel5.ResumeLayout(false);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.utePeriodoB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utePeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOficina)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraValidator uvValidador;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Infragistics.Win.Misc.UltraButton ubCerrar;
        private Infragistics.Win.Misc.UltraButton ubAgregar;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraPanel ultraPanel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteOficina;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneGastos;
        private Infragistics.Win.Misc.UltraButton ubNuevo;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor utePeriodoB;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor utePeriodo;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucConcepto;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraPanel ultraPanel5;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugData;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDescripcion;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccFechaNac;
        private System.Windows.Forms.BindingSource tblgastosadministrativosBindingSource;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet upOption;
        private System.Windows.Forms.BindingSource tblgtsautomaticosdetalleBindingSource;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarInfo ultraCalendarInfo1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel6;
        private Infragistics.Win.Misc.UltraPanel ultraPanel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}