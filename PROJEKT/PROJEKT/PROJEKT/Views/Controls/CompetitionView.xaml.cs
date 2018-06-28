using PROJEKT.ViewModels;
using PropertyChanged;

using Xamarin.Forms;

namespace PROJEKT.Views.Controls
{
    [AddINotifyPropertyChangedInterface]
    public partial class CompetitionView : ContentView
    {
        private CompetitionItemViewModel _vm;

        public CompetitionView()
        {
            InitializeComponent();
            this.WidthRequest = (Application.Current as App).Width;
            _vm = new CompetitionItemViewModel();

            _vm.DownloadData(caption, year, currentMatchday, numberOfMatchdays, numberOfTeams);
            
        }
    }
}
