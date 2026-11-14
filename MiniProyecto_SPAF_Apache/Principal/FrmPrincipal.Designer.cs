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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            cCodigo = new DataGridViewTextBoxColumn();
            cCliente = new DataGridViewTextBoxColumn();
            cZona = new DataGridViewTextBoxColumn();
            cPeso = new DataGridViewTextBoxColumn();
            cValorDeclarado = new DataGridViewTextBoxColumn();
            cTotal = new DataGridViewTextBoxColumn();
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
            resources.ApplyResources(lTitulo, "lTitulo");
            lTitulo.BackColor = Color.Gold;
            lTitulo.ForeColor = Color.Crimson;
            lTitulo.Name = "lTitulo";
            // 
            // lIdioma
            // 
            resources.ApplyResources(lIdioma, "lIdioma");
            lIdioma.BackColor = Color.Gold;
            lIdioma.Name = "lIdioma";
            // 
            // cbIdioma
            // 
            resources.ApplyResources(cbIdioma, "cbIdioma");
            cbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdioma.FormattingEnabled = true;
            cbIdioma.Items.AddRange(new object[] { resources.GetString("cbIdioma.Items"), resources.GetString("cbIdioma.Items1") });
            cbIdioma.Name = "cbIdioma";
            cbIdioma.SelectedIndexChanged += cbIdioma_SelectedIndexChanged;
            // 
            // gbCaptura
            // 
            resources.ApplyResources(gbCaptura, "gbCaptura");
            gbCaptura.BackColor = Color.Cornsilk;
            gbCaptura.Controls.Add(lFormato);
            gbCaptura.Controls.Add(bLimpiar);
            gbCaptura.Controls.Add(bProcesar);
            gbCaptura.Controls.Add(tLote);
            gbCaptura.Controls.Add(lInstruccion);
            gbCaptura.FlatStyle = FlatStyle.Popup;
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
            resources.ApplyResources(bLimpiar, "bLimpiar");
            bLimpiar.BackColor = Color.Gold;
            bLimpiar.ForeColor = Color.Crimson;
            bLimpiar.Name = "bLimpiar";
            bLimpiar.UseVisualStyleBackColor = false;
            // 
            // bProcesar
            // 
            resources.ApplyResources(bProcesar, "bProcesar");
            bProcesar.BackColor = Color.Gold;
            bProcesar.ForeColor = Color.Crimson;
            bProcesar.Name = "bProcesar";
            bProcesar.UseVisualStyleBackColor = false;
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
            resources.ApplyResources(gbResultados, "gbResultados");
            gbResultados.BackColor = Color.Cornsilk;
            gbResultados.Controls.Add(dgvPaquetes);
            gbResultados.Name = "gbResultados";
            gbResultados.TabStop = false;
            // 
            // dgvPaquetes
            // 
            resources.ApplyResources(dgvPaquetes, "dgvPaquetes");
            dgvPaquetes.AllowUserToAddRows = false;
            dgvPaquetes.AllowUserToDeleteRows = false;
            dgvPaquetes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaquetes.BackgroundColor = Color.Cornsilk;
            dgvPaquetes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.Gold;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 13F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPaquetes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPaquetes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPaquetes.Columns.AddRange(new DataGridViewColumn[] { cCodigo, cCliente, cZona, cPeso, cValorDeclarado, cTotal });
            dgvPaquetes.MultiSelect = false;
            dgvPaquetes.Name = "dgvPaquetes";
            dgvPaquetes.ReadOnly = true;
            dgvPaquetes.RowHeadersVisible = false;
            dgvPaquetes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvPaquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaquetes.CellContentClick += dgvPaquetes_CellContentClick;
            // 
            // gbDetalle
            // 
            resources.ApplyResources(gbDetalle, "gbDetalle");
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
            gbDetalle.Name = "gbDetalle";
            gbDetalle.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Gold;
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
            resources.ApplyResources(gbErrores, "gbErrores");
            gbErrores.BackColor = Color.Cornsilk;
            gbErrores.Controls.Add(dgvErrores);
            gbErrores.Name = "gbErrores";
            gbErrores.TabStop = false;
            // 
            // dgvErrores
            // 
            resources.ApplyResources(dgvErrores, "dgvErrores");
            dgvErrores.AllowUserToAddRows = false;
            dgvErrores.AllowUserToDeleteRows = false;
            dgvErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvErrores.BackgroundColor = Color.Cornsilk;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvErrores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvErrores.Columns.AddRange(new DataGridViewColumn[] { cLinea, cTextoOriginal, cMotivo });
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
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Gold;
            label2.Name = "label2";
            // 
            // lValidos
            // 
            resources.ApplyResources(lValidos, "lValidos");
            lValidos.BackColor = Color.Gold;
            lValidos.Name = "lValidos";
            // 
            // lInvalidos
            // 
            resources.ApplyResources(lInvalidos, "lInvalidos");
            lInvalidos.BackColor = Color.Gold;
            lInvalidos.Name = "lInvalidos";
            // 
            // lTotalLote
            // 
            resources.ApplyResources(lTotalLote, "lTotalLote");
            lTotalLote.BackColor = Color.Gold;
            lTotalLote.Name = "lTotalLote";
            // 
            // bGuardar
            // 
            resources.ApplyResources(bGuardar, "bGuardar");
            bGuardar.BackColor = Color.Gold;
            bGuardar.ForeColor = Color.Crimson;
            bGuardar.Name = "bGuardar";
            bGuardar.UseVisualStyleBackColor = false;
            // 
            // bExportar
            // 
            resources.ApplyResources(bExportar, "bExportar");
            bExportar.BackColor = Color.Gold;
            bExportar.ForeColor = Color.Crimson;
            bExportar.Name = "bExportar";
            bExportar.UseVisualStyleBackColor = false;
            // 
            // bHistorial
            // 
            resources.ApplyResources(bHistorial, "bHistorial");
            bHistorial.BackColor = Color.Gold;
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
