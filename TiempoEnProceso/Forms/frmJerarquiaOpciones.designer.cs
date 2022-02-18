namespace TiempoEnProceso.Forms
{
    partial class frmJerarquiaOpciones
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Grabar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_opciones", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("menu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("opcion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("pantalla");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("orden_menu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Tbl_detalle_solicitud_cheque", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_solicitud_cheque");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Linea_detalle");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id_Unidad_Medida");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion_Bien_Suministro");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio_Unitario");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Total_solicitado");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tbl_solicitud_cheque");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJerarquiaOpciones));
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.uteID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.uteDescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.uneNivel = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this._frmUsuario_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ucOpcion = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tblopcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ugDataPermisos = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.btAgregar = new Infragistics.Win.Misc.UltraButton();
            this.tbloficinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uteID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uneNivel)).BeginInit();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucOpcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblopcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugDataPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel7.Location = new System.Drawing.Point(24, 24);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(45, 14);
            this.ultraLabel7.TabIndex = 6;
            this.ultraLabel7.Text = "Código:";
            // 
            // uteID
            // 
            this.uteID.Location = new System.Drawing.Point(99, 20);
            this.uteID.MaxLength = 4;
            this.uteID.Name = "uteID";
            this.uteID.Size = new System.Drawing.Size(91, 21);
            this.uteID.TabIndex = 0;
            this.uvValidador.GetValidationSettings(this.uteID).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteID).NotificationSettings.Text = "Reporte Invalido";
            this.uvValidador.GetValidationSettings(this.uteID).ValidationGroupKey = "required";
            this.uteID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteID_KeyDown);
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
            // uteDescripcion
            // 
            this.uteDescripcion.Location = new System.Drawing.Point(99, 56);
            this.uteDescripcion.MaxLength = 25;
            this.uteDescripcion.Name = "uteDescripcion";
            this.uteDescripcion.Size = new System.Drawing.Size(261, 21);
            this.uteDescripcion.TabIndex = 1;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).NotificationSettings.Text = "Descripción Invalida";
            this.uvValidador.GetValidationSettings(this.uteDescripcion).ValidationGroupKey = "required";
            this.uteDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteDireccion_KeyDown);
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
            this.ultraPanel3.Size = new System.Drawing.Size(495, 46);
            this.ultraPanel3.TabIndex = 22;
            // 
            // ubCerrar
            // 
            appearance2.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance2;
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
            appearance17.Image = ((object)(resources.GetObject("appearance17.Image")));
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance17;
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
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneNivel);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel2);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteDescripcion);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel7);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteID);
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel4.Location = new System.Drawing.Point(8, 78);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(495, 128);
            this.ultraPanel4.TabIndex = 20;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(24, 96);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(33, 14);
            this.ultraLabel6.TabIndex = 2;
            this.ultraLabel6.Text = "Nivel:";
            // 
            // uneNivel
            // 
            this.uneNivel.Location = new System.Drawing.Point(99, 92);
            this.uneNivel.MaskInput = "nn";
            this.uneNivel.Name = "uneNivel";
            this.uneNivel.Size = new System.Drawing.Size(52, 21);
            this.uneNivel.TabIndex = 2;
            this.uneNivel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneNivel_KeyDown);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(24, 60);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(69, 14);
            this.ultraLabel2.TabIndex = 8;
            this.ultraLabel2.Text = "Descripción:";
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
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 384);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Right
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(503, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Name = "_frmUsuario_UltraFormManager_Dock_Area_Right";
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 384);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(511, 32);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 416);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(511, 8);
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ucOpcion);
            this.ultraPanel1.ClientArea.Controls.Add(this.ugDataPermisos);
            this.ultraPanel1.ClientArea.Controls.Add(this.ultraLabel4);
            this.ultraPanel1.ClientArea.Controls.Add(this.btAgregar);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.Location = new System.Drawing.Point(8, 206);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(495, 210);
            this.ultraPanel1.TabIndex = 27;
            // 
            // ucOpcion
            // 
            this.ucOpcion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucOpcion.DataSource = this.tblopcionesBindingSource;
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucOpcion.DisplayLayout.Appearance = appearance3;
            this.ucOpcion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
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
            ultraGridColumn5.Header.Caption = "Opcion";
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.ucOpcion.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucOpcion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucOpcion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.ucOpcion.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucOpcion.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.ucOpcion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucOpcion.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.ucOpcion.DisplayLayout.MaxColScrollRegions = 1;
            this.ucOpcion.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucOpcion.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucOpcion.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.ucOpcion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucOpcion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.ucOpcion.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucOpcion.DisplayLayout.Override.CellAppearance = appearance10;
            this.ucOpcion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucOpcion.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.ucOpcion.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.TextHAlignAsString = "Left";
            this.ucOpcion.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.ucOpcion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucOpcion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.ucOpcion.DisplayLayout.Override.RowAppearance = appearance13;
            this.ucOpcion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucOpcion.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.ucOpcion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucOpcion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucOpcion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucOpcion.DisplayMember = "opcion";
            this.ucOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucOpcion.LimitToList = true;
            this.ucOpcion.Location = new System.Drawing.Point(99, 9);
            this.ucOpcion.Name = "ucOpcion";
            this.ucOpcion.Size = new System.Drawing.Size(272, 22);
            this.ucOpcion.TabIndex = 9;
            this.ucOpcion.ValueMember = "opcion";
            this.ucOpcion.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucOpcion_InitializeRow);
            // 
            // tblopcionesBindingSource
            // 
            this.tblopcionesBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_opciones);
            // 
            // ugDataPermisos
            // 
            this.ugDataPermisos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn21.Header.Editor = null;
            ultraGridColumn21.Header.VisiblePosition = 0;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.Editor = null;
            ultraGridColumn22.Header.VisiblePosition = 1;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.Editor = null;
            ultraGridColumn23.Header.VisiblePosition = 2;
            ultraGridColumn23.MaxWidth = 80;
            ultraGridColumn23.MinWidth = 80;
            ultraGridColumn23.Width = 80;
            ultraGridColumn24.Header.Caption = "Unidad";
            ultraGridColumn24.Header.Editor = null;
            ultraGridColumn24.Header.VisiblePosition = 3;
            ultraGridColumn24.MaxWidth = 120;
            ultraGridColumn24.MinWidth = 120;
            ultraGridColumn24.Width = 120;
            ultraGridColumn25.Header.Caption = "Descripción";
            ultraGridColumn25.Header.Editor = null;
            ultraGridColumn25.Header.VisiblePosition = 4;
            ultraGridColumn25.MaxLength = 100;
            ultraGridColumn25.Width = 310;
            appearance15.TextHAlignAsString = "Right";
            ultraGridColumn26.CellAppearance = appearance15;
            ultraGridColumn26.Header.Caption = "Precio";
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 5;
            ultraGridColumn26.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn26.MaxWidth = 120;
            ultraGridColumn26.MinWidth = 120;
            ultraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive;
            ultraGridColumn26.Width = 120;
            ultraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            appearance16.TextHAlignAsString = "Right";
            ultraGridColumn27.CellAppearance = appearance16;
            ultraGridColumn27.Header.Caption = "Total";
            ultraGridColumn27.Header.Editor = null;
            ultraGridColumn27.Header.VisiblePosition = 6;
            ultraGridColumn27.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            ultraGridColumn27.MaxWidth = 120;
            ultraGridColumn27.MinWidth = 120;
            ultraGridColumn27.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative;
            ultraGridColumn27.Width = 120;
            ultraGridColumn28.Header.Editor = null;
            ultraGridColumn28.Header.VisiblePosition = 7;
            ultraGridColumn28.Hidden = true;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28});
            this.ugDataPermisos.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.ugDataPermisos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ugDataPermisos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ugDataPermisos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.ugDataPermisos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ugDataPermisos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.ugDataPermisos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.ugDataPermisos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ugDataPermisos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ugDataPermisos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugDataPermisos.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugDataPermisos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugDataPermisos.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Vertical;
            this.ugDataPermisos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ugDataPermisos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ugDataPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ugDataPermisos.Location = new System.Drawing.Point(0, 46);
            this.ugDataPermisos.Name = "ugDataPermisos";
            this.ugDataPermisos.Size = new System.Drawing.Size(495, 164);
            this.ugDataPermisos.TabIndex = 7;
            this.ugDataPermisos.Text = "ultraGrid1";
            this.ugDataPermisos.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugDataPermisos_InitializeLayout);
            this.ugDataPermisos.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugDataPermisos_ClickCellButton);
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Location = new System.Drawing.Point(24, 13);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(43, 14);
            this.ultraLabel4.TabIndex = 5;
            this.ultraLabel4.Text = "Opcion:";
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(400, 13);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(75, 23);
            this.btAgregar.TabIndex = 4;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // tbloficinaBindingSource
            // 
            this.tbloficinaBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_oficina);
            // 
            // frmJerarquiaOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 424);
            this.Controls.Add(this.ultraPanel1);
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
            this.Name = "frmJerarquiaOpciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puestos";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uteID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ClientArea.PerformLayout();
            this.ultraPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uneNivel)).EndInit();
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucOpcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblopcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ugDataPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).EndInit();
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
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteID;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDescripcion;
        private System.Windows.Forms.BindingSource tbloficinaBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneNivel;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraButton btAgregar;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugDataPermisos;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucOpcion;
        private System.Windows.Forms.BindingSource tblopcionesBindingSource;
    }
}