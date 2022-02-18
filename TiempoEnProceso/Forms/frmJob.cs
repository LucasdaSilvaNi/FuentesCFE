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
using System.Collections.ObjectModel;

namespace TiempoEnProceso.Forms
{
    public partial class frmJob : Form
    {
        public tbl_trabajos Item { get; set; }
        List<tbl_trabajos_distribucion> Detalle = new List<tbl_trabajos_distribucion>();
        public List<Tbl_Trabajos_Oficina> lstD = new List<Tbl_Trabajos_Oficina>();
        ValueList empleadosVl;
        ValueList empresasVl = new ValueList();

        public frmJobs frmJobs { get; set; }

        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;

        public frmJob()
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

            /*string _id = uteId.Value.ToString();
            string _cliente = ucCliente.Value.ToString();
            string _id_servicio = ucProducto.Value.ToString();
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_trabajos.Any(d => d.id_job==_id && d.id_oficina== Helper.Oficina && d.id_cliente ==_cliente && d.id_servicio == _id_servicio))
                {
                    MessageBox.Show("Job ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (AccionActual == Helper.Acciones.Editar)
            {
            }*/

            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();

            if (uteId.Value != null)
                uteId.Value = uteId.Value.ToString().Trim();

            if (uteContacto.Value != null)
                uteContacto.Value = uteContacto.Value.ToString().Trim();

            if (uteBillManager.Value != null)
                uteBillManager.Value = uteBillManager.Value.ToString().Trim();

            if (uteBillPartner.Value != null)
                uteBillPartner.Value = uteBillPartner.Value.ToString().Trim();

            if (uteContinent.Value != null)
                uteContinent.Value = uteContinent.Value.ToString().Trim();

            if (uteReferido.Value != null)
                uteReferido.Value = uteReferido.Value.ToString().Trim();

        }

        public void CargarItem(string _id_job, string _cliente, string _servicio)
        {
            tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;
            Item = db.tbl_trabajos.Include("tbl_trabajos_distribucion").Include("Tbl_Trabajos_Oficina").FirstOrDefault(d => d.id_job == _id_job && d.id_pais == _oficina.id_pais && d.id_cliente == _cliente && d.id_servicio == _servicio);
            Detalle = Item.tbl_trabajos_distribucion.ToList();
            lstD = Item.Tbl_Trabajos_Oficina.ToList();
            empleadosVl = new ValueList();
            empresasVl = new ValueList();
            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            string pais = (Helper.OficinaActiva as tbl_oficina).id_pais;
            if (AccionActual!= Helper.Acciones.Copiar)
                uteId.Value = Item.id_job;

            uteDescripcion.Value = Item.descripcion;
            uteContacto.Value = Item.contacto;
            ucCliente.Value = Item.id_cliente;
            ucProducto.Value = Item.id_servicio;

            uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);
            tbl_paises _pais = db.tbl_paises.FirstOrDefault(d => d.id_pais == pais);
            utePais.Value = string.Format("{0}-{1}", _pais.id_pais.Trim(), _pais.Nombre.Trim());
            uccFechaEmitir.Value = Item.fecha_inicio_job;
            uneGastos.Value = Item.gastos_contratados;
            uneHorarios.Value = Item.honorarios_contratados;
            uneHoras.Value = Item.horas_contratadas;
            uneRealizacion.Value = Item.realizacion_esperada;
            uckEstado.Checked = Item.estado == Helper.SI;
            uckCaptaHoras.Checked = Item.Inactivo_Cargo_Horas ?? true;
            utePropuesta.Value = Item.id_propuesta;
            uccFechaBaja.Value = Item.Fecha_Baja;
            /*
            ucLider.Value = Item.d;
            ucTeamLider.Value = Item.ddd;
            ucEngageLider.Value = Item.dadf;
            */
            ucLider.Value = Item.id_socio;
            ucTeamLider.Value = Item.id_encargado;
            ucEngageLider.Value = Item.segundo_socio;

            uteBillManager.Value = Item.perform_manager;
            uteBillPartner.Value = Item.perform_parther;
            uteContinent.Value = Item.conting_fee_flag;
            uteReferido.Value = Item.refered_by;

            ugData.DataSource = Detalle;
            ugData.DataBind();

