using PROJEKT.Models;
using PROJEKT.Models.Extensions;
using PROJEKT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PROJEKT.Views.Controls
{
    public partial class TeamsView : ContentView
    {
        private TeamItemViewModel _vm;

        public TeamsView()
        {
            InitializeComponent();
            this.WidthRequest = (Application.Current as App).Width;
            _vm = new TeamItemViewModel();

            _vm.DownloadData(listView);
        }
    }
}
