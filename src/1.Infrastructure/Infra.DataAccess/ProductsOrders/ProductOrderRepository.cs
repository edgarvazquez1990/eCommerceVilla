using Domain.Model.ProductsOrdes;
using Infra.DataAccess.Context;
using Infra.DataAccess.SeedWork;

namespace Infra.DataAccess.ProductsOrders
{
    public class ProductOrderRepository : Repository<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}
