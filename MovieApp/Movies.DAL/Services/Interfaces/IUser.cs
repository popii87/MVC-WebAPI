using Movies.DAL.Models.Data;
using Movies.DAL.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.DAL.Services.Interfaces
{
    public interface IUser
    {
        string CreateNewUser(UserDto user);
        string DeleteUser(int id);
        List<UserDto> GetAll();
        UserDto GetUserById(int id);
        //List<Movie> RentedMovies();
        string UpdateUser(UserDto user);
    }
}
