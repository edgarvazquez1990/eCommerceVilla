using Domain.Model.Products;
using Domain.Model.SeedWork;

namespace Domain.Model.Orders
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public DateTime FechaCompra { get { return DateTime.Now; } }

        public decimal Monto { get; set; }

        public virtual IEnumerable<Product> Productos { get; set; }

        public bool Validate()
        {
            var isValid = false;

            if (Monto > 0) isValid = true;

            return isValid;
        }
    }
}
