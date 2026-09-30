using AppCore.Interfaces.Commands;

namespace AppCore.Features.Commands;

public record UpdateTaskCompletionCommand(int Id) : ICommandDefinition { }
