namespace TiempoEnProceso.Forms
{
    partial class frmOficina
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_paises", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tasa_Cambio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Periodo_Proceso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Situacion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("inicia_periodo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("finaliza_periodo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_territory");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("iso_char2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("codigo_pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("paisSynId");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_trabajos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("pais", 0);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_trabajos", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Count");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsReadOnly");
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Grabar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOficina));
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.uteDescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tblSeriesPorCajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.uteIdBanco = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ucPais = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tblpaisesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.uteCodigoFiscal = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.uteCorreo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.uneFax = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.uneTelefono = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uckFacturar = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uckCaptar = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ucPeriodo = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.periodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uteDireccion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this._frmUsuario_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSeriesPorCajaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteIdBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucPais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpaisesBindingSource)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteCodigoFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckFacturar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckCaptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDireccion)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel7.Location = new System.Drawing.Point(28, 51);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(49, 14);
            this.ultraLabel7.TabIndex = 6;
            this.ultraLabel7.Text = "Nombre:";
            // 
            // uteDescripcion
            // 
            this.uteDescripcion.Location = new System.Drawing.Point(95, 47);
            this.uteDescripcion.MaxLength = 30;
            this.uteDescripcion.Name = "uteDescripcion";
            this.uteDescripcion.Size = new System.Drawing.Size(188, 21);
            this.uteDescripcion.TabIndex = 1;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).NotificationSettings.Text = "Nombre Invalido";
            this.uvValidador.GetValidationSettings(this.uteDescripcion).ValidationGroupKey = "required";
            this.uteDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteDescripcion_KeyDown);
            // 
            // tblSeriesPorCajaBindingSource
            // 
            this.tblSeriesPorCajaBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_oficina);
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
            // uteIdBanco
            // 
            this.uteIdBanco.Location = new System.Drawing.Point(95, 20);
            this.uteIdBanco.MaxLength = 2;
            this.uteIdBanco.Name = "uteIdBanco";
            this.uteIdBanco.Size = new System.Drawing.Size(52, 21);
            this.uteIdBanco.TabIndex = 0;
            this.uvValidador.GetValidationSettings(this.uteIdBanco).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteIdBanco).NotificationSettings.Text = "ID de Oficina Invalido";
            this.uvValidador.GetValidationSettings(this.uteIdBanco).ValidationGroupKey = "required";
            this.uteIdBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteIdBanco_KeyDown);
            // 
            // ucPais
            // 
            this.ucPais.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucPais.DataSource = this.tblpaisesBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucPais.DisplayLayout.Appearance = appearance2;
            this.ucPais.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
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
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
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
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.Editor = null;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Editor = null;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.Header.Editor = null;
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn14.Header.Caption = "Pais";
            ultraGridColumn14.Header.Editor = null;
            ultraGridColumn14.Header.VisiblePosition = 12;
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
            ultraGridColumn14});
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 0;
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 1;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn15,
            ultraGridColumn31});
            this.ucPais.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucPais.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ucPais.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucPais.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.ucPais.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucPais.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucPais.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucPais.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.ucPais.DisplayLayout.MaxColScrollRegions = 1;
            this.ucPais.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucPais.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucPais.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.ucPais.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucPais.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.ucPais.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucPais.DisplayLayout.Override.CellAppearance = appearance9;
            this.ucPais.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucPais.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.ucPais.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.ucPais.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ucPais.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucPais.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ucPais.DisplayLayout.Override.RowAppearance = appearance12;
            this.ucPais.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucPais.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ucPais.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucPais.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucPais.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucPais.DisplayMember = "Nombre";
            this.ucPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPais.LimitToList = true;
            this.ucPais.Location = new System.Drawing.Point(95, 101);
            this.ucPais.Name = "ucPais";
            this.ucPais.Size = new System.Drawing.Size(162, 22);
            this.ucPais.TabIndex = 3;
            this.uvValidador.GetValidationSettings(this.ucPais).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucPais).NotificationSettings.Text = "País Invalido";
            this.uvValidador.GetValidationSettings(this.ucPais).ValidationGroupKey = "required";
            this.ucPais.ValueMember = "id_pais";
            this.ucPais.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucPais_InitializeRow);
            this.ucPais.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucPais_ItemNotInList);
            this.ucPais.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPais_KeyDown);
            // 
            // tblpaisesBindingSource
            // 
            this.tblpaisesBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_paises);
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(483, 46);
            this.ultraPanel3.TabIndex = 22;
            // 
            // ubCerrar
            // 
            appearance14.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance14;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(41, 3);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(40, 40);
            this.ubCerrar.TabIndex = 17;
            ultraToolTipInfo1.ToolTipText = "Cancelar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubCerrar, ultraToolTipInfo1);
            this.ubCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubCerrar.Click += new System.EventHandler(this.ubCerrar_Click);
            // 
            // ubAgregar
            // 
            appearance15.Image = ((object)(resources.GetObject("appearance15.Image")));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance15;
            this.ubAgregar.AutoSize = true;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(3, 3);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(40, 40);
            this.ubAgregar.TabIndex = 16;
            ultraToolTipInfo2.ToolTipText = "Grabar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregar, ultraToolTipInfo2);
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
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel9);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteCodigoFiscal);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteCorreo);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel4);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneFax);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel8);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneTelefono);
            this.ultraPanel4.ClientArea.Controls.Add(this.uckFacturar);
            this.ultraPanel4.ClientArea.Controls.Add(this.uckCaptar);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel5);
            this.ultraPanel4.ClientArea.Controls.Add(this.ucPeriodo);
            this.ultraPanel4.ClientArea.Controls.Add(this.ucPais);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel3);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel2);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteDireccion);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteIdBanco);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel1);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel7);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteDescripcion);
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel4.Location = new System.Drawing.Point(8, 78);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(483, 282);
            this.ultraPanel4.TabIndex = 20;
            this.ultraPanel4.PaintClient += new System.Windows.Forms.PaintEventHandler(this.ultraPanel4_PaintClient);
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.AutoSize = true;
            this.ultraLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel9.Location = new System.Drawing.Point(28, 187);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(64, 14);
            this.ultraLabel9.TabIndex = 26;
            this.ultraLabel9.Text = "Cód. Fiscal:";
            // 
            // uteCodigoFiscal
            // 
            this.uteCodigoFiscal.Location = new System.Drawing.Point(95, 183);
            this.uteCodigoFiscal.MaxLength = 12;
            this.uteCodigoFiscal.Name = "uteCodigoFiscal";
            this.uteCodigoFiscal.Size = new System.Drawing.Size(109, 21);
            this.uteCodigoFiscal.TabIndex = 8;
            this.uteCodigoFiscal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteCodigoFiscal_KeyDown);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(28, 160);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(53, 14);
            this.ultraLabel6.TabIndex = 24;
            this.ultraLabel6.Text = "Correo E:";
            // 
            // uteCorreo
            // 
            this.uteCorreo.Location = new System.Drawing.Point(95, 156);
            this.uteCorreo.MaxLength = 60;
            this.uteCorreo.Name = "uteCorreo";
            this.uteCorreo.Size = new System.Drawing.Size(366, 21);
            this.uteCorreo.TabIndex = 7;
            this.uteCorreo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteCorreo_KeyDown);
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(265, 132);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(26, 14);
            this.ultraLabel4.TabIndex = 22;
            this.ultraLabel4.Text = "Fax:";
            // 
            // uneFax
            // 
            this.uneFax.Location = new System.Drawing.Point(317, 128);
            this.uneFax.MaskInput = "nnnnnnnn";
            this.uneFax.Name = "uneFax";
            this.uneFax.Size = new System.Drawing.Size(109, 21);
            this.uneFax.TabIndex = 6;
            this.uneFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneFax_KeyDown);
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.AutoSize = true;
            this.ultraLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel8.Location = new System.Drawing.Point(28, 133);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(51, 14);
            this.ultraLabel8.TabIndex = 20;
            this.ultraLabel8.Text = "Teléfono:";
            // 
            // uneTelefono
            // 
            this.uneTelefono.Location = new System.Drawing.Point(95, 129);
            this.uneTelefono.MaskInput = "nnnnnnnn";
            this.uneTelefono.Name = "uneTelefono";
            this.uneTelefono.Size = new System.Drawing.Size(109, 21);
            this.uneTelefono.TabIndex = 5;
            this.uneTelefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneTelefono_KeyDown);
            // 
            // uckFacturar
            // 
            this.uckFacturar.Location = new System.Drawing.Point(95, 238);
            this.uckFacturar.Name = "uckFacturar";
            this.uckFacturar.Size = new System.Drawing.Size(275, 20);
            this.uckFacturar.TabIndex = 10;
            this.uckFacturar.Text = "Permite Facturar en el Periodo";
            this.uckFacturar.CheckedChanged += new System.EventHandler(this.uckFacturar_CheckedChanged);
            this.uckFacturar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uckFacturar_KeyDown);
            // 
            // uckCaptar
            // 
            this.uckCaptar.Location = new System.Drawing.Point(95, 212);
            this.uckCaptar.Name = "uckCaptar";
            this.uckCaptar.Size = new System.Drawing.Size(275, 20);
            this.uckCaptar.TabIndex = 9;
            this.uckCaptar.Text = "Permite Captar reportes en el Periodo";
            this.uckCaptar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uckCaptar_KeyDown);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(265, 105);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(46, 14);
            this.ultraLabel5.TabIndex = 16;
            this.ultraLabel5.Text = "Periodo:";
            this.ultraLabel5.Visible = false;
            // 
            // ucPeriodo
            // 
            this.ucPeriodo.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucPeriodo.DataSource = this.periodoBindingSource;
            this.ucPeriodo.DisplayMember = "id_periodo";
            this.ucPeriodo.LimitToList = true;
            this.ucPeriodo.Location = new System.Drawing.Point(317, 101);
            this.ucPeriodo.Name = "ucPeriodo";
            this.ucPeriodo.Size = new System.Drawing.Size(144, 21);
            this.ucPeriodo.TabIndex = 4;
            this.ucPeriodo.ValueMember = "id_periodo";
            this.ucPeriodo.Visible = false;
            this.ucPeriodo.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.ucPeriodo_ItemNotInList);
            this.ucPeriodo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPeriodo_KeyDown);
            // 
            // periodoBindingSource
            // 
            this.periodoBindingSource.DataSource = typeof(TiempoEnProcesoDL.Periodo);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(28, 105);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(31, 14);
            this.ultraLabel3.TabIndex = 9;
            this.ultraLabel3.Text = "País:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(28, 78);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(55, 14);
            this.ultraLabel2.TabIndex = 8;
            this.ultraLabel2.Text = "Dirección:";
            // 
            // uteDireccion
            // 
            this.uteDireccion.Location = new System.Drawing.Point(95, 74);
            this.uteDireccion.MaxLength = 60;
            this.uteDireccion.Name = "uteDireccion";
            this.uteDireccion.Size = new System.Drawing.Size(366, 21);
            this.uteDireccion.TabIndex = 2;
            this.uteDireccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteDireccion_KeyDown);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(28, 24);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(19, 14);
            this.ultraLabel1.TabIndex = 6;
            this.ultraLabel1.Text = "ID:";
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
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 328);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Right
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(491, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Name = "_frmUsuario_UltraFormManager_Dock_Area_Right";
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 328);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(499, 32);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 360);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(499, 8);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // frmOficina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 368);
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
            this.Name = "frmOficina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oficina";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSeriesPorCajaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteIdBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucPais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpaisesBindingSource)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ClientArea.PerformLayout();
            this.ultraPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uteCodigoFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteCorreo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckFacturar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckCaptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDireccion)).EndInit();
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDescripcion;
        private System.Windows.Forms.BindingSource tblSeriesPorCajaBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteIdBanco;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucPais;
        private System.Windows.Forms.BindingSource tblpaisesBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDireccion;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucPeriodo;
        private System.Windows.Forms.BindingSource periodoBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckFacturar;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckCaptar;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneFax;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneTelefono;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteCorreo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteCodigoFiscal;
    }
}