namespace TiempoEnProceso.Forms
{
    partial class frmDatosAnulacion
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.frmDatosAnulacion_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.udtFechaAnula = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.uneDoctoAnula = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.frmDatosAnulacion_Fill_Panel.ClientArea.SuspendLayout();
            this.frmDatosAnulacion_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtFechaAnula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneDoctoAnula)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // frmDatosAnulacion_Fill_Panel
            // 
            // 
            // frmDatosAnulacion_Fill_Panel.ClientArea
            // 
            this.frmDatosAnulacion_Fill_Panel.ClientArea.Controls.Add(this.uneDoctoAnula);
            this.frmDatosAnulacion_Fill_Panel.ClientArea.Controls.Add(this.ubCerrar);
            this.frmDatosAnulacion_Fill_Panel.ClientArea.Controls.Add(this.ubAgregar);
            this.frmDatosAnulacion_Fill_Panel.ClientArea.Controls.Add(this.ultraLabel16);
            this.frmDatosAnulacion_Fill_Panel.ClientArea.Controls.Add(this.udtFechaAnula);
            this.frmDatosAnulacion_Fill_Panel.ClientArea.Controls.Add(this.ultraLabel14);
            this.frmDatosAnulacion_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmDatosAnulacion_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmDatosAnulacion_Fill_Panel.Location = new System.Drawing.Point(8, 32);
            this.frmDatosAnulacion_Fill_Panel.Name = "frmDatosAnulacion_Fill_Panel";
            this.frmDatosAnulacion_Fill_Panel.Size = new System.Drawing.Size(389, 145);
            this.frmDatosAnulacion_Fill_Panel.TabIndex = 0;
            // 
            // ubCerrar
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance1;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(206, 86);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(40, 40);
            this.ubCerrar.TabIndex = 68;
            this.ubCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubCerrar.Click += new System.EventHandler(this.ubCerrar_Click);
            // 
            // ubAgregar
            // 
            appearance2.Image = global::TiempoEnProceso.Properties.Resources.Guardar;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance2;
            this.ubAgregar.AutoSize = true;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(143, 86);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(40, 40);
            this.ubAgregar.TabIndex = 67;
            this.ubAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregar.Click += new System.EventHandler(this.ubAgregar_Click);
            // 
            // ultraLabel16
            // 
            this.ultraLabel16.AutoSize = true;
            this.ultraLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel16.Location = new System.Drawing.Point(30, 24);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(68, 14);
            this.ultraLabel16.TabIndex = 66;
            this.ultraLabel16.Text = "Documento:";
            // 
            // udtFechaAnula
            // 
            this.udtFechaAnula.DateButtons.Add(dateButton1);
            this.udtFechaAnula.Location = new System.Drawing.Point(142, 47);
            this.udtFechaAnula.Name = "udtFechaAnula";
            this.udtFechaAnula.NonAutoSizeHeight = 21;
            this.udtFechaAnula.Size = new System.Drawing.Size(91, 21);
            this.udtFechaAnula.TabIndex = 64;
            this.udtFechaAnula.Value = new System.DateTime(2018, 1, 6, 0, 0, 0, 0);
            // 
            // ultraLabel14
            // 
            this.ultraLabel14.AutoSize = true;
            this.ultraLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel14.Location = new System.Drawing.Point(30, 50);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(40, 14);
            this.ultraLabel14.TabIndex = 65;
            this.ultraLabel14.Text = "Fecha:";
            // 
            // _frmDatosAnulacion_UltraFormManager_Dock_Area_Left
            // 
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 32);
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.Name = "_frmDatosAnulacion_UltraFormManager_Dock_Area_Left";
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 145);
            // 
            // _frmDatosAnulacion_UltraFormManager_Dock_Area_Right
            // 
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(397, 32);
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.Name = "_frmDatosAnulacion_UltraFormManager_Dock_Area_Right";
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 145);
            // 
            // _frmDatosAnulacion_UltraFormManager_Dock_Area_Top
            // 
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top.Name = "_frmDatosAnulacion_UltraFormManager_Dock_Area_Top";
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(405, 32);
            // 
            // _frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 177);
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.Name = "_frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom";
            this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(405, 8);
            // 
            // uneDoctoAnula
            // 
            this.uneDoctoAnula.Location = new System.Drawing.Point(142, 20);
            this.uneDoctoAnula.Name = "uneDoctoAnula";
            this.uneDoctoAnula.Size = new System.Drawing.Size(228, 21);
            this.uneDoctoAnula.TabIndex = 0;
            // 
            // frmDatosAnulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 185);
            this.Controls.Add(this.frmDatosAnulacion_Fill_Panel);
            this.Controls.Add(this._frmDatosAnulacion_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmDatosAnulacion_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmDatosAnulacion_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatosAnulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos Anulación";
            this.Load += new System.EventHandler(this.frmDatosAnulacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.frmDatosAnulacion_Fill_Panel.ClientArea.ResumeLayout(false);
            this.frmDatosAnulacion_Fill_Panel.ClientArea.PerformLayout();
            this.frmDatosAnulacion_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udtFechaAnula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneDoctoAnula)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel frmDatosAnulacion_Fill_Panel;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmDatosAnulacion_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmDatosAnulacion_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmDatosAnulacion_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmDatosAnulacion_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo udtFechaAnula;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraButton ubCerrar;
        private Infragistics.Win.Misc.UltraButton ubAgregar;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uneDoctoAnula;
    }
}