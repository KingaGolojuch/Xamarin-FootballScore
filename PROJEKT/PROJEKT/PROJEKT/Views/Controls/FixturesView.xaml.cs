using PROJEKT.Models.Interfaces;
using PROJEKT.ViewModels;

using Xamarin.Forms;

namespace PROJEKT.Views.Controls
{
    public partial class FixturesView : ContentView
    {
        private FixtureItemViewModel _vm;

        public FixturesView()
        {
            InitializeComponent();
            this.WidthRequest = (Application.Current as App).Width;
            _vm = new FixtureItemViewModel();

            IDownloadFixture download = new DownloadFixture();
            _vm.DownloadData(download, listView);
        }
    }
}
