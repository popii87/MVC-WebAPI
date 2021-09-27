using Movies.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.DAL.Models.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genre FavoriteGenre { get; set; }
        public List<Movie> MoviesList { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
