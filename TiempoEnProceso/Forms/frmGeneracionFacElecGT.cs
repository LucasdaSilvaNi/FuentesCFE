using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TiempoEnProcesoDL;
using TiempoEnProcesoHelper;
using TiempoEnProcesoBL;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.Misc;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using TiempoEnProcesoEN;

// ReSharper disable All

namespace TiempoEnProceso.Forms
{
    public partial class frmGeneracionFacElecGT : Form
    {
        private TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        List<tbl_cuenta_corriente> lst = new List<tbl_cuenta_corriente>();
        List<tbl_clientes> lstClientes = new List<tbl_clientes>();

        public frmGeneracionFacElecGT()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
            db.Database.CommandTimeout = Helper.TimeOut;
        }

        private void ultraToolbarsManager1_ToolClick(object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Grabar": // ButtonTool
                    if (Grabar())
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }

                    break;

                case "Cancelar": // ButtonTool
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;
            }
        }

        #region Metodos

        private bool ValidataControles()
        {
            LimpiaEspacios();

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).ubicacion_factura) &&
                string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).formato_facturas))
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void LimpiaEspacios()
        {
        }

        public void CargarItem(string _oficina, string _reporte, string _descripcion)
        {
        }

        private void AsignaCampos()
        {
        }

        public void CargaCombos()
        {
            IQueryable query = from emp in db.tbl_empleados
                join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                where emp.id_empleado == Helper.usuario
                select ofi;

            tbloficinaBindingSource.DataSource = query.Cast<tbl_oficina>().ToList();

            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar(true,true);

            IQueryable qry = db.tbl_clientes.Where(d => d.id_pais == Helper.Pais);
            lstClientes = qry.Cast<tbl_clientes>().ToList();

            ugData.DataSource = lst;
            ugData.DataBind();

            ucTipoSolicitud.DataSource = db.sp_lista_tipo_FElectronicaGT().ToList();

            ucOficce.Value = Helper.Oficina;
            ucTipoSolicitud.Value = "FAC";
        }


        private bool Grabar()
        {
            ugData.PerformAction(UltraGridAction.CommitRow);

            string sEntidad = ucEntidad.Value.ToString();

            List<tbl_frases> frases = db.tbl_frases.Where(d => d.Id_entidad == sEntidad && d.Id_oficina == Helper.Oficina).ToList();
            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                bool Genero = false;
                lst = new List<tbl_cuenta_corriente>();

                foreach (UltraGridRow ugr in ugData.Rows)
                {
                    if (Convert.ToBoolean(ugr.Cells["select"].Value))
                    {
                        lst.Add(ugr.ListObject as tbl_cuenta_corriente);
                        Genero = true;
                    }
                }

                bool bError = false;
                if (Genero)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowNewFolderButton = true;
                    fbd.Description = "Carpeta destino";
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string path = fbd.SelectedPath;
                        foreach (var item in lst)
                        {
                            bool bGenera = GeneraArchivo(path, item.tipo_documento, item.numero_documento,
                                db.sp_text_felectronica_GT(item.id_oficina, item.id_entidad, item.tipo_documento,
                                    item.numero_documento).ToList(), item, frases);
                            bError = bError && bGenera;
                        }
                    }
                }


                if (!Genero)
                {
                    MessageBox.Show("Debe seleccionar al menos una Factura");
                    return false;
                }
                else
                {
                    if (!bError)
                        Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Proceso",
                            "Facturas Electrónicas generadas satisfactoriamente");
                    else
                        Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Proceso",
                            "Facturas Electrónicas generadas parcialmente");
                }

                ubConsultar_Click(null, null);

                /*lst.Clear();
                ugData.DataSource = lst;
                ugData.DataBind();*/
                //Close();
            }
            catch (Exception ex)
            {
                db.tbl_empleados.Local.Clear();
                db.tbl_Log_Documento_Electronico.Local.Clear();
                Helper.ShowError("Execute", "Error al Ejecutar", ex);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return true;
        }

        private void Imprimir()
        {
            /*FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Carpeta destino";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = fbd.SelectedPath;
            */


            //}
        }

        private bool GeneraArchivo(string path, string tipo, decimal documento,
            List<sp_text_felectronica_GT_Result> list, tbl_cuenta_corriente item, List<tbl_frases> frases)
        {
            DataSet ds = list.ToDataSet();
            string sDetalle = string.Empty, sTotal = string.Empty;
            string docto = Guid.NewGuid().ToString().ToUpper();// string.Format("{0}-{1}-{2}", ucEntidad.Value.ToString(), tipo.Trim(), documento);
            string sPath = Application.ExecutablePath.ToUpper().Replace("TIEMPOENPROCESO.EXE", "");
            bool EsExportacion = list.FirstOrDefault()?.Codigo_unidad_Grabable == 2;
            bool EsNC = list.FirstOrDefault()?.Tipo_DTE == "NCRE";
            bool EsND = list.FirstOrDefault()?.Tipo_DTE == "NABN";
            XNamespace myPrefix = "http://www.sat.gob.gt/dte/fel/0.2.0";
            var itemL = list.FirstOrDefault();
            DateTime dtFechaTimbrado = DateTime.Now.AddMinutes(-3);

                XDocument doc = new XDocument(
                    //new XDeclaration("1.0", "UTF-8", "no"),
                    new XElement(myPrefix + "GTDocumento",
                        new XAttribute("Version", "0.1"),
                        new XAttribute(XNamespace.Xmlns + "dte", "http://www.sat.gob.gt/dte/fel/0.2.0"),
                        new XAttribute(XNamespace.Xmlns + "xd", "http://www.we.org/2000/09/xmldsig#"),
                        new XElement(myPrefix + "SAT",
                            new XAttribute("ClaseDocumento", "dte"),
                            new XElement(myPrefix + "DTE",
                                new XAttribute("ID", "DatosCertificados"),
                                new XElement(myPrefix + "DatosEmision",
                                    new XAttribute("ID", "DatosEmision"),
                                    new XElement(myPrefix + "DatosGenerales",
                                        new XAttribute("CodigoMoneda", itemL.Codigo_Moneda),
                                        new XAttribute("FechaHoraEmision", dtFechaTimbrado.ToString("yyyy-MM-ddTHH:mm:ss.000-06:00")),
                                        new XAttribute("NumeroAcceso", itemL.Numero_Acceso),
                                        new XAttribute("Tipo", itemL.Tipo_DTE)
                                    ),
                                    new XElement(myPrefix + "Emisor",
                                        new XAttribute("AfiliacionIVA", itemL.Afiliacion_iva),
                                        new XAttribute("CodigoEstablecimiento", itemL.Numero_Establecimiento),
                                        new XAttribute("CorreoEmisor", itemL.correo_emisor.Trim()),
                                        new XAttribute("NITEmisor", itemL.nit.Trim()),
                                        new XAttribute("NombreComercial", itemL.nombre_comercial),
                                        new XAttribute("NombreEmisor", itemL.nombre_comercial),
                                        new XElement(myPrefix + "DireccionEmisor",
                                            new XElement(myPrefix + "Direccion", itemL.direccion.Trim()),
                                            new XElement(myPrefix + "CodigoPostal", itemL.codigo_postal),
                                            new XElement(myPrefix + "Municipio",  "Guatemala"),
                                            new XElement(myPrefix + "Departamento", "Guatemala"),
                                            new XElement(myPrefix + "Pais", "GT")
                                        )
                                    ),
                                    new XElement(myPrefix + "Receptor",
                                        new XAttribute("CorreoReceptor", itemL.Correo_Receptor),
                                        new XAttribute("IDReceptor", itemL.Nit_Receptor.Trim()),
                                        new XAttribute("NombreReceptor", itemL.Nombre_Receptor.Trim()),
                                        new XElement(myPrefix + "DireccionReceptor",
                                            new XElement(myPrefix + "Direccion", "Ciudad"),
                                            new XElement(myPrefix + "CodigoPostal", "01001"),
                                            new XElement(myPrefix + "Municipio", "Guatemala"),
                                            new XElement(myPrefix + "Departamento", "Guatemala"),
                                            new XElement(myPrefix + "Pais", "GT")
                                        )
                                    ),
                                    new XElement(myPrefix + "Frases"),
                                    new XElement(myPrefix + "Items"
                                    ),
                                    new XElement(myPrefix + "Totales",
                                        new XElement(myPrefix + "TotalImpuestos",
                                            new XElement(myPrefix + "TotalImpuesto",
                                                new XAttribute("NombreCorto", "IVA"),
                                                new XAttribute("TotalMontoImpuesto", list.Sum(d=> d.valorimpuesto.Value).ToString("N2").Replace(",",""))
                                            )
                                        ),
                                        new XElement(myPrefix + "GranTotal", itemL.GranTotal.Value.ToString("N2").Replace(",",""))
                                    )
                                )
                            )
                        )
                    )
                );

            foreach (var itemFrase in frases)
            {
                doc.Element(myPrefix + "GTDocumento")
                        .Element(myPrefix + "SAT")
                            .Element(myPrefix + "DTE")
                                .Element(myPrefix + "DatosEmision")
                                    .Element(myPrefix + "Frases")
                                        .Add(new XElement(myPrefix + "Frase",
                                                new XAttribute("CodigoEscenario", itemFrase.Codigo_Escenario),
                                                new XAttribute("TipoFrase", itemFrase.Tipo_Frase)));
            }

            foreach (var itemD in list)
            {
                if (!EsND)
                {
                    doc.Element(myPrefix + "GTDocumento")
                        .Element(myPrefix + "SAT")
                            .Element(myPrefix + "DTE")
                                .Element(myPrefix + "DatosEmision")
                                    .Element(myPrefix + "Items")
                                    .Add(new XElement(myPrefix + "Item",
                                            new XAttribute("BienOServicio", itemD.Bien_o_servicio),
                                            new XAttribute("NumeroLinea", itemD.numero_linea),
                                            new XElement(myPrefix + "Cantidad", itemD.numero_items),
                                            new XElement(myPrefix + "UnidadMedida", itemD.Unidad_Medida),
                                            new XElement(myPrefix + "Descripcion", itemD.concepto.Trim()),
                                            new XElement(myPrefix + "PrecioUnitario", itemD.preciounitario.Value.ToString("N2").Replace(",", "")),
                                            new XElement(myPrefix + "Precio", itemD.precio.Value.ToString("N2").Replace(",", "")),
                                            new XElement(myPrefix + "Descuento", itemD.descuento.ToString("N2").Replace(",", "")),
                                            new XElement(myPrefix + "Impuestos",
                                                new XElement(myPrefix + "Impuesto",
                                                    new XElement(myPrefix + "NombreCorto", "IVA"),
                                                    new XElement(myPrefix + "CodigoUnidadGravable", itemD.Codigo_unidad_Grabable),
                                                    new XElement(myPrefix + "MontoGravable", (itemD.precio - itemD.valorimpuesto).Value.ToString("N2").Replace(",", "")),
                                                    //new XElement(myPrefix + "CantidadUnidadesGravables", "1"),
                                                    new XElement(myPrefix + "MontoImpuesto", itemD.valorimpuesto.Value.ToString("N2").Replace(",", ""))
                                                )
                                            ),
                                            new XElement(myPrefix + "Total", itemD.precio.Value.ToString("N2").Replace(",", ""))
                                        ));

                }
                else
                {
                    doc.Element(myPrefix + "GTDocumento")
                        .Element(myPrefix + "SAT")
                            .Element(myPrefix + "DTE")
                                .Element(myPrefix + "DatosEmision")
                                    .Element(myPrefix + "Items")
                                    .Add(new XElement(myPrefix + "Item",
                                            new XAttribute("BienOServicio", itemD.Bien_o_servicio),
                                            new XAttribute("NumeroLinea", itemD.numero_linea),
                                            new XElement(myPrefix + "Cantidad", itemD.numero_items),
                                            new XElement(myPrefix + "UnidadMedida", itemD.Unidad_Medida),
                                            new XElement(myPrefix + "Descripcion", itemD.concepto.Trim()),
                                            new XElement(myPrefix + "PrecioUnitario", itemD.preciounitario.Value.ToString("N2").Replace(",", "")),
                                            new XElement(myPrefix + "Precio", itemD.precio.Value.ToString("N2").Replace(",", "")),
                                            new XElement(myPrefix + "Descuento", itemD.descuento.ToString("N2").Replace(",", "")),
                                            new XElement(myPrefix + "Total", itemD.precio.Value.ToString("N2").Replace(",", ""))
                                        ));
                }
            }

            if (EsNC || EsND)
            {
                doc.Element(myPrefix + "GTDocumento")
                        .Element(myPrefix + "SAT")
                            .Element(myPrefix + "DTE")
                                .Element(myPrefix + "DatosEmision")
                                    .Element(myPrefix + "Frases")
                                        .Remove();
            }

            if (EsND)
            {
                doc.Element(myPrefix + "GTDocumento")
                    .Element(myPrefix + "SAT")
                        .Element(myPrefix + "DTE")
                            .Element(myPrefix + "DatosEmision")
                                .Element(myPrefix + "Totales")
                                    .Element(myPrefix + "TotalImpuestos")
                                        .Remove();
            }
            if (EsExportacion)
            {
                XNamespace newPrefix = "http://www.sat.gob.gt/face2/ComplementoExportaciones/0.1.0";

                var itemExp = list.FirstOrDefault();

                doc.Element(myPrefix + "GTDocumento")
                    .Element(myPrefix + "SAT")
                        .Element(myPrefix + "DTE")
                            .Element(myPrefix + "DatosEmision")
                                .Element(myPrefix + "DatosGenerales")
                                .Add(new XAttribute("Exp", "SI")

                                );

                if (!EsNC &&!EsND)
                {

                    doc.Element(myPrefix + "GTDocumento")
                        .Element(myPrefix + "SAT")
                            .Element(myPrefix + "DTE")
                                .Element(myPrefix + "DatosEmision")
                                    .Element(myPrefix + "Frases")
                                    .Add(new XElement(myPrefix + "Frase",
                                                new XAttribute("CodigoEscenario", "1"),
                                                new XAttribute("TipoFrase", "4")
                                            )
                                    );
                }

                if (!EsND)
                {
                    doc.Element(myPrefix + "GTDocumento")
                        .Element(myPrefix + "SAT")
                            .Element(myPrefix + "DTE")
                                .Element(myPrefix + "DatosEmision")
                                    .Add(new XElement(myPrefix + "Complementos",
                                        new XElement(myPrefix + "Complemento",
                                            new XAttribute("IDComplemento", "Exportacion"),
                                            new XAttribute("NombreComplemento", "Exportacion"),
                                            new XAttribute("URIComplemento", ""),
                                            new XElement(newPrefix + "Exportacion",
                                                new XAttribute(XNamespace.Xmlns + "cex", "http://www.sat.gob.gt/face2/ComplementoExportaciones/0.1.0"),
                                                new XAttribute("Version", 1),
                                                new XElement(newPrefix + "NombreConsignatarioODestinatario", itemExp.Nombre_Consignatario.Trim()),
                                                new XElement(newPrefix + "DireccionConsignatarioODestinatario", itemExp.Direccion_Consignatario.Trim()),
                                                //new XElement(newPrefix + "CodigoConsignatarioODestinatario", itemExp.Codigo_Consignatario.Trim()),
                                                new XElement(newPrefix + "NombreComprador", itemExp.Nombre_Comprador.Trim()),
                                                new XElement(newPrefix + "DireccionComprador", itemExp.Direccion_Comprador.Trim()),
                                                new XElement(newPrefix + "CodigoComprador", itemExp.Codigo_Comprador.Trim()),
                                                new XElement(newPrefix + "OtraReferencia", itemExp.OtraReferencia.Trim()),
                                                new XElement(newPrefix + "INCOTERM", itemExp.cEx.Trim()),
                                                new XElement(newPrefix + "NombreExportador", itemExp.Nombre_Exportador.Trim()),
                                                new XElement(newPrefix + "CodigoExportador", itemExp.Codigo_exportador.Trim())
                                            )
                                        )
                                    ));
                }
                if (EsNC)
                {
                    XNamespace ncPrefix = "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0";
                    doc.Element(myPrefix + "GTDocumento")
                        .Element(myPrefix + "SAT")
                            .Element(myPrefix + "DTE")
                                .Element(myPrefix + "DatosEmision")
                                    .Element(myPrefix + "Complementos")
                                        .Add(
                                            new XElement(myPrefix + "Complemento",
                                                new XAttribute("URIComplemento", "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0"),
                                                new XAttribute("NombreComplemento", "Complemento Referencia Nota"),
                                                new XAttribute("IDComplemento", "ComplementoReferenciaNota"),
                                                new XElement(ncPrefix + "ReferenciasNota",
                                                    new XAttribute("Version", "0"),
                                                    new XAttribute("SerieDocumentoOrigen", itemL.Serie_Autorizacion_Documento_Original),
                                                    new XAttribute("NumeroAutorizacionDocumentoOrigen", itemL.Numero_Autorizacion_Documento_Original),
                                                    new XAttribute("FechaEmisionDocumentoOrigen", itemL.Fecha_Emision_Documento_Original.Value.ToString("yyyy-MM-dd")),
                                                    new XAttribute(XNamespace.Xmlns + "cno", "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0")
                                                )
                                            )
                                        );
                    if ((itemL.Regimen_Antiguo??1)==1)
                    {
                        doc.Element(myPrefix + "GTDocumento")
                        .Element(myPrefix + "SAT")
                            .Element(myPrefix + "DTE")
                                .Element(myPrefix + "DatosEmision")
                                    .Element(myPrefix + "Complementos")
                                        .Element(myPrefix + "Complemento")
                                            .Element(newPrefix + "ReferenciasNota")
                                                .Add(new XAttribute("RegimenAntiguo", "Antiguo"));
                    }
                }
            }
            else if (EsNC)
            {
                XNamespace newPrefix = "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0";
                doc.Element(myPrefix + "GTDocumento")
                    .Element(myPrefix + "SAT")
                        .Element(myPrefix + "DTE")
                            .Element(myPrefix + "DatosEmision")
                                .Add(
                                    new XElement(myPrefix + "Complementos",
                                        new XElement(myPrefix + "Complemento",
                                            new XAttribute("URIComplemento", "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0"),
                                            new XAttribute("NombreComplemento", "Complemento Referencia Nota"),
                                            new XAttribute("IDComplemento", "ComplementoReferenciaNota"),
                                            new XElement(newPrefix + "ReferenciasNota",
                                                new XAttribute("Version", "0"),
                                                new XAttribute("SerieDocumentoOrigen", itemL.Serie_Autorizacion_Documento_Original),
                                                new XAttribute("NumeroAutorizacionDocumentoOrigen", itemL.Numero_Autorizacion_Documento_Original),
                                                new XAttribute("FechaEmisionDocumentoOrigen", itemL.Fecha_Emision_Documento_Original.Value.ToString("yyyy-MM-dd")),
                                                new XAttribute(XNamespace.Xmlns + "cno", "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0")
                                            )
                                        )
                                    )
                                );

                if ((itemL.Regimen_Antiguo ?? 1) == 1)
                {
                    doc.Element(myPrefix + "GTDocumento")
                    .Element(myPrefix + "SAT")
                        .Element(myPrefix + "DTE")
                            .Element(myPrefix + "DatosEmision")
                                .Element(myPrefix + "Complementos")
                                    .Element(myPrefix + "Complemento")
                                        .Element(newPrefix + "ReferenciasNota")
                                            .Add(new XAttribute("RegimenAntiguo", "Antiguo"));
                }
            }

            doc.Element(myPrefix + "GTDocumento")
                .Element(myPrefix + "SAT")
                    .Add(
                        new XElement(myPrefix + "Adenda",
                            new XElement(myPrefix + "AdendaDetail",
                                new XAttribute("id", "AdendaSummary"),
                                new XElement(myPrefix + "AdendaSummary",
                                    new XElement(myPrefix + "Valor1", itemL.Adenda1),
                                    new XElement(myPrefix + "Valor2", itemL.Adenda2.Trim()),
                                    new XElement(myPrefix + "Valor3", itemL.Adenda3),
                                    new XElement(myPrefix + "Valor4", itemL.Adenda4.Trim()),
                                    new XElement(myPrefix + "Valor5", itemL.Adenda5.Trim())
                                )
                            )
                        )
                    );

            if (EsExportacion)
            {
                doc.Element(myPrefix + "GTDocumento")
                    .Element(myPrefix + "SAT")
                        .Element(myPrefix + "Adenda")
                            .Element(myPrefix + "AdendaDetail")
                                .Element(myPrefix + "AdendaSummary")
                                    .Add(
                                        new XElement(myPrefix + "Valor6", itemL.Adenda6.Trim())
                                    );

            }

            doc.Save(string.Format("{0}{1}.xml", sPath, docto), SaveOptions.DisableFormatting);
            string salida = doc.Root.ToString().Replace("\n", "").Replace("\r", "").Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "").Replace("reemplazarSchema=\"aqui\"", "xsi:schemaLocation=\"http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0 GT_Complemento_Referencia_Nota-0.1.0.xsd\"");
            /*using (StreamWriter file = new StreamWriter(string.Format("{0}\\{1}_{2}.txt", path, tipo.Trim().Replace("/","_"), documento)))
            {*/

            tbl_entidad_legal entidad = ucEntidad.SelectedRow.ListObject as tbl_entidad_legal;
            /*string sFileName = $"{entidad.NIT.Replace("-","").Replace(" ","")}.pfx";
            System.IO.File.WriteAllBytes(sFileName, Convert.FromBase64String(entidad.Certificado));

            XmlDocument xml_fel = FirmaDocumento.FirmarDocumento(sPath + sFileName, entidad.Clave_Cliente,
                "DatosEmision", string.Format("{0}{1}.xml", sPath, docto));

            /*XmlNode node = xml_fel.SelectSingleNode("/det:GTDocumento/ds:Signature/ds:Object/xades:QualifyingProperties/xades:SignedProperties/xades:SignedSignatureProperties");
            node.InnerText = DateTime.Now.AddMinutes(-3).ToString("yyyy-mm-ddTHH:mm:ss") + "06:00";*


            string sLinea = xml_fel.OuterXml.Replace("\n", "").Replace("\r", "").Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");*/

            tbl_empleados usuario = Helper.UsuarioActivo as tbl_empleados;
            DateTime FechaVenc = DateTime.Now.AddYears(-1);
            tbl_empleado_entidad_legal entidadFEL = db.tbl_empleado_entidad_legal.FirstOrDefault(d => d.Id_Empleado == Helper.usuario && d.Id_Entidad == entidad.id_entidad && d.Id_Oficina == entidad.id_oficina);
            if (entidadFEL == null)
            {
                entidadFEL = new tbl_empleado_entidad_legal()
                {
                    Id_Empleado = Helper.usuario,
                    Id_Entidad = entidad.id_entidad,
                    Id_Oficina = Helper.Oficina
                };
                db.tbl_empleado_entidad_legal.Add(entidadFEL);
                db.SaveChanges();
            }
            if (entidadFEL.Fecha_Hora_Expira_Token != null)
                FechaVenc = entidadFEL.Fecha_Hora_Expira_Token.Value;

            string data = string.Empty;
            string url_action = string.Empty;
            if (FechaVenc.AddMinutes(-2) < DateTime.Now)
            {
                /*TOKEN EXPIRADO, solicitar nuevo*/
                data = string.Format(
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SolicitaTokenRequest><usuario>{0}</usuario><apikey>{1}</apikey></SolicitaTokenRequest>",
                    entidad.NIT.Trim(), entidad.Clave_Api);
                url_action = string.Format("{0}{1}", Helper.GetConfigValue("FEL_GT"),
                    Helper.GetConfigValue("GetToken"));

                //MessageBox.Show($"Direccion Obtencion Token: {url_action}");
                SolicitaTokenResponse response =
                    Helper.SendToFEL<SolicitaTokenResponse>(url_action, data, string.Empty);

                if (response.tipo_respuesta == "1")
                {
                    Helper.ShowError("Obtener Token", response.errores, null, MessageBoxButtons.OK,
                        "Generación Factura Electrónica");
                    return false;
                }

                entidadFEL.FE_Token = response.token;
                entidadFEL.Fecha_Hora_Expira_Token = response.vigencia;

                db.SaveChanges();
            }

            data = string.Format(
                "<FirmaDocumentoRequest id=\"{0}\"><xml_dte><![CDATA[{1}]]></xml_dte></FirmaDocumentoRequest>",
                docto, salida);
            url_action = string.Format("{0}{1}", Helper.GetConfigValue("FEL_Firma"),
                Helper.GetConfigValue("solicitaFirma"));
            FirmaDocumentoResponse responseFirmaDocto = Helper.SendToFEL<FirmaDocumentoResponse>(url_action, data,
                entidadFEL.FE_Token);
            bool bProc = responseFirmaDocto.tipo_respuesta == "0";

            /*envio*/
            if (bProc)
            {
                data = string.Empty;
                url_action = string.Empty;

                DateTime dtEnvio = DateTime.Now;

                data = string.Format(
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?><RegistraDocumentoXMLRequest id=\"{0}\"><xml_dte><![CDATA[{1}]]></xml_dte></RegistraDocumentoXMLRequest>",
                    docto, responseFirmaDocto.xml_dte);
                url_action = string.Format("{0}{1}", Helper.GetConfigValue("FEL_V2_GT"),
                    Helper.GetConfigValue("registrarDocto"));
                RegistraDocumentoXMLResponse responseDocto = Helper.SendToFEL<RegistraDocumentoXMLResponse>(url_action, data,
                    entidadFEL.FE_Token);
                bProc = responseDocto.tipo_respuesta == "0";

                string numero_serie = string.Empty, numero_docto = string.Empty;
                if (!string.IsNullOrEmpty(responseDocto.uuid))
                {
                    string[] datosElectronicos = responseDocto.uuid.Split('-');
                    numero_serie = datosElectronicos.Length > 0 ? datosElectronicos[0] : string.Empty;
                    numero_docto = datosElectronicos.Length > 2 ? convert2decimal(datosElectronicos[1] + datosElectronicos[2]) : string.Empty;
                }

                tbl_Log_Documento_Electronico _log = new tbl_Log_Documento_Electronico
                {
                    detalle_envio = data,
                    docto_electronico = responseDocto.xml_dte,
                    Fecha_Hora_Envio = dtEnvio,
                    id_oficina = Helper.Oficina,
                    numero_documento = documento,
                    respuesta_fiscal = responseDocto.errores,
                    resultado_envio = responseDocto.uuid,
                    tipo_documento = tipo,
                    id_entidad = ucEntidad.Value.ToString(),
                    Aprobado = bProc,
                    Numero_Serie_Electronica = numero_serie,
                    Numero_Documento_Electronico = numero_docto
                };

                db.tbl_Log_Documento_Electronico.Add(_log);
                db.SaveChanges();

                if (!bProc)
                    MessageBox.Show(string.Format("Error en {0}-{1}:\n{2}", tipo.Trim(), documento, responseDocto.errores),
                        Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    item.clave_electronica = responseDocto.uuid;
                    item.numero_documento_fiscal_electronico = responseDocto.xml_dte;
                    item.fecha_timbrado = dtFechaTimbrado;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;

                    _log.fecha_hora_timbrado = dtFechaTimbrado;
                    db.Entry(_log).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    /*data = string.Format(
                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?><RetornaXMLRequest><uuid>{0}</uuid></RetornaXMLRequest>",
                        responseDocto.uuid);
                    url_action = string.Format("{0}{1}", Helper.GetConfigValue("FEL_GT"),
                        Helper.GetConfigValue("retornarXML"));
                    RetornaXMLResponse responseXML = Helper.SendToFEL<RetornaXMLResponse>(url_action, data,
                        (Helper.UsuarioActivo as tbl_empleados).FE_Token);*/

                    if (responseDocto.tipo_respuesta == "0")
                    {
                        File.WriteAllText(string.Format(@"{0}\{1}.xml", path, docto), responseDocto.xml_dte.Replace("&lt;", "<").Replace("&gt;", ">"));
                    }

                    /*data = string.Format(
                        "<?xml version=\"1.0\" encoding=\"UTF-8\"?><RetornaPDFRequest><uuid>{0}</uuid></RetornaPDFRequest>",
                       responseDocto.uuid);
                    url_action = string.Format("{0}{1}", Helper.GetConfigValue("FEL_GT"),
                        Helper.GetConfigValue("retornarPDF"));
                    RetornaPDFResponse responseDet =
                        Helper.SendToFEL<RetornaPDFResponse>(url_action, data, (Helper.UsuarioActivo as tbl_empleados).FE_Token);

                    if (responseDet.tipo_respuesta == "0")
                    {
                        byte[] bytes = Convert.FromBase64String(responseDet.pdf);
                        File.WriteAllBytes(string.Format(@"{0}\{1}.pdf", path, docto), bytes);
                    }*/
                } 
            }
            else
            {
                var directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                System.IO.File.WriteAllText(System.IO.Path.Combine(directory, $"{docto.ToUpper()}.xml"), salida);
                MessageBox.Show($"XML Generado en: {System.IO.Path.Combine(directory, $"{docto.ToUpper()}.xml")}");
            }

            return bProc;
        }

        private string convert2decimal(string vHexa)
        {
            long doctoVal = long.Parse(vHexa, System.Globalization.NumberStyles.HexNumber);
            return doctoVal.ToString();
        }

        private void ConstruyeItem()
        {
        }

        private void EstableceHabilitacion()
        {
        }

        private void NuevoItem()
        {
        }

        private void SetEnableControls(bool Enable)
        {
        }

        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            CargaCombos();
            uceTipoDoctoFiscal.Value = "FAC";
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                //Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                //DialogResult = System.Windows.Forms.DialogResult.OK;
                //Close();
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void ultraPanel4_PaintClient(object sender, PaintEventArgs e)
        {
        }

        private void uceEstado_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ultraPanel3_PaintClient(object sender, PaintEventArgs e)
        {
        }

        private void ucEntidad_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEntidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucEntidad, true, true, true, true);
        }

        private void ucEntidad_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["Razon_social"].Value.ToString().Trim());
        }

        private void upTipo_ValueChanged(object sender, EventArgs e)
        {
        }


        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.Row.Cells["select"].Value == null ||
                e.Row.Cells["select"].Value == DBNull.Value)
                e.Row.Cells["select"].Value = false;

            if (e.ReInitialize) return;

            tbl_oficina _oficina = ucOficce.SelectedRow.ListObject as tbl_oficina;
            string _cliente = e.Row.Cells["id_cliente"].Value.ToString();
            tbl_clientes _cl =
                lstClientes.FirstOrDefault(d => d.id_cliente == _cliente && d.id_pais == _oficina.id_pais);
            if (_cl != null)
                e.Row.Cells["cliente"].Value = _cl.Razon_Social;
        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
        }

        private void ubConsultar_Click(object sender, EventArgs e)
        {
            if (ucEntidad.Value == null)
            {
                MessageBox.Show("Debe seleccionar una Entidad Valida");
                return;
            }

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Debe seleccionar una Entidad Valida");
                return;
            }

            if (uceTipoDoctoFiscal.Value != null &&
                uceTipoDoctoFiscal.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un Tipo Valido");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                string _tipo = uceTipoDoctoFiscal.Value.ToString();

                IQueryable query = from a in db.tbl_cuenta_corriente
                    where
                        a.id_oficina == Helper.Oficina &&
                        a.tipo_documento_fiscal == _tipo &&
                        string.IsNullOrEmpty(a.numero_documento_fiscal_electronico) &&
                        a.estado!=2 &&
                        a.id_entidad == ucEntidad.Value.ToString()
                    select a;

                lst = query.Cast<tbl_cuenta_corriente>().ToList();
                ugData.DataSource = lst;
                ugData.DataBind();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Consultar", "Error", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ugData_ClickCellButton(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "edit")
            {
                decimal no_solicitud = Convert.ToDecimal(e.Cell.Row.Cells["id_solicitud"].Value);
                using (frmSolicitudFactura frm = new frmSolicitudFactura())
                {
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.EdicionLimitada = true;
                    frm.CargarItem(no_solicitud);
                    frm.ShowDialog();
                }
            }
        }

        private void ucTipoSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucTipoSolicitud, true, true, true, true);
        }
    }
}
/*
XmlSerializer serializer = new XmlSerializer(typeof(SolicitaTokenResponse));

            HttpWebRequest req = WebRequest.Create("https://dev.api.ifacere-fel.com/fel-dte-services/api/solicitarToken") as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/xml";
            req.Method = "POST";

            string data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SolicitaTokenRequest><usuario>418447</usuario><apikey>UKEMBPrmsHOcbhFbkGaaN5B</apikey></SolicitaTokenRequest>";

            byte[] buffer = Encoding.UTF8.GetBytes(data);
            Stream PostData = req.GetRequestStream();
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();

            WebResponse response = req.GetResponse();

            var dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            Serializer ser = new Serializer();
            SolicitaTokenResponse tokenResponse = ser.Deserialize<SolicitaTokenResponse>(responseFromServer);

            Console.WriteLine(responseFromServer);
            Console.ReadLine();
 */