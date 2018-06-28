using PROJEKT.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT.Models.Interfaces
{
    /// <summary>
    /// Interfejs do pobrania Competition
    /// </summary>
    public interface IDownloadCompetition
    {
        System.Threading.Tasks.Task HttpCall();
        List<CompetitionDTO> results { get; set; }
    }
}
