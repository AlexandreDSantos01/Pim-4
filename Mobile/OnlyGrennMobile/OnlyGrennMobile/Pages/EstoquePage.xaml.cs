using OnlyGrennMobile.Models;
using OnlyGrennMobile.Services;
using System.Collections.ObjectModel;

namespace OnlyGrennMobile.Pages
{
    public partial class EstoquePage : ContentPage
    {
        public ObservableCollection<Estoque> Estoques { get; set; }
        private ApiService _apiService;

        public EstoquePage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Estoques = new ObservableCollection<Estoque>();
            LoadData();
        }

        private async void LoadData()
        {
            var estoques = await _apiService.GetEstoquesAsync();
            foreach (var estoque in estoques)
            {
                Estoques.Add(estoque);
            }

            EstoqueCollectionView.ItemsSource = Estoques;
        }
    }
}
