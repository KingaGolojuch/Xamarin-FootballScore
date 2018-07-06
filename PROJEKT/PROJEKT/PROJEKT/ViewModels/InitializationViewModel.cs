using PropertyChanged;
using Xamarin.Forms;

namespace PROJEKT.ViewModels
{
    /// <summary> 
    /// Klasa pomocnicza do obsłużenia widoku InitializationPage.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class InitializationViewModel
    {
        /// <summary> 
        /// Metoda do zapisywania rozdzielczości telefonu.
        /// </summary> 
        /// <param name="height">Wysokosc ekranu</param>
        /// <param name="width">Szerokosc ekranu</param>
        public void SizeChanged(double width, double height)
        {
            (Application.Current as App).Width = width;
            (Application.Current as App).Height = height;
        }
    }
}
