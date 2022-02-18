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
    public partial class frmConceptos : Form
    {
        TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        frmConcepto frm;
        public frmConceptos()
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
                    frm = new frmConcepto();
                    frm.AccionActual = Helper.Acciones.Agregar;
                    frm.frmConceptos = this;
                    frm.Show();
                    /*using (frmConcepto frm = new frmConcepto())
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
            tbl_concepto_no_cargable item = e.Cell.Row.ListObject as tbl_concepto_no_cargable;

            if (e.Cell.Column.Key == "delete")
            {
                try
                {
                    if (MessageBox.Show(string.Format("Esta seguro de eliminar el Concepto \"{0}\"?", item.descripcion.Trim()), Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //db.tbl_concepto_no_cargable.Remove(item);
                        item.inactivar = Helper.SI;
                        db.SaveChanges();

                        db.Entry<tbl_concepto_no_cargable>(item).Reload();
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
                frm = new frmConcepto();
                frm.AccionActual = Helper.Acciones.Editar;
                frm.frmConceptos = this;
                frm.CargarItem(item.id_concepto);
                frm.Show();
                /*using (frmConcepto frm = new frmConcepto())
                {
                    Cursor = Cursors.WaitCursor;
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.CargarItem(item.id_concepto);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        db.Entry<tbl_concepto_no_cargable>(item).Reload();
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
        public void CargaGrid(bool checkError = true)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ugData.DataSource = new ConceptosBL().Listar(true);
            }
            catch (Exception ex)
            {
                if (checkError)
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
            /*using (frmConcepto frm = new frmConcepto())
            {*/
            tbl_concepto_no_cargable item = e.Cell.Row.ListObject as tbl_concepto_no_cargable;

            Cursor = Cursors.WaitCursor;
            frm = new frmConcepto();
            frm.AccionActual = Helper.Acciones.Consultar;
            frm.frmConceptos = this;
            frm.CargarItem(item.id_concepto);
            frm.Show();
            Cursor = Cursors.Default;
            //}
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            /*if (e.Row.Cells["inactivar"].Value.ToString() == "1")
                e.Row.CellAppearance.BackColor = Color.LightGray;*/
        }
    }
}
