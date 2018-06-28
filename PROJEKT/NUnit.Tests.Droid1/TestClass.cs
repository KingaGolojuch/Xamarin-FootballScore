using NUnit.Framework;
using NUnit.Tests.Droid1.MockResults;
using PROJEKT.Models;
using PROJEKT.ViewModels;
using PROJEKT.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NUnit.Tests.Droid1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TeamsViewIsUpdated()
        {
            //FixturesView ftView = new FixturesView();
            TeamItemViewModel teamsView = new TeamItemViewModel();

            MyListView lst = new MyListView();
            //lst = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::PROJEKT.Views.Controls.MyListView>(ftView, "listView");

            DownloadTeams downresults = new DownloadTeams();
            teamsView.DownloadData(downresults, lst);


            List<CustomTeam> cstlst = (List<CustomTeam>)lst.ItemsSource;

            Assert.AreEqual(cstlst[0].Name, downresults.results.Teams[0].Name);
        }
        [Test]
        public void FixturesViewIsUpdated()
        {
            //FixturesView ftView = new FixturesView();
            FixtureItemViewModel fixturesView = new FixtureItemViewModel();

            MyListView lst = new MyListView();
            //lst = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::PROJEKT.Views.Controls.MyListView>(ftView, "listView");

            DownloadFixtures downresults = new DownloadFixtures();
            fixturesView.DownloadData(downresults, lst);


            List<CustomFixture> cstlst = (List<CustomFixture>)lst.ItemsSource;

            Assert.AreEqual(cstlst[0].HomeTeam, downresults.results.Fixtures[0].HomeTeamName);
            Assert.AreEqual(cstlst[0].AwayTeam, downresults.results.Fixtures[0].AwayTeamName);
            Assert.AreEqual(cstlst[0].HomeTeamGoals, downresults.results.Fixtures[0].Result.GoalsHomeTeam.ToString());
            Assert.AreEqual(cstlst[0].AwayTeamGoals, downresults.results.Fixtures[0].Result.GoalsAwayTeam.ToString());
            //Assert.AreEqual(cstlst[0].Date, downresults.Results.Fixtures[0].Date);



        }
        [Test]
        public void CompetionsViewIsUpdated()
        {
            CompetitionsViewModel competitonsView = new CompetitionsViewModel();

            DownloadCompetitions downresults = new DownloadCompetitions();
            ListView lst = new ListView();
            Grid grd = new Grid();
            Label lbl = new Label();
            competitonsView.DownloadData(downresults, lst, grd, lbl);

            List<CustomCompetition> cstlst = (List<CustomCompetition>)lst.ItemsSource;

            Assert.AreEqual(cstlst[0].Id, downresults.results[0].Id);
            Assert.AreEqual(cstlst[0].Caption, downresults.results[0].Caption);
            Assert.AreEqual(cstlst[0].League, downresults.results[0].League);
            Assert.AreEqual(cstlst[0].CurrentMatchday, downresults.results[0].CurrentMatchday.ToString());
            Assert.AreEqual(cstlst[0].NumberOfMatchdays, downresults.results[0].NumberOfMatchdays.ToString());
            Assert.AreEqual(cstlst[0].NumerOfTeams, downresults.results[0].NumberOfTeams.ToString());

        }
    }
}
