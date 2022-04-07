using App.Service.SeedWork;
using CSharpFunctionalExtensions;
using Domain.Model.Addresses;

namespace App.Service.Addresses.Commands.RegisterAddress
{
    public sealed class RegisterAddressCommandHandler : ICommandHandler<RegisterAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;

        public RegisterAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Result Handle(RegisterAddressCommand command)
        {
            Address address = new();

            address.UsuarioId = command.Address.UsuarioId;
            address.Street = command.Address.Street;
            address.NumExt = command.Address.NumExt;

            _addressRepository.Add(address);
            _addressRepository.Save();

            return Result.Success();
        }
    }
}
