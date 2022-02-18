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
    public partial class frmBitacoraCobro : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);
        List<tbl_cuenta_corriente> lst = new List<tbl_cuenta_corriente>();

        public frmBitacoraCobro()
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

            return MessageBox.Show("Esta seguro de Anular la Solicitud", Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes;
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
            tblentidadlegalBindingSource.DataSource = (new EntidadLegalBL()).Listar();

            ugData.DataSource = lst;
            ugData.DataBind();
        }


        private bool Grabar()
        {
            
            return true;
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
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();
            Helper.SetUltraComboWidth(this);
            CargaCombos();

            ultraDockManager1.DockAreas[0].Closed = true;
            udteFecha.MaxDate = DateTime.Now;
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            
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
        }

        private void ucOficce_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void ubConsultar_Click(object sender, EventArgs e)
        {
            if (ucEntidad.Value == null)
            {
                MessageBox.Show("Debe seleccionar una Entidad Valida");
                return ;
            }

            if (ucEntidad.Value != null &&
                ucEntidad.SelectedRow == null)
            {
                MessageBox.Show("Debe seleccionar una Entidad Valida");
                return;
            }

            tbl_oficina _tbl = Helper.OficinaActiva as tbl_oficina;

            var query = from a in db.tbl_cuenta_corriente
                        where a.id_oficina == _tbl.id_oficina &&
                              a.estado == 1 && a.tipo_documento =="FAC" &&
                              a.saldo.Value != 0 &&
                              a.id_entidad == ucEntidad.Value.ToString()
                        select a;


            lst = query.ToList<tbl_cuenta_corriente>();
            ugData.DataSource = lst;
            ugData.DataBind();
        }

        private void ugData_AfterRowActivate(object sender, EventArgs e)
        {
        }

        private void ugData_ClickCellButton(object sender, CellEventArgs e)
        {

            if (e.Cell.Row.Index >= 0)
            {
                uteObservaciones.Value = null;
                udteFecha.Value = DateTime.Now.Date;

                string _ent = ucEntidad.Value.ToString();
                decimal _docto = (e.Cell.Row.ListObject as tbl_cuenta_corriente).numero_documento;
                string _tipo = (e.Cell.Row.ListObject as tbl_cuenta_corriente).tipo_documento;

                List<tbl_cuenta_corriente_gestion_cobro> lstD = new List<tbl_cuenta_corriente_gestion_cobro>();
                db.tbl_cuenta_corriente_gestion_cobro.Where(d => d.Id_entidad == _ent && d.Id_oficina == Helper.Oficina &&
                                                                 d.tipo_documento == _tipo && d.numero_documento == _docto)
                                                                 .OrderBy(d=>d.Fecha).ThenBy(d=> d.Linea).ToList().ForEach(d => lstD.Add(d));

                tblcuentacorrientegestioncobroBindingSource.DataSource = lstD;
                ugDataD.DataBind();

                ubAgregar.Enabled = false;
                ubCerrar.Enabled = false;
                ubConsultar.Enabled = false;
                ugData.Enabled = false;
                ucEntidad.Enabled = false;
                ultraDockManager1.DockAreas[0].Closed = false;
            }
        }

        private void ubCerrarModal_Click(object sender, EventArgs e)
        {
            ubAgregar.Enabled = true;
            ubCerrar.Enabled = true;
            ubConsultar.Enabled = true;
            ugData.Enabled = true;
            ucEntidad.Enabled = true;

           

            ultraDockManager1.DockAreas[0].Closed = true;
        }

        private void ubGrabarModal_Click(object sender, EventArgs e)
        {

            try
            {
                if (uteObservaciones.Value != null)
                    uteObservaciones.Value = uteObservaciones.Value.ToString().Trim();

                if (uteObservaciones.Value == null)
                {
                    MessageBox.Show("Debe ingresar un valor valido para las Observaciones", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Cursor = Cursors.WaitCursor;

                tbl_cuenta_corriente_gestion_cobro _tbl = new tbl_cuenta_corriente_gestion_cobro();
                _tbl.Fecha = Convert.ToDateTime(udteFecha.Value);
                _tbl.Id_entidad = ucEntidad.Value.ToString();
                _tbl.Id_oficina = Helper.Oficina;
                _tbl.numero_documento = (ugData.ActiveRow.ListObject as tbl_cuenta_corriente).numero_documento;
                _tbl.Observaciones = uteObservaciones.Value.ToString();
                _tbl.tipo_documento = (ugData.ActiveRow.ListObject as tbl_cuenta_corriente).tipo_documento;
                _tbl.Id_usuario = Helper.usuario;
                db.tbl_cuenta_corriente_gestion_cobro.Add(_tbl);
                db.SaveChanges();

                ubAgregar.Enabled = true;
                ubCerrar.Enabled = true;
                ubConsultar.Enabled = true;
                ugData.Enabled = true;
                ucEntidad.Enabled = true;

                ultraDockManager1.DockAreas[0].Closed = true;
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
            }
            catch (Exception ex)
            {
                Helper.ShowError("Grabar", "Ocurrio un Error", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }      
    }
}
