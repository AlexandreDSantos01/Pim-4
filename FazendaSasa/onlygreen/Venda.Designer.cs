namespace onlygreen
{
    partial class Venda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Venda));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbVenda = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dregistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbVendaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bdonlygreenDataSet16 = new onlygreen.bdonlygreenDataSet16();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRegistro = new System.Windows.Forms.MaskedTextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtIdcliente = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelecionarestoque = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdestoque = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bdonlygreenDataSet15 = new onlygreen.bdonlygreenDataSet15();
            this.tbVendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_VendaTableAdapter = new onlygreen.bdonlygreenDataSet15TableAdapters.tb_VendaTableAdapter();
            this.tb_VendaTableAdapter1 = new onlygreen.bdonlygreenDataSet16TableAdapters.tb_VendaTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVendaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdonlygreenDataSet16)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdonlygreenDataSet15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVendaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbVenda);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnVoltar);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPesquisar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1512, 746);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestão de venda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tbVenda
            // 
            this.tbVenda.AllowUserToDeleteRows = false;
            this.tbVenda.AutoGenerateColumns = false;
            this.tbVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.dregistroDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn});
            this.tbVenda.DataSource = this.tbVendaBindingSource1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tbVenda.DefaultCellStyle = dataGridViewCellStyle1;
            this.tbVenda.EnableHeadersVisualStyles = false;
            this.tbVenda.Location = new System.Drawing.Point(23, 147);
            this.tbVenda.MultiSelect = false;
            this.tbVenda.Name = "tbVenda";
            this.tbVenda.ReadOnly = true;
            this.tbVenda.RowHeadersVisible = false;
            this.tbVenda.RowHeadersWidth = 51;
            this.tbVenda.RowTemplate.Height = 24;
            this.tbVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbVenda.Size = new System.Drawing.Size(862, 548);
            this.tbVenda.TabIndex = 6;
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
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.MaxInputLength = 30;
            this.nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn.Width = 125;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.quantidadeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantidadeDataGridViewTextBoxColumn.Width = 125;
            // 
            // dregistroDataGridViewTextBoxColumn
            // 
            this.dregistroDataGridViewTextBoxColumn.DataPropertyName = "dregistro";
            this.dregistroDataGridViewTextBoxColumn.HeaderText = "Registro";
            this.dregistroDataGridViewTextBoxColumn.MaxInputLength = 30;
            this.dregistroDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dregistroDataGridViewTextBoxColumn.Name = "dregistroDataGridViewTextBoxColumn";
            this.dregistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.dregistroDataGridViewTextBoxColumn.Width = 125;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.valorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorDataGridViewTextBoxColumn.Width = 125;
            // 
            // tbVendaBindingSource1
            // 
            this.tbVendaBindingSource1.DataMember = "tb_Venda";
            this.tbVendaBindingSource1.DataSource = this.bdonlygreenDataSet16;
            // 
            // bdonlygreenDataSet16
            // 
            this.bdonlygreenDataSet16.DataSetName = "bdonlygreenDataSet16";
            this.bdonlygreenDataSet16.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtRegistro);
            this.groupBox2.Controls.Add(this.txtValor);
            this.groupBox2.Controls.Add(this.txtQuantidade);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.txtIdcliente);
            this.groupBox2.Location = new System.Drawing.Point(939, 383);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 312);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Venda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 25);
            this.label6.TabIndex = 27;
            this.label6.Text = "R$";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "Valor";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "Quantidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nome produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "ID cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(271, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Registro";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtRegistro
            // 
            this.txtRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistro.Location = new System.Drawing.Point(277, 230);
            this.txtRegistro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRegistro.Mask = "00/00/0000";
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.ReadOnly = true;
            this.txtRegistro.Size = new System.Drawing.Size(184, 30);
            this.txtRegistro.TabIndex = 4;
            this.txtRegistro.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtRegistro_MaskInputRejected);
            // 
            // txtValor
            // 
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Location = new System.Drawing.Point(49, 230);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(139, 30);
            this.txtValor.TabIndex = 3;
            this.txtValor.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtValor.Enter += new System.EventHandler(this.txtValor_Enter);
            this.txtValor.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantidade.Location = new System.Drawing.Point(48, 159);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(139, 30);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.Enter += new System.EventHandler(this.txtQuantidade_Enter);
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(48, 89);
            this.txtNome.MaxLength = 30;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(139, 30);
            this.txtNome.TabIndex = 0;
            // 
            // txtIdcliente
            // 
            this.txtIdcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdcliente.Location = new System.Drawing.Point(279, 89);
            this.txtIdcliente.MaxLength = 10;
            this.txtIdcliente.Name = "txtIdcliente";
            this.txtIdcliente.Size = new System.Drawing.Size(100, 30);
            this.txtIdcliente.TabIndex = 1;
            this.txtIdcliente.Enter += new System.EventHandler(this.txtIdcliente_Enter);
            this.txtIdcliente.Leave += new System.EventHandler(this.txtIdcliente_Leave);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1166, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(313, 25);
            this.label11.TabIndex = 39;
            this.label11.Text = "Visualizar/alterar/deletar venda\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(959, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(168, 25);
            this.label10.TabIndex = 38;
            this.label10.Text = "Adicionar venda";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtId);
            this.panel2.Controls.Add(this.btnSelecionar);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Location = new System.Drawing.Point(1205, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 192);
            this.panel2.TabIndex = 3;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Silver;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(18, 142);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(209, 31);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Deletar";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            this.btnDel.Enter += new System.EventHandler(this.btnDel_Enter);
            this.btnDel.Leave += new System.EventHandler(this.btnDel_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(56, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 22);
            this.label14.TabIndex = 3;
            this.label14.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(92, 34);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.MaxLength = 5;
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
            this.btnSelecionar.Location = new System.Drawing.Point(18, 68);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(209, 32);
            this.btnSelecionar.TabIndex = 1;
            this.btnSelecionar.Text = "Selecionar venda";
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            this.btnSelecionar.Enter += new System.EventHandler(this.btnSelecionar_Enter);
            this.btnSelecionar.Leave += new System.EventHandler(this.btnSelecionar_Leave);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Silver;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(18, 105);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(209, 32);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.Enter += new System.EventHandler(this.btnSalvar_Enter);
            this.btnSalvar.Leave += new System.EventHandler(this.btnSalvar_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSelecionarestoque);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIdestoque);
            this.panel1.Location = new System.Drawing.Point(904, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 192);
            this.panel1.TabIndex = 2;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(23, 142);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(245, 31);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar campos";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            this.btnLimpar.Enter += new System.EventHandler(this.btnLimpar_Enter);
            this.btnLimpar.Leave += new System.EventHandler(this.btnLimpar_Leave);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Silver;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(23, 106);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(245, 32);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.btnAdd_Enter);
            this.btnAdd.Leave += new System.EventHandler(this.btnAdd_Leave);
            // 
            // btnSelecionarestoque
            // 
            this.btnSelecionarestoque.BackColor = System.Drawing.Color.Silver;
            this.btnSelecionarestoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarestoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarestoque.Location = new System.Drawing.Point(127, 22);
            this.btnSelecionarestoque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionarestoque.Name = "btnSelecionarestoque";
            this.btnSelecionarestoque.Size = new System.Drawing.Size(141, 78);
            this.btnSelecionarestoque.TabIndex = 1;
            this.btnSelecionarestoque.Text = "Selecionar produto ";
            this.btnSelecionarestoque.UseVisualStyleBackColor = false;
            this.btnSelecionarestoque.Click += new System.EventHandler(this.btnSelecionarestoque_Click);
            this.btnSelecionarestoque.Enter += new System.EventHandler(this.btnSelecionarestoque_Enter);
            this.btnSelecionarestoque.Leave += new System.EventHandler(this.btnSelecionarestoque_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "ID estoque";
            // 
            // txtIdestoque
            // 
            this.txtIdestoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdestoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdestoque.Location = new System.Drawing.Point(23, 67);
            this.txtIdestoque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdestoque.MaxLength = 5;
            this.txtIdestoque.Name = "txtIdestoque";
            this.txtIdestoque.Size = new System.Drawing.Size(67, 28);
            this.txtIdestoque.TabIndex = 0;
            this.txtIdestoque.Enter += new System.EventHandler(this.txtIdestoque_Enter);
            this.txtIdestoque.Leave += new System.EventHandler(this.txtIdestoque_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Silver;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(800, 65);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 57);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.Enter += new System.EventHandler(this.btnBuscar_Enter);
            this.btnBuscar.Leave += new System.EventHandler(this.btnBuscar_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 25);
            this.label8.TabIndex = 35;
            this.label8.Text = "Pesquisar";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisar.Location = new System.Drawing.Point(23, 77);
            this.txtPesquisar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(742, 30);
            this.txtPesquisar.TabIndex = 0;
            this.txtPesquisar.Enter += new System.EventHandler(this.txtPesquisar_Enter);
            this.txtPesquisar.Leave += new System.EventHandler(this.txtPesquisar_Leave);
            // 
            // bdonlygreenDataSet15
            // 
            this.bdonlygreenDataSet15.DataSetName = "bdonlygreenDataSet15";
            this.bdonlygreenDataSet15.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbVendaBindingSource
            // 
            this.tbVendaBindingSource.DataMember = "tb_Venda";
            this.tbVendaBindingSource.DataSource = this.bdonlygreenDataSet15;
            // 
            // tb_VendaTableAdapter
            // 
            this.tb_VendaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_VendaTableAdapter1
            // 
            this.tb_VendaTableAdapter1.ClearBeforeFill = true;
            // 
            // Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 770);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Venda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlyGreen";
            this.Load += new System.EventHandler(this.Venda_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVendaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdonlygreenDataSet16)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdonlygreenDataSet15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVendaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSelecionarestoque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdestoque;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtIdcliente;
        private System.Windows.Forms.Button btnVoltar;
        private bdonlygreenDataSet15 bdonlygreenDataSet15;
        private System.Windows.Forms.BindingSource tbVendaBindingSource;
        private bdonlygreenDataSet15TableAdapters.tb_VendaTableAdapter tb_VendaTableAdapter;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtRegistro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView tbVenda;
        private bdonlygreenDataSet16 bdonlygreenDataSet16;
        private System.Windows.Forms.BindingSource tbVendaBindingSource1;
        private bdonlygreenDataSet16TableAdapters.tb_VendaTableAdapter tb_VendaTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dregistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
    }
}