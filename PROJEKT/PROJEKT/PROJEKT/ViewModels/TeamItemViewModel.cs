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
    public class TeamItemViewModel
    {
        public TeamsDTO Results { get; set; }

        public TeamItemViewModel()
        { }

        public async void DownloadData(ListView listView)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Configuration.API_COMPETITIONS + "/" + (Application.Current as App).CompetitionId) + "/teams");
                string responseJson = await response.Content.ReadAsStringAsync();
                Results = JsonConvert.DeserializeObject<TeamsDTO>(responseJson);
            }
            catch (Exception ex)
            { }

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
