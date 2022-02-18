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
using Infragistics.Win.UltraWinSchedule;

namespace TiempoEnProceso.Forms
{
    public partial class frmEmpleado : Form
    {
        public tbl_empleados Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }

        private TEPEntities db;
        public frmEmpleados frmEmpleados { get; set; }

        public frmEmpleado()
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
            LimpiaEspacios();

            if (!uvValidador.Validate("required", false, true).IsValid)
                return false;

            if (ucPuesto.Value != null &&
                ucPuesto.SelectedRow == null)
            {
                MessageBox.Show("Selección de Puesto Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucDepto.Value != null &&
                ucDepto.SelectedRow == null)
            {
                MessageBox.Show("Selección de Departamento Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ucTeam.Value != null &&
                ucTeam.SelectedRow == null)
            {
                MessageBox.Show("Selección de Team Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string _id = uneId.Value.ToString();
            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_empleados.Any(d => d.id_empleado== _id))
                {
                    MessageBox.Show("Empleado ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (AccionActual == Helper.Acciones.Editar)
            {
            }

            if (ucSituacion.Value != null &&
                ucSituacion.Value.ToString() == "B" &&
                udteFechaBaja.Value == null)
            {
                MessageBox.Show("Selección de Fecha de Baja Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();

            if (uneId.Value != null)
                uneId.Value = uneId.Value.ToString().Trim();

            if (uteIniciales.Value != null)
                uteIniciales.Value = uteIniciales.Value.ToString().Trim();

            if (uteApellidos.Value != null)
                uteApellidos.Value = uteApellidos.Value.ToString().Trim();

            if (uteClave.Value != null)
                uteClave.Value = uteClave.Value.ToString().Trim();

            if (uteCemCosto.Value != null)
                uteCemCosto.Value = uteCemCosto.Value.ToString().Trim();



        }

        public void CargarItem(string _empleado)
        {
            Item = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == _empleado);

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uneId.Value = Item.id_empleado;
            uteDescripcion.Value = Item.Nombres.Trim();
            uteIniciales.Value = Item.iniciales;
            ucPuesto.Value = Item.id_puesto;
            ucDepto.Value = Item.id_departamento;
            uteApellidos.Value = Item.apellidos.Trim();
            ucSituacion.Value = Item.situacion_actual.Trim();
            unePresupuesto.Value = Item.presupuesto_horas;
            uccFechaIngreso.Value = Item.fecha_ingreso;
            uccFechaNac.Value = Item.fecha_nacimiento;
            uteClave.Value = Item.clave;
            uteCemCosto.Value = Item.cem_costo;
            uneCuota.Value = Item.cuota_facturacion_local;
            uneCuotaInter.Value = Item.cuota_facturacion_interamerica;
            udteUltimo.Value = Item.ultimo_reporte_entregado;
            ucTeam.Value = Item.id_team;
            uckSolicita.Checked = Item.usuario_administrativo == Helper.SI;
            udteFechaBaja.Value = Item.fecha_baja;
            uteWorkDay.Value = Item.id_workday;
            uteempopyee_ppi.Value = Item.empoyee_ppi;
            utePartyId.Value = Item.partyId;
            uckSabado.Checked = Item.No_Trabaja_sabado ?? false;
        }

        public void CargaCombos()
        {
            tblpuestosBindingSource.DataSource = (new PuestosBL()).ListarTodos();
            tbldepartamentoBindingSource.DataSource = (new DeptoBL()).ListarTodos();
            tblteamsBindingSource.DataSource = (new TeamsBL()).ListarTodos();
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
                {

                    /*tbl_parametros param = db.tbl_parametros.FirstOrDefault(d => d.id_parametro == "expiracion_clave");
                    if (param == null)
                    {
                        Helper.ShowError("Encripción", "No existe el parámetro para vencimiento de clave", null, MessageBoxButtons.OK, "Error");
                        return false;
                    }

                    double dVenc = (double)param.valor_numerico;*/

                    db.tbl_empleados.Add(Item);

                    /*tbl_claves_empleado tbl = new tbl_claves_empleado()
                    {
                        activo = true,
                        cambia_clave = true,
                        clave = Helper.Encriptar(Item.id_empleado),
                        fecha_clave = DateTime.Now.Date,
                        fecha_expiracion = DateTime.Now.Date.AddDays(dVenc),
                        id_empleado = Item.id_empleado
                    };

                    db.tbl_claves_empleado.Add(tbl);*/
                }

                db.SaveChanges();

                frmEmpleados.CargaGrid(false);
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
                Item.id_empleado = uneId.Value.ToString();
                Item.id_oficina = Helper.Oficina;
            }

            Item.Nombres = uteDescripcion.Value.ToString();
            Item.empoyee_ppi = string.Empty;
            if (uteempopyee_ppi.Value != null)
                Item.empoyee_ppi = uteempopyee_ppi.Value.ToString();

            Item.iniciales = string.Empty;
            if (uteIniciales.Value != null)
                Item.iniciales = uteIniciales.Value.ToString();

            Item.id_puesto = ucPuesto.Value.ToString();
            Item.id_departamento = ucDepto.Value.ToString();
            Item.apellidos = uteApellidos.Value.ToString();
            Item.situacion_actual = ucSituacion.Value.ToString();
            Item.presupuesto_horas = Convert.ToDecimal(unePresupuesto.Value);
            Item.fecha_ingreso = Convert.ToDateTime(uccFechaIngreso.Value);
            Item.fecha_nacimiento = null;
            if (uccFechaNac.Value != null && uccFechaNac.Value!= DBNull.Value)
                Item.fecha_nacimiento = Convert.ToDateTime(uccFechaNac.Value);

            Item.clave = uteClave.Value.ToString();
            Item.No_Trabaja_sabado = uckSabado.Checked;

            Item.cem_costo = string.Empty;
            if (uteCemCosto.Value != null)
                Item.cem_costo = uteCemCosto.Value.ToString();

            Item.cuota_facturacion_local = Convert.ToDecimal(uneCuota.Value);
            Item.cuota_facturacion_interamerica = Convert.ToDecimal(uneCuotaInter.Value);
            Item.id_team = ucTeam.Value.ToString();
            Item.usuario_administrativo = uckSolicita.Checked ? Helper.SI : 0;
            
            Item.fecha_baja = null;
            if (udteFechaBaja.Value != null)
                Item.fecha_baja = Convert.ToDateTime(udteFechaBaja.Value);

            Item.id_workday = string.Empty;
            if (uteWorkDay.Value != null)
                Item.id_workday = uteWorkDay.Value.ToString();

            Item.partyId = string.Empty;
            if (utePartyId.Value != null)
                Item.partyId = utePartyId.Value.ToString();
        }

        private void EstableceHabilitacion()
        {
            switch (AccionActual)
            {
                case Helper.Acciones.Agregar:
                    //uneCuotaInter.Enabled = false;
                    udteUltimo.Enabled = false;
                    break;
                case Helper.Acciones.Consultar:
                    SetEnableControls(false);
                    break;
                case Helper.Acciones.Editar:
                    uneId.Enabled = false;
                    //uneCuotaInter.Enabled = false;
                    udteUltimo.Enabled = false;
                    break;
            }
        }

        private void NuevoItem()
        {
            Item = new tbl_empleados();
            uneId.Value = null;
            uteDescripcion.Value = null;
            ucTeam.Value = null;
            uteIniciales.Value = null;
            ucPuesto.Value = null;
            ucDepto.Value = null;
            uteApellidos.Value = null;
            ucSituacion.Value = Helper.ACTIVO;
            unePresupuesto.Value = null;
            uccFechaIngreso.Value = DateTime.Now.Date;
            uccFechaNac.Value = null;
            uteClave.Value = null;
            uteCemCosto.Value = null;
            uneCuota.Value = null;
            uneCuotaInter.Value = null;
            udteUltimo.Value = null;
            ucTeam.Value = null;
            uckSolicita.Checked = false;
            udteFechaBaja.Value = null;
            uckSabado.Checked = false;
            uneId.Focus();

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCombo>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraComboEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraDateTimeEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCalendarCombo>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraNumericEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraCheckEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);
            Helper.SetUltraComboWidth(this);

            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            uteOficina.Value = string.Format("{0}-{1}", Helper.Oficina, (Helper.OficinaActiva as tbl_oficina).Nombre);

            
            Helper.GetControls<UltraLabel>(this.ultraPanel4).ForEach(d => d.Appearance.FontData.Bold = DefaultableBoolean.True);

            if (AccionActual == Helper.Acciones.Agregar)
            {
                CargaCombos();
                NuevoItem();
            }
                           

            uneId.Focus();

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
                SelectNextControl(uneId, true, true, true, true);
        }

        private void ucDepto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucDepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucDepto, true, true, true, true);
        }

        private void ucDepto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_departamento"].Value.ToString().Trim(), e.Row.Cells["Nombre_largo"].Value.ToString().Trim());
        }

