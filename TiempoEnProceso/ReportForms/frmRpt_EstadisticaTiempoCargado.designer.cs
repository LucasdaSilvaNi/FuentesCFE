namespace TiempoEnProceso.Forms
{
    partial class frmRpt_EstadisticaTiempoCargado
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("direccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("periodo_proceso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("parametro_reportes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("permite_facturar_en_periodo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_Telefono");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_Fax");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correo_electronico");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("codigo_fiscal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_EstadisticaTiempoCargado));
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ucOficce = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tbloficinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._frmUsuario_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.unePeriodo = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.upTipo = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.periodoENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.periodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblentidadlegalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucOficce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unePeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).BeginInit();
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
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn9.Header.Caption = "Oficina";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn9});
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
            this.ucOficce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucOficce.LimitToList = true;
            this.ucOficce.Location = new System.Drawing.Point(105, 44);
            this.ucOficce.Name = "ucOficce";
            this.ucOficce.Size = new System.Drawing.Size(352, 22);
            this.ucOficce.TabIndex = 2;
            this.uvValidador.GetValidationSettings(this.ucOficce).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucOficce).NotificationSettings.Text = "Oficina Invalida";
            this.uvValidador.GetValidationSettings(this.ucOficce).ValidationGroupKey = "required";
            this.ucOficce.ValueMember = "id_oficina";
            this.ucOficce.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucOficce_InitializeRow);
            this.ucOficce.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucOficce_ItemNotInList);
            // 
            // tbloficinaBindingSource
            // 
            this.tbloficinaBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_oficina);
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
            this.ubAgregar.Location = new System.Drawing.Point(113, 106);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(86, 40);
            this.ubAgregar.TabIndex = 4;
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
            this.ubCerrar.Location = new System.Drawing.Point(249, 106);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(90, 40);
            this.ubCerrar.TabIndex = 5;
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
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 157);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 157);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 189);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(479, 8);
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.unePeriodo);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel3);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel5);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucOficce);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel2);
            this.ultraPanel3.ClientArea.Controls.Add(this.upTipo);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(463, 157);
            this.ultraPanel3.TabIndex = 3;
            this.ultraPanel3.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel3_PaintClient);
            // 
            // unePeriodo
            // 
            this.unePeriodo.Location = new System.Drawing.Point(105, 71);
            this.unePeriodo.MaskInput = "nnnn";
            this.unePeriodo.Name = "unePeriodo";
            this.unePeriodo.Size = new System.Drawing.Size(100, 21);
            this.unePeriodo.TabIndex = 3;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(20, 75);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel3.TabIndex = 53;
            this.ultraLabel3.Text = "Período:";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(20, 47);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(45, 14);
            this.ultraLabel5.TabIndex = 51;
            this.ultraLabel5.Text = "Oficina:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(20, 6);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(31, 14);
            this.ultraLabel2.TabIndex = 49;
            this.ultraLabel2.Text = "Tipo:";
            // 
            // upTipo
            // 
            this.upTipo.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            valueListItem1.DataValue = "1";
            valueListItem1.DisplayText = "Tiempo Cargado";
            valueListItem2.DataValue = "2";
            valueListItem2.DisplayText = "Tiempo Cargado Teams";
            this.upTipo.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.upTipo.Location = new System.Drawing.Point(105, 6);
            this.upTipo.Name = "upTipo";
            this.upTipo.Size = new System.Drawing.Size(338, 32);
            this.upTipo.TabIndex = 1;
            this.upTipo.ValueChanged += new System.EventHandler(this.upTipo_ValueChanged);
            // 
            // periodoENBindingSource
            // 
            this.periodoENBindingSource.DataSource = typeof(TiempoEnProcesoEN.PeriodoEN);
            // 
            // periodoBindingSource
            // 
            this.periodoBindingSource.DataSource = typeof(TiempoEnProcesoDL.Periodo);
            // 
            // tblentidadlegalBindingSource
            // 
            this.tblentidadlegalBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_entidad_legal);
            // 
            // frmRpt_EstadisticaTiempoCargado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 197);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt_EstadisticaTiempoCargado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadistica Tiempo Cargado";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucOficce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unePeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblentidadlegalBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource tblentidadlegalBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet upTipo;
        private System.Windows.Forms.BindingSource periodoENBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucOficce;
        private System.Windows.Forms.BindingSource tbloficinaBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor unePeriodo;
    }
}