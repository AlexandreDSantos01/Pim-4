using ProdutoApp.Models;
using ProdutoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoApp.Services
{
    public class ProdutoServiceBase1
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

        public Task UpdateProdutoAsync(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}