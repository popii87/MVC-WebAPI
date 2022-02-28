using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestModels
{
    public class RegisterRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genre FavoriteGenre { get; set; }
    }
}
