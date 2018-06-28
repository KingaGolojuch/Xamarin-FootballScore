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
    public class DownloadCompetitions : IDownloadCompetition
    {
        public List<CompetitionDTO> results { get; set; }

        public async System.Threading.Tasks.Task HttpCall()
        {
            results = new List<CompetitionDTO>();
            var result = new CompetitionDTO()
            {
                Caption = "tytul",
                CurrentMatchday = 2,
                Id = 1,
                League = "premier liga",
                NumberOfMatchdays = 3,
                NumberOfTeams = 4,
            };
            results.Add(result);
        }
    }
}