using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;
using TiempoEnProcesoHelper;

namespace TiempoEnProcesoBL
{
    public class SolicitudFacturaBL
    {
        TEPEntities db;

        public SolicitudFacturaBL()
        {
            db = new TEPEntities(Helper.CadenaConexion);
            db.Database.CommandTimeout = Helper.TimeOut;
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public SolicitudFacturaBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = Helper.TimeOut;
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public List<SolicitudFacturaDetEN> Detalle(int id_solicitud)
        {
            List<SolicitudFacturaDetEN> lst = new List<SolicitudFacturaDetEN>();
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_Detalle_Sol_temp, SolicitudFacturaDetEN>());
            var mapper = ConfMapper.CreateMapper();

            IQueryable qry = from a in db.tbl_Detalle_Sol_temp
                             where a.id_solicitud == id_solicitud
                             select a;

            lst = mapper.Map<List<SolicitudFacturaDetEN>>(qry);

            return lst;
        }

        public SolicitudFacturaEN CabeceraDetalle(int id_solicitud)
        {
            SolicitudFacturaEN solicitud = new SolicitudFacturaEN();
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_solicitud_temp, SolicitudFacturaEN>());
            var mapper = ConfMapper.CreateMapper();

            tbl_solicitud_temp tmp = db.tbl_solicitud_temp.FirstOrDefault(d => d.id_solicitud == id_solicitud);

            solicitud = mapper.Map<SolicitudFacturaEN>(tmp);

            return solicitud;
        }

        public decimal Pendientes(string id_empleado)
        {
            tbl_solicitud_temp tmp = db.tbl_solicitud_temp.FirstOrDefault(d => d.id_empleado == id_empleado && d.estado == 1);

            if (tmp != null)
                return tmp.id_solicitud;

            return 0;
        }

        public decimal GrabaDetalle(SolicitudFacturaDetEN _detalle)
        {
            decimal id_solicitud = _detalle.id_solicitud;

            tbl_solicitud_temp sol ;
            if (id_solicitud == 0)
            {
                sol = new tbl_solicitud_temp();
                sol.estado = 1;
                sol.total_solicitud = 0;
                sol.total_solicitud_moneda_local = 0;
                sol.tasa_cambio = 0;
                db.tbl_solicitud_temp.Add(sol);
            }
            else
                sol = db.tbl_solicitud_temp.FirstOrDefault(d=> d.id_solicitud == id_solicitud);

            tbl_Detalle_Sol_temp _det = new tbl_Detalle_Sol_temp 
            {
                Atencion_a=_detalle.Atencion_a,
                concepto= _detalle.concepto,
                Impuesto = _detalle.Impuesto,
                Impuesto_por = _detalle.Impuesto_por,
                line_detalle = _detalle.line_detalle,
                linea = _detalle.linea,
                Total = _detalle.Total,
                valor = _detalle.valor,
                Descripcion_comercial = _detalle.descripcion_comercial,
                Descuento_linea = _detalle.Descuento_linea,
                es_linea_fiscal = _detalle.Es_linea_fiscal,
                id_solicitud = _detalle.id_solicitud,
                Valor_local = _detalle.Valor_local,
                tbl_solicitud_temp = sol
                
            };

            sol.tbl_Detalle_Sol_temp.Add(_det);
            sol.total_solicitud = sol.tbl_Detalle_Sol_temp.Sum(d => d.Total);
            sol.total_solicitud_moneda_local = sol.total_solicitud * sol.tasa_cambio;

            db.SaveChanges();

            return sol.id_solicitud;
        }

        public List<SolicitudFacturaDetEN> EliminaDetalle(int line_detalle)
        {
            tbl_Detalle_Sol_temp _temp = db.tbl_Detalle_Sol_temp.FirstOrDefault(d => d.line_detalle == line_detalle);

            decimal id_solicitud = _temp.id_solicitud;

            db.tbl_Detalle_Sol_temp.Remove(_temp);
            db.SaveChanges();

            List<SolicitudFacturaDetEN> lst = new List<SolicitudFacturaDetEN>();
            AutoMapper.MapperConfiguration ConfMapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<tbl_Detalle_Sol_temp, SolicitudFacturaDetEN>());
            var mapper = ConfMapper.CreateMapper();

            IQueryable qry = from a in db.tbl_Detalle_Sol_temp
                             where a.id_solicitud == id_solicitud
                             select a;

            lst = mapper.Map<List<SolicitudFacturaDetEN>>(qry);

