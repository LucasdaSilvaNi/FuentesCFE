namespace TiempoEnProceso
{
    partial class frmViewReport
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
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ubOk = new Infragistics.Win.Misc.UltraButton();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ubOk);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 529);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(931, 54);
            this.ultraPanel1.TabIndex = 1;
            this.ultraPanel1.Resize += new System.EventHandler(this.ultraPanel1_Resize);
            // 
            // ubOk
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            this.ubOk.Appearance = appearance1;
            this.ubOk.ImageSize = new System.Drawing.Size(32, 32);
            this.ubOk.Location = new System.Drawing.Point(322, 6);
            this.ubOk.Name = "ubOk";
            this.ubOk.Size = new System.Drawing.Size(94, 43);
            this.ubOk.TabIndex = 0;
            this.ubOk.Text = "Cerrar";
            this.ubOk.Click += new System.EventHandler(this.ubOk_Click);
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.reportViewer1);
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(931, 529);
            this.ultraPanel2.TabIndex = 2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(931, 529);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 583);
            this.Controls.Add(this.ultraPanel2);
            this.Controls.Add(this.ultraPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmViewReport";
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.frmViewReport_Load);
            this.Resize += new System.EventHandler(this.frmViewReport_Resize);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ClientArea.PerformLayout();
            this.ultraPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraButton ubOk;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}