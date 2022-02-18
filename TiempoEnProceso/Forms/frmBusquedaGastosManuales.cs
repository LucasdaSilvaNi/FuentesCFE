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
using Infragistics.Win.Misc;

namespace TiempoEnProceso.Forms
{
    public partial class frmBusquedaGastosManuales : Form
    {
        TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        public int ID_Trx { get; set; }
        public frmBusquedaGastosManuales()
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

                    using (frmSolicitudFactura frm = new frmSolicitudFactura())
                    {
                        frm.AccionActual = Helper.Acciones.Agregar;
                        if (frm.ShowDialog() == DialogResult.OK)
                            CargaGrid();
                    }
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
            if (e.Cell.Row.Cells["id_transaccion"].Value != null &&
                e.Cell.Row.Cells["id_transaccion"].Value != DBNull.Value)
            {
                ID_Trx = Convert.ToInt32(e.Cell.Row.Cells["id_transaccion"].Value);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
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
                List<tbl_distribucion_gastos> lst = new List<tbl_distribucion_gastos>();
                string periodo = (Helper.OficinaActiva as tbl_oficina).periodo_proceso;
                if (uteCriterio.Value != null)
                {
                    int iTr = 0;                   

                    if (int.TryParse(uteCriterio.Value.ToString(), out iTr))
                        lst = db.tbl_distribucion_gastos.Where(d => d.periodo_tep_proceso == periodo && d.id_oficina == Helper.Oficina && d.id_transaccion == iTr).AsQueryable().ToList();
                    else if (!string.IsNullOrEmpty(uteCriterio.Value.ToString()))
                    {
                        string sVal = uteCriterio.Value.ToString();
                        lst = db.tbl_distribucion_gastos.Where(d => d.periodo_tep_proceso == periodo && d.id_oficina == Helper.Oficina && d.descripcion.Contains(sVal)).AsQueryable().ToList();
                    }
                    
                }
                else
                    lst = db.tbl_distribucion_gastos.Where(d => d.periodo_tep_proceso == periodo && d.id_oficina == Helper.Oficina).AsQueryable().ToList();

                ugData.DataSource = lst;
                ugData.DataBind();
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
           
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ubBuscar_Click(object sender, EventArgs e)
        {
            CargaGrid();
        }
    }
}
