using FirmaXadesNet;
using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature;
using FirmaXadesNet.Signature.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TiempoEnProcesoHelper
{
    public static class FirmaDocumento
    {
        //Invocación de la firma de documento, retorno  y almacenamiento de este
        public static XmlDocument FirmarDocumento(string rutaCertificado, string contraseñaCertificado, string rutaDocumento, string ElementToSign, string ubicacionDestino)
        {
            X509Certificate2 cert = new X509Certificate2(rutaCertificado, contraseñaCertificado, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);

            SignatureParameters parametros = ParametrosdeFirma(ElementToSign);
            var nombredocumento = Path.GetFileNameWithoutExtension(rutaDocumento);

            using (parametros.Signer = new Signer(cert))
            {
                var documento = FirmaXades(parametros, rutaDocumento);
                AlmacenamientoDocumento(documento, ubicacionDestino, nombredocumento);
                return documento.Document;
            }

        }

        //Invocación de la firma de documento y retorno de este
        public static XmlDocument FirmarDocumento(string rutaCertificado, string contraseñaCertificado, string ElementToSign, string rutaDocumento)
        {
            X509Certificate2 cert = new X509Certificate2(rutaCertificado, contraseñaCertificado, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);

            SignatureParameters parametros = ParametrosdeFirma(ElementToSign);
            using (parametros.Signer = new Signer(cert))
            {
                return FirmaXades(parametros, rutaDocumento).Document;
            }
        }

        //Firma del documento
        private static SignatureDocument FirmaXades(SignatureParameters sp, string ruta)
        {
            XadesService xadesService = new XadesService();
            using (FileStream fs = new FileStream(ruta, FileMode.Open))
            {
                var documento = xadesService.Sign(fs, sp);
                MoverNodoFirma(documento);
                return documento;
            }
        }

        //Almacenamiento e ruta especifica
        private static void AlmacenamientoDocumento(SignatureDocument sd, string ruta, string nombre)
        {
            ruta = string.Format("{0}\\{1}-Firmado.xml",ruta,nombre);
            sd.Save(ruta);
        }
        
        //Parametros para la firma del documento
        private static SignatureParameters ParametrosdeFirma(string ElementToSign)
        {
            SignatureParameters parametros = new SignatureParameters
            {
                SignaturePackaging = SignaturePackaging.INTERNALLY_DETACHED,
                InputMimeType = "text/xml",
                ElementIdToSign = ElementToSign,
                SignatureMethod = SignatureMethod.RSAwithSHA256,
                DigestMethod = DigestMethod.SHA256,
                SigningDate = DateTime.Now.AddMinutes(-3)
            };

            return parametros;
        }
        
        //Cambio de posicion del nodo de la firma en el nodo padre del documento
        private static void MoverNodoFirma(SignatureDocument sd)
        {
            var documento = sd.Document;
            var NodoFirma = documento.GetElementsByTagName("ds:Signature")[0];
            NodoFirma.ParentNode.RemoveChild(NodoFirma);
            documento.DocumentElement.AppendChild(NodoFirma);
        }
    }
}

/*
 XDocument doc = new XDocument(
				new XDeclaration("1.0", "gb2312", string.Empty),
				new XElement( "products",
					new XElement( "product",
						new XAttribute( "id", "01" ),
						new XElement( "Name", "Java" ),
						new XElement( "Price", "Free" ) ),
					new XElement( "product",
						new XAttribute( "id", "02" ),
						new XElement( "Name", "C#" ),
						new XElement( "Price", "Free" )
						) ) );
 */