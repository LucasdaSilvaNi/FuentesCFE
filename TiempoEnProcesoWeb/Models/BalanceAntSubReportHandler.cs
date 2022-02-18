using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using MvcReportViewer;

namespace TiempoEnProcesoWeb.Models
{
    public class BalanceAntSubReportHandler : IReportViewerEventsHandler
    {
        public void OnSubreportProcessing(ReportViewer reportViewer, SubreportProcessingEventArgs e)
        {
            var data = TiempoEnProcesoHelper.Helper.passData[TiempoEnProcesoHelper.Helper.empleado + "_BalAntPrel"];
            e.DataSources.Add(new ReportDataSource("pwcia", data));

            var data1 = TiempoEnProcesoHelper.Helper.passData[TiempoEnProcesoHelper.Helper.empleado + "_BalAntDef"];
            e.DataSources.Add(new ReportDataSource("pwcia2", data1));
        }

        public void OnDrillthrough(ReportViewer reportViewer, DrillthroughEventArgs e)
        {
            var report = (LocalReport)e.Report;
        
            report.Refresh();
        }
    }
}