        private void ucTeam_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_team"].Value.ToString().Trim(), e.Row.Cells["nombre"].Value.ToString().Trim());
        }

        private void ucTeam_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucTeam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucTeam, true, true, true, true);
        }

        private void udteUltimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(udteUltimo, true, true, true, true);
        }

        private void uneCuota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneCuota, true, true, true, true);
        }

        private void uneCuotaInter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uneCuotaInter, true, true, true, true);
        }

        private void uteClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteClave, true, true, true, true);
        }

        private void uteCemCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteCemCosto, true, true, true, true);
        }

        private void uccFechaIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uccFechaIngreso, true, true, true, true);
        }

        private void uccFechaNac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uccFechaNac, true, true, true, true);
        }

        private void ucSituacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucSituacion, true, true, true, true);
        }

        private void ucSituacion_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void uteApellidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteApellidos, true, true, true, true);
        }

        private void ucPuesto_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["id_puesto"].Value.ToString().Trim(), e.Row.Cells["descripcion"].Value.ToString().Trim());
        }

        private void ucPuesto_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucPuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(ucPuesto, true, true, true, true);
        }

        private void uteIniciales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteempopyee_ppi.Focus();
        }

        private void uckSolicita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uckSolicita, true, true, true, true);
        }

        private void unePresupuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(unePresupuesto, true, true, true, true);
        }

        private void udteFechaBaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(udteFechaBaja, true, true, true, true);
        }

        private void uteWorkDay_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.OemPipe) { e.SuppressKeyPress = true; return; }

            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteWorkDay, true, true, true, true);
        }

        private void uteempopyee_ppi_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.OemPipe) { e.SuppressKeyPress = true; return; }

            if (e.KeyCode == Keys.Enter)
                ucPuesto.Focus();
        }

        private void uteWorkDay_ValueChanged(object sender, EventArgs e)
        {
            /*if (uteWorkDay.Value == null) return;

            if (uteWorkDay.Value.ToString().IndexOf("|") >= 0)
            {
                uteWorkDay.Value = uteWorkDay.Value.ToString().Replace("|", "");
                uteWorkDay.SelectionStart = uteWorkDay.Value.ToString().Length;
            }*/
        }

        private void uteempopyee_ppi_ValueChanged(object sender, EventArgs e)
        {
            /*if (uteempopyee_ppi.Value == null) return;

            if (uteempopyee_ppi.Value.ToString().IndexOf("|") >= 0)
            {
                uteempopyee_ppi.Value = uteempopyee_ppi.Value.ToString().Replace("|", "");
                uteempopyee_ppi.SelectionStart = uteempopyee_ppi.Value.ToString().Length;
            }*/
        }

        private void uteWorkDay_Leave(object sender, EventArgs e)
        {
            if (uteWorkDay.Value == null) return;

            uteWorkDay.Value = uteWorkDay.Value.ToString().Replace("|", "");
           
        }

        private void uteempopyee_ppi_Leave(object sender, EventArgs e)
        {
            if (uteempopyee_ppi.Value == null) return;
            uteempopyee_ppi.Value = uteempopyee_ppi.Value.ToString().Replace("|", "");
        }

        private void utePartyId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(utePartyId, true, true, true, true);
        }
    }
}
