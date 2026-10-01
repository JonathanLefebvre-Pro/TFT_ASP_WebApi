using WebApi.AppCore.Interfaces.Commands;

namespace WebApi.AppCore.Features.Commands;

public record DeleteTaskCommand(int Id) : ICommandDefinition;
