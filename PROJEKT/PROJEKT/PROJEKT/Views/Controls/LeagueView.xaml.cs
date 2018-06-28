using PROJEKT.ViewModels;

using Xamarin.Forms;

namespace PROJEKT.Views.Controls
{
    public partial class LeagueView : ContentView
    {
        private LeagueItemViewModel _vm;

        public LeagueView()
        {
            InitializeComponent();
            this.WidthRequest = (Application.Current as App).Width;
            _vm = new LeagueItemViewModel();

            _vm.DownloadData(StlItem);
        }
    }
}
