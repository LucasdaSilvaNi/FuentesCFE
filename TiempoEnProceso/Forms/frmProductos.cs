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
    public partial class frmProductos : Form
    {
        TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        frmProducto frm;
        public frmProductos()
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
                    frm = new frmProducto();
                    frm.AccionActual = Helper.Acciones.Agregar;
                    frm.frmProductos = this;
                    frm.Show();
                    /*using (frmProducto frm = new frmProducto())
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
            tbl_departamento item = e.Cell.Row.ListObject as tbl_departamento;

            if (e.Cell.Column.Key == "delete")
            {
                try
                {
                    if (MessageBox.Show(string.Format("Esta seguro de eliminar el Departamento \"{0}\"?", item.Nombre_largo.Trim()), Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        db.tbl_departamento.Remove(item);
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
                frm = new frmProducto();
                frm.AccionActual = Helper.Acciones.Editar;
                frm.frmProductos = this;
                frm.CargarItem(item.id_departamento);
                frm.Show();
                /*using (frmProducto frm = new frmProducto())
                {
                    Cursor = Cursors.WaitCursor;
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.CargarItem(item.id_departamento);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        db.Entry<tbl_departamento>(item).Reload();
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
                ugData.DataSource = new DeptoBL().ListarTodos(true);
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
            /*using (frmProducto frm = new frmProducto())
            {*/
            tbl_departamento item = e.Cell.Row.ListObject as tbl_departamento;

            Cursor = Cursors.WaitCursor;
            frm = new frmProducto();
            frm.AccionActual = Helper.Acciones.Consultar;
            frm.frmProductos = this;
            frm.CargarItem(item.id_departamento);
            frm.Show();
            Cursor = Cursors.Default;
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
