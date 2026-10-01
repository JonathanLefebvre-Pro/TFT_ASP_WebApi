using AppCore.Interfaces.Commands;

namespace AppCore.Features.Commands;

public record AddTaskCommand(string Title) : ICommandDefinition<int>;