            return lst;
        }

        public decimal GrabaCabecera(SolicitudFacturaEN _det)
        {
            tbl_solicitud_temp sol;
            if (_det.id_solicitud == 0)
            {
                sol = new tbl_solicitud_temp();
                sol.estado = 1;
                
            }
            else
                sol = db.tbl_solicitud_temp.FirstOrDefault(d => d.id_solicitud == _det.id_solicitud);

            sol.fecha_a_emitir = _det.fecha_a_emitir;
            sol.facturar_en_perido = _det.facturar_en_perido.Trim();
            sol.fecha = _det.fecha;
            sol.fecha_tentativa_cobro = _det.fecha_tentativa_cobro;

            sol.id_cliente = null;
            if (!string.IsNullOrEmpty(_det.id_cliente))
                sol.id_cliente = _det.id_cliente.Trim();

            sol.id_empleado = _det.id_empleado.Trim();

            sol.id_entidad = null;
            if (!string.IsNullOrEmpty(_det.id_entidad))
                sol.id_entidad = _det.id_entidad.Trim();

            sol.id_job = null;

            if (!string.IsNullOrEmpty(_det.id_job))
                sol.id_job = _det.id_job.Trim();

            sol.id_oficina = _det.id_oficina.Trim();
            sol.Imprime_Moneda_Tep = _det.Imprime_Moneda_Tep;

            sol.instrucciones = null;
            if (!string.IsNullOrEmpty(_det.instrucciones))
                sol.instrucciones = _det.instrucciones.Trim();

            sol.Lenguaje_impresion_spanish = _det.Lenguaje_impresion_spanish;

            sol.situacion = null;
            if (!string.IsNullOrEmpty(_det.situacion))
                sol.situacion = _det.situacion.Trim();

            sol.tasa_cambio = _det.tasa_cambio;
            sol.Tasa_cambio_fiscal = _det.Tasa_cambio_fiscal;

            sol.tipo_entrega = null;
            if (!string.IsNullOrEmpty(_det.tipo_entrega))
                sol.tipo_entrega = _det.tipo_entrega.Trim();

            sol.total_solicitud = _det.total_solicitud;
            sol.total_solicitud_moneda_local = _det.total_solicitud_moneda_local;

            sol.id_servicio = null;
            if (!string.IsNullOrEmpty(_det.id_servicio) && 
                _det.id_servicio!=Constantes.S_TODOS)
                sol.id_servicio = _det.id_servicio.Trim();

            if (_det.id_solicitud == 0)
                db.tbl_solicitud_temp.Add(sol);

            db.SaveChanges();

            return sol.id_solicitud;
        }

        public void EliminaSolicitud(int id_solicitud)
        {
            tbl_solicitud_temp sol = db.tbl_solicitud_temp.Include("tbl_Detalle_Sol_temp").FirstOrDefault(d => d.id_solicitud == id_solicitud);

            if (sol == null)
                throw new Exception("Solicitud no Existe");

            if (sol.tbl_Detalle_Sol_temp != null)
                db.tbl_Detalle_Sol_temp.RemoveRange(sol.tbl_Detalle_Sol_temp);

            db.tbl_solicitud_temp.Remove(sol);

            db.SaveChanges();
        }

        public void FinalizaSolicitud(int id_solicitud)
        {
            tbl_solicitud_temp sol = db.tbl_solicitud_temp.Include("tbl_Detalle_Sol_temp").FirstOrDefault(d => d.id_solicitud == id_solicitud);

            if (sol == null)
                throw new Exception("Solicitud no Existe");

            if (string.IsNullOrEmpty(sol.id_cliente))
                throw new Exception("Cliente Invalido");

            if (string.IsNullOrEmpty(sol.id_servicio))
                throw new Exception("Producto Invalido");

            if (string.IsNullOrEmpty(sol.id_job))
                throw new Exception("Job Invalido");

            if (string.IsNullOrEmpty(sol.id_entidad))
                throw new Exception("Facturar de Invalido");

            if ((sol.total_solicitud ?? 0) <= 0)
                throw new Exception("Monto Solicitud Invalido");

            if (sol.tbl_Detalle_Sol_temp.Count == 0)
                throw new Exception("Detalle Invalido");

            if (sol.id_oficina == "60")
            {
                if (sol.total_solicitud_moneda_local != sol.tbl_Detalle_Sol_temp.Sum(d => d.Valor_local))
                    throw new Exception("Total monto Local es diferente al Total Local Solicitud");
            }

            sol.estado = 2;
            db.SaveChanges();
        }
    }
}
