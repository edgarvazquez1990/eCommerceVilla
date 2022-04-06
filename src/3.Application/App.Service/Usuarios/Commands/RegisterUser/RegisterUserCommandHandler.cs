using App.Service.SeedWork;
using CSharpFunctionalExtensions;
using Domain.Model.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Usuarios.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public RegisterUserCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Result Handle(RegisterUserCommand command)
        {
            Usuario usuario = new();

            usuario.Nombres = command.Usuario.Nombres;
            usuario.PrimerApellido = command.Usuario.PrimerApellido;
            usuario.UserName = command.Usuario.UserName;

            _usuarioRepository.Add(usuario);
            _usuarioRepository.Save();

            return Result.Success();
        }
    }
}
