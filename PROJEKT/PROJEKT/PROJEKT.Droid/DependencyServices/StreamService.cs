using PROJEKT.Droid.DependencyServices;
using PROJEKT.Models.Interfaces;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(StreamService))]
namespace PROJEKT.Droid.DependencyServices
{
    public class StreamService : IStreamService
    {
        public Stream GetStream(string path)
        {
            return Forms.Context.Assets.Open(path);
        }
    }
}