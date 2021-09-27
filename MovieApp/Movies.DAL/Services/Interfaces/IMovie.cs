using Movies.DAL.Models.Dto;
using Movies.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.DAL.Services.Interfaces
{
    public interface IMovie
    {
        string CreateMovie(MovieDto movie);
        MovieDto GetMovieById(int id);
        List<MovieDto> GetAll();
        List<MovieDto> GetMovieByGenre(Genre genre);
        string Delete(int id);
        string Update(MovieDto movie);
    }
}
