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
using TiempoEnProcesoEN;

namespace TiempoEnProceso.Forms
{
    public partial class frmGastosAutomaticos : Form
    {
        public Tbl_gts_automaticos Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        List<tbl_gts_automaticos_detalle> lstD = new List<tbl_gts_automaticos_detalle>();

        private TEPEntities db;

        public frmGastosAutomaticos()
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

            if (!uvValidador.Validate("reqVal", false, true).IsValid)
                return false;

            if (ucConcepto.Value != null &&
                ucConcepto.SelectedRow == null)
            {
                MessageBox.Show("Seleccion Gasto Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            /*if (Convert.ToDecimal(uneGastos.Value) <= 0)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }*/

            if (ugData.Rows.Count <= 0)
            {
                MessageBox.Show("Detalle Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!((List<tbl_gts_automaticos_detalle>)ugData.DataSource).Any(d => d.estado != 0))
            {
                MessageBox.Show("Debe seleccionar al menos un Servicio", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            /*bool bS = false;
            foreach(UltraGridRow _r in ugData.Rows)
                bS = bS || _r.ce
            */
            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();
        }

        public void CargarItem(int _id_transaccion)
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Item = db.Tbl_gts_automaticos.FirstOrDefault(d => d.Id_transaccion== _id_transaccion);
            if (Item != null)
            {
                lstD = db.tbl_gts_automaticos_detalle.Where(d => d.Id_transaccion == _id_transaccion).ToList<tbl_gts_automaticos_detalle>();

                CargaCombos();
                AsignaCampos();
            }
            else
            {
                Item = new Tbl_gts_automaticos();
                lstD = new List<tbl_gts_automaticos_detalle>();
                foreach (tbl_servicios _srv in db.tbl_servicios.OrderBy(d => d.id_servicio).ToList<tbl_servicios>())
                    lstD.Add(new tbl_gts_automaticos_detalle()
                    {
                        estado = 0,
                        id_servicio = _srv.id_servicio
                    });

                AsignaCampos();
            }
        }

        private void AsignaCampos()
        {
            ugData.DataSource = lstD;
        }

        public void CargaCombos()
        {
            tblgastosadministrativosBindingSource.DataSource = (new GastosAdmBL(ref db)).Listar();
        }


        private bool Grabar()
        {
            try
            {
                ultraPanel7.Visible = true;
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                if (!ValidataControles())
                    return false;

                using (var dbTran = db.Database.BeginTransaction())
                {
                    ConstruyeItem();

                    /*if (AccionActual == Helper.Acciones.Agregar)
                        db.tbl_entidad_legal.Add(Item);*/

                    db.SaveChanges();
                    dbTran.Commit();
                }

                Item.estado = 1;
                db.SaveChanges();
                ultraPanel7.Visible = false;
            }
            catch (Exception ex)
            {
                ultraPanel7.Visible = false;
                Helper.ShowError("Save", "Error al guardar", ex);
                return false;
            }

            return true;
        }

        private void ConstruyeItem()
        {
            bool bExiste = false;

            tbl_oficina _tb = Helper.OficinaActiva as tbl_oficina;
            tbl_correlativos _correl = db.tbl_correlativos.FirstOrDefault(d => d.tabla == "tbl_gts_automaticos");
            decimal dIDTran = _correl.correlativo.Value + 1;
           
            if (!bExiste)
            {
                Item = new Tbl_gts_automaticos();

                Item.Descripcion = uteDescripcion.Value.ToString();
                Item.estado = 0;
                Item.id_gasto = ucConcepto.Value.ToString();
                Item.Id_transaccion = dIDTran;
                Item.Periodo_tep_proceso = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
                Item.Tipo_distribucion = Convert.ToDecimal(upOption.Value);
                Item.usuario = Helper.usuario;

                Item.Valor = Convert.ToDecimal(uneGastos.Value);
                Item.Fecha = Convert.ToDateTime(uccFechaNac.Value);
                Item.Periodo_tep_proceso = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
                Item.Id_transaccion = dIDTran;
                Item.id_oficina = Helper.Oficina;
                db.Tbl_gts_automaticos.Add(Item);
            }
            db.SaveChanges();

            decimal iLinea = 1;
            iLinea = db.tbl_distribuidos.Max(d => d.id_linea) + 1;

            foreach (UltraGridRow _detR in ugData.Rows)
            {
                if (Convert.ToBoolean(_detR.Cells["estado"].Value))
                {
                    tbl_gts_automaticos_detalle _det = _detR.ListObject as tbl_gts_automaticos_detalle;
                    if (_det.Id_transaccion == 0)
                    {
                        _det.Id_transaccion = Item.Id_transaccion;
                        _det.Linea = iLinea++;
                        db.tbl_gts_automaticos_detalle.Add(_det);
                    }
                }
            }

            //Item.estado = 1;
            _correl.correlativo = dIDTran ;

            //Item.valor_total = db.tbl_distribuidos.Sum(d => d.valor);
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
                    break;
            }
            uteOficina.Enabled = false;
        }

        private void NuevoItem()
        {
            NuevoItemHeader();

        }

        private void NuevoItemHeader()
        {
            uteDescripcion.Value = null;
            uccFechaNac.Value = ultraCalendarInfo1.MinDate;
            ucConcepto.Value = null;
            uneGastos.Value = 0;
            lstD.Clear();
            ugData.DataBind();

            //lstD = new List<tbl_gts_automaticos_detalle>();
            foreach (tbl_servicios _srv in db.tbl_servicios.OrderBy(d => d.id_servicio).ToList<tbl_servicios>())
                lstD.Add(new tbl_gts_automaticos_detalle()
                {
                    estado = 0,
                    id_servicio = _srv.id_servicio
                });

            ugData.DataBind();

            uccFechaNac.Focus();
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
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

            CargaCombos();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);

                utePeriodo.Value= _oficina.periodo_proceso;

                ultraCalendarInfo1.MaxDate = new DateTime(Convert.ToInt32(_oficina.periodo_proceso.Substring(3)), Convert.ToInt32(_oficina.periodo_proceso.Substring(0, 2)), 1).AddMonths(7).AddDays(-1);
                ultraCalendarInfo1.MinDate = new DateTime(Convert.ToInt32(_oficina.periodo_proceso.Substring(3)), Convert.ToInt32(_oficina.periodo_proceso.Substring(0, 2)), 1).AddMonths(6);

                ugData.DataSource = lstD;
                
                NuevoItem();
            }

            uccFechaNac.Focus();

        }



        private void ubAgregar_Click(object sender, EventArgs e)
        {
            ugData.PerformAction(UltraGridAction.CommitRow);

            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                if (Helper.Continuo && AccionActual == Helper.Acciones.Agregar)
                {
                    NuevoItem();
                }
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

        private void ucPeriodo_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uneNotas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ugData.Focus();
        }

        private void ultraPanel1_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void ubNuevo_Click(object sender, EventArgs e)
        {
        }

        private void ucCliente_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucCliente_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["razon_social"].Value.ToString().Trim());
        }


