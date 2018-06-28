using PROJEKT.Models.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PROJEKT.Models.Extensions
{
    [ContentProperty("Source")]
    public class AssetsImageExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            try
            {
                Stream stream = DependencyService.Get<IStreamService>().GetStream(Source);
                return ImageSource.FromStream(() => stream);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ImageSource GetSource(string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                try
                {
                    Stream stream = DependencyService.Get<IStreamService>().GetStream(source);
                    return ImageSource.FromStream(() => { return stream; });
                }
                catch (Exception) { }
            }
            return source != null ? ImageSource.FromFile(source) : null;
        }
    }
}
