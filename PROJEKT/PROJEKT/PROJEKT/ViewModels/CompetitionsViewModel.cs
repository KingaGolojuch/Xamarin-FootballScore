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
    [AddINotifyPropertyChangedInterface]
    public class CompetitionsViewModel
    {
        public List<CustomCompetition> Competitions { get; set; }
        public List<CompetitionDTO> Results { get; set; }

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
            }
            else
            {
                lblNoInternet.IsVisible = true;
            }
            listView.ItemsSource = Competitions;
            grid.IsVisible = false;
        }
    }
}
