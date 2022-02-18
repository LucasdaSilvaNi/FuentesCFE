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

namespace TiempoEnProceso.Forms
{
    public partial class frmAnulacionSolicitud : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);
        List<tbl_entes_solicitud> lst = new List<tbl_entes_solicitud>();
        List<decimal> lstFac = new List<decimal>();

        public frmAnulacionSolicitud()
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
            var query = from emp in db.tbl_empleados
                        join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                        join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                        where emp.id_empleado == Helper.usuario
                        select ofi;

            tbloficinaBindingSource.DataSource = query.ToList<tbl_oficina>(); 

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
                string strUbicacion = (ucEntidad.SelectedRow.ListObject as tbl_entidad_legal).ubicacion_factura;
                bool Genero = false;
                

                foreach (UltraGridRow ugr in ugData.Rows)
                {
                    Cursor = Cursors.WaitCursor;
                    tbl_entes_solicitud _anu = ugr.ListObject as tbl_entes_solicitud;

                    tbl_solicitud_facturas _tbl = db.tbl_solicitud_facturas.FirstOrDefault(d => d.id_solicitud == _anu.id_solicitud);
                    if (_tbl != null)
                    {
                        _tbl.estado = 2;
                        Genero = true;
                    }
                }

                if (Genero)
                    db.SaveChanges();

                else
                {
                    MessageBox.Show("Debe seleccionar al menos una Solicitud");
                    return false;
                }

                lst.Clear();
                ugData.DataSource = lst;
                ugData.DataBind();
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Anulación de Solicitud Satisfactoria");
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
            Helper.SetUltraComboWidth(this);
            EstableceHabilitacion();
            CargaCombos();
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
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
            tbl_oficina _tbl = db.tbl_oficina.FirstOrDefault(d => d.id_oficina == _oficina);

            if (_tbl != null)
                e.Row.Cells["desc"].Value = string.Format("{0}-{1}", _tbl.id_oficina, _tbl.Nombre.Trim());
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

            IQueryable query = from a in db.tbl_solicitud_facturas
                        join b in db.tbl_entes_solicitud on a.id_solicitud equals b.id_solicitud
                        where a.estado != 2 && b.Estado == 0 &&
                            a.id_oficina == Helper.Oficina &&
                            a.id_entidad == ucEntidad.Value.ToString() &&
                            b.saldo > 0
                        select b;

            lst = query.Cast <tbl_entes_solicitud>().ToList();
            ugData.DataSource = lst;
            ugData.DataBind();
        }

        
      
    }
}
