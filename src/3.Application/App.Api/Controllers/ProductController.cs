using App.Service.Products.Commands.RegisterProduct;
using App.Service.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Ui.Model.ViewModel;

namespace App.Api.Controllers
{
    [Route("producto")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Messages _messages;

        public ProductController(Messages messages)
        {
            _messages = messages;
        }

        [HttpPost]
        [Route("registrar")]        
        public IActionResult Registrar(ProductVM model)
        {
            _messages.Dispatch(new RegisterProductCommand(model));
            return Ok();
        }
    }
}
