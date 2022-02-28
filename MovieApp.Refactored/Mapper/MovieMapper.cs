using DomainModels.Data;
using RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mapper
{
    public static class MovieMapper
    {
        public static Movie MapToMovie(MovieRequestModel requestModel)
        {
            return new Movie()
            {
                Title = requestModel.Title,
                Description = requestModel.Description,
                Year = requestModel.Year,
                Genre = requestModel.Genre,
                UserId = requestModel.UserId
            };
        }

        public static MovieRequestModel MapToMovieRequestModel(Movie movie)
        {
            return new MovieRequestModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre,
                UserId = movie.UserId
            };
        }
    }
}
