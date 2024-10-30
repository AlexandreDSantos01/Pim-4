using System;
using Microsoft.Maui.Controls;

namespace OnlyGrennMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registrando rotas para cada página
            Routing.RegisterRoute("UsuarioPage", typeof(Pages.UsuarioPage));
            Routing.RegisterRoute("ProducaoPage", typeof(Pages.ProducaoPage));
            Routing.RegisterRoute("EstoquePage", typeof(Pages.EstoquePage));
            Routing.RegisterRoute("ClientePage", typeof(Pages.ClientePage));
            Routing.RegisterRoute("FornecedorPage", typeof(Pages.FornecedorPage));
            Routing.RegisterRoute("DespesaPage", typeof(Pages.DespesaPage));
            Routing.RegisterRoute("VendaPage", typeof(Pages.VendaPage));
            Routing.RegisterRoute("FinanceiroPage", typeof(Pages.FinanceiroPage));
        }
    }
}
