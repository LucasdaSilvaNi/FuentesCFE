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
    public partial class frmCapturaReporteTiempo : Form
    {
        public tbl_reportes_tiempo Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        List<tbl_detalle_cargable> lstD = new List<tbl_detalle_cargable>();
        List<tbl_no_cargables> lstN = new List<tbl_no_cargables>();

        ValueList oficinaVL;
        ValueList clienteVL;
        ValueList productoVL;
        ValueList servicioVL;
        ValueList jobVL;
        ValueList conceptoVL;


        private TEPEntities db;

        public frmCapturaReporteTiempo()
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

            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();
        }

        public void CargarItem()
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Item = db.tbl_reportes_tiempo.FirstOrDefault(d => d.id_empleado == Helper.usuario && d.periodo_tep_proceso == _oficina.periodo_proceso);
            if (Item != null)
            {
                lstD = db.tbl_detalle_cargable.Where(d => d.id_reporte == Item.id_reporte).ToList<tbl_detalle_cargable>();
                lstN = db.tbl_no_cargables.Where(d => d.id_reporte == Item.id_reporte).ToList<tbl_no_cargables>();

                CargaCombos();
                AsignaCampos();
            }
            else
                Item = new tbl_reportes_tiempo();
        }

        private void AsignaCampos()
        {
            ugData.DataSource = lstD;
            ugDataNo.DataSource = lstN;
        }

        public void CargaCombos()
        {
            clienteVL = new ValueList();
            oficinaVL = new ValueList();
            productoVL = new ValueList();
            jobVL = new ValueList();
            conceptoVL = new ValueList();

            IQueryable query = from emp in db.tbl_empleados
                        join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                        join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                        where emp.id_empleado == Helper.usuario
                        select ofi;
            List<OficinaEN> lO = new List<OficinaEN>();
            query.Cast<tbl_oficina>().ToList().ForEach(d => lO.Add(new OficinaEN()
            {
                id_oficina = d.id_oficina,
                id_pais = d.id_pais,
                Nombre = d.Nombre,
                periodo_proceso= d.periodo_proceso,
                Status=d.Status
            }));

            tbl_oficina _oficin = (Helper.OficinaActiva as tbl_oficina);
            string periodo = _oficin.Status == 0 ? (new PeriodoBL()).ListarSiguienteUno(_oficin.periodo_proceso).id_periodo : _oficin.periodo_proceso;//_oficina.periodo_proceso;
            string sPer = "01/" + new DateTime(Convert.ToInt32(periodo.Split('/')[1]), 7, 1).ToString("yyyy");

            empleadoENBindingSource.DataSource = (new EmpleadosBL(ref db)).ListarTodos(Helper.Oficina);

            clienteENBindingSource.DataSource = (new ClientesBL(ref db)).ListarTodo(Helper.Oficina);
            oficinaENBindingSource.DataSource = lO;//(new OficinaBL(ref db)).ListarTodos();
            conceptoENBindingSource.DataSource = (new ConceptosBL(ref db)).ListarTodos();
            periodoENBindingSource.DataSource = (new PeriodoBL()).ListarTodos(sPer) ;

            foreach (ClienteEN _cliente in (List<ClienteEN>)clienteENBindingSource.DataSource)
                clienteVL.ValueListItems.Add(new ValueListItem(_cliente.id_cliente, _cliente.razon_social));

            foreach (OficinaEN _oficina in (List<OficinaEN>)oficinaENBindingSource.DataSource)
                oficinaVL.ValueListItems.Add(new ValueListItem(_oficina.id_oficina, string.Format("{0}-{1}", _oficina.id_oficina, _oficina.Nombre)));

            foreach (ConceptoEN _concepto in (List<ConceptoEN>)conceptoENBindingSource.DataSource)
                conceptoVL.ValueListItems.Add(new ValueListItem(_concepto.id_concepto, string.Format("{0}-{1}", _concepto.id_concepto, _concepto.descripcion)));

            List<ServicioEN> lstA = new List<ServicioEN>();
            db.tbl_servicios.AsQueryable().ToList().ForEach(d => lstA.Add(new ServicioEN() { id_servicio = d.id_servicio, Nombre_largo = d.Nombre_largo }));
            servicioENBindingSource.DataSource = lstA;

        }


        private bool Grabar()
        {
            try
            {
                using (var dbTran = db.Database.BeginTransaction())
                {
                    ConstruyeItem();

                    /*if (AccionActual == Helper.Acciones.Agregar)
                        db.tbl_entidad_legal.Add(Item);*/


                    if (lstD.Count > 0)
                    {

                        DataSet ds = Helper.ToDataSet(lstD);

                        Utf8StringWriter wf = new Utf8StringWriter();
                        ds.Tables[0].Columns.Add("signo", typeof(int));
                        ds.Tables[0].Columns.Add("signoGastos", typeof(int));

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dr["signo"] = Convert.ToDecimal(dr["horas"]) < 0 ? 1 : 0;
                            dr["horas"] = Convert.ToDecimal(dr["horas"]) * (Convert.ToInt32(dr["signo"]) > 0 ? -1 : 1);

                            dr["signoGastos"] = Convert.ToDecimal(dr["gastos"]) < 0 ? 1 : 0;
                            dr["gastos"] = Convert.ToDecimal(dr["gastos"]) * (Convert.ToInt32(dr["signoGastos"]) > 0 ? -1 : 1);
                        }
                        
                        ds.Tables[0].WriteXml(wf);

                        db.Insert_Detalle_Cargable(wf.ToString());
                    }

                    if (lstN.Count > 0)
                    {
                        DataSet ds = Helper.ToDataSet(lstN);

                        Utf8StringWriter wf = new Utf8StringWriter();                       

                        ds.Tables[0].Columns.Add("signo", typeof(int));
                        ds.Tables[0].Columns.Add("signoGastos", typeof(int));

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dr["signo"] = Convert.ToDecimal(dr["horas"]) < 0 ? 1 : 0;
                            dr["horas"] = Convert.ToDecimal(dr["horas"]) * (Convert.ToInt32(dr["signo"]) > 0 ? -1 : 1);
                            
                        }
                        ds.Tables[0].WriteXml(wf);
                        db.Insert_Detalle_NoCargable(wf.ToString());
                    }

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
            /*if (bExiste = db.tbl_reportes_tiempo.Any(d => d.id_oficina == Helper.Oficina && d.id_empleado == Helper.usuario && d.periodo_tep_proceso == _tb.periodo_proceso))
                Item = db.tbl_reportes_tiempo.FirstOrDefault(d => d.id_oficina == Helper.Oficina && d.id_empleado == Helper.usuario && d.periodo_tep_proceso == _tb.periodo_proceso);*/

           
            if (!bExiste)
            {
                decimal dRep = db.tbl_reportes_tiempo.Max(d => d.id_reporte) + 1;

                Item = new tbl_reportes_tiempo();
                Item.a_dia = Convert.ToDecimal(uteAl.Value);
                Item.de_dia = Convert.ToDecimal(uteDel.Value);
                Item.id_empleado = uceEmpleado.Value.ToString().Trim();
                Item.id_oficina = Helper.Oficina;
                Item.id_reporte = dRep;
                Item.periodo_tep_corresponde = _tb.periodo_proceso;
                Item.periodo_tep_proceso = _tb.periodo_proceso;
                Item.tasa_cambio = 1;

                db.tbl_reportes_tiempo.Add(Item);
            }

            db.SaveChanges();

            //decimal iLinea = 1;
            //iLinea = db.tbl_detalle_cargable.Max(d => d.linea) + 1;

            foreach (tbl_detalle_cargable _det in lstD)
            {
                if (_det.id_reporte == 0)
                {
                    _det.id_reporte = Item.id_reporte;
                    //_det.linea = iLinea++;
                    _det.autorizoenc = string.Empty;
                    _det.autorizotl = string.Empty;
                    _det.Id_departamento = (Helper.UsuarioActivo as tbl_empleados).id_departamento.Trim();
                    _det.Id_team = (Helper.UsuarioActivo as tbl_empleados).id_team.Trim();
                    _det.autorizado = Helper.SI;
                    _det.id_oficina0 = ucOficina.Value.ToString();
                    _det.fecha_hora_captura = DateTime.Now;
                    //db.tbl_detalle_cargable.Add(_det);
                }
            }

            //iLinea = db.tbl_no_cargables.Max(d => d.linea) + 1;

            foreach (tbl_no_cargables _det in lstN)
            {
                if (_det.id_reporte == 0)
                {
                    _det.id_reporte = Item.id_reporte;
                   // _det.linea = iLinea++;
                    _det.id_departamento = (Helper.UsuarioActivo as tbl_empleados).id_departamento.Trim();
                    _det.id_team = (Helper.UsuarioActivo as tbl_empleados).id_team.Trim();

                    //db.tbl_no_cargables.Add(_det);
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
                    break;
            }
            uteOficina.Enabled = false;
        }

        private void NuevoItem()
        {
            ucCliente.Value = null;
            ucProducto.Value = null;
            ucJob.Value = null;
            uteDescripcion.Value = null;
            uneHoras.Value = 0;
            uneGastos.Value = 0;
            ucConcepto.Value = null;

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);

            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Helper.SetUltraComboWidth(this);

            CargaCombos();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);
                

                tbl_oficina _oficin = (Helper.OficinaActiva as tbl_oficina);
                ucePeriodo.Value = _oficin.Status == 0 ? (new PeriodoBL()).ListarSiguienteUno(_oficin.periodo_proceso).id_periodo : _oficin.periodo_proceso;//_oficina.periodo_proceso;
                utePeriodoTep.Value = _oficin.periodo_proceso;

                uteDel.Value =21;
                uteAl.Value = 20;

                uccDel.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 21);
                uccAl.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 20).AddMonths(1);
                upsTipo.Value = 0;

                ucOficina.Value = Helper.Oficina;

                ugData.DataSource = lstD;
                ugDataNo.DataSource = lstN;

                NuevoItem();
            }

            uceEmpleado.Focus();

        }



        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");

                if (Helper.Continuo && AccionActual == Helper.Acciones.Agregar)
                {
                    NuevoItem();

                    uceEmpleado.Value = null;

                    lstD.Clear();
                    ugData.DataBind();

                    lstD = new List<tbl_detalle_cargable>();
                    ugData.DataSource = lstD;
                    ugData.DataBind();

                    lstN.Clear();
                    ugDataNo.DataBind();
                    lstN = new List<tbl_no_cargables>();
                    ugDataNo.DataSource = lstN;
                    ugDataNo.DataBind();

                    uneTotalCargable.Value = 0;
                    uneTotalNoCargable.Value = 0;
                    uneTotalHoras.Value = 0;
                    uneTotalGastos.Value = 0;
                    uneCuota.Value = 0;
                    uceEmpleado.Focus();
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

        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ubNuevo.Focus();
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uneFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneCuota, true, true, true, true);
        }

        private void uneCobranzas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneHoras, true, true, true, true);
        }

        private void uneNotas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneGastos, true, true, true, true);
        }

        private void ultraPanel1_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void ubNuevo_Click(object sender, EventArgs e)
        {
            LimpiaEspacios();
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            if (Convert.ToInt32(ucePeriodo.Value.ToString().Substring(0, 2)) > Convert.ToInt32(_oficina.periodo_proceso.Substring(0, 2)) + (_oficina.Status == 2 ? 1 : 0))
            {
                MessageBox.Show("Selección de Periodo Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ucOficina.Value != null &&
                ucOficina.SelectedRow == null)
            {
                MessageBox.Show("Selección de Oficina Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (upsTipo.Value.ToString() == "0") // cargable
            {

                if (!uvValidador.Validate("required", false, true).IsValid)
                    return;

                if (ucCliente.Value != null &&
                    ucCliente.SelectedRow == null)
                {
                    MessageBox.Show("Selección de Cliente Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ucProducto.Value != null &&
                    ucProducto.SelectedRow == null)
                {
                    MessageBox.Show("Selección de Producto Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ucJob.Value != null &&
                    ucJob.SelectedRow == null)
                {
                    MessageBox.Show("Selección de Job Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!uvValidador.Validate("reqNoCar", false, true).IsValid)
                    return;

                if (ucConcepto.Value != null &&
                    ucConcepto.SelectedRow == null)
                {
                    MessageBox.Show("Selección de Concepto Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!uvValidador.Validate("reqVal", false, true).IsValid)
                return;

            /*if (uneGastos.Value != null &&
                Convert.ToDecimal(uneGastos.Value)<0)
            {
                MessageBox.Show("Valor Gastos Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            /*if (uneHoras.Value != null &&
               Convert.ToDecimal(uneHoras.Value) < 0)
            {
                MessageBox.Show("Valor Horas Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToDecimal(uneGastos.Value) + Convert.ToDecimal(uneHoras.Value) <= 0)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            tbl_empleados empleado = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == Helper.usuario);
            if (upsTipo.Value.ToString() == "0") // cargable
            {
                tbl_detalle_cargable _cargable = new tbl_detalle_cargable();
                _cargable.cuota_facturacion = Convert.ToDecimal(uneCuota.Value ?? 0); //empleado.cuota_facturacion_local;

                _cargable.descripcion_cargo = string.Empty;
                if (uteDescripcion.Value != null)
                    _cargable.descripcion_cargo = uteDescripcion.Value.ToString();

                _cargable.gastos = Convert.ToDecimal(uneGastos.Value);
                _cargable.honorarios = 0;
                _cargable.gastoscaptadosweb = 0;
                _cargable.horas = Convert.ToDecimal(uneHoras.Value);
                _cargable.id_cliente = ucCliente.Value.ToString().Trim();
                _cargable.id_empleado = uceEmpleado.Value.ToString().Trim();
                _cargable.id_job = ucJob.Value.ToString().Trim();
                _cargable.id_oficina0 = Helper.Oficina;

                uneTotalCargable.Value = Convert.ToDecimal(uneTotalCargable.Value) + _cargable.horas;
                uneTotalGastos.Value = Convert.ToDecimal(uneTotalGastos.Value) + _cargable.gastos;

                lstD.Add(_cargable);
                ugData.DataBind();

            }
            else
            {
                tbl_no_cargables _noCargable = new tbl_no_cargables();

                _noCargable.descripcion = string.Empty;
                if (uteDescripcion.Value != null)
                    _noCargable.descripcion = uteDescripcion.Value.ToString();

                _noCargable.horas = Convert.ToDecimal(uneHoras.Value);
                _noCargable.id_concepto = ucConcepto.Value.ToString();

                uneTotalNoCargable.Value = Convert.ToDecimal(uneTotalNoCargable.Value) + _noCargable.horas;

                lstN.Add(_noCargable);
                ugDataNo.DataBind();
            }

            uneTotalHoras.Value = Convert.ToDecimal(uneTotalCargable.Value) + Convert.ToDecimal(uneTotalNoCargable.Value);

            NuevoItem();
            upsTipo.Focus();
            if (upsTipo.Value.ToString() == "0")
                ucCliente.Focus();
            else
                ucConcepto.Focus();

        }

        private void ucCliente_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucCliente_KeyDown(object sender, KeyEventArgs e)
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

        private void ucCliente_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}", e.Row.Cells["razon_social"].Value.ToString().Trim());
        }

        private void ucCliente_ValueChanged(object sender, EventArgs e)
        {
            
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

        private void ucProducto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["Nombre_largo"].Value.ToString().Trim());
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

        private void ucJob_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucJob_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_job"].Value.ToString().Trim(), e.Row.Cells["descripcion"].Value.ToString().Trim());
            //e.Row.Cells["propuesta"].Value = string.Format("{0}", e.Row.Cells["id_propuesta"].Value.ToString().Trim());
        }

        private void ucProducto_ValueChanged(object sender, EventArgs e)
        {
            jobsENBindingSource.Clear();
            if (ucProducto.Value != null &&
                ucProducto.SelectedRow != null &&
                ucCliente.Value != null &&
                ucCliente.SelectedRow != null)
            {
                List<JobsEN> lst = new List<JobsEN>();
                string id_oficina = ucOficina.Value.ToString();
                string id_servicio = ucProducto.Value.ToString();
                string id_cliente = ucCliente.Value.ToString();
                var query = from a in db.tbl_trabajos
                            join b in db.tbl_servicios on a.id_servicio equals b.id_servicio
                            where b.id_servicio == id_servicio && a.id_cliente == id_cliente && a.estado == 0 && (a.Inactivo_Cargo_Horas ?? false)==false &&
                            a.id_oficina == id_oficina
                            select new JobsExtEN()
                            {
                                id_job = a.id_job,
                                descripcion = a.descripcion,
                                id_cliente = a.id_cliente,
                                id_servicio = a.id_servicio,
                                id_propuesta = a.id_propuesta
                            };

                jobsENBindingSource.DataSource = query.AsQueryable().ToList();
                ucJob.Value = null;
            }
        }

        private void ucConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucConcepto.Value != null)
                {
                    string sVal = ucConcepto.Value.ToString();
                    ucConcepto.Value = null;
                    ucConcepto.Value = sVal.PadRight(4);
                }
                SelectNextControl(ucConcepto, true, true, true, true);
            }
        }

        private void ucConcepto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucConcepto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_concepto"].Value.ToString().Trim(), e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void upsTipo_ValueChanged(object sender, EventArgs e)
        {
            ucConcepto.Enabled = true;
            ucCliente.Enabled = true;
            ucProducto.Enabled = true;
            ucJob.Enabled = true;
            uneGastos.Enabled = true;
            uneCuota.Enabled = true;

            if (upsTipo.Value.ToString() == "0")
            {
                ucConcepto.Enabled = false;
                ucConcepto.Value = null;
                ulActCon.Text = "Trabajos Realizados:";
                ucCliente.Focus();
            }
            else
            {
                ulActCon.Text = "Actividad no Cargable:";
                ucCliente.Value = null;
                ucProducto.Value = null;
                ucJob.Value = null;
                uneGastos.Enabled = false;

                ucCliente.Enabled = false;
                ucProducto.Enabled = false;
                ucJob.Enabled = false;
                uneCuota.Value = 0;
                uneCuota.Enabled = false;
                ucConcepto.Focus();
                
            }
        }

        private void ucOficina_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void upsTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (upsTipo.Value.ToString() == "0")
                    ucCliente.Focus();
                else
                    ucConcepto.Focus();
        }

        private void ugData_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            switch (e.Cell.Column.Key.ToLower())
            {
                case "id_cliente":
                    servicioVL = new ValueList();
                    foreach (ServicioEN _servicio in (new ServicioBL(ref db)).ListarTodos(e.NewValue.ToString().Trim(), Constantes.S_TODOS, Constantes.S_TODOS, Helper.Oficina))
                        servicioVL.ValueListItems.Add(new ValueListItem(_servicio.id_servicio, string.Format("{0}-{1}", _servicio.id_servicio.Trim(), _servicio.Nombre_largo.Trim())));

                    e.Cell.ValueList = servicioVL;
                    break;
                case "id_job":
                    string id_cliente = e.Cell.Row.Cells["id_cliente"].Value.ToString();
                    string id_job = e.Cell.Row.Cells["id_job"].Value.ToString();
                    jobVL = new ValueList();
                    var query = from a in db.tbl_trabajos
                                where a.id_cliente == id_cliente && a.id_job == id_job
                                select new JobsEN()
                                {
                                    id_job = a.id_job,
                                    descripcion = a.descripcion,
                                    id_cliente = a.id_cliente,
                                    id_servicio = a.id_servicio
                                };

                    foreach (JobsEN _job in query.AsQueryable())
                        jobVL.ValueListItems.Add(new ValueListItem(_job.id_job, string.Format("{0}-{1}", _job.id_job.Trim(), _job.descripcion.Trim())));

                    e.Cell.ValueList = jobVL;
                    break;

            }
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_oficina0"].ValueList = oficinaVL;
            e.Layout.Bands[0].Columns["id_cliente"].ValueList = clienteVL;
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            if (Convert.ToInt32(e.Row.Cells["id_reporte"].Value) != 0)
                e.Row.Cells["delete"].Activation = Activation.Disabled;

            /*servicioVL = new ValueList();
            foreach (ServicioEN _servicio in (new ServicioBL(ref db)).ListarTodos(e.Row.Cells["id_cliente"].Value.ToString().Trim(), Constantes.S_TODOS, Constantes.S_TODOS, Helper.Oficina))
                servicioVL.ValueListItems.Add(new ValueListItem(_servicio.id_servicio, string.Format("{0}-{1}", _servicio.id_servicio.Trim(), _servicio.Nombre_largo.Trim())));

            e.Row.Cells["id_servicio"].ValueList = servicioVL;*/

            string id_cliente = e.Row.Cells["id_cliente"].Value.ToString();
            string id_job = e.Row.Cells["id_job"].Value.ToString();
            jobVL = new ValueList();
            var query = from a in db.tbl_trabajos
                        where a.id_cliente == id_cliente && a.id_job == id_job
                        select new JobsEN()
                        {
                            id_job = a.id_job,
                            descripcion = a.descripcion,
                            id_cliente = a.id_cliente,
                            id_servicio = a.id_servicio
                        };

            foreach (JobsEN _job in query.AsQueryable())
                jobVL.ValueListItems.Add(new ValueListItem(_job.id_job, string.Format("{0}-{1}", _job.id_job.Trim(), _job.descripcion.Trim())));

            e.Row.Cells["id_job"].ValueList = jobVL;            
        }

        private void ugDataNo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_concepto"].ValueList = conceptoVL;
        }

        private void uceEmpleado_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Cells["desc"].Value = string.Format("{0}",  e.Row.Cells["nombrecompleto"].Value.ToString().Trim());
        }

        private void uceEmpleado_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uceEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (uceEmpleado.Value != null)
                {
                    string sVal = uceEmpleado.Value.ToString();
                    uceEmpleado.Value = null;
                    uceEmpleado.Value = sVal.PadRight(10);
                }
                SelectNextControl(uceEmpleado, true, true, true, true);
            }
        }

        private void uceEmpleado_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = uceEmpleado.Textbox.SelectionStart;
                if (!uceEmpleado.IsDroppedDown)
                {
                    if (uceEmpleado.Text.Length > 0)
                    {

                        uceEmpleado.ToggleDropdown();
                        uceEmpleado.Textbox.SelectionLength = 0;
                        uceEmpleado.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (uceEmpleado.Text.Trim() != string.Empty)
                {
                    uceEmpleado.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    uceEmpleado.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + uceEmpleado.Text + "*");
                }
            }
        }

        private void uceEmpleado_BeforeDropDown(object sender, CancelEventArgs e)
        {
            uceEmpleado.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ultraPanel4_PaintClient(object sender, PaintEventArgs e)
        {

        }

        private void uceEmpleado_ValueChanged(object sender, EventArgs e)
        {
            if (uceEmpleado.Value != null &&
                uceEmpleado.SelectedRow != null)
            {
                EmpleadoEN _em = uceEmpleado.SelectedRow.ListObject as EmpleadoEN;
                uneCuota.Value = _em.cuota_facturacion_local;
            }

        }

        private void ugDataNo_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            if (Convert.ToInt32(e.Row.Cells["id_reporte"].Value) != 0)
                e.Row.Cells["delete"].Activation = Activation.Disabled;
        }

        private void ugData_ClickCellButton(object sender, CellEventArgs e)
        {
            if (ugData.ActiveRow != null)
            {

                uneTotalCargable.Value = Convert.ToDecimal(uneTotalCargable.Value) - (ugData.ActiveRow.ListObject as tbl_detalle_cargable).horas;
                uneTotalGastos.Value = Convert.ToDecimal(uneTotalGastos.Value) - (ugData.ActiveRow.ListObject as tbl_detalle_cargable).gastos;

                uneTotalHoras.Value = Convert.ToDecimal(uneTotalNoCargable.Value) + Convert.ToDecimal(uneTotalCargable.Value);

                lstD.Remove(ugData.ActiveRow.ListObject as tbl_detalle_cargable);
                ugData.DataBind();


            }
        }

        private void ugDataNo_ClickCellButton(object sender, CellEventArgs e)
        {
            if (ugDataNo.ActiveRow != null)
            {
                uneTotalNoCargable.Value = Convert.ToDecimal(uneTotalNoCargable.Value) - (ugDataNo.ActiveRow.ListObject as tbl_no_cargables).horas;
                uneTotalHoras.Value = Convert.ToDecimal(uneTotalNoCargable.Value) + Convert.ToDecimal(uneTotalCargable.Value);

                lstN.Remove(ugDataNo.ActiveRow.ListObject as tbl_no_cargables);
                ugDataNo.DataBind();
            }
        }

        private void ucCliente_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucCliente_KeyUp(object sender, KeyEventArgs e)
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

        private void ucProducto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucProducto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucJob_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucJob.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucConcepto_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucConcepto.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
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

        private void uccDel_ValueChanged(object sender, EventArgs e)
        {
            uteDel.Value = Convert.ToDateTime(uccDel.Value).Day;
        }

        private void uccAl_ValueChanged(object sender, EventArgs e)
        {
            uteAl.Value = Convert.ToDateTime(uccAl.Value).Day;
        }

        private void ucCliente_Enter(object sender, EventArgs e)
        {
            
        }

        private void ucCliente_TextChanged(object sender, EventArgs e)
        {
            if (ucProducto.Value != null) ucProducto.Value = null;
            if (ucJob.Value != null) ucJob.Value = null;
        }

        private void ucCliente_AfterCloseUp(object sender, EventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ubClean_Click(object sender, EventArgs e)
        {
            NuevoItem();
            upsTipo.Focus();
            if (upsTipo.Value.ToString() == "0")
                ucCliente.Focus();
            else
                ucConcepto.Focus();
        }

        private void ucOficina_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ucOficina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucOficina, true, true, true, true);
        }        
    }
}

