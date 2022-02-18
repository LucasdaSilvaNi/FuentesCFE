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

namespace TiempoEnProceso.Forms
{
    public partial class frmEmpleadoOpciones : Form
    {
        public tbl_empleados Item { get; set; }
        public Helper.Acciones AccionActual { get; set; }
        private ValueList opcionesVL;
        private ValueList menuVL;
        private List<tbl_opciones_empleado> lstO;

        private TEPEntities db;

        public frmEmpleadoOpciones()
        {
            InitializeComponent();
            db = new TEPEntities(Helper.CadenaConexion);
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

            if (!uvValidador.Validate("required", false, true).IsValid)
                return false;

            string _id = uteID.Value.ToString();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                if (db.tbl_empleados.Any(d => d.id_empleado==_id))
                {
                    MessageBox.Show("Empleado ya Existe", Helper.NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (AccionActual == Helper.Acciones.Editar)
            {
            }


            return true;
        }

        private void LimpiaEspacios()
        {
            if (uteID.Value != null)
                uteID.Value = uteID.Value.ToString().Trim();

            if (uteDescripcion.Value != null)
                uteDescripcion.Value = uteDescripcion.Value.ToString().Trim();
        }

        public void CargarItem(string _empleado)
        {
            Item = db.tbl_empleados.FirstOrDefault(d => d.id_empleado == _empleado);
            lstO = db.tbl_opciones_empleado.Where(d => d.id_empleado == Item.id_empleado).OrderBy(d=> d.menu).ToList<tbl_opciones_empleado>();

            CargaCombos();
            AsignaCampos();
        }

        private void AsignaCampos()
        {
            uteID.Value = Item.id_empleado;
            uteDescripcion.Value = Item.Nombres.Trim() + " " + Item.apellidos.Trim();

            ugDataPermisos.DataSource = lstO;
        }

        public void CargaCombos()
        {
            opcionesVL = new ValueList();
            menuVL = new ValueList();

            foreach (tbl_opciones pry in db.tbl_opciones.ToList())
            {
                menuVL.ValueListItems.Add(new ValueListItem(pry.menu, string.Format("{0}", pry.menu, pry.opcion.Trim())));
                opcionesVL.ValueListItems.Add(new ValueListItem(pry.pantalla, string.Format("{1}", pry.menu, pry.opcion.Trim())));
            }

            ucOpcion.DataSource = db.tbl_opciones.OrderBy(d => d.opcion).ToList();
        }


        private bool Grabar()
        {
            if (AccionActual == Helper.Acciones.Consultar)
                return true;

            if (!ValidataControles())
                return false;

            try
            {
                ConstruyeItem();

                /*if (AccionActual == Helper.Acciones.Agregar)
                    db.tbl_puestos.Add(Item);*/

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Helper.ShowError("Save", "Error al guardar", ex);
                return false;
            }

            return true;
        }

        private void ConstruyeItem()
        {
            /*if (AccionActual == Helper.Acciones.Agregar)
                Item.id_puesto = uteID.Value.ToString();

            Item.descripcion = uteDescripcion.Value.ToString();
            Item.id_nivel = Convert.ToDecimal(uneNivel.Value);*/

            foreach (tbl_opciones_empleado _op in (List<tbl_opciones_empleado>)ugDataPermisos.DataSource)
            {
                if (!db.tbl_opciones_empleado.Any(d => d.id_empleado == _op.id_empleado && d.menu == _op.menu && d.opcion == _op.opcion))
                    db.tbl_opciones_empleado.Add(_op);
            }
        }

        private void EstableceHabilitacion()
        {
            switch (AccionActual)
            {
                case Helper.Acciones.Agregar:
                    break;
                case Helper.Acciones.Consultar:
                    SetEnableControls(false);
                    ugDataPermisos.Enabled = false;
                    ucOpcion.Enabled = false;
                    ubAgregar.Enabled = false;
                    break;
                case Helper.Acciones.Editar:
                    SetEnableControls(false);
                    break;
            }
        }

        private void NuevoItem()
        {
            Item = new  tbl_empleados();
            uteID.Value = null;
            uteDescripcion.Value = null;
            
            uteID.Focus();

        }

        private void SetEnableControls(bool Enable)
        {
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
            Helper.GetControls<UltraNumericEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);
        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - {1}", AccionActual.ToString(), this.Text);
            Helper.SetUltraComboWidth(this);

            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();

            CargaCombos();

            if (AccionActual == Helper.Acciones.Agregar)
            {
                NuevoItem();
            }

            uteID.Focus();

        }



        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Grabar", "Registro Grabado Satisfactoriamente");
                if (Helper.Continuo && AccionActual == Helper.Acciones.Agregar)
                    NuevoItem();
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            if (Helper.Continuo)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;

            Close();
        }

