using System;
using System.Data.Entity;
using System.Linq;
using Pizza.Model;
using Pizza.Model.Interfaces;

namespace Pizza.DataAccess
{
    /// <summary>
    /// Concrete EF implementation of the repository
    /// </summary>
    public class SqlRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;

        public SqlRepository(DbContext context)
        {
            _context = context;
        }

        #region IRepository<T> Members

        public IQueryable<T> FindAll(Func<T, bool> exp)
        {
            return _context.Set<T>().Where(exp).AsQueryable();
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public T FindOne(Func<T, bool> exp)
        {
            return FindAll(exp).FirstOrDefault();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Entity cannot be null");
            }
            _context.Set<T>().Add(entity);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Entity cannot be null");
            }
            _context.Set<T>().Remove(entity);
        }

        #endregion
    }
}