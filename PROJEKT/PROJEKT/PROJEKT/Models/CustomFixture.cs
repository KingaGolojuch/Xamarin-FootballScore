using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT.Models
{
    /// <summary> 
    /// Klasa pomocnicza do przechowywania danych dla widoku.
    /// </summary> 
    public class CustomFixture
    {
        public string Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeamGoals { get; set; }
        public string AwayTeamGoals { get; set; }
    }
}
