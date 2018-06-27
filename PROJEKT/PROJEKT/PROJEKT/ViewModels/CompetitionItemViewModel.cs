using Newtonsoft.Json;
using PROJEKT.Models;
using PROJEKT.Models.API;
using PropertyChanged;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace PROJEKT.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CompetitionItemViewModel
    {
        public CompetitionDTO Result { get; set; }

        public CompetitionItemViewModel()
        { }

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
