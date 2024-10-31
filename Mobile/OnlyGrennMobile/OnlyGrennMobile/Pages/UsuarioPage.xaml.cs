using OnlyGrennMobile.Models;
using OnlyGrennMobile.Services;
using System.Collections.ObjectModel;

namespace OnlyGrennMobile.Pages
{
    public partial class UsuarioPage : ContentPage
    {
        public ObservableCollection<Usuario> Usuarios { get; set; }
        private ApiService _apiService;

        public UsuarioPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Usuarios = new ObservableCollection<Usuario>();
            LoadData();
        }

        private async void LoadData()
        {
            var usuarios = await _apiService.GetUsuariosAsync();
            Usuarios.Clear();
            foreach (var usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }

            UserCollectionView.ItemsSource = Usuarios;
        }
    }
}
