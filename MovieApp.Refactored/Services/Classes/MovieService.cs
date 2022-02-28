using Common.Exceptions;
using DataAccess.Repositories.Interfaces;
using DomainModels.Data;
using DomainModels.Enums;
using Mapper;
using RequestModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Classes
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void AddMovie(MovieRequestModel requestModel)
        {
            var movie = MovieMapper.MapToMovie(requestModel);
            _movieRepository.Add(movie);
        }

        public void Delete(int userId, int id)
        {
            var movie = _movieRepository.GetAll().SingleOrDefault(x => x.UserId == userId && x.Id == id);
            _movieRepository.Delete(movie);
        }

        public IEnumerable<MovieRequestModel> GetAllMovies()
        {
            var movie = _movieRepository.GetAll();
            var moviesRequestModel = new List<MovieRequestModel>();
            foreach (var item in movie)
            {
                var movieRequestModel = MovieMapper.MapToMovieRequestModel(item);
                moviesRequestModel.Add(movieRequestModel);
            }
            return moviesRequestModel;
        }

        public IEnumerable<MovieRequestModel> GetMovieByGenre(Genre genre)
        {
            var movie = _movieRepository.GetAll().Where(x => x.Genre == genre);
            var moviesRequestModel = new List<MovieRequestModel>();
            foreach (var item in movie)
            {
                var movieRequestModel = MovieMapper.MapToMovieRequestModel(item);
                moviesRequestModel.Add(movieRequestModel);
            }
            return moviesRequestModel;

        }

        public MovieRequestModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                throw new MovieException(id, "Movie not found");
            }
            //var movieRequestModel = MovieMapper.MapToMovieRequestModel(movie);
            return MovieMapper.MapToMovieRequestModel(movie);
        }

        public void Update(MovieRequestModel requestModel)
        {
            var updatedMovie = MovieMapper.MapToMovie(requestModel);
            if (updatedMovie == null)
            {
                throw new MovieException(updatedMovie.Id, "Movie not found");
            }
            _movieRepository.Update(updatedMovie);
        }
    }
}
