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
using TiempoEnProcesoEN;

namespace TiempoEnProceso.Forms
{
    public partial class frmJerarquiasOpciones : Form
    {
        TEPEntities db = new TEPEntities(Helper.CadenaConexion);

        public frmJerarquiasOpciones()
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

                    using (frmJerarquiaOpciones frm = new frmJerarquiaOpciones())
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
            PuestoEN item = e.Cell.Row.ListObject as PuestoEN;

            if (e.Cell.Column.Key == "edit")
            {
                using (frmJerarquiaOpciones frm = new frmJerarquiaOpciones())
                {
                    Cursor = Cursors.WaitCursor;
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.CargarItem(item.id_puesto);
                    if (frm.ShowDialog() == DialogResult.OK)
                        CargaGrid();

                    Cursor = Cursors.Default;
                }
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
                Cursor = Cursors.WaitCursor;
                PuestosBL unBL = new PuestosBL(ref db);
                ugData.DataSource = unBL.ListarTodos();
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
            using (frmJerarquiaOpciones frm = new frmJerarquiaOpciones())
            {
                PuestoEN item = e.Cell.Row.ListObject as PuestoEN;

                Cursor = Cursors.WaitCursor;
                frm.AccionActual = Helper.Acciones.Consultar;
                frm.CargarItem(item.id_puesto);
                frm.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }
    }
}
