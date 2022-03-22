using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootbalApp.Models.Data
{
    public class Team
    {
        public Team()
        {
            TeamPlayers = new HashSet<Player>();
        }
        public string Name { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
        public int Year { get; set; }

        public string History { get; set; }

        public virtual ICollection<Player> TeamPlayers { get; set; }


    }
}
