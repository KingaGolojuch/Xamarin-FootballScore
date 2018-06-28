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
    public class DownloadFixtures : IDownloadFixture
    {
        public FixturesDTO results { get; set; }

        public async System.Threading.Tasks.Task HttpCall()
        {
            results = new FixturesDTO();
            var result = new FixtureResultDTO()
            {
                GoalsAwayTeam = 2,
                GoalsHomeTeam = 2
            };
            var fixture = new FixtureDTO()
            {
                AwayTeamName = "druzyna przeciwna",
                HomeTeamName = "druzyna gospodarzy",
                //Date = System.DateTime.Parse("")
                Result = result,
                Status = "active"
            };
            results.Fixtures = new List<FixtureDTO>();
            results.Fixtures.Add(fixture);

        }

    }
}