        private void uteDescripcion_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ucPais_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }


        private void uteDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteDescripcion, true, true, true, true);
        }

        private void uteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(uteID, true, true, true, true);
        }


        private void btAgregar_Click(object sender, EventArgs e)
        {
             if (ucOpcion.Value != null &&
                ucOpcion.SelectedRow != null)
            {
                 string _o = uteID.Value.ToString();
                 
                 tbl_opciones op = ucOpcion.SelectedRow.ListObject as tbl_opciones;
                 if (!lstO.Any(d => d.id_empleado == _o && d.menu == op.menu && d.opcion == op.opcion))
                 {
                     tbl_opciones_empleado _opU = new tbl_opciones_empleado();
                     _opU.id_empleado = uteID.Value.ToString();
                     _opU.id_oficina = Helper.Oficina;
                     _opU.menu = op.menu;
                     _opU.opcion = op.opcion;
                     lstO.Add(_opU);

                     ugDataPermisos.DataBind();
                 }
            }
        }

        private void ugDataPermisos_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ColumnsCollection cols = e.Layout.Bands[0].Columns;

            foreach (UltraGridColumn c in cols)
                c.Hidden = true;

            cols["menu"].Hidden = false;
            cols["menu"].Header.Caption = "Menu";
            cols["menu"].CellActivation = Activation.NoEdit;
            cols["menu"].ValueList = menuVL;

            cols["opcion"].Hidden = false;
            cols["opcion"].Header.Caption = "Opcion";
            cols["opcion"].CellActivation = Activation.NoEdit;
            cols["opcion"].ValueList = opcionesVL;
            if (!cols.Exists("sel"))
                cols.Add("sel", "");

            cols["sel"].Hidden = false;
            cols["sel"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            cols["sel"].CellButtonAppearance.Image = TiempoEnProceso.Properties.Resources.Menos;
            cols["sel"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            cols["sel"].MaxWidth = 20;
            cols["sel"].MinWidth = 20;
            cols["sel"].Header.VisiblePosition = 0;
        }

        private void ugDataPermisos_ClickCellButton(object sender, CellEventArgs e)
        {
            tbl_opciones_empleado _tb = e.Cell.Row.ListObject as tbl_opciones_empleado;

            if (db.tbl_opciones_empleado.Any(d => d.id_empleado == _tb.id_empleado && d.menu == _tb.menu && d.opcion == _tb.opcion))
                db.tbl_opciones_empleado.Remove(e.Cell.Row.ListObject as tbl_opciones_empleado);
            
            lstO.Remove(e.Cell.Row.ListObject as tbl_opciones_empleado);
            ugDataPermisos.DataBind();
        }

        private void ucOpcion_ItemNotInList(object sender, Infragistics.Win.UltraWinEditors.ValidationErrorEventArgs e)
        {
            e.RetainFocus = false;
        }

        private void ucOpcion_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.ReInitialize) return;

            e.Row.Cells["desc"].Value = string.Format("{0}-{1}", e.Row.Cells["menu"].Value.ToString().Trim(), e.Row.Cells["opcion"].Value.ToString().Trim());
        }

       
    }
}
