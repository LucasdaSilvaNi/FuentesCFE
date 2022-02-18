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

namespace TiempoEnProceso.Forms
{
    public partial class frmEntidad : Form
    {
        public tbl_entidad_legal Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }
        List<tbl_frases> Detalle = new List<tbl_frases>();
        private bool esGT = Helper.EsGt;
        private TEPEntities db;
        public frmEntidades frmEntidades { get; set; }
        public frmEntidad()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Grabar":    // ButtonTool
                    if (Grabar())
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    break;

                case "Cancelar":    // ButtonTool
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;

            }

        }

        #region Metodos
        private bool ValidataControles()
        {
            LimpiaEspacios();

            if (!uvValidador.Validate("required", false, true).IsValid)
                return false;

            string _id = uteId.Value.ToString();
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_entidad_legal.Any(d => d.id_entidad==_id && d.id_oficina== Helper.Oficina))
                {
                    MessageBox.Show("Entidad ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (AccionActual == Helper.Acciones.Editar)
            {
            }


            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();

            if (uteId.Value != null)
                uteId.Value = uteId.Value.ToString().Trim();

            if (uteDireccion.Value != null)
                uteDireccion.Value = uteDireccion.Value.ToString().Trim();

            if (uteNit.Value != null)
                uteNit.Value = uteNit.Value.ToString().Trim();

            if (uteFormato.Value != null)
                uteFormato.Value = uteFormato.Value.ToString().Trim();
        }

        public void CargarItem(string _entidad)
        {
            Item = db.tbl_entidad_legal.Include("tbl_frases").FirstOrDefault(d =>d.id_entidad==_entidad && d.id_oficina == Helper.Oficina);
            Detalle = Item.tbl_frases.ToList();
            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uteId.Value = Item.id_entidad;
            uteDescripcion.Value = Item.Razon_social.Trim();
            uteDireccion.Value = Item.Direccion;
            uteNit.Value = Item.NIT;
            uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);
            uneFacturas.Value = Item.correlativo_facturas;
            uneCobranzas.Value = Item.correlativo_cobranzas;
            uneAnulaciones.Value = Item.correlativo_anulaciones;
            uneNotas.Value = Item.correlativo_anulaciones;
            uckIncluido.Checked = Item.incluido == Helper.SI;
            uckEntidad.Checked = Item.financiera ;
            uneImpuesto.Value = Item.impuesto;
            uteUbicacion.Value = Item.ubicacion_factura;
            uteFormato.Value = Item.formato_facturas;
            uckActivo.Checked = Item.Estado ?? true;
            uteOrigen.Value = Item.origen_datos_factura;
            uteApi.Value = Item.Clave_Api;
            uteAcceso.Value = Item.Clave_Acceso;
            uteClaveCertificado.Value = Item.Clave_Cliente;
            uteFormatoFEL.Value = Item.Formato_FEL;
            ugData.DataSource = Detalle;
            ugData.DataBind();
        }

        public void CargaCombos()
        {
        }


        private bool Grabar()
        {
            if (AccionActual == Helper.Acciones.Consultar)
                return true;

            if (!ValidataControles())
                return false;

            try
            {
                ConstruyeItem();

                if (AccionActual == Helper.Acciones.Agregar)
                    db.tbl_entidad_legal.Add(Item);

                db.SaveChanges();
                frmEntidades.CargaGrid(false);
            }
            catch (Exception ex)
            {
                Helper.ShowError("Save", "Error al guardar", ex);
                return false;
            }

            return true;
        }

        private void ConstruyeItem()
        {

            if (AccionActual == Helper.Acciones.Agregar)
            {
                Item.id_entidad = uteId.Value.ToString();
                Item.id_oficina = Helper.Oficina;
            }

            Item.Razon_social = uteDescripcion.Value.ToString();
            Item.Estado = uckActivo.Checked;

            Item.Direccion = string.Empty;
            if (uteDireccion.Value != null)
                Item.Direccion = uteDireccion.Value.ToString();

            Item.NIT = string.Empty;
            if (uteNit.Value != null)
                Item.NIT = uteNit.Value.ToString();

            Item.correlativo_anulaciones = uneAnulaciones.Value.ToString();
            Item.correlativo_cobranzas = uneCobranzas.Value.ToString();
            Item.correlativo_facturas = uneFacturas.Value.ToString();
            Item.correlativo_notas = uneNotas.Value.ToString();
            Item.impuesto = Convert.ToDecimal(uneImpuesto.Value);
            Item.financiera = uckEntidad.Checked ;
            Item.incluido = uckIncluido.Checked ? Helper.SI : Helper.NO;
            Item.ubicacion_factura = null;
            if (uteUbicacion.Value != null)
                Item.ubicacion_factura = uteUbicacion.Value.ToString();

            Item.formato_facturas = null;
            if (uteFormato.Value != null)
                Item.formato_facturas = uteFormato.Value.ToString();

            Item.origen_datos_factura = null;
            if (uteOrigen.Value != null)
                Item.origen_datos_factura = uteOrigen.Value.ToString();

            Item.Clave_Acceso = null;
            if (uteAcceso.Value != null)
                Item.Clave_Acceso = uteAcceso.Value.ToString();

            Item.Clave_Api = null;
            if (uteApi.Value != null)
                Item.Clave_Api = uteApi.Value.ToString();

            Item.Clave_Cliente = null;
            if (uteClaveCertificado.Value != null)
                Item.Clave_Cliente = uteClaveCertificado.Value.ToString();

            Item.Formato_FEL = null;
            if (uteFormatoFEL.Value != null)
                Item.Formato_FEL = uteFormatoFEL.Value.ToString();

            Detalle.ForEach(d =>
            {
                if (d.Id_tbl_frase == 0)
                {
                    d.Id_entidad = Item.id_entidad;
                    d.Id_oficina = Item.id_oficina;

                    Item.tbl_frases.Add(d);
                }
            });
        }

        private void EstableceHabilitacion()
        {
            switch (AccionActual)
            {
                case Helper.Acciones.Agregar:
                    break;
                case Helper.Acciones.Consultar:
                    SetEnableControls(false);
                    break;
                case Helper.Acciones.Editar:
                    uteId.Enabled = false;

                    break;
            }
            uteOficina.Enabled = false;
        }

        private void NuevoItem()
        {
            Item = new tbl_entidad_legal();
            Detalle = new List<tbl_frases>();
            ugData.DataSource = Detalle;
            ugData.DataBind();

            uteId.Value = null;
            uteDescripcion.Value = null;
            uteDireccion.Value = null;
            uteNit.Value = null;
            uneAnulaciones.Value = 0;
            uneFacturas.Value = 0;
            uneCobranzas.Value = 0;
            uneNotas.Value = 0;
            uneImpuesto.Value = 0;
            uckEntidad.Checked = false;
            uckIncluido.Checked = false;
            uteApi.Value = null;
            uteAcceso.Value = null;

            uteId.Focus();

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraButton>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);
            Helper.SetUltraComboWidth(this); 

            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();

            CargaCombos();
            ultraTabControl1.Tabs[1].Visible = esGT;
            if (AccionActual == Helper.Acciones.Agregar)
            {
                uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);
                NuevoItem();
            }

            uteId.Focus();

        }



        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                if (Helper.Continuo && AccionActual == Helper.Acciones.Agregar)
                    NuevoItem();
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            if (Helper.Continuo)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;

            Close();
        }

        private void uteDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDescripcion, true, true, true, true);
        }

        private void uteIdBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteId, true, true, true, true);
        }

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDireccion, true, true, true, true);
        }


        private void uckCaptar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckIncluido, true, true, true, true);
        }

        private void uckFacturar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckEntidad, true, true, true, true);
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uteNit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteNit, true, true, true, true);
        }

        private void uneFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneFacturas, true, true, true, true);
        }

        private void uneCobranzas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneCobranzas, true, true, true, true);
        }

        private void uneNotas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneNotas, true, true, true, true);
        }

        private void uneAnulaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneAnulaciones, true, true, true, true);
        }

        private void uneImpuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneImpuesto, true, true, true, true);
        }

        private void uteUbicacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteUbicacion, true, true, true, true);
        }

        private void ubFolder_Click(object sender, EventArgs e)
        {
            if (uteUbicacion.Value != null)
                folderBrowserDialog1.SelectedPath = uteUbicacion.Value.ToString();

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                uteUbicacion.Value = folderBrowserDialog1.SelectedPath;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (uteFormato.Value != null)
                openFileDialog1.FileName = uteFormato.Value.ToString();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                uteFormato.Value = openFileDialog1.FileName;
        }

        private void uteFormato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteFormato, true, true, true, true);
        }

        private void uckActivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ubAgregar.Focus();
        }

        private void uteOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteOrigen, true, true, true, true);
        }

        private void uteAcceso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteAcceso, true, true, true, true);
        }

        private void uteApi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteApi, true, true, true, true);
        }

        

        private void ubAgregarData_Click(object sender, EventArgs e)
        {
            uvValidador.ValidationGroups["requiredData"].Enabled = true;

            if (!uvValidador.Validate("requiredData", false, true).IsValid)
                return;

            if (uneEscenario.Value != null &&
                Convert.ToDecimal(uneEscenario.Value) <= 0)
            {
                MessageBox.Show("Escenario Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (uneTipFrase.Value != null &&
                Convert.ToDecimal(uneTipFrase.Value) <= 0)
            {
                MessageBox.Show("Tipo Frase Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int iEscenario = Convert.ToInt32(uneEscenario.Value);
            int iTipFrase = Convert.ToInt32(uneTipFrase.Value);
            if (!Detalle.Any(d=> d.Codigo_Escenario == iEscenario && d.Tipo_Frase == iTipFrase))
            {
                Detalle.Add(new tbl_frases
                {
                    Codigo_Escenario = iEscenario,
                    Tipo_Frase = iTipFrase
                });

                ugData.DataBind();
                uneEscenario.Value = null;
                uneTipFrase.Value = null;
                uvValidador.ValidationGroups["requiredData"].Enabled = false;
            }
        }

        private void ubEliminaData_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                var item = ugData.ActiveRow.ListObject as tbl_frases;
                if (item.Id_tbl_frase != 0)
                    Item.tbl_frases.Remove(item);

                Detalle.Remove(item);
                ugData.DataBind();
            }
        }
    }
}
