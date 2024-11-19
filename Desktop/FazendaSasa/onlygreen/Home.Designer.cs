namespace onlygreen
{
    partial class Home
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
            this.gpHome = new System.Windows.Forms.GroupBox();
            this.lblTipousuario = new System.Windows.Forms.Label();
            this.lblBemvindo = new System.Windows.Forms.Label();
            this.btnFinanceiro = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnDespesa = new System.Windows.Forms.Button();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnProducao = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.gpHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpHome
            // 
            this.gpHome.Controls.Add(this.lblTipousuario);
            this.gpHome.Controls.Add(this.lblBemvindo);
            this.gpHome.Controls.Add(this.btnFinanceiro);
            this.gpHome.Controls.Add(this.btnSair);
            this.gpHome.Controls.Add(this.btnDespesa);
            this.gpHome.Controls.Add(this.btnFornecedor);
            this.gpHome.Controls.Add(this.btnCliente);
            this.gpHome.Controls.Add(this.btnVenda);
            this.gpHome.Controls.Add(this.btnEstoque);
            this.gpHome.Controls.Add(this.btnProducao);
            this.gpHome.Controls.Add(this.btnUsuario);
            this.gpHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpHome.Location = new System.Drawing.Point(12, 12);
            this.gpHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpHome.Name = "gpHome";
            this.gpHome.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpHome.Size = new System.Drawing.Size(1512, 747);
            this.gpHome.TabIndex = 0;
            this.gpHome.TabStop = false;
            this.gpHome.Text = "Home";
            // 
            // lblTipousuario
            // 
            this.lblTipousuario.AutoSize = true;
            this.lblTipousuario.Location = new System.Drawing.Point(118, 62);
            this.lblTipousuario.Name = "lblTipousuario";
            this.lblTipousuario.Size = new System.Drawing.Size(163, 25);
            this.lblTipousuario.TabIndex = 10;
            this.lblTipousuario.Text = "Sua permissão:";
            // 
            // lblBemvindo
            // 
            this.lblBemvindo.AutoSize = true;
            this.lblBemvindo.Location = new System.Drawing.Point(118, 27);
            this.lblBemvindo.Name = "lblBemvindo";
            this.lblBemvindo.Size = new System.Drawing.Size(203, 25);
            this.lblBemvindo.TabIndex = 9;
            this.lblBemvindo.Text = "Seja bem-vindo (a),\r\n";
            // 
            // btnFinanceiro
            // 
            this.btnFinanceiro.BackColor = System.Drawing.Color.Silver;
            this.btnFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinanceiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanceiro.Location = new System.Drawing.Point(123, 530);
            this.btnFinanceiro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinanceiro.Name = "btnFinanceiro";
            this.btnFinanceiro.Size = new System.Drawing.Size(486, 102);
            this.btnFinanceiro.TabIndex = 6;
            this.btnFinanceiro.Text = "Financeiro";
            this.btnFinanceiro.UseVisualStyleBackColor = false;
            this.btnFinanceiro.Click += new System.EventHandler(this.btnFinanceiro_Click);
            this.btnFinanceiro.Enter += new System.EventHandler(this.btnFinanceiro_Enter);
            this.btnFinanceiro.Leave += new System.EventHandler(this.btnFinanceiro_Leave);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Silver;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(1331, 27);
            this.btnSair.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(175, 38);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Desconectar";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.Enter += new System.EventHandler(this.btnSair_Enter);
            this.btnSair.Leave += new System.EventHandler(this.btnSair_Leave);
            // 
            // btnDespesa
            // 
            this.btnDespesa.BackColor = System.Drawing.Color.Silver;
            this.btnDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDespesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDespesa.Location = new System.Drawing.Point(123, 401);
            this.btnDespesa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDespesa.Name = "btnDespesa";
            this.btnDespesa.Size = new System.Drawing.Size(486, 102);
            this.btnDespesa.TabIndex = 4;
            this.btnDespesa.Text = "Despesa";
            this.btnDespesa.UseVisualStyleBackColor = false;
            this.btnDespesa.Click += new System.EventHandler(this.btnDespesa_Click);
            this.btnDespesa.Enter += new System.EventHandler(this.btnDespesa_Enter);
            this.btnDespesa.Leave += new System.EventHandler(this.btnDespesa_Leave);
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.BackColor = System.Drawing.Color.Silver;
            this.btnFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFornecedor.Location = new System.Drawing.Point(123, 274);
            this.btnFornecedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(486, 102);
            this.btnFornecedor.TabIndex = 2;
            this.btnFornecedor.Text = "Fornecedor";
            this.btnFornecedor.UseVisualStyleBackColor = false;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            this.btnFornecedor.Enter += new System.EventHandler(this.btnFornecedor_Enter);
            this.btnFornecedor.Leave += new System.EventHandler(this.btnFornecedor_Leave);
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.Silver;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Location = new System.Drawing.Point(878, 530);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(486, 102);
            this.btnCliente.TabIndex = 7;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            this.btnCliente.Enter += new System.EventHandler(this.btnCliente_Enter);
            this.btnCliente.Leave += new System.EventHandler(this.btnCliente_Leave);
            // 
            // btnVenda
            // 
            this.btnVenda.BackColor = System.Drawing.Color.Silver;
            this.btnVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenda.Location = new System.Drawing.Point(878, 401);
            this.btnVenda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(486, 102);
            this.btnVenda.TabIndex = 5;
            this.btnVenda.Text = "Venda";
            this.btnVenda.UseVisualStyleBackColor = false;
            this.btnVenda.Click += new System.EventHandler(this.btnVenda_Click);
            this.btnVenda.Enter += new System.EventHandler(this.btnVenda_Enter);
            this.btnVenda.Leave += new System.EventHandler(this.btnVenda_Leave);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.Silver;
            this.btnEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.Location = new System.Drawing.Point(878, 274);
            this.btnEstoque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(486, 102);
            this.btnEstoque.TabIndex = 3;
            this.btnEstoque.Text = "Estoque";
            this.btnEstoque.UseVisualStyleBackColor = false;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            this.btnEstoque.Enter += new System.EventHandler(this.btnEstoque_Enter);
            this.btnEstoque.Leave += new System.EventHandler(this.btnEstoque_Leave);
            // 
            // btnProducao
            // 
            this.btnProducao.BackColor = System.Drawing.Color.Silver;
            this.btnProducao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducao.Location = new System.Drawing.Point(878, 149);
            this.btnProducao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProducao.Name = "btnProducao";
            this.btnProducao.Size = new System.Drawing.Size(486, 102);
            this.btnProducao.TabIndex = 1;
            this.btnProducao.Text = "Produção";
            this.btnProducao.UseVisualStyleBackColor = false;
            this.btnProducao.Click += new System.EventHandler(this.button1_Click);
            this.btnProducao.Enter += new System.EventHandler(this.btnProducao_Enter);
            this.btnProducao.Leave += new System.EventHandler(this.btnProducao_Leave);
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.Silver;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.Location = new System.Drawing.Point(123, 149);
            this.btnUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(486, 102);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuário";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            this.btnUsuario.Enter += new System.EventHandler(this.btnUsuario_Enter);
            this.btnUsuario.Leave += new System.EventHandler(this.btnUsuario_Leave);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 770);
            this.Controls.Add(this.gpHome);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlyGreen";
            this.Load += new System.EventHandler(this.Home_Load);
            this.gpHome.ResumeLayout(false);
            this.gpHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpHome;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnProducao;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.Button btnDespesa;
        private System.Windows.Forms.Button btnFinanceiro;
        private System.Windows.Forms.Label lblBemvindo;
        private System.Windows.Forms.Label lblTipousuario;
    }
}