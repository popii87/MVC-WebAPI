using Movies.DAL.Context;
using Movies.DAL.Models.Data;
using Movies.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.DAL.Repositories.Classes
{
    public class UserRepository : IRepository<User>
    {
        private readonly MovieDbContext _moviesDb;
        public UserRepository(MovieDbContext moivesDb)
        {
            _moviesDb = moivesDb;
        }
        public void Create(User entity)
        {

            _moviesDb.Users.Add(entity);
            _moviesDb.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _moviesDb.Users.FirstOrDefault(u => u.Id == id);
            _moviesDb.Users.Remove(user);
            _moviesDb.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _moviesDb.Users.ToList();
        }

        public void Update(User entity)
        {
           
            _moviesDb.Users.Update(entity);
            _moviesDb.SaveChanges();
        }
    }
}
