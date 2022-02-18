using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using TiempoEnProcesoHelper;

namespace TiempoEnProceso
{
    public partial class frmViewReportC : Form
    {
        public string _reportName { get; set; }
        public DataSet _data { get; set; }
        public bool _exportButton { get; set; }
        public bool _groupButton { get; set; }
        public bool _showStatus { get; set; }
        public string _reportFileName { get; set; }
        public CrystalDecisions.Windows.Forms.ToolPanelViewType _ToolPanelView { get; set; }
        public Dictionary<string, object> _parameters { get; set; }
        public ViewerExportFormats _exportFormat { get; set; }

        public frmViewReportC()
        {
            InitializeComponent();
            _exportButton = false;
            _groupButton = false;
            _showStatus = true;
            _reportFileName = null;
            _ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.GroupTree;
            _exportFormat = ViewerExportFormats.AllFormats;
            _parameters = new Dictionary<string, object>();
        }

        private void frmViewReport_Load(object sender, EventArgs e)
        {
            try
            {
                
                ReportDocument _report = new ReportDocument();

                _report.Load((_reportName.Contains("\\") ? "" : Application.StartupPath + @"\Reports\") + _reportName);
                _report.SetDataSource(_data);

                SetLogonInfo(ref _report);               

                _report.SummaryInfo.ReportTitle = _reportFileName;
                _report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                crystalReportViewer1.ReportSource = _report;
                crystalReportViewer1.RefreshReport();
                

                crystalReportViewer1.ShowCloseButton = false;
                crystalReportViewer1.ShowExportButton = _exportButton;
                crystalReportViewer1.ShowGroupTreeButton = _groupButton;
                crystalReportViewer1.DisplayStatusBar = _showStatus;
                crystalReportViewer1.ToolPanelView = _ToolPanelView;
                crystalReportViewer1.AllowedExportFormats = (int)_exportFormat;
                
                crystalReportViewer1.Zoom(100);

                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                Helper.ShowError("GeneraReporte", "Error al Generar", ex);
            }
        }

        private void SetLogonInfo(ref ReportDocument _report)
        {

            ConnectionInfo crConnection = new ConnectionInfo();
            crConnection.UserID = Helper.usuarioDB;
            crConnection.Password = Helper.llaveUsuario;
            crConnection.ServerName = Helper.servidor;
            crConnection.DatabaseName = Helper.db;

            TableLogOnInfo logOnInfo;
            ReportDocument subRd;
            Sections sects;
            ReportObjects ros;
            SubreportObject sro;

            foreach (CrystalDecisions.CrystalReports.Engine.Table t in _report.Database.Tables)
            {
                logOnInfo = t.LogOnInfo;
                logOnInfo.ReportName = _report.Name;
                logOnInfo.ConnectionInfo = crConnection;
                logOnInfo.TableName = t.Name;
                t.ApplyLogOnInfo(logOnInfo);
                t.Location = t.Name;
            }           

            sects = _report.ReportDefinition.Sections;
            foreach (Section sect in sects)
            {
                ros = sect.ReportObjects;
                foreach (ReportObject ro in ros)
                {
                    if (ro.Kind == ReportObjectKind.SubreportObject)
                    {
                        sro = (SubreportObject)ro;
                        subRd = sro.OpenSubreport(sro.SubreportName);

                        foreach (CrystalDecisions.CrystalReports.Engine.Table t in subRd.Database.Tables)
                        {
                            logOnInfo = t.LogOnInfo;
                            logOnInfo.ReportName = _report.Name;
                            logOnInfo.ConnectionInfo = crConnection;
                            logOnInfo.TableName = t.Name;
                            t.ApplyLogOnInfo(logOnInfo);
                        }
                        
                    }
                }
            }
        }        

        private void ubOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void ubImprimir_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }

        private void ultraPanel1_Resize(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
                ubImprimir.Location = new Point((ultraPanel1.Width / 2) - ubImprimir.Width - 23, ubImprimir.Location.Y);
                ubOk.Location = new Point((ultraPanel1.Width / 2) + 24, ubImprimir.Location.Y);
            //}
        }
    }
}
