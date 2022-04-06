using App.Service.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
