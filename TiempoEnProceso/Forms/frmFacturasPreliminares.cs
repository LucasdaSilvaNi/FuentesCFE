using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TiempoEnProcesoHelper;
using TiempoEnProcesoBL;
using TiempoEnProcesoDL;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace TiempoEnProceso.Forms
{
    public partial class frmFacturasPreliminares : Form
    {
        TEPEntities db ;

        public string id_oficina { get; set; }
        public string id_entidad { get; set; }

        public tbl_cuenta_corriente factura { get; set; }
        public frmFacturasPreliminares()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
        }

        public frmFacturasPreliminares(ref TEPEntities _db)
        {
            InitializeComponent();
            if (_db == null)
                _db = new TEPEntities(Helper.CadenaConexion);

            db = _db;

        }
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Nuevo":    // ButtonTool
                    // Place code here
                    Cursor = Cursors.WaitCursor;
                    
                    /*using (frmSolicitudFactura frm = new frmSolicitudFactura())
                    {
                        frm.AccionActual = Helper.Acciones.Agregar;
                        if (frm.ShowDialog() == DialogResult.OK)
                            CargaGrid();
                    }*/
                    Cursor = Cursors.Default;
                    
                    break;

                case "Refrescar":    // ButtonTool
                    CargaGrid();
                    break;

                case "Cerrar":    // ButtonTool
                    Close();
                    break;

                case "FilterClean":    // ButtonTool
                    // Place code here
                    break;

            }

        }

        private void ugData_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            tbl_cuenta_corriente item = e.Cell.Row.ListObject as tbl_cuenta_corriente;

            if (e.Cell.Column.Key == "delete")
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    Helper.ShowError("Deleting", "Ocurrio un error", ex);
                }
            }
            else if (e.Cell.Column.Key == "edit")
            {
                factura = item;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
                /*using (frmSolicitudFactura frm = new frmSolicitudFactura())
                {
                    Cursor = Cursors.WaitCursor;
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.CargarItem(item.id_solicitud);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        db.Entry<tbl_solicitud_facturas>(item).Reload();
                        CargaGrid();
                    }

                    Cursor = Cursors.Default;
                }*/
            }
        }

        #region Metodos
        private void CargaCombos()
        {
            

        }
        private void InitialLoad(object sender, EventArgs e)
        {
            Helper.SetUltraComboWidth(this);
            CargaCombos();
            CargaGrid();
            ValidaSeguridad();
        }
        private void CargaGrid()
        {
            try
            {
                tbl_oficina _of = Helper.OficinaActiva as tbl_oficina;
                Cursor = Cursors.WaitCursor;
                IQueryable query = db.tbl_cuenta_corriente.Where(d => d.tipo_documento == "FAC" && d.id_oficina == id_oficina && d.id_entidad == id_entidad && d.estado == 1 &&
                                                                     (d.saldo ?? 0) + (d.saldo_impuesto ?? 0) == d.valor_total).OrderBy(e => e.numero_documento);


                ugData.DataSource = query.Cast<tbl_cuenta_corriente>().ToList();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Carga", "Ocurrio un Error", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ValidaSeguridad()
        {
            /*ultraToolbarsManager1.Tools["Nuevo"].SharedProps.Enabled = ((List<tbl_opciones>)Helper.Permisos).Any(d => d.pantalla == ultraToolbarsManager1.Tools["Nuevo"].SharedProps.Tag.ToString());
            ugData.DisplayLayout.Bands[0].Columns["delete"].Hidden = !((List<tbl_opciones>)Helper.Permisos).Any(d => d.pantalla == ugData.DisplayLayout.Bands[0].Columns["delete"].Tag.ToString());
            ugData.DisplayLayout.Bands[0].Columns["edit"].Hidden = !((List<tbl_opciones>)Helper.Permisos).Any(d => d.pantalla == ugData.DisplayLayout.Bands[0].Columns["edit"].Tag.ToString());*/
        }
        #endregion

        private void ugData_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (e.Cell.Row.Index == 0)
                return;

            /*using (frmFormato frm = new frmFormato())
            {*/
                /*tbl_solicitud_facturas item = e.Cell.Row.ListObject as tbl_solicitud_facturas;

                Cursor = Cursors.WaitCursor;
                frm = new frmSolicitudFactura();
                frm.AccionActual = Helper.Acciones.Consultar;
                frm.CargarItem(item.id_solicitud);
                frm.Show();
                Cursor = Cursors.Default;*/
            //}
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }
    }
}
