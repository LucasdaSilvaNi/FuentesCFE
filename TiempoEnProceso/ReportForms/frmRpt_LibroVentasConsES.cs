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
    public partial class frmRpt_LibroVentasConsES : Form
    {
        private TEPEntities db= new TEPEntities(Helper.CadenaConexion);

        public frmRpt_LibroVentasConsES()
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

            if (!uvValidador.Validate("required", false, true).IsValid)
                return false;

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
        }

        private bool Grabar()
        {
            if (!ValidataControles())
                return false;

            try
            {
               
                Cursor = Cursors.WaitCursor;

                string _anio = uteAnio.Value.ToString().PadLeft(4,'0');
                string _mes = uteMes.Value.ToString().PadLeft(2,'0');

                List<rpt_libro_ventas_salvadoreño_Result> lst = db.rpt_libro_ventas_salvadoreño(Helper.Oficina, _mes, _anio, "VENTAS A CONSUMIDORES").ToList();

                if (lst.Count == 0)
                {
                    MessageBox.Show("No existe Información para los Parámetros Seleccionados");
                    return false;
                }

                List<rpt_libro_ventas_salvadoreño_resumen_Result> lstS = db.rpt_libro_ventas_salvadoreño_resumen(Helper.Oficina, _mes, _anio, "VENTAS A CONSUMIDORES").ToList();

                DataSet dsData = Helper.ToDataSet<rpt_libro_ventas_salvadoreño_Result>(lst);
                dsData.Tables[0].TableName = "pwcia";

                DataTable dt = Helper.ToDataSet<rpt_libro_ventas_salvadoreño_resumen_Result>(lstS).Tables[0].Copy();
                dt.TableName = "pwcia_repetido";

                dsData.Tables.Add(dt);                

                frmViewReport frm = new frmViewReport();
                frm._parameters.Add("id_oficina", Helper.Oficina);
                frm._parameters.Add("mes", _mes);
                frm._parameters.Add("anio", _anio);
                frm._parameters.Add("tipo_reporte", "VENTAS A CONSUMIDORES");
                frm._data = dsData;
                frm._reportName = "rpt_libro_ventas_salvadoreño_ventas_a_consumidores.rdlc";
                frm._showStatus = false;
                frm._exportButton = true;
                frm._DynamicSubReport = false;
                frm.Show();
                //Close();
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
            Helper.GetControls<UltraTextEditor>(this.ultraPanel4).ForEach(p => p.Enabled = Enable);

        }
        #endregion

        private void frmRegion_Load(object sender, EventArgs e)
        {
            Helper.SetUltraComboWidth(this);
            uvValidador.NotificationSettings.Caption = Helper.NombreAplicacion;
            EstableceHabilitacion();

            CargaCombos();
            uteAnio.Value = DateTime.Now.Year;
            uteMes.Value = DateTime.Now.Month;
        }

        private void ubAgregar_Click(object sender, EventArgs e)
        {
            if (Grabar())
            {
                //DialogResult = System.Windows.Forms.DialogResult.OK;
                //Close();
            }
        }

        private void ubCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        

        private void ucEncargado_ValueChanged(object sender, EventArgs e)
        {
            /*if (ucEncargado.Value != null &&
                ucEncargado.SelectedRow != null)
            {
                string _socio = ucOficina.Value.ToString();
                string _encargado = ucEncargado.Value.ToString();
                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

                //ucCliente.DataSource = (new ClientesBL()).ListarTodoOficinaEncargadoSocio(_socio, _encargado, _oficina.id_oficina);
                
                
                //ucCliente.Value = Constantes.S_TODOS;
            }*/
        }

        private void ucCliente_ValueChanged(object sender, EventArgs e)
        {
            /*if (ucCliente.Value != null &&
               ucCliente.SelectedRow != null)
            {
                string _socio = ucOficina.Value.ToString();
                string _encargado = ucEncargado.Value.ToString();
                string _cliente = ucCliente.Value.ToString();
                tbl_oficina _oficina = Helper.OficinaActiva as tbl_oficina;

                tbl_empleados _empleado = Helper.UsuarioActivo as tbl_empleados;

                ucServicio.DataSource = (new ServicioBL()).ListarTodos(_cliente, _socio, _encargado, _oficina.id_oficina);
                ucServicio.Value = Constantes.S_TODOS;
            }*/
        }

       
        private void ucOficina_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void uteMes_KeyDown(object sender, KeyEventArgs e)
        {

        }


        
    }
}
