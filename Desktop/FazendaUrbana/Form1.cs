using System;
using System.Drawing;
using System.Windows.Forms;

namespace FazendaUrbana
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        //TRATAMENTO DE CARACTERES E APAGAR
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = (int)e.KeyChar;

            if (!char.IsLetterOrDigit(e.KeyChar) && tecla != 08)
            {
                e.Handled = true;
                MessageBox.Show("Digite apenas letras ou números.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //FIM TRATAMENTO DE CARACTERES E APAGAR

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Equals("sayumi") && txtSenha.Text.Equals("123"))
            {
                var menu = new MenuPrincipal();
                menu.Show(this);

                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtLogin.Focus();
                txtSenha.Text = "";
            }

        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para cadastro ou recuperação de senha consulte o seu supervisor", "Ajuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Foco inicio
        private void txtLogin_Enter(object sender, EventArgs e)
        {
            txtLogin.BackColor = Color.LightBlue;
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            txtLogin.BackColor = Color.White;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.LightBlue;
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.White;
        }

        private void btnEntrar_Enter(object sender, EventArgs e)
        {
            btnEntrar.BackColor = Color.LightGreen;
        }

        private void btnEntrar_Leave(object sender, EventArgs e)
        {
            btnEntrar.BackColor = Color.White;
        }

        private void btnAjuda_Enter(object sender, EventArgs e)
        {
            btnAjuda.BackColor = Color.Red;
        }

        private void btnAjuda_Leave(object sender, EventArgs e)
        {
            btnAjuda.BackColor = Color.White;
        }

        //Foco fim
        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
