using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlyGrennMobile.Models;

namespace OnlyGrennMobile.Services
{
    public class ApiService02 // Altere o nome da classe para ApiService02
    {
        private readonly HttpClient _httpClient;

        public ApiService02() // Construtor atualizado
        {
            _httpClient = new HttpClient
            {
                // Defina a URL base da sua API
                BaseAddress = new Uri("https://apionlygreen.azurewebsites.net/api/")
            };
        }

        // Método para autenticar o usuário com login e senha
        public async Task<bool> LoginAsync(string login, string senha)
        {
            try
            {
                // Faz a requisição GET para obter o usuário pelo login
                var response = await _httpClient.GetAsync($"Usuarios?ulogar={login}");

                // Verifica se a requisição foi bem-sucedida
                if (!response.IsSuccessStatusCode)
                {
                    return false; // Caso a requisição falhe
                }

                // Lê o conteúdo da resposta
                var userJson = await response.Content.ReadAsStringAsync();

                // Desserializa a resposta JSON como uma lista de usuários
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(userJson);

                if (usuarios == null || usuarios.Count == 0)
                {
                    return false; // Não encontrou o usuário
                }

                // Pega o primeiro usuário (já que deveria ter apenas um)
                var usuario = usuarios.FirstOrDefault();

                if (usuario == null)
                {
                    return false; // Caso o usuário não seja encontrado
                }

                // Verifica se a senha fornecida corresponde à senha criptografada do usuário
                bool senhaValida = BCrypt.Net.BCrypt.EnhancedVerify(senha, usuario.senha);

                return senhaValida; // Retorna se a senha é válida ou não
            }
            catch
            {
                return false; // Caso ocorra algum erro na comunicação
            }
        }
    }
}
