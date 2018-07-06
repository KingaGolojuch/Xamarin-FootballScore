using Newtonsoft.Json;
using PROJEKT.Models;
using PROJEKT.Models.API;
using PROJEKT.Models.Interfaces;
using PROJEKT.Views.Controls;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace PROJEKT.ViewModels
{
    /// <summary>
    /// Klasa implementujaca metode API potrzebna do pobrania Team
    /// </summary>
    public class DownloadTeam : IDownloadTeam
    {
        public TeamsDTO results { get; set; }
        public async System.Threading.Tasks.Task HttpCall()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Configuration.API_COMPETITIONS + "/" + (Application.Current as App).CompetitionId) + "/teams");
                string responseJson = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<TeamsDTO>(responseJson);
            }
            catch (Exception ex)
            { }
        }
    }
    /// <summary> 
    /// Klasa pomocnicza do obsłużenia widoku.
    /// </summary> 
    [AddINotifyPropertyChangedInterface]
    public class TeamItemViewModel
    {
        /// <summary> 
        /// Lista obiektów LeaguesDTO do przekonwertowania danych z JSON. 
        /// </summary>
        public TeamsDTO Results { get; set; }

        /// <summary> 
        /// Konstruktor. 
        /// </summary> 
        public TeamItemViewModel()
        { }

        /// <summary> 
        /// Metoda do pobrania z API danych oraz wczytywanie ich do widoku.
        /// </summary>
        /// <param name="download">Obiekt implementujący IDownloadTeam, musi posiadać właściwość TeamsDTO</param>
        /// <param name="listView">Widok listy</param>
        public async void DownloadData(IDownloadTeam download, ListView listView)
        {
            await download.HttpCall();
            Results = download.results;

            List<CustomTeam> list = new List<CustomTeam>();
            if (Results != null)
            {
                int lp = 1;
                foreach (var result in Results.Teams)
                {
                    CustomTeam custom = new CustomTeam()
                    {
                        Lp = lp.ToString() + ".",
                        Name = result.Name
                    };
                    list.Add(custom);
                    lp++;
                }

                listView.ItemsSource = list;
                listView.ItemTemplate = new DataTemplate(typeof(TeamsItemView));
            }
        }
    }
}
