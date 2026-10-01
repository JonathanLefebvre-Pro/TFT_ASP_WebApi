using AppCore.Interfaces.Commands;

namespace AppCore.Features.Commands;

public record UpdateTaskCommand(int Id, string Title, bool Completed) : ICommandDefinition;
