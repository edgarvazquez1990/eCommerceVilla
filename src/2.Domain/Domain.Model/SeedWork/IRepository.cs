using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Domain.Model.SeedWork
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(object id);

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includes = "");

        void Add(T entity);

        void AddRange(T[] entities);

        void Remove(T entity);

        void Remove(object id);

        void Update(T entity);

        void UpdateRange(T[] entities);

        IDbContextTransaction BeginTransaction();

        void Rollback();

        void Commit(IDbContextTransaction transaction);

        void Save();
    }
}
