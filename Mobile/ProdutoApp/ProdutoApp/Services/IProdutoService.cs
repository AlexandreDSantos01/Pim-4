using ProdutoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoApp.Services
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int id);
        Task AddProdutoAsync(Produto produto);
        Task UpdateProdutoAsync(Produto produto);
        Task DeleteProdutoAsync(int id);
    }
}