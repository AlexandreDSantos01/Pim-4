using OnlyGrennMobile.Models;
using OnlyGrennMobile.Services;
using System.Collections.ObjectModel;

namespace OnlyGrennMobile.Pages
{
    public partial class FornecedorPage : ContentPage
    {
        public ObservableCollection<Fornecedor> Fornecedores { get; set; }
        private ApiService _apiService;

        public FornecedorPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Fornecedores = new ObservableCollection<Fornecedor>();
            LoadData();
        }

        private async void LoadData()
        {
            var fornecedores = await _apiService.GetFornecedoresAsync();
            foreach (var fornecedor in fornecedores)
            {
                Fornecedores.Add(fornecedor);
            }

            FornecedorCollectionView.ItemsSource = Fornecedores;
        }
    }
}
