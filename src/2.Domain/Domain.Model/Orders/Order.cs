using Domain.Model.Products;
using Domain.Model.ProductsOrdes;
using Domain.Model.SeedWork;
using Domain.Model.Usuarios;

namespace Domain.Model.Orders
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public DateTime FechaCompra { get; set; }

        public decimal Monto { get; set; }

        public virtual IEnumerable<ProductOrder> ProductsOrders { get; set; }

        public int? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public bool Validate()
        {
            var isValid = false;

            if (Monto > 0) isValid = true;

            return isValid;
        }
    }
}
