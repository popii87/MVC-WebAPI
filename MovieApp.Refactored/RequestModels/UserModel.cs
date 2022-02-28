using System;
using System.Collections.Generic;
using System.Text;

namespace RequestModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Token { get; set; }
        public List<MovieRequestModel> MovieList { get; set; }
    }
}
