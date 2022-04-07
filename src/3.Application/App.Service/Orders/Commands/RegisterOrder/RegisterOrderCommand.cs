using App.Service.SeedWork;
using Ui.Model.ViewModel;

namespace App.Service.Orders.Commands.RegisterOrder
{
    public sealed class RegisterOrderCommand : ICommand
    {
        public OrderVM Order { get; }
        public RegisterOrderCommand(OrderVM order)
        {
            Order = order;
        }
    }
}
