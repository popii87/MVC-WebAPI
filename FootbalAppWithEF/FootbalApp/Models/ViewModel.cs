using FootbalApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootbalApp.Models
{
    public class ViewModel
    {
        public Team Team { get; set; }
        public Player Player { get; set; }

        public List<Team> Teams { get; set; }
        public List<Player> Players { get; set; }
    }
}
