namespace TiempoEnProceso.Forms
{
    partial class frmGastoAdmon
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Eliminar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_gastos_administrativos_detalle_empresas", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id_Gasto");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Activo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_gastos_administrativos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("edit", 0);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastoAdmon));
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("delete", 1);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo6 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Agregar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Misc.ValidationGroup validationGroup2 = new Infragistics.Win.Misc.ValidationGroup("required");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo7 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo8 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Grabar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.uckDistribucion = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uteIdBanco = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.uteDescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ubEliminaData = new Infragistics.Win.Misc.UltraButton();
            this.ugDataT = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tblgastosadministrativosdetalleempresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ubAgregarData = new Infragistics.Win.Misc.UltraButton();
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._frmUsuario_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uckDistribucion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteIdBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugDataT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblgastosadministrativosdetalleempresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ultraPanel4);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(479, 165);
            // 
            // ultraPanel4
            // 
            // 
            // ultraPanel4.ClientArea
            // 
            this.ultraPanel4.ClientArea.Controls.Add(this.uckDistribucion);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteIdBanco);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel1);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel7);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteDescripcion);
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel4.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(479, 165);
            this.ultraPanel4.TabIndex = 20;
            // 
            // uckDistribucion
            // 
            this.uckDistribucion.Location = new System.Drawing.Point(102, 88);
            this.uckDistribucion.Name = "uckDistribucion";
            this.uckDistribucion.Size = new System.Drawing.Size(275, 20);
            this.uckDistribucion.TabIndex = 2;
            this.uckDistribucion.Text = "Distribución Proporcional Socios";
            this.uckDistribucion.CheckedChanged += new System.EventHandler(this.uckDistribucion_CheckedChanged);
            // 
            // uteIdBanco
            // 
            this.uteIdBanco.Location = new System.Drawing.Point(102, 24);
            this.uteIdBanco.MaxLength = 4;
            this.uteIdBanco.Name = "uteIdBanco";
            this.uteIdBanco.Size = new System.Drawing.Size(52, 21);
            this.uteIdBanco.TabIndex = 0;
            this.uvValidador.GetValidationSettings(this.uteIdBanco).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteIdBanco).NotificationSettings.Text = "ID de Oficina Invalido";
            this.uvValidador.GetValidationSettings(this.uteIdBanco).ValidationGroupKey = "required";
            this.uteIdBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteIdBanco_KeyDown);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(27, 28);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(19, 14);
            this.ultraLabel1.TabIndex = 6;
            this.ultraLabel1.Text = "ID:";
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel7.Location = new System.Drawing.Point(27, 64);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(69, 14);
            this.ultraLabel7.TabIndex = 6;
            this.ultraLabel7.Text = "Descripción:";
            // 
            // uteDescripcion
            // 
            this.uteDescripcion.Location = new System.Drawing.Point(102, 60);
            this.uteDescripcion.MaxLength = 100;
            this.uteDescripcion.Name = "uteDescripcion";
            this.uteDescripcion.Size = new System.Drawing.Size(346, 21);
            this.uteDescripcion.TabIndex = 1;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).NotificationSettings.Text = "Nombre Invalido";
            this.uvValidador.GetValidationSettings(this.uteDescripcion).ValidationGroupKey = "required";
            this.uteDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteDescripcion_KeyDown);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraPanel1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(479, 165);
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ubEliminaData);
            this.ultraPanel1.ClientArea.Controls.Add(this.ugDataT);
            this.ultraPanel1.ClientArea.Controls.Add(this.ubAgregarData);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(479, 165);
            this.ultraPanel1.TabIndex = 0;
            // 
            // ubEliminaData
            // 
            appearance8.Image = global::TiempoEnProceso.Properties.Resources.Menos;
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubEliminaData.Appearance = appearance8;
            this.ubEliminaData.AutoSize = true;
            this.ubEliminaData.ImageSize = new System.Drawing.Size(32, 32);
            this.ubEliminaData.Location = new System.Drawing.Point(426, 49);
            this.ubEliminaData.Name = "ubEliminaData";
            this.ubEliminaData.ShowOutline = false;
            this.ubEliminaData.Size = new System.Drawing.Size(40, 40);
            this.ubEliminaData.TabIndex = 106;
            ultraToolTipInfo5.ToolTipText = "Eliminar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubEliminaData, ultraToolTipInfo5);
            this.ubEliminaData.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubEliminaData.Click += new System.EventHandler(this.ubEliminaData_Click);
            // 
            // ugDataT
            // 
            this.ugDataT.DataSource = this.tblgastosadministrativosdetalleempresasBindingSource;
            this.ugDataT.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 1;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.Caption = "Empresa";
            ultraGridColumn17.Header.Editor = null;
            ultraGridColumn17.Header.VisiblePosition = 2;
            ultraGridColumn17.MaxWidth = 300;
            ultraGridColumn17.MinWidth = 300;
            ultraGridColumn17.Width = 300;
            ultraGridColumn18.Header.Editor = null;
            ultraGridColumn18.Header.VisiblePosition = 3;
            ultraGridColumn19.Header.Editor = null;
            ultraGridColumn19.Header.VisiblePosition = 4;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn63.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn63.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            ultraGridColumn63.CellButtonAppearance = appearance5;
            ultraGridColumn63.Header.Caption = "";
            ultraGridColumn63.Header.Editor = null;
            ultraGridColumn63.Header.VisiblePosition = 5;
            ultraGridColumn63.Hidden = true;
            ultraGridColumn63.MaxWidth = 20;
            ultraGridColumn63.MinLength = 14;
            ultraGridColumn63.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn63.Tag = "E_BANCOS";
            ultraGridColumn63.Width = 20;
            ultraGridColumn64.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn64.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            ultraGridColumn64.CellButtonAppearance = appearance6;
            ultraGridColumn64.Header.Caption = "";
            ultraGridColumn64.Header.Editor = null;
            ultraGridColumn64.Header.VisiblePosition = 0;
            ultraGridColumn64.Hidden = true;
            ultraGridColumn64.MaxWidth = 20;
            ultraGridColumn64.MinWidth = 14;
            ultraGridColumn64.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn64.Tag = "B_BANCOS";
            ultraGridColumn64.Width = 20;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn63,
            ultraGridColumn64});
            this.ugDataT.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugDataT.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ugDataT.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ugDataT.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.ugDataT.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ugDataT.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.ugDataT.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.ugDataT.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ugDataT.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ugDataT.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugDataT.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugDataT.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugDataT.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ugDataT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ugDataT.Location = new System.Drawing.Point(5, 3);
            this.ugDataT.Name = "ugDataT";
            this.ugDataT.Size = new System.Drawing.Size(404, 159);
            this.ugDataT.TabIndex = 105;
            this.ugDataT.Text = "ultraGrid1";
            this.ugDataT.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugDataT_InitializeLayout);
            this.ugDataT.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugDataT_ClickCellButton);
            // 
            // tblgastosadministrativosdetalleempresasBindingSource
            // 
            this.tblgastosadministrativosdetalleempresasBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_gastos_administrativos_detalle_empresas);
            // 
            // ubAgregarData
            // 
            appearance9.Image = global::TiempoEnProceso.Properties.Resources.mas;
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregarData.Appearance = appearance9;
            this.ubAgregarData.AutoSize = true;
            this.ubAgregarData.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregarData.Location = new System.Drawing.Point(426, 3);
            this.ubAgregarData.Name = "ubAgregarData";
            this.ubAgregarData.ShowOutline = false;
            this.ubAgregarData.Size = new System.Drawing.Size(40, 40);
            this.ubAgregarData.TabIndex = 103;
            ultraToolTipInfo6.ToolTipText = "Agregar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregarData, ultraToolTipInfo6);
            this.ubAgregarData.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregarData.Click += new System.EventHandler(this.ubAgregarData_Click);
            // 
            // uvValidador
            // 
            appearance10.Image = global::TiempoEnProceso.Properties.Resources.exclamation;
            this.uvValidador.ErrorAppearance = appearance10;
            this.uvValidador.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.Asterisk;
            this.uvValidador.NotificationSettings.Action = Infragistics.Win.Misc.NotificationAction.None;
            validationGroup2.Key = "required";
            this.uvValidador.ValidationGroups.Add(validationGroup2);
            this.uvValidador.ValidationTrigger = Infragistics.Win.Misc.ValidationTrigger.OnPropertyValueChanged;
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
            appearance11.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance11;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(41, 3);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(40, 40);
            this.ubCerrar.TabIndex = 17;
            ultraToolTipInfo7.ToolTipText = "Cancelar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubCerrar, ultraToolTipInfo7);
            this.ubCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubCerrar.Click += new System.EventHandler(this.ubCerrar_Click);
            // 
            // ubAgregar
            // 
            appearance12.Image = ((object)(resources.GetObject("appearance12.Image")));
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance12;
            this.ubAgregar.AutoSize = true;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(3, 3);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(40, 40);
            this.ubAgregar.TabIndex = 16;
            ultraToolTipInfo8.ToolTipText = "Grabar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregar, ultraToolTipInfo8);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 237);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 237);
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
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 269);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(499, 8);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(8, 78);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(483, 191);
            this.ultraTabControl1.TabIndex = 7;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "General";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Empresas";
            ultraTab2.Visible = false;
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(479, 165);
            // 
            // frmGastoAdmon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 277);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGastoAdmon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gasto Administrativo";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ClientArea.PerformLayout();
            this.ultraPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uckDistribucion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteIdBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugDataT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblgastosadministrativosdetalleempresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
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
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteIdBanco;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckDistribucion;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraButton ubAgregarData;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugDataT;
        private System.Windows.Forms.BindingSource tblgastosadministrativosdetalleempresasBindingSource;
        private Infragistics.Win.Misc.UltraButton ubEliminaData;
    }
}