            ugDataT.DataSource = lstD;
            ugDataT.DataBind();
            

        }

        public void CargaCombos()
        {
            clienteENBindingSource.DataSource = (new ClientesBL(ref db)).ListarTodo(Helper.Oficina);

            List<EmpleadoEN> empleados = (new EmpleadosBL()).ListarTodos(Helper.Oficina);
            ucLider.DataSource = empleados;
            ucTeamLider.DataSource = empleados;
            ucEngageLider.DataSource = empleados;
            uceSocioDist.DataSource = empleados;

            empleados.ForEach(d => empleadosVl.ValueListItems.Add(new ValueListItem(d.id_empleado , d.nombrecompleto)));
            db.tbl_entidad_legal.Where(d => d.id_oficina == Helper.Oficina).ToList().ForEach(d => empresasVl.ValueListItems.Add(d.id_entidad, d.Razon_social));

            //clienteVL.ValueListItems.Add(new ValueListItem(_entes.linea, _entes.nombre.Trim()))
            List<ServicioEN> lstA = new List<ServicioEN>();
            db.tbl_servicios.AsQueryable().ToList().ForEach(d => lstA.Add(new ServicioEN() { id_servicio = d.id_servicio, Nombre_largo = d.id_servicio + ' ' + d.Nombre_largo }));
            servicioENBindingSource.DataSource = lstA;
        }


        private bool Grabar()
        {
            if (AccionActual == Helper.Acciones.Consultar)
                return true;

            if (!ValidataControles())
                return false;

            if (uccFechaEmitir.Value == null || uccFechaEmitir.Value == DBNull.Value)
            {
                Helper.ShowError("Grabar", "Fecha de Inicio Invalida", null);
                return false;
            }

            try
            {
                ConstruyeItem();

                if (AccionActual == Helper.Acciones.Agregar ||
                    AccionActual == Helper.Acciones.Copiar )
                    db.tbl_trabajos.Add(Item);

                db.SaveChanges();

                if (AccionActual == Helper.Acciones.Copiar)
                    Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Copia - Proyecto", "Proyecto copiado Satisfactoriamente");

                frmJobs.CargaGrid(false);
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

            if (AccionActual == Helper.Acciones.Agregar ||
                AccionActual == Helper.Acciones.Copiar)
            {

                tbl_correlativos _correl = db.tbl_correlativos.FirstOrDefault(d => d.tabla == "tbl_trabajos");
                decimal dIDTran = _correl.correlativo.Value + 1;
                _correl.correlativo = dIDTran;
                db.SaveChanges();

                uteId.Value = dIDTran;

                Item.id_job = uteId.Value.ToString();

                Item.id_job= uteId.Value.ToString();
                Item.id_oficina = Helper.Oficina;
                Item.id_pais = (Helper.OficinaActiva as tbl_oficina).id_pais;
                Item.id_cliente = ucCliente.Value.ToString();
                Item.id_servicio = ucProducto.Value.ToString();

                /*tbl_correlativos _correl = db.tbl_correlativos.FirstOrDefault(d => d.tabla == "tbl_trabajos");
                _correl.correlativo = Convert.ToInt32(uteId.Value);*/
            }

            Item.descripcion = uteDescripcion.Value.ToString();
            Item.estado = uckEstado.Checked ? Helper.SI: 0;

            Item.contacto = string.Empty;
            if (uteContacto.Value != null)
                Item.contacto = uteContacto.Value.ToString();

            Item.fecha_inicio_job = Convert.ToDateTime(uccFechaEmitir.Value);
            Item.gastos_contratados = Convert.ToDecimal(uneGastos.Value);
            Item.honorarios_contratados = Convert.ToDecimal(uneHorarios.Value);
            Item.horas_contratadas = Convert.ToDecimal(uneHoras.Value);
            Item.realizacion_esperada = Convert.ToInt32(uneRealizacion.Value);
            Item.Inactivo_Cargo_Horas = uckCaptaHoras.Checked;

            Item.perform_manager = string.Empty;
            if (uteBillManager.Value != null)
                Item.perform_manager = uteBillManager.Value.ToString();

            Item.perform_parther = string.Empty;
            if (uteBillPartner.Value != null)
                Item.perform_parther = uteBillPartner.Value.ToString();

            Item.conting_fee_flag = string.Empty;
            if (uteContinent.Value != null)
                Item.conting_fee_flag = uteContinent.Value.ToString();

            if (ucLider.Value != null)
                Item.id_socio = ucLider.Value.ToString();

            Item.id_propuesta = null;
            if (utePropuesta.Value != null)
                Item.id_propuesta = utePropuesta.Value.ToString();

            if (ucTeamLider.Value != null)
                Item.id_encargado = ucTeamLider.Value.ToString();

            if (ucEngageLider.Value != null)
                Item.segundo_socio = ucEngageLider.Value.ToString();

            Item.Fecha_Baja = null;
            if (uccFechaBaja.Value != null)
                Item.Fecha_Baja = Convert.ToDateTime(uccFechaBaja.Value);

            Detalle.ForEach(d =>
            {
                if (d.Id_tbl_trabajos_distribucion == 0)
                {
                    d.id_cliente = Item.id_cliente;
                    d.id_job = Item.id_job;

                    Item.tbl_trabajos_distribucion.Add(d);
                }                
            });

            lstD.ForEach(d =>
            {
                if (!string.IsNullOrEmpty(d.Id_Cliente))
                {
                    d.Id_Cliente = Item.id_cliente;
                    d.Id_Job = Item.id_job;

                    Item.Tbl_Trabajos_Oficina.Add(d);
                }
            });
        }

        private void EstableceHabilitacion()
        {
            switch (AccionActual)
            {
                case Helper.Acciones.Agregar:
                    ugDataT.Enabled = false;
                    ubAgregarData2.Enabled = false;
                    ubEliminaData2.Enabled = false;
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
            Item = new tbl_trabajos();
            Detalle = new List<tbl_trabajos_distribucion>();
            lstD = new List<Tbl_Trabajos_Oficina>();

            ugData.DataSource = Detalle;
            ugData.DataBind();

            ugDataT.DataSource = lstD;
            ugDataT.DataBind();

            if (AccionActual != Helper.Acciones.Copiar)
            {
                uteDescripcion.Value = null;
                uteContacto.Value = null;
                ucCliente.Value = null;
                ucProducto.Value = null;
                uccFechaEmitir.Value = null;
                uneGastos.Value = null;
                uneHorarios.Value = null;
                uneHoras.Value = null;
                uneRealizacion.Value = null;

                ucLider.Value = null;
                ucTeamLider.Value = null;
                ucEngageLider.Value = null;

                uteBillManager.Value = null;
                uteBillPartner.Value = null;
                uteContinent.Value = null;
                uteReferido.Value = null;
                utePropuesta.Value = null;
                uccFechaBaja.Value = null;
            }
            ucCliente.Focus();            

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraDateTimeEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraNumericEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraButton>(this.ultraPanel5).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();

            empleadosVl = new ValueList();
            empresasVl = new ValueList();
            CargaCombos();
            ubCopy.Visible = true;

            if (AccionActual == Helper.Acciones.Agregar ||
                AccionActual == Helper.Acciones.Copiar)
            {
                uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);
                string pais = (Helper.OficinaActiva as tbl_oficina).id_pais;

                tbl_paises _pais = db.tbl_paises.FirstOrDefault(d => d.id_pais == pais);
                utePais.Value = string.Format("{0}-{1}", _pais.id_pais.Trim(), _pais.Nombre.Trim());
                uteId.Enabled = false;
                NuevoItem();
                ubCopy.Visible = false;
            }

            ucCliente.Focus();

        }



        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", string.Format("Proyecto:{0}.\n Registro Grabado Satisfactoriamente", Item.id_job));
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
                SelectNextControl(uteContacto, true, true, true, true);
        }

        private void uckFacturar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uneFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneGastos, true, true, true, true);
        }

        private void uteId_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ucCliente_ValueChanged(object sender, EventArgs e)
        {
            /*servicioENBindingSource.Clear();
            if (ucCliente.Value != null &&
                ucCliente.SelectedRow != null)
            {
                string _cliente = ucCliente.Value.ToString();
                servicioENBindingSource.DataSource = (new ServicioBL(ref db)).ListarTodos(ucCliente.Value.ToString().Trim(), Constantes.S_TODOS, Constantes.S_TODOS, Helper.Oficina, true);
                ucProducto.Value = null;
            }*/
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

        private void ucCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (ucCliente.Value!=null)
                {
                    string sVal = ucCliente.Value.ToString();
                    ucCliente.Value = null;
                    ucCliente.Value = sVal.PadRight(10, ' '); 
                }
                SelectNextControl(ucCliente, true, true, true, true);
            }
        }

        private void ucProducto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0} {1}", e.Row.Cells["id_servicio"].Value.ToString().Trim(), e.Row.Cells["Nombre_largo"].Value.ToString().Trim());
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
                    ucProducto.Value = sVal.PadRight(4,' ');
                }
                SelectNextControl(ucProducto, true, true, true, true);
            }
        }

        private void uccFechaEmitir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uccFechaEmitir, true, true, true, true);
        }

        private void uneHorarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneHorarios, true, true, true, true);
        }

        private void uneHoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneHoras, true, true, true, true);
        }

        private void uneRealizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneRealizacion, true, true, true, true);
        }

        private void ucLider_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucLider_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucLider.Value != null)
                {
                    string sVal = ucLider.Value.ToString();
                    ucLider.Value = null;
                    ucLider.Value = sVal.PadRight(10,' ');
                }
                SelectNextControl(ucLider, true, true, true, true);
            }
        }

        private void ucTeamLider_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucTeamLider_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucTeamLider.Value != null)
                {
                    string sVal = ucTeamLider.Value.ToString();
                    ucTeamLider.Value = null;
                    ucTeamLider.Value = sVal.PadRight(10, ' '); ;
                }
                SelectNextControl(ucTeamLider, true, true, true, true);
            }
        }

        private void ucEngageLider_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucEngageLider_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ucEngageLider.Value != null)
                {
                    string sVal = ucEngageLider.Value.ToString();
                    ucEngageLider.Value = null;
                    ucEngageLider.Value = sVal.PadRight(10, ' '); ;
                }
                SelectNextControl(ucEngageLider, true, true, true, true);
            }
        }

        private void uteBillManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteBillManager, true, true, true, true);
        }

        private void uteBillPartner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteBillPartner, true, true, true, true);
        }

        private void uteContinent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteContinent, true, true, true, true);
        }

        private void uteReferido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteReferido, true, true, true, true);
        }

        private void ubCopy_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmJob frmC = new frmJob())
                {
                    frmC.AccionActual = Helper.Acciones.Copiar;
                    frmC.CargarItem(uteId.Value.ToString(), ucCliente.Value.ToString(), ucProducto.Value.ToString());
                    frmC.StartPosition = FormStartPosition.CenterParent;
                    frmC.ShowDialog();
                }
                //db.sp_copia_job(ucCliente.Value.ToString(), uteId.Value.ToString());
                //Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Copia Job", "Job copiado Satisfactoriamente");
            }
            catch (Exception ex)
            {
                Helper.ShowError("Copia Job", "Error", ex);
            }

        }

        private void ucLider_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = e.Row.Cells["nombrecompleto"].Value;
        }

        private void ucTeamLider_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value =e.Row.Cells["nombrecompleto"].Value;
        }

        private void ucEngageLider_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = e.Row.Cells["nombrecompleto"].Value;
        }

        private void uckEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckEstado, true, true, true, true);
        }

        private void ucCliente_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

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

        private void ucCliente_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucCliente.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
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

        private void ucTeamLider_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucTeamLider.Textbox.SelectionStart;
                if (!ucTeamLider.IsDroppedDown)
                {
                    if (ucTeamLider.Text.Length > 0)
                    {

                        ucTeamLider.ToggleDropdown();
                        ucTeamLider.Textbox.SelectionLength = 0;
                        ucTeamLider.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucTeamLider.Text.Trim() != string.Empty)
                {
                    ucTeamLider.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucTeamLider.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucTeamLider.Text + "*");
                }
            }
        }

        private void ucTeamLider_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucTeamLider.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucLider_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucLider.Textbox.SelectionStart;
                if (!ucLider.IsDroppedDown)
                {
                    if (ucLider.Text.Length > 0)
                    {

                        ucLider.ToggleDropdown();
                        ucLider.Textbox.SelectionLength = 0;
                        ucLider.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucLider.Text.Trim() != string.Empty)
                {
                    ucLider.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucLider.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucLider.Text + "*");
                }
            }
        }

        private void ucLider_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucLider.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucEngageLider_BeforeDropDown(object sender, CancelEventArgs e)
        {
            ucEngageLider.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void ucEngageLider_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = ucEngageLider.Textbox.SelectionStart;
                if (!ucEngageLider.IsDroppedDown)
                {
                    if (ucEngageLider.Text.Length > 0)
                    {

                        ucEngageLider.ToggleDropdown();
                        ucEngageLider.Textbox.SelectionLength = 0;
                        ucEngageLider.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (ucEngageLider.Text.Trim() != string.Empty)
                {
                    ucEngageLider.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    ucEngageLider.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + ucEngageLider.Text + "*");
                }
            }
        }

        private void ucCliente_TextChanged(object sender, EventArgs e)
        {
            if (ucProducto.Value != null) ucProducto.Value = null;
        }

        private void uteDescripcion_ValueChanged(object sender, EventArgs e)
        {
            /*if (uteDescripcion.Value == null) return;

            if (uteDescripcion.Value.ToString().IndexOf("|") >= 0)
            {
                uteDescripcion.Value = uteDescripcion.Value.ToString().Replace("|", "");
                uteDescripcion.SelectionStart = uteDescripcion.Value.ToString().Length;
            }*/
        }

        private void uteDescripcion_Leave(object sender, EventArgs e)
        {
            if (uteDescripcion.Value == null) return;

            uteDescripcion.Value = uteDescripcion.Value.ToString().Replace("|", "");
        }

        private void ubEliminaData_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                var item = ugData.ActiveRow.ListObject as tbl_trabajos_distribucion;
                if (item.Id_tbl_trabajos_distribucion != 0)
                    Item.tbl_trabajos_distribucion.Remove(item);

                Detalle.Remove(item);

                ugData.DataBind();
            }
        }

        private void ubAgregarData_Click(object sender, EventArgs e)
        {
            uvValidador.ValidationGroups["requiredData"].Enabled = true;

            if (!uvValidador.Validate("requiredData", false, true).IsValid)
                return;

            if (uceSocioDist.Value != null &&
                uceSocioDist.SelectedRow == null)
            {
                MessageBox.Show("Selección de Socio Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (uneDistribucion.Value != null &&
                Convert.ToDecimal(uneDistribucion.Value) <= 0)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var porcentaje = Convert.ToDecimal(uneDistribucion.Value);
            var total = Detalle.Sum(d => d.porcentaje_distribucion) ?? 0;
            if (total + porcentaje > 100)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Detalle.Add(new tbl_trabajos_distribucion
            {
                Id_empleado = uceSocioDist.Value.ToString(),
                porcentaje_distribucion = porcentaje
            });
            ugData.DataBind();
            uceSocioDist.Value = null;
            uneDistribucion.Value = 0;
            uvValidador.ValidationGroups["requiredData"].Enabled = false;
        }

        private void uceSocioDist_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uceSocioDist_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = e.Row.Cells["nombrecompleto"].Value;
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["Id_empleado"].ValueList = empleadosVl;
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
        }

        private void ubAgregarData2_Click(object sender, EventArgs e)
        {
            lstD.Add(new Tbl_Trabajos_Oficina
            {
                Activo = true
            });
            ugDataT.DataBind();
        }

        private void ubEliminaData2_Click(object sender, EventArgs e)
        {
            if (ugDataT.ActiveRow != null)
            {
                var item = ugDataT.ActiveRow.ListObject as Tbl_Trabajos_Oficina;
                if (!string.IsNullOrEmpty(item.Id_Cliente))
                    Item.Tbl_Trabajos_Oficina.Remove(item);

                lstD.Remove(item);

                ugDataT.DataBind();
            }
        }

        private void ugDataT_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["Id_oficina"].ValueList = empresasVl;
        }

        private void uceSocioDist_KeyUp(object sender, KeyEventArgs e)
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
                int iSelLoc = uceSocioDist.Textbox.SelectionStart;
                if (!uceSocioDist.IsDroppedDown)
                {
                    if (uceSocioDist.Text.Length > 0)
                    {

                        uceSocioDist.ToggleDropdown();
                        uceSocioDist.Textbox.SelectionLength = 0;
                        uceSocioDist.Textbox.SelectionStart = iSelLoc;
                    }
                }
                if (uceSocioDist.Text.Trim() != string.Empty)
                {
                    uceSocioDist.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
                    uceSocioDist.DisplayLayout.Bands[0].ColumnFilters["desc"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Like, "*" + uceSocioDist.Text + "*");
                }
            }
        }

        private void uceSocioDist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (uceSocioDist.Value != null)
                {
                    string sVal = uceSocioDist.Value.ToString();
                    uceSocioDist.Value = null;
                    uceSocioDist.Value = sVal.PadRight(10, ' '); ;
                }
                SelectNextControl(uceSocioDist, true, true, true, true);
            }
        }
    }
}
