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
    }
}
