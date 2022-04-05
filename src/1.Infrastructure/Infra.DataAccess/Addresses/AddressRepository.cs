using Domain.Model.Addresses;
using Infra.DataAccess.Context;
using Infra.DataAccess.SeedWork;

namespace Infra.DataAccess.Addresses
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(IDatabaseContext database) : base(database)
        {

        }
    }
}
