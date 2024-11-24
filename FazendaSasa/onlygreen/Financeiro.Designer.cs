namespace onlygreen
{
    partial class Financeiro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Financeiro));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLucro = new System.Windows.Forms.TextBox();
            this.txtDespesa = new System.Windows.Forms.TextBox();
            this.txtVenda = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDregistro = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAte = new System.Windows.Forms.MaskedTextBox();
            this.txtDe = new System.Windows.Forms.MaskedTextBox();
            this.tbFinanceiro = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dregistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diainicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diafimDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorlucroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbFinanceiroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bdonlygreenDataSet18 = new onlygreen.bdonlygreenDataSet18();
            this.tb_FinanceiroTableAdapter = new onlygreen.bdonlygreenDataSet18TableAdapters.tb_FinanceiroTableAdapter();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFinanceiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFinanceiroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdonlygreenDataSet18)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVoltar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPesquisar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbFinanceiro);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1512, 746);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestão financeira";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Silver;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(1391, 28);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(115, 36);
            this.btnVoltar.TabIndex = 5;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.Enter += new System.EventHandler(this.btnVoltar_Enter);
            this.btnVoltar.Leave += new System.EventHandler(this.btnVoltar_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1156, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 25);
            this.label3.TabIndex = 46;
            this.label3.Text = "Visualizar/deletar relatório\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(850, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 45;
            this.label2.Text = "Adicionar relatório";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtId);
            this.panel2.Controls.Add(this.btnSelecionar);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Location = new System.Drawing.Point(1130, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 158);
            this.panel2.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(101, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 22);
            this.label14.TabIndex = 3;
            this.label14.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(137, 13);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(76, 28);
            this.txtId.TabIndex = 0;
            this.txtId.Enter += new System.EventHandler(this.txtId_Enter);
            this.txtId.Leave += new System.EventHandler(this.txtId_Leave);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.Color.Silver;
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionar.Location = new System.Drawing.Point(31, 64);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(256, 32);
            this.btnSelecionar.TabIndex = 1;
            this.btnSelecionar.Text = "Selecionar relatório";
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            this.btnSelecionar.Enter += new System.EventHandler(this.btnSelecionar_Enter);
            this.btnSelecionar.Leave += new System.EventHandler(this.btnSelecionar_Leave);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Silver;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(31, 108);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(256, 32);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Deletar";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            this.btnDel.Enter += new System.EventHandler(this.btnDel_Enter);
            this.btnDel.Leave += new System.EventHandler(this.btnDel_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Location = new System.Drawing.Point(811, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 158);
            this.panel1.TabIndex = 2;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.Silver;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Location = new System.Drawing.Point(24, 13);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(212, 78);
            this.btnAdicionar.TabIndex = 0;
            this.btnAdicionar.Text = "Adicionar novo relatório\r\n";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            this.btnAdicionar.Enter += new System.EventHandler(this.btnAdicionar_Enter);
            this.btnAdicionar.Leave += new System.EventHandler(this.btnAdicionar_Leave);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(24, 108);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(212, 31);
            this.btnLimpar.TabIndex = 1;
            this.btnLimpar.Text = "Limpar campos";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            this.btnLimpar.Enter += new System.EventHandler(this.btnLimpar_Enter);
            this.btnLimpar.Leave += new System.EventHandler(this.btnLimpar_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Silver;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(602, 88);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 47);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.Enter += new System.EventHandler(this.btnBuscar_Enter);
            this.btnBuscar.Leave += new System.EventHandler(this.btnBuscar_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 42;
            this.label1.Text = "Pesquisar";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisar.Location = new System.Drawing.Point(53, 95);
            this.txtPesquisar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(525, 30);
            this.txtPesquisar.TabIndex = 0;
            this.txtPesquisar.Enter += new System.EventHandler(this.txtPesquisar_Enter);
            this.txtPesquisar.Leave += new System.EventHandler(this.txtPesquisar_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtLucro);
            this.groupBox2.Controls.Add(this.txtDespesa);
            this.groupBox2.Controls.Add(this.txtVenda);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDregistro);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtAte);
            this.groupBox2.Controls.Add(this.txtDe);
            this.groupBox2.Location = new System.Drawing.Point(800, 373);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 322);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Relatório";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(423, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 25);
            this.label12.TabIndex = 4;
            this.label12.Text = "R$";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 25);
            this.label11.TabIndex = 54;
            this.label11.Text = "R$";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 25);
            this.label10.TabIndex = 53;
            this.label10.Text = "R$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 25);
            this.label9.TabIndex = 52;
            this.label9.Text = "Lucro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(459, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 25);
            this.label8.TabIndex = 51;
            this.label8.Text = "Despesas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 25);
            this.label7.TabIndex = 50;
            this.label7.Text = "Vendas";
            // 
            // txtLucro
            // 
            this.txtLucro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLucro.Location = new System.Drawing.Point(264, 250);
            this.txtLucro.Name = "txtLucro";
            this.txtLucro.ReadOnly = true;
            this.txtLucro.Size = new System.Drawing.Size(125, 30);
            this.txtLucro.TabIndex = 5;
            // 
            // txtDespesa
            // 
            this.txtDespesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDespesa.Location = new System.Drawing.Point(467, 189);
            this.txtDespesa.Name = "txtDespesa";
            this.txtDespesa.ReadOnly = true;
            this.txtDespesa.Size = new System.Drawing.Size(125, 30);
            this.txtDespesa.TabIndex = 4;
            // 
            // txtVenda
            // 
            this.txtVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVenda.Location = new System.Drawing.Point(264, 189);
            this.txtVenda.Name = "txtVenda";
            this.txtVenda.ReadOnly = true;
            this.txtVenda.Size = new System.Drawing.Size(125, 30);
            this.txtVenda.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 46;
            this.label6.Text = "Registro";
            // 
            // txtDregistro
            // 
            this.txtDregistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDregistro.Location = new System.Drawing.Point(81, 189);
            this.txtDregistro.Mask = "00/00/0000";
            this.txtDregistro.Name = "txtDregistro";
            this.txtDregistro.ReadOnly = true;
            this.txtDregistro.Size = new System.Drawing.Size(126, 30);
            this.txtDregistro.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 25);
            this.label5.TabIndex = 44;
            this.label5.Text = "Até";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 25);
            this.label4.TabIndex = 43;
            this.label4.Text = "De";
            // 
            // txtAte
            // 
            this.txtAte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAte.Location = new System.Drawing.Point(378, 69);
            this.txtAte.Mask = "00/00/0000";
            this.txtAte.Name = "txtAte";
            this.txtAte.Size = new System.Drawing.Size(126, 30);
            this.txtAte.TabIndex = 1;
            this.txtAte.Enter += new System.EventHandler(this.txtAte_Enter);
            this.txtAte.Leave += new System.EventHandler(this.txtAte_Leave);
            // 
            // txtDe
            // 
            this.txtDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDe.Location = new System.Drawing.Point(172, 69);
            this.txtDe.Mask = "00/00/0000";
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(126, 30);
            this.txtDe.TabIndex = 0;
            this.txtDe.Enter += new System.EventHandler(this.txtDe_Enter);
            this.txtDe.Leave += new System.EventHandler(this.txtDe_Leave);
            // 
            // tbFinanceiro
            // 
            this.tbFinanceiro.AllowUserToDeleteRows = false;
            this.tbFinanceiro.AutoGenerateColumns = false;
            this.tbFinanceiro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbFinanceiro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dregistroDataGridViewTextBoxColumn,
            this.diainicioDataGridViewTextBoxColumn,
            this.diafimDataGridViewTextBoxColumn,
            this.valorlucroDataGridViewTextBoxColumn});
            this.tbFinanceiro.DataSource = this.tbFinanceiroBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tbFinanceiro.DefaultCellStyle = dataGridViewCellStyle1;
            this.tbFinanceiro.EnableHeadersVisualStyles = false;
            this.tbFinanceiro.Location = new System.Drawing.Point(26, 162);
            this.tbFinanceiro.MultiSelect = false;
            this.tbFinanceiro.Name = "tbFinanceiro";
            this.tbFinanceiro.ReadOnly = true;
            this.tbFinanceiro.RowHeadersVisible = false;
            this.tbFinanceiro.RowHeadersWidth = 51;
            this.tbFinanceiro.RowTemplate.Height = 24;
            this.tbFinanceiro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbFinanceiro.Size = new System.Drawing.Size(728, 533);
            this.tbFinanceiro.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // dregistroDataGridViewTextBoxColumn
            // 
            this.dregistroDataGridViewTextBoxColumn.DataPropertyName = "dregistro";
            this.dregistroDataGridViewTextBoxColumn.HeaderText = "Registro";
            this.dregistroDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.dregistroDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dregistroDataGridViewTextBoxColumn.Name = "dregistroDataGridViewTextBoxColumn";
            this.dregistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.dregistroDataGridViewTextBoxColumn.Width = 125;
            // 
            // diainicioDataGridViewTextBoxColumn
            // 
            this.diainicioDataGridViewTextBoxColumn.DataPropertyName = "diainicio";
            this.diainicioDataGridViewTextBoxColumn.HeaderText = "De";
            this.diainicioDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.diainicioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.diainicioDataGridViewTextBoxColumn.Name = "diainicioDataGridViewTextBoxColumn";
            this.diainicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.diainicioDataGridViewTextBoxColumn.Width = 125;
            // 
            // diafimDataGridViewTextBoxColumn
            // 
            this.diafimDataGridViewTextBoxColumn.DataPropertyName = "diafim";
            this.diafimDataGridViewTextBoxColumn.HeaderText = "Até";
            this.diafimDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.diafimDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.diafimDataGridViewTextBoxColumn.Name = "diafimDataGridViewTextBoxColumn";
            this.diafimDataGridViewTextBoxColumn.ReadOnly = true;
            this.diafimDataGridViewTextBoxColumn.Width = 125;
            // 
            // valorlucroDataGridViewTextBoxColumn
            // 
            this.valorlucroDataGridViewTextBoxColumn.DataPropertyName = "valorlucro";
            this.valorlucroDataGridViewTextBoxColumn.HeaderText = "Lucro";
            this.valorlucroDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.valorlucroDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valorlucroDataGridViewTextBoxColumn.Name = "valorlucroDataGridViewTextBoxColumn";
            this.valorlucroDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorlucroDataGridViewTextBoxColumn.Width = 125;
            // 
            // tbFinanceiroBindingSource
            // 
            this.tbFinanceiroBindingSource.DataMember = "tb_Financeiro";
            this.tbFinanceiroBindingSource.DataSource = this.bdonlygreenDataSet18;
            // 
            // bdonlygreenDataSet18
            // 
            this.bdonlygreenDataSet18.DataSetName = "bdonlygreenDataSet18";
            this.bdonlygreenDataSet18.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_FinanceiroTableAdapter
            // 
            this.tb_FinanceiroTableAdapter.ClearBeforeFill = true;
            // 
            // Financeiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 770);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Financeiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlyGreen";
            this.Load += new System.EventHandler(this.Financeiro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFinanceiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFinanceiroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdonlygreenDataSet18)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tbFinanceiro;
        private bdonlygreenDataSet18 bdonlygreenDataSet18;
        private System.Windows.Forms.BindingSource tbFinanceiroBindingSource;
        private bdonlygreenDataSet18TableAdapters.tb_FinanceiroTableAdapter tb_FinanceiroTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.MaskedTextBox txtAte;
        private System.Windows.Forms.MaskedTextBox txtDe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dregistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diainicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diafimDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorlucroDataGridViewTextBoxColumn;
        private System.Windows.Forms.MaskedTextBox txtDregistro;
        private System.Windows.Forms.TextBox txtLucro;
        private System.Windows.Forms.TextBox txtDespesa;
        private System.Windows.Forms.TextBox txtVenda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnVoltar;
    }
}