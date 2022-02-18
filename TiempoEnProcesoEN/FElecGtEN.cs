using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoEnProcesoEN
{
    public class SolicitaTokenResponse
    {

        public string tipo_respuesta { get; set; }
        public List<error> listado_errores { get; set; }
        public string token { get; set; }
        public DateTime vigencia { get; set; }

        public string errores
        {
            get
            {
                if (listado_errores.Count() == 0) return string.Empty;
                return listado_errores.Select(d => d.desc_error).Aggregate((s1, s2) => string.Format("{0}\n{1}\n", s1, s2));                
            }
        }
    }

    public class error
    {
        public string cod_error { get; set; }
        public string desc_error { get; set; }

        public string error_desc { get { return string.Format("{0} : {1}", cod_error, desc_error); } }
    }

    public class DocumentoResponse
    {
        public string tipo_respuesta { get; set; }
        public List<error> listado_errores { get; set; }
        public string uuid { get; set; }
        public string xml_dte { get; set; }

        public string errores
        {
            get
            {
                if (listado_errores.Count() == 0) return string.Empty;
                return listado_errores.Select(d => d.desc_error).Aggregate((s1, s2) => string.Format("{0}\n{1}\n", s1, s2));
            }
        }
    }

    public class RetornaPDFResponse : DocumentoResponse
    {
        public string pdf { get; set; }
    }

    public class RegistraDocumentoXMLResponse : DocumentoResponse
    {

    }

    public class AnulaDocumentoXMLResponse : DocumentoResponse
    {

    }


    public class RetornaXMLResponse : DocumentoResponse
    {

    }

    public class ValidaDocumentoDocumentoResponse : DocumentoResponse
    {

    }

    public class FirmaDocumentoResponse : DocumentoResponse
    { }

}
