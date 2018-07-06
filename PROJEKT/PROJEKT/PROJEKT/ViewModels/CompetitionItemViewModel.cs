using Newtonsoft.Json;
using PROJEKT.Models;
using PROJEKT.Models.API;
using PropertyChanged;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace PROJEKT.ViewModels
{
    /// <summary> 
    /// Klasa pomocnicza do załadowania danych do widoku.
    /// </summary> 
    [AddINotifyPropertyChangedInterface]
    public class CompetitionItemViewModel
    {
        /// <summary> 
        /// Lista obiektów CompetitionDTO do przekonwertowania danych z JSON. 
        /// </summary> 
        public CompetitionDTO Result { get; set; }

        /// <summary> 
        /// Konstruktor.
        /// </summary> 
        public CompetitionItemViewModel()
        { }

        /// <summary> 
        /// Metoda do pobrania z API danych oraz wczytywanie ich do widoku.
        /// </summary> 
        /// <param name="caption">Labelka nagłówka</param>
        /// <param name="currentMatchday">Labelka informujaca o obecnej turze ligi</param>
        /// <param name="numberOfMatchdays">Labelka informujaca o ilosci rozgrywanych meczy</param>
        /// <param name="numberOfTeams">Labelka informujaca o ilosci druzyn</param>
        /// <param name="year">Labelka informujaca o roku danych rozgrywek</param>
        public async void DownloadData(Label caption, Label year, Label currentMatchday, Label numberOfMatchdays, Label numberOfTeams)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Configuration.API_COMPETITIONS + "/" + (Application.Current as App).CompetitionId));
                string responseJson = await response.Content.ReadAsStringAsync();
                Result = JsonConvert.DeserializeObject<CompetitionDTO>(responseJson);
            }
            catch (Exception ex)
            { }

            if (Result != null)
            {
                caption.Text = Result.Caption;
                year.Text = Result.Year;
                currentMatchday.Text = Result.CurrentMatchday.ToString();
                numberOfMatchdays.Text = Result.NumberOfMatchdays.ToString();
                numberOfTeams.Text = Result.NumberOfTeams.ToString();
            }
        }
    }
}
