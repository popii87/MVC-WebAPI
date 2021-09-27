using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T entity);
        List<T> GetAll();
        void Delete(int id);
        void Update(T entity);
    }
}
