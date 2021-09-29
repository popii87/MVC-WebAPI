using Movies.DAL.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.DAL.Models.Dto
{
    public class Mappers
    {
        public static Movie MovieDtoToMovie(MovieDto entity)
        {
            return new Movie
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Year = entity.Year,
                Genre = entity.Genre,
                UserId = entity.UserId
            };
        }

        public static MovieDto MovieToMovieDto(Movie entity)
        {
            return new MovieDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Year = entity.Year,
                Genre = entity.Genre,
                UserId = entity.UserId
            };

        }
        public static User UserDtoToUser(UserDto user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FavoriteGenre = user.FavoriteGenre
                
            };
        }
        public static UserDto UserToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FavoriteGenre = user.FavoriteGenre
              
            };

        }
    }
}
