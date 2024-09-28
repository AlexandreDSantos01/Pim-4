namespace FazendaUrbana
{
    partial class RegistrarProducao
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
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnRegistrarProducao = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeproduto = new System.Windows.Forms.TextBox();
            this.txtQuantidadeproduto = new System.Windows.Forms.TextBox();
            this.txtEstimativacolheita = new System.Windows.Forms.MaskedTextBox();
            this.txtDataregistro = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(433, 335);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(98, 44);
            this.btnVoltar.TabIndex = 0;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnRegistrarProducao
            // 
            this.btnRegistrarProducao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarProducao.Location = new System.Drawing.Point(137, 335);
            this.btnRegistrarProducao.Name = "btnRegistrarProducao";
            this.btnRegistrarProducao.Size = new System.Drawing.Size(192, 44);
            this.btnRegistrarProducao.TabIndex = 1;
            this.btnRegistrarProducao.Text = "Registrar produção";
            this.btnRegistrarProducao.UseVisualStyleBackColor = true;
            this.btnRegistrarProducao.Click += new System.EventHandler(this.btnRegistrarProducao_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDataregistro);
            this.groupBox1.Controls.Add(this.txtEstimativacolheita);
            this.groupBox1.Controls.Add(this.txtQuantidadeproduto);
            this.groupBox1.Controls.Add(this.txtNomeproduto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 298);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar produção";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data de registro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Estimativa de colheita";
            // 
            // txtNomeproduto
            // 
            this.txtNomeproduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeproduto.Location = new System.Drawing.Point(38, 109);
            this.txtNomeproduto.Name = "txtNomeproduto";
            this.txtNomeproduto.Size = new System.Drawing.Size(211, 34);
            this.txtNomeproduto.TabIndex = 4;
            // 
            // txtQuantidadeproduto
            // 
            this.txtQuantidadeproduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidadeproduto.Location = new System.Drawing.Point(485, 109);
            this.txtQuantidadeproduto.Name = "txtQuantidadeproduto";
            this.txtQuantidadeproduto.Size = new System.Drawing.Size(100, 34);
            this.txtQuantidadeproduto.TabIndex = 5;
            // 
            // txtEstimativacolheita
            // 
            this.txtEstimativacolheita.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimativacolheita.Location = new System.Drawing.Point(485, 218);
            this.txtEstimativacolheita.Mask = "00/00/0000";
            this.txtEstimativacolheita.Name = "txtEstimativacolheita";
            this.txtEstimativacolheita.Size = new System.Drawing.Size(150, 34);
            this.txtEstimativacolheita.TabIndex = 6;
            // 
            // txtDataregistro
            // 
            this.txtDataregistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataregistro.Location = new System.Drawing.Point(38, 218);
            this.txtDataregistro.Mask = "00/00/0000";
            this.txtDataregistro.Name = "txtDataregistro";
            this.txtDataregistro.Size = new System.Drawing.Size(150, 34);
            this.txtDataregistro.TabIndex = 7;
            // 
            // RegistrarProducao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 396);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRegistrarProducao);
            this.Controls.Add(this.btnVoltar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarProducao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlyGreen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnRegistrarProducao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtQuantidadeproduto;
        private System.Windows.Forms.TextBox txtNomeproduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDataregistro;
        private System.Windows.Forms.MaskedTextBox txtEstimativacolheita;
    }
}