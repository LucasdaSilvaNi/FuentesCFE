namespace TiempoEnProceso.Forms
{
    partial class frmEntidad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("tbl_frases", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id_tbl_frase");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo_Escenario");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tipo_Frase");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id_oficina");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id_entidad");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tbl_entidad_legal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("edit", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntidad));
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("delete", 1);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Eliminar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Agregar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Misc.ValidationGroup validationGroup1 = new Infragistics.Win.Misc.ValidationGroup("required");
            Infragistics.Win.Misc.ValidationGroup validationGroup2 = new Infragistics.Win.Misc.ValidationGroup("requiredData");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Cancelar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Grabar", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraPanel4 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.uteFormatoFEL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.uteClaveCertificado = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.uteApi = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uckActivo = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.uteAcceso = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uckEntidad = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.uteOrigen = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.uteFormato = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ubFolder = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.uteUbicacion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.uneImpuesto = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.uneAnulaciones = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.uneNotas = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.uneCobranzas = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.uneFacturas = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.uteNit = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.uteOficina = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uckIncluido = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uteDireccion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.uteId = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.uteDescripcion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.ugData = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tblfrasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ubEliminaData = new Infragistics.Win.Misc.UltraButton();
            this.ubAgregarData = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.uneTipFrase = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.uneEscenario = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.uvValidador = new Infragistics.Win.Misc.UltraValidator(this.components);
            this.ultraPanel3 = new Infragistics.Win.Misc.UltraPanel();
            this.ubCerrar = new Infragistics.Win.Misc.UltraButton();
            this.ubAgregar = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._frmUsuario_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.tblSeriesPorCajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblpaisesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.periodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraPanel4.ClientArea.SuspendLayout();
            this.ultraPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uteFormatoFEL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClaveCertificado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteApi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteAcceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckEntidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteFormato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteUbicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneImpuesto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneAnulaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneNotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCobranzas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOficina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckIncluido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblfrasesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneTipFrase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneEscenario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).BeginInit();
            this.ultraPanel3.ClientArea.SuspendLayout();
            this.ultraPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSeriesPorCajaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpaisesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ultraPanel4);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(593, 411);
            // 
            // ultraPanel4
            // 
            // 
            // ultraPanel4.ClientArea
            // 
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel16);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteFormatoFEL);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel17);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteClaveCertificado);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel14);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteApi);
            this.ultraPanel4.ClientArea.Controls.Add(this.uckActivo);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel15);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteAcceso);
            this.ultraPanel4.ClientArea.Controls.Add(this.uckEntidad);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel13);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteOrigen);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraButton1);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel12);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteFormato);
            this.ultraPanel4.ClientArea.Controls.Add(this.ubFolder);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel11);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteUbicacion);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel10);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneImpuesto);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel8);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneAnulaciones);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel9);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneNotas);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel5);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneCobranzas);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel3);
            this.ultraPanel4.ClientArea.Controls.Add(this.uneFacturas);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel6);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteNit);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel4);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteOficina);
            this.ultraPanel4.ClientArea.Controls.Add(this.uckIncluido);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel2);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteDireccion);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteId);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel1);
            this.ultraPanel4.ClientArea.Controls.Add(this.ultraLabel7);
            this.ultraPanel4.ClientArea.Controls.Add(this.uteDescripcion);
            this.ultraPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel4.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel4.Name = "ultraPanel4";
            this.ultraPanel4.Size = new System.Drawing.Size(593, 411);
            this.ultraPanel4.TabIndex = 20;
            // 
            // ultraLabel16
            // 
            this.ultraLabel16.AutoSize = true;
            this.ultraLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel16.Location = new System.Drawing.Point(23, 366);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(70, 14);
            this.ultraLabel16.TabIndex = 46;
            this.ultraLabel16.Text = "Formato FEL";
            // 
            // uteFormatoFEL
            // 
            this.uteFormatoFEL.Location = new System.Drawing.Point(113, 362);
            this.uteFormatoFEL.MaxLength = 60;
            this.uteFormatoFEL.Name = "uteFormatoFEL";
            this.uteFormatoFEL.Size = new System.Drawing.Size(366, 21);
            this.uteFormatoFEL.TabIndex = 18;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel17.Location = new System.Drawing.Point(23, 333);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(75, 30);
            this.ultraLabel17.TabIndex = 45;
            this.ultraLabel17.Text = "Clave Certificado:";
            // 
            // uteClaveCertificado
            // 
            this.uteClaveCertificado.Location = new System.Drawing.Point(113, 335);
            this.uteClaveCertificado.MaxLength = 60;
            this.uteClaveCertificado.Name = "uteClaveCertificado";
            this.uteClaveCertificado.Size = new System.Drawing.Size(366, 21);
            this.uteClaveCertificado.TabIndex = 17;
            // 
            // ultraLabel14
            // 
            this.ultraLabel14.AutoSize = true;
            this.ultraLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel14.Location = new System.Drawing.Point(23, 312);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(58, 14);
            this.ultraLabel14.TabIndex = 42;
            this.ultraLabel14.Text = "Clave API:";
            // 
            // uteApi
            // 
            this.uteApi.Location = new System.Drawing.Point(113, 308);
            this.uteApi.MaxLength = 60;
            this.uteApi.Name = "uteApi";
            this.uteApi.Size = new System.Drawing.Size(366, 21);
            this.uteApi.TabIndex = 16;
            this.uteApi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteApi_KeyDown);
            // 
            // uckActivo
            // 
            this.uckActivo.AutoSize = true;
            this.uckActivo.Location = new System.Drawing.Point(113, 389);
            this.uckActivo.Name = "uckActivo";
            this.uckActivo.Size = new System.Drawing.Size(52, 17);
            this.uckActivo.TabIndex = 36;
            this.uckActivo.Text = "Activo";
            this.uckActivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uckActivo_KeyDown);
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.AutoSize = true;
            this.ultraLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel15.Location = new System.Drawing.Point(22, 312);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(77, 14);
            this.ultraLabel15.TabIndex = 41;
            this.ultraLabel15.Text = "Clave Acceso:";
            this.ultraLabel15.Visible = false;
            // 
            // uteAcceso
            // 
            this.uteAcceso.Location = new System.Drawing.Point(113, 308);
            this.uteAcceso.MaxLength = 60;
            this.uteAcceso.Name = "uteAcceso";
            this.uteAcceso.Size = new System.Drawing.Size(366, 21);
            this.uteAcceso.TabIndex = 15;
            this.uteAcceso.Visible = false;
            this.uteAcceso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteAcceso_KeyDown);
            // 
            // uckEntidad
            // 
            this.uckEntidad.AutoSize = true;
            this.uckEntidad.Location = new System.Drawing.Point(323, 199);
            this.uckEntidad.Name = "uckEntidad";
            this.uckEntidad.Size = new System.Drawing.Size(116, 17);
            this.uckEntidad.TabIndex = 11;
            this.uckEntidad.Text = "Entidad Financiera";
            this.uckEntidad.CheckedChanged += new System.EventHandler(this.uckFacturar_CheckedChanged);
            this.uckEntidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uckFacturar_KeyDown);
            // 
            // ultraLabel13
            // 
            this.ultraLabel13.AutoSize = true;
            this.ultraLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel13.Location = new System.Drawing.Point(23, 285);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(74, 14);
            this.ultraLabel13.TabIndex = 38;
            this.ultraLabel13.Text = "Origen Datos:";
            // 
            // uteOrigen
            // 
            this.uteOrigen.Location = new System.Drawing.Point(113, 281);
            this.uteOrigen.MaxLength = 60;
            this.uteOrigen.Name = "uteOrigen";
            this.uteOrigen.Size = new System.Drawing.Size(366, 21);
            this.uteOrigen.TabIndex = 14;
            this.uteOrigen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteOrigen_KeyDown);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(505, 252);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(29, 23);
            this.ultraButton1.TabIndex = 36;
            this.ultraButton1.TabStop = false;
            this.ultraButton1.Text = "...";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraLabel12
            // 
            this.ultraLabel12.AutoSize = true;
            this.ultraLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel12.Location = new System.Drawing.Point(22, 258);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(91, 14);
            this.ultraLabel12.TabIndex = 35;
            this.ultraLabel12.Text = "Formato Factura:";
            // 
            // uteFormato
            // 
            this.uteFormato.Location = new System.Drawing.Point(113, 254);
            this.uteFormato.MaxLength = 60;
            this.uteFormato.Name = "uteFormato";
            this.uteFormato.Size = new System.Drawing.Size(386, 21);
            this.uteFormato.TabIndex = 13;
            this.uteFormato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteFormato_KeyDown);
            // 
            // ubFolder
            // 
            this.ubFolder.Location = new System.Drawing.Point(505, 225);
            this.ubFolder.Name = "ubFolder";
            this.ubFolder.Size = new System.Drawing.Size(29, 23);
            this.ubFolder.TabIndex = 33;
            this.ubFolder.TabStop = false;
            this.ubFolder.Text = "...";
            this.ubFolder.Click += new System.EventHandler(this.ubFolder_Click);
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel11.Location = new System.Drawing.Point(23, 221);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(64, 29);
            this.ultraLabel11.TabIndex = 32;
            this.ultraLabel11.Text = "Formato factura 1:";
            // 
            // uteUbicacion
            // 
            this.uteUbicacion.Location = new System.Drawing.Point(113, 227);
            this.uteUbicacion.MaxLength = 60;
            this.uteUbicacion.Name = "uteUbicacion";
            this.uteUbicacion.Size = new System.Drawing.Size(386, 21);
            this.uteUbicacion.TabIndex = 12;
            this.uteUbicacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteUbicacion_KeyDown);
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.AutoSize = true;
            this.ultraLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel10.Location = new System.Drawing.Point(22, 199);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(56, 14);
            this.ultraLabel10.TabIndex = 30;
            this.ultraLabel10.Text = "Impuesto:";
            // 
            // uneImpuesto
            // 
            this.uneImpuesto.Location = new System.Drawing.Point(113, 195);
            this.uneImpuesto.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneImpuesto.MaskInput = "nn";
            this.uneImpuesto.MaxValue = 99;
            this.uneImpuesto.MinValue = 0;
            this.uneImpuesto.Name = "uneImpuesto";
            this.uneImpuesto.Size = new System.Drawing.Size(43, 21);
            this.uneImpuesto.TabIndex = 9;
            this.uneImpuesto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneImpuesto_KeyDown);
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel8.Location = new System.Drawing.Point(323, 166);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(88, 37);
            this.ultraLabel8.TabIndex = 28;
            this.ultraLabel8.Text = "Correlativo Anulaciones";
            // 
            // uneAnulaciones
            // 
            this.uneAnulaciones.Location = new System.Drawing.Point(414, 168);
            this.uneAnulaciones.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneAnulaciones.MaskInput = "nnnnnnnn";
            this.uneAnulaciones.MinValue = 0;
            this.uneAnulaciones.Name = "uneAnulaciones";
            this.uneAnulaciones.Size = new System.Drawing.Size(120, 21);
            this.uneAnulaciones.TabIndex = 8;
            this.uvValidador.GetValidationSettings(this.uneAnulaciones).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneAnulaciones).NotificationSettings.Text = "Correlativo Anulaciones Invalido";
            this.uvValidador.GetValidationSettings(this.uneAnulaciones).ValidationGroupKey = "required";
            this.uneAnulaciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneAnulaciones_KeyDown);
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel9.Location = new System.Drawing.Point(22, 166);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(77, 37);
            this.ultraLabel9.TabIndex = 26;
            this.ultraLabel9.Text = "Correlativo Notas:";
            // 
            // uneNotas
            // 
            this.uneNotas.Location = new System.Drawing.Point(113, 168);
            this.uneNotas.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneNotas.MaskInput = "nnnnnnnn";
            this.uneNotas.MinValue = 0;
            this.uneNotas.Name = "uneNotas";
            this.uneNotas.Size = new System.Drawing.Size(120, 21);
            this.uneNotas.TabIndex = 7;
            this.uvValidador.GetValidationSettings(this.uneNotas).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneNotas).NotificationSettings.Text = "Correlativo Notas Invalido";
            this.uvValidador.GetValidationSettings(this.uneNotas).ValidationGroupKey = "required";
            this.uneNotas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneNotas_KeyDown);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel5.Location = new System.Drawing.Point(323, 136);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(88, 35);
            this.ultraLabel5.TabIndex = 24;
            this.ultraLabel5.Text = "Correlativo Cobranzas:";
            // 
            // uneCobranzas
            // 
            this.uneCobranzas.Location = new System.Drawing.Point(414, 141);
            this.uneCobranzas.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneCobranzas.MaskInput = "nnnnnnnn";
            this.uneCobranzas.MinValue = 0;
            this.uneCobranzas.Name = "uneCobranzas";
            this.uneCobranzas.Size = new System.Drawing.Size(120, 21);
            this.uneCobranzas.TabIndex = 6;
            this.uvValidador.GetValidationSettings(this.uneCobranzas).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneCobranzas).NotificationSettings.Text = "Correlativo Cobranzas Invalido";
            this.uvValidador.GetValidationSettings(this.uneCobranzas).ValidationGroupKey = "required";
            this.uneCobranzas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneCobranzas_KeyDown);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel3.Location = new System.Drawing.Point(22, 136);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(77, 35);
            this.ultraLabel3.TabIndex = 22;
            this.ultraLabel3.Text = "Correlativo Facturas:";
            // 
            // uneFacturas
            // 
            this.uneFacturas.Location = new System.Drawing.Point(113, 141);
            this.uneFacturas.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneFacturas.MaskInput = "nnnnnnnnnnnnnnn";
            this.uneFacturas.MaxValue = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.uneFacturas.MinValue = 0;
            this.uneFacturas.Name = "uneFacturas";
            this.uneFacturas.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
            this.uneFacturas.Size = new System.Drawing.Size(120, 21);
            this.uneFacturas.TabIndex = 5;
            this.uvValidador.GetValidationSettings(this.uneFacturas).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneFacturas).NotificationSettings.Text = "Correlativo Facturas Invalido";
            this.uvValidador.GetValidationSettings(this.uneFacturas).ValidationGroupKey = "required";
            this.uneFacturas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uneFacturas_KeyDown);
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel6.Location = new System.Drawing.Point(23, 118);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(26, 14);
            this.ultraLabel6.TabIndex = 20;
            this.ultraLabel6.Text = "NIT:";
            // 
            // uteNit
            // 
            this.uteNit.Location = new System.Drawing.Point(113, 114);
            this.uteNit.MaxLength = 60;
            this.uteNit.Name = "uteNit";
            this.uteNit.Size = new System.Drawing.Size(194, 21);
            this.uteNit.TabIndex = 4;
            this.uteNit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteNit_KeyDown);
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel4.Location = new System.Drawing.Point(22, 10);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(43, 14);
            this.ultraLabel4.TabIndex = 18;
            this.ultraLabel4.Text = "Oficina:";
            // 
            // uteOficina
            // 
            this.uteOficina.Enabled = false;
            this.uteOficina.Location = new System.Drawing.Point(113, 6);
            this.uteOficina.MaxLength = 60;
            this.uteOficina.Name = "uteOficina";
            this.uteOficina.Size = new System.Drawing.Size(421, 21);
            this.uteOficina.TabIndex = 0;
            this.uteOficina.TabStop = false;
            // 
            // uckIncluido
            // 
            this.uckIncluido.AutoSize = true;
            this.uckIncluido.Location = new System.Drawing.Point(173, 198);
            this.uckIncluido.Name = "uckIncluido";
            this.uckIncluido.Size = new System.Drawing.Size(60, 17);
            this.uckIncluido.TabIndex = 10;
            this.uckIncluido.Text = "Incluido";
            this.uckIncluido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uckCaptar_KeyDown);
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel2.Location = new System.Drawing.Point(23, 91);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(55, 14);
            this.ultraLabel2.TabIndex = 8;
            this.ultraLabel2.Text = "Dirección:";
            // 
            // uteDireccion
            // 
            this.uteDireccion.Location = new System.Drawing.Point(113, 87);
            this.uteDireccion.MaxLength = 60;
            this.uteDireccion.Name = "uteDireccion";
            this.uteDireccion.Size = new System.Drawing.Size(366, 21);
            this.uteDireccion.TabIndex = 3;
            this.uteDireccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteDireccion_KeyDown);
            // 
            // uteId
            // 
            this.uteId.Location = new System.Drawing.Point(113, 33);
            this.uteId.MaxLength = 2;
            this.uteId.Name = "uteId";
            this.uteId.Size = new System.Drawing.Size(52, 21);
            this.uteId.TabIndex = 1;
            this.uvValidador.GetValidationSettings(this.uteId).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteId).NotificationSettings.Text = "ID de Oficina Invalido";
            this.uvValidador.GetValidationSettings(this.uteId).ValidationGroupKey = "required";
            this.uteId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteIdBanco_KeyDown);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel1.Location = new System.Drawing.Point(22, 37);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(48, 14);
            this.ultraLabel1.TabIndex = 6;
            this.ultraLabel1.Text = "Entidad:";
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.AutoSize = true;
            this.ultraLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel7.Location = new System.Drawing.Point(22, 64);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(77, 14);
            this.ultraLabel7.TabIndex = 6;
            this.ultraLabel7.Text = "Razon Social:";
            // 
            // uteDescripcion
            // 
            this.uteDescripcion.Location = new System.Drawing.Point(113, 60);
            this.uteDescripcion.MaxLength = 60;
            this.uteDescripcion.Name = "uteDescripcion";
            this.uteDescripcion.Size = new System.Drawing.Size(366, 21);
            this.uteDescripcion.TabIndex = 2;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uteDescripcion).NotificationSettings.Text = "Nombre Invalido";
            this.uvValidador.GetValidationSettings(this.uteDescripcion).ValidationGroupKey = "required";
            this.uteDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uteDescripcion_KeyDown);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ultraPanel1);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(593, 411);
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.ugData);
            this.ultraPanel1.ClientArea.Controls.Add(this.ubEliminaData);
            this.ultraPanel1.ClientArea.Controls.Add(this.ubAgregarData);
            this.ultraPanel1.ClientArea.Controls.Add(this.ultraLabel19);
            this.ultraPanel1.ClientArea.Controls.Add(this.uneTipFrase);
            this.ultraPanel1.ClientArea.Controls.Add(this.ultraLabel18);
            this.ultraPanel1.ClientArea.Controls.Add(this.uneEscenario);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(593, 411);
            this.ultraPanel1.TabIndex = 0;
            // 
            // ugData
            // 
            this.ugData.DataSource = this.tblfrasesBindingSource;
            this.ugData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.Editor = null;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Código Escenario";
            ultraGridColumn2.Header.Editor = null;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 345;
            ultraGridColumn3.Header.Caption = "Tipo Frase";
            ultraGridColumn3.Header.Editor = null;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 227;
            ultraGridColumn6.Header.Editor = null;
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Editor = null;
            ultraGridColumn7.Header.VisiblePosition = 4;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.Editor = null;
            ultraGridColumn8.Header.VisiblePosition = 5;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            ultraGridColumn9.CellButtonAppearance = appearance2;
            ultraGridColumn9.Header.Caption = "";
            ultraGridColumn9.Header.Editor = null;
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.MaxWidth = 20;
            ultraGridColumn9.MinLength = 14;
            ultraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn9.Tag = "E_BANCOS";
            ultraGridColumn9.Width = 20;
            ultraGridColumn10.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            ultraGridColumn10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            ultraGridColumn10.CellButtonAppearance = appearance3;
            ultraGridColumn10.Header.Caption = "";
            ultraGridColumn10.Header.Editor = null;
            ultraGridColumn10.Header.VisiblePosition = 6;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn10.MaxWidth = 20;
            ultraGridColumn10.MinWidth = 14;
            ultraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn10.Tag = "B_BANCOS";
            ultraGridColumn10.Width = 20;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10});
            this.ugData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ugData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.LoadStyle = Infragistics.Win.UltraWinGrid.LoadStyle.LoadOnDemand;
            this.ugData.DisplayLayout.MaxBandDepth = 1;
            this.ugData.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ugData.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.ugData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.ugData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            this.ugData.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ugData.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugData.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ugData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ugData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ugData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ugData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ugData.Location = new System.Drawing.Point(0, 117);
            this.ugData.Name = "ugData";
            this.ugData.Size = new System.Drawing.Size(593, 294);
            this.ugData.TabIndex = 35;
            this.ugData.Text = "ultraGrid1";
            // 
            // tblfrasesBindingSource
            // 
            this.tblfrasesBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_frases);
            // 
            // ubEliminaData
            // 
            appearance4.Image = global::TiempoEnProceso.Properties.Resources.Menos;
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubEliminaData.Appearance = appearance4;
            this.ubEliminaData.AutoSize = true;
            this.ubEliminaData.ImageSize = new System.Drawing.Size(32, 32);
            this.ubEliminaData.Location = new System.Drawing.Point(541, 48);
            this.ubEliminaData.Name = "ubEliminaData";
            this.ubEliminaData.ShowOutline = false;
            this.ubEliminaData.Size = new System.Drawing.Size(40, 40);
            this.ubEliminaData.TabIndex = 37;
            ultraToolTipInfo3.ToolTipText = "Eliminar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubEliminaData, ultraToolTipInfo3);
            this.ubEliminaData.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubEliminaData.Click += new System.EventHandler(this.ubEliminaData_Click);
            // 
            // ubAgregarData
            // 
            appearance7.Image = global::TiempoEnProceso.Properties.Resources.mas;
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregarData.Appearance = appearance7;
            this.ubAgregarData.AutoSize = true;
            this.ubAgregarData.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregarData.Location = new System.Drawing.Point(541, 6);
            this.ubAgregarData.Name = "ubAgregarData";
            this.ubAgregarData.ShowOutline = false;
            this.ubAgregarData.Size = new System.Drawing.Size(40, 40);
            this.ubAgregarData.TabIndex = 36;
            ultraToolTipInfo4.ToolTipText = "Agregar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregarData, ultraToolTipInfo4);
            this.ubAgregarData.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregarData.Click += new System.EventHandler(this.ubAgregarData_Click);
            // 
            // ultraLabel19
            // 
            this.ultraLabel19.AutoSize = true;
            this.ultraLabel19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel19.Location = new System.Drawing.Point(47, 59);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(31, 14);
            this.ultraLabel19.TabIndex = 34;
            this.ultraLabel19.Text = "Tipo:";
            // 
            // uneTipFrase
            // 
            this.uneTipFrase.Location = new System.Drawing.Point(138, 55);
            this.uneTipFrase.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneTipFrase.MaskInput = "nn";
            this.uneTipFrase.MaxValue = 99;
            this.uneTipFrase.MinValue = 0;
            this.uneTipFrase.Name = "uneTipFrase";
            this.uneTipFrase.Size = new System.Drawing.Size(43, 21);
            this.uneTipFrase.TabIndex = 33;
            this.uvValidador.GetValidationSettings(this.uneTipFrase).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneTipFrase).NotificationSettings.Text = "Tipo Frase Invalido";
            this.uvValidador.GetValidationSettings(this.uneTipFrase).ValidationGroupKey = "requiredData";
            // 
            // ultraLabel18
            // 
            this.ultraLabel18.AutoSize = true;
            this.ultraLabel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel18.Location = new System.Drawing.Point(47, 23);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(60, 14);
            this.ultraLabel18.TabIndex = 32;
            this.ultraLabel18.Text = "Escenario:";
            // 
            // uneEscenario
            // 
            this.uneEscenario.Location = new System.Drawing.Point(138, 19);
            this.uneEscenario.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.uneEscenario.MaskInput = "nn";
            this.uneEscenario.MaxValue = 99;
            this.uneEscenario.MinValue = 0;
            this.uneEscenario.Name = "uneEscenario";
            this.uneEscenario.Size = new System.Drawing.Size(43, 21);
            this.uneEscenario.TabIndex = 31;
            this.uvValidador.GetValidationSettings(this.uneEscenario).IsRequired = true;
            this.uvValidador.GetValidationSettings(this.uneEscenario).NotificationSettings.Text = "Código de Escenario Invalido";
            this.uvValidador.GetValidationSettings(this.uneEscenario).ValidationGroupKey = "requiredData";
            // 
            // uvValidador
            // 
            appearance1.Image = global::TiempoEnProceso.Properties.Resources.exclamation;
            this.uvValidador.ErrorAppearance = appearance1;
            this.uvValidador.MessageBoxIcon = System.Windows.Forms.MessageBoxIcon.Asterisk;
            this.uvValidador.NotificationSettings.Action = Infragistics.Win.Misc.NotificationAction.None;
            validationGroup1.Key = "required";
            validationGroup2.Enabled = false;
            validationGroup2.Key = "requiredData";
            this.uvValidador.ValidationGroups.Add(validationGroup1);
            this.uvValidador.ValidationGroups.Add(validationGroup2);
            this.uvValidador.ValidationTrigger = Infragistics.Win.Misc.ValidationTrigger.OnPropertyValueChanged;
            // 
            // ultraPanel3
            // 
            // 
            // ultraPanel3.ClientArea
            // 
            this.ultraPanel3.ClientArea.Controls.Add(this.ubCerrar);
            this.ultraPanel3.ClientArea.Controls.Add(this.ubAgregar);
            this.ultraPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraPanel3.Location = new System.Drawing.Point(8, 32);
            this.ultraPanel3.Name = "ultraPanel3";
            this.ultraPanel3.Size = new System.Drawing.Size(597, 46);
            this.ultraPanel3.TabIndex = 22;
            // 
            // ubCerrar
            // 
            appearance5.Image = global::TiempoEnProceso.Properties.Resources.Cerrar;
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubCerrar.Appearance = appearance5;
            this.ubCerrar.AutoSize = true;
            this.ubCerrar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubCerrar.Location = new System.Drawing.Point(41, 3);
            this.ubCerrar.Name = "ubCerrar";
            this.ubCerrar.ShowOutline = false;
            this.ubCerrar.Size = new System.Drawing.Size(40, 40);
            this.ubCerrar.TabIndex = 17;
            ultraToolTipInfo1.ToolTipText = "Cancelar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubCerrar, ultraToolTipInfo1);
            this.ubCerrar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubCerrar.Click += new System.EventHandler(this.ubCerrar_Click);
            // 
            // ubAgregar
            // 
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ubAgregar.Appearance = appearance6;
            this.ubAgregar.AutoSize = true;
            this.ubAgregar.ImageSize = new System.Drawing.Size(32, 32);
            this.ubAgregar.Location = new System.Drawing.Point(3, 3);
            this.ubAgregar.Name = "ubAgregar";
            this.ubAgregar.ShowOutline = false;
            this.ubAgregar.Size = new System.Drawing.Size(40, 40);
            this.ubAgregar.TabIndex = 16;
            ultraToolTipInfo2.ToolTipText = "Grabar";
            this.ultraToolTipManager1.SetUltraToolTip(this.ubAgregar, ultraToolTipInfo2);
            this.ubAgregar.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.ubAgregar.Click += new System.EventHandler(this.ubAgregar_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Left
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Name = "_frmUsuario_UltraFormManager_Dock_Area_Left";
            this._frmUsuario_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(8, 483);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Right
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(605, 32);
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Name = "_frmUsuario_UltraFormManager_Dock_Area_Right";
            this._frmUsuario_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(8, 483);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Top
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._frmUsuario_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Name = "_frmUsuario_UltraFormManager_Dock_Area_Top";
            this._frmUsuario_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(613, 32);
            // 
            // _frmUsuario_UltraFormManager_Dock_Area_Bottom
            // 
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 515);
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Name = "_frmUsuario_UltraFormManager_Dock_Area_Bottom";
            this._frmUsuario_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(613, 8);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Ubicacion de Factura";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Crystal Report Format|*.rpt";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            this.openFileDialog2.Filter = "Certificados|*.pfx";
            // 
            // ultraTabControl1
            // 
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl2);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.Location = new System.Drawing.Point(8, 78);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.ultraTabControl1.Size = new System.Drawing.Size(597, 437);
            this.ultraTabControl1.TabIndex = 27;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "General";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "Frases";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(593, 411);
            // 
            // tblSeriesPorCajaBindingSource
            // 
            this.tblSeriesPorCajaBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_oficina);
            // 
            // tblpaisesBindingSource
            // 
            this.tblpaisesBindingSource.DataSource = typeof(TiempoEnProcesoDL.tbl_paises);
            // 
            // periodoBindingSource
            // 
            this.periodoBindingSource.DataSource = typeof(TiempoEnProcesoDL.Periodo);
            // 
            // frmEntidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 523);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this.ultraPanel3);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._frmUsuario_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEntidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entidad Legal";
            this.Load += new System.EventHandler(this.frmRegion_Load);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraPanel4.ClientArea.ResumeLayout(false);
            this.ultraPanel4.ClientArea.PerformLayout();
            this.ultraPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uteFormatoFEL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteClaveCertificado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteApi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteAcceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckEntidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteFormato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteUbicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneImpuesto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneAnulaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneNotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneCobranzas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteNit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteOficina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uckIncluido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uteDescripcion)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ugData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblfrasesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneTipFrase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uneEscenario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvValidador)).EndInit();
            this.ultraPanel3.ClientArea.ResumeLayout(false);
            this.ultraPanel3.ClientArea.PerformLayout();
            this.ultraPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSeriesPorCajaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblpaisesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraValidator uvValidador;
        private Infragistics.Win.Misc.UltraPanel ultraPanel3;
        private Infragistics.Win.Misc.UltraButton ubCerrar;
        private Infragistics.Win.Misc.UltraButton ubAgregar;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _frmUsuario_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraPanel ultraPanel4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDescripcion;
        private System.Windows.Forms.BindingSource tblSeriesPorCajaBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteId;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private System.Windows.Forms.BindingSource tblpaisesBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteDireccion;
        private System.Windows.Forms.BindingSource periodoBindingSource;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckEntidad;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckIncluido;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteNit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteOficina;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneImpuesto;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneAnulaciones;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneNotas;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneCobranzas;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneFacturas;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteUbicacion;
        private Infragistics.Win.Misc.UltraButton ubFolder;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteFormato;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uckActivo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteOrigen;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteApi;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteAcceso;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteFormatoFEL;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor uteClaveCertificado;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneTipFrase;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor uneEscenario;
        private Infragistics.Win.UltraWinGrid.UltraGrid ugData;
        private Infragistics.Win.Misc.UltraButton ubEliminaData;
        private Infragistics.Win.Misc.UltraButton ubAgregarData;
        private System.Windows.Forms.BindingSource tblfrasesBindingSource;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
    }
}