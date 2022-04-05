using Domain.Model.Orders;
using Domain.Model.SeedWork;

namespace Domain.Model.Products
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual Order Order { get; set; }

        public bool Validate()
        {
            var isValid = false;

            if (!string.IsNullOrEmpty(Name)) isValid = true;

            return isValid;
        }
    }
}
