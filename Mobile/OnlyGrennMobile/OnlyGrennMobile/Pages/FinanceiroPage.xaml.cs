using OnlyGrennMobile.Models;
using OnlyGrennMobile.Services;
using System.Collections.ObjectModel;

namespace OnlyGrennMobile.Pages
{
    public partial class FinanceiroPage : ContentPage
    {
        public ObservableCollection<Financeiro> Financeiros { get; set; }
        private ApiService _apiService;

        public FinanceiroPage()
        {
            InitializeComponent();
            _apiService = new ApiService(); // Inicializa o servi�o da API
            Financeiros = new ObservableCollection<Financeiro>(); // Cria a cole��o observ�vel
            LoadData(); // Carrega os dados da API
        }

        private async void LoadData()
        {
            var financas = await _apiService.GetFinanceirosAsync(); // Chama o m�todo da API para obter os dados financeiros
            foreach (var financeiro in financas)
            {
                Financeiros.Add(financeiro); // Adiciona cada item � cole��o
            }

            FinanceiroCollectionView.ItemsSource = Financeiros; // Define a fonte de itens da CollectionView
        }
    }
}
