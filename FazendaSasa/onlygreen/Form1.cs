using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using static onlygreen.Home;

namespace onlygreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ObterSituacaoUsuario(string login)
        {
            string situacao = string.Empty;

            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                string pegarsituacao = "SELECT situacao FROM tb_Usuario WHERE ulogar = @ulogar";

                using (var command = new SqlCommand(pegarsituacao, conectar))
                {
                    command.Parameters.AddWithValue("@ulogar", login);
                    var resultado = command.ExecuteScalar();

                    if (resultado != null)
                    {
                        situacao = resultado.ToString();
                    }
                }
            }

            return situacao;
        }

        private string ObterNomeUsuario(string login)
        {
            string nomeUsuario = null;

            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                var command = new SqlCommand("SELECT nome FROM tb_Usuario WHERE ulogar = @login", conectar);
                command.Parameters.AddWithValue("@login", login);

                var resultado = command.ExecuteScalar();

                if (resultado != null)
                {
                    nomeUsuario = resultado.ToString();
                }
            }

            return nomeUsuario;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            var situacaoUsuario = ObterSituacaoUsuario(login);

            if (situacaoUsuario == "Inativo")
            {
                MessageBox.Show("Usuário inativo. Acesso negado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (VerificarCredenciais(login, senha))
            {
                UserSession.TipoUsuario = ObterTipoUsuario(login);
                UserSession.NomeUsuario = ObterNomeUsuario(login);

                var menu = new Home();
                menu.Show(this);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObterTipoUsuario(string login)
        {
            string tipoUsuario = null;

            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                var command = new SqlCommand("SELECT tipousuario FROM tb_Usuario WHERE ulogar = @login", conectar);
                command.Parameters.AddWithValue("@login", login);

                var resultado = command.ExecuteScalar();

                if (resultado != null)
                {
                    tipoUsuario = resultado.ToString();
                }
            }

            return tipoUsuario;
        }

        private bool VerificarCredenciais(string login, string senha)
        {
            string bdonlygreen = "Server=DESKTOP-CV8MG1N;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();

                var command = new SqlCommand("SELECT senha FROM tb_Usuario WHERE ulogar = @login", conectar);
                command.Parameters.AddWithValue("@login", login);

                var senhaHash = command.ExecuteScalar() as string;

                if (senhaHash != null)
                {
                    Console.WriteLine($"Senha hash encontrada: {senhaHash}");

                    bool isVerified = BCrypt.Net.BCrypt.EnhancedVerify(senha, senhaHash);

                    Console.WriteLine($"Verificação de senha: {isVerified}");
                    return isVerified;
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado.");
                }
            }

            return false;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para recuperação de senha ou cadastro consulte um supervisor.", "Ajuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // FOCO
        private void txtLogin_Enter(object sender, EventArgs e)
        {
            txtLogin.BackColor = Color.LightBlue; // Mantém a cor original
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            txtLogin.BackColor = Color.White;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.LightBlue; // Mantém a cor original
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.White;
        }

        private void btnEntrar_Enter(object sender, EventArgs e)
        {
            btnEntrar.BackColor = Color.LightGreen; // Cor de foco no botão entrar
        }

        private void btnEntrar_Leave(object sender, EventArgs e)
        {
            btnEntrar.BackColor = Color.Silver;
        }

        private void btnAjuda_Enter(object sender, EventArgs e)
        {
            btnAjuda.BackColor = Color.Red; // Cor vermelha ao focar
        }

        private void btnAjuda_Leave(object sender, EventArgs e)
        {
            btnAjuda.BackColor = Color.Silver;
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSenha.Focus();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar.PerformClick();
        }

        // FOCO FIM
    }
}
