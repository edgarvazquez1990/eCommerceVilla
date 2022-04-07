using App.Service.Orders.Commands.RegisterOrder;
using App.Service.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Ui.Model.ViewModel;

namespace App.Api.Controllers
{
    [Route("orden")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Messages _messages;

        public OrderController(Messages messages)
        {
            _messages = messages;
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(OrderVM model)
        {
            _messages.Dispatch(new RegisterOrderCommand(model));
            return Ok();
        }
    }
}
