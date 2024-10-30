using OnlyGrennMobile.Models;
using OnlyGrennMobile.Services;
using System.Collections.ObjectModel;

namespace OnlyGrennMobile.Pages
{
    public partial class ProducaoPage : ContentPage
    {
        public ObservableCollection<Producao> Producoes { get; set; }
        private ApiService _apiService;

        public ProducaoPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Producoes = new ObservableCollection<Producao>();
            LoadData(); // Chama o m�todo para carregar dados da API
        }

        private async void LoadData()
        {
            try
            {
                var producoes = await _apiService.GetProducoesAsync();
                Producoes = new ObservableCollection<Producao>(producoes);
                ProducaoCollectionView.ItemsSource = Producoes;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"N�o foi poss�vel carregar os dados: {ex.Message}", "OK");
            }
        }
    }
}
