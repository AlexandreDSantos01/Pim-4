using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Security;
using System.Threading.Tasks;
using OnlyGrennMobile.Models;

namespace OnlyGrennMobile.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {

            // Configura o HttpClientHandler para ignorar erros SSL
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    if (cert != null && cert.Issuer.Equals("CN=localhost"))
                        return true; // Ignora erros SSL para localhost

                    return errors == SslPolicyErrors.None;
                }
            };
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://apionlygreen.azurewebsites.net/api/") // URL da sua API
            };
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>>("Usuarios");
        }

        public async Task<List<Producao>> GetProducoesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Producao>>("Producoes");
        }

        public async Task<List<Estoque>> GetEstoquesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Estoque>>("Estoques");
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Cliente>>("Clientes");
        }

        public async Task<List<Fornecedor>> GetFornecedoresAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Fornecedor>>("Fornecedores");
        }

        public async Task<List<Despesa>> GetDespesasAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Despesa>>("Despesas");
        }

        public async Task<List<Venda>> GetVendasAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Venda>>("Vendas");
        }

        public async Task<List<Financeiro>> GetFinanceirosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Financeiro>>("Financeiros");
        }
    }
}
