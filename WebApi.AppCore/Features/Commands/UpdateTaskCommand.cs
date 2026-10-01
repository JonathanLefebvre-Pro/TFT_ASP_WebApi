using WebApi.AppCore.Interfaces.Commands;

namespace WebApi.AppCore.Features.Commands;

public record UpdateTaskCommand(int Id, string Title, bool Completed) : ICommandDefinition;
