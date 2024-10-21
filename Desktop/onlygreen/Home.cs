using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlygreen
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent(); 
        }

        public static class UserSession
        {
            public static string TipoUsuario { get; set; }
        }


        private void btnUsuario_Click(object sender, EventArgs e)
        {
            if (VerificarPermissao("Supervisor") || VerificarPermissao("Todos"))
            {
                var menu = new Usuario();
                menu.Show(this);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você não tem permissão para entrar nessa área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Apenas Produtor
            if (VerificarPermissao("Produtor") || VerificarPermissao("Todos"))
            {
                var menu = new Producao();
                menu.Show(this);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você não tem permissão para entrar nessa área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            // Produtor e Vendedor ou Todos
            if ((VerificarPermissao("Produtor") || VerificarPermissao("Vendedor")) || VerificarPermissao("Todos"))
            {
                var menu = new Estoque();
                menu.Show(this);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você não tem permissão para entrar nessa área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            // Vendedor e Financeiro ou Todos
            if ((VerificarPermissao("Vendedor") || VerificarPermissao("Financeiro")) || VerificarPermissao("Todos"))
            {
                var menu = new Venda();
                menu.Show(this);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você não tem permissão para entrar nessa área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            // Vendedor ou Todos
            if (VerificarPermissao("Vendedor") || VerificarPermissao("Todos"))
            {
                var menu = new Cliente();
                menu.Show(this);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você não tem permissão para entrar nessa área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            // Suprimento ou Todos
            if (VerificarPermissao("Suprimento") || VerificarPermissao("Todos"))
            {
                var menu = new Fornecedor();
                menu.Show(this);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você não tem permissão para entrar nessa área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDespesa_Click(object sender, EventArgs e)
        {
            // Suprimento e Financeiro ou Todos
            if ((VerificarPermissao("Suprimento") || VerificarPermissao("Financeiro")) || VerificarPermissao("Todos"))
            {
                var menu = new Despesa();
                menu.Show(this);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você não tem permissão para entrar nessa área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFinanceiro_Click(object sender, EventArgs e)
        {
            // Financeiro ou Todos
            if (VerificarPermissao("Financeiro") || VerificarPermissao("Todos"))
            {
                var menu = new Financeiro();
                menu.Show(this);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Você não tem permissão para entrar nessa área.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método para verificar permissões
        private bool VerificarPermissao(string tipo)
        {
            return UserSession.TipoUsuario == tipo;
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja se desconectar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new Form1();
                menu.Show(this);

                this.Visible = false;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
    
}
    

