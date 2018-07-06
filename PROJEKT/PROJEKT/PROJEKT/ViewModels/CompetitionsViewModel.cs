using Newtonsoft.Json;
using PROJEKT.Models;
using PROJEKT.Models.API;
using PROJEKT.Models.Interfaces;
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
    /// Klasa implementujaca metode API potrzebna do pobrania Competition
    /// </summary>
    public class DownloadCompetition : IDownloadCompetition
    {
        public List<CompetitionDTO> results { get; set; }


        public async System.Threading.Tasks.Task HttpCall()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Configuration.API_COMPETITIONS));
                string responseJson = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<CompetitionDTO>>(responseJson);
            }
            catch (Exception ex)
            { }
        }
    }
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
        /// Metoda do pobrania z API danych oraz wczytywanie ich do widoku.
        /// </summary> 
        /// <param name="download">Obiekt implementujący IDownloadCompetition, musi posiadać właściwość liste CompetitionsDTO</param>
        /// <param name="listView">Widok listy</param>
        /// <param name="grid">Grid aplikacji</param>
        /// <param name="lblNoInternet">Labelka do informacji o braku połączenia</param>
        public async void DownloadData(IDownloadCompetition download,ListView listView, Grid grid, Label lblNoInternet)
        {
            await download.HttpCall();
            Results = download.results;

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
