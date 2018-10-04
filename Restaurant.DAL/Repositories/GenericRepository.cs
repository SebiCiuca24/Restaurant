using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Context;
using Restaurant.DAL.Contracts;
using System.Linq;

namespace Restaurant.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected RestaurantDbContext _restaurantDbContext;

        protected DbSet<T> _entities;

        #region Construnctor
        public GenericRepository(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;

            _entities = restaurantDbContext.Set<T>();
        }

        #endregion Constructor

        public T Add(T entityToAdd)
        {
            return _entities.Add(entityToAdd).Entity;
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_restaurantDbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _entities.Attach(entityToDelete);
            }

            _entities.Remove(entityToDelete);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entities;
        }

        public void SaveChanges()
        {
            _restaurantDbContext.SaveChanges();
        }

        public virtual T Update(T entityToUpdate)
        {
            return _entities.Update(entityToUpdate).Entity;
        }
    }
}
