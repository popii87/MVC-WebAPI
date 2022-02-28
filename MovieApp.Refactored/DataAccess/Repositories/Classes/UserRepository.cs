using DataAccess.Context;
using DataAccess.Repositories.Interfaces;
using DomainModels.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Classes
{
    public class UserRepository : IRepository<User>
    {
        private readonly MovieDbContext _context;
        public UserRepository(MovieDbContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
