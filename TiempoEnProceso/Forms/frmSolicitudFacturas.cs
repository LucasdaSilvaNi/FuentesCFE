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
    public partial class frmSolicitudFacturas : Form
    {
        TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        ValueList clienteVL;
        frmSolicitudFactura frm ;
        public decimal id_solicitud { get; set; }
        public frmSolicitudFacturas()
        {
            InitializeComponent();
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Nuevo":    // ButtonTool
                    // Place code here
                    Cursor = Cursors.WaitCursor;
                    frm = new frmSolicitudFactura();
                    frm.AccionActual = Helper.Acciones.Agregar;
                    frm.Show();
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
            tbl_solicitud_facturas item = e.Cell.Row.ListObject as tbl_solicitud_facturas;

            if (e.Cell.Column.Key == "delete")
            {
                try
                {
                    if (MessageBox.Show(string.Format("Esta seguro de eliminar la Solicitud de Factura # \"{0}\"?", item.id_solicitud), Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.tbl_solicitud_facturas.Remove(item);

                        List<tbl_det_Solicitud> lst = db.tbl_det_Solicitud.Where(d => d.id_solicitud == item.id_solicitud).ToList();
                        db.tbl_det_Solicitud.RemoveRange(lst.AsEnumerable());

                        //item.Status = Helper.NO;
                        db.SaveChanges();

                        CargaGrid();
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowError("Deleting", "Ocurrio un error", ex);
                }
            }
            else if (e.Cell.Column.Key == "edit")
            {
                id_solicitud = item.id_solicitud;
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
            clienteVL = new ValueList();
            (new ClientesBL()).ListarTodo(Helper.Oficina).ForEach(d=>
                clienteVL.ValueListItems.Add(d.id_cliente, string.Format("{0}",d.razon_social.Trim()))
            );

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
                IQueryable query = from a in db.tbl_solicitud_facturas
                            join b in db.tbl_clientes on a.id_cliente equals b.id_cliente
                            join c in db.tbl_trabajos on new { id_pais = b.id_pais, id_job = a.id_job, id_cliente = b.id_cliente } equals new { id_pais = c.id_pais, id_job = c.id_job, id_cliente = c.id_cliente }
                            where a.situacion == "N" && a.estado == 0 && b.id_pais == _of.id_pais && a.id_oficina == _of.id_oficina
                            orderby a.id_solicitud
                            select a;


                ugData.DataSource = query.Cast<tbl_solicitud_facturas>().ToList();
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
            e.Layout.Bands[0].Columns["id_cliente"].ValueList = clienteVL;
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }
    }
}
