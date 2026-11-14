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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistorial));
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            resources.ApplyResources(cbIdioma, "cbIdioma");
            cbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdioma.FormattingEnabled = true;
            cbIdioma.Items.AddRange(new object[] { resources.GetString("cbIdioma.Items"), resources.GetString("cbIdioma.Items1") });
            cbIdioma.Name = "cbIdioma";
            cbIdioma.SelectedIndexChanged += cbIdioma_SelectedIndexChanged;
            // 
            // lIdioma
            // 
            resources.ApplyResources(lIdioma, "lIdioma");
            lIdioma.BackColor = Color.Gold;
            lIdioma.Name = "lIdioma";
            // 
            // lTitulo
            // 
            resources.ApplyResources(lTitulo, "lTitulo");
            lTitulo.BackColor = Color.Gold;
            lTitulo.ForeColor = Color.Crimson;
            lTitulo.Name = "lTitulo";
            // 
            // gbLotes
            // 
            resources.ApplyResources(gbLotes, "gbLotes");
            gbLotes.BackColor = Color.Cornsilk;
            gbLotes.Controls.Add(dataGridView1);
            gbLotes.FlatStyle = FlatStyle.Popup;
            gbLotes.Name = "gbLotes";
            gbLotes.TabStop = false;
            // 
            // dataGridView1
            // 
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.Cornsilk;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { cIdLote, cFecha, cCantidad, cTotalLote });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // cIdLote
            // 
            resources.ApplyResources(cIdLote, "cIdLote");
            cIdLote.Name = "cIdLote";
            cIdLote.ReadOnly = true;
            // 
            // cFecha
            // 
            resources.ApplyResources(cFecha, "cFecha");
            cFecha.Name = "cFecha";
            cFecha.ReadOnly = true;
            // 
            // cCantidad
            // 
            resources.ApplyResources(cCantidad, "cCantidad");
            cCantidad.Name = "cCantidad";
            cCantidad.ReadOnly = true;
            // 
            // cTotalLote
            // 
            resources.ApplyResources(cTotalLote, "cTotalLote");
            cTotalLote.Name = "cTotalLote";
            cTotalLote.ReadOnly = true;
            // 
            // gbPaquetes
            // 
            resources.ApplyResources(gbPaquetes, "gbPaquetes");
            gbPaquetes.BackColor = Color.Cornsilk;
            gbPaquetes.Controls.Add(dgvPaquetes);
            gbPaquetes.Name = "gbPaquetes";
            gbPaquetes.TabStop = false;
            // 
            // dgvPaquetes
            // 
            resources.ApplyResources(dgvPaquetes, "dgvPaquetes");
            dgvPaquetes.AllowUserToAddRows = false;
            dgvPaquetes.AllowUserToDeleteRows = false;
            dgvPaquetes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaquetes.BackgroundColor = Color.Cornsilk;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.Gold;
            dataGridViewCellStyle6.Font = new Font("Century Gothic", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvPaquetes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvPaquetes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaquetes.Columns.AddRange(new DataGridViewColumn[] { cCodigo, cCliente, cZona, cPeso, cValorDeclarado, cTotal });
            dgvPaquetes.MultiSelect = false;
            dgvPaquetes.Name = "dgvPaquetes";
            dgvPaquetes.ReadOnly = true;
            dgvPaquetes.RowHeadersVisible = false;
            dgvPaquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            // bActualizar
            // 
            resources.ApplyResources(bActualizar, "bActualizar");
            bActualizar.BackColor = Color.Gold;
            bActualizar.ForeColor = Color.Crimson;
            bActualizar.Name = "bActualizar";
            bActualizar.UseVisualStyleBackColor = false;
            // 
            // bCerrar
            // 
            resources.ApplyResources(bCerrar, "bCerrar");
            bCerrar.BackColor = Color.Gold;
            bCerrar.ForeColor = Color.Crimson;
            bCerrar.Name = "bCerrar";
            bCerrar.UseVisualStyleBackColor = false;
            bCerrar.Click += bCerrar_Click;
            // 
            // FrmHistorial
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(bCerrar);
            Controls.Add(bActualizar);
            Controls.Add(gbDetalle);
            Controls.Add(gbPaquetes);
            Controls.Add(gbLotes);
            Controls.Add(cbIdioma);
            Controls.Add(lIdioma);
            Controls.Add(lTitulo);
            Name = "FrmHistorial";
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
        private GroupBox gbPaquetes;
        private DataGridView dgvPaquetes;
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
        private DataGridViewTextBoxColumn cIdLote;
        private DataGridViewTextBoxColumn cFecha;
        private DataGridViewTextBoxColumn cCantidad;
        private DataGridViewTextBoxColumn cTotalLote;
        private DataGridViewTextBoxColumn cCodigo;
        private DataGridViewTextBoxColumn cCliente;
        private DataGridViewTextBoxColumn cZona;
        private DataGridViewTextBoxColumn cPeso;
        private DataGridViewTextBoxColumn cValorDeclarado;
        private DataGridViewTextBoxColumn cTotal;
    }
}