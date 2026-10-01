using WebApi.AppCore.Interfaces.Commands;

namespace WebApi.AppCore.Features.Commands;

public record AddTaskCommand(string Title) : ICommandDefinition<int>;
