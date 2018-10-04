using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DAL.Contracts
{
    public interface IGenericRepository<T> where T : class, new()
    {
        T Add(T entityToAdd);

        T Update(T entityToUpdate);

        void Delete(T entityToDelete);

        void SaveChanges();

        IQueryable<T> GetAll();
    }
}
