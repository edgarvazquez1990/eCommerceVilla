using App.Service.SeedWork;
using CSharpFunctionalExtensions;
using Domain.Model.Products;

namespace App.Service.Products.Commands.RegisterProduct
{
    public sealed class RegisterProductCommandHandler : ICommandHandler<RegisterProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public RegisterProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Result Handle(RegisterProductCommand command)
        {
            Product product = new();

            product.Name = command.Product.Name;
            product.Price = command.Product.Price;

            _productRepository.Add(product);
            _productRepository.Save();

            return Result.Success();
        }
    }
}
