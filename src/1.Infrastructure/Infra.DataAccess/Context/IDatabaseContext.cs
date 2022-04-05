using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.DataAccess.Context
{
    public interface IDatabaseContext
    {
        DbSet<T> Set<T>() where T : class;

        IDbContextTransaction BeginTransaction();

        void Commit(IDbContextTransaction transaction);

        void Rollback();

        void Save();
    }
}
