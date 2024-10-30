using OnlyGrennMobile.Models;
using OnlyGrennMobile.Services;
using System.Collections.ObjectModel;

namespace OnlyGrennMobile.Pages
{
    public partial class VendaPage : ContentPage
    {
        public ObservableCollection<Venda> Vendas { get; set; }
        private ApiService _apiService;

        public VendaPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Vendas = new ObservableCollection<Venda>();
            LoadData();
        }

        private async void LoadData()
        {
            var vendas = await _apiService.GetVendasAsync(); // Chama o método para buscar as vendas da API
            foreach (var venda in vendas)
            {
                Vendas.Add(venda); // Adiciona cada venda à coleção
            }

            VendaCollectionView.ItemsSource = Vendas; // Define a fonte de itens da CollectionView
        }
    }
}
