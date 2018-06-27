using PROJEKT.Views;

using Xamarin.Forms;

namespace PROJEKT
{
    public partial class App : Application
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public int CompetitionId { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InitializationPage());
        }
    }
}
