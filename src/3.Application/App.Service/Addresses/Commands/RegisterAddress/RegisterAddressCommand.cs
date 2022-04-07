using App.Service.SeedWork;
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
