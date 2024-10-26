using ProdutoApp.Models;

namespace ProdutoApp.Services
{
    public class ProdutoServiceBase
    {

        public Task AddProdutoAsync(Produto produto)
        {
            produto.Id = _produtos.Count > 0 ? _produtos.Max(p => p.Id) + 1 : 1;
            _produtos.Add(produto);
            return Task.CompletedTask;
        }

        public Task AddProdutoAsync(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}