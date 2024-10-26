using System.Collections.ObjectModel;
using System.Windows.Input;
using ProdutoApp.Models;
using ProdutoApp.Services;

namespace ProdutoApp.ViewModels
{
    public class ProdutoListViewModel : BaseViewModel // Assegure-se de que BaseViewModel implemente INotifyPropertyChanged
    {
        private readonly IProdutoService _produtoService;
        public ObservableCollection<Produto> Produtos { get; set; }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public string AddProdutoPage { get; private set; }

        public ProdutoListViewModel()
        {
            _produtoService = DependencyService.Get<IProdutoService>();
            Produtos = new ObservableCollection<Produto>();

            AddCommand = new Command(OnAdd);
            EditCommand = new Command<Produto>(OnEdit);
            DeleteCommand = new Command<Produto>(OnDelete);

            LoadProdutos();
        }

        private async void LoadProdutos()
        {
            var produtos = await _produtoService.GetProdutosAsync();
            Produtos.Clear();

            foreach (var produto in produtos)
            {
                Produtos.Add(produto);
            }
        }

        private async void OnAdd()
        {
            // Aqui você pode navegar para a página de adicionar produto
            await Shell.Current.GoToAsync(nameof(AddProdutoPage));
        }

        private async void OnEdit(Produto produto)
        {
            if (produto == null)
                return;

            // Aqui você pode navegar para a página de edição e passar o produto
            await Shell.Current.GoToAsync($"{nameof(AddProdutoPage)}?id={produto.Id}");
        }

        private async void OnDelete(Produto produto)
        {
            if (produto == null)
                return;

            // Chama o serviço para deletar o produto
            await _produtoService.DeleteProdutoAsync(produto.Id);
            Produtos.Remove(produto);
        }
    }
}
