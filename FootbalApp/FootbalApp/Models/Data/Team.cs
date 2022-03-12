using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootbalApp.Models.Data
{
    public class Team
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
        public int Year { get; set; }

        public string History { get; set; }

        public List<Player> TeamPlayers { get; set; }


    }
}
