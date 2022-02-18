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
using System.Threading;

namespace TiempoEnProceso.Forms
{
    public partial class frmCreditosAplicaciones : Form
    {
        private bool isProcessRunning = false;

        public tbl_creditos_aplicaciones Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }
        ValueList gastosVL;
        ValueList empleadoVL;
        ValueList entidadVL;
        ValueList entidad2VL;

        List<tbl_aplicacion_tep> lstAplicacionTep = new List<tbl_aplicacion_tep>();
        List<tbl_aplicacion_gts_admon> lstAplicacionGts = new List<tbl_aplicacion_gts_admon>();
        List<tbl_anticipo_preliminar> lstAnticipo= new List<tbl_anticipo_preliminar>();
        List<tbl_anticipo_preliminar> lstFacturas = new List<tbl_anticipo_preliminar>();


        private TEPEntities db;

        public frmCreditosAplicaciones()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
            //db.Database.Log = TiempoEnProcesoHelper.Helper.Log;
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Grabar":    // ButtonTool
                    if (Grabar())
                    {
                        Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
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
            if (!ValidataControlesHeader()) return false;

            return true;

        }

        private bool ValidataControlesHeader()
        {
            LimpiaEspacios();

            if (!uvValidador.Validate("reqVal", false, true).IsValid)
                return false;

            if (ucCliente.Value != null &&
                ucCliente.SelectedRow == null)
            {
                MessageBox.Show("Seleccion de Cliente Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ucProducto.Value != null &&
                ucProducto.SelectedRow == null)
            {
                MessageBox.Show("Seleccion de Producto Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ucJob.Value != null &&
                ucJob.SelectedRow == null)
            {
                MessageBox.Show("Seleccion de Job Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        public void CargarItem(int _id_transaccion)
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Item = db.tbl_creditos_aplicaciones.FirstOrDefault(d => d.id_transaccion== _id_transaccion);
            if (Item != null)
            {
                lstAplicacionTep = db.tbl_aplicacion_tep.Where(d => d.id_transaccion == _id_transaccion).ToList<tbl_aplicacion_tep>();

                CargaCombos();
                AsignaCampos();
            }
            else
            {
                Item = new tbl_creditos_aplicaciones();
                lstAplicacionTep = new List<tbl_aplicacion_tep>();

                AsignaCampos();
            }
        }

        private void AsignaCampos()
        {
            ugData.DataSource = lstAplicacionTep;
        }

        public void CargaCombos()
        {
            gastosVL = new ValueList();
            empleadoVL = new ValueList();
            entidadVL = new ValueList();
            entidad2VL = new ValueList();

            CargaClientes();

            CargaProducto();

            List<tbl_empleados> lstEmp = new List<tbl_empleados>();
            (new EmpleadosBL()).ListarxPais(false).ForEach(d =>
            {
                if (d.id_oficina == Helper.Oficina)
                {
                    lstEmp.Add(new tbl_empleados()
                    {
                        id_empleado = d.id_empleado,
                        id_oficina = d.id_oficina,
                        Nombres = string.Format("{0} {1}", d.Nombres.Trim(), d.apellidos.Trim()),
                        cuota_facturacion_local = d.cuota_facturacion_local,
                        cuota_facturacion_interamerica = d.cuota_facturacion_interamerica,
                        apellidos = d.apellidos
                    });
                }
                empleadoVL.ValueListItems.Add(new ValueListItem(d.id_empleado, string.Format("{0}-{1} {2}", d.id_empleado.Trim(), d.Nombres.Trim(), d.apellidos.Trim())));
            });

            ucEmpleado.DataSource = lstEmp;

            
            List<tbl_gastos_administrativos> lstGts = new List<tbl_gastos_administrativos>();
            (new GastosAdmBL()).Listar().ForEach(d =>
            {
                lstGts.Add(new tbl_gastos_administrativos()
                {
                    id_gasto = d.id_gasto,
                    Descripcion = d.Descripcion
                });
                gastosVL.ValueListItems.Add(new ValueListItem(d.id_gasto, string.Format("{0}-{1}", d.id_gasto.Trim(), d.Descripcion.Trim())));
            });

            ucGasto.DataSource = lstGts;

            (new EntidadLegalBL()).Listar().Where(d => d.id_oficina == Helper.Oficina).ToList<tbl_entidad_legal>().ForEach(d =>
                {
                    entidadVL.ValueListItems.Add(new ValueListItem(d.id_entidad, string.Format("{0}-{1}", d.id_entidad.Trim(), d.Razon_social.Trim())));
                    entidad2VL.ValueListItems.Add(new ValueListItem(d.id_entidad, string.Format("{0}-{1}", d.id_entidad.Trim(), d.Razon_social.Trim())));
                });
        }

        private void CargaProducto()
        {
            List<ServicioEN> lstServ = new List<ServicioEN>();
            var query = (from c in db.tbl_servicios
                         orderby c.id_servicio
                         select new { id_servicio = c.id_servicio, Nombre_largo = c.Nombre_largo }).ToList();

            query.ForEach(_srv =>
                lstServ.Add(new ServicioEN()
                {
                    id_servicio = _srv.id_servicio,
                    Nombre_largo = _srv.Nombre_largo
                }));

            ucProducto.DataSource = lstServ;
        }
        private void CargaJobs()
        {
            if (ucCliente.Value != null &&
                ucProducto.Value != null)
            {
                string _cliente = ucCliente.Value.ToString();
                string _producto = ucProducto.Value.ToString();

                List<JobsEN> lstJobs = new List<JobsEN>();

                var query = (from t in db.tbl_trabajos
                            join s in db.tbl_servicios on t.id_servicio equals s.id_servicio
                            where s.id_servicio == _producto && t.estado == 0 &&
                                  t.id_oficina == Helper.Oficina && t.id_cliente == _cliente
                                  orderby t.descripcion
                            select new { id_job = t.id_job, descripcion = t.descripcion }).ToList();

                query.ForEach(item =>
                    lstJobs.Add(new JobsEN() { id_job = item.id_job, descripcion = item.descripcion }));

                ucJob.DataSource = lstJobs;
            }
        }   
        private void CargaClientes()
        {
            
            List<ClienteEN> lstCliente = new List<ClienteEN>();
            var query = (from c in db.tbl_clientes
                        from p in db.tbl_oficina
                            .Where(p=> p.id_pais == c.id_pais && p.id_oficina == Helper.Oficina)
                        from g in db.tbl_grupos
                            .Where(g => g.id_grupo == c.id_grupo).DefaultIfEmpty()
                        from i in db.tbl_industrias
                            .Where(i => i.id_industria == c.id_industria).DefaultIfEmpty()
                        orderby c.id_cliente
                        select new { id_cliente = c.id_cliente, Razon_social = c.Razon_Social.Trim() + "; Grupo: " + (g == null ? "" : g.nombre.Trim()) + " Industria: " + i.nombre.Trim()}).ToList();

            query.ForEach(item =>
                lstCliente.Add(new ClienteEN() { id_cliente = item.id_cliente, razon_social = item.Razon_social}));

            ucCliente.DataSource = lstCliente;
        }


        private bool Grabar()
        {
            try
            {
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
            bool bExiste = false;

            tbl_oficina _tb = Helper.OficinaActiva as tbl_oficina;
            tbl_correlativos _correl = db.tbl_correlativos.FirstOrDefault(d => d.tabla == "tbl_creditos_aplicaciones");
            decimal dIDTran = _correl.correlativo.Value + 1;
           
            if (!bExiste)
            {
                Item = new tbl_creditos_aplicaciones();
                Item.id_cliente = ucCliente.Value.ToString();
                Item.id_job = ucJob.Value.ToString();
                Item.id_oficina = Helper.Oficina;
                Item.id_transaccion = dIDTran;
                Item.periodo_tep = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
                Item.realizado_por = Helper.usuario;

                Item.realizacion_gastos = Convert.ToDecimal(uneRealizaGastos.Value);
                Item.realizacion_honorarios = Convert.ToDecimal(uneRealizaHono.Value);
                db.tbl_creditos_aplicaciones.Add(Item);

                _correl.correlativo = dIDTran;
                db.Entry<tbl_correlativos>(_correl).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();            

            foreach (UltraGridRow _detR in ugData.Rows)
            {
                tbl_aplicacion_tep _det = _detR.ListObject as tbl_aplicacion_tep;
                if (_det.id_transaccion == 0)
                {
                    _det.id_oficina0 = Helper.Oficina;
                    _det.id_transaccion = Item.id_transaccion;
                    db.tbl_aplicacion_tep.Add(_det);
                }
            }

            foreach (UltraGridRow _detR in ugGtsAdmon.Rows)
            {
                tbl_aplicacion_gts_admon _det = _detR.ListObject as tbl_aplicacion_gts_admon;
                if (_det.id_transaccion == 0)
                {
                    _det.id_transaccion = Item.id_transaccion;
                    db.tbl_aplicacion_gts_admon.Add(_det);
                }
            }

            decimal iLinea = 1;
            iLinea = db.tbl_anticipo_preliminar.Max(d => d.linea) + 1;

            foreach (UltraGridRow _detR in ugAnticipos.Rows)
            {
                tbl_anticipo_preliminar _det = _detR.ListObject as tbl_anticipo_preliminar;
                if (_det.id_transaccion == 0)
                {
                    _det.linea = iLinea++;
                    _det.id_transaccion = Item.id_transaccion;
                    _det.preliminar = 0;
                    db.tbl_anticipo_preliminar.Add(_det);
                }
            }

            foreach (UltraGridRow _detR in ugFacturas.Rows)
            {
                tbl_anticipo_preliminar _det = _detR.ListObject as tbl_anticipo_preliminar;
                if (_det.id_transaccion == 0)
                {
                    _det.linea = iLinea++;
                    _det.id_transaccion = Item.id_transaccion;
                    _det.anticipo = 0;
                    db.tbl_anticipo_preliminar.Add(_det);
                }
            }



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
            ucCliente.Value = null;
            ucJob.Value = null;
            ucProducto.Value = null;
            lstAplicacionTep.Clear();
            ugData.DataBind();

            lstAplicacionGts.Clear();
            ugGtsAdmon.DataBind();

            lstAnticipo.Clear();
            ugAnticipos.DataBind();

            lstFacturas.Clear();
            ugFacturas.DataBind();

            ucCliente.Focus();
        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraCombo>(this.ultraPanel2).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraButton>(this.ultraPanel2).ForEach(p => p.Enabled = Enable);
        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);
            Helper.SetUltraComboWidth(this);

            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

            LoadData();       

            if (AccionActual == Helper.Acciones.Agregar)
            {
                uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);

                LoadValues();                

                NuevoItem();
            }
        }

        private void LoadValues()
        {
            DialogProcess processDialog = new DialogProcess("Cargando valores...");
            Thread backgroundThread = new Thread(
                new ThreadStart(() =>
                {
                    isProcessRunning = true;
                    AssignValues();

                    // No need to reset the progress since we are closing the dialog
                    processDialog.BeginInvoke(new Action(() => processDialog.Close()));

                    isProcessRunning = false;
                }
            ));
            backgroundThread.Start();

            processDialog.ShowDialog();     
        }

        private void AssignValues()
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            utePeriodo.Value = _oficina.periodo_proceso;
            utePeriodoB.Value = (new PeriodoBL()).ListarPorId(_oficina.periodo_proceso);

            ugData.DataSource = lstAplicacionTep;
            ugAnticipos.DataSource = lstAnticipo;
            ugFacturas.DataSource = lstFacturas;
            ugGtsAdmon.DataSource = lstAplicacionGts;
        }

        private void LoadData()
        {
            DialogProcess processDialog = new DialogProcess("Cargando datos desde Base de Datos...");
            Thread backgroundThread = new Thread(
                new ThreadStart(() =>
                {
                    isProcessRunning = true;
                    CargaCombos();

                    // No need to reset the progress since we are closing the dialog
                    processDialog.BeginInvoke(new Action(() => processDialog.Close()));

                    isProcessRunning = false;
                }
            ));
            backgroundThread.Start();

            processDialog.ShowDialog();     
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
                if (ucCliente.Value != null)
                {
                    string sVal = ucCliente.Value.ToString();
                    ucCliente.Value = null;
                    ucCliente.Value = sVal.PadRight(10);
                }
                SelectNextControl(ucCliente, true, true, true, true);
            }
        }

        private void ucConcepto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucConcepto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_cliente"].Value.ToString().Trim(), e.Row.Cells["razon_social"].Value.ToString().Trim());
        }        

        private void ucOficina_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ugData_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key == "horas")
            {
                e.Cell.Row.Cells["horas_reporte"].Activation = Activation.NoEdit;
                if (Convert.ToDecimal(e.NewValue) > 0)
                {
                    e.Cell.Row.Cells["horas_reporte"].Activation = Activation.AllowEdit;
                   
                }
                
            }
            
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_empleado"].ValueList = empleadoVL;
            if (!e.Layout.Bands[0].Summaries.Exists("Sumgastos"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["gastos"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumgastos", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }

            if (!e.Layout.Bands[0].Summaries.Exists("Sumhoras"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["horas"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumhoras", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }
            if (!e.Layout.Bands[0].Summaries.Exists("Sumhonorarios"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["honorarios"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumhonorarios", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }
            /*if (!e.Layout.Bands[0].Summaries.Exists("Sumgastos_reporte"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["gastos_reporte"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumgastos_reporte", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }*/

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells;
            e.Layout.Override.SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["horas_reporte"].Activation = Activation.NoEdit;
            if (e.Row.Cells["horas"].Value != null &&
                Convert.ToDecimal(e.Row.Cells["horas"].Value) > 0)
            {
                e.Row.Cells["horas_reporte"].Activation = Activation.AllowEdit;
                   
            }
        }


        private void ultraPanel2_PaintClient(object sender, PaintEventArgs e)
        {

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
                int iSelLoc = ucCliente.Textbox.SelectionStart;
                if (!ucCliente.IsDroppedDown)
                {
                    if (ucCliente.Text.Length > 0)
                    {

                        ucCliente.ToggleDropdown();
                        ucCliente.Textbox.SelectionLength = 0;
                        ucCliente.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucCliente.Text.Trim() != string.Empty)
                {
                    ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucCliente.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucCliente.Text + "*");
                }
            }
        }

        private void ucConcepto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void ugGtsAdmon_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
        }

        private void ugFacturas_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
        }

        private void ugAnticipos_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
        }

        private void ugGtsAdmon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_gasto"].ValueList = gastosVL;

            if (!e.Layout.Bands[0].Summaries.Exists("Sumvalor"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["valor"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumvalor", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }

            if (!e.Layout.Bands[0].Summaries.Exists("Sumvalor_docto"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["valor_docto"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumvalor_docto", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells;
            e.Layout.Override.SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void ugFacturas_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_entidad"].ValueList = entidad2VL;
            if (!e.Layout.Bands[0].Summaries.Exists("Sumpreliminar"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["preliminar"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumpreliminar", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }

            if (!e.Layout.Bands[0].Summaries.Exists("Sumpreliminar_docto"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["preliminar_docto"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumpreliminar_docto", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells;
            e.Layout.Override.SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void ugAnticipos_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_entidad"].ValueList = entidadVL;
            if (!e.Layout.Bands[0].Summaries.Exists("Sumvalor"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["anticipo"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumvalor", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }

            if (!e.Layout.Bands[0].Summaries.Exists("Sumanticipo_docto"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["anticipo_docto"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sumanticipo_docto", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N2}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells;
            e.Layout.Override.SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void ucProducto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["nombre_largo"].Value.ToString().Trim());
        }

        private void ucProducto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucProducto.Value != null)
                {
                    string sVal = ucProducto.Value.ToString();
                    ucProducto.Value = null;
                    ucProducto.Value = sVal.PadRight(4, ' ');
                }
                SelectNextControl(ucProducto, true, true, true, true);
            }
        }

        private void ucProducto_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucProducto.Textbox.SelectionStart;
                if (!ucProducto.IsDroppedDown)
                {
                    if (ucProducto.Text.Length > 0)
                    {

                        ucProducto.ToggleDropdown();
                        ucProducto.Textbox.SelectionLength = 0;
                        ucProducto.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucProducto.Text.Trim() != string.Empty)
                {
                    ucProducto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucProducto.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucProducto.Text + "*");
                }
            }
        }

        private void ucProducto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucProducto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucJob_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucJob.Value != null)
                {
                    string sVal = ucJob.Value.ToString();
                    ucJob.Value = null;
                    ucJob.Value = sVal.PadRight(10, ' ');
                }

                SelectNextControl(ucJob, true, true, true, true);
            }
        }

        private void ucJob_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_job"].Value.ToString().Trim(), e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucJob_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucJob.Textbox.SelectionStart;
                if (!ucJob.IsDroppedDown)
                {
                    if (ucJob.Text.Length > 0)
                    {

                        ucJob.ToggleDropdown();
                        ucJob.Textbox.SelectionLength = 0;
                        ucJob.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucJob.Text.Trim() != string.Empty)
                {
                    ucJob.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucJob.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucJob.Text + "*");
                }
            }
        }

        private void ucJob_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucJob.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ubConsultar_Click(object sender, EventArgs e)
        {
            if (!ValidataControlesHeader()) return;
            string _cliente = ucCliente.Value.ToString();
            string _job = ucJob.Value.ToString();

            lstAplicacionGts.Clear();
            lstAplicacionTep.Clear();
            lstFacturas.Clear();
            lstAnticipo.Clear();

            ugAnticipos.DataBind();
            ugData.DataBind();
            ugFacturas.DataBind();
            ugGtsAdmon.DataBind();
            
            //Tbl_aplicacion_tep
            IQueryable query = from t in db.tbl_saldo_tep
                        where (t.gastos!= 0 || t.horas!=0 || t.honorarios!=0) &&
                               t.id_oficina0 == Helper.Oficina && t.id_cliente== _cliente && t.id_job ==_job
                        select t;

            query.Cast <tbl_saldo_tep>().ToList().ForEach(
                d => lstAplicacionTep.Add(
                    new tbl_aplicacion_tep()
                    {
                        id_oficina = d.id_oficina,
                        id_empleado = d.id_empleado,
                        horas = d.horas,
                        honorarios = d.honorarios,
                        gastos = d.gastos,
                        horas_reporte = d.horas,
                        honorarios_reporte = d.honorarios,
                        gastos_reporte = d.gastos
                    }));


            IQueryable queryGts = from t in db.tbl_saldo_gastos
                    where t.valor != 0 &&  t.id_oficina == Helper.Oficina && t.id_cliente == _cliente && t.id_job == _job
                    select t;

            queryGts.Cast <tbl_saldo_gastos>().ToList().ForEach(
                d => lstAplicacionGts.Add(
                    new tbl_aplicacion_gts_admon()
                    {
                        id_gasto = d.id_gasto,
                        valor = d.valor,
                        valor_docto = d.valor
                    }));

            IQueryable queryFact = from t in db.tbl_cuenta_corriente
                            where t.tipo_documento == "FAC" && t.estado != 2 && t.factura_preliminar != 0 &&
                                  t.id_oficina == Helper.Oficina && t.id_cliente == _cliente && t.id_job == _job
                            select t;

            queryFact.Cast<tbl_cuenta_corriente>().ToList().ForEach(
                d => lstFacturas.Add(new tbl_anticipo_preliminar()
                {
                    id_oficina = d.id_oficina,
                    id_entidad = d.id_entidad,
                    tipo_documento = d.tipo_documento,
                    numero_documento = d.numero_documento,
                    preliminar = d.factura_preliminar,
                    linea = d.linea.Value,
                    preliminar_docto = d.factura_preliminar
                }));

            IQueryable queryAnt = from t in db.tbl_cuenta_corriente
                            where t.tipo_documento == "FAC" && t.estado != 2 && t.anticipo_aplicar != 0 &&
                                  t.id_oficina == Helper.Oficina && t.id_cliente == _cliente && t.id_job == _job
                            select t;

            queryAnt.Cast<tbl_cuenta_corriente>().ToList().ForEach(
                d => lstAnticipo.Add(new tbl_anticipo_preliminar()
                {
                    id_oficina = d.id_oficina,
                    id_entidad = d.id_entidad,
                    tipo_documento = d.tipo_documento,
                    numero_documento = d.numero_documento,
                    anticipo_docto = d.anticipo_aplicar,
                    linea = d.linea.Value,
                    anticipo = d.anticipo_aplicar
                }));

            ugAnticipos.DataBind();
            ugData.DataBind();
            ugFacturas.DataBind();
            ugGtsAdmon.DataBind();
        }

        private void ucCliente_ValueChanged(object sender, EventArgs e)
        {
            CargaJobs();
        }

        private void ucProducto_ValueChanged(object sender, EventArgs e)
        {
            CargaJobs();
        }

        private void ucProducto_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void ultraPanel6_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void ucEmpleado_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucEmpleado.Value != null)
                {
                    string sVal = ucEmpleado.Value.ToString();
                    ucEmpleado.Value = null;
                    ucEmpleado.Value = sVal.PadRight(10);
                }
                SelectNextControl(ucEmpleado, true, true, true, true);
            }
        }

        private void ucEmpleado_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucEmpleado.Textbox.SelectionStart;
                if (!ucEmpleado.IsDroppedDown)
                {
                    if (ucEmpleado.Text.Length > 0)
                    {

                        ucEmpleado.ToggleDropdown();
                        ucEmpleado.Textbox.SelectionLength = 0;
                        ucEmpleado.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucEmpleado.Text.Trim() != string.Empty)
                {
                    ucEmpleado.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucEmpleado.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucEmpleado.Text + "*");
                }
            }
        }

        private void ucEmpleado_ValueChanged(object sender, EventArgs e)
        {
            CalculaHonorarioEmpleado();
        }

        private void CalculaHonorarioEmpleado()
        {
            if (ucEmpleado.Value != null &&
                ucEmpleado.SelectedRow != null &&
                uneHorasEmpleado.Value!=null )
            {
                tbl_empleados _emp = ucEmpleado.SelectedRow.ListObject as tbl_empleados;
                decimal dHoras = uneHorasEmpleado.Value== null? 0 : Convert.ToDecimal(uneHorasEmpleado.Value);
                uneHonorariosEmpleado.Value = _emp.cuota_facturacion_local * dHoras;
            }
        }

        private void ucEmpleado_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucEmpleado.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void uneHorasEmpleado_ValueChanged(object sender, EventArgs e)
        {
            CalculaHonorarioEmpleado();
        }

        private void ubAgregarData_Click(object sender, EventArgs e)
        {
            if (ucEmpleado.Value == null)
            {
                MessageBox.Show("Selección de Empleado Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ucEmpleado.Value != null &&
                ucEmpleado.SelectedRow==null)
            {
                MessageBox.Show("Selección de Empleado Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToDecimal(uneHorasEmpleado.Value) + Convert.ToDecimal(uneGastosEmpleado.Value) == 0)
            {
                MessageBox.Show("Monto Horas/Gastos Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            /*string _emp = ucEmpleado.Value.ToString();
            if (lstAplicacionTep.Any(d => d.id_empleado == _emp))
            {
                MessageBox.Show("Selección de Empleado Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/

            lstAplicacionTep.Add(new tbl_aplicacion_tep()
            {
                id_oficina = (ucEmpleado.SelectedRow.ListObject as tbl_empleados).id_oficina,
                id_oficina0 = (ucEmpleado.SelectedRow.ListObject as tbl_empleados).id_oficina,
                id_empleado = ucEmpleado.Value.ToString(),
                horas = Convert.ToDecimal(uneHorasEmpleado.Value),
                honorarios = Convert.ToDecimal(uneHonorariosEmpleado.Value),
                gastos = Convert.ToDecimal(uneGastosEmpleado.Value),
                horas_reporte = 0,
                honorarios_reporte = 0,
                gastos_reporte = 0
            });

            ugData.DataBind();

            ucEmpleado.Value = null;
            uneHorasEmpleado.Value = null;
            uneGastosEmpleado.Value = null;

            ucEmpleado.Focus();
        }

        private void ubEliminaData_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow == null)
                return;

            lstAplicacionTep.Remove(ugData.ActiveRow.ListObject as tbl_aplicacion_tep);

            ugData.DataBind();
        }

        private void ucEmpleado_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1} {2}", e.Row.Cells["id_empleado"].Value.ToString().Trim(), e.Row.Cells["Nombres"].Value.ToString().Trim(),e.Row.Cells["apellidos"].Value.ToString());
        }

        private void uneHorasEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneHorasEmpleado, true, true, true, true);
        }

        private void uneGastosEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneGastosEmpleado, true, true, true, true);
        }

        private void ucGasto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_gasto"].Value.ToString().Trim(), e.Row.Cells["Descripcion"].Value.ToString().Trim());
        }

        private void ucGasto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucGasto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucGasto, true, true, true, true);
        }

        private void ucGasto_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucGasto.Textbox.SelectionStart;
                if (!ucGasto.IsDroppedDown)
                {
                    if (ucGasto.Text.Length > 0)
                    {

                        ucGasto.ToggleDropdown();
                        ucGasto.Textbox.SelectionLength = 0;
                        ucGasto.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucGasto.Text.Trim() != string.Empty)
                {
                    ucGasto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucGasto.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucGasto.Text + "*");
                }
            }
        }

        private void ucGasto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucGasto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ubGtsAdmon_Click(object sender, EventArgs e)
        {
            if (ucGasto.Value == null)
            {
                MessageBox.Show("Selección de Gasto Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ucGasto.Value != null &&
                ucGasto.SelectedRow == null)
            {
                MessageBox.Show("Selección de Gasto Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToDecimal(uneGtsValor.Value) == 0)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string _gts = ucGasto.Value.ToString();
            if (lstAplicacionGts.Any(d => d.id_gasto == _gts))
            {
                MessageBox.Show("Selección de Gasto Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lstAplicacionGts.Add(new tbl_aplicacion_gts_admon()
            {
                id_gasto = ucGasto.Value.ToString(),
                valor = Convert.ToDecimal(uneGtsValor.Value),
                valor_docto = 0
            });

            ugGtsAdmon.DataBind();

            ucGasto.Value = null;
            uneGtsValor.Value = null;

            ucGasto.Focus();
        }

        private void ubEliminaGtsAdmon_Click(object sender, EventArgs e)
        {
            if (ugGtsAdmon.ActiveRow == null)
                return;

            lstAplicacionGts.Remove(ugGtsAdmon.ActiveRow.ListObject as tbl_aplicacion_gts_admon);

            ugGtsAdmon.DataBind();            
        }

        private void ugData_SummaryValueChanged(object sender, SummaryValueChangedEventArgs e)
        {
            CalculaTotales();
        }

        private void CalculaTotales()
        {
            uneTotalCreditos.Value = Convert.ToDecimal(ugData.Rows.SummaryValues["Sumhonorarios"].Value) +
                                     Convert.ToDecimal(ugData.Rows.SummaryValues["Sumgastos"].Value) +
                                     Convert.ToDecimal(ugGtsAdmon.Rows.SummaryValues["Sumvalor"].Value);

            uneTotalAplicaciones.Value = Convert.ToDecimal(ugFacturas.Rows.SummaryValues["Sumpreliminar"].Value) +
                                         Convert.ToDecimal(ugAnticipos.Rows.SummaryValues["Sumvalor"].Value);

            decimal dGastos = Convert.ToDecimal(ugData.Rows.SummaryValues["Sumgastos"].Value) + Convert.ToDecimal(ugGtsAdmon.Rows.SummaryValues["Sumvalor"].Value);
            if (Convert.ToDecimal(uneTotalAplicaciones.Value) > dGastos)
                uneRealizaGastos.Value = dGastos;
            else
            {
                if (Convert.ToDecimal(uneTotalAplicaciones.Value) != 0)
                    uneRealizaGastos.Value = uneTotalAplicaciones.Value;
                else
                    uneRealizaGastos.Value = dGastos * -1;
            }

            if (Convert.ToDecimal(uneTotalAplicaciones.Value) != 0)
                uneRealizaHono.Value = Convert.ToDecimal(uneTotalAplicaciones.Value) - Convert.ToDecimal(uneRealizaGastos.Value);
            else
                uneRealizaHono.Value = (Convert.ToDecimal(uneTotalCreditos.Value) + Convert.ToDecimal(uneRealizaGastos.Value)) * -1;

            unePorcHonorario.Value = Convert.ToDecimal(uneTotalCreditos.Value) - Convert.ToDecimal(uneRealizaGastos.Value) == 0 ? 0 : Convert.ToDecimal(uneRealizaHono.Value) / (Convert.ToDecimal(uneTotalCreditos.Value) - Convert.ToDecimal(uneRealizaGastos.Value)) * 100;

            unePorcGastos.Value = dGastos == 0 ? 0 : (Convert.ToDecimal(uneRealizaGastos.Value) / dGastos) * 100;

            //if (Convert.ToDecimal(uneTotalAplicaciones.Value)!= 0)

        }

        private void ugGtsAdmon_SummaryValueChanged(object sender, SummaryValueChangedEventArgs e)
        {
            CalculaTotales();
        }

        private void ugFacturas_SummaryValueChanged(object sender, SummaryValueChangedEventArgs e)
        {
            CalculaTotales();
        }

        private void ugAnticipos_SummaryValueChanged(object sender, SummaryValueChangedEventArgs e)
        {
            CalculaTotales();
        }

        private void uneGtsValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneGtsValor, true, true, true, true);
        }

        private void ucCliente_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void ugData_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "horas")
            {
                if (e.Cell.Activation == Activation.AllowEdit)
                {
                    if (e.Cell.Row.Cells["id_empleado"].Value != null)
                    {
                        string id_empleado = e.Cell.Row.Cells["id_empleado"].Value.ToString();
                        tbl_empleados _emp = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == id_empleado);
                        decimal dHoras = e.Cell.Value == null ? 0 : Convert.ToDecimal(e.Cell.Value);
                        e.Cell.Row.Cells["honorarios"].Value = _emp.cuota_facturacion_local * dHoras;
                    }
                }
            }
        }

        private void ugData_KeyDown(object sender, KeyEventArgs e)
        {
            string sCol = ugData.ActiveCell != null ? ugData.ActiveCell.Column.Key : string.Empty;

            switch (e.KeyCode)
            {
                case Keys.Enter:

                    if (ugData.ActiveRow != null)
                    {
                        if (ugData.ActiveCell != null)
                        {
                            if (ugData.ActiveCell.Column.Key == "gastos")
                            {
                                if (ugData.ActiveRow.Index == ugData.Rows.Count - 1)
                                    ugData.PerformAction(UltraGridAction.FirstRowInBand);
                                else
                                    ugData.PerformAction(UltraGridAction.BelowRow);
                            }
                            else
                                ugData.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        else
                            ugData.PerformAction(UltraGridAction.FirstCellInRow);
                    }
                    break;
                case Keys.Up:
                    ugData.PerformAction(UltraGridAction.ExitEditMode);
                    if (ugData.ActiveRow.Index > 0)
                    {
                        ugData.PerformAction(UltraGridAction.AboveRow);
                        ugData.PerformAction(UltraGridAction.ActivateCell);
                        ugData.PerformAction(UltraGridAction.NextCellByTab);
                        ugData.PerformAction(UltraGridAction.NextCellByTab);
                        ugData.PerformAction(UltraGridAction.NextCellByTab);
                        ugData.PerformAction(UltraGridAction.NextCellByTab);
                        if (sCol == "honorarios")
                            ugData.PerformAction(UltraGridAction.NextCellByTab);
                        if (sCol == "gastos")
                        {
                            ugData.PerformAction(UltraGridAction.NextCellByTab);
                            ugData.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        ugData.PerformAction(UltraGridAction.EnterEditMode);


                    }
                    e.Handled = true;
                    break;
                case Keys.Down:
                    ugData.PerformAction(UltraGridAction.ExitEditMode);
                    if (ugData.ActiveRow.Index < ugData.Rows.Count-1)
                    {
                        ugData.PerformAction(UltraGridAction.BelowRow);
                        ugData.PerformAction(UltraGridAction.ActivateCell);
                        ugData.PerformAction(UltraGridAction.NextCellByTab);
                        ugData.PerformAction(UltraGridAction.NextCellByTab);
                        ugData.PerformAction(UltraGridAction.NextCellByTab);
                        ugData.PerformAction(UltraGridAction.NextCellByTab);
                        if (sCol == "honorarios")
                            ugData.PerformAction(UltraGridAction.NextCellByTab);

                        if (sCol == "gastos")
                        {
                            ugData.PerformAction(UltraGridAction.NextCellByTab);
                            ugData.PerformAction(UltraGridAction.NextCellByTab);
                        }

                        ugData.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    e.Handled = true;
                    break;
            }
        }

        private void ugGtsAdmon_KeyDown(object sender, KeyEventArgs e)
        {
            string sCol = ugGtsAdmon.ActiveCell != null ? ugGtsAdmon.ActiveCell.Column.Key : string.Empty;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (ugGtsAdmon.ActiveRow != null)
                    {
                        if (ugGtsAdmon.ActiveCell != null)
                        {
                            if (ugGtsAdmon.ActiveCell.Column.Key == "valor")
                            {
                                if (ugGtsAdmon.ActiveRow.Index == ugData.Rows.Count - 1)
                                    ugGtsAdmon.PerformAction(UltraGridAction.FirstRowInBand);
                                else
                                    ugGtsAdmon.PerformAction(UltraGridAction.BelowRow);
                            }
                            else
                                ugGtsAdmon.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        else
                            ugGtsAdmon.PerformAction(UltraGridAction.FirstCellInRow);
                    }
                    break;

                case Keys.Up:
                    ugGtsAdmon.PerformAction(UltraGridAction.ExitEditMode);
                    if (ugGtsAdmon.ActiveRow.Index > 0)
                    {
                        ugGtsAdmon.PerformAction(UltraGridAction.AboveRow);
                        ugGtsAdmon.PerformAction(UltraGridAction.ActivateCell);
                        ugGtsAdmon.PerformAction(UltraGridAction.NextCellByTab);
                        ugGtsAdmon.PerformAction(UltraGridAction.NextCellByTab);
                        ugGtsAdmon.PerformAction(UltraGridAction.EnterEditMode);


                    }
                    e.Handled = true;
                    break;
                case Keys.Down:
                    ugGtsAdmon.PerformAction(UltraGridAction.ExitEditMode);
                    if (ugGtsAdmon.ActiveRow.Index < ugGtsAdmon.Rows.Count - 1)
                    {
                        ugGtsAdmon.PerformAction(UltraGridAction.BelowRow);
                        ugGtsAdmon.PerformAction(UltraGridAction.ActivateCell);
                        ugGtsAdmon.PerformAction(UltraGridAction.NextCellByTab);
                        ugGtsAdmon.PerformAction(UltraGridAction.NextCellByTab);
                        ugGtsAdmon.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    e.Handled = true;
                    break;

            }

        }

        private void ugFacturas_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key == "preliminar")
            {
                if (e.NewValue != null)
                {
                    decimal dV = Convert.ToDecimal(e.NewValue);
                    if (dV != 0 &&
                        dV != Convert.ToDecimal(e.Cell.Row.Cells["preliminar_docto"].Value))
                    {
                        MessageBox.Show("No se puede ingresar valores diferentes a la factura o a cero", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }

                }
            }
        }

        private void ugFacturas_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (ugFacturas.ActiveRow != null)
                    {
                        if (ugFacturas.ActiveCell != null)
                        {
                            if (ugFacturas.ActiveCell.Column.Key == "preliminar")
                            {
                                if (ugFacturas.ActiveRow.Index == ugFacturas.Rows.Count - 1)
                                    ugFacturas.PerformAction(UltraGridAction.FirstRowInBand);
                                else
                                    ugFacturas.PerformAction(UltraGridAction.BelowRow);
                            }
                            else
                                ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        else
                            ugFacturas.PerformAction(UltraGridAction.FirstCellInRow);
                    }
                    break;
                case Keys.Up:
                    ugFacturas.PerformAction(UltraGridAction.ExitEditMode);
                    if (ugFacturas.ActiveRow.Index > 0)
                    {
                        ugFacturas.PerformAction(UltraGridAction.AboveRow);
                        ugFacturas.PerformAction(UltraGridAction.ActivateCell);
                        ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        ugFacturas.PerformAction(UltraGridAction.EnterEditMode);


                    }
                    e.Handled = true;
                    break;
                case Keys.Down:
                    ugFacturas.PerformAction(UltraGridAction.ExitEditMode);
                    if (ugFacturas.ActiveRow.Index < ugFacturas.Rows.Count - 1)
                    {
                        ugFacturas.PerformAction(UltraGridAction.BelowRow);
                        ugFacturas.PerformAction(UltraGridAction.ActivateCell);
                        ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        ugFacturas.PerformAction(UltraGridAction.NextCellByTab);
                        ugFacturas.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    e.Handled = true;
                    break;
            }
        }

        private void ugAnticipos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (ugAnticipos.ActiveRow != null)
                    {
                        if (ugAnticipos.ActiveCell != null)
                        {
                            if (ugAnticipos.ActiveCell.Column.Key == "anticipo")
                            {
                                if (ugAnticipos.ActiveRow.Index == ugAnticipos.Rows.Count - 1)
                                    ugAnticipos.PerformAction(UltraGridAction.FirstRowInBand);
                                else
                                    ugAnticipos.PerformAction(UltraGridAction.BelowRow);
                            }
                            else
                                ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        else
                            ugAnticipos.PerformAction(UltraGridAction.FirstCellInRow);
                    }
                    break;
                case Keys.Up:
                    ugAnticipos.PerformAction(UltraGridAction.ExitEditMode);
                    if (ugAnticipos.ActiveRow.Index > 0)
                    {
                        ugAnticipos.PerformAction(UltraGridAction.AboveRow);
                        ugAnticipos.PerformAction(UltraGridAction.ActivateCell);
                        ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        ugAnticipos.PerformAction(UltraGridAction.EnterEditMode);


                    }
                    e.Handled = true;
                    break;
                case Keys.Down:
                    ugAnticipos.PerformAction(UltraGridAction.ExitEditMode);
                    if (ugAnticipos.ActiveRow.Index < ugAnticipos.Rows.Count - 1)
                    {
                        ugAnticipos.PerformAction(UltraGridAction.BelowRow);
                        ugAnticipos.PerformAction(UltraGridAction.ActivateCell);
                        ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        ugAnticipos.PerformAction(UltraGridAction.NextCellByTab);
                        ugAnticipos.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    e.Handled = true;
                    break;
            }
        }

        private void ugAnticipos_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            if (e.Cell.Column.Key == "anticipo_docto")
            {
                if (e.NewValue != null)
                {
                    decimal dV = Convert.ToDecimal(e.NewValue);
                    if (dV > Convert.ToDecimal(e.Cell.Row.Cells["preliminar"].Value))
                    {
                        MessageBox.Show("No se puede ingresar valores mayores a la factura", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }

                }
            }
        }           
    }
}

