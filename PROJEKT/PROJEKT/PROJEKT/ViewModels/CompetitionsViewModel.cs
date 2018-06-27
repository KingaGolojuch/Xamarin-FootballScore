using Newtonsoft.Json;
using PROJEKT.Models;
using PROJEKT.Models.API;
using PROJEKT.Views.Controls;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Xamarin.Forms;

namespace PROJEKT.ViewModels
{
    /// <summary>
    /// Klasa pomocnicza do obsłużenia widoku CompetitionsPage.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class CompetitionsViewModel
    {
        /// <summary>
        /// Lista CustomCompetition, która jest źródłem do kontrolki ListView.
        /// </summary>
        public List<CustomCompetition> Competitions { get; set; }
        /// <summary>
        /// Lista obiektów CompetitionDTO do przekonwertowania danych z JSON.
        /// </summary>
        public List<CompetitionDTO> Results { get; set; }

        /// <summary>
        /// Metoda do pobrania z API danych.
        /// </summary>
        public async void DownloadData(ListView listView, Grid grid, Label lblNoInternet)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Configuration.API_COMPETITIONS));
                string responseJson = await response.Content.ReadAsStringAsync();
                Results = JsonConvert.DeserializeObject<List<CompetitionDTO>>(responseJson);
            }
            catch (Exception ex)
            { }

            Competitions = new List<CustomCompetition>();

            if (Results != null)
            {
                DataView(listView, grid);
            }
            else
            {
                lblNoInternet.IsVisible = true;
            }
            
        }

        /// <summary>
        /// Metoda wczytująca dane do widoku.
        /// </summary>
        private void DataView(ListView listView, Grid grid)
        {
            foreach (var result in Results)
            {
                CustomCompetition custom = new CustomCompetition()
                {
                    Id = result.Id,
                    Caption = result.Caption,
                    League = result.League,
                    Year = result.Year,
                    CurrentMatchday = result.CurrentMatchday.ToString(),
                    NumberOfMatchdays = result.NumberOfMatchdays.ToString(),
                    NumerOfTeams = result.NumberOfTeams.ToString()
                };
                Competitions.Add(custom);
            }

            listView.ItemsSource = Competitions;
            grid.IsVisible = false;
        }
    }
}
