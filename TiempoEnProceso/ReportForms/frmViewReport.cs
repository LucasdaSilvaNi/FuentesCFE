using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace TiempoEnProceso
{
    public partial class frmViewReport : Form
    {
        public string _reportName { get; set; }
        public DataSet _data { get; set; }
        public bool _exportButton { get; set; }
        public bool _groupButton { get; set; }
        public bool _showStatus { get; set; }
        public string _reportFileName { get; set; }
        public Dictionary<string, string> _parameters { get; set; }
        public bool _DynamicSubReport { get; set; }
        public string _DynamicType { get; set; }

        private int iSubReport = 0;

        public frmViewReport()
        {
            InitializeComponent();
            _exportButton = false;
            _groupButton = false;
            _showStatus = true;
            _reportFileName = null;
            _DynamicSubReport = false;
            _parameters = new Dictionary<string, string>();
        }

        private void frmViewReport_Load(object sender, EventArgs e)
        {
            try
            {

                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                LocalReport localReport = reportViewer1.LocalReport;
                localReport.ReportPath= Application.StartupPath + @"\Reports\" + _reportName;

                ReportDataSource dsDS = new ReportDataSource();
                dsDS.Name = _data.Tables[0].TableName;
                dsDS.Value = _data.Tables[0];

                localReport.DataSources.Add(dsDS);

                if (_data.Tables.Count > 1 || _DynamicSubReport)
                    reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

                foreach (KeyValuePair<string, string> pair in _parameters)
                {
                    ReportParameter _par = new ReportParameter();
                    _par.Name = pair.Key;
                    _par.Values.Add(pair.Value);

                    localReport.SetParameters(new ReportParameter[] { _par });
                }
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();

                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                TiempoEnProcesoHelper.Helper.ShowError("GeneraReporte", "Error al Generar", ex);
            }
            
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (_DynamicSubReport && _DynamicType.Contains(string.Format(",{0},", e.ReportPath)))
            {
                DataSet _dataSub = GetDynamicDataSubReport(e.ReportPath, e.Parameters);
                e.DataSources.Add(new ReportDataSource(_dataSub.Tables[0].TableName, _dataSub.Tables[0]));
            }
            else
            {
                iSubReport++;

                if (_data.Tables.Count == 2)
                    e.DataSources.Add(new ReportDataSource(_data.Tables[1].TableName.Replace("_repetido", ""), _data.Tables[1]));
                else
                    e.DataSources.Add(new ReportDataSource(_data.Tables[iSubReport].TableName.Replace("_repetido" + iSubReport.ToString(), ""), _data.Tables[iSubReport]));
                
            }
        }

        private DataSet GetDynamicDataSubReport(string _DynamicType, ReportParameterInfoCollection _param)
        {
            DataSet ds = new DataSet();
            TiempoEnProcesoDL.TEPEntities db = new TiempoEnProcesoDL.TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            if (_DynamicType == "rpt_validacion_creditos_aplicaciones_aplicaciones")
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Id Transaccion: {0}", _param[0].Values.ToList()[0]));

                List<TiempoEnProcesoDL.rpt_validacion_credito_aplicaciones_aplicaciones_Result> lst = db.rpt_validacion_credito_aplicaciones_aplicaciones(Convert.ToDecimal(_param[0].Values.ToList()[0])).ToList();
                /*if (lst.Count == 0)
                {
                    lst.Add(new TiempoEnProcesoDL.rpt_validacion_credito_aplicaciones_aplicaciones_Result()
                    {
                        anticipo = 0,
                        anticipo_docto = 0,
                        id_transaccion = Convert.ToDecimal(_param[0]),
                        numero_documento = 0,
                        preliminar = 0,
                        preliminar_docto = 0,
                        tipo_documento = "XXX",

                    });
                }*/
                ds = TiempoEnProcesoHelper.Helper.ToDataSet<TiempoEnProcesoDL.rpt_validacion_credito_aplicaciones_aplicaciones_Result>(lst);
                if (ds.Tables.Count > 0)
                    ds.Tables[0].TableName = "pwcia";
            }
            if (_DynamicType == "rpt_auxiliar_trabajo_proceso_subreporte")
            {
                List<TiempoEnProcesoDL.rpt_auxiliar_trabajo_proceso_sub_reporte_Result> lst = db.rpt_auxiliar_trabajo_proceso_sub_reporte(TiempoEnProcesoHelper.Helper.Oficina, _param["cliente"].Values.ToList()[0], _param["servicio"].Values.ToList()[0], _param["id_job"].Values.ToList()[0], _param["id_socio"].Values.ToList()[0], _param["id_encargado"].Values.ToList()[0]).ToList();
                //var data = (new ReportesBL()).Reporte_Auxiliar_Tep_Sub(e.Parameters["oficina"].Values[0], e.Parameters["id_socio"].Values[0], e.Parameters["id_encargado"].Values[0], e.Parameters["cliente"].Values[0], e.Parameters["servicio"].Values[0], e.Parameters["id_job"].Values[0]);

                ds = TiempoEnProcesoHelper.Helper.ToDataSet<TiempoEnProcesoDL.rpt_auxiliar_trabajo_proceso_sub_reporte_Result>(lst);
                ds.Tables[0].TableName = "pwcia";
            }

            if (_DynamicType == "rpt_auxiliar_trabajo_en_proceso_facturas_anticipos")
            {
                List<TiempoEnProcesoDL.rpt_auxiliar_trabajo_proceso_facturas_anticipos_Result> lst = db.rpt_auxiliar_trabajo_proceso_facturas_anticipos(TiempoEnProcesoHelper.Helper.Oficina, _param["Id_Cliente"].Values.ToList()[0], _param["Id_Servicio"].Values.ToList()[0], _param["id_job"].Values.ToList()[0]).ToList();
                //var data = (new ReportesBL()).Reporte_Auxiliar_Tep_Sub(e.Parameters["oficina"].Values[0], e.Parameters["id_socio"].Values[0], e.Parameters["id_encargado"].Values[0], e.Parameters["cliente"].Values[0], e.Parameters["servicio"].Values[0], e.Parameters["id_job"].Values[0]);

                ds = TiempoEnProcesoHelper.Helper.ToDataSet<TiempoEnProcesoDL.rpt_auxiliar_trabajo_proceso_facturas_anticipos_Result>(lst);
                ds.Tables[0].TableName = "pwcia";
            }

            return ds;
        }

        private void ubOk_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void ultraPanel1_Resize(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
                ubOk.Location = new Point((ultraPanel1.Width / 2) - 47, ubOk.Location.Y);
            //}
        }

        private void frmViewReport_Resize(object sender, EventArgs e)
        {

        }
    }
}
