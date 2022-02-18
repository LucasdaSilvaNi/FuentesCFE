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
    public partial class frmJobs : Form
    {
        TEPEntities db = new TEPEntities(Helper.CadenaConexion);
        ValueList clienteVL;
        ValueList servicioVL;

        frmJob frm;

        public frmJobs()
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
                    frm = new frmJob();
                    frm.AccionActual = Helper.Acciones.Agregar;
                    frm.frmJobs = this;
                    frm.Show();
                    /*using (frmJob frm = new frmJob())
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
            JobsEN item = e.Cell.Row.ListObject as JobsEN;

            if (e.Cell.Column.Key == "delete")
            {
                try
                {
                    if (MessageBox.Show(string.Format("Esta seguro de eliminar el Job \"{0} {1}\"?", item.descripcion.Trim()), Helper.NombreAplicacion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //db.tbl_clientes.Remove(item);
                        tbl_trabajos _tb = db.tbl_trabajos.FirstOrDefault(d => d.id_job == item.id_job && d.id_oficina == Helper.Oficina && d.id_servicio == item.id_servicio && d.id_cliente == item.id_cliente);
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
                frm = new frmJob();
                frm.AccionActual = Helper.Acciones.Editar;
                frm.CargarItem(item.id_job, item.id_cliente, item.id_servicio);
                frm.frmJobs = this;
                frm.Show();
                /*using (frmJob frm = new frmJob())
                {
                    Cursor = Cursors.WaitCursor;
                    frm.AccionActual = Helper.Acciones.Editar;
                    frm.CargarItem(item.id_job, item.id_cliente, item.id_servicio);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        tbl_trabajos _tb = db.tbl_trabajos.FirstOrDefault(d => d.id_job == item.id_job && d.id_oficina == Helper.Oficina && d.id_servicio == item.id_servicio && d.id_cliente == item.id_cliente);
                        db.Entry<tbl_trabajos>(_tb).Reload();
                        item.descripcion = string.Format("{0} {1}", _tb.id_job, _tb.descripcion);
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
            servicioVL = new ValueList();

            foreach (ClienteEN _cliente in (new ClientesBL(ref db)).ListarTodoOficina(Helper.Oficina))
                clienteVL.ValueListItems.Add(new ValueListItem(_cliente.id_cliente, string.Format("{0}-{1}", _cliente.id_cliente.Trim(), _cliente.razon_social.Trim())));

            List<ServicioEN> lstA = new List<ServicioEN>();

            db.tbl_servicios.AsQueryable().ToList().ForEach(d => lstA.Add(new ServicioEN() { id_servicio = d.id_servicio, Nombre_largo = d.Nombre_largo }));

            lstA.ForEach(d => servicioVL.ValueListItems.Add(new ValueListItem(d.id_servicio, string.Format("{0}", d.Nombre_largo.Trim()))));
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
                ugData.DataSource = (new JobsBL()).ListarTodos(Helper.Oficina, true,true);
                ugData.DataBind();
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
            ugData.DisplayLayout.Bands[0].Columns["delete"].Hidden = true;
        }
        #endregion

        private void ugData_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            /*using (frmJob frm = new frmJob())
            {*/
            JobsEN item = e.Cell.Row.ListObject as JobsEN;

            Cursor = Cursors.WaitCursor;
            frm = new frmJob();
            frm.AccionActual = Helper.Acciones.Consultar;
            frm.CargarItem(item.id_job, item.id_cliente, item.id_servicio);
            frm.frmJobs = this;
            frm.Show();
            Cursor = Cursors.Default;
            //}
        }

        private void ugData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["id_cliente"].ValueList = clienteVL;
            e.Layout.Bands[0].Columns["id_servicio"].ValueList = servicioVL;
        }

        private void ugData_InitializeRow(object sender, InitializeRowEventArgs e)
        {

        }
    }
}
