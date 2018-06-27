using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PROJEKT.Views
{
    public partial class InitializationPage : ContentPage
    {
        InitializationViewModel vm;

        public InitializationPage()
        {
            InitializeComponent();
            vm = new InitializationViewModel();
            BindingContext = vm;
            SizeChanged += (s, e) => vm.SizeChanged(Width, Height);
        }

        protected override async void OnAppearing()
        {
            await Task.Delay(1000);
            await Navigation.PushAsync(new CompetitionsPage());
        }

        private void Image_SizeChanged(object s, EventArgs e)
        {
            Image img = (Image)s;
            img.HeightRequest = (Application.Current as App).Height;
            img.WidthRequest = (Application.Current as App).Width;
        }
    }
}
