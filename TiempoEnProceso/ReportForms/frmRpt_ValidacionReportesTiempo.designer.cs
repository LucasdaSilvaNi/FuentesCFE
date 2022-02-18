﻿namespace TiempoEnProceso.Forms
{
    partial class frmRpt_ValidacionReportesTiempo
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_oficina", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("direccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("periodo_proceso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("parametro_reportes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("permite_facturar_en_periodo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_Telefono");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_Fax");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correo_electronico");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("codigo_fiscal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpt_ValidacionReportesTiempo));
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ucOficina = new Infragistics.Win.UltraWinGrid.UltraCombo();
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
            this.utePeriodo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucOficina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utePeriodo)).BeginInit();
            this.SuspendLayout();
            // 
            // uvValidador
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.exclamation;
            this.uvValidador.ErrorAppearance = appearance1;
            this.uvValidador.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.Asterisk;
            this.uvValidador.NotificationSettings.Action = Infragistics.Win.Misc.NotificationAction.None;
            validationGroup1.Key = "required";
            this.uvValidador.ValidationGroups.Add(validationGroup1);
            this.uvValidador.ValidationTrigger = Infragistics.Win.Misc.ValidationTrigger.OnPropertyValueChanged;
            // 
            // ucOficina
            // 
            this.ucOficina.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucOficina.DataSource = this.tbloficinaBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucOficina.DisplayLayout.Appearance = appearance2;
            this.ucOficina.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 0;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 2;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.Header.Editor = null;
            ultraGridColumn20.Header.VisiblePosition = 3;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 4;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 1;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 5;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 6;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 7;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 8;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 10;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 11;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 12;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.Header.Caption = "Oficina";
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 9;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30});
            this.ucOficina.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucOficina.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucOficina.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.ucOficina.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucOficina.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucOficina.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucOficina.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.ucOficina.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ucOficina.DisplayLayout.MaxBandDepth = 1;
            this.ucOficina.DisplayLayout.MaxColScrollRegions = 1;
            this.ucOficina.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucOficina.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucOficina.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.ucOficina.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucOficina.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.ucOficina.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucOficina.DisplayLayout.Override.CellAppearance = appearance9;
            this.ucOficina.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucOficina.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.ucOficina.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.ucOficina.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ucOficina.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucOficina.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ucOficina.DisplayLayout.Override.RowAppearance = appearance12;
            this.ucOficina.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucOficina.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ucOficina.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucOficina.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucOficina.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucOficina.DisplayMember = "Nombre";
            this.ucOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucOficina.LimitToList = true;
            this.ucOficina.Location = new System.Drawing.Point(88, 6);
            this.ucOficina.Name = "ucOficina";
            this.ucOficina.Size = new System.Drawing.Size(238, 22);
            this.ucOficina.TabIndex = 0;
            this.uvValidador.GetValidationSettings(this.ucOficina).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucOficina).NotificationSettings.Text = "Oficina Invalida";
            this.uvValidador.GetValidationSettings(this.ucOficina).ValidationGroupKey = "required";
            this.ucOficina.ValueMember = "id_oficina";
            this.ucOficina.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucOficina_InitializeRow);
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
            this.ubAgregar.Location = new System.Drawing.Point(49, 69);
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
            this.ubCerrar.Location = new System.Drawing.Point(185, 69);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 119);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Right
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(351, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Name = "_frmUsuario_UltraFormManager_Dock_Area_Right";
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 119);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(359, 32);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 151);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(359, 8);
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.utePeriodo);
            this.ultraPanel3.ClientArea.Controls.Add(this.ucOficina);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel1);
            this.ultraPanel3.ClientArea.Controls.Add(this.ultraLabel3);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(343, 119);
            this.ultraPanel3.TabIndex = 3;
            this.ultraPanel3.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel3_PaintClient);
            // 
            // utePeriodo
            // 
            this.utePeriodo.Location = new System.Drawing.Point(88, 34);
            this.utePeriodo.MaxLength = 7;
            this.utePeriodo.Name = "utePeriodo";
            this.utePeriodo.Size = new System.Drawing.Size(100, 21);
            this.utePeriodo.TabIndex = 1;
            this.utePeriodo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.utePeriodo_KeyDown);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(25, 9);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(45, 14);
            this.ultraLabel1.TabIndex = 27;
            this.ultraLabel1.Text = "Oficina:";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(25, 38);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel3.TabIndex = 11;
            this.ultraLabel3.Text = "Período:";
            // 
            // frmRpt_ValidacionReportesTiempo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 159);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpt_ValidacionReportesTiempo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de Tiempo";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucOficina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.utePeriodo)).EndInit();
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
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Infragistics.Win.Misc.UltraButton ubCerrar;
        private Infragistics.Win.Misc.UltraButton ubAgregar;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private System.Windows.Forms.BindingSource tbloficinaBindingSource;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucOficina;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor utePeriodo;
    }
}