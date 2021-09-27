using Movies.DAL.Models.Data;
using Movies.DAL.Models.Dto;
using Movies.DAL.Models.Enums;
using Movies.DAL.Repositories.Interfaces;
using Movies.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.DAL.Services.Classes
{
    public class MovieService : IMovie
    {
        private readonly IRepository<Movie> _movieRepository;
        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public string CreateMovie(MovieDto movie)
        {

            if (movie == null)
            {
                throw new Exception("Error");
            }
            var newMovie = Mappers.MovieDtoToMovie(movie);
            _movieRepository.Create(newMovie);
            return "New Movie is added!!!";


        }

        public string Delete(int id)
        {
            if (id < 1)
            {
                throw new Exception("Error");
            }
           
            _movieRepository.Delete(id);
            return "Movie is deleted!!!";
        }

        public List<MovieDto> GetAll()
        {
            var movies = _movieRepository.GetAll().Select(m => Mappers.MovieToMovieDto(m)).ToList();
            return movies;
        }

        public List<MovieDto> GetMovieByGenre(Genre genre)
        {
            var movies = _movieRepository.GetAll().Select(m => Mappers.MovieToMovieDto(m)).Where(g => g.Genre == genre).ToList();
            return movies;
        }

        public MovieDto GetMovieById(int id)
        {
            var movie = _movieRepository.GetAll().FirstOrDefault(m => m.Id == id);
            var movie1 = Mappers.MovieToMovieDto(movie);
            return movie1;
        }

        public string Update(MovieDto movie)
        {
            var updatedMovie = Mappers.MovieDtoToMovie(movie);
            _movieRepository.Update(updatedMovie);
            return "Movie is Updated";
        }
    }
}
