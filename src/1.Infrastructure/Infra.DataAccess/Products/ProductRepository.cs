using Domain.Model.Products;
using Domain.Model.ProductsOrdes;
using Infra.DataAccess.Context;
using Infra.DataAccess.SeedWork;

namespace Infra.DataAccess.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseContext database) : base(database)
        {
        }
    }
}
