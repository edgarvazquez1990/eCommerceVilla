using CSharpFunctionalExtensions;

namespace App.Service.SeedWork
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
