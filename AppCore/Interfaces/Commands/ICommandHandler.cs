using AppCore.Features.Results;

namespace AppCore.Interfaces.Commands;

public interface ICommandHandler<TCommand>
    where TCommand : ICommandDefinition
{
    Result Handle(TCommand command);
}

public interface ICommandHandler<TCommand, TResult>
    where TCommand : ICommandDefinition<TResult>
{
    Result<TResult> Handle(TCommand command);
}

public interface ICommandHandlerAsync<TCommand>
    where TCommand : ICommandDefinition
{
    Task<Result> Handle(TCommand command);
}

public interface ICommandHandlerAsync<TCommand, TResult>
    where TCommand : ICommandDefinition<TResult>
{
    Task<Result<TResult>> Handle(TCommand command);
}
