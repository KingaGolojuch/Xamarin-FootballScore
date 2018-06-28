using Newtonsoft.Json;
using PROJEKT.Models;
using PROJEKT.Models.API;
using PROJEKT.Views.Controls;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using PROJEKT.Models.Interfaces;

namespace PROJEKT.ViewModels
{
    /// <summary>
    /// Klasa implementujaca metode API potrzebna do pobrania Fixture
    /// </summary>
    public class DownloadFixture : IDownloadFixture
    {
        public FixturesDTO results { get; set; }

        public async System.Threading.Tasks.Task HttpCall()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Configuration.API_COMPETITIONS + "/" + (Application.Current as App).CompetitionId) + "/fixtures");

                string responseJson = await response.Content.ReadAsStringAsync();

                results = JsonConvert.DeserializeObject<FixturesDTO>(responseJson);
            }
            catch (Exception ex)
            { }

        }

    }
    /// <summary> 
    /// Klasa pomocnicza do obsłużenia widoku.
    /// </summary> 
    [AddINotifyPropertyChangedInterface]
    public class FixtureItemViewModel
    {
        /// <summary> 
        /// Lista obiektów FixturesDTO do przekonwertowania danych z JSON. 
        /// </summary> 
        public FixturesDTO Results { get; set; }

        /// <summary> 
        /// Konstruktor. 
        /// </summary> 
        public FixtureItemViewModel()
        { }

        /// <summary> 
        /// Metoda do pobrania z API danych oraz wczytywanie ich do widoku.
        /// </summary> 
        public async void DownloadData(IDownloadFixture download, ListView listView)
        {
            await download.HttpCall();
            Results = download.results;

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
