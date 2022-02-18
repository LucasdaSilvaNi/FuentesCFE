namespace TiempoEnProceso
{
    partial class frmSelOficina
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
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("direccion");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("periodo_proceso");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("id_pais");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("parametro_reportes");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Status");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("permite_facturar_en_periodo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_Telefono");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Numero_Fax");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("correo_electronico");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("codigo_fiscal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("desc", 0);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelOficina));
            this.ultraValidator1 = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ucDepto = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.tbloficinaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.frmLogin_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ubAceptar = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this._frmLogin_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmLogin_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmLogin_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmLogin_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraValidator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucDepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.frmLogin_Fill_Panel.ClientArea.SuspendLayout();
            this.frmLogin_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraValidator1
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.exclamation;
            this.ultraValidator1.ErrorAppearance = appearance1;
            this.ultraValidator1.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.Asterisk;
            this.ultraValidator1.NotificationSettings.Action = Infragistics.Win.Misc.NotificationAction.None;
            validationGroup1.Key = "required";
            this.ultraValidator1.ValidationGroups.Add(validationGroup1);
            this.ultraValidator1.ValidationTrigger = Infragistics.Win.Misc.ValidationTrigger.OnPropertyValueChanged;
            // 
            // ucDepto
            // 
            this.ucDepto.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.ucDepto.DataSource = this.tbloficinaBindingSource;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ucDepto.DisplayLayout.Appearance = appearance2;
            this.ucDepto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn16.Header.Editor = null;
            ultraGridColumn16.Header.VisiblePosition = 2;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn15.Header.Caption = "Pais";
            ultraGridColumn15.Header.Editor = null;
            ultraGridColumn15.Header.VisiblePosition = 1;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn4.Header.Editor = null;
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Editor = null;
            ultraGridColumn5.Header.VisiblePosition = 6;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 7;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 8;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 10;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 11;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 12;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn26.Header.Caption = "Oficina";
            ultraGridColumn26.Header.Editor = null;
            ultraGridColumn26.Header.VisiblePosition = 9;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn16,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn15,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn26});
            this.ucDepto.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ucDepto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ucDepto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.ucDepto.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucDepto.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.ucDepto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ucDepto.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.ucDepto.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ucDepto.DisplayLayout.MaxBandDepth = 1;
            this.ucDepto.DisplayLayout.MaxColScrollRegions = 1;
            this.ucDepto.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucDepto.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ucDepto.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.ucDepto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ucDepto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.ucDepto.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ucDepto.DisplayLayout.Override.CellAppearance = appearance9;
            this.ucDepto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ucDepto.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.ucDepto.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.ucDepto.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ucDepto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ucDepto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.ucDepto.DisplayLayout.Override.RowAppearance = appearance12;
            this.ucDepto.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucDepto.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.ucDepto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ucDepto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ucDepto.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ucDepto.DisplayMember = "Nombre";
            this.ucDepto.DropDownWidth = 0;
            this.ucDepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDepto.LimitToList = true;
            this.ucDepto.Location = new System.Drawing.Point(91, 30);
            this.ucDepto.Name = "ucDepto";
            this.ucDepto.Size = new System.Drawing.Size(226, 22);
            this.ucDepto.TabIndex = 4;
            this.ultraValidator1.GetValidationSettings(this.ucDepto).IsRequired = true;
            this.ultraValidator1.GetValidationSettings(this.ucDepto).NotificationSettings.Text = "Selección invalida";
            this.ultraValidator1.GetValidationSettings(this.ucDepto).ValidationGroupKey = "required";
            this.ucDepto.ValueMember = "id_oficina";
            this.ucDepto.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.ucDepto_InitializeRow);
            this.ucDepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucDepto_KeyDown);
            // 
            // tbloficinaBindingSource
            // 
            this.tbloficinaBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_oficina);
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // frmLogin_Fill_Panel
            // 
            // 
            // frmLogin_Fill_Panel.ClientArea
            // 
            this.frmLogin_Fill_Panel.ClientArea.Controls.Add(this.ucDepto);
            this.frmLogin_Fill_Panel.ClientArea.Controls.Add(this.ubCancel);
            this.frmLogin_Fill_Panel.ClientArea.Controls.Add(this.ubAceptar);
            this.frmLogin_Fill_Panel.ClientArea.Controls.Add(this.ultraLabel1);
            this.frmLogin_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmLogin_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmLogin_Fill_Panel.Location = new System.Drawing.Point(8, 31);
            this.frmLogin_Fill_Panel.Name = "frmLogin_Fill_Panel";
            this.frmLogin_Fill_Panel.Size = new System.Drawing.Size(347, 121);
            this.frmLogin_Fill_Panel.TabIndex = 0;
            // 
            // ubCancel
            // 
            this.ubCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ubCancel.Location = new System.Drawing.Point(184, 78);
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size(75, 23);
            this.ubCancel.TabIndex = 3;
            this.ubCancel.Text = "Cancelar";
            // 
            // ubAceptar
            // 
            this.ubAceptar.Location = new System.Drawing.Point(74, 78);
            this.ubAceptar.Name = "ubAceptar";
            this.ubAceptar.Size = new System.Drawing.Size(75, 23);
            this.ubAceptar.TabIndex = 2;
            this.ubAceptar.Text = "Aceptar";
            this.ubAceptar.Click += new System.EventHandler(this.ubAceptar_Click);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(42, 35);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(45, 14);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Oficina:";
            // 
            // _frmLogin_UltraFormManager_Dock_Area_Left
            // 
            this._frmLogin_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmLogin_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmLogin_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmLogin_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmLogin_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmLogin_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmLogin_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 31);
            this._frmLogin_UltraFormManager_Dock_Area_Left.Name = "_frmLogin_UltraFormManager_Dock_Area_Left";
            this._frmLogin_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 121);
            // 
            // _frmLogin_UltraFormManager_Dock_Area_Right
            // 
            this._frmLogin_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmLogin_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmLogin_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmLogin_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmLogin_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmLogin_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmLogin_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(355, 31);
            this._frmLogin_UltraFormManager_Dock_Area_Right.Name = "_frmLogin_UltraFormManager_Dock_Area_Right";
            this._frmLogin_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 121);
            // 
            // _frmLogin_UltraFormManager_Dock_Area_Top
            // 
            this._frmLogin_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmLogin_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmLogin_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmLogin_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmLogin_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmLogin_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmLogin_UltraFormManager_Dock_Area_Top.Name = "_frmLogin_UltraFormManager_Dock_Area_Top";
            this._frmLogin_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(363, 31);
            // 
            // _frmLogin_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 152);
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.Name = "_frmLogin_UltraFormManager_Dock_Area_Bottom";
            this._frmLogin_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(363, 8);
            // 
            // frmSelOficina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 160);
            this.ControlBox = false;
            this.Controls.Add(this.frmLogin_Fill_Panel);
            this.Controls.Add(this._frmLogin_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmLogin_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmLogin_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmLogin_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelOficina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraValidator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucDepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbloficinaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.frmLogin_Fill_Panel.ClientArea.ResumeLayout(false);
            this.frmLogin_Fill_Panel.ClientArea.PerformLayout();
            this.frmLogin_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraValidator ultraValidator1;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel frmLogin_Fill_Panel;
        private Infragistics.Win.Misc.UltraButton ubCancel;
        private Infragistics.Win.Misc.UltraButton ubAceptar;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmLogin_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmLogin_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmLogin_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmLogin_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinGrid.UltraCombo ucDepto;
        private System.Windows.Forms.BindingSource tbloficinaBindingSource;
    }
}