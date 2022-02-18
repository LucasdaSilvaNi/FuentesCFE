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
using TiempoEnProcesoEN;

namespace TiempoEnProceso.Forms
{
    public partial class frmDistribucionFactura : Form
    {
        private TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        List<tbl_solicitud_facturas_distribucion_socios> lst = new List<tbl_solicitud_facturas_distribucion_socios>();
        List<decimal> lstFac = new List<decimal>();
        List<tbl_oficina> lstOf = new List<tbl_oficina>();
        ValueList empleadosVl;

        public frmDistribucionFactura()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
            db.Database.CommandTimeout = Helper.TimeOut;
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

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).ubicacion_factura) &&
                string.IsNullOrEmpty((ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).formato_facturas))
            {
                MessageBox.Show("Selección Invalida", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            empleadosVl = new ValueList();
            List<EmpleadoEN> empleados = (new EmpleadosBL()).ListarTodos(Helper.Oficina);
            empleados.ForEach(d => empleadosVl.ValueListItems.Add(new ValueListItem(d.id_empleado, d.nombrecompleto)));
            empleadoENBindingSource.DataSource = empleados;

            lstOf = db.tbl_oficina.ToList();
            IQueryable query = from emp in db.tbl_empleados
                               join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                               join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                               where emp.id_empleado == Helper.usuario
                               select ofi;

            tbloficinaBindingSource.DataSource = query.Cast<tbl_oficina>().ToList();

            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();

            ugData.DataSource = lst;
            ugData.DataBind();

            ucOficce.Value = Helper.Oficina;
        }


        private bool Grabar()
        {
            ugData.PerformAction(UltraGridAction.CommitRow);

            if (!ValidataControles())
                return false;

            try
            {
                Cursor = Cursors.WaitCursor;
                string sEntidad = ucEntidad.Value.ToString();
                decimal dFactura = Convert.ToDecimal(uneFactura.Value);
                tbl_cuenta_corriente tbl_Cuenta = db.tbl_cuenta_corriente.FirstOrDefault(d => d.id_oficina == Helper.Oficina && d.id_entidad == sEntidad && d.numero_documento == dFactura);

                lst.ForEach(d =>
                {
                    if (d.id_solicitud == 0)
                    {
                        d.id_solicitud = tbl_Cuenta.id_solicitud ?? 0;
                        db.tbl_solicitud_facturas_distribucion_socios.Add(d);
                    }
                });

                db.SaveChanges();
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, Helper.NombreAplicacion, "Distribución Actualizada");
                Cursor = Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                Helper.ShowError("Execute", "Error al Ejecutar", ex);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return true;
        }

        private void EstableceHabilitacion()
        {
        }

        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            CargaCombos();
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                uneFactura.Value = null;
                uneDistribucion.Value = null;
                uceSocioDist.Value = null;
                lst.Clear();
                ugData.DataBind();

                uneFactura.Focus();
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
            if (e.ReInitialize) return;

            if (e.Row.Cells["select"].Value == null ||
                e.Row.Cells["select"].Value == DBNull.Value)
                e.Row.Cells["select"].Value = false;
        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;
            string _oficina = e.Row.Cells["id_oficina"].Value.ToString().Trim();
            tbl_oficina _tbl = lstOf.FirstOrDefault(d => d.id_oficina == _oficina);

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

            if (uneFactura.Value == null)
            {
                MessageBox.Show("Debe seleccionar una Factura Valida");
                return;
            }
            decimal dFactura = Convert.ToDecimal(uneFactura.Value);
            string sEntidad = ucEntidad.Value.ToString();
            IQueryable query = from a in db.tbl_solicitud_facturas_distribucion_socios
                               join b in db.tbl_cuenta_corriente on a.id_solicitud equals b.id_solicitud
                               where b.numero_documento == dFactura &&
                                   b.id_oficina == Helper.Oficina && b.id_entidad == sEntidad
                               select a;

            lst = query.Cast<tbl_solicitud_facturas_distribucion_socios>().ToList();

            if (lst.Count==0)
            {
                MessageBox.Show("Factura no cuenta con Distribución por Socio");
                return;
            }         

            ugData.DataSource = lst;
            ugData.DataBind();
        }

        private void ugData_ClickCellButton(object sender, CellEventArgs e)
        {
            
        }

        private void ucEntidad_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ultraButton2_Click(object sender, EventArgs e)
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
            var total = lst.Sum(d => d.porcentaje_distribucion);
            if (total + porcentaje > 100)
            {
                MessageBox.Show("Valor Invalido", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lst.Add(new tbl_solicitud_facturas_distribucion_socios
            {
                Id_empleado = uceSocioDist.Value.ToString(),
                porcentaje_distribucion = porcentaje
            });
            ugData.DataBind();
            uceSocioDist.Value = null;
            uneDistribucion.Value = 0;
            uvValidador.ValidationGroups["requiredData"].Enabled = false;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (ugData.ActiveRow != null)
            {
                var item = ugData.ActiveRow.ListObject as tbl_solicitud_facturas_distribucion_socios;
                lst.Remove(item);
                db.tbl_solicitud_facturas_distribucion_socios.Remove(item);
                ugData.DataBind();
            }
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_empleado"].ValueList = empleadosVl;

            if (!e.Layout.Bands[0].Summaries.Exists("Sum_porcentaje"))
            {
                UltraGridColumn columnToSummarize = e.Layout.Bands[0].Columns["porcentaje_distribucion"];

                SummarySettings summary = e.Layout.Bands[0].Summaries.Add("Sum_porcentaje", SummaryType.Sum, columnToSummarize);
                summary.DisplayFormat = "{0:N0}";
                summary.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter;
                summary.Appearance.TextHAlign = HAlign.Right;
            }
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells;
            e.Layout.Override.SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
        }

        private void uceSocioDist_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }
    }
}
