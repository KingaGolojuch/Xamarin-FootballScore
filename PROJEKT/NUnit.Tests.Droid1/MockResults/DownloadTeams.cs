using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PROJEKT.Models.API;
using PROJEKT.Models.Interfaces;

namespace NUnit.Tests.Droid1.MockResults
{
    public class DownloadTeams : IDownloadTeam
    {         
        public TeamsDTO results { get; set; }

        public async System.Threading.Tasks.Task HttpCall()
        {
            results = new TeamsDTO();
            var result = new TeamDTO()
            {
                Name = "druzyna"
            };
            results.Teams.Add(result);

        }

    }
}
