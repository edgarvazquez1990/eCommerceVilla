using Domain.Model.Orders;
using Infra.DataAccess.Context;
using Infra.DataAccess.SeedWork;

namespace Infra.DataAccess.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}
