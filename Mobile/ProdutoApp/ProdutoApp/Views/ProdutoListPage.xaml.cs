using ProdutoApp.ViewModels; // Certifique-se de que este namespace está correto para onde seu ViewModel está localizado

namespace ProdutoApp.Views
{
    public partial class ProdutoListPage : ContentPage
    {
        public ProdutoListPage()
        {
           // InitializeComponent();
            BindingContext = new ProdutoListViewModel(); // Configura o ViewModel como o contexto de dados da página
        }

        private async void OnAdicionarProdutoClicked(object sender, EventArgs e)
        {
            // Navega para a página de adicionar produto
            await Navigation.PushAsync(new AddProdutoPage());
        }
    }
}
