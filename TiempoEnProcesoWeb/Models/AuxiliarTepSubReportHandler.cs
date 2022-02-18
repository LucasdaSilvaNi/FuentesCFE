using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;
using MvcReportViewer;
using TiempoEnProcesoBL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoWeb.Models
{
    public class AuxiliarTepSubReportHandler : IReportViewerEventsHandler
    {
        public void OnSubreportProcessing(ReportViewer reportViewer, SubreportProcessingEventArgs e)
        {
            DataTable data = new DataTable();
            
            //var data = TiempoEnProcesoHelper.Helper.passData[TiempoEnProcesoHelper.Helper.empleado+"_Auxiliar"];
            if (e.ReportPath == "rpt_auxiliar_trabajo_proceso_subreporte")
                data = (new ReportesBL()).Reporte_Auxiliar_Tep_Sub(TiempoEnProcesoHelper.Helper.Oficina, e.Parameters["id_socio"].Values[0], e.Parameters["id_encargado"].Values[0], e.Parameters["cliente"].Values[0], e.Parameters["servicio"].Values[0], e.Parameters["id_job"].Values[0]);
            else
                data = (new ReportesBL()).Reporte_Auxiliar_Tep_Sub_Facturas(TiempoEnProcesoHelper.Helper.Oficina, e.Parameters["Id_cliente"].Values[0], e.Parameters["Id_servicio"].Values[0], e.Parameters["id_job"].Values[0]);

            data.TableName = "pwcia";
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