using Domain.Model.SeedWork;
using Infra.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Infra.DataAccess.SeedWork
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDatabaseContext _database;

        public Repository(IDatabaseContext database)
        {
            _database = database;
        }

        public IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public T GetById(object id)
        {
            return _database.Set<T>().Find(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includes = "")
        {
            var query = _database.Set<T>().AsQueryable();
            if (filter != null)
                query = query.Where(filter);
            if (!string.IsNullOrEmpty(includes))
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

        public void Add(T entity)
        {
            _database.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
        }

        public void Remove(object Id)
        {
            var entity = _database.Set<T>().Find(Id);
            _database.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _database.Set<T>().Update(entity);
        }

        public void UpdateRange(T[] entities)
        {
            _database.Set<T>().UpdateRange(entities);
        }
        public void AddRange(T[] entities)
        {
            _database.Set<T>().AddRange(entities);
        }
        public void Save()
        {
            _database.Save();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _database.BeginTransaction();
        }

        public void Rollback()
        {
            _database.Rollback();
        }

        public void Commit(IDbContextTransaction transaction)
        {
            _database.Commit(transaction);
        }
    }
}
