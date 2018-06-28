using PROJEKT.Models;
using PROJEKT.Models.Interfaces;
using PROJEKT.ViewModels;
using PROJEKT.Views.Controls;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PROJEKT.Views
{
    public partial class CompetitionsPage : ContentPage
    {
        private CompetitionsViewModel _vm;

        public CompetitionsPage()
        {
            InitializeComponent();
            _vm = new CompetitionsViewModel();
            BindingContext = _vm;
            Title = "ZAWODY";
            grid.IsVisible = true;
            LblNoInternet.IsVisible = false;
        }

        protected override void OnAppearing()
        {
            listView.ItemTemplate = new DataTemplate(typeof(CompetitionsView));
            IDownloadCompetition download = new DownloadCompetition();
            _vm.DownloadData(download, listView, grid, LblNoInternet);

            listView.ItemSelected += async (s, e) =>
            {
                grid.IsVisible = true;
                CustomCompetition item = (CustomCompetition)e.SelectedItem;
                CompetitionPage page = new CompetitionPage();
                page.Title = item.Caption;
                (Application.Current as App).CompetitionId = item.Id;
                //await Task.Delay(1000);
                await Navigation.PushAsync(page);
            };
        }
    }
}
