using Domain.Model.Orders;
using Domain.Model.Products;
using Domain.Model.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ProductsOrdes
{
    public  class ProductOrder 
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
