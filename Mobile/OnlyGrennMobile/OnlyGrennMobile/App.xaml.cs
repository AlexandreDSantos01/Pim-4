namespace OnlyGrennMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell(); // Use AppShell para permitir navegação
        }
    }
}
