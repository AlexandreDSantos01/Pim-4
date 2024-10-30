using OnlyGrennMobile.Models;
using OnlyGrennMobile.Services;
using System.Collections.ObjectModel;

namespace OnlyGrennMobile.Pages
{
    public partial class DespesaPage : ContentPage
    {
        public ObservableCollection<Despesa> Despesas { get; set; }
        private ApiService _apiService;

        public DespesaPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Despesas = new ObservableCollection<Despesa>();
            LoadData();
        }

        private async void LoadData()
        {
            var despesas = await _apiService.GetDespesasAsync();
            foreach (var despesa in despesas)
            {
                Despesas.Add(despesa);
            }

            DespesaCollectionView.ItemsSource = Despesas;
        }
    }
}
