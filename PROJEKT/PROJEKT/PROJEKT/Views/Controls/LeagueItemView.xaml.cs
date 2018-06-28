
using Xamarin.Forms;

namespace PROJEKT.Views.Controls
{
    public partial class LeagueItemView : ContentView
    {
        public LeagueItemView()
        {
            InitializeComponent();
            this.WidthRequest = (Application.Current as App).Width;
        }
    }
}
