namespace TiempoEnProceso.Forms
{
    partial class frmEmpleado
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_teams", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_team");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Lider");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("presupuesto_horas");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_puestos", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_puesto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("descripcion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_nivel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn35 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_empleados");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn36 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_puestos1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn37 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_puestos2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn38 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
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
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_departamento", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn39 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_departamento");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn40 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre_largo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn41 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre_reportes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn42 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_grupos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn43 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn44 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Socio");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn45 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id_linea_pwcglobal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn46 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("code_center_code");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn47 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_servicios");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Grabar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.uteDescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ucTeam = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tblteamsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucPuesto = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tblpuestosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucDepto = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tbldepartamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uteApellidos = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uneId = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteClave = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteWorkDay = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteCemCosto = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.uckSabado = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.uteempopyee_ppi = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.udteFechaBaja = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.udteUltimo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccFechaNac = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccFechaIngreso = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uckSolicita = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.uneCuotaInter = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.uneCuota = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.unePresupuesto = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ucSituacion = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uteIniciales = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.uteOficina = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.utePartyId = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this._frmUsuario_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblteamsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucPuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpuestosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucDepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbldepartamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteApellidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteWorkDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteCemCosto)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uckSabado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteempopyee_ppi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFechaBaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteUltimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaNac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckSolicita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCuotaInter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCuota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unePresupuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucSituacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteIniciales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOficina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utePartyId)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel7.Location = new System.Drawing.Point(37, 156);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(55, 14);
            this.ultraLabel7.TabIndex = 6;
            this.ultraLabel7.Text = "Nombres:";
            // 
            // uteDescripcion
            // 
            this.uteDescripcion.Location = new System.Drawing.Point(133, 152);
            this.uteDescripcion.MaxLength = 60;
            this.uteDescripcion.Name = "uteDescripcion";
            this.uteDescripcion.Size = new System.Drawing.Size(420, 21);
            this.uteDescripcion.TabIndex = 5;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).NotificationSettings.Text = "Nombre Invalido";
            this.uvValidador.GetValidationSettings(this.uteDescripcion).ValidationGroupKey = "required";
            this.uteDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteDescripcion_KeyDown);
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
            // ucTeam
            // 
            this.ucTeam.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucTeam.DataSource = this.tblteamsBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucTeam.DisplayLayout.Appearance = appearance2;
            this.ucTeam.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 0;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.Caption = "Pais";
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 1;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 2;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 3;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.Header.Editor = null;
            ultraGridColumn29.Header.VisiblePosition = 4;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.Header.Editor = null;
            ultraGridColumn30.Header.VisiblePosition = 5;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.Header.Caption = "Team";
            ultraGridColumn31.Header.Editor = null;
            ultraGridColumn31.Header.VisiblePosition = 6;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30,
            ultraGridColumn31});
            this.ucTeam.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucTeam.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucTeam.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.ucTeam.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucTeam.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucTeam.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucTeam.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.ucTeam.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ucTeam.DisplayLayout.MaxBandDepth = 1;
            this.ucTeam.DisplayLayout.MaxColScrollRegions = 1;
            this.ucTeam.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucTeam.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucTeam.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.ucTeam.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucTeam.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.ucTeam.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucTeam.DisplayLayout.Override.CellAppearance = appearance9;
            this.ucTeam.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucTeam.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.ucTeam.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.ucTeam.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ucTeam.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucTeam.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ucTeam.DisplayLayout.Override.RowAppearance = appearance12;
            this.ucTeam.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucTeam.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ucTeam.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucTeam.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucTeam.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucTeam.DisplayMember = "nombre";
            this.ucTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTeam.LimitToList = true;
            this.ucTeam.Location = new System.Drawing.Point(133, 341);
            this.ucTeam.Name = "ucTeam";
            this.ucTeam.Size = new System.Drawing.Size(420, 22);
            this.ucTeam.TabIndex = 17;
            this.uvValidador.GetValidationSettings(this.ucTeam).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucTeam).NotificationSettings.Text = "Team Invalido";
            this.uvValidador.GetValidationSettings(this.ucTeam).ValidationGroupKey = "required";
            this.ucTeam.ValueMember = "id_team";
            this.ucTeam.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucTeam_InitializeRow);
            this.ucTeam.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucTeam_ItemNotInList);
            this.ucTeam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucTeam_KeyDown);
            // 
            // tblteamsBindingSource
            // 
            this.tblteamsBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_teams);
            // 
            // ucPuesto
            // 
            this.ucPuesto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucPuesto.DataSource = this.tblpuestosBindingSource;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucPuesto.DisplayLayout.Appearance = appearance14;
            this.ucPuesto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn32.Header.Editor = null;
            ultraGridColumn32.Header.VisiblePosition = 0;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.Header.Editor = null;
            ultraGridColumn33.Header.VisiblePosition = 1;
            ultraGridColumn33.Hidden = true;
            ultraGridColumn34.Header.Editor = null;
            ultraGridColumn34.Header.VisiblePosition = 2;
            ultraGridColumn34.Hidden = true;
            ultraGridColumn35.Header.Editor = null;
            ultraGridColumn35.Header.VisiblePosition = 4;
            ultraGridColumn36.Header.Editor = null;
            ultraGridColumn36.Header.VisiblePosition = 5;
            ultraGridColumn37.Header.Editor = null;
            ultraGridColumn37.Header.VisiblePosition = 6;
            ultraGridColumn38.Header.Caption = "Puesto";
            ultraGridColumn38.Header.Editor = null;
            ultraGridColumn38.Header.VisiblePosition = 3;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34,
            ultraGridColumn35,
            ultraGridColumn36,
            ultraGridColumn37,
            ultraGridColumn38});
            this.ucPuesto.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ucPuesto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucPuesto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.BorderColor = System.Drawing.SystemColors.Window;
            this.ucPuesto.DisplayLayout.GroupByBox.Appearance = appearance15;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucPuesto.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.ucPuesto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance17.BackColor2 = System.Drawing.SystemColors.Control;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucPuesto.DisplayLayout.GroupByBox.PromptAppearance = appearance17;
            this.ucPuesto.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ucPuesto.DisplayLayout.MaxBandDepth = 1;
            this.ucPuesto.DisplayLayout.MaxColScrollRegions = 1;
            this.ucPuesto.DisplayLayout.MaxRowScrollRegions = 1;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucPuesto.DisplayLayout.Override.ActiveCellAppearance = appearance18;
            appearance19.BackColor = System.Drawing.SystemColors.Highlight;
            appearance19.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucPuesto.DisplayLayout.Override.ActiveRowAppearance = appearance19;
            this.ucPuesto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucPuesto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            this.ucPuesto.DisplayLayout.Override.CardAreaAppearance = appearance20;
            appearance21.BorderColor = System.Drawing.Color.Silver;
            appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucPuesto.DisplayLayout.Override.CellAppearance = appearance21;
            this.ucPuesto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucPuesto.DisplayLayout.Override.CellPadding = 0;
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance22.BorderColor = System.Drawing.SystemColors.Window;
            this.ucPuesto.DisplayLayout.Override.GroupByRowAppearance = appearance22;
            appearance23.TextHAlignAsString = "Left";
            this.ucPuesto.DisplayLayout.Override.HeaderAppearance = appearance23;
            this.ucPuesto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucPuesto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            appearance24.BorderColor = System.Drawing.Color.Silver;
            this.ucPuesto.DisplayLayout.Override.RowAppearance = appearance24;
            this.ucPuesto.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucPuesto.DisplayLayout.Override.TemplateAddRowAppearance = appearance25;
            this.ucPuesto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucPuesto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucPuesto.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucPuesto.DisplayMember = "descripcion";
            this.ucPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPuesto.LimitToList = true;
            this.ucPuesto.Location = new System.Drawing.Point(133, 96);
            this.ucPuesto.Name = "ucPuesto";
            this.ucPuesto.Size = new System.Drawing.Size(420, 22);
            this.ucPuesto.TabIndex = 3;
            this.uvValidador.GetValidationSettings(this.ucPuesto).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucPuesto).NotificationSettings.Text = "Puesto Invalido";
            this.uvValidador.GetValidationSettings(this.ucPuesto).ValidationGroupKey = "required";
            this.ucPuesto.ValueMember = "id_puesto";
            this.ucPuesto.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucPuesto_InitializeRow);
            this.ucPuesto.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucPuesto_ItemNotInList);
            this.ucPuesto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPuesto_KeyDown);
            // 
            // tblpuestosBindingSource
            // 
            this.tblpuestosBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_puestos);
            // 
            // ucDepto
            // 
            this.ucDepto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucDepto.DataSource = this.tbldepartamentoBindingSource;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucDepto.DisplayLayout.Appearance = appearance26;
            this.ucDepto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn39.Header.Editor = null;
            ultraGridColumn39.Header.VisiblePosition = 0;
            ultraGridColumn39.Hidden = true;
            ultraGridColumn40.Header.Editor = null;
            ultraGridColumn40.Header.VisiblePosition = 1;
            ultraGridColumn40.Hidden = true;
            ultraGridColumn41.Header.Editor = null;
            ultraGridColumn41.Header.VisiblePosition = 2;
            ultraGridColumn41.Hidden = true;
            ultraGridColumn42.Header.Editor = null;
            ultraGridColumn42.Header.VisiblePosition = 3;
            ultraGridColumn42.Hidden = true;
            ultraGridColumn43.Header.Editor = null;
            ultraGridColumn43.Header.VisiblePosition = 4;
            ultraGridColumn43.Hidden = true;
            ultraGridColumn44.Header.Editor = null;
            ultraGridColumn44.Header.VisiblePosition = 5;
            ultraGridColumn44.Hidden = true;
            ultraGridColumn45.Header.Editor = null;
            ultraGridColumn45.Header.VisiblePosition = 6;
            ultraGridColumn45.Hidden = true;
            ultraGridColumn46.Header.Editor = null;
            ultraGridColumn46.Header.VisiblePosition = 7;
            ultraGridColumn46.Hidden = true;
            ultraGridColumn47.Header.Editor = null;
            ultraGridColumn47.Header.VisiblePosition = 9;
            ultraGridColumn48.Header.Caption = "Departamento";
            ultraGridColumn48.Header.Editor = null;
            ultraGridColumn48.Header.VisiblePosition = 8;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn39,
            ultraGridColumn40,
            ultraGridColumn41,
            ultraGridColumn42,
            ultraGridColumn43,
            ultraGridColumn44,
            ultraGridColumn45,
            ultraGridColumn46,
            ultraGridColumn47,
            ultraGridColumn48});
            this.ucDepto.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.ucDepto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucDepto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance27.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance27.BorderColor = System.Drawing.SystemColors.Window;
            this.ucDepto.DisplayLayout.GroupByBox.Appearance = appearance27;
            appearance28.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucDepto.DisplayLayout.GroupByBox.BandLabelAppearance = appearance28;
            this.ucDepto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance29.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance29.BackColor2 = System.Drawing.SystemColors.Control;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance29.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucDepto.DisplayLayout.GroupByBox.PromptAppearance = appearance29;
            this.ucDepto.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ucDepto.DisplayLayout.MaxBandDepth = 1;
            this.ucDepto.DisplayLayout.MaxColScrollRegions = 1;
            this.ucDepto.DisplayLayout.MaxRowScrollRegions = 1;
            appearance30.BackColor = System.Drawing.SystemColors.Window;
            appearance30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucDepto.DisplayLayout.Override.ActiveCellAppearance = appearance30;
            appearance31.BackColor = System.Drawing.SystemColors.Highlight;
            appearance31.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucDepto.DisplayLayout.Override.ActiveRowAppearance = appearance31;
            this.ucDepto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucDepto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance32.BackColor = System.Drawing.SystemColors.Window;
            this.ucDepto.DisplayLayout.Override.CardAreaAppearance = appearance32;
            appearance33.BorderColor = System.Drawing.Color.Silver;
            appearance33.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucDepto.DisplayLayout.Override.CellAppearance = appearance33;
            this.ucDepto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucDepto.DisplayLayout.Override.CellPadding = 0;
            appearance34.BackColor = System.Drawing.SystemColors.Control;
            appearance34.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance34.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance34.BorderColor = System.Drawing.SystemColors.Window;
            this.ucDepto.DisplayLayout.Override.GroupByRowAppearance = appearance34;
            appearance35.TextHAlignAsString = "Left";
            this.ucDepto.DisplayLayout.Override.HeaderAppearance = appearance35;
            this.ucDepto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucDepto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.BorderColor = System.Drawing.Color.Silver;
            this.ucDepto.DisplayLayout.Override.RowAppearance = appearance36;
            this.ucDepto.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance37.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucDepto.DisplayLayout.Override.TemplateAddRowAppearance = appearance37;
            this.ucDepto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucDepto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucDepto.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucDepto.DisplayMember = "Nombre_largo";
            this.ucDepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDepto.LimitToList = true;
            this.ucDepto.Location = new System.Drawing.Point(133, 124);
            this.ucDepto.Name = "ucDepto";
            this.ucDepto.Size = new System.Drawing.Size(420, 22);
            this.ucDepto.TabIndex = 4;
            this.uvValidador.GetValidationSettings(this.ucDepto).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.ucDepto).NotificationSettings.Text = "Departamento Invalido";
            this.uvValidador.GetValidationSettings(this.ucDepto).ValidationGroupKey = "required";
            this.ucDepto.ValueMember = "id_departamento";
            this.ucDepto.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucDepto_InitializeRow);
            this.ucDepto.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(this.ucDepto_ItemNotInList);
            this.ucDepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucDepto_KeyDown);
            // 
            // tbldepartamentoBindingSource
            // 
            this.tbldepartamentoBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_departamento);
            // 
            // uteApellidos
            // 
            this.uteApellidos.Location = new System.Drawing.Point(133, 179);
            this.uteApellidos.MaxLength = 60;
            this.uteApellidos.Name = "uteApellidos";
            this.uteApellidos.Size = new System.Drawing.Size(420, 21);
            this.uteApellidos.TabIndex = 6;
            this.uvValidador.GetValidationSettings(this.uteApellidos).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteApellidos).NotificationSettings.Text = "Apellidos Invalido";
            this.uvValidador.GetValidationSettings(this.uteApellidos).ValidationGroupKey = "required";
            this.uteApellidos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteApellidos_KeyDown);
            // 
            // uneId
            // 
            this.uneId.Location = new System.Drawing.Point(133, 42);
            this.uneId.MaxLength = 10;
            this.uneId.Name = "uneId";
            this.uneId.Size = new System.Drawing.Size(73, 21);
            this.uneId.TabIndex = 0;
            this.uvValidador.GetValidationSettings(this.uneId).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneId).NotificationSettings.Text = "Nombre Invalido";
            this.uvValidador.GetValidationSettings(this.uneId).ValidationGroupKey = "required";
            this.uneId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteIdBanco_KeyDown);
            // 
            // uteClave
            // 
            this.uteClave.Location = new System.Drawing.Point(133, 287);
            this.uteClave.MaxLength = 15;
            this.uteClave.Name = "uteClave";
            this.uteClave.PasswordChar = '*';
            this.uteClave.Size = new System.Drawing.Size(73, 21);
            this.uteClave.TabIndex = 13;
            this.uvValidador.GetValidationSettings(this.uteClave).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteClave).NotificationSettings.Text = "Nombre Invalido";
            this.uvValidador.GetValidationSettings(this.uteClave).ValidationGroupKey = "required";
            this.uteClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteClave_KeyDown);
            // 
            // uteWorkDay
            // 
            this.uteWorkDay.Location = new System.Drawing.Point(424, 42);
            this.uteWorkDay.MaxLength = 10;
            this.uteWorkDay.Name = "uteWorkDay";
            this.uteWorkDay.Size = new System.Drawing.Size(129, 21);
            this.uteWorkDay.TabIndex = 1;
            this.uteWorkDay.Visible = false;
            this.uteWorkDay.ValueChanged += new System.EventHandler(this.uteWorkDay_ValueChanged);
            this.uteWorkDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteWorkDay_KeyDown);
            this.uteWorkDay.Leave += new System.EventHandler(this.uteWorkDay_Leave);
            // 
            // uteCemCosto
            // 
            this.uteCemCosto.Location = new System.Drawing.Point(424, 287);
            this.uteCemCosto.MaxLength = 10;
            this.uteCemCosto.Name = "uteCemCosto";
            this.uteCemCosto.Size = new System.Drawing.Size(129, 21);
            this.uteCemCosto.TabIndex = 14;
            this.uteCemCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteCemCosto_KeyDown);
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
            this.ultraPanel3.Size = new System.Drawing.Size(563, 46);
            this.ultraPanel3.TabIndex = 22;
            // 
            // ubCerrar
            // 
            appearance38.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance38.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance38.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance38;
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
            appearance41.Image = ((object)(resources.GetObject("appearance41.Image")));
            appearance41.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance41;
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
            this.ultraPanel4.ClientArea.Controls.Add(this.uckSabado);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel21);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteempopyee_ppi);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel20);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteWorkDay);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel19);
            this.ultraPanel4.ClientArea.Controls.Add(this.udteFechaBaja);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel18);
            this.ultraPanel4.ClientArea.Controls.Add(this.udteUltimo);
            this.ultraPanel4.ClientArea.Controls.Add(this.uccFechaNac);
            this.ultraPanel4.ClientArea.Controls.Add(this.uccFechaIngreso);
            this.ultraPanel4.ClientArea.Controls.Add(this.uckSolicita);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel17);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel16);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneCuotaInter);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel15);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneCuota);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteCemCosto);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel14);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteClave);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel13);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel12);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel11);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel10);
            this.ultraPanel4.ClientArea.Controls.Add(this.unePresupuesto);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneId);
            this.ultraPanel4.ClientArea.Controls.Add(this.ucSituacion);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel9);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel8);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteApellidos);
            this.ultraPanel4.ClientArea.Controls.Add(this.ucDepto);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel4.ClientArea.Controls.Add(this.ucPuesto);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel5);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel2);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteIniciales);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel4);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteOficina);
            this.ultraPanel4.ClientArea.Controls.Add(this.ucTeam);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel3);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel1);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel7);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteDescripcion);
            this.ultraPanel4.ClientArea.Controls.Add(this.utePartyId);
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel4.Location = new System.Drawing.Point(8, 78);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(563, 394);
            this.ultraPanel4.TabIndex = 20;
            // 
            // uckSabado
            // 
            appearance39.FontData.BoldAsString = "True";
            this.uckSabado.Appearance = appearance39;
            this.uckSabado.Location = new System.Drawing.Point(397, 369);
            this.uckSabado.Name = "uckSabado";
            this.uckSabado.Size = new System.Drawing.Size(275, 20);
            this.uckSabado.TabIndex = 20;
            this.uckSabado.Text = "No Trabaja Sábado";
            // 
            // ultraLabel21
            // 
            this.ultraLabel21.AutoSize = true;
            this.ultraLabel21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel21.Location = new System.Drawing.Point(37, 372);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel21.TabIndex = 58;
            this.ultraLabel21.Text = "Party ID:";
            this.ultraLabel21.Visible = false;
            // 
            // uteempopyee_ppi
            // 
            this.uteempopyee_ppi.Location = new System.Drawing.Point(424, 69);
            this.uteempopyee_ppi.MaxLength = 10;
            this.uteempopyee_ppi.Name = "uteempopyee_ppi";
            this.uteempopyee_ppi.Size = new System.Drawing.Size(129, 21);
            this.uteempopyee_ppi.TabIndex = 2;
            this.uteempopyee_ppi.Visible = false;
            this.uteempopyee_ppi.ValueChanged += new System.EventHandler(this.uteempopyee_ppi_ValueChanged);
            this.uteempopyee_ppi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteempopyee_ppi_KeyDown);
            this.uteempopyee_ppi.Leave += new System.EventHandler(this.uteempopyee_ppi_Leave);
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.AutoSize = true;
            this.ultraLabel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel20.Location = new System.Drawing.Point(288, 73);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(80, 14);
            this.ultraLabel20.TabIndex = 56;
            this.ultraLabel20.Text = "Empopyee ppi:";
            this.ultraLabel20.Visible = false;
            // 
            // ultraLabel19
            // 
            this.ultraLabel19.AutoSize = true;
            this.ultraLabel19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel19.Location = new System.Drawing.Point(288, 46);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(66, 14);
            this.ultraLabel19.TabIndex = 54;
            this.ultraLabel19.Text = "ID Workday:";
            this.ultraLabel19.Visible = false;
            // 
            // udteFechaBaja
            // 
            this.udteFechaBaja.DateTime = new System.DateTime(2017, 3, 4, 0, 0, 0, 0);
            this.udteFechaBaja.Location = new System.Drawing.Point(133, 260);
            this.udteFechaBaja.Name = "udteFechaBaja";
            this.udteFechaBaja.Size = new System.Drawing.Size(129, 21);
            this.udteFechaBaja.TabIndex = 11;
            this.udteFechaBaja.Value = new System.DateTime(2017, 3, 4, 0, 0, 0, 0);
            this.udteFechaBaja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.udteFechaBaja_KeyDown);
            // 
            // ultraLabel18
            // 
            this.ultraLabel18.AutoSize = true;
            this.ultraLabel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel18.Location = new System.Drawing.Point(37, 264);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(65, 14);
            this.ultraLabel18.TabIndex = 52;
            this.ultraLabel18.Text = "Fecha Baja:";
            // 
            // udteUltimo
            // 
            this.udteUltimo.DateTime = new System.DateTime(2017, 3, 4, 0, 0, 0, 0);
            this.udteUltimo.Location = new System.Drawing.Point(424, 260);
            this.udteUltimo.Name = "udteUltimo";
            this.udteUltimo.Size = new System.Drawing.Size(129, 21);
            this.udteUltimo.TabIndex = 12;
            this.udteUltimo.Value = new System.DateTime(2017, 3, 4, 0, 0, 0, 0);
            this.udteUltimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.udteUltimo_KeyDown);
            // 
            // uccFechaNac
            // 
            this.uccFechaNac.DateTime = new System.DateTime(2017, 3, 4, 0, 0, 0, 0);
            this.uccFechaNac.Location = new System.Drawing.Point(424, 232);
            this.uccFechaNac.Name = "uccFechaNac";
            this.uccFechaNac.Size = new System.Drawing.Size(129, 21);
            this.uccFechaNac.TabIndex = 10;
            this.uccFechaNac.Value = new System.DateTime(2017, 3, 4, 0, 0, 0, 0);
            this.uccFechaNac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uccFechaNac_KeyDown);
            // 
            // uccFechaIngreso
            // 
            this.uccFechaIngreso.DateTime = new System.DateTime(2017, 3, 4, 0, 0, 0, 0);
            this.uccFechaIngreso.Location = new System.Drawing.Point(133, 233);
            this.uccFechaIngreso.Name = "uccFechaIngreso";
            this.uccFechaIngreso.Size = new System.Drawing.Size(144, 21);
            this.uccFechaIngreso.TabIndex = 9;
            this.uccFechaIngreso.Value = new System.DateTime(2017, 3, 4, 0, 0, 0, 0);
            this.uccFechaIngreso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uccFechaIngreso_KeyDown);
            // 
            // uckSolicita
            // 
            appearance40.FontData.BoldAsString = "True";
            this.uckSolicita.Appearance = appearance40;
            this.uckSolicita.Location = new System.Drawing.Point(133, 368);
            this.uckSolicita.Name = "uckSolicita";
            this.uckSolicita.Size = new System.Drawing.Size(275, 20);
            this.uckSolicita.TabIndex = 19;
            this.uckSolicita.Text = "Accesa a los Módulos de Administración";
            this.uckSolicita.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uckSolicita_KeyDown);
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.AutoSize = true;
            this.ultraLabel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel17.Location = new System.Drawing.Point(288, 264);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(123, 14);
            this.ultraLabel17.TabIndex = 50;
            this.ultraLabel17.Text = "Ult. Reporte Entregado:";
            // 
            // ultraLabel16
            // 
            this.ultraLabel16.AutoSize = true;
            this.ultraLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel16.Location = new System.Drawing.Point(288, 318);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(64, 14);
            this.ultraLabel16.TabIndex = 48;
            this.ultraLabel16.Text = "Cuota USD:";
            // 
            // uneCuotaInter
            // 
            this.uneCuotaInter.Location = new System.Drawing.Point(424, 314);
            this.uneCuotaInter.MaskInput = "nnnnnnnnnn.nn";
            this.uneCuotaInter.Name = "uneCuotaInter";
            this.uneCuotaInter.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneCuotaInter.Size = new System.Drawing.Size(129, 21);
            this.uneCuotaInter.TabIndex = 16;
            this.uneCuotaInter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneCuotaInter_KeyDown);
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.AutoSize = true;
            this.ultraLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel15.Location = new System.Drawing.Point(37, 318);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(68, 14);
            this.ultraLabel15.TabIndex = 46;
            this.ultraLabel15.Text = "Cuota Local:";
            // 
            // uneCuota
            // 
            this.uneCuota.Location = new System.Drawing.Point(133, 314);
            this.uneCuota.Name = "uneCuota";
            this.uneCuota.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.uneCuota.Size = new System.Drawing.Size(129, 21);
            this.uneCuota.TabIndex = 15;
            this.uneCuota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneCuota_KeyDown);
            // 
            // ultraLabel14
            // 
            this.ultraLabel14.AutoSize = true;
            this.ultraLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel14.Location = new System.Drawing.Point(288, 291);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(65, 14);
            this.ultraLabel14.TabIndex = 44;
            this.ultraLabel14.Text = "CEM Costo:";
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.AutoSize = true;
            this.ultraLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel13.Location = new System.Drawing.Point(37, 291);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(38, 14);
            this.ultraLabel13.TabIndex = 42;
            this.ultraLabel13.Text = "Clave:";
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.AutoSize = true;
            this.ultraLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel12.Location = new System.Drawing.Point(288, 236);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(102, 14);
            this.ultraLabel12.TabIndex = 40;
            this.ultraLabel12.Text = "Fecha Nacimiento:";
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.AutoSize = true;
            this.ultraLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel11.Location = new System.Drawing.Point(37, 236);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(83, 14);
            this.ultraLabel11.TabIndex = 38;
            this.ultraLabel11.Text = "Fecha Ingreso:";
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel10.Location = new System.Drawing.Point(288, 210);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(108, 14);
            this.ultraLabel10.TabIndex = 36;
            this.ultraLabel10.Text = "Presupuesto Horas:";
            // 
            // unePresupuesto
            // 
            this.unePresupuesto.Location = new System.Drawing.Point(424, 206);
            this.unePresupuesto.Name = "unePresupuesto";
            this.unePresupuesto.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.unePresupuesto.Size = new System.Drawing.Size(129, 21);
            this.unePresupuesto.TabIndex = 8;
            this.unePresupuesto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.unePresupuesto_KeyDown);
            // 
            // ucSituacion
            // 
            this.ucSituacion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            valueListItem1.DataValue = "A";
            valueListItem1.DisplayText = "Activa";
            valueListItem2.DataValue = "B";
            valueListItem2.DisplayText = "Baja";
            this.ucSituacion.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.ucSituacion.Location = new System.Drawing.Point(133, 206);
            this.ucSituacion.Name = "ucSituacion";
            this.ucSituacion.Size = new System.Drawing.Size(144, 21);
            this.ucSituacion.TabIndex = 7;
            this.ucSituacion.ItemNotInList += new Infragistics.Win.UltraWinEditors.UltraComboEditor.ItemNotInListEventHandler(this.ucSituacion_ItemNotInList);
            this.ucSituacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucSituacion_KeyDown);
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.AutoSize = true;
            this.ultraLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel9.Location = new System.Drawing.Point(37, 210);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(92, 14);
            this.ultraLabel9.TabIndex = 33;
            this.ultraLabel9.Text = "Situación Actual:";
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.AutoSize = true;
            this.ultraLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel8.Location = new System.Drawing.Point(37, 183);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(56, 14);
            this.ultraLabel8.TabIndex = 32;
            this.ultraLabel8.Text = "Apellidos:";
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(37, 128);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(82, 14);
            this.ultraLabel6.TabIndex = 30;
            this.ultraLabel6.Text = "Departamento:";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(37, 100);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(44, 14);
            this.ultraLabel5.TabIndex = 28;
            this.ultraLabel5.Text = "Puesto:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(37, 73);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel2.TabIndex = 26;
            this.ultraLabel2.Text = "Iniciales:";
            // 
            // uteIniciales
            // 
            this.uteIniciales.Location = new System.Drawing.Point(133, 69);
            this.uteIniciales.MaxLength = 60;
            this.uteIniciales.Name = "uteIniciales";
            this.uteIniciales.Size = new System.Drawing.Size(48, 21);
            this.uteIniciales.TabIndex = 2;
            this.uteIniciales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteIniciales_KeyDown);
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(37, 10);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(43, 14);
            this.ultraLabel4.TabIndex = 24;
            this.ultraLabel4.Text = "Oficina:";
            // 
            // uteOficina
            // 
            this.uteOficina.Enabled = false;
            this.uteOficina.Location = new System.Drawing.Point(133, 6);
            this.uteOficina.MaxLength = 60;
            this.uteOficina.Name = "uteOficina";
            this.uteOficina.Size = new System.Drawing.Size(420, 21);
            this.uteOficina.TabIndex = 23;
            this.uteOficina.TabStop = false;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(37, 345);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(37, 14);
            this.ultraLabel3.TabIndex = 22;
            this.ultraLabel3.Text = "Team:";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(37, 46);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(60, 14);
            this.ultraLabel1.TabIndex = 6;
            this.ultraLabel1.Text = "Empleado:";
            // 
            // utePartyId
            // 
            this.utePartyId.Location = new System.Drawing.Point(133, 368);
            this.utePartyId.MaxLength = 30;
            this.utePartyId.Name = "utePartyId";
            this.utePartyId.Size = new System.Drawing.Size(129, 21);
            this.utePartyId.TabIndex = 18;
            this.utePartyId.Visible = false;
            this.utePartyId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.utePartyId_KeyDown);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 440);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Right
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(571, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Name = "_frmUsuario_UltraFormManager_Dock_Area_Right";
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 440);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(579, 32);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 472);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(579, 8);
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 480);
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
            this.Name = "frmEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleado";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblteamsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucPuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpuestosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucDepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbldepartamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteApellidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteWorkDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteCemCosto)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ClientArea.PerformLayout();
            this.ultraPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uckSabado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteempopyee_ppi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteFechaBaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteUltimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaNac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFechaIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckSolicita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCuotaInter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCuota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unePresupuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucSituacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteIniciales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOficina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utePartyId)).EndInit();
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
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDescripcion;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucTeam;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneCuotaInter;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneCuota;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteCemCosto;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteClave;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor unePresupuesto;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uneId;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ucSituacion;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteApellidos;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucDepto;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucPuesto;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteIniciales;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteOficina;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckSolicita;
        private System.Windows.Forms.BindingSource tblpuestosBindingSource;
        private System.Windows.Forms.BindingSource tbldepartamentoBindingSource;
        private System.Windows.Forms.BindingSource tblteamsBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor uccFechaNac;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor uccFechaIngreso;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteUltimo;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udteFechaBaja;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteWorkDay;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteempopyee_ppi;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor utePartyId;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckSabado;
    }
}