using PropertyChanged;
using Xamarin.Forms;

namespace PROJEKT.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class InitializationViewModel
    {
        public void SizeChanged(double width, double height)
        {
            (Application.Current as App).Width = width;
            (Application.Current as App).Height = height;
        }
    }
}
