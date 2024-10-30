using OnlyGrennMobile.Models;
using OnlyGrennMobile.Services;
using System.Collections.ObjectModel;

namespace OnlyGrennMobile.Pages
{
    public partial class ClientePage : ContentPage
    {
        public ObservableCollection<Cliente> Clientes { get; set; }
        private ApiService _apiService;

        public ClientePage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Clientes = new ObservableCollection<Cliente>();
            LoadData();
        }

        private async void LoadData()
        {
            var clientes = await _apiService.GetClientesAsync();
            foreach (var cliente in clientes)
            {
                Clientes.Add(cliente);
            }

            ClienteCollectionView.ItemsSource = Clientes;
        }
    }
}
