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
    public partial class frmGastoAdmon : Form
    {
        public tbl_gastos_administrativos Item { get; set; }
        public List<tbl_gastos_administrativos_detalle_empresas> lstD = new List<tbl_gastos_administrativos_detalle_empresas>();
        public List<tbl_gastos_administrativos_detalle_empresas> lst2Del = new List<tbl_gastos_administrativos_detalle_empresas>();
        ValueList empresasVl = new ValueList();
        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;
        public frmGastosAdmon frmGastosAdmon { get; set; }

        public frmGastoAdmon()
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

            string _id = uteIdBanco.Value.ToString();
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_gastos_administrativos.Any(d => d.id_gasto == _id))
                {
                    MessageBox.Show("Gasto Administrativo ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (uteIdBanco.Value != null)
                uteIdBanco.Value = uteIdBanco.Value.ToString().Trim();

        }

        public void CargarItem(string _gasto)
        {
            Item = db.tbl_gastos_administrativos.FirstOrDefault(d => d.id_gasto == _gasto);
            if (Item != null)
                lstD = db.tbl_gastos_administrativos_detalle_empresas.Where(d => d.Id_Gasto == Item.id_gasto).ToList();

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uteIdBanco.Value = Item.id_gasto;
            uteDescripcion.Value = Item.Descripcion.Trim();
            uckDistribucion.Checked = Item.Distribucion_Proporcional_socios ?? false;

            ugDataT.DataSource = lstD;
            ugDataT.DataBind();
        }

        public void CargaCombos()
        {
            empresasVl = new ValueList();
            db.tbl_entidad_legal.Where(d => d.id_oficina == Helper.Oficina).ToList().ForEach(d => empresasVl.ValueListItems.Add(d.id_entidad, d.Razon_social));
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
                    db.tbl_gastos_administrativos.Add(Item);

                db.SaveChanges();

                frmGastosAdmon.CargaGrid(false);
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
            ugDataT.PerformAction(UltraGridAction.CommitRow);
            if (AccionActual == Helper.Acciones.Agregar)
                Item.id_gasto = uteIdBanco.Value.ToString();

            Item.Distribucion_Proporcional_socios = uckDistribucion.Checked;

            Item.Descripcion = uteDescripcion.Value.ToString();

            if (lst2Del.Count > 0)
                db.tbl_gastos_administrativos_detalle_empresas.RemoveRange(lst2Del.AsEnumerable());

            foreach (tbl_gastos_administrativos_detalle_empresas _det in (List<tbl_gastos_administrativos_detalle_empresas>)ugDataT.DataSource)
            {
                if (string.IsNullOrEmpty(_det.Id_oficina))
                {
                    _det.Id_oficina = Helper.Oficina;
                    db.tbl_gastos_administrativos_detalle_empresas.Add(_det);
                }
            }

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
                    uteIdBanco.Enabled = false;

                    break;
            }
        }

        private void NuevoItem()
        {
            Item = new tbl_gastos_administrativos();
            uteIdBanco.Value = null;
            uckDistribucion.Checked = false;
            uteDescripcion.Value = null;

            lstD.Clear();
            ugDataT.DataBind();
            uteIdBanco.Focus();

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);
            Helper.SetUltraComboWidth(this);

            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();

            CargaCombos();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                ugDataT.DataSource = lstD;
                ugDataT.Enabled = false;
                ubAgregarData.Enabled = false;
                ubEliminaData.Enabled = false;
                NuevoItem();
            }

            uteIdBanco.Focus();

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
                SelectNextControl(uteIdBanco, true, true, true, true);
        }

        private void uckDistribucion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ubAgregarData_Click(object sender, EventArgs e)
        {
            lstD.Add(new tbl_gastos_administrativos_detalle_empresas { Activo = true });
            ugDataT.DataBind();
        }

        private void ugDataT_ClickCellButton(object sender, CellEventArgs e)
        {
            
        }

        private void ubEliminaData_Click(object sender, EventArgs e)
        {
            if (ugDataT.ActiveRow!=null)
            {
                if (!string.IsNullOrEmpty((ugDataT.ActiveRow.ListObject as tbl_gastos_administrativos_detalle_empresas).Id_oficina))
                        lst2Del.Add(ugDataT.ActiveRow.ListObject as tbl_gastos_administrativos_detalle_empresas);

                lstD.Remove(ugDataT.ActiveRow.ListObject as tbl_gastos_administrativos_detalle_empresas);
                ugDataT.DataBind();
            }
        }

        private void ugDataT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["Id_oficina"].ValueList = empresasVl;
        }
    }
}
