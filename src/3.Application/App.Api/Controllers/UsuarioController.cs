using App.Service.SeedWork;
using App.Service.Usuarios.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using Ui.Model.ViewModel;

namespace App.Api.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Messages _message;

        public UsuarioController(Messages message)
        {
            _message = message;
        }

        [Route("registrar")]
        [HttpPost]
        public IActionResult Register(UsuarioVM model)
        {
            _message.Dispatch(new RegisterUserCommand(model));
            return Ok();
        }



    }
}
