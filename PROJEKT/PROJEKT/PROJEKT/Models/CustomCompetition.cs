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
    public class CustomCompetition
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string League { get; set; }
        public string Year { get; set; }
        public string CurrentMatchday { get; set; }
        public string NumberOfMatchdays { get; set; }
        public string NumerOfTeams { get; set; }
    }
}
