using App.Service.SeedWork;
using CSharpFunctionalExtensions;
using Domain.Model.Orders;
using Domain.Model.ProductsOrdes;

namespace App.Service.Orders.Commands.RegisterOrder
{
    public sealed class RegisterOrderCommandHandler : ICommandHandler<RegisterOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RegisterOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Result Handle(RegisterOrderCommand command)
        {
            var transOrder = _orderRepository.BeginTransaction();

            try
            {
                Order order = new();

                order.Monto = command.Order.Monto;
                order.FechaCompra = DateTime.Now;
                order.UsuarioId = command.Order.UsuarioId;

                List<ProductOrder> products = new();

                foreach (var item in command.Order.Products)
                {
                    var productOrder = new ProductOrder
                    {
                        OrderId = order.Id,
                        ProductId = item.Id
                    };

                    products.Add(productOrder);
                }

                order.ProductsOrders = products;

                _orderRepository.Add(order);
                _orderRepository.Save();

                transOrder.Commit();
            }
            catch (Exception)
            {
                transOrder.Rollback();
            }

            return Result.Success();
        }
    }
}
