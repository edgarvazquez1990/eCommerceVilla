using Domain.Model.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;

namespace Infra.DataAccess.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        private IDbContextTransaction _currentTransaction;

        public DatabaseContext()
            : base() { }

        //public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        //{
        //    ChangeTracker.LazyLoadingEnabled = false;
        //    ChangeTracker.AutoDetectChangesEnabled = false;
        //}

        public IDbContextTransaction GetCurrentTransaction => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public DbSet<Usuario> Usuario { get; set; }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public IDbContextTransaction BeginTransaction()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = Database.BeginTransaction(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public void Commit(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void Rollback()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "server=osdbqa.cenace.com;database=curso-micro-cvr;port=3306;user=usr-micro-cvr;password=Cenace01#; sslmode = none";

            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

            //if (!optionsBuilder.IsConfigured)
            //{
            //    var conn = "server=osdbqa.cenace.com;database=curso-micro-cvr;port=3306;user=usr-micro-cvr;password=Cenace01#; sslmode = none";

            //    optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Agregamos las configuraciones
            List<Type> ConfigurationMaps = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            ConfigurationMaps.ForEach(x => modelBuilder.ApplyConfiguration((dynamic)Activator.CreateInstance(x)));

        }
    }
}
