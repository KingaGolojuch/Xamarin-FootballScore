using Newtonsoft.Json;
using PROJEKT.Models;
using PROJEKT.Models.API;
using PROJEKT.Views.Controls;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace PROJEKT.ViewModels
{
    /// <summary> 
    /// Klasa pomocnicza do obsłużenia widoku.
    /// </summary> 
    [AddINotifyPropertyChangedInterface]
    public class LeagueItemViewModel
    {
        /// <summary> 
        /// Lista obiektów LeaguesDTO do przekonwertowania danych z JSON. 
        /// </summary>
        public LeaguesDTO Results { get; set; }

        /// <summary> 
        /// Konstruktor. 
        /// </summary> 
        public LeagueItemViewModel()
        { }

        /// <summary> 
        /// Metoda do pobrania z API danych oraz wczytywanie ich do widoku.        
        /// </summary>
        /// <param name="stlItem">Referencja StackLayout dla widoku</param>
        public async void DownloadData(StackLayout stlItem)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Configuration.API_COMPETITIONS + "/" + (Application.Current as App).CompetitionId) + "/leagueTable");
                string responseJson = await response.Content.ReadAsStringAsync();
                Results = JsonConvert.DeserializeObject<LeaguesDTO>(responseJson);
            }
            catch (Exception ex)
            { }

            List<LeagueViewModel> list = new List<LeagueViewModel>();
            if (Results != null)
            {
                foreach (var result in Results.League)
                {
                    LeagueViewModel league = new LeagueViewModel()
                    {
                        Position = result.Position.ToString(),
                        TeamName = result.TeamName,
                        Points = result.Points.ToString(),
                        Wins = result.Wins.ToString(),
                        Draws = result.Draws.ToString(),
                        Losses = result.Losses.ToString(),
                        PlayedGames = result.PlayedGames.ToString(),
                        Goals = result.Goals.ToString()
                    };
                    list.Add(league);
                }

                foreach (var item in list)
                {
                    LeagueItemView view = new LeagueItemView();
                    view.BindingContext = item;
                    stlItem.Children.Add(view);
                }
            }
        }
    }
}
