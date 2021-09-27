using Movies.DAL.Context;
using Movies.DAL.Models.Data;
using Movies.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.DAL.Repositories.Classes
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieDbContext _moviesDb;
        public MovieRepository(MovieDbContext moviesDb)
        {
            _moviesDb = moviesDb;
        }
        public void Create(Movie entity)
        {

            _moviesDb.Movies.Add(entity);
            _moviesDb.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _moviesDb.Movies.FirstOrDefault(m => m.Id == id);
            _moviesDb.Movies.Remove(movie);
            _moviesDb.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _moviesDb.Movies.ToList();
        }

        public void Update(Movie entity)
        {
            
            _moviesDb.Movies.Update(entity);
            _moviesDb.SaveChanges();
        }
    }
}

