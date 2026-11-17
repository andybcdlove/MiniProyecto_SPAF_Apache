namespace MiniProyecto_SPAF_Apache
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lTitulo = new Label();
            lIdioma = new Label();
            cbIdioma = new ComboBox();
            gbCaptura = new GroupBox();
            lFormato = new Label();
            bLimpiar = new Button();
            bProcesar = new Button();
            tLote = new TextBox();
            lInstruccion = new Label();
            gbResultados = new GroupBox();
            dgvPaquetes = new DataGridView();
            cCodigo = new DataGridViewTextBoxColumn();
            cCliente = new DataGridViewTextBoxColumn();
            cZona = new DataGridViewTextBoxColumn();
            cPeso = new DataGridViewTextBoxColumn();
            cValorDeclarado = new DataGridViewTextBoxColumn();
            cTotal = new DataGridViewTextBoxColumn();
            gbDetalle = new GroupBox();
            label1 = new Label();
            lTotalPaquete = new Label();
            lIva = new Label();
            lCostoFijo = new Label();
            lSeguro = new Label();
            lRecargoZona = new Label();
            lSubtotalPeso = new Label();
            lPenalizacion = new Label();
            lValorDeclarado = new Label();
            lPeso = new Label();
            lZona = new Label();
            lCliente = new Label();
            lCodigo = new Label();
            gbErrores = new GroupBox();
            dgvErrores = new DataGridView();
            cLinea = new DataGridViewTextBoxColumn();
            cTextoOriginal = new DataGridViewTextBoxColumn();
            cMotivo = new DataGridViewTextBoxColumn();
            label2 = new Label();
            lValidos = new Label();
            lInvalidos = new Label();
            lTotalLote = new Label();
            bGuardar = new Button();
            bExportar = new Button();
            bHistorial = new Button();
            sfdExportar = new SaveFileDialog();
            gbCaptura.SuspendLayout();
            gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaquetes).BeginInit();
            gbDetalle.SuspendLayout();
            gbErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvErrores).BeginInit();
            SuspendLayout();
            // 
            // lTitulo
            // 
            lTitulo.BackColor = Color.Gold;
            resources.ApplyResources(lTitulo, "lTitulo");
            lTitulo.ForeColor = Color.Crimson;
            lTitulo.Name = "lTitulo";
            // 
            // lIdioma
            // 
            lIdioma.BackColor = Color.Gold;
            resources.ApplyResources(lIdioma, "lIdioma");
            lIdioma.Name = "lIdioma";
            // 
            // cbIdioma
            // 
            cbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdioma.FormattingEnabled = true;
            cbIdioma.Items.AddRange(new object[] { resources.GetString("cbIdioma.Items"), resources.GetString("cbIdioma.Items1") });
            resources.ApplyResources(cbIdioma, "cbIdioma");
            cbIdioma.Name = "cbIdioma";
            cbIdioma.SelectedIndexChanged += cbIdioma_SelectedIndexChanged;
            // 
            // gbCaptura
            // 
            gbCaptura.BackColor = Color.Cornsilk;
            gbCaptura.Controls.Add(lFormato);
            gbCaptura.Controls.Add(bLimpiar);
            gbCaptura.Controls.Add(bProcesar);
            gbCaptura.Controls.Add(tLote);
            gbCaptura.Controls.Add(lInstruccion);
            gbCaptura.FlatStyle = FlatStyle.Popup;
            resources.ApplyResources(gbCaptura, "gbCaptura");
            gbCaptura.Name = "gbCaptura";
            gbCaptura.TabStop = false;
            // 
            // lFormato
            // 
            resources.ApplyResources(lFormato, "lFormato");
            lFormato.BackColor = Color.AntiqueWhite;
            lFormato.Name = "lFormato";
            // 
            // bLimpiar
            // 
            bLimpiar.BackColor = Color.Gold;
            resources.ApplyResources(bLimpiar, "bLimpiar");
            bLimpiar.ForeColor = Color.Crimson;
            bLimpiar.Name = "bLimpiar";
            bLimpiar.UseVisualStyleBackColor = false;
            bLimpiar.Click += bLimpiar_Click;
            // 
            // bProcesar
            // 
            bProcesar.BackColor = Color.Gold;
            resources.ApplyResources(bProcesar, "bProcesar");
            bProcesar.ForeColor = Color.Crimson;
            bProcesar.Name = "bProcesar";
            bProcesar.UseVisualStyleBackColor = false;
            bProcesar.Click += bProcesar_Click;
            // 
            // tLote
            // 
            tLote.AcceptsReturn = true;
            resources.ApplyResources(tLote, "tLote");
            tLote.Name = "tLote";
            // 
            // lInstruccion
            // 
            resources.ApplyResources(lInstruccion, "lInstruccion");
            lInstruccion.Name = "lInstruccion";
            // 
            // gbResultados
            // 
            gbResultados.BackColor = Color.Cornsilk;
            gbResultados.Controls.Add(dgvPaquetes);
            resources.ApplyResources(gbResultados, "gbResultados");
            gbResultados.Name = "gbResultados";
            gbResultados.TabStop = false;
            // 
            // dgvPaquetes
            // 
            dgvPaquetes.AllowUserToAddRows = false;
            dgvPaquetes.AllowUserToDeleteRows = false;
            dgvPaquetes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaquetes.BackgroundColor = Color.Cornsilk;
            dgvPaquetes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Gold;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 13F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPaquetes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(dgvPaquetes, "dgvPaquetes");
            dgvPaquetes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPaquetes.Columns.AddRange(new DataGridViewColumn[] { cCodigo, cCliente, cZona, cPeso, cValorDeclarado, cTotal });
            dgvPaquetes.MultiSelect = false;
            dgvPaquetes.Name = "dgvPaquetes";
            dgvPaquetes.ReadOnly = true;
            dgvPaquetes.RowHeadersVisible = false;
            dgvPaquetes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPaquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaquetes.SelectionChanged += dgvPaquetes_SelectionChanged;
            // 
            // cCodigo
            // 
            resources.ApplyResources(cCodigo, "cCodigo");
            cCodigo.Name = "cCodigo";
            cCodigo.ReadOnly = true;
            // 
            // cCliente
            // 
            resources.ApplyResources(cCliente, "cCliente");
            cCliente.Name = "cCliente";
            cCliente.ReadOnly = true;
            // 
            // cZona
            // 
            resources.ApplyResources(cZona, "cZona");
            cZona.Name = "cZona";
            cZona.ReadOnly = true;
            // 
            // cPeso
            // 
            resources.ApplyResources(cPeso, "cPeso");
            cPeso.Name = "cPeso";
            cPeso.ReadOnly = true;
            // 
            // cValorDeclarado
            // 
            resources.ApplyResources(cValorDeclarado, "cValorDeclarado");
            cValorDeclarado.Name = "cValorDeclarado";
            cValorDeclarado.ReadOnly = true;
            // 
            // cTotal
            // 
            resources.ApplyResources(cTotal, "cTotal");
            cTotal.Name = "cTotal";
            cTotal.ReadOnly = true;
            // 
            // gbDetalle
            // 
            gbDetalle.BackColor = Color.Cornsilk;
            gbDetalle.Controls.Add(label1);
            gbDetalle.Controls.Add(lTotalPaquete);
            gbDetalle.Controls.Add(lIva);
            gbDetalle.Controls.Add(lCostoFijo);
            gbDetalle.Controls.Add(lSeguro);
            gbDetalle.Controls.Add(lRecargoZona);
            gbDetalle.Controls.Add(lSubtotalPeso);
            gbDetalle.Controls.Add(lPenalizacion);
            gbDetalle.Controls.Add(lValorDeclarado);
            gbDetalle.Controls.Add(lPeso);
            gbDetalle.Controls.Add(lZona);
            gbDetalle.Controls.Add(lCliente);
            gbDetalle.Controls.Add(lCodigo);
            resources.ApplyResources(gbDetalle, "gbDetalle");
            gbDetalle.Name = "gbDetalle";
            gbDetalle.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Gold;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lTotalPaquete
            // 
            resources.ApplyResources(lTotalPaquete, "lTotalPaquete");
            lTotalPaquete.Name = "lTotalPaquete";
            // 
            // lIva
            // 
            resources.ApplyResources(lIva, "lIva");
            lIva.Name = "lIva";
            // 
            // lCostoFijo
            // 
            resources.ApplyResources(lCostoFijo, "lCostoFijo");
            lCostoFijo.Name = "lCostoFijo";
            // 
            // lSeguro
            // 
            resources.ApplyResources(lSeguro, "lSeguro");
            lSeguro.Name = "lSeguro";
            // 
            // lRecargoZona
            // 
            resources.ApplyResources(lRecargoZona, "lRecargoZona");
            lRecargoZona.Name = "lRecargoZona";
            // 
            // lSubtotalPeso
            // 
            resources.ApplyResources(lSubtotalPeso, "lSubtotalPeso");
            lSubtotalPeso.Name = "lSubtotalPeso";
            // 
            // lPenalizacion
            // 
            resources.ApplyResources(lPenalizacion, "lPenalizacion");
            lPenalizacion.Name = "lPenalizacion";
            // 
            // lValorDeclarado
            // 
            resources.ApplyResources(lValorDeclarado, "lValorDeclarado");
            lValorDeclarado.Name = "lValorDeclarado";
            // 
            // lPeso
            // 
            resources.ApplyResources(lPeso, "lPeso");
            lPeso.Name = "lPeso";
            // 
            // lZona
            // 
            resources.ApplyResources(lZona, "lZona");
            lZona.Name = "lZona";
            // 
            // lCliente
            // 
            resources.ApplyResources(lCliente, "lCliente");
            lCliente.Name = "lCliente";
            // 
            // lCodigo
            // 
            resources.ApplyResources(lCodigo, "lCodigo");
            lCodigo.Name = "lCodigo";
            // 
            // gbErrores
            // 
            gbErrores.BackColor = Color.Cornsilk;
            gbErrores.Controls.Add(dgvErrores);
            resources.ApplyResources(gbErrores, "gbErrores");
            gbErrores.Name = "gbErrores";
            gbErrores.TabStop = false;
            // 
            // dgvErrores
            // 
            dgvErrores.AllowUserToAddRows = false;
            dgvErrores.AllowUserToDeleteRows = false;
            dgvErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErrores.BackgroundColor = Color.Cornsilk;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvErrores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvErrores.Columns.AddRange(new DataGridViewColumn[] { cLinea, cTextoOriginal, cMotivo });
            resources.ApplyResources(dgvErrores, "dgvErrores");
            dgvErrores.MultiSelect = false;
            dgvErrores.Name = "dgvErrores";
            dgvErrores.ReadOnly = true;
            dgvErrores.RowHeadersVisible = false;
            dgvErrores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // cLinea
            // 
            cLinea.FillWeight = 15F;
            resources.ApplyResources(cLinea, "cLinea");
            cLinea.Name = "cLinea";
            cLinea.ReadOnly = true;
            // 
            // cTextoOriginal
            // 
            cTextoOriginal.FillWeight = 50F;
            resources.ApplyResources(cTextoOriginal, "cTextoOriginal");
            cTextoOriginal.Name = "cTextoOriginal";
            cTextoOriginal.ReadOnly = true;
            // 
            // cMotivo
            // 
            cMotivo.FillWeight = 35F;
            resources.ApplyResources(cMotivo, "cMotivo");
            cMotivo.Name = "cMotivo";
            cMotivo.ReadOnly = true;
            // 
            // label2
            // 
            label2.BackColor = Color.Gold;
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // lValidos
            // 
            lValidos.BackColor = Color.Gold;
            resources.ApplyResources(lValidos, "lValidos");
            lValidos.Name = "lValidos";
            // 
            // lInvalidos
            // 
            lInvalidos.BackColor = Color.Gold;
            resources.ApplyResources(lInvalidos, "lInvalidos");
            lInvalidos.Name = "lInvalidos";
            // 
            // lTotalLote
            // 
            lTotalLote.BackColor = Color.Gold;
            resources.ApplyResources(lTotalLote, "lTotalLote");
            lTotalLote.Name = "lTotalLote";
            // 
            // bGuardar
            // 
            bGuardar.BackColor = Color.Gold;
            resources.ApplyResources(bGuardar, "bGuardar");
            bGuardar.ForeColor = Color.Crimson;
            bGuardar.Name = "bGuardar";
            bGuardar.UseVisualStyleBackColor = false;
            bGuardar.Click += bGuardar_Click;
            // 
            // bExportar
            // 
            bExportar.BackColor = Color.Gold;
            resources.ApplyResources(bExportar, "bExportar");
            bExportar.ForeColor = Color.Crimson;
            bExportar.Name = "bExportar";
            bExportar.UseVisualStyleBackColor = false;
            // 
            // bHistorial
            // 
            bHistorial.BackColor = Color.Gold;
            resources.ApplyResources(bHistorial, "bHistorial");
            bHistorial.ForeColor = Color.Crimson;
            bHistorial.Name = "bHistorial";
            bHistorial.UseVisualStyleBackColor = false;
            bHistorial.Click += bHistorial_Click;
            // 
            // sfdExportar
            // 
            sfdExportar.DefaultExt = "csv";
            sfdExportar.FileName = "ReporteEnvios.csv";
            resources.ApplyResources(sfdExportar, "sfdExportar");
            // 
            // FrmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(bHistorial);
            Controls.Add(bExportar);
            Controls.Add(bGuardar);
            Controls.Add(lTotalLote);
            Controls.Add(lInvalidos);
            Controls.Add(lValidos);
            Controls.Add(label2);
            Controls.Add(gbErrores);
            Controls.Add(gbDetalle);
            Controls.Add(gbResultados);
            Controls.Add(gbCaptura);
            Controls.Add(cbIdioma);
            Controls.Add(lIdioma);
            Controls.Add(lTitulo);
            Name = "FrmPrincipal";
            gbCaptura.ResumeLayout(false);
            gbCaptura.PerformLayout();
            gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPaquetes).EndInit();
            gbDetalle.ResumeLayout(false);
            gbDetalle.PerformLayout();
            gbErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvErrores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lTitulo;
        private Label lIdioma;
        private ComboBox cbIdioma;
        private GroupBox gbCaptura;
        private Label lInstruccion;
        private TextBox tLote;
        private Button bProcesar;
        private Button bLimpiar;
        private Label lFormato;
        private GroupBox gbResultados;
        private DataGridView dgvPaquetes;
        private GroupBox gbDetalle;
        private Label lCodigo;
        private Label lTotalPaquete;
        private Label lIva;
        private Label lCostoFijo;
        private Label lSeguro;
        private Label lRecargoZona;
        private Label lSubtotalPeso;
        private Label lPenalizacion;
        private Label lValorDeclarado;
        private Label lPeso;
        private Label lZona;
        private Label lCliente;
        private Label label1;
        private GroupBox gbErrores;
        private DataGridView dgvErrores;
        private Label label2;
        private Label lValidos;
        private Label lInvalidos;
        private Label lTotalLote;
        private Button bGuardar;
        private Button bExportar;
        private Button bHistorial;
        private SaveFileDialog sfdExportar;
        private DataGridViewTextBoxColumn cLinea;
        private DataGridViewTextBoxColumn cTextoOriginal;
        private DataGridViewTextBoxColumn cMotivo;
        private DataGridViewTextBoxColumn cCodigo;
        private DataGridViewTextBoxColumn cCliente;
        private DataGridViewTextBoxColumn cZona;
        private DataGridViewTextBoxColumn cPeso;
        private DataGridViewTextBoxColumn cValorDeclarado;
        private DataGridViewTextBoxColumn cTotal;
    }
}
