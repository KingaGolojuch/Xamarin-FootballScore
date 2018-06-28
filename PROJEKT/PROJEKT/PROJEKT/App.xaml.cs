using PROJEKT.Views;

using Xamarin.Forms;

namespace PROJEKT
{
    /// <summary> 
    /// Klasa startowa projektu.
    /// </summary> 
    public partial class App : Application
    {
        /// <summary> 
        /// Szerokość telefonu.
        /// </summary> 
        public double Width { get; set; }
        /// <summary> 
        /// Wysokość telefonu.
        /// </summary> 
        public double Height { get; set; }
        /// <summary> 
        /// Id danego konkursu.
        /// </summary> 
        public int CompetitionId { get; set; }

        /// <summary> 
        /// Konstruktor.
        /// </summary>
        public App()
        {
            InitializeComponent();

            /// <summary> 
            /// Ustawianie strony startowej.
            /// </summary>
            MainPage = new NavigationPage(new InitializationPage());
        }
    }
}
