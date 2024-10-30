using OnlyGrennMobile.Pages;

namespace OnlyGrennMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavigateToUsuario(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("UsuarioPage");
        }

        private async void NavigateToProducao(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ProducaoPage");
        }

        private async void NavigateToEstoque(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("EstoquePage");
        }

        private async void NavigateToCliente(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ClientePage");
        }

        private async void NavigateToFornecedor(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("FornecedorPage");
        }

        private async void NavigateToDespesa(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("DespesaPage");
        }

        private async void NavigateToVenda(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("VendaPage");
        }

        private async void NavigateToFinanceiro(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("FinanceiroPage");
        }



    }


}
