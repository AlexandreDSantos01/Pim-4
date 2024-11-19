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
            CarregarInformacoes();
        }
   
        public static class UserSession
        {
            public static string NomeUsuario { get; set; }
            public static string TipoUsuario { get; set; }
        }
        
        private void CarregarInformacoes()
        {
            lblBemvindo.Text = $"Seja bem-vindo(a), {UserSession.NomeUsuario}.";
            lblTipousuario.Text = $"Sua permissão: {UserSession.TipoUsuario}.";
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

        private void btnUsuario_Enter(object sender, EventArgs e)
        {
            btnUsuario.BackColor = Color.LightGreen;
        }

        private void btnUsuario_Leave(object sender, EventArgs e)
        {
            btnUsuario.BackColor = Color.Silver;
        }

        private void btnFornecedor_Enter(object sender, EventArgs e)
        {
            btnFornecedor.BackColor = Color.LightGreen;
        }

        private void btnFornecedor_Leave(object sender, EventArgs e)
        {
            btnFornecedor.BackColor = Color.Silver;
        }

        private void btnDespesa_Enter(object sender, EventArgs e)
        {
            btnDespesa.BackColor = Color.LightGreen;
        }

        private void btnDespesa_Leave(object sender, EventArgs e)
        {
            btnDespesa.BackColor = Color.Silver;
        }

        private void btnFinanceiro_Enter(object sender, EventArgs e)
        {
            btnFinanceiro.BackColor = Color.LightGreen;
        }

        private void btnFinanceiro_Leave(object sender, EventArgs e)
        {
            btnFinanceiro.BackColor = Color.Silver;
        }

        private void btnProducao_Enter(object sender, EventArgs e)
        {
            btnProducao.BackColor = Color.LightGreen;
        }

        private void btnProducao_Leave(object sender, EventArgs e)
        {
            btnProducao.BackColor = Color.Silver;
        }

        private void btnEstoque_Enter(object sender, EventArgs e)
        {
            btnEstoque.BackColor = Color.LightGreen;
        }

        private void btnEstoque_Leave(object sender, EventArgs e)
        {
            btnEstoque.BackColor = Color.Silver;
        }

        private void btnVenda_Enter(object sender, EventArgs e)
        {
            btnVenda.BackColor = Color.LightGreen;
        }

        private void btnVenda_Leave(object sender, EventArgs e)
        {
            btnVenda.BackColor = Color.Silver;
        }

        private void btnCliente_Enter(object sender, EventArgs e)
        {
            btnCliente.BackColor = Color.LightGreen;
        }

        private void btnCliente_Leave(object sender, EventArgs e)
        {
            btnCliente.BackColor = Color.Silver;
        }

        private void btnSair_Enter(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.Red;
        }

        private void btnSair_Leave(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.Silver;
        }
    }
    
}
    

