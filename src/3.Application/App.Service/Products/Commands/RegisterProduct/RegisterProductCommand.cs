using App.Service.SeedWork;
using Ui.Model.ViewModel;

namespace App.Service.Products.Commands.RegisterProduct
{
    public sealed class RegisterProductCommand : ICommand
    {
        public ProductVM Product { get; }
        public RegisterProductCommand(ProductVM product)
        {
            Product = product;
        }
    }
}
