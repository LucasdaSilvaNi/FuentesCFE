﻿namespace TiempoEnProceso.Forms
{
    partial class frmLineas
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_lineas", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_grupos");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("descripcion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Socio_encargado");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_linea_pwcglobal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("edit", 0);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("delete", 1);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Nuevo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refrescar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cerrar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FilterClean");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Nuevo");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refrescar");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cerrar");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("FilterClean");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ugData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._frmUnidades_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._frmUnidades_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmUnidades_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmUnidades_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tbllineasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbllineasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ugData);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 43);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(640, 223);
            this.ultraGroupBox1.TabIndex = 10;
            this.ultraGroupBox1.Text = "Lineas";
            // 
            // ugData
            // 
            this.ugData.DataSource = this.tbllineasBindingSource;
            this.ugData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.Caption = "Línea";
            ultraGridColumn1.Header.VisiblePosition = 2;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.Caption = "Descripción";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.Caption = "Oficina";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn13.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.Editar;
            ultraGridColumn13.CellButtonAppearance = appearance1;
            ultraGridColumn13.Header.Caption = "";
            ultraGridColumn13.Header.VisiblePosition = 1;
            ultraGridColumn13.MaxWidth = 20;
            ultraGridColumn13.MinLength = 14;
            ultraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn13.Tag = "E_BANCOS";
            ultraGridColumn13.Width = 20;
            ultraGridColumn14.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance2.Image = global::TiempoEnProceso.Properties.Resources.Menos;
            ultraGridColumn14.CellButtonAppearance = appearance2;
            ultraGridColumn14.Header.Caption = "";
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn14.MaxWidth = 20;
            ultraGridColumn14.MinWidth = 14;
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn14.Tag = "B_BANCOS";
            ultraGridColumn14.Width = 20;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn13,
            ultraGridColumn14});
            this.ugData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ugData.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.ugData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.ugData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ugData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ugData.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ugData.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugData.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ugData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ugData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ugData.Location = new System.Drawing.Point(3, 16);
            this.ugData.Name = "ugData";
            this.ugData.Size = new System.Drawing.Size(634, 204);
            this.ugData.TabIndex = 6;
            this.ugData.Text = "ultraGrid1";
            this.ugData.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ugData_InitializeLayout);
            this.ugData.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ugData_InitializeRow);
            this.ugData.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.ugData_ClickCellButton);
            this.ugData.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(this.ugData_DoubleClickCell);
            // 
            // _frmUnidades_Toolbars_Dock_Area_Right
            // 
            this._frmUnidades_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUnidades_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._frmUnidades_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._frmUnidades_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUnidades_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(640, 43);
            this._frmUnidades_Toolbars_Dock_Area_Right.Name = "_frmUnidades_Toolbars_Dock_Area_Right";
            this._frmUnidades_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 223);
            this._frmUnidades_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.MdiMergeable = false;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            buttonTool1.InstanceProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool7});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars;
            ultraToolbar1.Settings.UseLargeImages = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.Text = "UltraToolbar1";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            appearance3.Image = global::TiempoEnProceso.Properties.Resources.Agregar;
            buttonTool4.SharedPropsInternal.AppearancesLarge.Appearance = appearance3;
            buttonTool4.SharedPropsInternal.Caption = "Nuevo";
            buttonTool4.SharedPropsInternal.Tag = "A_BANCOS";
            appearance4.Image = global::TiempoEnProceso.Properties.Resources.Cambiar_Valores_por_Defecto;
            buttonTool5.SharedPropsInternal.AppearancesLarge.Appearance = appearance4;
            buttonTool5.SharedPropsInternal.Caption = "Refrescar";
            appearance5.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            buttonTool6.SharedPropsInternal.AppearancesLarge.Appearance = appearance5;
            buttonTool6.SharedPropsInternal.Caption = "Cerrar";
            appearance6.Image = global::TiempoEnProceso.Properties.Resources._1305039480_filter_delete;
            buttonTool8.SharedPropsInternal.AppearancesLarge.Appearance = appearance6;
            buttonTool8.SharedPropsInternal.Caption = "FilterClean";
            buttonTool8.SharedPropsInternal.Visible = false;
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool8});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _frmUnidades_Toolbars_Dock_Area_Left
            // 
            this._frmUnidades_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUnidades_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._frmUnidades_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._frmUnidades_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUnidades_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 43);
            this._frmUnidades_Toolbars_Dock_Area_Left.Name = "_frmUnidades_Toolbars_Dock_Area_Left";
            this._frmUnidades_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 223);
            this._frmUnidades_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmUnidades_Toolbars_Dock_Area_Bottom
            // 
            this._frmUnidades_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUnidades_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._frmUnidades_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._frmUnidades_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUnidades_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 266);
            this._frmUnidades_Toolbars_Dock_Area_Bottom.Name = "_frmUnidades_Toolbars_Dock_Area_Bottom";
            this._frmUnidades_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(640, 0);
            this._frmUnidades_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmUnidades_Toolbars_Dock_Area_Top
            // 
            this._frmUnidades_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUnidades_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._frmUnidades_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._frmUnidades_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUnidades_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmUnidades_Toolbars_Dock_Area_Top.Name = "_frmUnidades_Toolbars_Dock_Area_Top";
            this._frmUnidades_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(640, 43);
            this._frmUnidades_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // tbllineasBindingSource
            // 
            this.tbllineasBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_lineas);
            // 
            // frmLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 266);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this._frmUnidades_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._frmUnidades_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._frmUnidades_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._frmUnidades_Toolbars_Dock_Area_Top);
            this.Name = "frmLineas";
            this.Text = "Lineas";
            this.Load += new System.EventHandler(this.InitialLoad);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbllineasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmUnidades_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmUnidades_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmUnidades_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmUnidades_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugData;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private System.Windows.Forms.BindingSource tbllineasBindingSource;
    }
}