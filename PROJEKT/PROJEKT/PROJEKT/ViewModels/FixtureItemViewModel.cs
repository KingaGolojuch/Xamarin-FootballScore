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
    [AddINotifyPropertyChangedInterface]
    public class FixtureItemViewModel
    {
        public FixturesDTO Results { get; set; }

        public FixtureItemViewModel()
        { }

        public async void DownloadData(ListView listView)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Configuration.API_COMPETITIONS + "/" + (Application.Current as App).CompetitionId) + "/fixtures");
                string responseJson = await response.Content.ReadAsStringAsync();
                Results = JsonConvert.DeserializeObject<FixturesDTO>(responseJson);
            }
            catch (Exception ex)
            { }

            List<CustomFixture> list = new List<CustomFixture>();
            if (Results != null)
            {
                foreach (var result in Results.Fixtures)
                {
                    CustomFixture custom = new CustomFixture()
                    {
                        Date = result.Date.ToString("HH:mm dd.MM.yyyy") + " r.",
                        AwayTeam = result.AwayTeamName,
                        HomeTeam = result.HomeTeamName,
                        AwayTeamGoals = result.Result.GoalsAwayTeam.ToString(),
                        HomeTeamGoals = result.Result.GoalsHomeTeam.ToString()
                    };
                    list.Add(custom);
                }
            }

            listView.ItemsSource = list;
            listView.ItemTemplate = new DataTemplate(typeof(FixturesItemView));
        }
    }
}
