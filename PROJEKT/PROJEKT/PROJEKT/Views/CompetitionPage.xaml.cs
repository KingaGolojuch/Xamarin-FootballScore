using PROJEKT.ViewModels;
using System;

using Xamarin.Forms;

namespace PROJEKT.Views
{
    public partial class CompetitionPage : ContentPage
    {
        private CompetitionViewModel _vm;

        public CompetitionPage()
        {
            InitializeComponent();
            _vm = new CompetitionViewModel()
            {
                view = crlLayout,
                GHome = homeGrid,
                GFixtures = fixturesGrid,
                GLeague = leagueGrid,
                GTeams = teamGrid
            };
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            crlLayout.WidthRequest = (Application.Current as App).Width;
            footer.HeightRequest = (Application.Current as App).Width / 6;
            _vm.DownloadData();
            crlLayout.page = this;
        }

        public void ChangeSelectedIndex(int target)
        {
            switch (target)
            {
                case 0:
                    _vm.ChangeBackground(homeGrid);
                    break;
                case 1:
                    _vm.ChangeBackground(fixturesGrid);
                    break;
                case 2:
                    _vm.ChangeBackground(leagueGrid);
                    break;
                case 3:
                    _vm.ChangeBackground(teamGrid);
                    break;
                default:
                    _vm.ChangeBackground(homeGrid);
                    break;

            }
        }

        private void Image_SizeChanged(object sender, EventArgs e)
        {
            Image image = (sender as Image);
            image.WidthRequest = (Application.Current as App).Width / 7;
            image.HeightRequest = (Application.Current as App).Width / 7;
        }
    }
}
