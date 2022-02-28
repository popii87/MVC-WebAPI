using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using DomainModels.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Classes
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieDbContext _moviesDb;
        public MovieRepository(MovieDbContext moviesDb)
        {
            _moviesDb = moviesDb;
        }
        public void Add(Movie entity)
        {
            _moviesDb.Movies.Add(entity);
            _moviesDb.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _moviesDb.Movies.Remove(entity);
            _moviesDb.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _moviesDb.Movies;
        }

        public void Update(Movie entity)
        {
            _moviesDb.Movies.Update(entity);
            _moviesDb.SaveChanges();
        }
    }
}
