using App.Service.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
