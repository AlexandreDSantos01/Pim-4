using ProdutoApp.ViewModels; // Certifique-se de que este namespace est� correto para onde seu ViewModel est� localizado

namespace ProdutoApp.Views
{
    public partial class ProdutoListPage : ContentPage
    {
        public ProdutoListPage()
        {
           // InitializeComponent();
            BindingContext = new ProdutoListViewModel(); // Configura o ViewModel como o contexto de dados da p�gina
        }

        private async void OnAdicionarProdutoClicked(object sender, EventArgs e)
        {
            // Navega para a p�gina de adicionar produto
            await Navigation.PushAsync(new AddProdutoPage());
        }
    }
}
