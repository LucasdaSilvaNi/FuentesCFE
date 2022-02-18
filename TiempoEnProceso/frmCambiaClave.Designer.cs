namespace TiempoEnProceso
{
    partial class frmCambiaClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiaClave));
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uteUsuario = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteClave = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ubAceptar = new Infragistics.Win.Misc.UltraButton();
            this.ubCancel = new Infragistics.Win.Misc.UltraButton();
            this.ultraValidator1 = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.uteClaveNueva = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteClaveConf = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this.frmCambiaClave_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.uteUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraValidator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClaveNueva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClaveConf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.frmCambiaClave_Fill_Panel.ClientArea.SuspendLayout();
            this.frmCambiaClave_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(24, 16);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(46, 14);
            this.ultraLabel1.TabIndex = 0;
            this.ultraLabel1.Text = "Usuario:";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Location = new System.Drawing.Point(24, 43);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(36, 14);
            this.ultraLabel2.TabIndex = 0;
            this.ultraLabel2.Text = "Clave:";
            // 
            // uteUsuario
            // 
            this.uteUsuario.Enabled = false;
            this.uteUsuario.Location = new System.Drawing.Point(125, 12);
            this.uteUsuario.Name = "uteUsuario";
            this.uteUsuario.Size = new System.Drawing.Size(165, 21);
            this.uteUsuario.TabIndex = 0;
            this.ultraValidator1.GetValidationSettings(this.uteUsuario).IsRequired = true;
            this.ultraValidator1.GetValidationSettings(this.uteUsuario).NotificationSettings.Caption = "Usuario";
            this.ultraValidator1.GetValidationSettings(this.uteUsuario).NotificationSettings.Text = "Usuario Invalido";
            this.ultraValidator1.GetValidationSettings(this.uteUsuario).ValidationGroupKey = "required";
            this.uteUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteUsuario_KeyDown);
            // 
            // uteClave
            // 
            this.uteClave.Enabled = false;
            this.uteClave.Location = new System.Drawing.Point(125, 39);
            this.uteClave.MaxLength = 15;
            this.uteClave.Name = "uteClave";
            this.uteClave.PasswordChar = '*';
            this.uteClave.Size = new System.Drawing.Size(165, 21);
            this.uteClave.TabIndex = 1;
            this.ultraValidator1.GetValidationSettings(this.uteClave).IsRequired = true;
            this.ultraValidator1.GetValidationSettings(this.uteClave).NotificationSettings.Caption = "Usuario";
            this.ultraValidator1.GetValidationSettings(this.uteClave).NotificationSettings.Text = "Clave Invalida";
            this.ultraValidator1.GetValidationSettings(this.uteClave).ValidationGroupKey = "required";
            this.uteClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteClave_KeyDown);
            // 
            // ubAceptar
            // 
            this.ubAceptar.Location = new System.Drawing.Point(81, 132);
            this.ubAceptar.Name = "ubAceptar";
            this.ubAceptar.Size = new System.Drawing.Size(75, 23);
            this.ubAceptar.TabIndex = 5;
            this.ubAceptar.Text = "Aceptar";
            this.ubAceptar.Click += new System.EventHandler(this.ubAceptar_Click);
            // 
            // ubCancel
            // 
            this.ubCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ubCancel.Location = new System.Drawing.Point(191, 132);
            this.ubCancel.Name = "ubCancel";
            this.ubCancel.Size = new System.Drawing.Size(75, 23);
            this.ubCancel.TabIndex = 6;
            this.ubCancel.Text = "Cancelar";
            this.ubCancel.Click += new System.EventHandler(this.ubCancel_Click);
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
            // uteClaveNueva
            // 
            this.uteClaveNueva.Location = new System.Drawing.Point(125, 66);
            this.uteClaveNueva.MaxLength = 15;
            this.uteClaveNueva.Name = "uteClaveNueva";
            this.uteClaveNueva.PasswordChar = '*';
            this.uteClaveNueva.Size = new System.Drawing.Size(165, 21);
            this.uteClaveNueva.TabIndex = 2;
            this.ultraValidator1.GetValidationSettings(this.uteClaveNueva).IsRequired = true;
            this.ultraValidator1.GetValidationSettings(this.uteClaveNueva).NotificationSettings.Text = "Nueva Clave Invalida";
            this.ultraValidator1.GetValidationSettings(this.uteClaveNueva).ValidationGroupKey = "required";
            this.uteClaveNueva.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteClaveNueva_KeyDown);
            // 
            // uteClaveConf
            // 
            this.uteClaveConf.Location = new System.Drawing.Point(125, 93);
            this.uteClaveConf.MaxLength = 15;
            this.uteClaveConf.Name = "uteClaveConf";
            this.uteClaveConf.PasswordChar = '*';
            this.uteClaveConf.Size = new System.Drawing.Size(165, 21);
            this.uteClaveConf.TabIndex = 3;
            this.ultraValidator1.GetValidationSettings(this.uteClaveConf).IsRequired = true;
            this.ultraValidator1.GetValidationSettings(this.uteClaveConf).NotificationSettings.Text = "Confirmación de Clave Invalida";
            this.ultraValidator1.GetValidationSettings(this.uteClaveConf).ValidationGroupKey = "required";
            this.uteClaveConf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteClaveConf_KeyDown);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(24, 70);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(72, 14);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Text = "Nueva Clave:";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Location = new System.Drawing.Point(24, 97);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(85, 14);
            this.ultraLabel4.TabIndex = 0;
            this.ultraLabel4.Text = "Confirma Clave:";
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // frmCambiaClave_Fill_Panel
            // 
            // 
            // frmCambiaClave_Fill_Panel.ClientArea
            // 
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.ubCancel);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.ubAceptar);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.uteClaveConf);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.uteClaveNueva);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.ultraLabel4);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.uteClave);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.ultraLabel3);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.uteUsuario);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.ultraLabel2);
            this.frmCambiaClave_Fill_Panel.ClientArea.Controls.Add(this.ultraLabel1);
            this.frmCambiaClave_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmCambiaClave_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmCambiaClave_Fill_Panel.Location = new System.Drawing.Point(8, 31);
            this.frmCambiaClave_Fill_Panel.Name = "frmCambiaClave_Fill_Panel";
            this.frmCambiaClave_Fill_Panel.Size = new System.Drawing.Size(339, 165);
            this.frmCambiaClave_Fill_Panel.TabIndex = 0;
            // 
            // _frmCambiaClave_UltraFormManager_Dock_Area_Left
            // 
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 31);
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.Name = "_frmCambiaClave_UltraFormManager_Dock_Area_Left";
            this._frmCambiaClave_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 165);
            // 
            // _frmCambiaClave_UltraFormManager_Dock_Area_Right
            // 
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(347, 31);
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.Name = "_frmCambiaClave_UltraFormManager_Dock_Area_Right";
            this._frmCambiaClave_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 165);
            // 
            // _frmCambiaClave_UltraFormManager_Dock_Area_Top
            // 
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top.Name = "_frmCambiaClave_UltraFormManager_Dock_Area_Top";
            this._frmCambiaClave_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(355, 31);
            // 
            // _frmCambiaClave_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 196);
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.Name = "_frmCambiaClave_UltraFormManager_Dock_Area_Bottom";
            this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(355, 8);
            // 
            // frmCambiaClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 204);
            this.ControlBox = false;
            this.Controls.Add(this.frmCambiaClave_Fill_Panel);
            this.Controls.Add(this._frmCambiaClave_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmCambiaClave_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmCambiaClave_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmCambiaClave_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCambiaClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambia de Clave";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uteUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraValidator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClaveNueva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClaveConf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.frmCambiaClave_Fill_Panel.ClientArea.ResumeLayout(false);
            this.frmCambiaClave_Fill_Panel.ClientArea.PerformLayout();
            this.frmCambiaClave_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteUsuario;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteClave;
        private Infragistics.Win.Misc.UltraButton ubAceptar;
        private Infragistics.Win.Misc.UltraButton ubCancel;
        private Infragistics.Win.Misc.UltraValidator ultraValidator1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteClaveNueva;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteClaveConf;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.Misc.UltraPanel frmCambiaClave_Fill_Panel;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmCambiaClave_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmCambiaClave_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmCambiaClave_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmCambiaClave_UltraFormManager_Dock_Area_Bottom;
    }
}