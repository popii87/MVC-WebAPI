using Movies.DAL.Models.Data;
using Movies.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.DAL.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genre FavoriteGenre { get; set; }
        
    }
}
