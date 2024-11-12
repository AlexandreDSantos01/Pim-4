using BCrypt.Net;
using OnlyGrennMobile.Models;
using System.Net.Http.Json;

namespace OnlyGrennMobile.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly HttpClient _httpClient;

        public LoginPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            bool loginValido = await VerificarCredenciaisAsync(login, senha);

            if (loginValido)
            {
                // Alterando a MainPage para o AppShell ap�s login bem-sucedido
                Application.Current.MainPage = new AppShell(); // Altera para o AppShell, com as abas
            }
            else
            {
                await DisplayAlert("Erro", "Login ou senha inv�lidos", "OK");
            }
        }

        private async Task<bool> VerificarCredenciaisAsync(string login, string senha)
        {
            try
            {
                // Fazendo a requisi��o � API para pegar os dados do usu�rio
                var response = await _httpClient.GetFromJsonAsync<List<Usuario>>("https://apionlygreen.azurewebsites.net/api/Usuarios");

                if (response != null)
                {
                    // Procurar o usu�rio com o login fornecido
                    var usuario = response.FirstOrDefault(u => u.ulogar == login);
                    if (usuario != null)
                    {
                        // Verifica se a senha fornecida bate com o hash
                        bool senhaValida = BCrypt.Net.BCrypt.EnhancedVerify(senha, usuario.senha);
                        return senhaValida;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log ou tratar erros de requisi��o
                Console.WriteLine($"Erro ao verificar credenciais: {ex.Message}");
            }

            return false; // Caso n�o tenha encontrado ou tenha ocorrido algum erro
        }
    }
}
