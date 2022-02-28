using DomainModels.Enums;
using RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        void AddMovie(MovieRequestModel requestModel);
        MovieRequestModel GetMovieById(int id);
        IEnumerable<MovieRequestModel> GetAllMovies();
        IEnumerable<MovieRequestModel> GetMovieByGenre(Genre genre);
        void Delete(int userId, int id);
        void Update(MovieRequestModel requestModel);


    }
}
