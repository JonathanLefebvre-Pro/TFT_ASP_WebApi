using System;

namespace AppCore.Interfaces.Commands;

public interface ICommandHandler<TCommand>
    where TCommand : ICommandDefinition
{
    bool Handle(TCommand command);
}
