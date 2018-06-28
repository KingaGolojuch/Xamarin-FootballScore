using PROJEKT.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT.Models.Interfaces
{
    public interface IDownloadTeam
    {
        System.Threading.Tasks.Task HttpCall();
        TeamsDTO results { get; set; }

    }
}
