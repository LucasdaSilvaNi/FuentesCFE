using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TiempoEnProcesoBL;
using TiempoEnProcesoDL;
using TiempoEnProcesoHelper;
using System.Globalization;

namespace TiempoEnProceso
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            var cultureInfo = "es-GT";
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureInfo);

            Helper.SeteaValoresDefecto();

            using (frmPrincipal frm = new frmPrincipal())
            {
                Infragistics.Win.AppStyling.StyleManager.Load(frm.AsignarEstilo(Helper.Style));
            }
        }

        private void ubAceptar_Click(object sender, EventArgs e)
        {
            

            if (!ultraValidator1.Validate("required", false, true).IsValid)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                Helper.Inicializa();
                TEPEntities db = new TEPEntities(Helper.CadenaConexion);
                EmpleadosBL empBL = new EmpleadosBL();
                Helper.UsuarioActivo = empBL.ValidarIngreso(uteUsuario.Value.ToString(), uteClave.Value.ToString());
                if (Helper.UsuarioActivo == null)
                    throw new Exception("Error");

                Helper.usuario = uteUsuario.Value.ToString().Trim();
                Helper.claveUsuario = uteClave.Value.ToString();

                if (!empBL.TipoValidacion() && empBL.CambiaClave(uteUsuario.Value.ToString()))
                {
                    using (frmCambiaClave frm = new frmCambiaClave())
                    {
                        frm.mandatorio = true;
                        frm.ShowDialog();
                    }
                }

                var query = from emp in db.tbl_empleados
                            join niv in db.tbl_niveles_empleado on emp.id_empleado equals niv.id_empleado
                            join ofi in db.tbl_oficina on niv.id_oficina equals ofi.id_oficina
                            where emp.id_empleado == Helper.usuario
                            select ofi;

                if (query.ToList().Count > 1)
                {
                    using (frmSelOficina _frm = new frmSelOficina())
                    {
                        if (_frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        { }
                        else
                        {
                            DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            return;
                        }
                    }
                }
                else
                {

                    Helper.Oficina = (Helper.UsuarioActivo as tbl_empleados).id_oficina;
                    Helper.OficinaActiva = (new OficinaBL()).DevuelveDatosOficina(Helper.Oficina);
                    
                }
                

                if (Helper.OficinaActiva == null)
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    return;
                }
                Helper.Pais = (Helper.OficinaActiva as tbl_oficina).id_pais;
                Helper.EsGt = (new PaisBL()).EsGt(Helper.Pais);
                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Advertencia", "La información que se almacena y se procesa es propiedad de ATISA.\nAl accesar y utilizar este sistema usted esa aceptando la supervisión y monitoreo del mismo para la aplicación de la ley y otros propósitos.\nEl uso no autorizado de este sistema puede conllevarle a penas criminales y/o sanciones de la compañia.");

                Helper.Permisos = (new PermisosBL()).ListarPorEmpleado(Helper.usuario);
                Cursor = Cursors.Default;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Helper.ShowError("Login", "Usuario/clave Invalida", null);
                //MessageBox.Show("Usuario/clave Invalida", Helper.NombreAplicacion,  MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void uteUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                uteClave.Focus();
        }

        private void uteClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ubAceptar.Focus();
        }
    }
}
