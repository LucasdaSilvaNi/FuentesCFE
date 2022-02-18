using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoEnProcesoDL;
using TiempoEnProcesoEN;

namespace TiempoEnProcesoBL
{
    public class EntidadLegalBL
    {
        TEPEntities db;
        public EntidadLegalBL()
        {
            db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            
        }

        public EntidadLegalBL(ref TEPEntities _db)
        {
            if (_db==null)
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);

            db = _db;
            db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
        }

        public List<tbl_entidad_legal> Listar(bool soloActivo)
        {
            List<tbl_entidad_legal> lst = new List<tbl_entidad_legal>();

            db.tbl_entidad_legal.Where(d => d.id_oficina == TiempoEnProcesoHelper.Helper.Oficina && (d.Estado ?? true) == true).ToList<tbl_entidad_legal>().ForEach(d =>
                lst.Add(new tbl_entidad_legal
                {
                    correlativo_anulaciones = d.correlativo_anulaciones,
                    correlativo_cobranzas = d.correlativo_cobranzas,
                    correlativo_facturas = d.correlativo_facturas,
                    correlativo_notas = d.correlativo_notas,
                    Direccion = d.Direccion,
                    Estado = d.Estado,
                    financiera = d.financiera,
                    formato_facturas = d.formato_facturas,
                    id_entidad = d.id_entidad,
                    id_oficina = d.id_oficina,
                    impuesto = d.impuesto,
                    incluido = d.incluido,
                    NIT = d.NIT,
                    origen_datos_factura = d.origen_datos_factura,
                    Razon_social = string.Format("{0} {1}", d.id_entidad, d.Razon_social),
                    tbl_tipo_documento = d.tbl_tipo_documento,
                    ubicacion_factura = d.ubicacion_factura,
                    Formato_FEL = d.Formato_FEL
                }));

            return lst;
        }

        public List<tbl_entidad_legal> Listar(int cargar = 0)
        {
            List<tbl_entidad_legal> lst = new List<tbl_entidad_legal>();

            if (Convert.ToBoolean(cargar))
            {
                db.Dispose();
                db = new TEPEntities(TiempoEnProcesoHelper.Helper.CadenaConexion);
                db.Database.CommandTimeout = TiempoEnProcesoHelper.Helper.TimeOut;
            }

            IQueryable qry = db.tbl_entidad_legal.Where(d => d.id_oficina == TiempoEnProcesoHelper.Helper.Oficina).OrderBy(d=> d.id_entidad);
            
            qry.Cast<tbl_entidad_legal>().ToList().ForEach(d =>
                lst.Add(new tbl_entidad_legal { 
                    correlativo_anulaciones = d.correlativo_anulaciones,
                    correlativo_cobranzas=d.correlativo_cobranzas,
                    correlativo_facturas=d.correlativo_facturas,
                    correlativo_notas=d.correlativo_notas,
                    Direccion=d.Direccion,
                    Estado= d.Estado,
                    financiera=d.financiera,
                    formato_facturas=d.formato_facturas,
                    id_entidad= d.id_entidad,
                    id_oficina=d.id_oficina,
                    impuesto=d.impuesto,
                    incluido=d.incluido,
                    NIT=d.NIT,
                    origen_datos_factura = d.origen_datos_factura,
                    Razon_social = string.Format("{0} {1}", d.id_entidad, d.Razon_social),
                    ubicacion_factura= d.ubicacion_factura

                }));

            return lst;
        }

        public List<EntidadLegalEN> Listar(string id_oficina)
        {
            List<EntidadLegalEN> lst = new List<EntidadLegalEN>();

            IQueryable qry = db.tbl_entidad_legal.Where(d => d.id_oficina == id_oficina);

            qry.Cast<tbl_entidad_legal>().ToList().ForEach(d =>
                lst.Add(new EntidadLegalEN
                {
                    id_entidad = d.id_entidad,
                    id_oficina = d.id_oficina,
                    Razon_social = string.Format("{0} {1}", d.id_entidad, d.Razon_social),
                    valor_impuesto = d.impuesto ?? 0
                }));

            lst.Insert(0, new EntidadLegalEN
            {
                id_entidad = "-1",
                id_oficina = id_oficina,
                Razon_social = "",
                valor_impuesto = 0
            });
            return lst;
        }

        public List<tbl_entidad_legal> Listar(bool soloActivo, bool fel)
        {
            List<tbl_entidad_legal> lst = new List<tbl_entidad_legal>();

            db.tbl_entidad_legal.Where(d => d.id_oficina == TiempoEnProcesoHelper.Helper.Oficina && (d.Estado ?? true) == true && (d.control_fel??false)==fel).ToList<tbl_entidad_legal>().ForEach(d =>
                lst.Add(new tbl_entidad_legal
                {
                    correlativo_anulaciones = d.correlativo_anulaciones,
                    correlativo_cobranzas = d.correlativo_cobranzas,
                    correlativo_facturas = d.correlativo_facturas,
                    correlativo_notas = d.correlativo_notas,
                    Direccion = d.Direccion,
                    Estado = d.Estado,
                    financiera = d.financiera,
                    formato_facturas = d.formato_facturas,
                    id_entidad = d.id_entidad,
                    id_oficina = d.id_oficina,
                    impuesto = d.impuesto,
                    incluido = d.incluido,
                    NIT = d.NIT,
                    origen_datos_factura = d.origen_datos_factura,
                    Razon_social = string.Format("{0} {1}", d.id_entidad, d.Razon_social),
                    tbl_tipo_documento = d.tbl_tipo_documento,
                    ubicacion_factura = d.ubicacion_factura,
                    Clave_Api = d.Clave_Api

                }));

            return lst;
        }
    }
}
