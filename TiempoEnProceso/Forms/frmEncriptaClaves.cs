using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiempoEnProcesoDL;
using TiempoEnProcesoHelper;

namespace TiempoEnProceso.Forms
{
    public partial class frmEncriptaClaves : Form
    {
        public frmEncriptaClaves()
        {
            InitializeComponent();
        }

        private void ubCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ubProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                TEPEntities db = new TEPEntities(Helper.CadenaConexion);

                bool ValidaAntigua = false;
                tbl_parametros param = db.tbl_parametros.FirstOrDefault(d => d.id_parametro == "Modo_clave");
                if (param == null)
                    ValidaAntigua = true;
                else if (param.valor_numerico == 0)
                    ValidaAntigua = true;

                if (ValidaAntigua)
                {
                    if (db.tbl_claves_empleado.Any())
                    {
                        Helper.ShowError("Encripción", "Proceso ya fue ejecutado", null, MessageBoxButtons.OK, "Error");
                        return;
                    }

                    param = db.tbl_parametros.FirstOrDefault(d => d.id_parametro == "expiracion_clave");
                    if (param == null)
                    {
                        Helper.ShowError("Encripción", "No existe el parámetro para vencimiento de clave", null, MessageBoxButtons.OK, "Error");
                        return;
                    }

                    double dVenc = (double)param.valor_numerico;
                    IQueryable qry = from emp in db.tbl_empleados
                                     select emp;

                    qry.Cast<tbl_empleados>().ToList().ForEach(d =>
                    {
                        tbl_claves_empleado tbl = new tbl_claves_empleado()
                        {
                            activo = true,
                            cambia_clave = true,
                            clave = Helper.Encriptar(d.clave.Trim()),
                            fecha_clave = DateTime.Now.Date,
                            fecha_expiracion = DateTime.Now.Date.AddDays(dVenc),
                            id_empleado = d.id_empleado
                        };
                        db.tbl_claves_empleado.Add(tbl);
                    });
                }
                else
                {
                    IQueryable qry = from emp in db.tbl_empleados
                                     select emp;

                    qry.Cast<tbl_empleados>().ToList().ForEach(d =>
                    {
                        d.clave = Guid.NewGuid().ToString().Replace("-", "").Substring(0,15);
                    });
                }

                db.SaveChanges();

                Helper.ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Encripción", "Proceso finalizado Satisfactoriamente");
            }
            catch (Exception ex)
            {
                Helper.ShowError("Encripción", "Ocurrio un Error", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
