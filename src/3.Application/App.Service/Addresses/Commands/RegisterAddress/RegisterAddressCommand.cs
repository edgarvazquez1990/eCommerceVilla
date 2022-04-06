using App.Service.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ui.Model.ViewModel;

namespace App.Service.Addresses.Commands.RegisterAddress
{
    public sealed class RegisterAddressCommand : ICommand
    {
        public AddressVM Address { get; }
        public RegisterAddressCommand(AddressVM address)
        {
            Address = address;
        }
    }
}
