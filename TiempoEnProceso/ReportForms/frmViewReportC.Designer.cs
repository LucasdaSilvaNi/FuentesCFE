namespace TiempoEnProceso
{
    partial class frmViewReportC
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ubImprimir = new Infragistics.Win.Misc.UltraButton();
            this.ubOk = new Infragistics.Win.Misc.UltraButton();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowPrintButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(737, 385);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ubImprimir);
            this.ultraPanel1.ClientArea.Controls.Add(this.ubOk);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 385);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(737, 54);
            this.ultraPanel1.TabIndex = 1;
            this.ultraPanel1.Resize += new System.EventHandler(this.ultraPanel1_Resize);
            // 
            // ubImprimir
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.printer;
            this.ubImprimir.Appearance = appearance1;
            this.ubImprimir.ImageSize = new System.Drawing.Size(32, 32);
            this.ubImprimir.Location = new System.Drawing.Point(252, 6);
            this.ubImprimir.Name = "ubImprimir";
            this.ubImprimir.Size = new System.Drawing.Size(93, 43);
            this.ubImprimir.TabIndex = 0;
            this.ubImprimir.Text = "Imprimir";
            this.ubImprimir.Click += new System.EventHandler(this.ubImprimir_Click);
            // 
            // ubOk
            // 
            appearance2.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            this.ubOk.Appearance = appearance2;
            this.ubOk.ImageSize = new System.Drawing.Size(32, 32);
            this.ubOk.Location = new System.Drawing.Point(392, 6);
            this.ubOk.Name = "ubOk";
            this.ubOk.Size = new System.Drawing.Size(93, 43);
            this.ubOk.TabIndex = 0;
            this.ubOk.Text = "Cerrar";
            this.ubOk.Click += new System.EventHandler(this.ubOk_Click);
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.crystalReportViewer1);
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(737, 385);
            this.ultraPanel2.TabIndex = 2;
            // 
            // frmViewReportC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 439);
            this.Controls.Add(this.ultraPanel2);
            this.Controls.Add(this.ultraPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmViewReportC";
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.frmViewReport_Load);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraButton ubOk;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.Misc.UltraButton ubImprimir;
    }
}