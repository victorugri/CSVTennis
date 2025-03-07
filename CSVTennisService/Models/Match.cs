using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVTennisService.Models
{
    public class Match
    {
        public string Tournament { get; set; }
        public string Surface { get; set; }
        public string Round { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }
        public int WinnerGames { get; set; }
        public int LoserGames { get; set; }
        public string Score { get; set; }
    }
}
