using System;
using System.Drawing;
using System.Windows.Forms;

namespace FazendaUrbana
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        //foco inicio
        private void btnProducao_Enter(object sender, EventArgs e)
        {
            btnProducao.BackColor = Color.LightGreen;
        }

        private void btnProducao_Leave(object sender, EventArgs e)
        {
            btnProducao.BackColor = Color.White;
        }

        private void btnCliente_Enter(object sender, EventArgs e)
        {
            btnCliente.BackColor = Color.LightGreen;
        }

        private void btnCliente_Leave(object sender, EventArgs e)
        {
            btnCliente.BackColor = Color.White;
        }

        private void btnFornecedor_Enter(object sender, EventArgs e)
        {
            btnFornecedor.BackColor = Color.LightGreen;
        }

        private void btnFornecedor_Leave(object sender, EventArgs e)
        {
            btnFornecedor.BackColor = Color.White;
        }

        private void btnEstoque_Enter(object sender, EventArgs e)
        {
            btnEstoque.BackColor = Color.LightGreen;
        }

        private void btnEstoque_Leave(object sender, EventArgs e)
        {
            btnEstoque.BackColor = Color.White;
        }

        private void btnVenda_Enter(object sender, EventArgs e)
        {
            btnVenda.BackColor = Color.LightGreen;
        }

        private void btnVenda_Leave(object sender, EventArgs e)
        {
            btnVenda.BackColor = Color.White;
        }

        private void btnDespesa_Enter(object sender, EventArgs e)
        {
            btnDespesa.BackColor = Color.LightGreen;
        }

        private void btnDespesa_Leave(object sender, EventArgs e)
        {
            btnDespesa.BackColor = Color.White;
        }

        private void btnRelatorio_Enter(object sender, EventArgs e)
        {
            btnRelatorio.BackColor = Color.LightGreen;
        }

        private void btnRelatorio_Leave(object sender, EventArgs e)
        {
            btnRelatorio.BackColor = Color.White;
        }

        private void btnUsuario_Enter(object sender, EventArgs e)
        {
            btnUsuario.BackColor = Color.LightGreen;
        }

        private void btnUsuario_Leave(object sender, EventArgs e)
        {
            btnUsuario.BackColor = Color.White;
        }
        private void btnDesconect_Enter(object sender, EventArgs e)
        {
            btnDesconect.BackColor = Color.Red;
        }

        private void btnDesconect_Leave(object sender, EventArgs e)
        {
            btnDesconect.BackColor = Color.White;

        }
        //foco fim

        //Entrar áreas inicio
        private void btnProducao_Click(object sender, EventArgs e)
        {
            var menu = new Producao();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            var menu = new Cliente();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            var menu = new Fornecedor();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            var menu = new Estoque();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            var menu = new Venda();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnDespesa_Click(object sender, EventArgs e)
        {
            var menu = new Despesa();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var menu = new Relatorio();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            var menu = new Usuario();
            menu.Show(this);

            this.Visible = false;
        }

        private void btnDesconect_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Você tem certeza que deseja se desconectar?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                var menu = new TelaLogin();
                menu.Show(this);

                this.Visible = false;
            }
        }
        //Entrar áreas fim
    }
}
