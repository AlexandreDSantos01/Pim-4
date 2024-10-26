using ProdutoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoApp.Services
{
    public class ProdutoService : ProdutoServiceBase1, IProdutoService
    {
        private List<Produto> _produtos = new List<Produto>();

        public Task<List<Produto>> GetProdutosAsync() => Task.FromResult(_produtos);

        public Task<Produto> GetProdutoByIdAsync(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(produto);
        }

        public Task UpdateProdutoAsync(Produto produto)
        {
            var existingProduto = _produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (existingProduto != null)
            {
                existingProduto.Nome = produto.Nome;
                existingProduto.Descricao = produto.Descricao;
                existingProduto.Preco = produto.Preco;
                existingProduto.Quantidade = produto.Quantidade;
            }
            return Task.CompletedTask;
        }

        public Task DeleteProdutoAsync(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
                _produtos.Remove(produto);
            return Task.CompletedTask;
        }

        Task<List<Produto>> IProdutoService.GetProdutosAsync()
        {
            throw new NotImplementedException();
        }

        Task<Produto> IProdutoService.GetProdutoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
