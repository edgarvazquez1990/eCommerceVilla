using App.Service.Addresses.Commands.RegisterAddress;
using App.Service.SeedWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ui.Model.ViewModel;

namespace App.Api.Controllers
{
    [Route("address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly Messages _message;

        public AddressController(Messages message)
        {
            _message = message;
        }

        [Route("registrar")]
        [HttpPost]
        public IActionResult Register(AddressVM model)
        {
            _message.Dispatch(new RegisterAddressCommand(model));
            return Ok();
        }
    }
}
