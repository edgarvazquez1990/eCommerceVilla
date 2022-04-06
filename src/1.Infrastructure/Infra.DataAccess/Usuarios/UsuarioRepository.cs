using Domain.Model.Usuarios;
using Infra.DataAccess.Context;
using Infra.DataAccess.SeedWork;

namespace Infra.DataAccess.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly IDatabaseContext _database;
        public UsuarioRepository(IDatabaseContext database) : base(database)
        {
            _database = database;
        }
    }
}
