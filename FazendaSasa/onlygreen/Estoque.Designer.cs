namespace onlygreen
{
    partial class Estoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estoque));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkEsgotado = new System.Windows.Forms.CheckBox();
            this.checkDisponivel = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbEstoque = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcolheitaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbEstoqueBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bdonlygreenDataSet13 = new onlygreen.bdonlygreenDataSet13();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnSalvar2 = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdproducao = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDregistroProducao = new System.Windows.Forms.MaskedTextBox();
            this.txtValidade = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtEstimativa = new System.Windows.Forms.MaskedTextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.tbEstoqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_EstoqueTableAdapter1 = new onlygreen.bdonlygreenDataSet13TableAdapters.tb_EstoqueTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEstoqueBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdonlygreenDataSet13)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEstoqueBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkEsgotado);
            this.groupBox1.Controls.Add(this.checkDisponivel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbEstoque);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnVoltar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPesquisar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1511, 742);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestão do estoque";
            // 
            // checkEsgotado
            // 
            this.checkEsgotado.AutoSize = true;
            this.checkEsgotado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEsgotado.Location = new System.Drawing.Point(646, 34);
            this.checkEsgotado.Name = "checkEsgotado";
            this.checkEsgotado.Size = new System.Drawing.Size(109, 24);
            this.checkEsgotado.TabIndex = 1;
            this.checkEsgotado.Text = "Esgotado";
            this.checkEsgotado.UseVisualStyleBackColor = true;
            this.checkEsgotado.CheckedChanged += new System.EventHandler(this.checkEsgotado_CheckedChanged);
            // 
            // checkDisponivel
            // 
            this.checkDisponivel.AutoSize = true;
            this.checkDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDisponivel.Location = new System.Drawing.Point(506, 35);
            this.checkDisponivel.Name = "checkDisponivel";
            this.checkDisponivel.Size = new System.Drawing.Size(119, 24);
            this.checkDisponivel.TabIndex = 0;
            this.checkDisponivel.Text = "Disponível";
            this.checkDisponivel.UseVisualStyleBackColor = true;
            this.checkDisponivel.CheckedChanged += new System.EventHandler(this.checkDisponivel_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(433, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 25);
            this.label12.TabIndex = 33;
            this.label12.Text = "Filtro:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1242, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(258, 25);
            this.label11.TabIndex = 32;
            this.label11.Text = "Visualizar/alterar estoque";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1003, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 25);
            this.label10.TabIndex = 31;
            this.label10.Text = "Adicionar produto";
            // 
            // tbEstoque
            // 
            this.tbEstoque.AllowUserToDeleteRows = false;
            this.tbEstoque.AutoGenerateColumns = false;
            this.tbEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.dcolheitaDataGridViewTextBoxColumn,
            this.precoDataGridViewTextBoxColumn,
            this.situacaoDataGridViewTextBoxColumn});
            this.tbEstoque.DataSource = this.tbEstoqueBindingSource1;
            this.tbEstoque.EnableHeadersVisualStyles = false;
            this.tbEstoque.Location = new System.Drawing.Point(28, 136);
            this.tbEstoque.MultiSelect = false;
            this.tbEstoque.Name = "tbEstoque";
            this.tbEstoque.ReadOnly = true;
            this.tbEstoque.RowHeadersVisible = false;
            this.tbEstoque.RowHeadersWidth = 51;
            this.tbEstoque.RowTemplate.Height = 24;
            this.tbEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbEstoque.Size = new System.Drawing.Size(892, 577);
            this.tbEstoque.TabIndex = 30;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeDataGridViewTextBoxColumn.Width = 125;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantidadeDataGridViewTextBoxColumn.Width = 125;
            // 
            // dcolheitaDataGridViewTextBoxColumn
            // 
            this.dcolheitaDataGridViewTextBoxColumn.DataPropertyName = "dcolheita";
            this.dcolheitaDataGridViewTextBoxColumn.HeaderText = "Registro";
            this.dcolheitaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dcolheitaDataGridViewTextBoxColumn.Name = "dcolheitaDataGridViewTextBoxColumn";
            this.dcolheitaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dcolheitaDataGridViewTextBoxColumn.Width = 125;
            // 
            // precoDataGridViewTextBoxColumn
            // 
            this.precoDataGridViewTextBoxColumn.DataPropertyName = "preco";
            this.precoDataGridViewTextBoxColumn.HeaderText = "Preço";
            this.precoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.precoDataGridViewTextBoxColumn.Name = "precoDataGridViewTextBoxColumn";
            this.precoDataGridViewTextBoxColumn.ReadOnly = true;
            this.precoDataGridViewTextBoxColumn.Width = 125;
            // 
            // situacaoDataGridViewTextBoxColumn
            // 
            this.situacaoDataGridViewTextBoxColumn.DataPropertyName = "situacao";
            this.situacaoDataGridViewTextBoxColumn.HeaderText = "Situação";
            this.situacaoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.situacaoDataGridViewTextBoxColumn.Name = "situacaoDataGridViewTextBoxColumn";
            this.situacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.situacaoDataGridViewTextBoxColumn.Width = 125;
            // 
            // tbEstoqueBindingSource1
            // 
            this.tbEstoqueBindingSource1.DataMember = "tb_Estoque";
            this.tbEstoqueBindingSource1.DataSource = this.bdonlygreenDataSet13;
            // 
            // bdonlygreenDataSet13
            // 
            this.bdonlygreenDataSet13.DataSetName = "bdonlygreenDataSet13";
            this.bdonlygreenDataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtId);
            this.panel2.Controls.Add(this.btnSelecionar);
            this.panel2.Controls.Add(this.btnSalvar);
            this.panel2.Location = new System.Drawing.Point(1249, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 192);
            this.panel2.TabIndex = 5;
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
            this.btnSelecionar.Location = new System.Drawing.Point(18, 84);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(209, 32);
            this.btnSelecionar.TabIndex = 1;
            this.btnSelecionar.Text = "Selecionar produto";
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
            this.btnSalvar.Location = new System.Drawing.Point(18, 131);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(209, 32);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar alteração";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.Enter += new System.EventHandler(this.btnSalvar_Enter);
            this.btnSalvar.Leave += new System.EventHandler(this.btnSalvar_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.btnSalvar2);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIdproducao);
            this.panel1.Location = new System.Drawing.Point(948, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 192);
            this.panel1.TabIndex = 4;
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
            // btnSalvar2
            // 
            this.btnSalvar2.BackColor = System.Drawing.Color.Silver;
            this.btnSalvar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar2.Location = new System.Drawing.Point(23, 106);
            this.btnSalvar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvar2.Name = "btnSalvar2";
            this.btnSalvar2.Size = new System.Drawing.Size(245, 32);
            this.btnSalvar2.TabIndex = 2;
            this.btnSalvar2.Text = "Salvar no estoque";
            this.btnSalvar2.UseVisualStyleBackColor = false;
            this.btnSalvar2.Click += new System.EventHandler(this.btnSalvar2_Click);
            this.btnSalvar2.Enter += new System.EventHandler(this.btnSalvar2_Enter);
            this.btnSalvar2.Leave += new System.EventHandler(this.btnSalvar2_Leave);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.Silver;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Location = new System.Drawing.Point(127, 22);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(141, 78);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Selecionar novo produto";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            this.btnAdicionar.Enter += new System.EventHandler(this.btnAdicionar_Enter);
            this.btnAdicionar.Leave += new System.EventHandler(this.btnAdicionar_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 40);
            this.label1.TabIndex = 12;
            this.label1.Text = "ID \r\nprodução";
            // 
            // txtIdproducao
            // 
            this.txtIdproducao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdproducao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdproducao.Location = new System.Drawing.Point(23, 67);
            this.txtIdproducao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdproducao.MaxLength = 5;
            this.txtIdproducao.Name = "txtIdproducao";
            this.txtIdproducao.Size = new System.Drawing.Size(67, 28);
            this.txtIdproducao.TabIndex = 0;
            this.txtIdproducao.Enter += new System.EventHandler(this.txtIdproducao_Enter);
            this.txtIdproducao.Leave += new System.EventHandler(this.txtIdproducao_Leave);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Silver;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(1355, 27);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(150, 35);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.Enter += new System.EventHandler(this.btnVoltar_Enter);
            this.btnVoltar.Leave += new System.EventHandler(this.btnVoltar_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Silver;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(805, 71);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(115, 57);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.Enter += new System.EventHandler(this.btnBuscar_Enter);
            this.btnBuscar.Leave += new System.EventHandler(this.btnBuscar_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "Pesquisar";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisar.Location = new System.Drawing.Point(28, 83);
            this.txtPesquisar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(742, 30);
            this.txtPesquisar.TabIndex = 2;
            this.txtPesquisar.Enter += new System.EventHandler(this.txtPesquisar_Enter);
            this.txtPesquisar.Leave += new System.EventHandler(this.txtPesquisar_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDregistroProducao);
            this.groupBox2.Controls.Add(this.txtValidade);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPreco);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtQuantidade);
            this.groupBox2.Controls.Add(this.txtEstimativa);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Location = new System.Drawing.Point(948, 352);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(552, 361);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(295, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Registro da produção";
            // 
            // txtDregistroProducao
            // 
            this.txtDregistroProducao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDregistroProducao.Location = new System.Drawing.Point(300, 101);
            this.txtDregistroProducao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDregistroProducao.Mask = "00/00/0000";
            this.txtDregistroProducao.Name = "txtDregistroProducao";
            this.txtDregistroProducao.ReadOnly = true;
            this.txtDregistroProducao.Size = new System.Drawing.Size(184, 30);
            this.txtDregistroProducao.TabIndex = 1;
            // 
            // txtValidade
            // 
            this.txtValidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidade.Location = new System.Drawing.Point(298, 250);
            this.txtValidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValidade.Mask = "00/00/0000";
            this.txtValidade.Name = "txtValidade";
            this.txtValidade.Size = new System.Drawing.Size(184, 30);
            this.txtValidade.TabIndex = 6;
            this.txtValidade.Enter += new System.EventHandler(this.txtValidade_Enter);
            this.txtValidade.Leave += new System.EventHandler(this.txtValidade_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Preço";
            // 
            // txtPreco
            // 
            this.txtPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreco.Location = new System.Drawing.Point(34, 250);
            this.txtPreco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPreco.MaxLength = 10;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(186, 30);
            this.txtPreco.TabIndex = 4;
            this.txtPreco.Enter += new System.EventHandler(this.txtPreco_Enter);
            this.txtPreco.Leave += new System.EventHandler(this.txtPreco_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(294, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Validade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Estimativa da colheita";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Quantidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nome";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantidade.Location = new System.Drawing.Point(298, 177);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(186, 30);
            this.txtQuantidade.TabIndex = 3;
            this.txtQuantidade.Enter += new System.EventHandler(this.txtQuantidade_Enter);
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // txtEstimativa
            // 
            this.txtEstimativa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstimativa.Location = new System.Drawing.Point(34, 101);
            this.txtEstimativa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEstimativa.Mask = "00/00/0000";
            this.txtEstimativa.Name = "txtEstimativa";
            this.txtEstimativa.ReadOnly = true;
            this.txtEstimativa.Size = new System.Drawing.Size(186, 30);
            this.txtEstimativa.TabIndex = 0;
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(33, 177);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(186, 30);
            this.txtNome.TabIndex = 2;
            // 
            // tbEstoqueBindingSource
            // 
            this.tbEstoqueBindingSource.DataMember = "tb_Estoque";
            // 
            // tb_EstoqueTableAdapter1
            // 
            this.tb_EstoqueTableAdapter1.ClearBeforeFill = true;
            // 
            // Estoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 770);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Estoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlyGreen";
            this.Load += new System.EventHandler(this.Estoque_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEstoqueBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdonlygreenDataSet13)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEstoqueBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.MaskedTextBox txtEstimativa;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdproducao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtValidade;

        private System.Windows.Forms.BindingSource tbEstoqueBindingSource;

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Button btnSalvar2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtDregistroProducao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tbEstoque;
        private bdonlygreenDataSet13 bdonlygreenDataSet13;
        private System.Windows.Forms.BindingSource tbEstoqueBindingSource1;
        private bdonlygreenDataSet13TableAdapters.tb_EstoqueTableAdapter tb_EstoqueTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dcolheitaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkEsgotado;
        private System.Windows.Forms.CheckBox checkDisponivel;
    }
}