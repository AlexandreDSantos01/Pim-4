using Microsoft.Extensions.Logging;
using ProdutoApp.Services; // Adicione esta linha para referenciar o namespace dos serviços

namespace ProdutoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registrar o ProdutoService como um serviço singleton
            builder.Services.AddSingleton<IProdutoService, ProdutoService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
