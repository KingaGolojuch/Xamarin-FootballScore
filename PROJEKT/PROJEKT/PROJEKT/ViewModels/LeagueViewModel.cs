using PropertyChanged;

namespace PROJEKT.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LeagueViewModel
    {
        public string Position { get; set; }
        public string TeamName { get; set; }
        public string PlayedGames { get; set; }
        public string Points { get; set; }
        public string Goals { get; set; }
        public string Wins { get; set; }
        public string Draws { get; set; }
        public string Losses { get; set; }
    }
}
