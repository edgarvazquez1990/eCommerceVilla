using Domain.Model.Orders;
using Domain.Model.Products;

namespace Domain.Model.ProductsOrdes
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
