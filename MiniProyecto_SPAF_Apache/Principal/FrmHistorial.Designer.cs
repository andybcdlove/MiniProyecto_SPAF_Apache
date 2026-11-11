namespace MiniProyecto_SPAF_Apache.Principal
{
    partial class FrmHistorial
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cbIdioma = new ComboBox();
            lIdioma = new Label();
            lTitulo = new Label();
            gbLotes = new GroupBox();
            dataGridView1 = new DataGridView();
            cIdLote = new DataGridViewTextBoxColumn();
            cFecha = new DataGridViewTextBoxColumn();
            cCantidad = new DataGridViewTextBoxColumn();
            cTotalLote = new DataGridViewTextBoxColumn();
            gbPaquetes = new GroupBox();
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
            bActualizar = new Button();
            bCerrar = new Button();
            gbLotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            gbPaquetes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaquetes).BeginInit();
            gbDetalle.SuspendLayout();
            SuspendLayout();
            // 
            // cbIdioma
            // 
            cbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdioma.FormattingEnabled = true;
            cbIdioma.Items.AddRange(new object[] { "Español", "Inglés" });
            cbIdioma.Location = new Point(922, 17);
            cbIdioma.Name = "cbIdioma";
            cbIdioma.Size = new Size(121, 29);
            cbIdioma.TabIndex = 5;
            // 
            // lIdioma
            // 
            lIdioma.BackColor = Color.Gold;
            lIdioma.Location = new Point(842, 9);
            lIdioma.Name = "lIdioma";
            lIdioma.Size = new Size(74, 42);
            lIdioma.TabIndex = 4;
            lIdioma.Text = "Idioma";
            lIdioma.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lTitulo
            // 
            lTitulo.BackColor = Color.Gold;
            lTitulo.Font = new Font("Century Gothic", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lTitulo.ForeColor = Color.Crimson;
            lTitulo.Location = new Point(1, 9);
            lTitulo.Name = "lTitulo";
            lTitulo.Size = new Size(1181, 42);
            lTitulo.TabIndex = 3;
            lTitulo.Text = "Historial de envíos";
            lTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbLotes
            // 
            gbLotes.BackColor = Color.Cornsilk;
            gbLotes.Controls.Add(dataGridView1);
            gbLotes.FlatStyle = FlatStyle.Popup;
            gbLotes.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbLotes.Location = new Point(12, 58);
            gbLotes.Name = "gbLotes";
            gbLotes.Size = new Size(917, 236);
            gbLotes.TabIndex = 6;
            gbLotes.TabStop = false;
            gbLotes.Text = "Lotes guardados";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.Cornsilk;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { cIdLote, cFecha, cCantidad, cTotalLote });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 25);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(911, 208);
            dataGridView1.TabIndex = 0;
            // 
            // cIdLote
            // 
            cIdLote.HeaderText = "Número de Lote";
            cIdLote.Name = "cIdLote";
            cIdLote.ReadOnly = true;
            // 
            // cFecha
            // 
            cFecha.HeaderText = "Fecha de Procesamiento";
            cFecha.Name = "cFecha";
            cFecha.ReadOnly = true;
            // 
            // cCantidad
            // 
            cCantidad.HeaderText = "Cantidad de Paquetes";
            cCantidad.Name = "cCantidad";
            cCantidad.ReadOnly = true;
            // 
            // cTotalLote
            // 
            cTotalLote.HeaderText = "Total del Lote";
            cTotalLote.Name = "cTotalLote";
            cTotalLote.ReadOnly = true;
            // 
            // gbPaquetes
            // 
            gbPaquetes.BackColor = Color.Cornsilk;
            gbPaquetes.Controls.Add(dgvPaquetes);
            gbPaquetes.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbPaquetes.Location = new Point(12, 315);
            gbPaquetes.Name = "gbPaquetes";
            gbPaquetes.Size = new Size(546, 466);
            gbPaquetes.TabIndex = 13;
            gbPaquetes.TabStop = false;
            gbPaquetes.Text = "\tPaquetes del lote seleccionado";
            // 
            // dgvPaquetes
            // 
            dgvPaquetes.AllowUserToAddRows = false;
            dgvPaquetes.AllowUserToDeleteRows = false;
            dgvPaquetes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaquetes.BackgroundColor = Color.Cornsilk;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.Gold;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPaquetes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            gbDetalle.Location = new Point(626, 315);
            gbDetalle.Name = "gbDetalle";
            gbDetalle.Size = new Size(546, 466);
            gbDetalle.TabIndex = 14;
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
            // bActualizar
            // 
            bActualizar.BackColor = Color.Gold;
            bActualizar.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bActualizar.ForeColor = Color.Crimson;
            bActualizar.Location = new Point(16, 812);
            bActualizar.Name = "bActualizar";
            bActualizar.Size = new Size(203, 37);
            bActualizar.TabIndex = 19;
            bActualizar.Text = "Actualizar Historial";
            bActualizar.UseVisualStyleBackColor = false;
            // 
            // bCerrar
            // 
            bCerrar.BackColor = Color.Gold;
            bCerrar.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bCerrar.ForeColor = Color.Crimson;
            bCerrar.Location = new Point(1054, 812);
            bCerrar.Name = "bCerrar";
            bCerrar.Size = new Size(118, 37);
            bCerrar.TabIndex = 20;
            bCerrar.Text = "Cerrar";
            bCerrar.UseVisualStyleBackColor = false;
            bCerrar.Click += bCerrar_Click;
            // 
            // FrmHistorial
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1184, 861);
            Controls.Add(bCerrar);
            Controls.Add(bActualizar);
            Controls.Add(gbDetalle);
            Controls.Add(gbPaquetes);
            Controls.Add(gbLotes);
            Controls.Add(cbIdioma);
            Controls.Add(lIdioma);
            Controls.Add(lTitulo);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmHistorial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de envíos";
            gbLotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            gbPaquetes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPaquetes).EndInit();
            gbDetalle.ResumeLayout(false);
            gbDetalle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbIdioma;
        private Label lIdioma;
        private Label lTitulo;
        private GroupBox gbLotes;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn cIdLote;
        private DataGridViewTextBoxColumn cFecha;
        private DataGridViewTextBoxColumn cCantidad;
        private DataGridViewTextBoxColumn cTotalLote;
        private GroupBox gbPaquetes;
        private DataGridView dgvPaquetes;
        private DataGridViewTextBoxColumn cCodigo;
        private DataGridViewTextBoxColumn cCliente;
        private DataGridViewTextBoxColumn cZona;
        private DataGridViewTextBoxColumn cPeso;
        private DataGridViewTextBoxColumn cValorDeclarado;
        private DataGridViewTextBoxColumn cTotal;
        private GroupBox gbDetalle;
        private Label label1;
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
        private Label lCodigo;
        private Button bActualizar;
        private Button bCerrar;
    }
}