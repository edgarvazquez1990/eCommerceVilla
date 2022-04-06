using Domain.Model.Addresses;
using Domain.Model.Orders;
using Domain.Model.SeedWork;

namespace Domain.Model.Usuarios
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }

        public string Nombres { get; set; }

        public string PrimerApellido { get; set; }

        public string UserName { get; set; }

        public virtual Address Address { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public bool Validate()
        {
            var isValid = false;

            if (!string.IsNullOrEmpty(Nombres)) isValid = true;

            return isValid;
        }

    }
}
