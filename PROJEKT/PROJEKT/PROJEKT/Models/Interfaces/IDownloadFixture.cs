using PROJEKT.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT.Models.Interfaces
{
    /// <summary>
    /// Interfejs do pobrania danych dla Fixture
    /// </summary>
    public interface IDownloadFixture
    {
        FixturesDTO results { get; set; }
        System.Threading.Tasks.Task HttpCall();
    }
}
