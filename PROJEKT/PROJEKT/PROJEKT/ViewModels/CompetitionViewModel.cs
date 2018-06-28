using Newtonsoft.Json;
using PROJEKT.Models;
using PROJEKT.Models.API;
using PROJEKT.Views.Controls;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PROJEKT.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CompetitionViewModel
    {
        public MyCarouselView view = null;
        public Grid GHome = null;
        public Grid GFixtures = null;
        public Grid GLeague = null;
        public Grid GTeams = null;
        public List<CustomCompetition> ListPages { get; set; }
        public Command CmdHome { get; set; }
        public Command CmdFixtures { get; set; }
        public Command CmdLeague { get; set; }
        public Command CmdTeams { get; set; }

        public CompetitionViewModel()
        {
            CmdHome = new Command(() =>
            {
                view.SelectedIndex = 0;
                ChangeBackground(GHome);
            });
            CmdFixtures = new Command(() =>
            {
                view.SelectedIndex = 1;
                ChangeBackground(GFixtures);
            });
            CmdLeague = new Command(() =>
            {
                view.SelectedIndex = 2;
                ChangeBackground(GLeague);
            });
            CmdTeams = new Command(() =>
            {
                view.SelectedIndex = 3;
                ChangeBackground(GTeams);
            });
        }

        public void ChangeBackground(Grid grid)
        {
            GTeams.BackgroundColor = Color.FromHex("#073a0a");
            GFixtures.BackgroundColor = Color.FromHex("#073a0a");
            GLeague.BackgroundColor = Color.FromHex("#073a0a");
            GHome.BackgroundColor = Color.FromHex("#073a0a");
            grid.BackgroundColor = Color.FromHex("#efefef");
        }

        public void DownloadData()
        {
            ListPages = new List<CustomCompetition>()
            {
                new CustomCompetition() { Id = 1},
                new CustomCompetition() { Id = 2},
                new CustomCompetition() { Id = 3},
                new CustomCompetition() { Id = 4}
            };
            view.ItemsSource = ListPages;
        }
    }
}
