using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            // Método para verificar as credenciais
            if (VerificarCredenciais(login, senha))
            {
                // Suponha que você tenha uma forma de pegar o tipo de usuário
                UserSession.TipoUsuario = ObterTipoUsuario(login); // Método que você precisa implementar
                var menu = new Home();
                menu.Show(this);
                this.Hide(); // Oculta o formulário atual
            }
            else
            {
                MessageBox.Show("Login ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ObterTipoUsuario(string login)
        {
            string tipoUsuario = null; // Inicializa a variável

            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
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
            string bdonlygreen = "Server=FEUERWOLF;Database=bdonlygreen;Integrated Security=True;";
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
    }
}