        private void ucConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucConcepto.Value != null)
                {
                    string sVal = ucConcepto.Value.ToString();
                    ucConcepto.Value = null;
                    ucConcepto.Value = sVal.PadRight(5,' ');
                }
                upOption.Focus();
            }
                //SelectNextControl(ucConcepto, true, true, true, true);
        }

        private void ucConcepto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucConcepto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_gasto"].Value.ToString().Trim(), e.Row.Cells["Descripcion"].Value.ToString().Trim());
        }

        

        private void ucOficina_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ugData_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            string id_servicio = e.Row.Cells["id_servicio"].Value.ToString();
            tbl_servicios _srv = (new ServicioBL(ref db)).ListarPorId(id_servicio);
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _srv.id_servicio.Trim(), _srv.Nombre_largo.Trim());
        }


        private void ultraPanel2_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void uccFechaNac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                uteDescripcion.Focus();
        }

        private void ucConcepto_KeyUp(object sender, KeyEventArgs e)
        {
            List<int> IgnoreKeys = new List<int>();
            IgnoreKeys.Add((int)Keys.Left);
            IgnoreKeys.Add((int)Keys.Right);
            IgnoreKeys.Add((int)Keys.Up);
            IgnoreKeys.Add((int)Keys.Down);
            IgnoreKeys.Add((int)Keys.Escape);
            IgnoreKeys.Add((int)Keys.Enter);

            if (!IgnoreKeys.Contains((int)e.KeyCode))
            {
                int iSelLoc = ucConcepto.Textbox.SelectionStart;
                if (!ucConcepto.IsDroppedDown)
                {
                    if (ucConcepto.Text.Length > 0)
                    {

                        ucConcepto.ToggleDropdown();
                        ucConcepto.Textbox.SelectionLength = 0;
                        ucConcepto.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucConcepto.Text.Trim() != string.Empty)
                {
                    ucConcepto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucConcepto.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucConcepto.Text + "*");
                }
            }
        }

        private void ucConcepto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucConcepto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void upOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(upOption, true, true, true, true);
        }   
           
    }
}

