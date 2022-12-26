using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootbalApp.Models.Data
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public Team()
        {
            TeamPlayers = new HashSet<Player>().ToList();
        }

        public string Name { get; set; }
        public string City { get; set; }
        public string Stadium { get; set; }
        public int Year { get; set; }

        public string History { get; set; }

        public virtual List<Player> TeamPlayers { get; set; }


    }
}
