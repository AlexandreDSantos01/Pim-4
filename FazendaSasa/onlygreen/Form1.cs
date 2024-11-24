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

            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
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

            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                var command = new SqlCommand("SELECT nome FROM tb_Usuario WHERE ulogar = @login", conectar);
                command.Parameters.AddWithValue("@login", login);

                // Executa a consulta e armazena o nome do usuário
                var resultado = command.ExecuteScalar();

                if (resultado != null)
                {
                    nomeUsuario = resultado.ToString(); // Converte o resultado para string
                }
            }

            return nomeUsuario; // Retorna o nome do usuário ou null se não encontrado
        }


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            var situacaoUsuario = ObterSituacaoUsuario(login); // Método que você precisará implementar

            // Verifica se o usuário está ativo
            if (situacaoUsuario == "Inativo")
            {
                MessageBox.Show("Usuário inativo. Acesso negado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            // Método para verificar as credenciais
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
            string tipoUsuario = null; // Inicializa a variável

            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();
                var command = new SqlCommand("SELECT tipousuario FROM tb_Usuario WHERE ulogar = @login", conectar);
                command.Parameters.AddWithValue("@login", login);

                // Executa a consulta e armazena o tipo de usuário
                var resultado = command.ExecuteScalar();

                if (resultado != null)
                {
                    tipoUsuario = resultado.ToString(); // Converte o resultado para string
                }
            }

            return tipoUsuario; // Retorna o tipo de usuário ou null se não encontrado
        }

        // Método para verificar credenciais
        private bool VerificarCredenciais(string login, string senha)
        {
            string bdonlygreen = "Server=DESKTOP-BRQ9Q8N;Database=bdonlygreen;Integrated Security=True;";
            using (var conectar = new SqlConnection(bdonlygreen))
            {
                conectar.Open();

                // Busca o hash da senha para o ulogar fornecido
                var command = new SqlCommand("SELECT senha FROM tb_Usuario WHERE ulogar = @login", conectar);
                command.Parameters.AddWithValue("@login", login);

                // Executa a consulta e armazena o hash da senha
                var senhaHash = command.ExecuteScalar() as string;

                if (senhaHash != null)
                {
                    // Log para verificar a senha hash encontrada
                    Console.WriteLine($"Senha hash encontrada: {senhaHash}");

                    // Verifica se a senha fornecida corresponde ao hash armazenado
                    bool isVerified = BCrypt.Net.BCrypt.EnhancedVerify(senha, senhaHash);

                    // Log para verificar se a verificação foi bem-sucedida
                    Console.WriteLine($"Verificação de senha: {isVerified}");
                    return isVerified;
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado.");
                }
            }

            return false; // Retorna falso se o usuário não foi encontrado
        }



        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para recuperação de senha ou cadastro consulte um supervisor.", "Ajuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //FOCO
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
            btnEntrar.BackColor = Color.Silver;
        }

        private void btnAjuda_Enter(object sender, EventArgs e)
        {
            btnAjuda.BackColor = Color.Red;
        }

        private void btnAjuda_Leave(object sender, EventArgs e)
        {
            btnAjuda.BackColor = Color.Silver;
        }

        //FOCO FIM
    }
}