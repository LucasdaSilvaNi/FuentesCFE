using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TiempoEnProcesoHelper
{
    public static class Helper
    {
        public enum SqlMode
        {
            SQL = 0,
            Azure = 1
        }

        public enum Acciones
        {
            Agregar,
            Editar,
            Eliminar,
            Buscar,
            Consultar,
            Copiar
        }

        public enum Formas
        {
            Paises
        }

        public const int SI = 1;
        public const int NO = 2;

        public static string NombreAplicacion = "ATISA";
        public static string ACTIVO = "A";
        public static string CR = "60";
        public static string HN = "45,46";
        public static bool EsGt;

        public static string CadenaConexion;

        public static object UsuarioActivo;
        public static object OficinaActiva;
        public static object Permisos;

        public static string servidor;
        public static string db;
        public static string usuario;
        public static string usuarioDB;
        public static string claveUsuario;
        public static string llaveUsuario;
        public static int TimeOut;
        public static string empleado;

        public static string Oficina;
        public static string Pais;
        public static SqlMode sqlMode;
        public static string Style;
        public static bool Continuo;
        public static List<Formas> CambiosForma;

        public static Dictionary<string, DataTable> passData = new Dictionary<string, DataTable>();

        public static void Inicializa()
        {
            sqlMode = Convert.ToInt32(ConfigurationManager.AppSettings["SQLMode"] ?? "0") == 1
                ? SqlMode.Azure
                : SqlMode.SQL;
            string _tiempo = string.Empty;
            if (ConfigurationManager.AppSettings["ManejoRecurso"] == "0")
            {
                servidor = ConfigurationManager.AppSettings["NombreServidor"];
                db = ConfigurationManager.AppSettings["NombreDB"];
                _tiempo = ConfigurationManager.AppSettings["TIEMPOESPERA"];
                TimeOut = Convert.ToInt32(_tiempo);
                usuarioDB = ConfigurationManager.AppSettings["UsuarioDB"];
                llaveUsuario = ConfigurationManager.AppSettings["ClaveDB"];
            }
            else
            {
                servidor = ValidaterUserEncript.Connection.DecriptValue(
                    ConfigurationManager.AppSettings["NombreServidor"]);
                db = ValidaterUserEncript.Connection.DecriptValue(ConfigurationManager.AppSettings["NombreDB"]);
                _tiempo = ValidaterUserEncript.Connection.DecriptValue(
                    ConfigurationManager.AppSettings["TiempoEspera"]);
                TimeOut = Convert.ToInt32(_tiempo);
                usuarioDB = ValidaterUserEncript.Connection.DecriptValue(ConfigurationManager.AppSettings["UsuarioDB"]);
                llaveUsuario =
                    ValidaterUserEncript.Connection.DecriptValue(ConfigurationManager.AppSettings["ClaveDB"]);
            }

            //ShowMessage(MessageBoxIcon.Information, MessageBoxButtons.OK, "Parametros", string.Format("{0}<br/>{1}<br/>{2}<br/>{3}", servidor, db, usuarioDB, llaveUsuario));

            CadenaConexion = ConfigurationManager.ConnectionStrings["TEPEntities"].ConnectionString
                .Replace("SERVIDOR", servidor).Replace("BASEDATOS", db).Replace("USUARIO", usuarioDB)
                .Replace("CLAVE", llaveUsuario).Replace("TIEMPOESPERA", _tiempo);
            CadenaConexion = (sqlMode == SqlMode.SQL) ? CadenaConexion.Replace("@" + servidor, "") : CadenaConexion;
            CadenaConexion = (sqlMode == SqlMode.SQL)
                ? CadenaConexion.Replace(".database.windows.net", "")
                : CadenaConexion;
            CadenaConexion = (sqlMode == SqlMode.SQL)
                ? CadenaConexion.Replace("Integrated Security=False", "persist security info=True")
                : CadenaConexion;
            CadenaConexion = (sqlMode == SqlMode.SQL)
                ? CadenaConexion.Replace("Encrypt=True;TrustServerCertificate=False", "App=EntityFramework")
                : CadenaConexion;

            /*foreach (Formas i in Enum.GetValues(typeof(Formas)))
                CambiosForma.Add(i);*/
            CambiosForma = new List<Formas>();
        }

        public static string Encriptar(string valor)
        {
            string hash = valor;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, valor);
            }

            return hash;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static void ShowError(string Metodo, string Mensaje, Exception ex)
        {
            string error = string.Empty;

            if (ex == null)
                error = "Unknow error";
            else
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.InnerException != null)
                        error = string.Format("<p><b>Exception:</b> {0}</p> <p><b>Inner:</b> {1}</p>", ex.Message,
                            ex.InnerException.InnerException.Message);
                    else
                        error = string.Format("<p><b>Exception:</b> {0}</p> <p><b>Inner:</b> {1}</p>", ex.Message,
                            ex.InnerException.Message);
                }
                else
                {
                    error = string.Format("Exception: {0}", ex.Message);
                }
            }

            string msgErr = string.Empty;
            if (ex == null)
                msgErr = string.Format("<b><font size=\"3\" color=\"red\">{0}</font></b> <p><b>Metodo: </b>{1}</p> ",
                    Mensaje, Metodo);
            else
                msgErr = string.Format(
                    "<b><font size=\"3\" color=\"red\">{0}</font></b> <p><b>Metodo: </b>{1}</p> <p><b>Excepcion:</b> {2}</p> {3}",
                    Mensaje, Metodo, ex == null ? "N/A" : ex.GetType().ToString(), error);

            Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo msg =
                new Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo();
            msg.Icon = MessageBoxIcon.Error;
            msg.Buttons = MessageBoxButtons.OK;
            msg.Caption = Helper.NombreAplicacion;
            msg.HeaderFormatted = "Ocurrio un Error";
            msg.TextFormatted = msgErr;

            Infragistics.Win.UltraMessageBox.UltraMessageBoxManager.Show(msg);

            //System.Windows.Forms.MessageBox.Show(string.Format("{0}\nMetodo: {1}\nExcepcion: {2}\nDescripcion: {3}", Mensaje, Metodo, ex.GetType().ToString(), error), NombreAplicacion, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static DialogResult ShowError(string Metodo, string Mensaje, Exception ex, MessageBoxButtons botones,
            string Encabezado)
        {
            string error = string.Empty;

            if (ex == null)
                error = "Unknow error";
            else
            {
                if (ex.InnerException != null)
                    error = string.Format("<p><b>Exception:</b> {0}</p> <p><b>Inner:</b> {1}</p>", ex.Message,
                        ex.InnerException.Message);
                else
                {
                    error = string.Format("Exception: {0}", ex.Message);
                }
            }

            string msgErr = string.Empty;
            if (ex == null)
                msgErr = string.Format("<b><font size=\"5\" color=\"red\">{0}</font></b> <p><b>Metodo: </b>{1}</p> ",
                    Mensaje, Metodo);
            else
                msgErr = string.Format(
                    "<b><font size=\"5\" color=\"red\">{0}</font></b> <p><b>Metodo: </b>{1}</p> <p><b>Excepcion:</b> {2}</p> {3}",
                    Mensaje, Metodo, ex == null ? "N/A" : ex.GetType().ToString(), error);

            Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo msg =
                new Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo();
            msg.Icon = MessageBoxIcon.Information;
            msg.Buttons = botones;
            msg.Caption = Helper.NombreAplicacion;
            msg.HeaderFormatted = Encabezado;
            msg.TextFormatted = msgErr;

            return Infragistics.Win.UltraMessageBox.UltraMessageBoxManager.Show(msg);

            //System.Windows.Forms.MessageBox.Show(string.Format("{0}\nMetodo: {1}\nExcepcion: {2}\nDescripcion: {3}", Mensaje, Metodo, ex.GetType().ToString(), error), NombreAplicacion, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static void ShowMessage(MessageBoxIcon _icon, MessageBoxButtons _botones, string _header,
            string _message)
        {
            Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo msg =
                new Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo();
            msg.Icon = _icon;
            msg.Buttons = _botones;
            //msg.Caption = Helper.NombreAplicacion;
            msg.HeaderFormatted = _header;
            msg.TextFormatted = _message;

            Infragistics.Win.UltraMessageBox.UltraMessageBoxManager.Show(msg);
        }

        public static void ShowReportMessage(MessageBoxIcon _icon, MessageBoxButtons _botones, string FileName)
        {
            Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo msg =
                new Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo();
            msg.Icon = _icon;
            msg.Buttons = _botones;
            msg.Caption = Helper.NombreAplicacion;
            msg.HeaderFormatted = "Reporte generado exitosamente!!!";
            msg.TextFormatted = "Para ver el archivo de click <a href=\"file://" + FileName + "\">aqui</a>";

            Infragistics.Win.UltraMessageBox.UltraMessageBoxManager.Show(msg);
        }

        public static void SeteaValoresDefecto()
        {
            Infragistics.Shared.ResourceCustomizer rc = Infragistics.Win.Misc.Resources.Customizer;
            rc.SetCustomizedString("Validate_ErrorNotificationMessageHeader",
                "Proceso de validación ha fallado \ncon el(los) siguiente(s) error(es):");

            Style = ConfigurationManager.AppSettings["Style"];
        }

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            t.TableName = elementType.Name;
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = System.Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }

        private static string GetColumnName2(int ColumnSignal)
        {
            string Letra = string.Empty;

            switch (ColumnSignal)
            {
                case 1:
                    Letra = "A";
                    break;
                case 2:
                    Letra = "B";
                    break;
                case 3:
                    Letra = "C";
                    break;
                case 4:
                    Letra = "D";
                    break;
                case 5:
                    Letra = "E";
                    break;
                case 6:
                    Letra = "F";
                    break;
                case 7:
                    Letra = "G";
                    break;
                case 8:
                    Letra = "H";
                    break;
                case 9:
                    Letra = "I";
                    break;
                case 10:
                    Letra = "J";
                    break;
                case 11:
                    Letra = "K";
                    break;
                case 12:
                    Letra = "L";
                    break;
                case 13:
                    Letra = "M";
                    break;
                case 14:
                    Letra = "N";
                    break;
                case 15:
                    Letra = "O";
                    break;
                case 16:
                    Letra = "P";
                    break;
                case 17:
                    Letra = "Q";
                    break;
                case 18:
                    Letra = "R";
                    break;
                case 19:
                    Letra = "S";
                    break;
                case 20:
                    Letra = "T";
                    break;
                case 21:
                    Letra = "U";
                    break;
                case 22:
                    Letra = "V";
                    break;
                case 23:
                    Letra = "W";
                    break;
                case 24:
                    Letra = "X";
                    break;
                case 25:
                    Letra = "Y";
                    break;
                case 26:
                    Letra = "Z";
                    break;
            }

            return Letra;
        }

        public static string GetColumnSignalName(int ColumnSignal)
        {
            ColumnSignal++;
            string ConcatColumn = string.Empty;
            int Resto;
            int Result = Math.DivRem(ColumnSignal, 26, out Resto);
            if (Result == 0)
            {
                ConcatColumn = GetColumnName2(ColumnSignal);
            }
            else
            {
                if (Resto == 0)
                {
                    if (Result == 1)
                    {
                        ConcatColumn = GetColumnName2(ColumnSignal);
                    }
                    else
                    {
                        ConcatColumn = string.Format("{0}Z", GetColumnName2(Result - 1));
                    }
                }
                else
                {
                    ConcatColumn = string.Format("{0}{1}", GetColumnName2(Result),
                        GetColumnName2(ColumnSignal - (26 * Result)));
                }
            }

            return ConcatColumn;
        }

        public static DataSet CrossDataSet(DataSet dsData, DataTable dtColumns, string Field2LinkColumns,
            string Field2LinkData, string Fields2Cross, string Field2Group, string Fields2Sum, bool Totales)
        {
            DataSet ds = new DataSet();
            DataTable dt = dsData.Tables[0].DefaultView.ToTable(true, Field2Group.Split(','));
            foreach (string sAddF in Fields2Sum.Split(','))
                dt.Columns.Add("Total_" + sAddF, dsData.Tables[0].Columns[sAddF].DataType);

            dt.TableName = "data";

            foreach (string sF in Fields2Cross.Split(','))
            {
                string sTotal = string.Empty;
                foreach (DataRow dr in dtColumns.Rows)
                {
                    dt.Columns.Add(string.Format("{0}_{1}", sF, dr[Field2LinkColumns]), typeof(decimal));
                    sTotal += (sTotal.Length > 0 ? "+" : "") +
                              string.Format("ISNULL({0}_{1},0)", sF, dr[Field2LinkColumns]);
                }

                if (Totales)
                    dt.Columns.Add(string.Format("Total_{0}", sF), typeof(decimal), sTotal);
            }

            foreach (DataRow dr in dt.Rows)
            {
                string sCond = string.Empty;
                foreach (string s in Field2Group.Split(','))
                    sCond += (sCond.Length > 0 ? " AND " : "") + string.Format("{0}='{1}'", s, dr[s]);

                foreach (string sF in Fields2Cross.Split(','))
                foreach (DataRow drD in dsData.Tables[0].Select(sCond))
                foreach (string sVF in Field2LinkData.Split(','))
                    dr[string.Format("{0}_{1}", sF, drD[sVF])] =
                        Convert.ToDecimal(dr[string.Format("{0}_{1}", sF, drD[sVF])] == DBNull.Value
                            ? 0
                            : dr[string.Format("{0}_{1}", sF, drD[sVF])]) + Convert.ToDecimal(drD[sF]);

                foreach (string sAddF in Fields2Sum.Split(','))
                {
                    object val = dsData.Tables[0].Compute(string.Format("SUM({0})", sAddF), sCond);
                    dr["Total_" + sAddF] = val == DBNull.Value ? 0 : Convert.ToDecimal(val);
                }
            }

            ds.Tables.Add(dt);
            ds.Tables.Add(dtColumns);
            return ds;
        }

        public static List<T> GetControls<T>(System.Windows.Forms.Control container) where T : Control
        {
            List<T> controls = new List<T>();
            foreach (System.Windows.Forms.Control c in container.Controls)
            {
                if (c is T)
                    controls.Add((T) c);
                controls.AddRange(GetControls<T>(c));
            }

            return controls;
        }

        public static void EnvioMail(string Subject, string Body, string To, string CC, string BCC, string Attachements)
        {
            SmtpClient oMail = new SmtpClient(ConfigurationManager.AppSettings["SMTPServer"]);
            var mail = new MailMessage();
            mail.From = new MailAddress(ConfigurationManager.AppSettings["EMail"], Helper.NombreAplicacion);

            if (!string.IsNullOrEmpty(To))
                foreach (string sTo in To.Split(','))
                    mail.To.Add(sTo);

            if (!string.IsNullOrEmpty(CC))
                foreach (string sCC in CC.Split(','))
                    mail.CC.Add(sCC);

            if (!string.IsNullOrEmpty(BCC))
                foreach (string sBC in BCC.Split(','))
                    mail.Bcc.Add(sBC);

            foreach (string sfile in Attachements.Split(','))
                mail.Attachments.Add(new Attachment(sfile));

            mail.Subject = Subject;
            mail.IsBodyHtml = true;
            mail.Body = Body;

            oMail.Port = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
            oMail.UseDefaultCredentials = false;
            oMail.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EMail"],
                ConfigurationManager.AppSettings["ClaveEMail"]);
            oMail.EnableSsl = true;
            oMail.Send(mail);
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SetData(DataTable dt, string Key)
        {
            if (passData.ContainsKey(empleado + Key))
                passData[empleado + Key] = dt;
            else
                passData.Add(empleado + Key, dt);
        }

        public static bool IsValidPassword(string clave, string id_empleado)
        {
            var input = clave;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            if (clave.ToUpper().Contains(id_empleado.ToUpper()))
                return false;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                //ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                //ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                //ErrorMessage = "Password should not be less than or greater than 8 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                //ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                //ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }

            return true;
        }

        public static void Log(string message)
        {
            System.IO.File.AppendAllText(Application.StartupPath + "\\DB_Log.txt", message);
        }

        public static T SendToFEL<T>(string url_action, string data, string token) where T: class
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);

            HttpWebRequest req = WebRequest.Create(url_action) as HttpWebRequest;

            req.KeepAlive = false;
            req.ContentType = "text/xml; encoding=utf-8";
            req.ContentLength = buffer.Length;
            req.Method = "POST";
            if (!string.IsNullOrEmpty(token))
                req.Headers.Add("Authorization", "Bearer " + token);

            Stream PostData = req.GetRequestStream();
            PostData.Write(buffer, 0, buffer.Length);
            PostData.Close();

            /*ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;*/
            HttpWebResponse response = (HttpWebResponse) req.GetResponse();

            var dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            XDocument xmlDoc = XDocument.Parse(responseFromServer);

            T Xmlresponse = XMLSerializer.Deserialize<T>(xmlDoc.Root.ToString());

            return Xmlresponse;
        }

        public static string GetConfigValue(string key, bool decript = false)
        {
            return decript
                ? ValidaterUserEncript.Connection.DecriptValue(ConfigurationManager.AppSettings[key])
                : ConfigurationManager.AppSettings[key];
        }
        
        public static void SetUltraComboWidth(Form form)
        {
            GetControls<UltraPanel>(form).ForEach(u =>
            {
                GetControls<UltraCombo>(u).ForEach(d => d.DropDownWidth = 0);
            });
        }
     
    }
}