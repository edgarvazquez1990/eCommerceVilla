using App.Service.SeedWork;
using Ui.Model.ViewModel;

namespace App.Service.Usuarios.Commands.RegisterUser
{
    public sealed class RegisterUserCommand : ICommand
    {
        public UsuarioVM Usuario { get; }
        public RegisterUserCommand(UsuarioVM usuario)
        {
            Usuario = usuario;
        }

        //public string Nombres { get; }

        //public string PrimerApellido { get; }

        //public string UserName { get; }

        //public RegisterUserCommand(string nombres, string primerApellido, string userName)
        //{
        //    Nombres = nombres;
        //    PrimerApellido = primerApellido;
        //    UserName = userName;
        //}
    }
}
