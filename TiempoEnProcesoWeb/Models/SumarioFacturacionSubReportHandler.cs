using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using MvcReportViewer;

namespace TiempoEnProcesoWeb.Models
{
    public class SumarioFacturacionSubReportHandler : IReportViewerEventsHandler
    {
        public void OnSubreportProcessing(ReportViewer reportViewer, SubreportProcessingEventArgs e)
        {
            var data = TiempoEnProcesoHelper.Helper.passData[TiempoEnProcesoHelper.Helper.empleado+"_SumFact"];
            e.DataSources.Add(new ReportDataSource("pwcia", data));
        }

        public void OnDrillthrough(ReportViewer reportViewer, DrillthroughEventArgs e)
        {
            var report = (LocalReport)e.Report;
            var parameters = report.GetParameters();
            var countryId = int.Parse(parameters["CountryId"].Values.First());
            //var cities = LocalData.GetCitiesByCountryId(countryId);
            //report.DataSources.Add(new ReportDataSource("Cities", cities));
            report.Refresh();
        }
    }
}