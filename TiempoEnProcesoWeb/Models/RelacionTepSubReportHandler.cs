using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using MvcReportViewer;

namespace TiempoEnProcesoWeb.Models
{
    public class RelacionTepSubReportHandler : IReportViewerEventsHandler
    {
        public void OnSubreportProcessing(ReportViewer reportViewer, SubreportProcessingEventArgs e)
        {
            var data = TiempoEnProcesoHelper.Helper.passData[TiempoEnProcesoHelper.Helper.empleado+"_Relacion"];
            e.DataSources.Add(new ReportDataSource("pwcia", data));
        }

        public void OnDrillthrough(ReportViewer reportViewer, DrillthroughEventArgs e)
        {
            var report = (LocalReport)e.Report;
        
            report.Refresh();
        }
    }
}