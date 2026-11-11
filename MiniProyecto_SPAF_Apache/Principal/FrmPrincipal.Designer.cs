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
            lTitulo.Font = new Font("Century Gothic", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lTitulo.ForeColor = Color.Crimson;
            lTitulo.Location = new Point(3, 9);
            lTitulo.Name = "lTitulo";
            lTitulo.Size = new Size(1154, 52);
            lTitulo.TabIndex = 0;
            lTitulo.Text = "Paqueteria";
            lTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lIdioma
            // 
            lIdioma.BackColor = Color.Gold;
            lIdioma.Location = new Point(938, 9);
            lIdioma.Name = "lIdioma";
            lIdioma.Size = new Size(74, 52);
            lIdioma.TabIndex = 1;
            lIdioma.Text = "Idioma";
            lIdioma.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbIdioma
            // 
            cbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdioma.FormattingEnabled = true;
            cbIdioma.Items.AddRange(new object[] { "Español", "Inglés" });
            cbIdioma.Location = new Point(1018, 22);
            cbIdioma.Name = "cbIdioma";
            cbIdioma.Size = new Size(121, 29);
            cbIdioma.TabIndex = 2;
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
            gbCaptura.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbCaptura.Location = new Point(12, 78);
            gbCaptura.Name = "gbCaptura";
            gbCaptura.Size = new Size(879, 258);
            gbCaptura.TabIndex = 3;
            gbCaptura.TabStop = false;
            gbCaptura.Text = "Captura de paquetes";
            // 
            // lFormato
            // 
            lFormato.AutoSize = true;
            lFormato.BackColor = Color.AntiqueWhite;
            lFormato.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lFormato.Location = new Point(267, 35);
            lFormato.Name = "lFormato";
            lFormato.Size = new Size(340, 21);
            lFormato.TabIndex = 13;
            lFormato.Text = "Código;Cliente;Zona;Peso;Valor declarado";
            // 
            // bLimpiar
            // 
            bLimpiar.BackColor = Color.Gold;
            bLimpiar.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bLimpiar.ForeColor = Color.Crimson;
            bLimpiar.Location = new Point(770, 203);
            bLimpiar.Name = "bLimpiar";
            bLimpiar.Size = new Size(87, 29);
            bLimpiar.TabIndex = 12;
            bLimpiar.Text = "Limpiar";
            bLimpiar.UseVisualStyleBackColor = false;
            // 
            // bProcesar
            // 
            bProcesar.BackColor = Color.Gold;
            bProcesar.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bProcesar.ForeColor = Color.Crimson;
            bProcesar.Location = new Point(15, 203);
            bProcesar.Name = "bProcesar";
            bProcesar.Size = new Size(134, 29);
            bProcesar.TabIndex = 11;
            bProcesar.Text = "Procesar Lote";
            bProcesar.UseVisualStyleBackColor = false;
            // 
            // tLote
            // 
            tLote.AcceptsReturn = true;
            tLote.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tLote.Location = new Point(15, 69);
            tLote.Multiline = true;
            tLote.Name = "tLote";
            tLote.ScrollBars = ScrollBars.Vertical;
            tLote.Size = new Size(842, 112);
            tLote.TabIndex = 3;
            // 
            // lInstruccion
            // 
            lInstruccion.AutoSize = true;
            lInstruccion.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lInstruccion.Location = new Point(15, 35);
            lInstruccion.Name = "lInstruccion";
            lInstruccion.Size = new Size(237, 21);
            lInstruccion.TabIndex = 0;
            lInstruccion.Text = "Escribe un paquete por línea:\r\n";
            // 
            // gbResultados
            // 
            gbResultados.BackColor = Color.Cornsilk;
            gbResultados.Controls.Add(dgvPaquetes);
            gbResultados.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbResultados.Location = new Point(12, 368);
            gbResultados.Name = "gbResultados";
            gbResultados.Size = new Size(546, 466);
            gbResultados.TabIndex = 4;
            gbResultados.TabStop = false;
            gbResultados.Text = "Paquetes procesados";
            // 
            // dgvPaquetes
            // 
            dgvPaquetes.AllowUserToAddRows = false;
            dgvPaquetes.AllowUserToDeleteRows = false;
            dgvPaquetes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaquetes.BackgroundColor = Color.Cornsilk;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Gold;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPaquetes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPaquetes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaquetes.Columns.AddRange(new DataGridViewColumn[] { cCodigo, cCliente, cZona, cPeso, cValorDeclarado, cTotal });
            dgvPaquetes.Dock = DockStyle.Fill;
            dgvPaquetes.Location = new Point(3, 25);
            dgvPaquetes.MultiSelect = false;
            dgvPaquetes.Name = "dgvPaquetes";
            dgvPaquetes.ReadOnly = true;
            dgvPaquetes.RowHeadersVisible = false;
            dgvPaquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaquetes.Size = new Size(540, 438);
            dgvPaquetes.TabIndex = 0;
            // 
            // cCodigo
            // 
            cCodigo.HeaderText = "Código";
            cCodigo.Name = "cCodigo";
            cCodigo.ReadOnly = true;
            // 
            // cCliente
            // 
            cCliente.HeaderText = "Cliente";
            cCliente.Name = "cCliente";
            cCliente.ReadOnly = true;
            // 
            // cZona
            // 
            cZona.HeaderText = "Zona";
            cZona.Name = "cZona";
            cZona.ReadOnly = true;
            // 
            // cPeso
            // 
            cPeso.HeaderText = "Peso";
            cPeso.Name = "cPeso";
            cPeso.ReadOnly = true;
            // 
            // cValorDeclarado
            // 
            cValorDeclarado.HeaderText = "Valor";
            cValorDeclarado.Name = "cValorDeclarado";
            cValorDeclarado.ReadOnly = true;
            // 
            // cTotal
            // 
            cTotal.HeaderText = "Total";
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
            gbDetalle.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbDetalle.Location = new Point(591, 368);
            gbDetalle.Name = "gbDetalle";
            gbDetalle.Size = new Size(546, 466);
            gbDetalle.TabIndex = 5;
            gbDetalle.TabStop = false;
            gbDetalle.Text = "Detalle del paquete";
            // 
            // label1
            // 
            label1.BackColor = Color.Gold;
            label1.Location = new Point(0, 192);
            label1.Name = "label1";
            label1.Size = new Size(546, 10);
            label1.TabIndex = 11;
            // 
            // lTotalPaquete
            // 
            lTotalPaquete.AutoSize = true;
            lTotalPaquete.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTotalPaquete.Location = new Point(16, 424);
            lTotalPaquete.Name = "lTotalPaquete";
            lTotalPaquete.Size = new Size(169, 19);
            lTotalPaquete.TabIndex = 10;
            lTotalPaquete.Text = "Total del paquete: —";
            // 
            // lIva
            // 
            lIva.AutoSize = true;
            lIva.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lIva.Location = new Point(16, 390);
            lIva.Name = "lIva";
            lIva.Size = new Size(63, 21);
            lIva.TabIndex = 9;
            lIva.Text = "IVA: —";
            // 
            // lCostoFijo
            // 
            lCostoFijo.AutoSize = true;
            lCostoFijo.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lCostoFijo.Location = new Point(16, 358);
            lCostoFijo.Name = "lCostoFijo";
            lCostoFijo.Size = new Size(105, 21);
            lCostoFijo.TabIndex = 8;
            lCostoFijo.Text = "\tCosto fijo: —";
            // 
            // lSeguro
            // 
            lSeguro.AutoSize = true;
            lSeguro.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSeguro.Location = new Point(18, 324);
            lSeguro.Name = "lSeguro";
            lSeguro.Size = new Size(88, 21);
            lSeguro.TabIndex = 7;
            lSeguro.Text = "Seguro: —";
            // 
            // lRecargoZona
            // 
            lRecargoZona.AutoSize = true;
            lRecargoZona.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lRecargoZona.Location = new Point(18, 253);
            lRecargoZona.Name = "lRecargoZona";
            lRecargoZona.Size = new Size(173, 21);
            lRecargoZona.TabIndex = 6;
            lRecargoZona.Text = "Recargo por zona: —";
            // 
            // lSubtotalPeso
            // 
            lSubtotalPeso.AutoSize = true;
            lSubtotalPeso.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSubtotalPeso.Location = new Point(18, 217);
            lSubtotalPeso.Name = "lSubtotalPeso";
            lSubtotalPeso.Size = new Size(172, 21);
            lSubtotalPeso.TabIndex = 5;
            lSubtotalPeso.Text = "Subtotal por peso: —";
            // 
            // lPenalizacion
            // 
            lPenalizacion.AutoSize = true;
            lPenalizacion.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lPenalizacion.Location = new Point(18, 289);
            lPenalizacion.Name = "lPenalizacion";
            lPenalizacion.Size = new Size(202, 21);
            lPenalizacion.TabIndex = 5;
            lPenalizacion.Text = "Penalización por peso: —";
            // 
            // lValorDeclarado
            // 
            lValorDeclarado.AutoSize = true;
            lValorDeclarado.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lValorDeclarado.Location = new Point(18, 153);
            lValorDeclarado.Name = "lValorDeclarado";
            lValorDeclarado.Size = new Size(160, 21);
            lValorDeclarado.TabIndex = 4;
            lValorDeclarado.Text = "Valor declarado: —";
            // 
            // lPeso
            // 
            lPeso.AutoSize = true;
            lPeso.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lPeso.Location = new Point(18, 122);
            lPeso.Name = "lPeso";
            lPeso.Size = new Size(104, 21);
            lPeso.TabIndex = 3;
            lPeso.Text = "Peso (kg): —";
            // 
            // lZona
            // 
            lZona.AutoSize = true;
            lZona.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lZona.Location = new Point(18, 89);
            lZona.Name = "lZona";
            lZona.Size = new Size(73, 21);
            lZona.TabIndex = 2;
            lZona.Text = "Zona: —";
            // 
            // lCliente
            // 
            lCliente.AutoSize = true;
            lCliente.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lCliente.Location = new Point(18, 56);
            lCliente.Name = "lCliente";
            lCliente.Size = new Size(90, 21);
            lCliente.TabIndex = 1;
            lCliente.Text = "Cliente: —";
            // 
            // lCodigo
            // 
            lCodigo.AutoSize = true;
            lCodigo.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lCodigo.Location = new Point(18, 25);
            lCodigo.Name = "lCodigo";
            lCodigo.Size = new Size(92, 21);
            lCodigo.TabIndex = 0;
            lCodigo.Text = "Código: —";
            // 
            // gbErrores
            // 
            gbErrores.BackColor = Color.Cornsilk;
            gbErrores.Controls.Add(dgvErrores);
            gbErrores.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbErrores.Location = new Point(12, 890);
            gbErrores.Name = "gbErrores";
            gbErrores.Size = new Size(879, 249);
            gbErrores.TabIndex = 6;
            gbErrores.TabStop = false;
            gbErrores.Text = "Errores del lote";
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
            dgvErrores.Dock = DockStyle.Fill;
            dgvErrores.Location = new Point(3, 25);
            dgvErrores.MultiSelect = false;
            dgvErrores.Name = "dgvErrores";
            dgvErrores.ReadOnly = true;
            dgvErrores.RowHeadersVisible = false;
            dgvErrores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvErrores.Size = new Size(873, 221);
            dgvErrores.TabIndex = 0;
            // 
            // cLinea
            // 
            cLinea.FillWeight = 15F;
            cLinea.HeaderText = "Linea";
            cLinea.Name = "cLinea";
            cLinea.ReadOnly = true;
            // 
            // cTextoOriginal
            // 
            cTextoOriginal.FillWeight = 50F;
            cTextoOriginal.HeaderText = "Texto Original";
            cTextoOriginal.Name = "cTextoOriginal";
            cTextoOriginal.ReadOnly = true;
            // 
            // cMotivo
            // 
            cMotivo.FillWeight = 35F;
            cMotivo.HeaderText = "Motivo del Error";
            cMotivo.Name = "cMotivo";
            cMotivo.ReadOnly = true;
            // 
            // label2
            // 
            label2.BackColor = Color.Gold;
            label2.Location = new Point(15, 1167);
            label2.Name = "label2";
            label2.Size = new Size(1140, 35);
            label2.TabIndex = 12;
            // 
            // lValidos
            // 
            lValidos.BackColor = Color.Gold;
            lValidos.Font = new Font("Century Gothic", 12F);
            lValidos.Location = new Point(40, 1167);
            lValidos.Name = "lValidos";
            lValidos.Size = new Size(159, 35);
            lValidos.TabIndex = 13;
            lValidos.Text = "Paquetes válidos: 0";
            lValidos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lInvalidos
            // 
            lInvalidos.BackColor = Color.Gold;
            lInvalidos.Font = new Font("Century Gothic", 12F);
            lInvalidos.Location = new Point(386, 1167);
            lInvalidos.Name = "lInvalidos";
            lInvalidos.Size = new Size(172, 35);
            lInvalidos.TabIndex = 14;
            lInvalidos.Text = "Paquetes inválidos: 0";
            lInvalidos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lTotalLote
            // 
            lTotalLote.BackColor = Color.Gold;
            lTotalLote.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lTotalLote.Location = new Point(759, 1167);
            lTotalLote.Name = "lTotalLote";
            lTotalLote.Size = new Size(159, 35);
            lTotalLote.TabIndex = 15;
            lTotalLote.Text = "Total del lote: $0.00";
            lTotalLote.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bGuardar
            // 
            bGuardar.BackColor = Color.Gold;
            bGuardar.Enabled = false;
            bGuardar.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bGuardar.ForeColor = Color.Crimson;
            bGuardar.Location = new Point(27, 1249);
            bGuardar.Name = "bGuardar";
            bGuardar.Size = new Size(134, 37);
            bGuardar.TabIndex = 16;
            bGuardar.Text = "Guardar Lote";
            bGuardar.UseVisualStyleBackColor = false;
            // 
            // bExportar
            // 
            bExportar.BackColor = Color.Gold;
            bExportar.Enabled = false;
            bExportar.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bExportar.ForeColor = Color.Crimson;
            bExportar.Location = new Point(536, 1249);
            bExportar.Name = "bExportar";
            bExportar.Size = new Size(134, 37);
            bExportar.TabIndex = 17;
            bExportar.Text = "Exportar CSV";
            bExportar.UseVisualStyleBackColor = false;
            // 
            // bHistorial
            // 
            bHistorial.BackColor = Color.Gold;
            bHistorial.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bHistorial.ForeColor = Color.Crimson;
            bHistorial.Location = new Point(1021, 1249);
            bHistorial.Name = "bHistorial";
            bHistorial.Size = new Size(134, 37);
            bHistorial.TabIndex = 18;
            bHistorial.Text = "Ver Historial";
            bHistorial.UseVisualStyleBackColor = false;
            bHistorial.Click += bHistorial_Click;
            // 
            // sfdExportar
            // 
            sfdExportar.DefaultExt = "csv";
            sfdExportar.FileName = "ReporteEnvios.csv";
            sfdExportar.Filter = "Archivos CSV (*.csv)|*.csv";
            sfdExportar.Title = "Guardar reporte del lote";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 1300);
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1184, 861);
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
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Procesamiento de envíos";
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
        private DataGridViewTextBoxColumn cCodigo;
        private DataGridViewTextBoxColumn cCliente;
        private DataGridViewTextBoxColumn cZona;
        private DataGridViewTextBoxColumn cPeso;
        private DataGridViewTextBoxColumn cValorDeclarado;
        private DataGridViewTextBoxColumn cTotal;
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
        private DataGridViewTextBoxColumn cLinea;
        private DataGridViewTextBoxColumn cTextoOriginal;
        private DataGridViewTextBoxColumn cMotivo;
        private Label label2;
        private Label lValidos;
        private Label lInvalidos;
        private Label lTotalLote;
        private Button bGuardar;
        private Button bExportar;
        private Button bHistorial;
        private SaveFileDialog sfdExportar;
    }
}
