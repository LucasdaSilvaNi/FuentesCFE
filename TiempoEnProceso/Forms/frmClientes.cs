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
    public partial class frmClientes : Form
    {
        TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        //frmCliente frm ;
        public string id_cliente { get; set; }

        public frmClientes()
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
                    /*frm = new frmCliente();
                    frm.AccionActual = Helper.Acciones.Agregar;

                    /*using (frmCliente frm = new frmCliente())
                    {
                        frm.AccionActual = Helper.Acciones.Agregar;
                        frm.Show();
                        
                        /*if (frm.ShowDialog() == DialogResult.OK)
                            CargaGrid();/
                    }*
                    frm.Show();*/
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
            ClienteEN item = e.Cell.Row.ListObject as ClienteEN;

            if (e.Cell.Column.Key == "delete")
            {
                try
                {
                    if (MessageBox.Show(string.Format("Esta seguro de eliminar el Cliente \"{0} {1}\"?", item.razon_social.Trim()), Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //db.tbl_clientes.Remove(item);
                        tbl_clientes _tb = db.tbl_clientes.FirstOrDefault(d => d.id_cliente == item.id_cliente && d.id_pais == Helper.Oficina);
                        if (_tb != null)
                            _tb.estado = Helper.NO; 

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

                id_cliente = item.id_cliente;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
                /*frm = new frmCliente();
                frm.AccionActual = Helper.Acciones.Editar;
                frm.CargarItem(item.id_cliente);
                frm.Show();*/
                /*using (frmCliente frm = new frmCliente())
                {
                    Cursor = Cursors.WaitCursor;
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.CargarItem(item.id_cliente);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        tbl_clientes _tb = db.tbl_clientes.FirstOrDefault(d => d.id_cliente == item.id_cliente && d.id_pais == Helper.Oficina);
                        db.Entry<tbl_clientes>(_tb).Reload();
                        item.razon_social = string.Format("{0} {1}", _tb.id_cliente, _tb.Razon_Social);
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
                Cursor = Cursors.WaitCursor;
                ClientesBL unBL = new ClientesBL(ref db);
                ugData.DataSource = unBL.ListarTodoLight(Helper.Oficina);
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
            ugData.DisplayLayout.Bands[0].Columns["delete"].Hidden = true;
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
    }
}
